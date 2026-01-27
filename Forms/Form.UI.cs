using System;
using System.Windows.Forms;

namespace AFK_Assist;

public partial class Form
{
    private void EnableConfigurations()
    {
        // Enable Main Options
        SwitchToGameToolStripMenuItem.Enabled = true;

        // Enable Input Groups
        MouseGroupBox.Enabled = true;
        KeyboardGroupBox.Enabled = true;

        // Enable Sliders
        TrackBarLength.Enabled = true;
        TrackBarSpeed.Enabled = true;

        // Enable Buttons
        ButtonStart.Enabled = true;
        ButtonStop.Enabled = false;
    }

    private void DisableConfigurations()
    {
        // Disable Main Options
        SwitchToGameToolStripMenuItem.Enabled = false;

        // Disable Input Groups
        MouseGroupBox.Enabled = false;
        KeyboardGroupBox.Enabled = false;

        // Disable Sliders
        TrackBarLength.Enabled = false;
        TrackBarSpeed.Enabled = false;

        // Enable Stop Button
        ButtonStart.Enabled = true;
        ButtonStop.Enabled = true;

        // Reset Log Window
        _logHasEntry = false;
        TextBoxLog.Text = "";
    }

    private void UpdateLog(string message)
    {
        // Marshal To UI Thread
        if (TextBoxLog.InvokeRequired)
        {
            TextBoxLog.Invoke(new Action(() => WriteLog(message)));
        }
        else
        {
            WriteLog(message);
        }
    }

    private void WriteLog(string message)
    {
        // Build Timestamp Entry
        var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        var logEntry = $"[{timestamp}] {message}";

        // Append With Formatting
        if (!_logHasEntry)
        {
            TextBoxLog.Text += logEntry;
            _logHasEntry = true;
        }
        else
        {
            TextBoxLog.Text += $"\n\r\n\r{logEntry}";
        }

        // Scroll To Bottom
        TextBoxLog.SelectionStart = TextBoxLog.TextLength;
        TextBoxLog.ScrollToCaret();
    }

    private void TutorialToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Build Tutorial Text
        var text =
            "Tutorial\n\n"
            + "1. Start the game and bring it to foreground\n"
            + "2. Select inputs in Mouse and Keyboard\n"
            + "3. Keep Randomize Simulation enabled by default\n"
            + "4. Keep Randomize Intervals enabled by default\n"
            + "5. Choose simulations per minute and total duration\n"
            + "6. Press Start and do not touch the PC while running\n"
            + "7. Use Pause to pause and Resume to continue\n"
            + "8. Press Stop to end and reset";

        // Show Tutorial Dialog
        MessageBox.Show(this, text, "Tutorial");
    }

    private void AzertyToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Update Checkbox Text
        if (AzertyToolStripMenuItem.Checked)
        {
            WKeyCheckBox.Text = "Z Key";
            AKeyCheckBox.Text = "Q Key";
            UpdateLog("AZERTY Layout Applied");
        }
        else
        {
            WKeyCheckBox.Text = "W Key";
            AKeyCheckBox.Text = "A Key";
            UpdateLog("QWERTY Layout Applied");
        }
    }

    private void TrackBarLength_Scroll(object sender, EventArgs e)
    {
        // Read Current Value
        var value = TrackBarLength.Value;

        // Render Minutes Text
        if (value < 60)
        {
            LabelLength.Text = value == 1 ? "1 Minute" : $"{value} Minutes";
        }
        else
        {
            // Render Hours Text
            var hours = value / 60;
            var minutes = value % 60;

            LabelLength.Text =
                minutes == 0 ? (hours == 1 ? "1 Hour" : $"{hours} Hours") : $"{hours}h {minutes}m";
        }
    }

    private void TrackBarSpeed_Scroll(object sender, EventArgs e)
    {
        // Read Current Value
        var value = TrackBarSpeed.Value;

        // Render Speed Text
        LabelSpeed.Text = value == 1 ? "1 Simulation / Minute" : $"{value} Simulations / Minute";
    }

    private async void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        await CheckForUpdatesAsync(showNoUpdateMessageBox: true);
    }

    private void RandomizeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Confirm Disabling Risk
        if (!RandomizeToolStripMenuItem.Checked)
        {
            var confirmed = ConfirmDisableRandomFeature("Randomize Simulation");
            if (!confirmed)
            {
                RandomizeToolStripMenuItem.Checked = true;
                return;
            }

            UpdateLog("Randomize Simulation Disabled");
        }
        else
        {
            // Write Enabled Log
            UpdateLog("Randomize Simulation Enabled");
        }
    }

    private void RandomizeIntervalsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Confirm Disabling Risk
        if (!RandomizeIntervalsToolStripMenuItem.Checked)
        {
            var confirmed = ConfirmDisableRandomFeature("Randomize Intervals");
            if (!confirmed)
            {
                RandomizeIntervalsToolStripMenuItem.Checked = true;
                return;
            }

            UpdateLog("Randomize Intervals Disabled");
        }
        else
        {
            // Write Enabled Log
            UpdateLog("Randomize Intervals Enabled");
        }
    }

    private void SwitchToGameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Log Current State
        if (SwitchToGameToolStripMenuItem.Checked)
        {
            UpdateLog("Switch to Game Automatically Enabled");
        }
        else
        {
            UpdateLog("Switch to Game Automatically Disabled");
        }
    }

    private bool ConfirmDisableRandomFeature(string featureName)
    {
        // Build Confirmation Text
        var title = "Disable Confirmation";
        var message =
            $"Disabling \"{featureName}\" may increase AFK Assist's detection risk\n\n"
            + "Press OK to disable or Cancel to keep enabled";

        // Show Confirmation Dialog
        var result = MessageBox.Show(
            this,
            message,
            title,
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2
        );

        return result == DialogResult.OK;
    }
}
