using System;

namespace AFK_Assist
{
    partial class Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Menu Strip
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HowToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtraOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SwitchToGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomizeIntervalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AzertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Timer
            this.MainTimer = new System.Windows.Forms.Timer(this.components);

            // Mouse Controls
            this.MouseGroupBox = new System.Windows.Forms.GroupBox();
            this.MouseClickLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.MouseClickRightCheckBox = new System.Windows.Forms.CheckBox();

            // Keyboard Controls
            this.KeyboardGroupBox = new System.Windows.Forms.GroupBox();
            this.WKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.AKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.SKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.DKeyCheckBox = new System.Windows.Forms.CheckBox();

            // Speed Controls
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.LabelSpeed = new System.Windows.Forms.Label();
            this.TrackBarSpeed = new System.Windows.Forms.TrackBar();

            // Length Controls
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.LabelLength = new System.Windows.Forms.Label();
            this.TrackBarLength = new System.Windows.Forms.TrackBar();

            // Logs
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.TextBoxLog = new System.Windows.Forms.TextBox();

            // Time Display
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.LabelElapsedTime = new System.Windows.Forms.Label();

            // Buttons
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();

            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSpeed)).BeginInit();
            this.MouseGroupBox.SuspendLayout();
            this.KeyboardGroupBox.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.SuspendLayout();

            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem,
            this.ExtraOptionsToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(560, 28);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HowToUseToolStripMenuItem,
            this.CheckForUpdatesToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.HelpToolStripMenuItem.Text = "File";
            // 
            // HowToUseToolStripMenuItem
            // 
            this.HowToUseToolStripMenuItem.Name = "HowToUseToolStripMenuItem";
            this.HowToUseToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.HowToUseToolStripMenuItem.Text = "How To Use";
            this.HowToUseToolStripMenuItem.Click += new System.EventHandler(this.TutorialToolStripMenuItem_Click);
            // 
            // CheckForUpdatesToolStripMenuItem
            // 
            this.CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem";
            this.CheckForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.CheckForUpdatesToolStripMenuItem.Text = "Check For Updates";
            this.CheckForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdatesToolStripMenuItem_Click);
            // 
            // ExtraOptionsToolStripMenuItem
            // 
            this.ExtraOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SwitchToGameToolStripMenuItem,
            this.RandomizeToolStripMenuItem,
            this.RandomizeIntervalsToolStripMenuItem,
            this.AzertyToolStripMenuItem});
            this.ExtraOptionsToolStripMenuItem.Name = "ExtraOptionsToolStripMenuItem";
            this.ExtraOptionsToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.ExtraOptionsToolStripMenuItem.Text = "Extra Options";
            // 
            // SwitchToGameToolStripMenuItem
            // 
            this.SwitchToGameToolStripMenuItem.CheckOnClick = true;
            this.SwitchToGameToolStripMenuItem.Name = "SwitchToGameToolStripMenuItem";
            this.SwitchToGameToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.SwitchToGameToolStripMenuItem.Text = "Switch To Game Automatically";
            // 
            // RandomizeToolStripMenuItem
            // 
            this.RandomizeToolStripMenuItem.Checked = true;
            this.RandomizeToolStripMenuItem.CheckOnClick = true;
            this.RandomizeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RandomizeToolStripMenuItem.Name = "RandomizeToolStripMenuItem";
            this.RandomizeToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.RandomizeToolStripMenuItem.Text = "Randomize Simulation";
            this.RandomizeToolStripMenuItem.Click += new System.EventHandler(this.RandomizeToolStripMenuItem_Click);
            // 
            // RandomizeIntervalsToolStripMenuItem
            // 
            this.RandomizeIntervalsToolStripMenuItem.Checked = true;
            this.RandomizeIntervalsToolStripMenuItem.CheckOnClick = true;
            this.RandomizeIntervalsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RandomizeIntervalsToolStripMenuItem.Name = "RandomizeIntervalsToolStripMenuItem";
            this.RandomizeIntervalsToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.RandomizeIntervalsToolStripMenuItem.Text = "Randomize Intervals";
            this.RandomizeIntervalsToolStripMenuItem.Click += new System.EventHandler(this.RandomizeIntervalsToolStripMenuItem_Click);
            // 
            // AzertyToolStripMenuItem
            // 
            this.AzertyToolStripMenuItem.CheckOnClick = true;
            this.AzertyToolStripMenuItem.Name = "AzertyToolStripMenuItem";
            this.AzertyToolStripMenuItem.Size = new System.Drawing.Size(242, 26);
            this.AzertyToolStripMenuItem.Text = "Azerty Layout";
            this.AzertyToolStripMenuItem.Click += new System.EventHandler(this.AzertyToolStripMenuItem_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 2000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_TickAsync);
            // 
            // MouseGroupBox
            // 
            this.MouseGroupBox.Controls.Add(this.MouseClickLeftCheckBox);
            this.MouseGroupBox.Controls.Add(this.MouseClickRightCheckBox);
            this.MouseGroupBox.Location = new System.Drawing.Point(10, 35);
            this.MouseGroupBox.Name = "MouseGroupBox";
            this.MouseGroupBox.Size = new System.Drawing.Size(200, 69);
            this.MouseGroupBox.TabIndex = 0;
            this.MouseGroupBox.TabStop = false;
            this.MouseGroupBox.Text = "Mouse";
            // 
            // MouseClickLeftCheckBox
            // 
            this.MouseClickLeftCheckBox.AutoSize = true;
            this.MouseClickLeftCheckBox.Location = new System.Drawing.Point(10, 22);
            this.MouseClickLeftCheckBox.Name = "MouseClickLeftCheckBox";
            this.MouseClickLeftCheckBox.Size = new System.Drawing.Size(93, 21);
            this.MouseClickLeftCheckBox.TabIndex = 0;
            this.MouseClickLeftCheckBox.Text = "Left Click";
            this.MouseClickLeftCheckBox.UseVisualStyleBackColor = true;
            // 
            // MouseClickRightCheckBox
            // 
            this.MouseClickRightCheckBox.AutoSize = true;
            this.MouseClickRightCheckBox.Location = new System.Drawing.Point(10, 45);
            this.MouseClickRightCheckBox.Name = "MouseClickRightCheckBox";
            this.MouseClickRightCheckBox.Size = new System.Drawing.Size(103, 21);
            this.MouseClickRightCheckBox.TabIndex = 1;
            this.MouseClickRightCheckBox.Text = "Right Click";
            this.MouseClickRightCheckBox.UseVisualStyleBackColor = true;
            // 
            // KeyboardGroupBox
            // 
            this.KeyboardGroupBox.Controls.Add(this.WKeyCheckBox);
            this.KeyboardGroupBox.Controls.Add(this.AKeyCheckBox);
            this.KeyboardGroupBox.Controls.Add(this.SKeyCheckBox);
            this.KeyboardGroupBox.Controls.Add(this.DKeyCheckBox);
            this.KeyboardGroupBox.Location = new System.Drawing.Point(10, 110);
            this.KeyboardGroupBox.Name = "KeyboardGroupBox";
            this.KeyboardGroupBox.Size = new System.Drawing.Size(200, 115);
            this.KeyboardGroupBox.TabIndex = 1;
            this.KeyboardGroupBox.TabStop = false;
            this.KeyboardGroupBox.Text = "Keyboard";
            // 
            // WKeyCheckBox
            // 
            this.WKeyCheckBox.AutoSize = true;
            this.WKeyCheckBox.Location = new System.Drawing.Point(10, 22);
            this.WKeyCheckBox.Name = "WKeyCheckBox";
            this.WKeyCheckBox.Size = new System.Drawing.Size(76, 21);
            this.WKeyCheckBox.TabIndex = 0;
            this.WKeyCheckBox.Text = "W Key";
            this.WKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // AKeyCheckBox
            // 
            this.AKeyCheckBox.AutoSize = true;
            this.AKeyCheckBox.Location = new System.Drawing.Point(10, 45);
            this.AKeyCheckBox.Name = "AKeyCheckBox";
            this.AKeyCheckBox.Size = new System.Drawing.Size(71, 21);
            this.AKeyCheckBox.TabIndex = 1;
            this.AKeyCheckBox.Text = "A Key";
            this.AKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // SKeyCheckBox
            // 
            this.SKeyCheckBox.AutoSize = true;
            this.SKeyCheckBox.Location = new System.Drawing.Point(10, 68);
            this.SKeyCheckBox.Name = "SKeyCheckBox";
            this.SKeyCheckBox.Size = new System.Drawing.Size(71, 21);
            this.SKeyCheckBox.TabIndex = 2;
            this.SKeyCheckBox.Text = "S Key";
            this.SKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // DKeyCheckBox
            // 
            this.DKeyCheckBox.AutoSize = true;
            this.DKeyCheckBox.Location = new System.Drawing.Point(10, 91);
            this.DKeyCheckBox.Name = "DKeyCheckBox";
            this.DKeyCheckBox.Size = new System.Drawing.Size(72, 21);
            this.DKeyCheckBox.TabIndex = 3;
            this.DKeyCheckBox.Text = "D Key";
            this.DKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.LabelSpeed);
            this.GroupBox2.Controls.Add(this.TrackBarSpeed);
            this.GroupBox2.Location = new System.Drawing.Point(10, 231);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(200, 98);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Speed";
            // 
            // LabelSpeed
            // 
            this.LabelSpeed.Location = new System.Drawing.Point(10, 20);
            this.LabelSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSpeed.Name = "LabelSpeed";
            this.LabelSpeed.Size = new System.Drawing.Size(180, 25);
            this.LabelSpeed.TabIndex = 6;
            this.LabelSpeed.Text = "1 Simulation / Minute";
            this.LabelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackBarSpeed
            // 
            this.TrackBarSpeed.LargeChange = 2;
            this.TrackBarSpeed.Location = new System.Drawing.Point(10, 50);
            this.TrackBarSpeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TrackBarSpeed.Minimum = 1;
            this.TrackBarSpeed.Name = "TrackBarSpeed";
            this.TrackBarSpeed.Size = new System.Drawing.Size(180, 56);
            this.TrackBarSpeed.TabIndex = 2;
            this.TrackBarSpeed.Value = 1;
            this.TrackBarSpeed.Scroll += new System.EventHandler(this.TrackBarSpeed_Scroll);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.LabelLength);
            this.GroupBox3.Controls.Add(this.TrackBarLength);
            this.GroupBox3.Location = new System.Drawing.Point(10, 335);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(200, 98);
            this.GroupBox3.TabIndex = 13;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Length";
            // 
            // LabelLength
            // 
            this.LabelLength.Location = new System.Drawing.Point(10, 20);
            this.LabelLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelLength.Name = "LabelLength";
            this.LabelLength.Size = new System.Drawing.Size(180, 25);
            this.LabelLength.TabIndex = 5;
            this.LabelLength.Text = "1 Minute";
            this.LabelLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackBarLength
            // 
            this.TrackBarLength.Location = new System.Drawing.Point(10, 50);
            this.TrackBarLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TrackBarLength.Maximum = 360;
            this.TrackBarLength.Minimum = 1;
            this.TrackBarLength.Name = "TrackBarLength";
            this.TrackBarLength.Size = new System.Drawing.Size(180, 56);
            this.TrackBarLength.TabIndex = 0;
            this.TrackBarLength.TickFrequency = 10;
            this.TrackBarLength.Value = 1;
            this.TrackBarLength.Scroll += new System.EventHandler(this.TrackBarLength_Scroll);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.TextBoxLog);
            this.GroupBox4.Location = new System.Drawing.Point(220, 35);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(330, 398);
            this.GroupBox4.TabIndex = 14;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Logs";
            // 
            // TextBoxLog
            // 
            this.TextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxLog.Location = new System.Drawing.Point(10, 22);
            this.TextBoxLog.Multiline = true;
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.ReadOnly = true;
            this.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxLog.Size = new System.Drawing.Size(310, 370);
            this.TextBoxLog.TabIndex = 0;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.LabelElapsedTime);
            this.GroupBox5.Location = new System.Drawing.Point(220, 439);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(330, 66);
            this.GroupBox5.TabIndex = 15;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Time";
            // 
            // LabelElapsedTime
            // 
            this.LabelElapsedTime.Location = new System.Drawing.Point(6, 20);
            this.LabelElapsedTime.Name = "LabelElapsedTime";
            this.LabelElapsedTime.Size = new System.Drawing.Size(318, 43);
            this.LabelElapsedTime.TabIndex = 1;
            this.LabelElapsedTime.Text = "Elapsed: 00:00\r\nRemaining: 00:00";
            this.LabelElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(10, 439);
            this.ButtonStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(200, 30);
            this.ButtonStart.TabIndex = 3;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_ClickAsync);
            // 
            // ButtonStop
            // 
            this.ButtonStop.Enabled = false;
            this.ButtonStop.Location = new System.Drawing.Point(10, 475);
            this.ButtonStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(200, 30);
            this.ButtonStop.TabIndex = 4;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(560, 515);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.KeyboardGroupBox);
            this.Controls.Add(this.MouseGroupBox);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "Form";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AFK Assist";
            this.TopMost = true;
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSpeed)).EndInit();
            this.MouseGroupBox.ResumeLayout(false);
            this.MouseGroupBox.PerformLayout();
            this.KeyboardGroupBox.ResumeLayout(false);
            this.KeyboardGroupBox.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        #region Controls - Menu
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HowToUseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CheckForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExtraOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SwitchToGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RandomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RandomizeIntervalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AzertyToolStripMenuItem;
        #endregion

        #region Controls - Mouse
        private System.Windows.Forms.GroupBox MouseGroupBox;
        private System.Windows.Forms.CheckBox MouseClickLeftCheckBox;
        private System.Windows.Forms.CheckBox MouseClickRightCheckBox;
        #endregion

        #region Controls - Keyboard
        private System.Windows.Forms.GroupBox KeyboardGroupBox;
        private System.Windows.Forms.CheckBox WKeyCheckBox;
        private System.Windows.Forms.CheckBox AKeyCheckBox;
        private System.Windows.Forms.CheckBox SKeyCheckBox;
        private System.Windows.Forms.CheckBox DKeyCheckBox;
        #endregion

        #region Controls - Speed
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Label LabelSpeed;
        private System.Windows.Forms.TrackBar TrackBarSpeed;
        #endregion

        #region Controls - Length
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.Label LabelLength;
        private System.Windows.Forms.TrackBar TrackBarLength;
        #endregion

        #region Controls - Logs
        private System.Windows.Forms.GroupBox GroupBox4;
        private System.Windows.Forms.TextBox TextBoxLog;
        #endregion

        #region Controls - Time
        private System.Windows.Forms.GroupBox GroupBox5;
        private System.Windows.Forms.Label LabelElapsedTime;
        #endregion

        #region Controls - Buttons
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonStop;
        #endregion

        #region Components
        private System.Windows.Forms.Timer MainTimer;
        #endregion
    }
}
