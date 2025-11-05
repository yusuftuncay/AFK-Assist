using AFK_Assist.Classes;
using AFK_Assist.Services;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AFK_Assist
{
    public partial class Form : System.Windows.Forms.Form
    {
        // Runtime State
        private readonly Stopwatch runStopwatch = new Stopwatch();
        private readonly Random randomNumberGenerator = new Random();
        private readonly Timer elapsedUiTimer = new Timer();
        private CancellationTokenSource simulationCancellation;
        private bool isPaused = false;
        private bool isSimulationRunning = false;
        private bool switchToGamePerformedOnce = false;
        private bool logHasEntry = false;
        private TimeSpan pausedElapsedSnapshot = TimeSpan.Zero;

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
            elapsedUiTimer.Interval = 100;
            elapsedUiTimer.Tick += ElapsedTimer_Tick;
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

                var isBelgium = currentCulture.Name.EndsWith(
                    "-BE",
                    StringComparison.OrdinalIgnoreCase
                );
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

            if (isPaused)
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
            simulationCancellation?.Cancel();

            MainTimer.Stop();
            elapsedUiTimer.Stop();
            runStopwatch.Stop();

            var finalElapsed = isPaused ? pausedElapsedSnapshot : runStopwatch.Elapsed;

            EnableConfigurations();
            SetTimerInterval(1);

            isPaused = false;
            isSimulationRunning = false;
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
            isPaused = true;

            pausedElapsedSnapshot = runStopwatch.Elapsed;

            MainTimer.Stop();
            elapsedUiTimer.Stop();
            runStopwatch.Stop();

            ButtonStart.Text = "Resume";
            ButtonStart.Enabled = true;
        }

        // Resume Action
        private async Task ResumeSimulationAsync()
        {
            isPaused = false;

            GameWindowFinder.TryFocusKnownGameWindow(SwitchToGameToolStripMenuItem.Checked);

            runStopwatch.Start();
            elapsedUiTimer.Start();
            MainTimer.Start();

            ButtonStart.Text = "Pause";

            if (SwitchToGameToolStripMenuItem.Checked && !switchToGamePerformedOnce)
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
            GameWindowFinder.TryFocusKnownGameWindow(SwitchToGameToolStripMenuItem.Checked);

            runStopwatch.Reset();
            MainTimer.Stop();
            elapsedUiTimer.Stop();

            SetTimerInterval(60 / TrackBarSpeed.Value);

            isPaused = false;
            switchToGamePerformedOnce = false;
            logHasEntry = false;
            isSimulationRunning = true;
            simulationCancellation = new CancellationTokenSource();

            UpdateElapsedTimeDisplay();

            runStopwatch.Start();
            elapsedUiTimer.Start();
            MainTimer.Start();
            DisableConfigurations();

            ButtonStart.Text = "Pause";
            ButtonStart.Enabled = true;

            if (SwitchToGameToolStripMenuItem.Checked && !switchToGamePerformedOnce)
            {
                await FocusGameOnceAsync();
            }

            try
            {
                await Task.Delay(TrackBarLength.Value * 60000, simulationCancellation.Token);
                if (!simulationCancellation.Token.IsCancellationRequested)
                    ButtonStop.PerformClick();
            }
            catch (TaskCanceledException) { }
        }

        // Focus Once
        private async Task FocusGameOnceAsync()
        {
            await Task.Delay(800, simulationCancellation.Token);
            if (simulationCancellation.Token.IsCancellationRequested)
                return;

            var focused = GameWindowFinder.TryFocusKnownGameWindow(
                SwitchToGameToolStripMenuItem.Checked
            );
            UpdateLog(focused ? "Game Focused" : "Game Focus Failed");

            switchToGamePerformedOnce = true;
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
}
