using System.IO.Compression;

namespace BG3_Autosave_Manager
{
    public partial class MainForm : Form
    {
        private TimerPlus timerplus;
        private const int INTERVAL = 1000; // Timer interval in milliseconds
        private int lineCount = 0; // Counter for the number of lines in the log text box

        private string bg3SaveFolder = Properties.Settings.Default.BG3SaveFolder;
        private string backupFolder = Properties.Settings.Default.BackupFolder;
        private string storyId = Properties.Settings.Default.BG3StoryId;
        private int autosaveInterval = Properties.Settings.Default.AutosaveInterval;
        private int autosaveLimit = Properties.Settings.Default.AutosaveLimit;

        public MainForm()
        {
            // This call is required by the designer.
            InitializeComponent();

            // Initialize the timer
            timerplus = new TimerPlus(INTERVAL, autosaveInterval * 60);
            timerplus.Tick += TimerTick;

            // Add any initialization after the InitializeComponent() call.
            BG3SaveFolderTextBox.Text = bg3SaveFolder;
            BG3StoryIdLabel.Text = storyId;
            BackupFolderTextBox.Text = backupFolder;
            AutosaveIntervalTrackBar.Value = autosaveInterval;
            AutosaveIntervalLabel.Text = $"{autosaveInterval} minutes";
            AutosaveLimitTrackBar.Value = autosaveLimit;
            AutosaveLimitLabel.Text = autosaveLimit.ToString();

            SendToLog($"Autosave Manager started.");
            SendToLog($"Autosave folder: {bg3SaveFolder}");
            SendToLog($"Story ID: {storyId}");
            SendToLog($"Backup folder: {backupFolder}");
            SendToLog($"Autosave interval set to {autosaveInterval} minutes.");
            SendToLog($"Autosave limit set to {autosaveLimit} files.");
            SendToLog($"Autosave Manager is ready.");

            AutosaveIntervalTrackBar.Scroll += new EventHandler(AutosaveIntervalTrackBar_Scroll);
            AutosaveIntervalTrackBar.ValueChanged += new EventHandler(AutosaveIntervalTrackBar_ValueChanged);
            AutosaveLimitTrackBar.Scroll += new EventHandler(AutosaveLimitTrackBar_Scroll);
            AutosaveLimitTrackBar.ValueChanged += new EventHandler(AutosaveLimitTrackBar_ValueChanged);

            AutosaveIntervalTrackBar_ValueChanged(this, EventArgs.Empty);
            AutosaveLimitTrackBar_ValueChanged(this, EventArgs.Empty);

            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }
        private void AutosaveIntervalTrackBar_Scroll(object? sender, EventArgs e)
        {
            // Update the label with the current value of the trackbar
            autosaveInterval = AutosaveIntervalTrackBar.Value;
            AutosaveIntervalLabel.Text = $"{autosaveInterval} minutes";
            Properties.Settings.Default.AutosaveInterval = autosaveInterval;
        }
        private void AutosaveIntervalTrackBar_ValueChanged(object? sender, EventArgs e)
        {
            int duration = AutosaveIntervalTrackBar.Value;
            TimeSpan timeSpan = TimeSpan.FromMinutes(duration);

            timerplus.RemainingTime = duration * 60; // Set the timer duration in seconds

            CountdownLabel.Text = timeSpan.ToString(@"h\:mm\:ss");
            timerplus.Duration = duration * 60; // Set the timer duration in seconds

            // Log the new duration
            SendToLog($"Autosave interval changed to {duration} minutes.");
        }
        private void AutosaveLimitTrackBar_Scroll(object? sender, EventArgs e)
        {
            // Update the label with the current value of the trackbar
            autosaveLimit = AutosaveLimitTrackBar.Value;
            AutosaveLimitLabel.Text = autosaveLimit.ToString();
            Properties.Settings.Default.AutosaveLimit = autosaveLimit;
        }
        private void AutosaveLimitTrackBar_ValueChanged(object? sender, EventArgs e)
        {
            // Update the label with the current value of the trackbar
            autosaveLimit = AutosaveLimitTrackBar.Value;
            AutosaveLimitLabel.Text = autosaveLimit.ToString();
            Properties.Settings.Default.AutosaveLimit = autosaveLimit;

            // Log the new limit
            SendToLog($"Autosave limit changed to {autosaveLimit} files.");
        }
        private Boolean ValidateInputs()
        {
            // Validate the inputs for the save folder, story ID, and backup folder
            if (string.IsNullOrEmpty(BG3SaveFolderTextBox.Text))
            {
                MessageBox.Show("Please select a valid save folder.");
                return false;
            }
            if (string.IsNullOrEmpty(BackupFolderTextBox.Text))
            {
                MessageBox.Show("Please select a valid backup folder.");
                return false;
            }
            return true;
        }
        private void EnableButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; // Validate inputs before proceeding

            // Disable the enable button and enable the disable button  
            EnableButton.Enabled = false;
            DisableButton.Enabled = true;

            CleanBackupFolder(); // Call the method to clean up the backup folder

            timerplus.Start();

