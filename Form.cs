using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AFK_Assist
{
    public partial class Form : System.Windows.Forms.Form
    {
        #region Main
        public Form()
        {
            InitializeComponent();
        }
        #endregion

        #region Variables
        Stopwatch Stopwatch = new Stopwatch();
        bool AltTabbed = false;
        int LoopNumber = 0;
        bool LoopRanOnce = false;
        #endregion

        #region Import and use DLL
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        const uint MOUSEEVENTF_LEFTUP = 0x04;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        const uint MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll")]
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
            // Check if Timer is already running
            if (MainTimer.Enabled == false)
            {
                MessageBox.Show("The timer is not running", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Stopwatch.Stop();
                MainTimer.Stop();
                EnableConfigurations();
                SetTimerInterval(1);

                if (Math.Round(Stopwatch.Elapsed.TotalSeconds, 0) >= 60)
                {
                    if (Stopwatch.Elapsed.TotalMinutes <= 1)
                    {
                        int minutes = (int)Stopwatch.Elapsed.TotalMinutes;
                        int seconds = (int)(Stopwatch.Elapsed.TotalSeconds - (minutes * 60));
                        MessageBox.Show("Elapsed time " + minutes.ToString("00") + "min " + seconds.ToString("00") + "sec");
                    }
                    else
                    {
                        int minutes = (int)Stopwatch.Elapsed.TotalMinutes;
                        int seconds = (int)(Stopwatch.Elapsed.TotalSeconds - (minutes * 60));
                        MessageBox.Show("Elapsed time " + minutes.ToString("0") + "min " + seconds.ToString("00") + "sec");
                    }
                }
                else
                {
                    if (Stopwatch.Elapsed.TotalSeconds <= 10)
                    {
                        MessageBox.Show("Elapsed time " + Stopwatch.Elapsed.TotalSeconds.ToString("0") + "s");
                    }
                    else
                    {
                        MessageBox.Show("Elapsed time " + Stopwatch.Elapsed.TotalSeconds.ToString("00") + "s");
                    }
                }
            }
        }
        #endregion

        #region Timer
        private void Timer_TickAsync(object sender, EventArgs e)
        {
            // Alt + Tab
            if (AltTabCheckBox.Checked == true && AltTabbed == false)
            {
                SendKeys.Send("%{TAB}");

                // Update Log
                UpdateLog("* Alt + Tab");

                AltTabbed = true; // Variable to prevent constant AltTabbing every TimerTick
            }

            // Keyboard Keys
            if (WKeyCheckBox.Checked)
            {
                keybd_event((byte)Keys.W, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press W key
                Thread.Sleep(800);
                keybd_event((byte)Keys.W, 0x45, KEYEVENTF_KEYUP, 0); // Release W key

                // Update Log
                UpdateLog("* W Key");
            }
            if (AKeyCheckBox.Checked)
            {
                keybd_event((byte)Keys.A, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press A key
                Thread.Sleep(800);
                keybd_event((byte)Keys.A, 0x45, KEYEVENTF_KEYUP, 0); // Release A key

                // Update Log
                UpdateLog("* A Key");
            }
            if (SKeyCheckBox.Checked)
            {
                keybd_event((byte)Keys.S, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press S key
                Thread.Sleep(800);
                keybd_event((byte)Keys.S, 0x45, KEYEVENTF_KEYUP, 0); // Release S key

                // Update Log
                UpdateLog("* S key");
            }
            if (DKeyCheckBox.Checked)
            {
                keybd_event((byte)Keys.D, 0x45, KEYEVENTF_EXTENDEDKEY, 0); // Press D key
                Thread.Sleep(800);
                keybd_event((byte)Keys.D, 0x45, KEYEVENTF_KEYUP, 0); // Release D key

                // Update Log
                UpdateLog("* D key");
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

            // Update Log
            LoopNumber ++;
            UpdateLog($"Finished Loop {LoopNumber}\n\r");

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
            AltTabCheckBox.Enabled = true;
            MouseCheckBox.Enabled = true;
            KeyboardCheckBox.Enabled = true;

            // Enable Trackbars
            TrackBarLength.Enabled = true;
            TrackBarSpeed.Enabled = true;

            // Enable MenuStripItems
            ExtraToolStripMenuItem.Enabled = true;
            PresetsToolStripMenuItem.Enabled = true;

            // Enable/Disable Buttons
            ButtonStart.Enabled = true;
            ButtonStop.Enabled = false;
        }
        private void DisableConfigurations()
        {
            // Disable all Checkboxes
            AltTabCheckBox.Enabled = false;
            MouseCheckBox.Enabled = false;
            KeyboardCheckBox.Enabled = false;

            // Disable Trackbars
            TrackBarLength.Enabled = false;
            TrackBarSpeed.Enabled = false;

            // Disable MenuStripItems
            ExtraToolStripMenuItem.Enabled = false;
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
            AltTabCheckBox.Checked = false;
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
            LabelSpeed.Text = "1 minute";
        }
        private void TutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. Toggle the Alt + Tab feature on or off, depending on whether or not you want the program to switch to the game automatically\r\n\r\n2. Select your preferred simulation option, mouse and/or keyboard. Choose at least one option from keyboard or mouse for the program to run. You can choose the specific keys you want to simulate (WASD keys), and also the mouse buttons you want to simulate (left and/or right click)\r\n\r\n3. Choose the amount of simulations you want to perform per minute, ranging from 1 per minute to 10 per minute\r\n\r\n4. Select the total duration for the simulation, between 1 minute and 120\r\n\r\n5. Press \"Start\" to begin the simulation. You can also stop the simulation at any time by pressing \"Stop\"\r\n\r\n6. A log will be available in real-time, allowing you to monitor the progress of the simulation", "");
        }
        private void GTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MouseCheckBox.CheckState = CheckState.Indeterminate;
            MouseClickLeftCheckBox.CheckState = CheckState.Checked;
            MouseClickRightCheckBox.CheckState = CheckState.Unchecked;
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
