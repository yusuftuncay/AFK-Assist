using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AFK_Assist.Helpers;
using Timer = System.Windows.Forms.Timer;

namespace AFK_Assist;

public partial class Form : System.Windows.Forms.Form
{
    // Time Tracking
    private readonly Stopwatch _runStopwatch = new();
    private readonly Timer _elapsedUiTimer = new();
    private TimeSpan _pausedElapsedSnapshot = TimeSpan.Zero;

    // Randomness
    private readonly Random _randomNumberGenerator = new();

    // Simulation Lifecycle
    private CancellationTokenSource _simulationCancellation;
    private bool _isSimulationRunning;
    private bool _isPaused;

    // Window Focus
    private bool _switchToGamePerformedOnce;

    // Logging
    private bool _logHasEntry;

    // Scheduler State
    private int _currentMinuteBucketIndex = -1;
    private int _currentMinuteBucketStepIndex;
    private double[] _currentMinuteBucketScheduleSeconds;

    // Constructor
    public Form()
    {
        InitializeComponent();
        InitializeElapsedTimer();
        SetDefaultRandomization();
        ApplyKeyboardAutoDetection();
        _ = CheckForUpdatesAsync();

        InputLanguageChanged += Form_InputLanguageChanged;
    }

    #region Init
    private void InitializeElapsedTimer()
    {
        _elapsedUiTimer.Interval = 100;
        _elapsedUiTimer.Tick += ElapsedTimer_Tick;
    }

    private void SetDefaultRandomization()
    {
        RandomizeToolStripMenuItem.Checked = true;
        RandomizeIntervalsToolStripMenuItem.Checked = true;
    }

    private void ApplyKeyboardAutoDetection()
    {
        try
        {
            // Get Current Layout Data
            var currentLanguage = InputLanguage.CurrentInputLanguage;
            var currentCulture = currentLanguage?.Culture ?? CultureInfo.CurrentCulture;
            var layoutName = (currentLanguage?.LayoutName ?? string.Empty).ToLowerInvariant();

            // Detect Belgian Or Azerty
            var isBelgium = currentCulture.Name.EndsWith("-BE", StringComparison.OrdinalIgnoreCase);
            var nameIsAzerty =
                layoutName.Contains("azerty")
                || layoutName.Contains("belgian")
                || layoutName.Contains("belgië")
                || layoutName.Contains("belgique");

            // Determine Desired State
            var isAzerty = isBelgium || nameIsAzerty;
            var currentAzertyState = AzertyToolStripMenuItem.Checked;

            // Apply Correct Toggle
            if (isAzerty && !currentAzertyState)
                AzertyToolStripMenuItem.PerformClick();
            else if (!isAzerty && currentAzertyState)
                AzertyToolStripMenuItem.PerformClick();
        }
        catch { }
    }
    #endregion

    #region Update Check
    private async Task CheckForUpdatesAsync(bool showNoUpdateMessageBox = false)
    {
        try
        {
            // Check Latest Release
            var updateResult = await UpdateChecker.CheckAsync();
            if (updateResult == null)
                return;

            // Prompt if Available
            if (updateResult.UpdateAvailable)
            {
                var message =
                    "A New Version is Available\n\n"
                    + "Current: "
                    + UpdateChecker.GetCurrentVersion()
                    + "\n"
                    + "Latest:  "
                    + updateResult.Latest
                    + "\n\nOpen the Release Page?";

                var openRelease =
                    MessageBox.Show(
                        this,
                        message,
                        "Update Available",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    ) == DialogResult.Yes;

                if (openRelease)
                {
                    UpdateChecker.OpenRelease(updateResult.ReleaseUrl);
                }
            }
            else if (showNoUpdateMessageBox)
            {
                // Show No Update Message
                var message =
                    "You are Using the Latest Available Version\n\nCurrent: v"
                    + UpdateChecker.GetCurrentVersion();

                MessageBox.Show(this, message, "No Update Available", MessageBoxButtons.OK);
            }
        }
        catch { }
    }
    #endregion

    #region Start Stop Pause
    private async void ButtonStart_ClickAsync(object sender, EventArgs e)
    {
        // Pause When Running
        if (ButtonStart.Text == "Pause")
        {
            PauseSimulation();
            return;
        }

        // Resume When Paused
        if (_isPaused)
        {
            await ResumeSimulationAsync();
            return;
        }

        // Validate User Selection
        if (!ValidateAnyInputSelected())
        {
            HighlightInputSelectionError();
            return;
        }

        // Start Fresh Run
        await StartSimulationAsync();
    }

    private void ButtonStop_Click(object sender, EventArgs e)
    {
        // Write Stop Log
        UpdateLog("Stopped");

        // Cancel Active Work
        _simulationCancellation?.Cancel();

        // Stop Timers
        _elapsedUiTimer.Stop();
        _runStopwatch.Stop();

        // Choose Final Elapsed
        var finalElapsed = _isPaused ? _pausedElapsedSnapshot : _runStopwatch.Elapsed;

        // Restore UI State
        EnableConfigurations();

        _isPaused = false;
        _isSimulationRunning = false;
        ButtonStart.Text = "Start";

        // Format Time Display
        var elapsedHours = (int)finalElapsed.TotalHours;
        var elapsedMinutes = (int)finalElapsed.TotalMinutes % 60;
        var elapsedSeconds = (int)finalElapsed.TotalSeconds % 60;

        var totalMinutes = TrackBarLength.Value;
        var displayTime =
            totalMinutes >= 60 && elapsedHours > 0
                ? $"{elapsedHours:00}:{elapsedMinutes:00}:{elapsedSeconds:00}"
                : $"{elapsedMinutes:00}:{elapsedSeconds:00}";

        // Set Final Label Text
        LabelElapsedTime.Text = $"Elapsed: {displayTime}\nRemaining: 00:00";
    }

