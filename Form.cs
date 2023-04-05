using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFK_Assist
{
    public partial class Form : System.Windows.Forms.Form
    {
        #region Variables / Classes
        readonly Stopwatch Stopwatch = new Stopwatch();
        readonly Random Random = new Random();
        bool LoopRanOnce = false;
        bool AltTabbed = false;
        int LoopNumber = 0;
        #endregion

        #region Main
        public Form()
        {
            InitializeComponent();
        }
        #endregion

        #region Import and use DLL
        [DllImport("user32.dll")] // Mouse
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        const uint MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")] // Keyboard
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x0001; // Key Down
        const int KEYEVENTF_KEYUP = 0x0002; // Key Up
        #endregion

        #region Buttons
        private async void ButtonStart_ClickAsync(object sender, EventArgs e)
        {
            // Check if Mouse and/or Keyboard CheckBoxes are checked
            if (MouseCheckBox.Checked == false && KeyboardCheckBox.Checked == false)
            {
                MouseCheckBox.BackColor = Color.Red;
                KeyboardCheckBox.BackColor = Color.Red;

                DialogResult result = MessageBox.Show("Please select an input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    MouseCheckBox.BackColor = Color.Transparent;
                    KeyboardCheckBox.BackColor = Color.Transparent;
                }
            }
            else
            {
                Stopwatch.Reset();
                Stopwatch.Start();
                MainTimer.Start();
                DisableConfigurations();

                // Set length of AFK Assist, determined by TrackBarLength value
                await Task.Delay(TrackBarLength.Value * 60000);

                ButtonStop.PerformClick();
            }
        }
        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Stopwatch.Stop();
            MainTimer.Stop();
            EnableConfigurations();
            SetTimerInterval(1);

            int minutes = (int)Stopwatch.Elapsed.TotalMinutes;
            int seconds = (int)(Stopwatch.Elapsed.TotalSeconds - (minutes * 60));
            MessageBox.Show("Elapsed Time " + minutes.ToString("00") + ":" + seconds.ToString("00"), "Stopped");
        }
        #endregion

        #region Timer
        private void Timer_TickAsync(object sender, EventArgs e)
        {
            // Alt + Tab
            if (AltTabToolStripMenuItem.Checked && AltTabbed == false)
            {
                SendKeys.Send("%{TAB}");

                // Update Log
                UpdateLog("* Alt + Tab");

                AltTabbed = true; // Variable to prevent constant AltTabbing every TimerTick
            }

            // Randomize Simulation
            if (RandomizeToolStripMenuItem.Checked)
            {
                // Variables
                int loopRandInt = 0;
                bool WKeyPressed = false;
                bool AKeyPressed = false;
                bool SKeyPressed = false;
                bool DKeyPressed = false;

                while (loopRandInt != 4)
                {
                    // Randomizes Key Presses
                    int randInt = Random.Next(4);
                    if (randInt == 0 && WKeyPressed == false)
                    {
                        if (AzertyToolStripMenuItem.Checked)
                        {
                            ZKey();
                        }
                        else
                        {
                            WKey();
                        }
                        WKeyPressed = true;
                    }
                    else if (randInt == 1 && AKeyPressed == false)
                    {
                        if (AzertyToolStripMenuItem.Checked)
                        {
                            ZKey();
                        }
                        else
                        {
                            AKey();
                        }
                        AKeyPressed = true;
                    }
                    else if (randInt == 2 && SKeyPressed == false)
                    {
                        SKey();
                        SKeyPressed = true;
                    }
                    else if (randInt == 3 && DKeyPressed == false)
                    {
                        DKey();
                        DKeyPressed = true;
                    }
                    else
                    {
                        // If the Randomizer chooses a Key that was already pressed, it loops again to choose another key
                        loopRandInt--;
                    }

                    loopRandInt++;
                }
            }
            else
            {
                if (AzertyToolStripMenuItem.Checked)
                {
                    ZKey();
                    QKey();
                }
                else
                {
                    WKey();
                    AKey();
                }
                SKey();
                DKey();
            }

            // Keyboard Presses
            void ZKey()
            {
                // Keyboard Key Z
                if (WKeyCheckBox.Checked)
                {
                    keybd_event((byte)Keys.Z, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press Z key
                    Thread.Sleep(800);
                    keybd_event((byte)Keys.Z, 0x45, KEYEVENTF_KEYUP, 0); // Release Z key

                    // Update Log
                    UpdateLog("* Z Key");
                }
            }
            void QKey()
            {
                // Keyboard Key A
                if (AKeyCheckBox.Checked)
                {
                    keybd_event((byte)Keys.Q, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press Q key
                    Thread.Sleep(800);
                    keybd_event((byte)Keys.Q, 0x45, KEYEVENTF_KEYUP, 0); // Release Q key

                    // Update Log
                    UpdateLog("* Q Key");
                }
            }
            void WKey()
            {
                // Keyboard Key W
                if (WKeyCheckBox.Checked)
                {
                    keybd_event((byte)Keys.W, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press W key
                    Thread.Sleep(800);
                    keybd_event((byte)Keys.W, 0x45, KEYEVENTF_KEYUP, 0); // Release W key

                    // Update Log
                    UpdateLog("* W Key");
                }
            }
            void AKey()
            {
                // Keyboard Key A
                if (AKeyCheckBox.Checked)
                {
                    keybd_event((byte)Keys.A, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press A key
                    Thread.Sleep(800);
                    keybd_event((byte)Keys.A, 0x45, KEYEVENTF_KEYUP, 0); // Release A key

                    // Update Log
                    UpdateLog("* A Key");
                }
            }
            void SKey()
            {
                // Keyboard Key S
                if (SKeyCheckBox.Checked)
                {
                    keybd_event((byte)Keys.S, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press S key
                    Thread.Sleep(800);
                    keybd_event((byte)Keys.S, 0x45, KEYEVENTF_KEYUP, 0); // Release S key

                    // Update Log
                    UpdateLog("* S key");
                }
            }
            void DKey()
            {
                // Keyboard Key D
                if (DKeyCheckBox.Checked)
                {
                    keybd_event((byte)Keys.D, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press D key
                    Thread.Sleep(800);
                    keybd_event((byte)Keys.D, 0x45, KEYEVENTF_KEYUP, 0); // Release D key

                    // Update Log
                    UpdateLog("* D key");
                }
            }

            // Mouse Buttons
            if (MouseClickLeftCheckBox.Checked)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0); // Press left mouse button
                Thread.Sleep(800);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0); // Release left mouse button

                // Update Log
                UpdateLog("* Left mouse");
            }
            if (MouseClickRightCheckBox.Checked)
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0); // Press right mouse button
                Thread.Sleep(800);
                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0); // Release right mouse button

                // Update Log
                UpdateLog("* Right mouse");
            }

            LoopNumber++;

            // Update Log
            UpdateLog($"Finished Loop {LoopNumber}\n\r");

            // Set Timer Interval to users preffered Value
            SetTimerInterval(60 / TrackBarSpeed.Value);
        }
        public void SetTimerInterval(int seconds) // Sets Timer Interval to X amount of seconds
        {
            MainTimer.Interval = seconds * 1000;
        }
        #endregion

        #region Enable/Disable Configuration Methods
        private void EnableConfigurations()
        {
            // Enable all Checkboxes
            AltTabToolStripMenuItem.Enabled = true;
            MouseCheckBox.Enabled = true;
            KeyboardCheckBox.Enabled = true;

            // Enable Trackbars
            TrackBarLength.Enabled = true;
            TrackBarSpeed.Enabled = true;

            // Enable MenuStripItems
            HelpToolStripMenuItem.Enabled = true;
            ExtraOptionsToolStripMenuItem.Enabled = true;
            PresetsToolStripMenuItem.Enabled = true;

            // Enable/Disable Buttons
            ButtonStart.Enabled = true;
            ButtonStop.Enabled = false;
        }
        private void DisableConfigurations()
        {
            // Disable all Checkboxes
            AltTabToolStripMenuItem.Enabled = false;
            MouseCheckBox.Enabled = false;
            KeyboardCheckBox.Enabled = false;

            // Disable Trackbars
            TrackBarLength.Enabled = false;
            TrackBarSpeed.Enabled = false;

            // Disable MenuStripItems
            HelpToolStripMenuItem.Enabled = false;
            ExtraOptionsToolStripMenuItem.Enabled = false;
            PresetsToolStripMenuItem.Enabled = false;

            // Disable/Enable Buttons
            ButtonStart.Enabled = false;
            ButtonStop.Enabled = true;

            // Hide All Panels
            MousePanel.Visible = false;
            KeyboardPanel.Visible = false;

            // Extra Configurations
            LoopRanOnce = false;
            AltTabbed = false;
            LoopNumber = 0;
            TextBoxLog.Text = "";
        }
        #endregion

        #region Visual Methods for Mouse Click Checkbox
        private void MouseCheckBox_Click(object sender, EventArgs e)
        {
            if (MouseCheckBox.Checked)
            {
                KeyboardPanel.Visible = false;
                MousePanel.Visible = true;
                MouseClickLeftCheckBox.Checked = true;
                MouseClickRightCheckBox.Checked = true;
            }
            else
            {
                MousePanel.Visible = false;
                MouseClickLeftCheckBox.Checked = false;
                MouseClickRightCheckBox.Checked = false;
            }
        }
        private void MouseClickCheckBox_Click(object sender, EventArgs e)
        {
            if (MouseClickLeftCheckBox.Checked && MouseClickRightCheckBox.Checked)
            {
                MouseCheckBox.CheckState = CheckState.Checked;
            }
            else if (!MouseClickLeftCheckBox.Checked && !MouseClickRightCheckBox.Checked)
            {
                MouseCheckBox.Checked = false;
            }
            else
            {
                MouseCheckBox.CheckState = CheckState.Indeterminate;
            }
        }
        #endregion

        #region  Visual Methods for Keyboard Checkbox
        private void KeyboardCheckBox_Click(object sender, EventArgs e)
        {
            if (KeyboardCheckBox.Checked)
            {
                MousePanel.Visible = false;
                KeyboardPanel.Visible = true;
                WKeyCheckBox.Checked = true;
                AKeyCheckBox.Checked = true;
                SKeyCheckBox.Checked = true;
                DKeyCheckBox.Checked = true;
            }
            else
            {
                KeyboardPanel.Visible = false;
                WKeyCheckBox.Checked = false;
                AKeyCheckBox.Checked = false;
                SKeyCheckBox.Checked = false;
                DKeyCheckBox.Checked = false;
            }
        }
        private void WASDKeyCheckBox_Click(object sender, EventArgs e)
        {
            if (WKeyCheckBox.Checked && AKeyCheckBox.Checked && SKeyCheckBox.Checked && DKeyCheckBox.Checked)
            {
                KeyboardCheckBox.CheckState = CheckState.Checked;
            }
            else if (!WKeyCheckBox.Checked && !AKeyCheckBox.Checked && !SKeyCheckBox.Checked && !DKeyCheckBox.Checked)
            {
                KeyboardCheckBox.Checked = false;
            }
            else
            {
                KeyboardCheckBox.CheckState = CheckState.Indeterminate;
            }
        }
        #endregion

        #region Method to Update Log
        public void UpdateLog(string text)
        {
            if (LoopRanOnce == false)
            {
                TextBoxLog.Text += $"{text}";
                LoopRanOnce = true;
            }
            else
            {
                TextBoxLog.Text += $"\n\r\n\r{text}";
            }
            TextBoxLog.SelectionStart = TextBoxLog.TextLength;
            TextBoxLog.ScrollToCaret();
        }
        #endregion

        #region MenuStrip
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Disable Checkboxes
            AltTabToolStripMenuItem.Checked = false;
            RandomizeToolStripMenuItem.Checked = false;
            AzertyToolStripMenuItem.Checked = false;

            MouseCheckBox.Checked = false;
            MouseClickLeftCheckBox.Checked = false;
            MouseClickRightCheckBox.Checked = false;
            KeyboardCheckBox.Checked = false;

            WKeyCheckBox.Checked = false;
            AKeyCheckBox.Checked = false;
            SKeyCheckBox.Checked = false;
            DKeyCheckBox.Checked = false;

            // Hide Panels
            MousePanel.Visible = false;
            KeyboardPanel.Visible = false;

            // Reset TrackBars
            TrackBarSpeed.Value = 1;
            LabelSpeed.Text = "1 simulation / minute";
            TrackBarLength.Value = 1;
            LabelLength.Text = "1 minute";
        }
        private void TutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Toggle the Alt + Tab feature on or off, depending on whether or not you want the program to switch to the game automatically\r\n\r\n" +
                "2. Select \"Randomize simulation\" in the \"Extra\" tab if you want the application to randomize key presses\r\n\r\n" +
                "3. Select your preferred simulation option, mouse and/or keyboard. Choose at least one option from keyboard or mouse for the program to run. You can choose the specific keys you want to simulate (WASD keys), and also the mouse buttons you want to simulate (left and/or right click)\r\n\r\n" +
                "4. Choose the amount of simulations you want to perform per minute, ranging from 1 per minute to 10 per minute\r\n\r\n" +
                "5. Select the total duration for the simulation, between 1 minute and 120\r\n\r\n" +
                "6. Press \"Start\" to begin the simulation. You can also stop the simulation at any time by pressing \"Stop\"\r\n\r\n" +
                "7. A log will be available in real-time, allowing you to monitor the progress of the simulation", "");
        }
        private void GTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltTabToolStripMenuItem.CheckState = CheckState.Unchecked;

            MouseCheckBox.CheckState = CheckState.Indeterminate;
            MouseClickLeftCheckBox.CheckState = CheckState.Unchecked;
            MouseClickRightCheckBox.CheckState = CheckState.Checked;
            KeyboardCheckBox.CheckState = CheckState.Unchecked;
            WKeyCheckBox.CheckState = CheckState.Unchecked;
            AKeyCheckBox.CheckState = CheckState.Unchecked;
            SKeyCheckBox.CheckState = CheckState.Unchecked;
            DKeyCheckBox.CheckState = CheckState.Unchecked;

            MousePanel.Visible = true;
            KeyboardPanel.Visible = false;
        }
        private void RocketLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltTabToolStripMenuItem.CheckState = CheckState.Unchecked;

            MouseCheckBox.CheckState = CheckState.Checked;
            MouseClickLeftCheckBox.CheckState = CheckState.Checked;
            MouseClickRightCheckBox.CheckState = CheckState.Checked;
            KeyboardCheckBox.CheckState = CheckState.Checked;
            WKeyCheckBox.CheckState = CheckState.Checked;
            AKeyCheckBox.CheckState = CheckState.Checked;
            SKeyCheckBox.CheckState = CheckState.Checked;
            DKeyCheckBox.CheckState = CheckState.Checked;

            MousePanel.Visible = false;
            KeyboardPanel.Visible = false;
        }
        private void AzertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        #endregion

        #region TrackBar
        private void TrackBarLength_Scroll(object sender, EventArgs e)
        {
            string text;
            if (TrackBarLength.Value == 1)
            {
                text = "1 minute";
            }
            else
            {
                text = $"{TrackBarLength.Value} minutes";
            }
            LabelLength.Text = text;
        }
        private void TrackBarSpeed_Scroll(object sender, EventArgs e)
        {
            string text;
            if (TrackBarSpeed.Value == 1)
            {
                text = "1 simulation / minute";
            }
            else
            {
                text = $"{TrackBarSpeed.Value} simulations / minute";
            }
            LabelSpeed.Text = text;
        }
        #endregion
    }
}