            SendToLog($"Autosave timer started.");
        }
        private void FolderExists(string folderPath)
        {
            // Check if the backup folder exists and create it if it doesn't
            if (!System.IO.Directory.Exists(folderPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                    SendToLog($"Created backup folder.");
                }
                catch (Exception ex)
                {
                    SendToLog($"Error creating backup folder: {ex.Message}");
                }
            }
        }
        private void DeleteExcessFilesInFolder(List<FileInfo> files, int fileLimit)
        {
            // Check if the number of files exceeds the limit
            if (files.Count > fileLimit)
            {
                // Delete the oldest files
                for (int i = 0; i < files.Count - fileLimit; i++)
                {
                    try
                    {
                        files[i].Delete();
                        SendToLog($"Deleted: {files[i].FullName}");
                    }
                    catch (Exception ex)
                    {
                        SendToLog($"Error deleting file: {ex.Message}");
                    }
                }
            }
            else
            {
                // Log that there are no files to delete
                SendToLog($"No files to delete. Current count: {files.Count}, Limit: {autosaveLimit}.");
            }
        }
        private void CleanBackupFolder(int extraFilesToDelete = 0)
        {
            string backupStoryFolder = System.IO.Path.Combine(backupFolder, storyId);

            // Check if the backup folder exists and create it if it doesn't
            FolderExists(backupStoryFolder);

            // Get the list of files in the backup folder
            var files = new DirectoryInfo(backupStoryFolder).GetFiles()
                .OrderBy(f => f.CreationTime)
                .ToList();
            // Log the number of files found
            SendToLog($"Backup folder contains {files.Count} saves.");

            // Check if the number of files exceeds the limit
            DeleteExcessFilesInFolder(files, autosaveLimit - extraFilesToDelete);
        }
        private void TimerTick(object? sender, EventArgs e)
        {
            int remainingTime = timerplus.RemainingTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(remainingTime);

            if (remainingTime <= 0)
            {
                // Reset timer.
                timerplus.Stop();
                timerplus.RemainingTime = timerplus.Duration;
                WriteAutosave(); // Call the method to write autosave
                timerplus.Start();
            }

            // Log the remaining time.
            CountdownLabel.Text = timeSpan.ToString(@"h\:mm\:ss");
        }
        public static void CreateZipFromFiles(List<FileInfo> files, string zipPath)
        {
            using FileStream zipToOpen = new(zipPath, FileMode.Create);
            using ZipArchive archive = new(zipToOpen, ZipArchiveMode.Create);

            foreach (FileInfo file in files)
            {
                ZipArchiveEntry entry = archive.CreateEntry(file.Name);
                using Stream entryStream = entry.Open();
                using FileStream fileStream = file.OpenRead();
                fileStream.CopyTo(entryStream);
            }
        }
        private void WriteAutosave()
        {
            // Get the current date and time
            DateTime now = DateTime.Now;
            // Format the date and time as a string
            string formattedDateTime = now.ToString("yyyy-MM-dd_HH-mm-ss");
            string fileName = "autosave_" + formattedDateTime + ".zip";
            string zipPath = System.IO.Path.Combine(backupFolder, storyId, fileName);

            // Simplified collection initialization in CleanBackupFolder
            var files = new DirectoryInfo(bg3SaveFolder).GetFiles()
                .OrderBy(f => f.CreationTime)
                .ToList();
            
            if (files.Count > 0)
            {
                // Check if the backup folder exists and create it if it doesn't.
                // Also free up one extra file if autosaves already at limit.
                CleanBackupFolder(1);

                // Create a zip file from the files in the autosave folder
                CreateZipFromFiles(files, zipPath);
                SendToLog($"Backup created.");
            }
        }
        private void DisableButton_Click(object sender, EventArgs e)
        {
            // Disable the disable button and enable the enable button  
            DisableButton.Enabled = false;
            EnableButton.Enabled = true;

            timerplus.Stop();
        }
        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Stop the timer if the form is closing
            if (timerplus != null)
            {
                timerplus.Stop();
                timerplus.Tick -= TimerTick;
                timerplus.Dispose();
                timerplus = null!;
            }

