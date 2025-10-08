using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AFK_Assist
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly Random random = new Random();
        private readonly Timer elapsedTimer = new Timer();
        private bool loopRanOnce = false;
        private bool altTabbed = false;
        private int loopNumber = 0;
        private int totalLoops = 0;
        private CancellationTokenSource cancellationTokenSource;
        private bool isPaused = false;
        private TimeSpan pausedElapsedTime = TimeSpan.Zero;
        private bool isSimulationRunning = false;

        public Form()
        {
            InitializeComponent();
            InitializeElapsedTimer();
            InitializeMenuStripHover();
        }

        private void InitializeElapsedTimer()
        {
            elapsedTimer.Interval = 100;
            elapsedTimer.Tick += ElapsedTimer_Tick;
        }

        private void InitializeMenuStripHover()
        {
            // Enable Menu Hover Behavior
            MenuStrip.MenuActivate += (s, e) => { };
        }

        private void ElapsedTimer_Tick(object sender, EventArgs e)
        {
            UpdateElapsedTimeDisplay();
        }

        #region Import And Use DLL
        [DllImport("user32.dll")]
        public static extern void mouse_event(
            uint dwFlags,
            uint dx,
            uint dy,
            uint cButtons,
            uint dwExtraInfo
        );

        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        const uint MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        const int KEYEVENTF_KEYUP = 0x0002;
        #endregion

        #region Buttons
        private async void ButtonStart_ClickAsync(object sender, EventArgs e)
        {
            // Handle Pause
            if (ButtonStart.Text == "Pause")
            {
                PauseSimulation();
                return;
            }

            // Handle Resume
            if (isPaused)
            {
                ResumeSimulation();
                return;
            }

            // Check If Any Input Is Selected
            bool hasMouseInput = MouseClickLeftCheckBox.Checked || MouseClickRightCheckBox.Checked;
            bool hasKeyboardInput =
                WKeyCheckBox.Checked
                || AKeyCheckBox.Checked
                || SKeyCheckBox.Checked
                || DKeyCheckBox.Checked;

            if (!hasMouseInput && !hasKeyboardInput)
            {
                // Highlight
                MouseClickLeftCheckBox.ForeColor = Color.Red;
                MouseClickRightCheckBox.ForeColor = Color.Red;
                WKeyCheckBox.ForeColor = Color.Red;
                AKeyCheckBox.ForeColor = Color.Red;
                SKeyCheckBox.ForeColor = Color.Red;
                DKeyCheckBox.ForeColor = Color.Red;

                DialogResult result = MessageBox.Show(
                    "Please Select At Least One Input",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                if (result == DialogResult.OK)
                {
                    // Reset Colors
                    MouseClickLeftCheckBox.ForeColor = SystemColors.ControlText;
                    MouseClickRightCheckBox.ForeColor = SystemColors.ControlText;
                    WKeyCheckBox.ForeColor = SystemColors.ControlText;
                    AKeyCheckBox.ForeColor = SystemColors.ControlText;
                    SKeyCheckBox.ForeColor = SystemColors.ControlText;
                    DKeyCheckBox.ForeColor = SystemColors.ControlText;
                }
                return;
            }

            // Calculate Total Loops
            totalLoops = TrackBarLength.Value * TrackBarSpeed.Value;

            // Reset And Start Timer
            stopwatch.Reset();
            MainTimer.Stop();
            elapsedTimer.Stop();
            SetTimerInterval(60 / TrackBarSpeed.Value);
            loopNumber = 0;
            altTabbed = false;
            isPaused = false;
            pausedElapsedTime = TimeSpan.Zero;
            isSimulationRunning = true;
            cancellationTokenSource = new CancellationTokenSource();

            // Initialize Display Immediately
            UpdateElapsedTimeDisplay();

            stopwatch.Start();
            elapsedTimer.Start();
            MainTimer.Start();
            DisableConfigurations();

            // Change to Pause State
            ButtonStart.Text = "Pause";
            ButtonStart.Enabled = true;

            try
            {
                // Duration Based On TrackBar Value
                await Task.Delay(TrackBarLength.Value * 60000, cancellationTokenSource.Token);

                if (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    ButtonStop.PerformClick();
                }
            }
            catch (TaskCanceledException)
            {
                // Expected When Stop Is Clicked
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            // Cancel Running Task Immediately
            cancellationTokenSource?.Cancel();

            // Stop All Timers First
            MainTimer.Stop();
            elapsedTimer.Stop();
            stopwatch.Stop();

            // Capture Final Elapsed Time Immediately
            TimeSpan finalElapsedTime = isPaused ? pausedElapsedTime : stopwatch.Elapsed;

            // Re Enable Controls
            EnableConfigurations();
            SetTimerInterval(1);

            // Reset Pause State
            isPaused = false;
            pausedElapsedTime = TimeSpan.Zero;
            isSimulationRunning = false;
            ButtonStart.Text = "Start";

            // Calculate Elapsed Time From Snapshot
            int hours = (int)finalElapsedTime.TotalHours;
            int minutes = (int)finalElapsedTime.TotalMinutes % 60;
            int seconds = (int)finalElapsedTime.TotalSeconds % 60;

            // Update Display With Final Time
            int totalMinutes = TrackBarLength.Value;
            string displayTime =
                totalMinutes >= 60 && hours > 0
                    ? $"{hours:00}:{minutes:00}:{seconds:00}"
                    : $"{minutes:00}:{seconds:00}";

            LabelElapsedTime.Text = $"Elapsed: {displayTime}\nRemaining: 00:00";

            // Format Time Message For MessageBox
            //string timeMessage =
            //    hours > 0
            //        ? $"Elapsed Time {hours:00}:{minutes:00}:{seconds:00}"
            //        : $"Elapsed Time {minutes:00}:{seconds:00}";

            //MessageBox.Show(timeMessage, "Stopped");
        }

        private void PauseSimulation()
        {
            isPaused = true;
            pausedElapsedTime = stopwatch.Elapsed;

            // Stop Timers
            MainTimer.Stop();
            elapsedTimer.Stop();
            stopwatch.Stop();

            // Change to Resume State
            ButtonStart.Text = "Resume";
            ButtonStart.Enabled = true;
        }

        private void ResumeSimulation()
        {
            isPaused = false;

            // Resume Timers
            stopwatch.Start();
            elapsedTimer.Start();
            MainTimer.Start();

            // Change to Pause State
            ButtonStart.Text = "Pause";
        }
        #endregion

        #region Timer
        private async void Timer_TickAsync(object sender, EventArgs e)
        {
            // Stop Immediately Check
            if (cancellationTokenSource?.Token.IsCancellationRequested == true)
                return;

            // Check if Paused
            if (isPaused)
                return;

            // Alt Tab Once Per Session
            if (AltTabToolStripMenuItem.Checked && !altTabbed)
            {
                SendKeys.Send("%{TAB}");
                UpdateLog("* Alt + Tab");
                altTabbed = true;
            }

            // Execute Simulation Asynchronously
            await ExecuteSimulationAsync();

            loopNumber++;

            // Calculate And Display Remaining Loops
            int remainingLoops = totalLoops - loopNumber;
            UpdateLog($"{remainingLoops} Loop{(remainingLoops == 1 ? "" : "s")} Remaining\n\r");

            // Update Timer Interval for Precision
            SetTimerInterval(60 / TrackBarSpeed.Value);
        }

        private async Task ExecuteSimulationAsync()
        {
            // Check Cancellation Before Executing
            if (cancellationTokenSource?.Token.IsCancellationRequested == true)
                return;

            // Execute Key Simulation
            if (RandomizeToolStripMenuItem.Checked)
                await RandomizeKeyPressesAsync();
            else
                await SequentialKeyPressesAsync();

            // Check Cancellation Before Mouse Clicks
            if (cancellationTokenSource?.Token.IsCancellationRequested == true)
                return;

            // Handle Mouse Clicks
            await ExecuteMouseClicksAsync();
        }

        private async Task RandomizeKeyPressesAsync()
        {
            bool[] keysPressed = new bool[4];
            int pressedCount = 0;

            while (pressedCount < 4)
            {
                // Check Cancellation During Key Presses
                if (cancellationTokenSource?.Token.IsCancellationRequested == true)
                    return;

                int keyIndex = random.Next(4);
                if (!keysPressed[keyIndex])
                {
                    await ExecuteKeyPressAsync(keyIndex);
                    keysPressed[keyIndex] = true;
                    pressedCount++;
                }
            }
        }

        private async Task SequentialKeyPressesAsync()
        {
            if (AzertyToolStripMenuItem.Checked)
            {
                // Z & Q Key For Azerty
                await ExecuteKeyPressAsync(4);
                await ExecuteKeyPressAsync(5);
            }
            else
            {
                // W & A Key For Qwerty
                await ExecuteKeyPressAsync(0);
                await ExecuteKeyPressAsync(1);
            }

            // S & D Key For Both
            await ExecuteKeyPressAsync(2);
            await ExecuteKeyPressAsync(3);
        }

        private async Task ExecuteKeyPressAsync(int keyIndex)
        {
            switch (keyIndex)
            {
                case 0:
                    if (WKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.W, "* W Key");
                    break;
                case 1:
                    if (AKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.A, "* A Key");
                    break;
                case 2:
                    if (SKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.S, "* S Key");
                    break;
                case 3:
                    if (DKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.D, "* D Key");
                    break;
                case 4:
                    if (WKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.Z, "* Z Key");
                    break;
                case 5:
                    if (AKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.Q, "* Q Key");
                    break;
            }
        }

        private async Task PressAndReleaseKeyAsync(Keys key, string logMessage)
        {
            // Log Immediately
            UpdateLog(logMessage);

            await Task.Run(() =>
            {
                // Press Key
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
                Thread.Sleep(100);
                // Release Key
                keybd_event((byte)key, 0x45, KEYEVENTF_KEYUP, 0);
            });
        }

        private async Task ExecuteMouseClicksAsync()
        {
            // Left Click
            if (MouseClickLeftCheckBox.Checked)
            {
                // Log Immediately
                UpdateLog("* Left Mouse");

                await Task.Run(() =>
                {
                    // Press Left Button
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    // Release Left Button
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                });
            }

            // Right Click
            if (MouseClickRightCheckBox.Checked)
            {
                // Log Immediately
                UpdateLog("* Right Mouse");

                await Task.Run(() =>
                {
                    // Press Right Button
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(100);
                    // Release Right Button
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                });
            }
        }

        private void UpdateElapsedTimeDisplay()
        {
            if (stopwatch.IsRunning || isPaused || isSimulationRunning)
            {
                // Capture Current Time Snapshot
                TimeSpan currentElapsed = isPaused ? pausedElapsedTime : stopwatch.Elapsed;

                // Calculate Elapsed Time
                int elapsedHours = (int)currentElapsed.TotalHours;
                int elapsedMinutes = (int)currentElapsed.TotalMinutes % 60;
                int elapsedSeconds = (int)currentElapsed.TotalSeconds % 60;

                // Calculate Remaining Time
                int totalMinutes = TrackBarLength.Value;
                int totalSeconds = totalMinutes * 60;
                int elapsedTotalSeconds = (int)currentElapsed.TotalSeconds;
                int remainingSeconds = Math.Max(0, totalSeconds - elapsedTotalSeconds);

                int remainingHours = remainingSeconds / 3600;
                int remainingMinutes = (remainingSeconds % 3600) / 60;
                int remainingSecondsOnly = remainingSeconds % 60;

                // Format Elapsed Time
                string elapsedTime =
                    totalMinutes >= 60 && elapsedHours > 0
                        ? $"{elapsedHours:00}:{elapsedMinutes:00}:{elapsedSeconds:00}"
                        : $"{elapsedMinutes:00}:{elapsedSeconds:00}";

                // Format Remaining Time
                string remainingTime =
                    totalMinutes >= 60
                        ? $"{remainingHours:00}:{remainingMinutes:00}:{remainingSecondsOnly:00}"
                        : $"{remainingMinutes:00}:{remainingSecondsOnly:00}";

                // Ensure UI Updates Happen on UI Thread
                if (LabelElapsedTime.InvokeRequired)
                {
                    LabelElapsedTime.Invoke(
                        new Action(() =>
                        {
                            LabelElapsedTime.Text =
                                $"Elapsed: {elapsedTime}\nRemaining: {remainingTime}";
                        })
                    );
                }
                else
                {
                    LabelElapsedTime.Text = $"Elapsed: {elapsedTime}\nRemaining: {remainingTime}";
                }
            }
        }

        public void SetTimerInterval(int seconds)
        {
            MainTimer.Interval = seconds * 1000;
        }
        #endregion

        #region Enable/Disable Configuration Methods
        private void EnableConfigurations()
        {
            // Enable Menu Items
            AltTabToolStripMenuItem.Enabled = true;
            HelpToolStripMenuItem.Enabled = true;
            ExtraOptionsToolStripMenuItem.Enabled = true;
            PresetsToolStripMenuItem.Enabled = true;

            // Enable Input Groups
            MouseGroupBox.Enabled = true;
            KeyboardGroupBox.Enabled = true;

            // Enable TrackBars
            TrackBarLength.Enabled = true;
            TrackBarSpeed.Enabled = true;

            // Enable Start Button
            ButtonStart.Enabled = true;
            ButtonStop.Enabled = false;
        }

        private void DisableConfigurations()
        {
            // Disable Menu Items
            AltTabToolStripMenuItem.Enabled = false;
            HelpToolStripMenuItem.Enabled = false;
            ExtraOptionsToolStripMenuItem.Enabled = false;
            PresetsToolStripMenuItem.Enabled = false;

            // Disable Input Groups
            MouseGroupBox.Enabled = false;
            KeyboardGroupBox.Enabled = false;

            // Disable TrackBars
            TrackBarLength.Enabled = false;
            TrackBarSpeed.Enabled = false;

            // Enable Start/Stop Button
            ButtonStart.Enabled = true;
            ButtonStop.Enabled = true;

            // Reset State
            loopRanOnce = false;
            altTabbed = false;
            loopNumber = 0;
            TextBoxLog.Text = "";
        }
        #endregion

        #region Update Log
        public void UpdateLog(string text)
        {
            // Ensure UI Updates Happen on UI Thread
            if (TextBoxLog.InvokeRequired)
                TextBoxLog.Invoke(new Action(() => UpdateLogInternal(text)));
            else
                UpdateLogInternal(text);
        }

        private void UpdateLogInternal(string text)
        {
            if (!loopRanOnce)
            {
                TextBoxLog.Text += text;
                loopRanOnce = true;
            }
            else
            {
                TextBoxLog.Text += $"\n\r\n\r{text}";
            }

            // Auto Scroll To Bottom
            TextBoxLog.SelectionStart = TextBoxLog.TextLength;
            TextBoxLog.ScrollToCaret();
        }
        #endregion

        #region MenuStrip
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Uncheck Extra Options
            AltTabToolStripMenuItem.Checked = false;
            RandomizeToolStripMenuItem.Checked = false;
            AzertyToolStripMenuItem.Checked = false;

            // Uncheck All Inputs
            MouseClickLeftCheckBox.Checked = false;
            MouseClickRightCheckBox.Checked = false;
            WKeyCheckBox.Checked = false;
            AKeyCheckBox.Checked = false;
            SKeyCheckBox.Checked = false;
            DKeyCheckBox.Checked = false;

            // Reset TrackBars
            ResetTrackBars();
        }

        private void TutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "1. Toggle the Alt + Tab feature on or off, depending on whether or not you want the program to switch to the game automatically\r\n\r\n"
                    + "2. Select \"Randomize simulation\" in the \"Extra\" tab if you want the application to randomize key presses\r\n\r\n"
                    + "3. Select your preferred simulation options in the Mouse and Keyboard sections. Choose at least one option from either group for the program to run\r\n\r\n"
                    + "4. Choose the amount of simulations you want to perform per minute, ranging from 1 per minute to 10 per minute\r\n\r\n"
                    + "5. Select the total duration for the simulation, between 1 minute and 6 hours\r\n\r\n"
                    + "6. Press \"Start\" to begin the simulation. You can also pause the simulation at any time by pressing \"Pause\", or stop it completely with \"Stop\"\r\n\r\n"
                    + "7. A log will be available in real-time, allowing you to monitor the progress of the simulation",
                "How To Use"
            );
        }

        private void GTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Configure For GTA
            AltTabToolStripMenuItem.Checked = false;

            // Mouse Right Click Only
            MouseClickLeftCheckBox.Checked = false;
            MouseClickRightCheckBox.Checked = true;

            // No Keyboard Keys
            WKeyCheckBox.Checked = false;
            AKeyCheckBox.Checked = false;
            SKeyCheckBox.Checked = false;
            DKeyCheckBox.Checked = false;

            // Reset TrackBars
            ResetTrackBars();
        }

        private void RocketLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Configure For Rocket League
            AltTabToolStripMenuItem.Checked = false;

            // All Mouse Buttons
            MouseClickLeftCheckBox.Checked = true;
            MouseClickRightCheckBox.Checked = true;

            // All Keyboard Keys
            WKeyCheckBox.Checked = true;
            AKeyCheckBox.Checked = true;
            SKeyCheckBox.Checked = true;
            DKeyCheckBox.Checked = true;

            // Reset TrackBars
            ResetTrackBars();
        }

        private void AzertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Update Key Labels For Azerty
            if (AzertyToolStripMenuItem.Checked)
            {
                WKeyCheckBox.Text = "Z Key";
                AKeyCheckBox.Text = "Q Key";
            }
            else
            {
                WKeyCheckBox.Text = "W Key";
                AKeyCheckBox.Text = "A Key";
            }
        }

        private void ResetTrackBars()
        {
            // Reset Speed
            TrackBarSpeed.Value = 1;
            LabelSpeed.Text = "1 Simulation / Minute";

            // Reset Length
            TrackBarLength.Value = 1;
            LabelLength.Text = "1 Minute";
        }
        #endregion

        #region TrackBar
        private void TrackBarLength_Scroll(object sender, EventArgs e)
        {
            int value = TrackBarLength.Value;

            if (value < 60)
            {
                // Display Minutes
                LabelLength.Text = value == 1 ? "1 Minute" : $"{value} Minutes";
            }
            else
            {
                // Calculate Hours And Minutes
                int hours = value / 60;
                int minutes = value % 60;

                // Display Hours
                if (minutes == 0)
                    LabelLength.Text = hours == 1 ? "1 Hour" : $"{hours} Hours";
                else
                    LabelLength.Text = $"{hours}h {minutes}m";
            }
        }

        private void TrackBarSpeed_Scroll(object sender, EventArgs e)
        {
            int value = TrackBarSpeed.Value;

            // Display Speed
            LabelSpeed.Text =
                value == 1 ? "1 Simulation / Minute" : $"{value} Simulations / Minute";
        }
        #endregion
    }
}
