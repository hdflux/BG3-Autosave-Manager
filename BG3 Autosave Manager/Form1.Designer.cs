namespace BG3_Autosave_Manager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            EnableButton = new Button();
            DisableButton = new Button();
            LogTextBox = new TextBox();
            FormHeaderLabel = new Label();
            LogHeaderLabel = new Label();
            AutosaveLimitTrackBar = new TrackBar();
            AutosaveLimitLabel = new Label();
            label10 = new Label();
            label1 = new Label();
            label4 = new Label();
            BG3SaveFolderTextBox = new TextBox();
            BackupFolderTextBox = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            LoadAutosaveButton = new Button();
            AutosaveIntervalLabel = new Label();
            AutosaveIntervalTrackBar = new TrackBar();
            BG3StoryIdLabel = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            CountdownLabel = new Label();
            BackupNowButton = new Button();
            ((System.ComponentModel.ISupportInitialize)AutosaveLimitTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AutosaveIntervalTrackBar).BeginInit();
            SuspendLayout();
            // 
            // EnableButton
            // 
            EnableButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            EnableButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnableButton.Location = new Point(12, 510);
            EnableButton.Name = "EnableButton";
            EnableButton.Size = new Size(122, 32);
            EnableButton.TabIndex = 0;
            EnableButton.Text = "Enable Autosaves";
            EnableButton.UseVisualStyleBackColor = true;
            EnableButton.Click += EnableButton_Click;
            // 
            // DisableButton
            // 
            DisableButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DisableButton.Enabled = false;
            DisableButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DisableButton.Location = new Point(476, 510);
            DisableButton.Name = "DisableButton";
            DisableButton.Size = new Size(122, 32);
            DisableButton.TabIndex = 1;
            DisableButton.Text = "Disable Autosaves";
            DisableButton.UseVisualStyleBackColor = true;
            DisableButton.Click += DisableButton_Click;
            // 
            // LogTextBox
            // 
            LogTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LogTextBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogTextBox.Location = new Point(12, 347);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.ScrollBars = ScrollBars.Both;
            LogTextBox.Size = new Size(586, 149);
            LogTextBox.TabIndex = 2;
            LogTextBox.WordWrap = false;
            // 
            // FormHeaderLabel
            // 
            FormHeaderLabel.AutoSize = true;
            FormHeaderLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormHeaderLabel.Location = new Point(12, 11);
            FormHeaderLabel.Name = "FormHeaderLabel";
            FormHeaderLabel.Size = new Size(393, 21);
            FormHeaderLabel.TabIndex = 3;
            FormHeaderLabel.Text = "Baulder's Gate 3: Honour Mode Autosave Manager";
            // 
            // LogHeaderLabel
            // 
            LogHeaderLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LogHeaderLabel.AutoSize = true;
            LogHeaderLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogHeaderLabel.Location = new Point(12, 327);
            LogHeaderLabel.Name = "LogHeaderLabel";
            LogHeaderLabel.Size = new Size(84, 17);
            LogHeaderLabel.TabIndex = 4;
            LogHeaderLabel.Text = "Log Window";
            // 
            // AutosaveLimitTrackBar
            // 
            AutosaveLimitTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AutosaveLimitTrackBar.Location = new Point(14, 246);
            AutosaveLimitTrackBar.Margin = new Padding(2);
            AutosaveLimitTrackBar.Maximum = 50;
            AutosaveLimitTrackBar.Minimum = 1;
            AutosaveLimitTrackBar.Name = "AutosaveLimitTrackBar";
            AutosaveLimitTrackBar.Size = new Size(583, 45);
            AutosaveLimitTrackBar.TabIndex = 5;
            AutosaveLimitTrackBar.Value = 5;
            // 
            // AutosaveLimitLabel
            // 
            AutosaveLimitLabel.AutoSize = true;
            AutosaveLimitLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutosaveLimitLabel.Location = new Point(176, 229);
            AutosaveLimitLabel.Margin = new Padding(2, 0, 2, 0);
            AutosaveLimitLabel.Name = "AutosaveLimitLabel";
            AutosaveLimitLabel.Size = new Size(15, 17);
            AutosaveLimitLabel.TabIndex = 9;
            AutosaveLimitLabel.Text = "5";
            AutosaveLimitLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(14, 83);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(85, 17);
            label10.TabIndex = 11;
            label10.Text = "BG3 Story Id";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 117);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(94, 17);
            label1.TabIndex = 12;
            label1.Text = "Backup Folder";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(14, 40);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 17);
            label4.TabIndex = 14;
            label4.Text = "BG3 Save Folder";
            // 
            // BG3SaveFolderTextBox
            // 
            BG3SaveFolderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BG3SaveFolderTextBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BG3SaveFolderTextBox.Location = new Point(14, 59);
            BG3SaveFolderTextBox.Margin = new Padding(2);
            BG3SaveFolderTextBox.Name = "BG3SaveFolderTextBox";
            BG3SaveFolderTextBox.Size = new Size(583, 22);
            BG3SaveFolderTextBox.TabIndex = 15;
            BG3SaveFolderTextBox.Click += BG3SaveFolderTextBox_Click;
            // 
            // BackupFolderTextBox
            // 
            BackupFolderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BackupFolderTextBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupFolderTextBox.Location = new Point(14, 136);
            BackupFolderTextBox.Margin = new Padding(2);
            BackupFolderTextBox.Name = "BackupFolderTextBox";
            BackupFolderTextBox.Size = new Size(583, 22);
            BackupFolderTextBox.TabIndex = 17;
            BackupFolderTextBox.Click += BackupFolderTextBox_Click;
            // 
            // LoadAutosaveButton
            // 
            LoadAutosaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LoadAutosaveButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoadAutosaveButton.Location = new Point(348, 510);
            LoadAutosaveButton.Name = "LoadAutosaveButton";
            LoadAutosaveButton.Size = new Size(122, 32);
            LoadAutosaveButton.TabIndex = 18;
            LoadAutosaveButton.Text = "Load Autosave...";
            LoadAutosaveButton.UseVisualStyleBackColor = true;
            LoadAutosaveButton.Click += LoadAutosaveButton_Click;
            // 
            // AutosaveIntervalLabel
            // 
            AutosaveIntervalLabel.AutoSize = true;
            AutosaveIntervalLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutosaveIntervalLabel.Location = new Point(176, 179);
            AutosaveIntervalLabel.Margin = new Padding(2, 0, 2, 0);
            AutosaveIntervalLabel.Name = "AutosaveIntervalLabel";
            AutosaveIntervalLabel.Size = new Size(71, 17);
            AutosaveIntervalLabel.TabIndex = 20;
            AutosaveIntervalLabel.Text = "10 minutes";
            AutosaveIntervalLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // AutosaveIntervalTrackBar
            // 
            AutosaveIntervalTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AutosaveIntervalTrackBar.Location = new Point(14, 198);
            AutosaveIntervalTrackBar.Margin = new Padding(2);
            AutosaveIntervalTrackBar.Maximum = 60;
            AutosaveIntervalTrackBar.Minimum = 1;
            AutosaveIntervalTrackBar.Name = "AutosaveIntervalTrackBar";
            AutosaveIntervalTrackBar.Size = new Size(583, 45);
            AutosaveIntervalTrackBar.TabIndex = 19;
            AutosaveIntervalTrackBar.Value = 10;
            // 
            // BG3StoryIdLabel
            // 
            BG3StoryIdLabel.AutoSize = true;
            BG3StoryIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            BG3StoryIdLabel.ForeColor = SystemColors.ControlDark;
            BG3StoryIdLabel.Location = new Point(14, 100);
            BG3StoryIdLabel.Name = "BG3StoryIdLabel";
            BG3StoryIdLabel.Size = new Size(46, 17);
            BG3StoryIdLabel.TabIndex = 22;
            BG3StoryIdLabel.Text = "StoryId";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(14, 179);
            label6.Name = "label6";
            label6.Size = new Size(157, 17);
            label6.TabIndex = 23;
            label6.Text = "Frequency of Autosaves:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(14, 229);
            label7.Name = "label7";
            label7.Size = new Size(144, 17);
            label7.TabIndex = 24;
            label7.Text = "Number of Autosaves:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(14, 302);
            label9.Name = "label9";
            label9.Size = new Size(161, 17);
            label9.TabIndex = 26;
            label9.Text = "Time until next autosave:";
            // 
            // CountdownLabel
            // 
            CountdownLabel.AutoSize = true;
            CountdownLabel.Location = new Point(176, 302);
            CountdownLabel.Name = "CountdownLabel";
            CountdownLabel.Size = new Size(39, 17);
            CountdownLabel.TabIndex = 27;
            CountdownLabel.Text = "10:00";
            // 
            // BackupNowButton
            // 
            BackupNowButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BackupNowButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupNowButton.Location = new Point(140, 510);
            BackupNowButton.Name = "BackupNowButton";
            BackupNowButton.Size = new Size(122, 32);
            BackupNowButton.TabIndex = 28;
            BackupNowButton.Text = "Backup Now";
            BackupNowButton.UseVisualStyleBackColor = true;
            BackupNowButton.Click += BackupNowButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(610, 554);
            Controls.Add(BackupNowButton);
            Controls.Add(CountdownLabel);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(BG3StoryIdLabel);
            Controls.Add(DisableButton);
            Controls.Add(LoadAutosaveButton);
            Controls.Add(EnableButton);
            Controls.Add(LogHeaderLabel);
            Controls.Add(LogTextBox);
            Controls.Add(AutosaveLimitLabel);
            Controls.Add(AutosaveLimitTrackBar);
            Controls.Add(AutosaveIntervalLabel);
            Controls.Add(AutosaveIntervalTrackBar);
            Controls.Add(BackupFolderTextBox);
            Controls.Add(BG3SaveFolderTextBox);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label10);
            Controls.Add(FormHeaderLabel);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "MainForm";
            Text = "Baulder's Gate 3: Honour Mode Autosave Manager";
            ((System.ComponentModel.ISupportInitialize)AutosaveLimitTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)AutosaveIntervalTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EnableButton;
        private Button DisableButton;
        private TextBox LogTextBox;
        private Label FormHeaderLabel;
        private Label LogHeaderLabel;
        private TrackBar AutosaveLimitTrackBar;
        private Label AutosaveLimitLabel;
        private Label label1;
        private Label label10;
        private Label label4;
        private TextBox BG3SaveFolderTextBox;
        private TextBox BackupFolderTextBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button LoadAutosaveButton;
        private Label AutosaveIntervalLabel;
        private TrackBar AutosaveIntervalTrackBar;
        private Label BG3StoryIdLabel;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label CountdownLabel;
        private Button BackupNowButton;
    }
}
