using System;
using System.Windows.Forms;

namespace AFK_Assist;

public partial class Form
{
    // Enable Controls
    private void EnableConfigurations()
    {
        SwitchToGameToolStripMenuItem.Enabled = true;

        MouseGroupBox.Enabled = true;
        KeyboardGroupBox.Enabled = true;

        TrackBarLength.Enabled = true;
        TrackBarSpeed.Enabled = true;

        ButtonStart.Enabled = true;
        ButtonStop.Enabled = false;
    }

    // Disable Controls
    private void DisableConfigurations()
    {
        SwitchToGameToolStripMenuItem.Enabled = false;

        MouseGroupBox.Enabled = false;
        KeyboardGroupBox.Enabled = false;

        TrackBarLength.Enabled = false;
        TrackBarSpeed.Enabled = false;

        ButtonStart.Enabled = true;
        ButtonStop.Enabled = true;

        _logHasEntry = false;
        TextBoxLog.Text = "";
    }

    // Log Write
    private void UpdateLog(string message)
    {
        if (TextBoxLog.InvokeRequired)
        {
            TextBoxLog.Invoke(new Action(() => WriteLog(message)));
        }
        else
        {
            WriteLog(message);
        }
    }

    // Log Core
    private void WriteLog(string message)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        var logEntry = $"[{timestamp}] {message}";

        if (!_logHasEntry)
        {
            TextBoxLog.Text += logEntry;
            _logHasEntry = true;
        }
        else
        {
            TextBoxLog.Text += $"\n\r\n\r{logEntry}";
        }

        TextBoxLog.SelectionStart = TextBoxLog.TextLength;
        TextBoxLog.ScrollToCaret();
    }

    // Tutorial Click
    private void TutorialToolStripMenuItem_Click(object sender, EventArgs e)
    {
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
        MessageBox.Show(this, text, "Tutorial");
    }

    // AZERTY Toggle
    private void AzertyToolStripMenuItem_Click(object sender, EventArgs e)
    {
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

    // Length Scroll
    private void TrackBarLength_Scroll(object sender, EventArgs e)
    {
        var value = TrackBarLength.Value;
        if (value < 60)
        {
            LabelLength.Text = value == 1 ? "1 Minute" : $"{value} Minutes";
        }
        else
        {
            var hours = value / 60;
            var minutes = value % 60;
            LabelLength.Text =
                minutes == 0 ? (hours == 1 ? "1 Hour" : $"{hours} Hours") : $"{hours}h {minutes}m";
        }
    }

    // Speed Scroll
    private void TrackBarSpeed_Scroll(object sender, EventArgs e)
    {
        var value = TrackBarSpeed.Value;
        LabelSpeed.Text = value == 1 ? "1 Simulation / Minute" : $"{value} Simulations / Minute";
    }

    // Manual Update
    private async void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        await CheckForUpdatesAsync(showNoUpdateMessageBox: true);
    }

    // Randomize Toggle
    private void RandomizeToolStripMenuItem_Click(object sender, EventArgs e)
    {
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
            UpdateLog("Randomize Simulation Enabled");
        }
    }

    // Random Intervals Toggle
    private void RandomizeIntervalsToolStripMenuItem_Click(object sender, EventArgs e)
    {
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
            UpdateLog("Randomize Intervals Enabled");
        }
    }

    // Switch To Game Toggle
    private void SwitchToGameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (SwitchToGameToolStripMenuItem.Checked)
        {
            UpdateLog("Switch to Game Automatically Enabled");
        }
        else
        {
            UpdateLog("Switch to Game Automatically Disabled");
        }
    }

    // Disable Confirmation
    private bool ConfirmDisableRandomFeature(string featureName)
    {
        var title = "Disable Confirmation";
        var message =
            $"Disabling \"{featureName}\" may increase AFK Assist's detection risk\n\n"
            + "Press OK to disable or Cancel to keep enabled";
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
