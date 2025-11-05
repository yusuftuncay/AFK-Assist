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
    // Runtime State
    private readonly Stopwatch _runStopwatch = new();
    private readonly Random _randomNumberGenerator = new();
    private readonly Timer _elapsedUiTimer = new();
    private CancellationTokenSource _simulationCancellation;
    private bool _isPaused;
    private bool _isSimulationRunning;
    private bool _switchToGamePerformedOnce;
    private bool _logHasEntry;
    private TimeSpan _pausedElapsedSnapshot = TimeSpan.Zero;

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
    // Elapsed Timer Init
    private void InitializeElapsedTimer()
    {
        _elapsedUiTimer.Interval = 100;
        _elapsedUiTimer.Tick += ElapsedTimer_Tick;
    }

    // Default Randomization
    private void SetDefaultRandomization()
    {
        RandomizeToolStripMenuItem.Checked = true;
        RandomizeIntervalsToolStripMenuItem.Checked = true;
    }

    // Keyboard Auto Detect
    private void ApplyKeyboardAutoDetection()
    {
        try
        {
            var currentLanguage = InputLanguage.CurrentInputLanguage;
            var currentCulture = currentLanguage?.Culture ?? CultureInfo.CurrentCulture;
            var layoutName = (currentLanguage?.LayoutName ?? string.Empty).ToLowerInvariant();

            var isBelgium = currentCulture.Name.EndsWith("-BE", StringComparison.OrdinalIgnoreCase);
            var nameIsAzerty =
                layoutName.Contains("azerty")
                || layoutName.Contains("belgian")
                || layoutName.Contains("belgië")
                || layoutName.Contains("belgique");

            var isAzerty = isBelgium || nameIsAzerty;
            var currentAzertyState = AzertyToolStripMenuItem.Checked;

            if (isAzerty && !currentAzertyState)
                AzertyToolStripMenuItem.PerformClick();
            else if (!isAzerty && currentAzertyState)
                AzertyToolStripMenuItem.PerformClick();
        }
        catch { }
    }
    #endregion

    #region Update Check
    // Update Check
    private async Task CheckForUpdatesAsync(bool showNoUpdateMessageBox = false)
    {
        try
        {
            var result = await UpdateChecker.CheckAsync();
            if (result == null)
                return;

            if (result.UpdateAvailable)
            {
                var message =
                    "A New Version is Available\n\n"
                    + "Current: "
                    + Application.ProductVersion
                    + "\n"
                    + "Latest:  "
                    + result.Latest
                    + "\n\nOpen the Release Page?";
                if (
                    MessageBox.Show(
                        this,
                        message,
                        "Update Available",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    ) == DialogResult.Yes
                )
                {
                    UpdateChecker.OpenRelease(result.ReleaseUrl);
                }
            }
            else if (showNoUpdateMessageBox)
            {
                var message =
                    "You are Using the Latest Available Version\n\nCurrent: v"
                    + Application.ProductVersion;
                MessageBox.Show(this, message, "No Update Available", MessageBoxButtons.OK);
            }
        }
        catch { }
    }
    #endregion

    #region Start Stop Pause
    // Start Entry
    private async void ButtonStart_ClickAsync(object sender, EventArgs e)
    {
        if (ButtonStart.Text == "Pause")
        {
            PauseSimulation();
            return;
        }

        if (_isPaused)
        {
            await ResumeSimulationAsync();
            return;
        }

        if (!ValidateAnyInputSelected())
        {
            HighlightInputSelectionError();
            return;
        }

        await StartSimulationAsync();
    }

    // Stop Entry
    private void ButtonStop_Click(object sender, EventArgs e)
    {
        UpdateLog("Stopped");

        _simulationCancellation?.Cancel();

        MainTimer.Stop();
        _elapsedUiTimer.Stop();
        _runStopwatch.Stop();

        var finalElapsed = _isPaused ? _pausedElapsedSnapshot : _runStopwatch.Elapsed;

        EnableConfigurations();
        SetTimerInterval(1);

        _isPaused = false;
        _isSimulationRunning = false;
        ButtonStart.Text = "Start";

        var hours = (int)finalElapsed.TotalHours;
        var minutes = (int)finalElapsed.TotalMinutes % 60;
        var seconds = (int)finalElapsed.TotalSeconds % 60;

        var totalMinutes = TrackBarLength.Value;
        var displayTime =
            totalMinutes >= 60 && hours > 0
                ? $"{hours:00}:{minutes:00}:{seconds:00}"
                : $"{minutes:00}:{seconds:00}";

        LabelElapsedTime.Text = $"Elapsed: {displayTime}\nRemaining: 00:00";
    }

    // Pause Action
    private void PauseSimulation()
    {
        UpdateLog("Paused");

        _isPaused = true;

        _pausedElapsedSnapshot = _runStopwatch.Elapsed;

        MainTimer.Stop();
        _elapsedUiTimer.Stop();
        _runStopwatch.Stop();

        ButtonStart.Text = "Resume";
        ButtonStart.Enabled = true;
    }

    // Resume Action
    private async Task ResumeSimulationAsync()
    {
        UpdateLog("Resumed");

        _isPaused = false;

        GameWindowFinder.TryFocusKnownGameWindow(SwitchToGameToolStripMenuItem.Checked);

        _runStopwatch.Start();
        _elapsedUiTimer.Start();
        MainTimer.Start();

        ButtonStart.Text = "Pause";

        if (SwitchToGameToolStripMenuItem.Checked && !_switchToGamePerformedOnce)
        {
            await FocusGameOnceAsync();
        }
    }
    #endregion

    #region Start Helpers
    // Validate Selection
    private bool ValidateAnyInputSelected()
    {
        var hasMouse = MouseClickLeftCheckBox.Checked || MouseClickRightCheckBox.Checked;
        var hasKeyboard =
            WKeyCheckBox.Checked
            || AKeyCheckBox.Checked
            || SKeyCheckBox.Checked
            || DKeyCheckBox.Checked;
        return hasMouse || hasKeyboard;
    }

    // Highlight Error
    private void HighlightInputSelectionError()
    {
        MouseClickLeftCheckBox.ForeColor = Color.Red;
        MouseClickRightCheckBox.ForeColor = Color.Red;
        WKeyCheckBox.ForeColor = Color.Red;
        AKeyCheckBox.ForeColor = Color.Red;
        SKeyCheckBox.ForeColor = Color.Red;
        DKeyCheckBox.ForeColor = Color.Red;

        MessageBox.Show(
            "Please Select At Least One Input",
            "Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        );

        MouseClickLeftCheckBox.ForeColor = SystemColors.ControlText;
        MouseClickRightCheckBox.ForeColor = SystemColors.ControlText;
        WKeyCheckBox.ForeColor = SystemColors.ControlText;
        AKeyCheckBox.ForeColor = SystemColors.ControlText;
        SKeyCheckBox.ForeColor = SystemColors.ControlText;
        DKeyCheckBox.ForeColor = SystemColors.ControlText;
    }

    // Start Body
    private async Task StartSimulationAsync()
    {
        UpdateLog("Started");

        GameWindowFinder.TryFocusKnownGameWindow(SwitchToGameToolStripMenuItem.Checked);

        _runStopwatch.Reset();
        MainTimer.Stop();
        _elapsedUiTimer.Stop();

        SetTimerInterval(60 / TrackBarSpeed.Value);

        _isPaused = false;
        _switchToGamePerformedOnce = false;
        _logHasEntry = false;
        _isSimulationRunning = true;
        _simulationCancellation = new CancellationTokenSource();

        UpdateElapsedTimeDisplay();

        _runStopwatch.Start();
        _elapsedUiTimer.Start();
        MainTimer.Start();
        DisableConfigurations();

        ButtonStart.Text = "Pause";
        ButtonStart.Enabled = true;

        if (SwitchToGameToolStripMenuItem.Checked && !_switchToGamePerformedOnce)
        {
            await FocusGameOnceAsync();
        }

        try
        {
            await Task.Delay(TrackBarLength.Value * 60000, _simulationCancellation.Token);
            if (!_simulationCancellation.Token.IsCancellationRequested)
                ButtonStop.PerformClick();
        }
        catch (TaskCanceledException) { }
    }

    // Focus Once
    private async Task FocusGameOnceAsync()
    {
        await Task.Delay(800, _simulationCancellation.Token);
        if (_simulationCancellation.Token.IsCancellationRequested)
            return;

        var focused = GameWindowFinder.TryFocusKnownGameWindow(
            SwitchToGameToolStripMenuItem.Checked
        );
        UpdateLog(focused ? "Game Focused" : "Game Focus Failed");

        _switchToGamePerformedOnce = true;
    }

    // Layout Change Handler
    private void Form_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
    {
        var previousAzerty = AzertyToolStripMenuItem.Checked;
        ApplyKeyboardAutoDetection();
        var newAzerty = AzertyToolStripMenuItem.Checked;

        if (previousAzerty != newAzerty)
        {
            var layoutType = AzertyToolStripMenuItem.Checked ? "AZERTY" : "QWERTY";
            UpdateLog($"{layoutType} Layout Applied");
        }
    }
    #endregion
}
