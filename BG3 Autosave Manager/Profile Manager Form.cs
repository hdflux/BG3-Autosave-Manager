namespace BG3_Autosave_Manager
{
    public partial class ProfileManagerForm : Form
    {
        public ProfileManagerForm(ComboBox profilesComboBox)
        {
            InitializeComponent();

            listBox.Items.Clear();

            foreach (var profile in profilesComboBox.Items)
            {
                listBox.Items.Add(profile);
            }
        }
        // Expose the listBox as a public property
        public ListBox ProfileListBox
        {
            get { return listBox; }
        }
    }
}
