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
            AutosaveEnableButton = new Button();
            AutosaveDisableButton = new Button();
            LogTextBox = new TextBox();
            FormHeaderLabel = new Label();
            LogHeaderLabel = new Label();
            AutosaveLimitTrackBar = new TrackBar();
            AutosaveLimitLabel = new Label();
            label10 = new Label();
            label1 = new Label();
            label4 = new Label();
            BackupFolderTextBox = new TextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            AutosaveLoadButton = new Button();
            AutosaveIntervalLabel = new Label();
            AutosaveIntervalTrackBar = new TrackBar();
            BG3StoryIdLabel = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            CountdownLabel = new Label();
            QuickSaveButton = new Button();
            SaveTabControl = new TabControl();
            AutosaveTabPage = new TabPage();
            AutosaveDeleteButton = new Button();
            QuicksaveTabPage = new TabPage();
            label2 = new Label();
            QuickLimitTrackBar = new TrackBar();
            QuickLimitLabel = new Label();
            QuickLoadButton = new Button();
            QuickDeleteButton = new Button();
            profilesComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)AutosaveLimitTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AutosaveIntervalTrackBar).BeginInit();
            SaveTabControl.SuspendLayout();
            AutosaveTabPage.SuspendLayout();
            QuicksaveTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuickLimitTrackBar).BeginInit();
            SuspendLayout();
            // 
            // AutosaveEnableButton
            // 
            AutosaveEnableButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutosaveEnableButton.Location = new Point(6, 145);
            AutosaveEnableButton.Name = "AutosaveEnableButton";
            AutosaveEnableButton.Size = new Size(122, 32);
            AutosaveEnableButton.TabIndex = 0;
            AutosaveEnableButton.Text = "Enable";
            AutosaveEnableButton.UseVisualStyleBackColor = true;
            AutosaveEnableButton.Click += AutosaveEnableButton_Click;
            // 
            // AutosaveDisableButton
            // 
            AutosaveDisableButton.Enabled = false;
            AutosaveDisableButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutosaveDisableButton.Location = new Point(134, 145);
            AutosaveDisableButton.Name = "AutosaveDisableButton";
            AutosaveDisableButton.Size = new Size(122, 32);
            AutosaveDisableButton.TabIndex = 1;
            AutosaveDisableButton.Text = "Disable";
            AutosaveDisableButton.UseVisualStyleBackColor = true;
            AutosaveDisableButton.Click += AutosaveDisableButton_Click;
            // 
            // LogTextBox
            // 
            LogTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LogTextBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LogTextBox.Location = new Point(11, 426);
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.ScrollBars = ScrollBars.Both;
            LogTextBox.Size = new Size(587, 149);
            LogTextBox.TabIndex = 2;
            LogTextBox.WordWrap = false;
            // 
            // FormHeaderLabel
            // 
            FormHeaderLabel.AutoSize = true;
            FormHeaderLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormHeaderLabel.Location = new Point(12, 9);
            FormHeaderLabel.Name = "FormHeaderLabel";
            FormHeaderLabel.Size = new Size(358, 21);
            FormHeaderLabel.TabIndex = 3;
            FormHeaderLabel.Text = "Baulder's Gate 3: Honour Mode Save Manager";
            // 
            // LogHeaderLabel
            // 
            LogHeaderLabel.AutoSize = true;
            LogHeaderLabel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogHeaderLabel.Location = new Point(11, 406);
            LogHeaderLabel.Name = "LogHeaderLabel";
            LogHeaderLabel.Size = new Size(84, 17);
            LogHeaderLabel.TabIndex = 4;
            LogHeaderLabel.Text = "Log Window";
            // 
            // AutosaveLimitTrackBar
            // 
            AutosaveLimitTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AutosaveLimitTrackBar.BackColor = SystemColors.Control;
            AutosaveLimitTrackBar.Location = new Point(6, 87);
            AutosaveLimitTrackBar.Margin = new Padding(2);
            AutosaveLimitTrackBar.Maximum = 50;
            AutosaveLimitTrackBar.Minimum = 1;
            AutosaveLimitTrackBar.Name = "AutosaveLimitTrackBar";
            AutosaveLimitTrackBar.Size = new Size(556, 45);
            AutosaveLimitTrackBar.TabIndex = 5;
            AutosaveLimitTrackBar.Value = 20;
            // 
            // AutosaveLimitLabel
            // 
            AutosaveLimitLabel.AutoSize = true;
            AutosaveLimitLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutosaveLimitLabel.Location = new Point(168, 70);
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
            label10.Location = new Point(14, 96);
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
            label1.Location = new Point(14, 137);
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
            label4.Location = new Point(14, 46);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(106, 17);
            label4.TabIndex = 14;
            label4.Text = "BG3 Save Folder";
            // 
            // BackupFolderTextBox
            // 
            BackupFolderTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BackupFolderTextBox.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackupFolderTextBox.Location = new Point(14, 156);
            BackupFolderTextBox.Margin = new Padding(2);
            BackupFolderTextBox.Name = "BackupFolderTextBox";
            BackupFolderTextBox.Size = new Size(578, 22);
            BackupFolderTextBox.TabIndex = 17;
            BackupFolderTextBox.Click += BackupFolderTextBox_Click;
            // 
            // AutosaveLoadButton
            // 
            AutosaveLoadButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AutosaveLoadButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutosaveLoadButton.Location = new Point(312, 145);
            AutosaveLoadButton.Name = "AutosaveLoadButton";
            AutosaveLoadButton.Size = new Size(122, 32);
            AutosaveLoadButton.TabIndex = 18;
            AutosaveLoadButton.Text = "Load";
            AutosaveLoadButton.UseVisualStyleBackColor = true;
            AutosaveLoadButton.Click += LoadAutosaveButton_Click;
            // 
            // AutosaveIntervalLabel
            // 
            AutosaveIntervalLabel.AutoSize = true;
            AutosaveIntervalLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutosaveIntervalLabel.Location = new Point(168, 3);
            AutosaveIntervalLabel.Margin = new Padding(2, 0, 2, 0);
            AutosaveIntervalLabel.Name = "AutosaveIntervalLabel";
            AutosaveIntervalLabel.Size = new Size(71, 17);
            AutosaveIntervalLabel.TabIndex = 20;
            AutosaveIntervalLabel.Text = "15 minutes";
            AutosaveIntervalLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // AutosaveIntervalTrackBar
            // 
            AutosaveIntervalTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AutosaveIntervalTrackBar.Location = new Point(6, 22);
            AutosaveIntervalTrackBar.Margin = new Padding(2);
            AutosaveIntervalTrackBar.Maximum = 60;
            AutosaveIntervalTrackBar.Minimum = 1;
            AutosaveIntervalTrackBar.Name = "AutosaveIntervalTrackBar";
            AutosaveIntervalTrackBar.Size = new Size(556, 45);
            AutosaveIntervalTrackBar.TabIndex = 19;
            AutosaveIntervalTrackBar.Value = 15;
            // 
            // BG3StoryIdLabel
            // 
            BG3StoryIdLabel.AutoSize = true;
            BG3StoryIdLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            BG3StoryIdLabel.ForeColor = SystemColors.ControlDark;
            BG3StoryIdLabel.Location = new Point(14, 113);
            BG3StoryIdLabel.Name = "BG3StoryIdLabel";
            BG3StoryIdLabel.Size = new Size(46, 17);
            BG3StoryIdLabel.TabIndex = 22;
            BG3StoryIdLabel.Text = "StoryId";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 3);
            label6.Name = "label6";
            label6.Size = new Size(157, 17);
            label6.TabIndex = 23;
            label6.Text = "Frequency of Autosaves:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(6, 70);
            label7.Name = "label7";
            label7.Size = new Size(144, 17);
            label7.TabIndex = 24;
            label7.Text = "Number of Autosaves:";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(351, 3);
            label9.Name = "label9";
            label9.Size = new Size(161, 17);
            label9.TabIndex = 26;
            label9.Text = "Time until next autosave:";
            // 
            // CountdownLabel
            // 
            CountdownLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CountdownLabel.AutoSize = true;
            CountdownLabel.Location = new Point(513, 3);
            CountdownLabel.Name = "CountdownLabel";
            CountdownLabel.Size = new Size(49, 17);
            CountdownLabel.TabIndex = 27;
            CountdownLabel.Text = "0:15:00";
            CountdownLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // QuickSaveButton
            // 
            QuickSaveButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QuickSaveButton.Location = new Point(6, 145);
            QuickSaveButton.Name = "QuickSaveButton";
            QuickSaveButton.Size = new Size(122, 32);
            QuickSaveButton.TabIndex = 28;
            QuickSaveButton.Text = "Save";
            QuickSaveButton.UseVisualStyleBackColor = true;
            QuickSaveButton.Click += QuickSaveButton_Click;
            // 
            // SaveTabControl
            // 
            SaveTabControl.Controls.Add(AutosaveTabPage);
            SaveTabControl.Controls.Add(QuicksaveTabPage);
            SaveTabControl.Location = new Point(15, 190);
            SaveTabControl.Name = "SaveTabControl";
            SaveTabControl.SelectedIndex = 0;
            SaveTabControl.Size = new Size(577, 213);
            SaveTabControl.TabIndex = 30;
            // 
            // AutosaveTabPage
            // 
            AutosaveTabPage.Controls.Add(AutosaveDeleteButton);
            AutosaveTabPage.Controls.Add(CountdownLabel);
            AutosaveTabPage.Controls.Add(AutosaveEnableButton);
            AutosaveTabPage.Controls.Add(label9);
            AutosaveTabPage.Controls.Add(AutosaveLoadButton);
            AutosaveTabPage.Controls.Add(label7);
            AutosaveTabPage.Controls.Add(AutosaveDisableButton);
            AutosaveTabPage.Controls.Add(label6);
            AutosaveTabPage.Controls.Add(AutosaveIntervalLabel);
            AutosaveTabPage.Controls.Add(AutosaveLimitTrackBar);
            AutosaveTabPage.Controls.Add(AutosaveLimitLabel);
            AutosaveTabPage.Controls.Add(AutosaveIntervalTrackBar);
            AutosaveTabPage.Location = new Point(4, 26);
            AutosaveTabPage.Name = "AutosaveTabPage";
            AutosaveTabPage.Padding = new Padding(3);
            AutosaveTabPage.Size = new Size(569, 183);
            AutosaveTabPage.TabIndex = 0;
            AutosaveTabPage.Text = "Autosave";
            AutosaveTabPage.UseVisualStyleBackColor = true;
            // 
            // AutosaveDeleteButton
            // 
            AutosaveDeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AutosaveDeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AutosaveDeleteButton.Location = new Point(440, 145);
            AutosaveDeleteButton.Name = "AutosaveDeleteButton";
            AutosaveDeleteButton.Size = new Size(122, 32);
            AutosaveDeleteButton.TabIndex = 19;
            AutosaveDeleteButton.Text = "Delete";
            AutosaveDeleteButton.UseVisualStyleBackColor = true;
            AutosaveDeleteButton.Click += AutosaveDeleteButton_Click;
            // 
            // QuicksaveTabPage
            // 
            QuicksaveTabPage.Controls.Add(label2);
            QuicksaveTabPage.Controls.Add(QuickLimitTrackBar);
            QuicksaveTabPage.Controls.Add(QuickLimitLabel);
            QuicksaveTabPage.Controls.Add(QuickLoadButton);
            QuicksaveTabPage.Controls.Add(QuickDeleteButton);
            QuicksaveTabPage.Controls.Add(QuickSaveButton);
            QuicksaveTabPage.Location = new Point(4, 24);
            QuicksaveTabPage.Name = "QuicksaveTabPage";
            QuicksaveTabPage.Padding = new Padding(3);
            QuicksaveTabPage.Size = new Size(569, 185);
            QuicksaveTabPage.TabIndex = 1;
            QuicksaveTabPage.Text = "Quicksave";
            QuicksaveTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 3);
            label2.Name = "label2";
            label2.Size = new Size(148, 17);
            label2.TabIndex = 33;
            label2.Text = "Number of Quicksaves:";
            // 
            // QuickLimitTrackBar
            // 
            QuickLimitTrackBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            QuickLimitTrackBar.BackColor = SystemColors.Control;
            QuickLimitTrackBar.Location = new Point(6, 20);
            QuickLimitTrackBar.Margin = new Padding(2);
            QuickLimitTrackBar.Maximum = 50;
            QuickLimitTrackBar.Minimum = 1;
            QuickLimitTrackBar.Name = "QuickLimitTrackBar";
            QuickLimitTrackBar.Size = new Size(556, 45);
            QuickLimitTrackBar.TabIndex = 31;
            QuickLimitTrackBar.Value = 10;
            // 
            // QuickLimitLabel
            // 
            QuickLimitLabel.AutoSize = true;
            QuickLimitLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QuickLimitLabel.Location = new Point(168, 3);
            QuickLimitLabel.Margin = new Padding(2, 0, 2, 0);
            QuickLimitLabel.Name = "QuickLimitLabel";
            QuickLimitLabel.Size = new Size(22, 17);
            QuickLimitLabel.TabIndex = 32;
            QuickLimitLabel.Text = "10";
            QuickLimitLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // QuickLoadButton
            // 
            QuickLoadButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            QuickLoadButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QuickLoadButton.Location = new Point(312, 145);
            QuickLoadButton.Name = "QuickLoadButton";
            QuickLoadButton.Size = new Size(122, 32);
            QuickLoadButton.TabIndex = 30;
            QuickLoadButton.Text = "Load";
            QuickLoadButton.UseVisualStyleBackColor = true;
            QuickLoadButton.Click += QuickLoadButton_Click;
            // 
            // QuickDeleteButton
            // 
            QuickDeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            QuickDeleteButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QuickDeleteButton.Location = new Point(440, 145);
            QuickDeleteButton.Name = "QuickDeleteButton";
            QuickDeleteButton.Size = new Size(122, 32);
            QuickDeleteButton.TabIndex = 29;
            QuickDeleteButton.Text = "Delete";
            QuickDeleteButton.UseVisualStyleBackColor = true;
            QuickDeleteButton.Click += QuickDeleteButton_Click;
            // 
            // profilesComboBox
            // 
            profilesComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            profilesComboBox.FormattingEnabled = true;
            profilesComboBox.Location = new Point(14, 65);
            profilesComboBox.MaxDropDownItems = 20;
            profilesComboBox.Name = "profilesComboBox";
            profilesComboBox.Size = new Size(578, 25);
            profilesComboBox.TabIndex = 31;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(610, 584);
            Controls.Add(SaveTabControl);
            Controls.Add(BG3StoryIdLabel);
            Controls.Add(LogHeaderLabel);
            Controls.Add(LogTextBox);
            Controls.Add(BackupFolderTextBox);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label10);
            Controls.Add(FormHeaderLabel);
            Controls.Add(profilesComboBox);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "MainForm";
            Text = "Baulder's Gate 3: Honour Mode Save Manager";
            ((System.ComponentModel.ISupportInitialize)AutosaveLimitTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)AutosaveIntervalTrackBar).EndInit();
            SaveTabControl.ResumeLayout(false);
            AutosaveTabPage.ResumeLayout(false);
            AutosaveTabPage.PerformLayout();
            QuicksaveTabPage.ResumeLayout(false);
            QuicksaveTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)QuickLimitTrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AutosaveEnableButton;
        private Button AutosaveDisableButton;
        private TextBox LogTextBox;
        private Label FormHeaderLabel;
        private Label LogHeaderLabel;
        private TrackBar AutosaveLimitTrackBar;
        private Label AutosaveLimitLabel;
        private Label label1;
        private Label label10;
        private Label label4;
        private TextBox BackupFolderTextBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button AutosaveLoadButton;
        private Label AutosaveIntervalLabel;
        private TrackBar AutosaveIntervalTrackBar;
        private Label BG3StoryIdLabel;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label CountdownLabel;
        private Button QuickSaveButton;
        private TabControl SaveTabControl;
        private TabPage AutosaveTabPage;
        private TabPage QuicksaveTabPage;
        private Button AutosaveDeleteButton;
        private Button QuickLoadButton;
        private Button QuickDeleteButton;
        private Label label2;
        private TrackBar QuickLimitTrackBar;
        private Label QuickLimitLabel;
        private ComboBox profilesComboBox;
    }
}
