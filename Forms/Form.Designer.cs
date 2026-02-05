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
            components = new System.ComponentModel.Container();
            MenuStrip = new System.Windows.Forms.MenuStrip();
            HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            HowToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            CheckForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ExtraOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            SwitchToGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            RandomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            RandomizeIntervalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AzertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            MainTimer = new System.Windows.Forms.Timer(components);
            MouseGroupBox = new System.Windows.Forms.GroupBox();
            MouseClickLeftCheckBox = new System.Windows.Forms.CheckBox();
            MouseClickRightCheckBox = new System.Windows.Forms.CheckBox();
            KeyboardGroupBox = new System.Windows.Forms.GroupBox();
            WKeyCheckBox = new System.Windows.Forms.CheckBox();
            AKeyCheckBox = new System.Windows.Forms.CheckBox();
            SKeyCheckBox = new System.Windows.Forms.CheckBox();
            DKeyCheckBox = new System.Windows.Forms.CheckBox();
            GroupBox2 = new System.Windows.Forms.GroupBox();
            LabelSpeed = new System.Windows.Forms.Label();
            TrackBarSpeed = new System.Windows.Forms.TrackBar();
            GroupBox3 = new System.Windows.Forms.GroupBox();
            NumericUpDownHours = new System.Windows.Forms.NumericUpDown();
            NumericUpDownMinutes = new System.Windows.Forms.NumericUpDown();
            LabelHours = new System.Windows.Forms.Label();
            LabelMinutes = new System.Windows.Forms.Label();
            GroupBox4 = new System.Windows.Forms.GroupBox();
            TextBoxLog = new System.Windows.Forms.TextBox();
            GroupBox5 = new System.Windows.Forms.GroupBox();
            LabelElapsedTime = new System.Windows.Forms.Label();
            ButtonStart = new System.Windows.Forms.Button();
            ButtonStop = new System.Windows.Forms.Button();
            MenuStrip.SuspendLayout();
            MouseGroupBox.SuspendLayout();
            KeyboardGroupBox.SuspendLayout();
            GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrackBarSpeed).BeginInit();
            GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownMinutes).BeginInit();
            GroupBox4.SuspendLayout();
            GroupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { HelpToolStripMenuItem, ExtraOptionsToolStripMenuItem });
            MenuStrip.Location = new System.Drawing.Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            MenuStrip.Size = new System.Drawing.Size(560, 28);
            MenuStrip.TabIndex = 0;
            MenuStrip.Text = "MenuStrip";
            // 
            // HelpToolStripMenuItem
            // 
            HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { HowToUseToolStripMenuItem, CheckForUpdatesToolStripMenuItem });
            HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            HelpToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            HelpToolStripMenuItem.Text = "File";
            // 
            // HowToUseToolStripMenuItem
            // 
            HowToUseToolStripMenuItem.Name = "HowToUseToolStripMenuItem";
            HowToUseToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            HowToUseToolStripMenuItem.Text = "How To Use";
            HowToUseToolStripMenuItem.Click += TutorialToolStripMenuItem_Click;
            // 
            // CheckForUpdatesToolStripMenuItem
            // 
            CheckForUpdatesToolStripMenuItem.Name = "CheckForUpdatesToolStripMenuItem";
            CheckForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            CheckForUpdatesToolStripMenuItem.Text = "Check For Updates";
            CheckForUpdatesToolStripMenuItem.Click += CheckForUpdatesToolStripMenuItem_Click;
            // 
            // ExtraOptionsToolStripMenuItem
            // 
            ExtraOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { SwitchToGameToolStripMenuItem, RandomizeToolStripMenuItem, RandomizeIntervalsToolStripMenuItem, AzertyToolStripMenuItem });
            ExtraOptionsToolStripMenuItem.Name = "ExtraOptionsToolStripMenuItem";
            ExtraOptionsToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            ExtraOptionsToolStripMenuItem.Text = "Extra Options";
            // 
            // SwitchToGameToolStripMenuItem
            // 
            SwitchToGameToolStripMenuItem.Checked = true;
            SwitchToGameToolStripMenuItem.CheckOnClick = true;
            SwitchToGameToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            SwitchToGameToolStripMenuItem.Name = "SwitchToGameToolStripMenuItem";
            SwitchToGameToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
            SwitchToGameToolStripMenuItem.Text = "Switch To Game Automatically";
            SwitchToGameToolStripMenuItem.Click += SwitchToGameToolStripMenuItem_Click;
            // 
            // RandomizeToolStripMenuItem
            // 
            RandomizeToolStripMenuItem.Checked = true;
            RandomizeToolStripMenuItem.CheckOnClick = true;
            RandomizeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            RandomizeToolStripMenuItem.Name = "RandomizeToolStripMenuItem";
            RandomizeToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
            RandomizeToolStripMenuItem.Text = "Randomize Simulation";
            RandomizeToolStripMenuItem.Click += RandomizeToolStripMenuItem_Click;
            // 
            // RandomizeIntervalsToolStripMenuItem
            // 
            RandomizeIntervalsToolStripMenuItem.Checked = true;
            RandomizeIntervalsToolStripMenuItem.CheckOnClick = true;
            RandomizeIntervalsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            RandomizeIntervalsToolStripMenuItem.Name = "RandomizeIntervalsToolStripMenuItem";
            RandomizeIntervalsToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
            RandomizeIntervalsToolStripMenuItem.Text = "Randomize Intervals";
            RandomizeIntervalsToolStripMenuItem.Click += RandomizeIntervalsToolStripMenuItem_Click;
            // 
            // AzertyToolStripMenuItem
            // 
            AzertyToolStripMenuItem.CheckOnClick = true;
            AzertyToolStripMenuItem.Name = "AzertyToolStripMenuItem";
            AzertyToolStripMenuItem.Size = new System.Drawing.Size(294, 26);
            AzertyToolStripMenuItem.Text = "Azerty Layout";
            AzertyToolStripMenuItem.Click += AzertyToolStripMenuItem_Click;
            // 
            // MainTimer
            // 
            MainTimer.Interval = 2000;
            MainTimer.Tick += ElapsedTimer_Tick;
            // 
            // MouseGroupBox
            // 
            MouseGroupBox.Controls.Add(MouseClickLeftCheckBox);
            MouseGroupBox.Controls.Add(MouseClickRightCheckBox);
            MouseGroupBox.Location = new System.Drawing.Point(10, 35);
            MouseGroupBox.Name = "MouseGroupBox";
            MouseGroupBox.Size = new System.Drawing.Size(200, 69);
            MouseGroupBox.TabIndex = 0;
            MouseGroupBox.TabStop = false;
            MouseGroupBox.Text = "Mouse";
            // 
            // MouseClickLeftCheckBox
            // 
            MouseClickLeftCheckBox.AutoSize = true;
            MouseClickLeftCheckBox.Location = new System.Drawing.Point(10, 22);
            MouseClickLeftCheckBox.Name = "MouseClickLeftCheckBox";
            MouseClickLeftCheckBox.Size = new System.Drawing.Size(93, 21);
            MouseClickLeftCheckBox.TabIndex = 0;
            MouseClickLeftCheckBox.Text = "Left Click";
            MouseClickLeftCheckBox.UseVisualStyleBackColor = true;
            // 
            // MouseClickRightCheckBox
            // 
            MouseClickRightCheckBox.AutoSize = true;
            MouseClickRightCheckBox.Location = new System.Drawing.Point(10, 45);
            MouseClickRightCheckBox.Name = "MouseClickRightCheckBox";
            MouseClickRightCheckBox.Size = new System.Drawing.Size(103, 21);
            MouseClickRightCheckBox.TabIndex = 1;
            MouseClickRightCheckBox.Text = "Right Click";
            MouseClickRightCheckBox.UseVisualStyleBackColor = true;
            // 
            // KeyboardGroupBox
            // 
            KeyboardGroupBox.Controls.Add(WKeyCheckBox);
            KeyboardGroupBox.Controls.Add(AKeyCheckBox);
            KeyboardGroupBox.Controls.Add(SKeyCheckBox);
            KeyboardGroupBox.Controls.Add(DKeyCheckBox);
            KeyboardGroupBox.Location = new System.Drawing.Point(10, 110);
            KeyboardGroupBox.Name = "KeyboardGroupBox";
            KeyboardGroupBox.Size = new System.Drawing.Size(200, 115);
            KeyboardGroupBox.TabIndex = 1;
            KeyboardGroupBox.TabStop = false;
            KeyboardGroupBox.Text = "Keyboard";
            // 
            // WKeyCheckBox
            // 
            WKeyCheckBox.AutoSize = true;
            WKeyCheckBox.Location = new System.Drawing.Point(10, 22);
            WKeyCheckBox.Name = "WKeyCheckBox";
            WKeyCheckBox.Size = new System.Drawing.Size(76, 21);
            WKeyCheckBox.TabIndex = 0;
            WKeyCheckBox.Text = "W Key";
            WKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // AKeyCheckBox
            // 
            AKeyCheckBox.AutoSize = true;
            AKeyCheckBox.Location = new System.Drawing.Point(10, 45);
            AKeyCheckBox.Name = "AKeyCheckBox";
            AKeyCheckBox.Size = new System.Drawing.Size(71, 21);
            AKeyCheckBox.TabIndex = 1;
            AKeyCheckBox.Text = "A Key";
            AKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // SKeyCheckBox
            // 
            SKeyCheckBox.AutoSize = true;
            SKeyCheckBox.Location = new System.Drawing.Point(10, 68);
            SKeyCheckBox.Name = "SKeyCheckBox";
            SKeyCheckBox.Size = new System.Drawing.Size(71, 21);
            SKeyCheckBox.TabIndex = 2;
            SKeyCheckBox.Text = "S Key";
            SKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // DKeyCheckBox
            // 
            DKeyCheckBox.AutoSize = true;
            DKeyCheckBox.Location = new System.Drawing.Point(10, 91);
            DKeyCheckBox.Name = "DKeyCheckBox";
            DKeyCheckBox.Size = new System.Drawing.Size(72, 21);
            DKeyCheckBox.TabIndex = 3;
            DKeyCheckBox.Text = "D Key";
            DKeyCheckBox.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(LabelSpeed);
            GroupBox2.Controls.Add(TrackBarSpeed);
            GroupBox2.Location = new System.Drawing.Point(10, 231);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Size = new System.Drawing.Size(200, 98);
            GroupBox2.TabIndex = 12;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "Speed";
            // 
            // LabelSpeed
            // 
            LabelSpeed.Location = new System.Drawing.Point(10, 20);
            LabelSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            LabelSpeed.Name = "LabelSpeed";
            LabelSpeed.Size = new System.Drawing.Size(180, 25);
            LabelSpeed.TabIndex = 6;
            LabelSpeed.Text = "1 Simulation / Minute";
            LabelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrackBarSpeed
            // 
            TrackBarSpeed.LargeChange = 2;
            TrackBarSpeed.Location = new System.Drawing.Point(10, 50);
            TrackBarSpeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            TrackBarSpeed.Minimum = 1;
            TrackBarSpeed.Name = "TrackBarSpeed";
            TrackBarSpeed.Size = new System.Drawing.Size(180, 56);
            TrackBarSpeed.TabIndex = 2;
            TrackBarSpeed.Value = 1;
            TrackBarSpeed.Scroll += TrackBarSpeed_Scroll;
            // 
            // GroupBox3
            // 
            GroupBox3.Controls.Add(NumericUpDownHours);
            GroupBox3.Controls.Add(NumericUpDownMinutes);
            GroupBox3.Controls.Add(LabelHours);
            GroupBox3.Controls.Add(LabelMinutes);
            GroupBox3.Location = new System.Drawing.Point(10, 335);
            GroupBox3.Name = "GroupBox3";
            GroupBox3.Size = new System.Drawing.Size(200, 98);
            GroupBox3.TabIndex = 13;
            GroupBox3.TabStop = false;
            GroupBox3.Text = "Length";
            // 
            // NumericUpDownHours
            // 
            NumericUpDownHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            NumericUpDownHours.Location = new System.Drawing.Point(7, 30);
            NumericUpDownHours.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NumericUpDownHours.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            NumericUpDownHours.Name = "NumericUpDownHours";
            NumericUpDownHours.Size = new System.Drawing.Size(90, 24);
            NumericUpDownHours.TabIndex = 0;
            NumericUpDownHours.Value = new decimal(new int[] { 8, 0, 0, 0 });
            NumericUpDownHours.ValueChanged += NumericUpDownHours_ValueChanged;
            // 
            // NumericUpDownMinutes
            // 
            NumericUpDownMinutes.Location = new System.Drawing.Point(103, 30);
            NumericUpDownMinutes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            NumericUpDownMinutes.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            NumericUpDownMinutes.Name = "NumericUpDownMinutes";
            NumericUpDownMinutes.Size = new System.Drawing.Size(90, 24);
            NumericUpDownMinutes.TabIndex = 1;
            NumericUpDownMinutes.ValueChanged += NumericUpDownMinutes_ValueChanged;
            // 
            // LabelHours
            // 
            LabelHours.AutoSize = true;
            LabelHours.Location = new System.Drawing.Point(7, 57);
            LabelHours.Name = "LabelHours";
            LabelHours.Size = new System.Drawing.Size(50, 17);
            LabelHours.TabIndex = 6;
            LabelHours.Text = "Hours";
            // 
            // LabelMinutes
            // 
            LabelMinutes.AutoSize = true;
            LabelMinutes.Location = new System.Drawing.Point(103, 57);
            LabelMinutes.Name = "LabelMinutes";
            LabelMinutes.Size = new System.Drawing.Size(62, 17);
            LabelMinutes.TabIndex = 7;
            LabelMinutes.Text = "Minutes";
            // 
            // GroupBox4
            // 
            GroupBox4.Controls.Add(TextBoxLog);
            GroupBox4.Location = new System.Drawing.Point(220, 35);
            GroupBox4.Name = "GroupBox4";
            GroupBox4.Size = new System.Drawing.Size(330, 398);
            GroupBox4.TabIndex = 14;
            GroupBox4.TabStop = false;
            GroupBox4.Text = "Logs";
            // 
            // TextBoxLog
            // 
            TextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TextBoxLog.Location = new System.Drawing.Point(10, 22);
            TextBoxLog.Multiline = true;
            TextBoxLog.Name = "TextBoxLog";
            TextBoxLog.ReadOnly = true;
            TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            TextBoxLog.Size = new System.Drawing.Size(310, 370);
            TextBoxLog.TabIndex = 0;
            // 
            // GroupBox5
            // 
            GroupBox5.Controls.Add(LabelElapsedTime);
            GroupBox5.Location = new System.Drawing.Point(220, 439);
            GroupBox5.Name = "GroupBox5";
            GroupBox5.Size = new System.Drawing.Size(330, 66);
            GroupBox5.TabIndex = 15;
            GroupBox5.TabStop = false;
            GroupBox5.Text = "Time";
            // 
            // LabelElapsedTime
            // 
            LabelElapsedTime.Location = new System.Drawing.Point(6, 20);
            LabelElapsedTime.Name = "LabelElapsedTime";
            LabelElapsedTime.Size = new System.Drawing.Size(318, 43);
            LabelElapsedTime.TabIndex = 1;
            LabelElapsedTime.Text = "Elapsed: 00:00\r\nRemaining: 00:00";
            LabelElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonStart
            // 
            ButtonStart.Location = new System.Drawing.Point(10, 439);
            ButtonStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ButtonStart.Name = "ButtonStart";
            ButtonStart.Size = new System.Drawing.Size(200, 30);
            ButtonStart.TabIndex = 3;
            ButtonStart.Text = "Start";
            ButtonStart.UseVisualStyleBackColor = true;
            ButtonStart.Click += ButtonStart_ClickAsync;
            // 
            // ButtonStop
            // 
            ButtonStop.Enabled = false;
            ButtonStop.Location = new System.Drawing.Point(10, 475);
            ButtonStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new System.Drawing.Size(200, 30);
            ButtonStop.TabIndex = 4;
            ButtonStop.Text = "Stop";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click;
            // 
            // Form
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            ClientSize = new System.Drawing.Size(560, 515);
            Controls.Add(GroupBox5);
            Controls.Add(GroupBox4);
            Controls.Add(GroupBox3);
            Controls.Add(GroupBox2);
            Controls.Add(KeyboardGroupBox);
            Controls.Add(MouseGroupBox);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonStart);
            Controls.Add(MenuStrip);
            Font = new System.Drawing.Font("Verdana", 8.25F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MainMenuStrip = MenuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "Form";
            ShowIcon = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "AFK Assist";
            TopMost = true;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            MouseGroupBox.ResumeLayout(false);
            MouseGroupBox.PerformLayout();
            KeyboardGroupBox.ResumeLayout(false);
            KeyboardGroupBox.PerformLayout();
            GroupBox2.ResumeLayout(false);
            GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrackBarSpeed).EndInit();
            GroupBox3.ResumeLayout(false);
            GroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownMinutes).EndInit();
            GroupBox4.ResumeLayout(false);
            GroupBox4.PerformLayout();
            GroupBox5.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.NumericUpDown NumericUpDownHours;
        private System.Windows.Forms.NumericUpDown NumericUpDownMinutes;
        private System.Windows.Forms.Label LabelHours;
        private System.Windows.Forms.Label LabelMinutes;
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
