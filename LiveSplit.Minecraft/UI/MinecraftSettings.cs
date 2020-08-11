using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using LiveSplit.Minecraft.UI;

namespace LiveSplit.Minecraft
{
    public partial class MinecraftSettings : UserControl
    {
        //TODO add instructions link on form
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

            checkBoxAdvancedFeatures.Checked = Properties.Settings.Default.AdvancedFeaturesEnabled;
            btnConfigureAutosplitterSettings.Enabled = Properties.Settings.Default.AdvancedFeaturesEnabled;
            grpBoxTimingMethod.Enabled = Properties.Settings.Default.AdvancedFeaturesEnabled;

            radioBtnIGT.Checked = (MinecraftTimingMethod)Properties.Settings.Default.TimingMethod == MinecraftTimingMethod.IGT;
            radioBtnRTAWithoutLoads.Checked = (MinecraftTimingMethod)Properties.Settings.Default.TimingMethod == MinecraftTimingMethod.RTA_WITHOUT_LOADS;

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
            if (Properties.Settings.Default.AdvancedFeaturesEnabled != checkBoxAdvancedFeatures.Checked)
            {
                Properties.Settings.Default.AdvancedFeaturesEnabled = checkBoxAdvancedFeatures.Checked;
                Properties.Settings.Default.Save();

                btnConfigureAutosplitterSettings.Enabled = Properties.Settings.Default.AdvancedFeaturesEnabled;
                grpBoxTimingMethod.Enabled = Properties.Settings.Default.AdvancedFeaturesEnabled;
            }
        }

        private void LinkMod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Jorkoh/LiveSplit.Minecraft.Mod/releases/latest");
        }

        private void BtnConfigureAutosplitterSettings_Click(object sender, EventArgs e)
        {
            new MinecraftAutosplitterSettings(component).ShowDialog();
        }

        private void RadioBtnIGT_CheckedChanged(object sender, EventArgs e)
        {
            SetTimingMethod();
        }

        private void RadioBtnRTAWithoutLoads_CheckedChanged(object sender, EventArgs e)
        {
            SetTimingMethod();
        }

        private void SetTimingMethod()
        {
            if (radioBtnIGT.Checked && (MinecraftTimingMethod)Properties.Settings.Default.TimingMethod != MinecraftTimingMethod.IGT)
            {
                Properties.Settings.Default.TimingMethod = (int)MinecraftTimingMethod.IGT;
                Properties.Settings.Default.Save();
            }
            else if (radioBtnRTAWithoutLoads.Checked && (MinecraftTimingMethod)Properties.Settings.Default.TimingMethod != MinecraftTimingMethod.RTA_WITHOUT_LOADS)
            {
                Properties.Settings.Default.TimingMethod = (int)MinecraftTimingMethod.RTA_WITHOUT_LOADS;
                Properties.Settings.Default.Save();
            }
        }
    }
}
