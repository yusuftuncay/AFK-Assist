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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtraOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AltTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AzertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RocketLeagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.TrackBarLength = new System.Windows.Forms.TrackBar();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.LabelLength = new System.Windows.Forms.Label();
            this.MouseClickRightCheckBox = new System.Windows.Forms.CheckBox();
            this.MouseClickLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.KeyboardGroupBox = new System.Windows.Forms.GroupBox();
            this.DKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.SKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.AKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.WKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.MouseGroupBox = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.TrackBarSpeed = new System.Windows.Forms.TrackBar();
            this.LabelSpeed = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.TextBoxLog = new System.Windows.Forms.TextBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.LabelElapsedTime = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarLength)).BeginInit();
            this.KeyboardGroupBox.SuspendLayout();
            this.MouseGroupBox.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSpeed)).BeginInit();
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
            this.ExtraOptionsToolStripMenuItem,
            this.PresetsToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(440, 28);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.HelpToolStripMenuItem.Text = "How To Use";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.TutorialToolStripMenuItem_Click);
            // 
            // ExtraOptionsToolStripMenuItem
            // 
            this.ExtraOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AltTabToolStripMenuItem,
            this.RandomizeToolStripMenuItem,
            this.AzertyToolStripMenuItem,
            this.toolStripSeparator1,
            this.ClearToolStripMenuItem});
            this.ExtraOptionsToolStripMenuItem.Name = "ExtraOptionsToolStripMenuItem";
            this.ExtraOptionsToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.ExtraOptionsToolStripMenuItem.Text = "Extra Options";
            // 
            // AltTabToolStripMenuItem
            // 
            this.AltTabToolStripMenuItem.CheckOnClick = true;
            this.AltTabToolStripMenuItem.Name = "AltTabToolStripMenuItem";
            this.AltTabToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.AltTabToolStripMenuItem.Text = "Alt + Tab Into Previous App";
            // 
            // RandomizeToolStripMenuItem
            // 
            this.RandomizeToolStripMenuItem.CheckOnClick = true;
            this.RandomizeToolStripMenuItem.Name = "RandomizeToolStripMenuItem";
            this.RandomizeToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.RandomizeToolStripMenuItem.Text = "Randomize Simulation";
            // 
            // AzertyToolStripMenuItem
            // 
            this.AzertyToolStripMenuItem.CheckOnClick = true;
            this.AzertyToolStripMenuItem.Name = "AzertyToolStripMenuItem";
            this.AzertyToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.AzertyToolStripMenuItem.Text = "Azerty Layout";
            this.AzertyToolStripMenuItem.Click += new System.EventHandler(this.AzertyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(270, 6);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(273, 26);
            this.ClearToolStripMenuItem.Text = "Clear All Fields";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // PresetsToolStripMenuItem
            // 
            this.PresetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GTAToolStripMenuItem,
            this.RocketLeagueToolStripMenuItem});
            this.PresetsToolStripMenuItem.Name = "PresetsToolStripMenuItem";
            this.PresetsToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.PresetsToolStripMenuItem.Text = "Presets";
            // 
            // GTAToolStripMenuItem
            // 
            this.GTAToolStripMenuItem.Name = "GTAToolStripMenuItem";
            this.GTAToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.GTAToolStripMenuItem.Text = "Grand Theft Auto 5";
            this.GTAToolStripMenuItem.Click += new System.EventHandler(this.GTAToolStripMenuItem_Click);
            // 
            // RocketLeagueToolStripMenuItem
            // 
            this.RocketLeagueToolStripMenuItem.Name = "RocketLeagueToolStripMenuItem";
            this.RocketLeagueToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.RocketLeagueToolStripMenuItem.Text = "Rocket League";
            this.RocketLeagueToolStripMenuItem.Click += new System.EventHandler(this.RocketLeagueToolStripMenuItem_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 2000;
            this.MainTimer.Tick += new System.EventHandler(this.Timer_TickAsync);
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
            // KeyboardGroupBox
            // 
            this.KeyboardGroupBox.Controls.Add(this.DKeyCheckBox);
            this.KeyboardGroupBox.Controls.Add(this.SKeyCheckBox);
            this.KeyboardGroupBox.Controls.Add(this.AKeyCheckBox);
            this.KeyboardGroupBox.Controls.Add(this.WKeyCheckBox);
            this.KeyboardGroupBox.Location = new System.Drawing.Point(10, 110);
            this.KeyboardGroupBox.Name = "KeyboardGroupBox";
            this.KeyboardGroupBox.Size = new System.Drawing.Size(200, 115);
            this.KeyboardGroupBox.TabIndex = 1;
            this.KeyboardGroupBox.TabStop = false;
            this.KeyboardGroupBox.Text = "Keyboard";
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
            // MouseGroupBox
            // 
            this.MouseGroupBox.Controls.Add(this.MouseClickRightCheckBox);
            this.MouseGroupBox.Controls.Add(this.MouseClickLeftCheckBox);
            this.MouseGroupBox.Location = new System.Drawing.Point(10, 35);
            this.MouseGroupBox.Name = "MouseGroupBox";
            this.MouseGroupBox.Size = new System.Drawing.Size(200, 69);
            this.MouseGroupBox.TabIndex = 0;
            this.MouseGroupBox.TabStop = false;
            this.MouseGroupBox.Text = "Mouse";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.TrackBarSpeed);
            this.GroupBox2.Controls.Add(this.LabelSpeed);
            this.GroupBox2.Location = new System.Drawing.Point(10, 231);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(200, 98);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Speed";
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
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.TrackBarLength);
            this.GroupBox3.Controls.Add(this.LabelLength);
            this.GroupBox3.Location = new System.Drawing.Point(10, 335);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(200, 98);
            this.GroupBox3.TabIndex = 13;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Length";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.TextBoxLog);
            this.GroupBox4.Location = new System.Drawing.Point(220, 35);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(210, 398);
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
            this.TextBoxLog.Size = new System.Drawing.Size(190, 370);
            this.TextBoxLog.TabIndex = 0;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.LabelElapsedTime);
            this.GroupBox5.Location = new System.Drawing.Point(220, 439);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(210, 66);
            this.GroupBox5.TabIndex = 15;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Time";
            // 
            // LabelElapsedTime
            // 
            this.LabelElapsedTime.Location = new System.Drawing.Point(10, 20);
            this.LabelElapsedTime.Name = "LabelElapsedTime";
            this.LabelElapsedTime.Size = new System.Drawing.Size(190, 40);
            this.LabelElapsedTime.TabIndex = 1;
            this.LabelElapsedTime.Text = "Elapsed: 00:00\r\nRemaining: 00:00";
            this.LabelElapsedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(440, 515);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.KeyboardGroupBox);
            this.Controls.Add(this.MouseGroupBox);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.KeyboardGroupBox.ResumeLayout(false);
            this.KeyboardGroupBox.PerformLayout();
            this.MouseGroupBox.ResumeLayout(false);
            this.MouseGroupBox.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSpeed)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Extra
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.TrackBar TrackBarLength;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.Label LabelLength;
        private System.Windows.Forms.CheckBox MouseClickRightCheckBox;
        private System.Windows.Forms.CheckBox MouseClickLeftCheckBox;
        private System.Windows.Forms.GroupBox MouseGroupBox;
        private System.Windows.Forms.GroupBox KeyboardGroupBox;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.GroupBox GroupBox4;
        private System.Windows.Forms.GroupBox GroupBox5;
        private System.Windows.Forms.TrackBar TrackBarSpeed;
        private System.Windows.Forms.Label LabelSpeed;
        private System.Windows.Forms.TextBox TextBoxLog;
        private System.Windows.Forms.CheckBox DKeyCheckBox;
        private System.Windows.Forms.CheckBox SKeyCheckBox;
        private System.Windows.Forms.CheckBox AKeyCheckBox;
        private System.Windows.Forms.CheckBox WKeyCheckBox;
        private System.Windows.Forms.ToolStripMenuItem PresetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RocketLeagueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GTAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExtraOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RandomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AltTabToolStripMenuItem;
        private System.Windows.Forms.Label LabelElapsedTime;
        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem AzertyToolStripMenuItem;
    }
}

