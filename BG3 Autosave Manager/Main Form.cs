using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

namespace BG3_Autosave_Manager
{
    public partial class MainForm : Form
    {
        private const string AUTOSAVE_PREFIX = "autosave_";
        private const string QUICKSAVE_PREFIX = "quicksave_";
        private const string DATETIME_PATTERN = "yyyy-MM-dd_HH-mm-ss"; // Example pattern: YYYY-MM-DD_HH-MM-SS.
        private const string SAVE_EXT = ".zip";
        private const string COUNTDOWN_PATTERN = @"h\:mm\:ss";
        private const string BG3_SAVE_FOLDER = @"Larian Studios\Baldur's Gate 3\PlayerProfiles\Public\Savegames\Story";
        private static readonly string LOCALAPPDATA = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private TimerPlus timerplus = null!; // TimerPlus instance for managing the timer.
        private const int INTERVAL = 1000; // Timer interval in milliseconds.
        private int lineCount = 0; // Counter for the number of lines in the log text box.

        private string bg3SaveFolder = Properties.Settings.Default.BG3SaveFolder;
        private string backupFolder = Properties.Settings.Default.BackupFolder;
        private string storyId = Properties.Settings.Default.BG3StoryId;
        private int autosaveInterval = Properties.Settings.Default.AutosaveInterval;
        private int autosaveLimit = Properties.Settings.Default.AutosaveLimit;
        private int quickLimit = Properties.Settings.Default.QuickLimit;