            Properties.Settings.Default.Save(); // Save the settings when the form is closing
        }
        private void BG3SaveFolderTextBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Set the folder path to the text box.
                bg3SaveFolder = folderDialog.SelectedPath;
                BG3SaveFolderTextBox.Text = bg3SaveFolder;
                Properties.Settings.Default.BG3SaveFolder = bg3SaveFolder;

                storyId = Path.GetFileName(bg3SaveFolder);
                BG3StoryIdLabel.Text = storyId;
                Properties.Settings.Default.BG3StoryId = storyId;
                
                SendToLog($"BG3 Save Folder: {bg3SaveFolder}");
                SendToLog($"Story ID: {storyId}");
            }
        }
        private void BackupFolderTextBox_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new();
            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Set the folder path to the text box.
                backupFolder = folderDialog.SelectedPath;
                BackupFolderTextBox.Text = backupFolder;
                Properties.Settings.Default.BackupFolder = backupFolder;

                SendToLog($"Backup Folder: {backupFolder}");
            }
        }
        private void UnzipArchive(string zipFilePath, string extractFolderPath)
        {
            try
            {
                // Ensure the extraction folder exists
                if (!Directory.Exists(extractFolderPath))
                {
                    Directory.CreateDirectory(extractFolderPath);
                }

                // Extract the contents of the zip file
                ZipFile.ExtractToDirectory(zipFilePath, extractFolderPath, overwriteFiles: true);
                SendToLog($"Successfully extracted archive.");
            }
            catch (Exception ex)
            {
                // Log any errors that occur during extraction
                SendToLog($"Error extracting archive: {ex.Message}");
            }
        }
        private void LoadAutosaveButton_Click(object sender, EventArgs e)
        {
            string backupStoryFolder = System.IO.Path.Combine(backupFolder, storyId);

            DisableButton_Click(sender, e); // Disable the timer

            // Check if the backup folder exists
            if (!System.IO.Directory.Exists(backupStoryFolder))
            {
                MessageBox.Show("Backup folder does not exist.");
                return;
            }

            // Get the list of zip files in the backup folder
            var zipFiles = new DirectoryInfo(backupStoryFolder).GetFiles("*.zip")
                .OrderByDescending(f => f.CreationTime)
                .ToList();
            SendToLog($"Found {zipFiles.Count} backup files, sending file list to listbox.");

            if (zipFiles.Count > 0)
            {
                Panel zipPanel = new();
                Button loadButton = new();
                Button cancelButton = new();
                ListBox zipListBox = new();
                Label zipLabel = new();

                zipListBox.Name = "zipListBox";
                zipListBox.Dock = DockStyle.Fill;
                zipListBox.TabIndex = 0;
                zipListBox.Sorted = true;

                loadButton.Name = "loadButton";
                loadButton.Size = new System.Drawing.Size(260, 30);
                loadButton.TabIndex = 1;
                loadButton.Dock = DockStyle.Bottom;
                loadButton.Text = "Load Selected Autosave";

                cancelButton.Name = "cancelButton";
                cancelButton.Size = new System.Drawing.Size(260, 30);
                cancelButton.TabIndex = 2;
                cancelButton.Dock = DockStyle.Bottom;
                cancelButton.Text = "Cancel";
                cancelButton.Click += (s, e) =>
                {
                    zipPanel.Visible = false;
                    zipPanel.Dispose();
                };

                foreach (FileInfo file in zipFiles)
                {
                    zipListBox.Items.Add(file.Name);
                }
                zipListBox.SelectedIndex = zipFiles.Count - 1; // Select the first item by default

                loadButton.Click += (s, e) =>
                {
                    if (zipListBox.SelectedItem != null)
                    {
                        if (zipListBox.SelectedItem != null)
                        {
                            string selectedFile = zipListBox.SelectedItem?.ToString() ?? string.Empty;
                            zipLabel.Text = "Selected File: " + selectedFile;
                            string selectedFilePath = Path.Combine(backupStoryFolder, selectedFile);

                            // Load the selected autosave file
                            UnzipArchive(selectedFilePath, bg3SaveFolder);
                            SendToLog($"Autosave restored.");

                            zipPanel.Visible = false;
                            zipPanel.Dispose();

                            if (timerplus.IsRunning)
                            {
                                EnableButton_Click(sender, e); // Re-enable the timer
                            }
                        }
                    }
                };

                this.Controls.Add(zipPanel);

                zipPanel.Name = "zipPanel";
                zipPanel.Dock = DockStyle.Fill;
                zipPanel.BorderStyle = BorderStyle.FixedSingle;
                zipPanel.BackColor = System.Drawing.Color.LightGray;
                zipPanel.Controls.AddRange([zipListBox, loadButton, cancelButton, zipLabel]);
                zipPanel.BringToFront();
                zipPanel.Focus();
                zipPanel.Select();
            }
            else
            {
                MessageBox.Show("No backups found.");
            }
        }
        private void SendToLog(string message)
        {
            // Get the current DateTime
            DateTime dt = DateTime.Now;
            // Format DateTime with Message as a String.
            string logEntry = $"[{dt:yyyy-MM-dd HH:mm:ss}] {message}";

            // Append the log entry to the log text box
            // Use a lock to ensure thread safety when updating the UI
            if (LogTextBox.InvokeRequired)
            {
                LogTextBox.Invoke(new Action(() =>
                {
                    LogTextBox.AppendText(logEntry + Environment.NewLine);
                }));
            }
            else
            {
                LogTextBox.AppendText(logEntry + Environment.NewLine);
            }

            if (++lineCount > 100)
            {
                LogTextBox.Clear();
                lineCount = 0;
            }
        }
        private void BackupNowButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; // Validate inputs before proceeding

            Boolean resume = false;

            // Reset timer.
            if (timerplus.IsRunning)
            {
                timerplus.Stop();
                resume = true;
                SendToLog($"Autosave Manager paused.");
            }

            timerplus.RemainingTime = timerplus.Duration;
            WriteAutosave(); // Call the method to write autosave

            // Re-enable the timer if it was running before
            if (resume)
            {
                timerplus.Start();
                SendToLog($"Autosave Manager resumed.");
            }
        }
    }
}