    private void PauseSimulation()
    {
        // Write Pause Log
        UpdateLog("Paused");

        // Snapshot Current Elapsed
        _isPaused = true;
        _pausedElapsedSnapshot = _runStopwatch.Elapsed;

        // Stop Active Timers
        _elapsedUiTimer.Stop();
        _runStopwatch.Stop();

        // Update Button State
        ButtonStart.Text = "Resume";
        ButtonStart.Enabled = true;
    }

    private async Task ResumeSimulationAsync()
    {
        // Write Resume Log
        UpdateLog("Resumed");

        // Clear Pause State
        _isPaused = false;

        // Focus Game if Needed
        GameWindowFinder.TryFocusKnownGameWindow(SwitchToGameToolStripMenuItem.Checked);

        // Restart Timers
        _runStopwatch.Start();
        _elapsedUiTimer.Start();

        // Update Button State
        ButtonStart.Text = "Pause";

        // Focus Once When Enabled
        if (SwitchToGameToolStripMenuItem.Checked && !_switchToGamePerformedOnce)
        {
            await FocusGameOnceAsync();
        }
    }
    #endregion

    #region Start Helpers
    private bool ValidateAnyInputSelected()
    {
        // Check Mouse Selection
        var hasMouse = MouseClickLeftCheckBox.Checked || MouseClickRightCheckBox.Checked;

        // Check Keyboard Selection
        var hasKeyboard =
            WKeyCheckBox.Checked
            || AKeyCheckBox.Checked
            || SKeyCheckBox.Checked
            || DKeyCheckBox.Checked;

        return hasMouse || hasKeyboard;
    }

    private void HighlightInputSelectionError()
    {
        // Highlight Related Controls
        MouseClickLeftCheckBox.ForeColor = Color.Red;
        MouseClickRightCheckBox.ForeColor = Color.Red;
        WKeyCheckBox.ForeColor = Color.Red;
        AKeyCheckBox.ForeColor = Color.Red;
        SKeyCheckBox.ForeColor = Color.Red;
        DKeyCheckBox.ForeColor = Color.Red;

        // Show Error Message
        MessageBox.Show(
            "Please Select At Least One Input",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );

        // Restore Default Colors
        MouseClickLeftCheckBox.ForeColor = SystemColors.ControlText;
        MouseClickRightCheckBox.ForeColor = SystemColors.ControlText;
        WKeyCheckBox.ForeColor = SystemColors.ControlText;
        AKeyCheckBox.ForeColor = SystemColors.ControlText;
        SKeyCheckBox.ForeColor = SystemColors.ControlText;
        DKeyCheckBox.ForeColor = SystemColors.ControlText;
    }

    private async Task StartSimulationAsync()
    {
        // Write Start Log
        UpdateLog("Started");

        // Focus Game if Needed
        GameWindowFinder.TryFocusKnownGameWindow(SwitchToGameToolStripMenuItem.Checked);

        // Reset Timers
        _runStopwatch.Reset();
        _elapsedUiTimer.Stop();

        // Reset Runtime Flags
        _isPaused = false;
        _switchToGamePerformedOnce = false;
        _logHasEntry = false;
        _isSimulationRunning = true;

        // Reset Scheduler State
        _currentMinuteBucketIndex = -1;
        _currentMinuteBucketStepIndex = 0;
        _currentMinuteBucketScheduleSeconds = null;

        // Cancel Previous Run
        _simulationCancellation?.Cancel();
        _simulationCancellation = new CancellationTokenSource();

        // Render Initial UI
        UpdateElapsedTimeDisplay();

        // Start Timers
        _runStopwatch.Start();
        _elapsedUiTimer.Start();

        // Lock Configuration UI
        DisableConfigurations();

        // Update Button State
        ButtonStart.Text = "Pause";
        ButtonStart.Enabled = true;

        // Focus Once When Enabled
        if (SwitchToGameToolStripMenuItem.Checked && !_switchToGamePerformedOnce)
        {
            await FocusGameOnceAsync();
        }

        // Start Background Loop
        await RunSimulationLoopAsync(_simulationCancellation.Token);

        // Stop After Active Duration
        try
        {
            // Compute Target Duration
            var totalDuration = TimeSpan.FromMinutes(TrackBarLength.Value);

            while (!_simulationCancellation.Token.IsCancellationRequested)
            {
                // Stop When Time Reached
                if (!_isPaused && _runStopwatch.Elapsed >= totalDuration)
                {
                    ButtonStop.PerformClick();
                    break;
                }

                // Keep Loop Responsive
                await Task.Delay(100, _simulationCancellation.Token);
            }
        }
        catch (TaskCanceledException) { }
    }

    private async Task FocusGameOnceAsync()
    {
        // Wait Before Focusing
        await Task.Delay(800, _simulationCancellation.Token);
        if (_simulationCancellation.Token.IsCancellationRequested)
            return;

        // Attempt Window Focus
        var focused = GameWindowFinder.TryFocusKnownGameWindow(
            SwitchToGameToolStripMenuItem.Checked
        );

        // Write Focus Result
        UpdateLog(focused ? "Game Focused" : "Game Focus Failed");

        // Record One Time Focus
        _switchToGamePerformedOnce = true;
    }

    private void Form_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
    {
        // Reapply Auto Detection
        ApplyKeyboardAutoDetection();
    }
    #endregion
}