        public MainForm()
        {
            // Load the certificate from the store
            //Boolean isValid = LoadCertificate("2f788e39e7a597c134ce4e5165a20feb32ca0e63");
            //if (!isValid) return;

            // This call is required by the designer.
            InitializeComponent();
            PopulatePofilesComboBox();

            // Initialize the timer.
            timerplus = new TimerPlus(INTERVAL, autosaveInterval * 60);
            timerplus.Tick += TimerTick;

            // Add any initialization after the InitializeComponent() call.
            BG3StoryIdLabel.Text = storyId;
            BackupFolderTextBox.Text = backupFolder;
            AutosaveIntervalTrackBar.Value = autosaveInterval;
            AutosaveIntervalLabel.Text = $"{autosaveInterval} minutes";
            AutosaveLimitTrackBar.Value = autosaveLimit;
            AutosaveLimitLabel.Text = autosaveLimit.ToString();
            QuickLimitTrackBar.Value = quickLimit;
            QuickLimitLabel.Text = quickLimit.ToString();
            CountdownLabel.Text = FormatTime(timerplus.RemainingTime, COUNTDOWN_PATTERN);

            SendToLog($"Autosave Manager started.");
            SendToLog($"Story ID: {storyId}");
            SendToLog($"Backup folder: {backupFolder}");
            SendToLog($"Autosave interval set to {autosaveInterval} minutes.");
            SendToLog($"Autosave limit set to {autosaveLimit} files.");
            SendToLog($"Autosave Manager is ready.");

            AutosaveIntervalTrackBar.Scroll += new EventHandler(AutosaveIntervalTrackBar_Scroll);
            AutosaveIntervalTrackBar.ValueChanged += new EventHandler(AutosaveIntervalTrackBar_ValueChanged);
            AutosaveLimitTrackBar.Scroll += new EventHandler(AutosaveLimitTrackBar_ValueChanged);
            AutosaveLimitTrackBar.ValueChanged += new EventHandler(AutosaveLimitTrackBar_ValueChanged);
            QuickLimitTrackBar.Scroll += new EventHandler(QuickLimitTrackBar_ValueChanged);
            QuickLimitTrackBar.ValueChanged += new EventHandler(QuickLimitTrackBar_ValueChanged);

            profilesComboBox.SelectedValueChanged += new EventHandler(ProfilesComboBox_SelectedValueChanged);

            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }
        private void ProfilesComboBox_SelectedValueChanged(object? sender, EventArgs e)
        {
            string bg3StoryFolder = Path.Combine(LOCALAPPDATA, BG3_SAVE_FOLDER);
            string profile = profilesComboBox.SelectedItem?.ToString() ?? string.Empty;

            if (profile != string.Empty)
            {
                Properties.Settings.Default.BG3StoryId = profile;
                storyId = profile;
                BG3StoryIdLabel.Text = storyId;
                SendToLog($"Story ID: {storyId}");

                bg3SaveFolder = Path.Combine(bg3StoryFolder, profile);
                Properties.Settings.Default.BG3SaveFolder = bg3SaveFolder;
                SendToLog($"BG3 Save Folder: {bg3SaveFolder}");

            }
        }
        private void PopulatePofilesComboBox()
        {
            string bg3StoryFolder = Path.Combine(LOCALAPPDATA, BG3_SAVE_FOLDER);

            if (Directory.Exists(bg3StoryFolder))
            {
                // Get all directories in bg3StoryPath that end with "__HonourMode"
                string[] honourModeFolders = Directory.GetDirectories(bg3StoryFolder, "*__HonourMode", SearchOption.TopDirectoryOnly);

                // Log the folders or process them as needed
                foreach (string folder in honourModeFolders)
                {
                    string folderName = Path.GetFileName(folder);
                    profilesComboBox.Items.Add(Path.GetFileName(folderName));

                    if (folderName == storyId)
                    {
                        profilesComboBox.SelectedIndex = profilesComboBox.Items.Count - 1; // Select the last item
                    }
                }
            }
            else
            {
                SendToLog($"Directory does not exist: {bg3StoryFolder}");
            }
        }
        private static Boolean LoadCertificate(string thumbprint)
        {
            Boolean isValid = false;

            // Define the store name and location
            StoreName storeName = StoreName.My;
            StoreLocation storeLocation = StoreLocation.CurrentUser;

            // Open the certificate store
            using X509Store store = new(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);

            // Find the certificate by its thumbprint
            X509Certificate2Collection certCollection = store.Certificates.Find(
                X509FindType.FindByThumbprint, thumbprint, false);

            if (certCollection.Count > 0)
            {
                X509Certificate2 certificate = certCollection[0];

                //MessageBox.Show("Certificate found: " + certificate.Subject, "Certificate Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isValid = true;
            }
            else
            {
                // Handle the case where the certificate is not found
                MessageBox.Show("Certificate not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            store.Close();

            return isValid;
        }
        private static string FormatTime(int duration, string format)
        {
            // Format the TimeSpan as "hh:mm:ss".
            TimeSpan timeSpan = TimeSpan.FromSeconds(duration);
            return timeSpan.ToString(format); ;
        }
        private void AutosaveIntervalTrackBar_Scroll(object? sender, EventArgs e)
        {
            // Update the label with the current value of the trackbar.
            autosaveInterval = AutosaveIntervalTrackBar.Value;
            AutosaveIntervalLabel.Text = $"{autosaveInterval} minutes";
            Properties.Settings.Default.AutosaveInterval = autosaveInterval;
        }
        private void AutosaveIntervalTrackBar_ValueChanged(object? sender, EventArgs e)
        {
            int seconds = AutosaveIntervalTrackBar.Value * 60; // Convert minutes to seconds.

            timerplus.Duration = seconds; // Set the timer duration in seconds.
            timerplus.RemainingTime = seconds; // Set the timer duration in seconds.

            CountdownLabel.Text = FormatTime(seconds, COUNTDOWN_PATTERN);

            // Log the new duration.
            SendToLog($"Autosave interval changed to {seconds / 60} minutes.");
        }
        private void AutosaveLimitTrackBar_ValueChanged(object? sender, EventArgs e)
        {
            // Update the label with the current value of the trackbar.
            autosaveLimit = AutosaveLimitTrackBar.Value;
            AutosaveLimitLabel.Text = autosaveLimit.ToString();
            Properties.Settings.Default.AutosaveLimit = autosaveLimit;

            // Log the new limit.
            SendToLog($"Autosave limit changed to {autosaveLimit} files.");
        }
        private void QuickLimitTrackBar_ValueChanged(object? sender, EventArgs e)
        {
            // Update the label with the current value of the trackbar.
            quickLimit = QuickLimitTrackBar.Value;
            QuickLimitLabel.Text = quickLimit.ToString();
            Properties.Settings.Default.QuickLimit = quickLimit;

            // Log the new limit.
            SendToLog($"Quicksave limit changed to {quickLimit} files.");
        }
        private Boolean ValidateInputs()
        {
            // Validate the inputs for the save folder, story ID, and backup folder.
            if (string.IsNullOrEmpty(BackupFolderTextBox.Text))
            {
                MessageBox.Show("Please select a valid backup folder.");
                return false;
            }
            if (BG3StoryIdLabel.Text == "StoryId")
            {
                MessageBox.Show("Please select a valid BG3 save folder.");
                return false;
            }
            return true;
        }
        private void AutosaveEnableButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; // Validate inputs before proceeding.

            // Disable the enable button and enable the disable button.
            AutosaveEnableButton.Enabled = false;
            AutosaveDisableButton.Enabled = true;

            CleanBackupFolder(AUTOSAVE_PREFIX, autosaveLimit); // Call the method to clean up the backup folder.

            timerplus.Start();

            SendToLog($"Autosave timer started.");
        }
        private void DeleteExcessFilesInFolder(FileInfo[] files, int fileLimit)
        {
            int limit = fileLimit - 1; // Adjust the limit to account for the current file.

            // Check if the number of files exceeds the limit.
            if (files.Length > limit)
            {
                // Delete the oldest files.
                for (int i = 0; i < files.Length - limit; i++)
                {
                    try
                    {
                        files[i].Delete();
                        SendToLog($"Deleted oldest backup.");
                    }
                    catch (Exception ex)
                    {
                        SendToLog($"Error deleting file: {ex.Message}");
                    }
                }
            }
            else
            {
                // Log that there are no files to delete.
                SendToLog($"No files to delete. Current count: {files.Length}, Limit: {fileLimit}.");
            }
        }
        private void CleanBackupFolder(string prefix, int fileLimit = 0)
        {
            string path = System.IO.Path.Combine(backupFolder, storyId);

            // Check if the backup folder exists and create it if it doesn't.
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
                SendToLog($"Backup folder created: {path}");
            }

            // Get the list of files in the backup folder.
            FileInfo[] files = GetBackupFiles(path, prefix);
            // Check if the number of files exceeds the limit.
            if (files.Length > fileLimit - 1)
            {
                DeleteExcessFilesInFolder(files, fileLimit);
            }
        }
        private void TimerTick(object? sender, EventArgs e)
        {
            int remainingTime = timerplus.RemainingTime;

            if (remainingTime <= 0)
            {
                // Reset timer.
                timerplus.Stop();
                timerplus.RemainingTime = timerplus.Duration;
                WriteSave(AUTOSAVE_PREFIX); // Call the method to write autosave.
                timerplus.Start();
            }

            // Log the remaining time.
            // string formattedTime = now.ToString("HH:mm:ss");
            CountdownLabel.Text = FormatTime(remainingTime, COUNTDOWN_PATTERN);
        }
        public static void CreateZipFromFiles(string path, FileInfo[] files)
        {
            using FileStream zipToOpen = new(path, FileMode.Create);
            using ZipArchive archive = new(zipToOpen, ZipArchiveMode.Create);

            foreach (FileInfo file in files)
            {
                ZipArchiveEntry entry = archive.CreateEntry(file.Name);
                using Stream entryStream = entry.Open();
                using FileStream fileStream = file.OpenRead();
                fileStream.CopyTo(entryStream);
            }
        }
        private static FileInfo[] GetBackupFiles(string path, string prefix = "")
        {
            // Check if the directory exists.
            if (!System.IO.Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            // Create a DirectoryInfo object to access the directory.
            DirectoryInfo directoryInfo = new(path);
            directoryInfo.Refresh(); // Refresh the directory info to get the latest file list.

            // Get the list of files in the directory that match the prefix and extension.
            FileInfo[] files = [.. directoryInfo.GetFiles()
                .Where(file => file.Name.StartsWith(prefix) && file.Extension == SAVE_EXT)
                .OrderBy(file => file.CreationTime)];

            return files;
        }
        private static FileInfo[] GetSaveFiles(string path)
        {
            // Check if the directory exists.
            if (!System.IO.Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            // Create a DirectoryInfo object to access the directory.
            DirectoryInfo directoryInfo = new(path);
            directoryInfo.Refresh(); // Refresh the directory info to get the latest file list.

            // Get the list of files in the directory that match the prefix and extension.
            FileInfo[] files = [.. directoryInfo.GetFiles()];

            return files;
        }
        private void WriteSave(string prefix)
        {
            DateTime now = DateTime.Now;
            string timestamp = now.ToString(DATETIME_PATTERN);
            string filename = $"{prefix}{timestamp}{SAVE_EXT}";
            string zipPath = System.IO.Path.Combine(backupFolder, storyId, filename);

            FileInfo[] files = GetSaveFiles(bg3SaveFolder);

            if (files.Length > 0)
            {
                // Check if the backup folder exists and create it if it doesn't.
                if (prefix == AUTOSAVE_PREFIX)
                {
                    CleanBackupFolder(prefix, autosaveLimit);
                }
                else if (prefix == QUICKSAVE_PREFIX)
                {
                    CleanBackupFolder(prefix, quickLimit);
                }

                // Create a zip file from the files in the autosave folder.
                CreateZipFromFiles(zipPath, files);

                // Log the creation of the zip file.
                if (prefix == AUTOSAVE_PREFIX)
                {
                    SendToLog($"Autosave created: {filename}");
                }
                else if (prefix == QUICKSAVE_PREFIX)
                {
                    SendToLog($"Quicksave created: {filename}");
                }
            }
        }
        private void AutosaveDisableButton_Click(object sender, EventArgs e)
        {
            // Disable the disable button and enable the enable button.
            AutosaveDisableButton.Enabled = false;
            AutosaveEnableButton.Enabled = true;

            timerplus.Stop();
        }
        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Stop the timer if the form is closing.
            if (timerplus != null)
            {
                timerplus.Stop();
                timerplus.Tick -= TimerTick;
                timerplus.Dispose();
                timerplus = null!;
            }

            Properties.Settings.Default.Save(); // Save the settings when the form is closing.
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
                // Ensure the extraction folder exists.
                if (!Directory.Exists(extractFolderPath))
                {
                    Directory.CreateDirectory(extractFolderPath);
                }

                // Extract the contents of the zip file.
                ZipFile.ExtractToDirectory(zipFilePath, extractFolderPath, overwriteFiles: true);
                //SendToLog($"Extracting archive: {zipFilePath} to {extractFolderPath}");
                SendToLog($"Successfully extracted archive.");
            }
            catch (Exception ex)
            {
                // Log any errors that occur during extraction.
                SendToLog($"Error extracting archive: {ex.Message}");
            }
        }
        private void LoadSave(string prefix)
        {
            string backupStoryFolder = System.IO.Path.Combine(backupFolder, storyId);

            // Reset timer.
            if (prefix == AUTOSAVE_PREFIX && timerplus.IsRunning)
            {
                timerplus.Stop();
                timerplus.ResumePlaying = true;
                SendToLog($"Autosave Manager paused.");
            }

            // Check if the backup folder exists.
            if (!System.IO.Directory.Exists(backupStoryFolder))
            {
                MessageBox.Show("Backup folder does not exist.");
                return;
            }

            // Get the list of zip files in the backup folder.
            FileInfo[] files = GetBackupFiles(backupStoryFolder, prefix);
            SendToLog($"Found {files.Length} backup files.");

            if (files.Length == 0)
            {
                MessageBox.Show("No backups found.");
                return;
            }

            // Create the UI for file deletion.
            Panel panel = CreatePanel(
                new { SelectionMode = SelectionMode.One },
                new { Name = "loadButton", Text = "Load Selected Backup" },
                out ListBox listBox, out Button loadButton, out Button cancelButton
            );

            foreach (FileInfo file in files)
            {
                listBox.Items.Add(file.Name);
            }
            listBox.SelectedIndex = files.Length - 1; // Select the first item by default.

            loadButton.Click += (s, e) =>
            {
                if (listBox.SelectedItem != null)
                {
                    string selectedItem = listBox.SelectedItem?.ToString() ?? string.Empty;
                    var filePath = Path.Combine(backupStoryFolder, selectedItem);

                    try
                    {
                        // Load the selected autosave file.
                        UnzipArchive(filePath, bg3SaveFolder);
                        SendToLog($"Backup restored.");
                    }
                    catch (Exception ex)
                    {
                        SendToLog($"Error restoring backup: {ex.Message}");
                    }

                    // Re-enable the timer if it was running before.
                    if (prefix == AUTOSAVE_PREFIX && timerplus.ResumePlaying)
                    {
                        timerplus.Start();
                        timerplus.ResumePlaying = false; // Reset the flag.
                        SendToLog($"Autosave Manager resumed.");
                    }

                    // Close the panel after deletion.
                    ClosePanel(panel, prefix);
                }
                else
                {
                    MessageBox.Show("No file selected.");
                }
            };

            // Handle the cancel button click.
            cancelButton.Click += (s, e) => ClosePanel(panel, prefix);

            this.Controls.Add(panel);

            // Add the delete panel to the form.
            this.Controls.Add(panel);
            panel.BringToFront();
            panel.Focus();
        }
        private void LoadAutosaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; // Validate inputs before proceeding.

