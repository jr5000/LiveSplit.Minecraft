using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace LiveSplit.Minecraft
{
    public partial class MinecraftSettings : UserControl
    {
        private readonly MinecraftComponent component;

        // No, I won't learn Windows Forms databinding
        public MinecraftSettings(MinecraftComponent component)
        {
            this.component = component;
            // This (↓) initialize is for the Windows Form, not the MinecraftComponent
            InitializeComponent();

            if (Properties.Settings.Default.FirstLaunch)
            {
                Properties.Settings.Default.FirstLaunch = false;

                // Set the saves path to the standard one
                var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Properties.Settings.Default.SavesPath = Path.Combine(appDataPath, ".minecraft", "saves");

                Properties.Settings.Default.Save();

                // Encourage the user to check the settings page on first launch
                MessageBox.Show($"Minecraft saves folder location has been automatically set to:\n\n" +
                    $"{Properties.Settings.Default.SavesPath}\n\n" +
                    $"It can be changed on the settings page where you will also find other options and instructions. Good luck in your runs!",
                    this.component.ComponentName, MessageBoxButtons.OK);
            }
        }

        private void MinecraftSettings_Load(object sender, EventArgs e)
        {
            txtBoxSavesPath.Text = Properties.Settings.Default.SavesPath;

            checkBoxAutosplitterEnabled.Checked = Properties.Settings.Default.AutosplitterEnabled;

            grpBoxAutsplitterSettings.Enabled = Properties.Settings.Default.AutosplitterEnabled;

            checkBoxResetOnCreation.Checked = Properties.Settings.Default.ResetOnCreation;
            checkBoxStartOnJoin.Checked = Properties.Settings.Default.StartOnJoin;
            checkBoxSplitOnCredits.Checked = Properties.Settings.Default.SplitOnCredits;
            checkBoxSplitOnFirstNetherEntrance.Checked = Properties.Settings.Default.SplitOnFirstNetherEntrance;

            labelVersion.Text = $"Version {Assembly.GetExecutingAssembly().GetName().Version} by Jorkoh";
        }

        private void BtnChangeSavesPath_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            Properties.Settings.Default.SavesPath = dialog.SelectedPath;
            Properties.Settings.Default.Save();

            txtBoxSavesPath.Text = Properties.Settings.Default.SavesPath;
        }


        private void BtnResetSavesPath_Click(object sender, EventArgs e)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Properties.Settings.Default.SavesPath = Path.Combine(appDataPath, ".minecraft", "saves");
            Properties.Settings.Default.Save();

            txtBoxSavesPath.Text = Properties.Settings.Default.SavesPath;
        }

        private void CheckBoxAutosplitterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutosplitterEnabled = checkBoxAutosplitterEnabled.Checked;
            Properties.Settings.Default.Save();

            grpBoxAutsplitterSettings.Enabled = Properties.Settings.Default.AutosplitterEnabled;
        }

        private void CheckBoxResetOnCreation_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ResetOnCreation = checkBoxResetOnCreation.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckBoxStartOnJoin_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartOnJoin = checkBoxStartOnJoin.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckBoxSplitOnCredits_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SplitOnCredits = checkBoxSplitOnCredits.Checked;
            Properties.Settings.Default.Save();
        }

        private void CheckBoxSplitOnFirstNetherEntrance_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SplitOnFirstNetherEntrance = checkBoxSplitOnFirstNetherEntrance.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
