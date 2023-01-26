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
            this.ExtraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RocketLeagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.TrackBarLength = new System.Windows.Forms.TrackBar();
            this.MouseCheckBox = new System.Windows.Forms.CheckBox();
            this.KeyboardCheckBox = new System.Windows.Forms.CheckBox();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonStop = new System.Windows.Forms.Button();
            this.LabelLength = new System.Windows.Forms.Label();
            this.AltTabCheckBox = new System.Windows.Forms.CheckBox();
            this.MousePanel = new System.Windows.Forms.Panel();
            this.MouseClickRightCheckBox = new System.Windows.Forms.CheckBox();
            this.MouseClickLeftCheckBox = new System.Windows.Forms.CheckBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.KeyboardPanel = new System.Windows.Forms.Panel();
            this.DKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.SKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.AKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.WKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.TrackBarSpeed = new System.Windows.Forms.TrackBar();
            this.LabelSpeed = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.TextBoxLog = new System.Windows.Forms.TextBox();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarLength)).BeginInit();
            this.MousePanel.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.KeyboardPanel.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSpeed)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExtraToolStripMenuItem,
            this.PresetsToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(564, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // ExtraToolStripMenuItem
            // 
            this.ExtraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearToolStripMenuItem,
            this.ToolStripSeparator1,
            this.TutorialToolStripMenuItem});
            this.ExtraToolStripMenuItem.Name = "ExtraToolStripMenuItem";
            this.ExtraToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.ExtraToolStripMenuItem.Text = "Extra";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ClearToolStripMenuItem.Text = "Clear";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // TutorialToolStripMenuItem
            // 
            this.TutorialToolStripMenuItem.Name = "TutorialToolStripMenuItem";
            this.TutorialToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.TutorialToolStripMenuItem.Text = "How to use";
            this.TutorialToolStripMenuItem.Click += new System.EventHandler(this.TutorialToolStripMenuItem_Click);
            // 
            // PresetsToolStripMenuItem
            // 
            this.PresetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GTAToolStripMenuItem,
            this.RocketLeagueToolStripMenuItem});
            this.PresetsToolStripMenuItem.Name = "PresetsToolStripMenuItem";
            this.PresetsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.PresetsToolStripMenuItem.Text = "Presets";
            // 
            // GTAToolStripMenuItem
            // 
            this.GTAToolStripMenuItem.Name = "GTAToolStripMenuItem";
            this.GTAToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.GTAToolStripMenuItem.Text = "Grand Theft Auto 5";
            this.GTAToolStripMenuItem.Click += new System.EventHandler(this.GTAToolStripMenuItem_Click);
            // 
            // RocketLeagueToolStripMenuItem
            // 
            this.RocketLeagueToolStripMenuItem.Name = "RocketLeagueToolStripMenuItem";
            this.RocketLeagueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.TrackBarLength.Location = new System.Drawing.Point(7, 69);
            this.TrackBarLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TrackBarLength.Maximum = 120;
            this.TrackBarLength.Minimum = 1;
            this.TrackBarLength.Name = "TrackBarLength";
            this.TrackBarLength.Size = new System.Drawing.Size(186, 45);
            this.TrackBarLength.TabIndex = 0;
            this.TrackBarLength.TickFrequency = 10;
            this.TrackBarLength.Value = 1;
            this.TrackBarLength.Scroll += new System.EventHandler(this.TrackBarLength_Scroll);
            // 
            // MouseCheckBox
            // 
            this.MouseCheckBox.AutoSize = true;
            this.MouseCheckBox.Location = new System.Drawing.Point(7, 43);
            this.MouseCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MouseCheckBox.Name = "MouseCheckBox";
            this.MouseCheckBox.Size = new System.Drawing.Size(94, 17);
            this.MouseCheckBox.TabIndex = 1;
            this.MouseCheckBox.Text = "Mouse Click";
            this.MouseCheckBox.UseVisualStyleBackColor = true;
            this.MouseCheckBox.Click += new System.EventHandler(this.MouseCheckBox_Click);
            // 
            // KeyboardCheckBox
            // 
            this.KeyboardCheckBox.AutoSize = true;
            this.KeyboardCheckBox.Location = new System.Drawing.Point(7, 66);
            this.KeyboardCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.KeyboardCheckBox.Name = "KeyboardCheckBox";
            this.KeyboardCheckBox.Size = new System.Drawing.Size(81, 17);
            this.KeyboardCheckBox.TabIndex = 2;
            this.KeyboardCheckBox.Text = "Keyboard";
            this.KeyboardCheckBox.UseVisualStyleBackColor = true;
            this.KeyboardCheckBox.Click += new System.EventHandler(this.KeyboardCheckBox_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(18, 222);
            this.ButtonStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(153, 24);
            this.ButtonStart.TabIndex = 3;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_ClickAsync);
            // 
            // ButtonStop
            // 
            this.ButtonStop.Enabled = false;
            this.ButtonStop.Location = new System.Drawing.Point(19, 249);
            this.ButtonStop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(152, 24);
            this.ButtonStop.TabIndex = 4;
            this.ButtonStop.Text = "Stop";
            this.ButtonStop.UseVisualStyleBackColor = true;
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // LabelLength
            // 
            this.LabelLength.Location = new System.Drawing.Point(7, 17);
            this.LabelLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelLength.Name = "LabelLength";
            this.LabelLength.Size = new System.Drawing.Size(186, 49);
            this.LabelLength.TabIndex = 5;
            this.LabelLength.Text = "1 minute";
            this.LabelLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AltTabCheckBox
            // 
            this.AltTabCheckBox.AutoSize = true;
            this.AltTabCheckBox.Location = new System.Drawing.Point(7, 20);
            this.AltTabCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.AltTabCheckBox.Name = "AltTabCheckBox";
            this.AltTabCheckBox.Size = new System.Drawing.Size(78, 17);
            this.AltTabCheckBox.TabIndex = 6;
            this.AltTabCheckBox.Text = "Alt + Tab";
            this.AltTabCheckBox.UseVisualStyleBackColor = true;
            // 
            // MousePanel
            // 
            this.MousePanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MousePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MousePanel.Controls.Add(this.MouseClickRightCheckBox);
            this.MousePanel.Controls.Add(this.MouseClickLeftCheckBox);
            this.MousePanel.Location = new System.Drawing.Point(7, 89);
            this.MousePanel.Name = "MousePanel";
            this.MousePanel.Size = new System.Drawing.Size(131, 46);
            this.MousePanel.TabIndex = 10;
            this.MousePanel.Visible = false;
            // 
            // MouseClickRightCheckBox
            // 
            this.MouseClickRightCheckBox.AutoSize = true;
            this.MouseClickRightCheckBox.Location = new System.Drawing.Point(3, 26);
            this.MouseClickRightCheckBox.Name = "MouseClickRightCheckBox";
            this.MouseClickRightCheckBox.Size = new System.Drawing.Size(127, 17);
            this.MouseClickRightCheckBox.TabIndex = 8;
            this.MouseClickRightCheckBox.Text = "Mouse Click Right";
            this.MouseClickRightCheckBox.UseVisualStyleBackColor = true;
            this.MouseClickRightCheckBox.Click += new System.EventHandler(this.MouseClickCheckBox_Click);
            // 
            // MouseClickLeftCheckBox
            // 
            this.MouseClickLeftCheckBox.AutoSize = true;
            this.MouseClickLeftCheckBox.Location = new System.Drawing.Point(3, 3);
            this.MouseClickLeftCheckBox.Name = "MouseClickLeftCheckBox";
            this.MouseClickLeftCheckBox.Size = new System.Drawing.Size(119, 17);
            this.MouseClickLeftCheckBox.TabIndex = 7;
            this.MouseClickLeftCheckBox.Text = "Mouse Click Left";
            this.MouseClickLeftCheckBox.UseVisualStyleBackColor = true;
            this.MouseClickLeftCheckBox.Click += new System.EventHandler(this.MouseClickCheckBox_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.MousePanel);
            this.GroupBox1.Controls.Add(this.KeyboardPanel);
            this.GroupBox1.Controls.Add(this.AltTabCheckBox);
            this.GroupBox1.Controls.Add(this.MouseCheckBox);
            this.GroupBox1.Controls.Add(this.KeyboardCheckBox);
            this.GroupBox1.Location = new System.Drawing.Point(12, 27);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(165, 189);
            this.GroupBox1.TabIndex = 11;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Configure Simulation";
            // 
            // KeyboardPanel
            // 
            this.KeyboardPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.KeyboardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.KeyboardPanel.Controls.Add(this.DKeyCheckBox);
            this.KeyboardPanel.Controls.Add(this.SKeyCheckBox);
            this.KeyboardPanel.Controls.Add(this.AKeyCheckBox);
            this.KeyboardPanel.Controls.Add(this.WKeyCheckBox);
            this.KeyboardPanel.Location = new System.Drawing.Point(7, 89);
            this.KeyboardPanel.Name = "KeyboardPanel";
            this.KeyboardPanel.Size = new System.Drawing.Size(68, 92);
            this.KeyboardPanel.TabIndex = 11;
            this.KeyboardPanel.Visible = false;
            // 
            // DKeyCheckBox
            // 
            this.DKeyCheckBox.AutoSize = true;
            this.DKeyCheckBox.Location = new System.Drawing.Point(3, 72);
            this.DKeyCheckBox.Name = "DKeyCheckBox";
            this.DKeyCheckBox.Size = new System.Drawing.Size(61, 17);
            this.DKeyCheckBox.TabIndex = 10;
            this.DKeyCheckBox.Text = "D Key";
            this.DKeyCheckBox.UseVisualStyleBackColor = true;
            this.DKeyCheckBox.Click += new System.EventHandler(this.WASDKeyCheckBox_Click);
            // 
            // SKeyCheckBox
            // 
            this.SKeyCheckBox.AutoSize = true;
            this.SKeyCheckBox.Location = new System.Drawing.Point(3, 49);
            this.SKeyCheckBox.Name = "SKeyCheckBox";
            this.SKeyCheckBox.Size = new System.Drawing.Size(60, 17);
            this.SKeyCheckBox.TabIndex = 9;
            this.SKeyCheckBox.Text = "S Key";
            this.SKeyCheckBox.UseVisualStyleBackColor = true;
            this.SKeyCheckBox.Click += new System.EventHandler(this.WASDKeyCheckBox_Click);
            // 
            // AKeyCheckBox
            // 
            this.AKeyCheckBox.AutoSize = true;
            this.AKeyCheckBox.Location = new System.Drawing.Point(3, 26);
            this.AKeyCheckBox.Name = "AKeyCheckBox";
            this.AKeyCheckBox.Size = new System.Drawing.Size(60, 17);
            this.AKeyCheckBox.TabIndex = 8;
            this.AKeyCheckBox.Text = "A Key";
            this.AKeyCheckBox.UseVisualStyleBackColor = true;
            this.AKeyCheckBox.Click += new System.EventHandler(this.WASDKeyCheckBox_Click);
            // 
            // WKeyCheckBox
            // 
            this.WKeyCheckBox.AutoSize = true;
            this.WKeyCheckBox.Location = new System.Drawing.Point(3, 3);
            this.WKeyCheckBox.Name = "WKeyCheckBox";
            this.WKeyCheckBox.Size = new System.Drawing.Size(62, 17);
            this.WKeyCheckBox.TabIndex = 7;
            this.WKeyCheckBox.Text = "W key";
            this.WKeyCheckBox.UseVisualStyleBackColor = true;
            this.WKeyCheckBox.Click += new System.EventHandler(this.WASDKeyCheckBox_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.TrackBarSpeed);
            this.GroupBox2.Controls.Add(this.LabelSpeed);
            this.GroupBox2.Location = new System.Drawing.Point(183, 27);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(200, 120);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Speed";
            // 
            // TrackBarSpeed
            // 
            this.TrackBarSpeed.LargeChange = 2;
            this.TrackBarSpeed.Location = new System.Drawing.Point(7, 69);
            this.TrackBarSpeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TrackBarSpeed.Minimum = 1;
            this.TrackBarSpeed.Name = "TrackBarSpeed";
            this.TrackBarSpeed.Size = new System.Drawing.Size(186, 45);
            this.TrackBarSpeed.TabIndex = 2;
            this.TrackBarSpeed.Value = 1;
            this.TrackBarSpeed.Scroll += new System.EventHandler(this.TrackBarSpeed_Scroll);
            // 
            // LabelSpeed
            // 
            this.LabelSpeed.Location = new System.Drawing.Point(7, 17);
            this.LabelSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSpeed.Name = "LabelSpeed";
            this.LabelSpeed.Size = new System.Drawing.Size(186, 49);
            this.LabelSpeed.TabIndex = 6;
            this.LabelSpeed.Text = "1 simulation / minute";
            this.LabelSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.TrackBarLength);
            this.GroupBox3.Controls.Add(this.LabelLength);
            this.GroupBox3.Location = new System.Drawing.Point(183, 153);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(200, 120);
            this.GroupBox3.TabIndex = 13;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Length";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.TextBoxLog);
            this.GroupBox4.Location = new System.Drawing.Point(389, 28);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(162, 245);
            this.GroupBox4.TabIndex = 14;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Log";
            // 
            // TextBoxLog
            // 
            this.TextBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBoxLog.Location = new System.Drawing.Point(7, 21);
            this.TextBoxLog.Multiline = true;
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.ReadOnly = true;
            this.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxLog.Size = new System.Drawing.Size(149, 218);
            this.TextBoxLog.TabIndex = 0;
            // 
            // Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(564, 283);
            this.Controls.Add(this.ButtonStop);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
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
            this.MousePanel.ResumeLayout(false);
            this.MousePanel.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.KeyboardPanel.ResumeLayout(false);
            this.KeyboardPanel.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSpeed)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExtraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TutorialToolStripMenuItem;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.TrackBar TrackBarLength;
        private System.Windows.Forms.CheckBox MouseCheckBox;
        private System.Windows.Forms.CheckBox KeyboardCheckBox;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonStop;
        private System.Windows.Forms.Label LabelLength;
        private System.Windows.Forms.CheckBox AltTabCheckBox;
        private System.Windows.Forms.Panel MousePanel;
        private System.Windows.Forms.CheckBox MouseClickRightCheckBox;
        private System.Windows.Forms.CheckBox MouseClickLeftCheckBox;
        private System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.GroupBox GroupBox3;
        private System.Windows.Forms.GroupBox GroupBox4;
        private System.Windows.Forms.TrackBar TrackBarSpeed;
        private System.Windows.Forms.Label LabelSpeed;
        private System.Windows.Forms.TextBox TextBoxLog;
        private System.Windows.Forms.Panel KeyboardPanel;
        private System.Windows.Forms.CheckBox DKeyCheckBox;
        private System.Windows.Forms.CheckBox SKeyCheckBox;
        private System.Windows.Forms.CheckBox AKeyCheckBox;
        private System.Windows.Forms.CheckBox WKeyCheckBox;
        private System.Windows.Forms.ToolStripMenuItem PresetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RocketLeagueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem GTAToolStripMenuItem;
    }
}

