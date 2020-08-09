using LiveSplit.Minecraft.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveSplit.Minecraft.UI
{
    public partial class MinecraftAutosplitterSettings : Form
    {
        private readonly MinecraftComponent component;

        public MinecraftAutosplitterSettings(MinecraftComponent component)
        {
            this.component = component;
            // This (↓) initialize is for the Windows Form, not the MinecraftComponent
            InitializeComponent();
        }

        private void MinecraftAutosplitterSettings_Load(object sender, EventArgs e)
        {
            checkBoxResetOnCreation.Checked = Settings.Default.ResetOnCreation;
            checkBoxStartOnJoin.Checked = Settings.Default.StartOnJoin;
            checkBoxSplitOnCredits.Checked = Settings.Default.SplitOnCredits;

            foreach (var advancement in Settings.Default.Advancements)
            {
                var advancementSplit = advancement.Split(':');
                dataGridAdvancements.Rows.Add(advancementSplit[0], advancementSplit[1], advancementSplit[2]);
            }
            dataGridAdvancements.ClearSelection();
        }

        private void CheckBoxResetOnCreation_CheckedChanged(object sender, EventArgs e)
        {
            if (Settings.Default.ResetOnCreation != checkBoxResetOnCreation.Checked)
            {
                Settings.Default.ResetOnCreation = checkBoxResetOnCreation.Checked;
                Settings.Default.Save();
            }
        }

        private void CheckBoxStartOnJoin_CheckedChanged(object sender, EventArgs e)
        {
            if (Settings.Default.StartOnJoin != checkBoxStartOnJoin.Checked)
            {
                Settings.Default.StartOnJoin = checkBoxStartOnJoin.Checked;
                Settings.Default.Save();
            }
        }

        private void CheckBoxSplitOnCredits_CheckedChanged(object sender, EventArgs e)
        {
            if (Settings.Default.SplitOnCredits != checkBoxSplitOnCredits.Checked)
            {
                Settings.Default.SplitOnCredits = checkBoxSplitOnCredits.Checked;
                Settings.Default.Save();
            }
        }

        // Advancements grid events
        private void ButtonAddAdvancement_Click(object sender, EventArgs e)
        {
            var index = dataGridAdvancements.Rows.Add();
            dataGridAdvancements.Rows[index].Cells[0].Value = true;
            dataGridAdvancements.Rows[index].Cells[1].Value = "minecraft";
            dataGridAdvancements.Rows[index].Cells[2].Value = "replace/this";
            dataGridAdvancements.CurrentCell = dataGridAdvancements.Rows[index].Cells[2];
            dataGridAdvancements.BeginEdit(true);
        }

        private void ButtonRemoveAdvancements_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridAdvancements.SelectedRows)
            {
                dataGridAdvancements.Rows.RemoveAt(row.Index);
            }
        }

        private void DataGridAdvancements_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewRow row in dataGridAdvancements.SelectedRows)
                {
                    dataGridAdvancements.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void MinecraftAutosplitterSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridAdvancements.EndEdit();
            foreach (DataGridViewRow row in dataGridAdvancements.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (string.IsNullOrWhiteSpace(cell.FormattedValue.ToString()))
                    {
                        // Shouldn't be needed since we are setting default values on the CellEndEdit event when empty
                        MessageBox.Show("Make sure that all of the advancements have a namespace and a name.", component.ComponentName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        break;
                    }
                }
            }

            if (!e.Cancel)
            {
                Settings.Default.Advancements.Clear();
                foreach (DataGridViewRow row in dataGridAdvancements.Rows)
                {
                    Settings.Default.Advancements.Add($"{row.Cells[0].Value}:{row.Cells[1].FormattedValue}:{row.Cells[2].FormattedValue}");
                }
                Settings.Default.Save();
                // StringCollection type doesn't notify property changes ¯\_(ツ)_/¯
                component.OnSettingsChanged(this, new PropertyChangedEventArgs("Advancements"));
            }
        }

        private void DataGridAdvancements_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridAdvancements.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (string.IsNullOrWhiteSpace(cell.FormattedValue.ToString()))
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        cell.Value = false;
                        break;
                    case 1:
                        cell.Value = "minecraft";
                        break;
                    case 2:
                        cell.Value = "replace/this";
                        break;
                    default:
                        break;
                }
            }
        }

        private void LinkLabelIdentifiers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://minecraft.gamepedia.com/Advancement#List_of_advancements");
        }
    }
}
