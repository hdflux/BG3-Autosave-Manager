namespace BG3_Autosave_Manager
{
    partial class ProfileManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveButton = new Button();
            closeButton = new Button();
            listBox = new ListBox();
            editButton = new Button();
            addButton = new Button();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Dock = DockStyle.Bottom;
            saveButton.Location = new Point(0, 304);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(284, 30);
            saveButton.TabIndex = 7;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Bottom;
            closeButton.Location = new Point(0, 334);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(284, 30);
            closeButton.TabIndex = 6;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            // 
            // listBox
            // 
            listBox.Dock = DockStyle.Fill;
            listBox.FormattingEnabled = true;
            listBox.HorizontalScrollbar = true;
            listBox.ItemHeight = 15;
            listBox.Items.AddRange(new object[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty" });
            listBox.Location = new Point(0, 0);
            listBox.Name = "listBox";
            listBox.Size = new Size(284, 244);
            listBox.TabIndex = 5;
            // 
            // editButton
            // 
            editButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            editButton.Dock = DockStyle.Bottom;
            editButton.Location = new Point(0, 244);
            editButton.Name = "editButton";
            editButton.Size = new Size(284, 30);
            editButton.TabIndex = 9;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Bottom;
            addButton.Location = new Point(0, 274);
            addButton.Name = "addButton";
            addButton.Size = new Size(284, 30);
            addButton.TabIndex = 8;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // ProfileManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = closeButton;
            ClientSize = new Size(284, 364);
            Controls.Add(listBox);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(saveButton);
            Controls.Add(closeButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ProfileManagerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Profiles Manager";
            ResumeLayout(false);
        }

        #endregion

        private Button saveButton;
        private Button closeButton;
        private ListBox listBox;
        private Button editButton;
        private Button addButton;
    }
}