            LoadSave(AUTOSAVE_PREFIX); // Call the method to load autosave.
        }
        private void QuickLoadButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; // Validate inputs before proceeding.

            LoadSave(QUICKSAVE_PREFIX); // Call the method to load quicksave.
        }
        private void SendToLog(string message)
        {
            // Get the current DateTime.
            DateTime dt = DateTime.Now;
            // Format DateTime with Message as a String.
            string logEntry = $"[{dt:h:mm:ss tt}] {message}";

            // Append the log entry to the log text box.
            // Use a lock to ensure thread safety when updating the UI.
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
        private void QuickSaveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; // Validate inputs before proceeding.

            WriteSave(QUICKSAVE_PREFIX); // Call the method to write autosave.
        }
        private void DeleteBackups(string prefix)
        {
            string backupStoryFolder = System.IO.Path.Combine(backupFolder, storyId);

            // Reset timer.
            if (prefix == AUTOSAVE_PREFIX && timerplus.IsRunning)
            {
                timerplus.Stop();
                timerplus.ResumePlaying = true;
                SendToLog($"Autosave Manager paused.");
            }

            // Check if the backup folder exists.
            if (!System.IO.Directory.Exists(backupStoryFolder))
            {
                MessageBox.Show("Backup folder does not exist.");
                return;
            }

            // Get the list of zip files in the backup folder.
            FileInfo[] files = GetBackupFiles(backupStoryFolder, prefix);
            SendToLog($"Found {files.Length} backup files.");

            if (files.Length == 0)
            {
                MessageBox.Show("No backups found.");
                return;
            }

            // Create the UI for file deletion.
            Panel deletePanel = CreatePanel(
                new { SelectionMode = SelectionMode.MultiExtended },
                new { Name = "deleteButton", Text = "Deleted Selected Backups" },
                out ListBox listBox, out Button deleteButton, out Button cancelButton
            );

            // Populate the ListBox with file names.
            foreach (FileInfo file in files)
            {
                listBox.Items.Add(file.Name);
            }

            // Handle the delete button click.
            deleteButton.Click += (s, e) =>
            {
                if (listBox.SelectedItems.Count > 0)
                {
                    var selectedItems = listBox.SelectedItems.Cast<string>().ToList();

                    foreach (string selectedItem in selectedItems)
                    {
                        string filePath = Path.Combine(backupStoryFolder, selectedItem);
                        try
                        {
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                                listBox.Items.Remove(selectedItem);
                                SendToLog($"Deleted file: {selectedItem}");
                            }
                            else
                            {
                                MessageBox.Show($"File not found: {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting file: {filePath}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Close the panel after deletion.
                    ClosePanel(deletePanel, prefix);
                }
                else
                {
                    MessageBox.Show("No files selected for deletion.");
                }
            };

            // Handle the cancel button click.
            cancelButton.Click += (s, e) => ClosePanel(deletePanel, prefix);

            // Add the delete panel to the form.
            this.Controls.Add(deletePanel);
            deletePanel.BringToFront();
            deletePanel.Focus();
        }
        // Helper method to create the delete panel and its components.
        private static Panel CreatePanel(dynamic listBoxParams, dynamic actionButtonParams, out ListBox listBox, out Button actionButton, out Button cancelButton)
        {
            Panel panel = new()
            {
                Name = "panel",
                Size = new System.Drawing.Size(260, 300),
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.LightGray
            };

            listBox = new()
            {
                Name = "listBox",
                Dock = DockStyle.Fill,
                SelectionMode = listBoxParams.SelectionMode,
                Sorted = true
            };

            actionButton = new()
            {
                Name = actionButtonParams.Name,
                Text = actionButtonParams.Text,
                Dock = DockStyle.Bottom,
                Size = new System.Drawing.Size(260, 30)
            };

            cancelButton = new()
            {
                Name = "cancelButton",
                Text = "Cancel",
                Dock = DockStyle.Bottom,
                Size = new System.Drawing.Size(260, 30)
            };

            panel.Controls.Add(listBox);
            panel.Controls.Add(actionButton);
            panel.Controls.Add(cancelButton);

            return panel;
        }
        // Helper method to close the delete panel and resume the timer if necessary.
        private void ClosePanel(Panel panel, string prefix)
        {
            panel.Visible = false;
            panel.Dispose();

            if (prefix == AUTOSAVE_PREFIX && timerplus.ResumePlaying)
            {
                timerplus.Start();
                timerplus.ResumePlaying = false;
                SendToLog("Autosave Manager resumed.");
            }
        }
        private void AutosaveDeleteButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; // Validate inputs before proceeding.

            DeleteBackups(AUTOSAVE_PREFIX); // Call the method to delete autosave.
        }
        private void QuickDeleteButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return; // Validate inputs before proceeding.

            DeleteBackups(QUICKSAVE_PREFIX); // Call the method to delete quicksave.
        }
    }
}