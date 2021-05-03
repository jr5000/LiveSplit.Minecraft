using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using LiveSplit.Minecraft.Properties;
using LiveSplit.Model;

namespace LiveSplit.Minecraft
{
    public partial class MinecraftSettings : UserControl
    {
        private readonly MinecraftComponent component;

        // No, I won't learn Windows Forms databinding
        public MinecraftSettings(MinecraftComponent component, LiveSplitState state)
        {
            this.component = component;
            // This (↓) initialize is for the Windows Form, not the MinecraftComponent
            InitializeComponent();

            if (Settings.Default.FirstLaunch)
            {
                Settings.Default.FirstLaunch = false;

                // Enable global hotkeys by default
                state.Settings.GlobalHotkeysEnabled = true;

                // Set the saves path to the standard one
                var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Settings.Default.SavesPath = Path.Combine(appDataPath, ".minecraft", "saves");

                Settings.Default.Save();

                // Encourage the user to check the settings page on first launch
                MessageBox.Show("Minecraft saves folder location has been set to:\n\n" +
                                $"{Settings.Default.SavesPath}\n\n" +
                                "It can be changed on the settings page where you will also find other options and instructions. Global hotkeys have been enabled. Good luck in your runs!",
                    this.component.ComponentName, MessageBoxButtons.OK);
            }

            Settings.Default.PropertyChanged += PropertyChanged;
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            LoadProperties();
        }

        private void MinecraftSettings_Load(object sender, EventArgs e)
        {
            LoadProperties();
            labelVersion.Text = $"Version {Assembly.GetExecutingAssembly().GetName().Version} by Kohru (Witchcraft and Wizardry mod by jr5000)";
        }

        private void LoadProperties()
        {
            txtBoxSavesPath.Text = Settings.Default.SavesPath;
            checkBoxAutosplitter.Checked = Settings.Default.AutosplitterEnabled;
            splitsTxt.Text = Settings.Default.Splits;
        }

        private void BtnChangeSavesPath_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Settings.Default.SavesPath = dialog.SelectedPath;
                Settings.Default.Save();

                txtBoxSavesPath.Text = Settings.Default.SavesPath;
            }
        }


        private void BtnResetSavesPath_Click(object sender, EventArgs e)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Settings.Default.SavesPath = Path.Combine(appDataPath, ".minecraft", "saves");
            Settings.Default.Save();

            txtBoxSavesPath.Text = Settings.Default.SavesPath;
        }

        private void LinkInstructions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=Ij7HDfbv63g");
        }

        private void CheckBoxAutosplitter_CheckedChanged(object sender, EventArgs e)
        {
            if (Settings.Default.AutosplitterEnabled != checkBoxAutosplitter.Checked)
            {
                Settings.Default.AutosplitterEnabled = checkBoxAutosplitter.Checked;
                Settings.Default.Save();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void splitsTxt_TextChanged(object sender, EventArgs e)
        {
            if (Settings.Default.Splits != splitsTxt.Text)
            {
                Settings.Default.Splits = splitsTxt.Text;
                Settings.Default.Save();
            }
        }
    }
}