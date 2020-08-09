namespace LiveSplit.Minecraft.UI
{
    partial class MinecraftAutosplitterSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinecraftAutosplitterSettings));
            this.dataGridAdvancements = new System.Windows.Forms.DataGridView();
            this.EnabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NamespaceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentifierColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBoxSplitOnCredits = new System.Windows.Forms.CheckBox();
            this.checkBoxStartOnJoin = new System.Windows.Forms.CheckBox();
            this.checkBoxResetOnCreation = new System.Windows.Forms.CheckBox();
            this.buttonAddAdvancement = new System.Windows.Forms.Button();
            this.buttonRemoveAdvancements = new System.Windows.Forms.Button();
            this.labelAdvancements = new System.Windows.Forms.Label();
            this.grpBoxCoreEvents = new System.Windows.Forms.GroupBox();
            this.grpBoxAdvancementEvents = new System.Windows.Forms.GroupBox();
            this.linkLabelIdentifiers = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdvancements)).BeginInit();
            this.grpBoxCoreEvents.SuspendLayout();
            this.grpBoxAdvancementEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridAdvancements
            // 
            this.dataGridAdvancements.AllowUserToAddRows = false;
            this.dataGridAdvancements.AllowUserToDeleteRows = false;
            this.dataGridAdvancements.AllowUserToResizeColumns = false;
            this.dataGridAdvancements.AllowUserToResizeRows = false;
            this.dataGridAdvancements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAdvancements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnabledColumn,
            this.NamespaceColumn,
            this.IdentifierColumn});
            this.dataGridAdvancements.Location = new System.Drawing.Point(87, 56);
            this.dataGridAdvancements.Name = "dataGridAdvancements";
            this.dataGridAdvancements.RowHeadersVisible = false;
            this.dataGridAdvancements.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridAdvancements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAdvancements.Size = new System.Drawing.Size(418, 197);
            this.dataGridAdvancements.TabIndex = 22;
            this.dataGridAdvancements.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridAdvancements_CellEndEdit);
            this.dataGridAdvancements.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridAdvancements_KeyDown);
            // 
            // EnabledColumn
            // 
            this.EnabledColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EnabledColumn.HeaderText = "Enabled";
            this.EnabledColumn.Name = "EnabledColumn";
            this.EnabledColumn.Width = 52;
            // 
            // NamespaceColumn
            // 
            this.NamespaceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NamespaceColumn.HeaderText = "Namespace";
            this.NamespaceColumn.Name = "NamespaceColumn";
            this.NamespaceColumn.Width = 89;
            // 
            // IdentifierColumn
            // 
            this.IdentifierColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdentifierColumn.HeaderText = "Identifier";
            this.IdentifierColumn.Name = "IdentifierColumn";
            // 
            // checkBoxSplitOnCredits
            // 
            this.checkBoxSplitOnCredits.AutoSize = true;
            this.checkBoxSplitOnCredits.Location = new System.Drawing.Point(377, 26);
            this.checkBoxSplitOnCredits.Name = "checkBoxSplitOnCredits";
            this.checkBoxSplitOnCredits.Size = new System.Drawing.Size(105, 17);
            this.checkBoxSplitOnCredits.TabIndex = 21;
            this.checkBoxSplitOnCredits.Text = "SPLIT on credits";
            this.checkBoxSplitOnCredits.UseVisualStyleBackColor = true;
            this.checkBoxSplitOnCredits.CheckedChanged += new System.EventHandler(this.CheckBoxSplitOnCredits_CheckedChanged);
            // 
            // checkBoxStartOnJoin
            // 
            this.checkBoxStartOnJoin.AutoSize = true;
            this.checkBoxStartOnJoin.Location = new System.Drawing.Point(209, 26);
            this.checkBoxStartOnJoin.Name = "checkBoxStartOnJoin";
            this.checkBoxStartOnJoin.Size = new System.Drawing.Size(124, 17);
            this.checkBoxStartOnJoin.TabIndex = 20;
            this.checkBoxStartOnJoin.Text = "START on world join";
            this.checkBoxStartOnJoin.UseVisualStyleBackColor = true;
            this.checkBoxStartOnJoin.CheckedChanged += new System.EventHandler(this.CheckBoxStartOnJoin_CheckedChanged);
            // 
            // checkBoxResetOnCreation
            // 
            this.checkBoxResetOnCreation.AutoSize = true;
            this.checkBoxResetOnCreation.Location = new System.Drawing.Point(21, 26);
            this.checkBoxResetOnCreation.Name = "checkBoxResetOnCreation";
            this.checkBoxResetOnCreation.Size = new System.Drawing.Size(146, 17);
            this.checkBoxResetOnCreation.TabIndex = 19;
            this.checkBoxResetOnCreation.Text = "RESET on world creation";
            this.checkBoxResetOnCreation.UseVisualStyleBackColor = true;
            this.checkBoxResetOnCreation.CheckedChanged += new System.EventHandler(this.CheckBoxResetOnCreation_CheckedChanged);
            // 
            // buttonAddAdvancement
            // 
            this.buttonAddAdvancement.BackColor = System.Drawing.Color.Transparent;
            this.buttonAddAdvancement.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddAdvancement.BackgroundImage")));
            this.buttonAddAdvancement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddAdvancement.FlatAppearance.BorderSize = 0;
            this.buttonAddAdvancement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAdvancement.Location = new System.Drawing.Point(18, 92);
            this.buttonAddAdvancement.Name = "buttonAddAdvancement";
            this.buttonAddAdvancement.Size = new System.Drawing.Size(52, 52);
            this.buttonAddAdvancement.TabIndex = 24;
            this.buttonAddAdvancement.UseVisualStyleBackColor = false;
            this.buttonAddAdvancement.Click += new System.EventHandler(this.ButtonAddAdvancement_Click);
            // 
            // buttonRemoveAdvancements
            // 
            this.buttonRemoveAdvancements.BackColor = System.Drawing.Color.Transparent;
            this.buttonRemoveAdvancements.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRemoveAdvancements.BackgroundImage")));
            this.buttonRemoveAdvancements.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRemoveAdvancements.FlatAppearance.BorderSize = 0;
            this.buttonRemoveAdvancements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveAdvancements.Location = new System.Drawing.Point(18, 176);
            this.buttonRemoveAdvancements.Name = "buttonRemoveAdvancements";
            this.buttonRemoveAdvancements.Size = new System.Drawing.Size(52, 52);
            this.buttonRemoveAdvancements.TabIndex = 25;
            this.buttonRemoveAdvancements.UseVisualStyleBackColor = false;
            this.buttonRemoveAdvancements.Click += new System.EventHandler(this.ButtonRemoveAdvancements_Click);
            // 
            // labelAdvancements
            // 
            this.labelAdvancements.AutoSize = true;
            this.labelAdvancements.Location = new System.Drawing.Point(18, 28);
            this.labelAdvancements.Name = "labelAdvancements";
            this.labelAdvancements.Size = new System.Drawing.Size(210, 13);
            this.labelAdvancements.TabIndex = 26;
            this.labelAdvancements.Text = "\"Enabled\" advancements will split the timer";
            // 
            // grpBoxCoreEvents
            // 
            this.grpBoxCoreEvents.Controls.Add(this.checkBoxResetOnCreation);
            this.grpBoxCoreEvents.Controls.Add(this.checkBoxSplitOnCredits);
            this.grpBoxCoreEvents.Controls.Add(this.checkBoxStartOnJoin);
            this.grpBoxCoreEvents.Location = new System.Drawing.Point(12, 12);
            this.grpBoxCoreEvents.Name = "grpBoxCoreEvents";
            this.grpBoxCoreEvents.Size = new System.Drawing.Size(511, 64);
            this.grpBoxCoreEvents.TabIndex = 27;
            this.grpBoxCoreEvents.TabStop = false;
            this.grpBoxCoreEvents.Text = "Core Events";
            // 
            // grpBoxAdvancementEvents
            // 
            this.grpBoxAdvancementEvents.Controls.Add(this.buttonAddAdvancement);
            this.grpBoxAdvancementEvents.Controls.Add(this.buttonRemoveAdvancements);
            this.grpBoxAdvancementEvents.Controls.Add(this.dataGridAdvancements);
            this.grpBoxAdvancementEvents.Controls.Add(this.labelAdvancements);
            this.grpBoxAdvancementEvents.Controls.Add(this.linkLabelIdentifiers);
            this.grpBoxAdvancementEvents.Location = new System.Drawing.Point(12, 82);
            this.grpBoxAdvancementEvents.Name = "grpBoxAdvancementEvents";
            this.grpBoxAdvancementEvents.Size = new System.Drawing.Size(511, 265);
            this.grpBoxAdvancementEvents.TabIndex = 28;
            this.grpBoxAdvancementEvents.TabStop = false;
            this.grpBoxAdvancementEvents.Text = "Advancement Events";
            // 
            // linkLabelIdentifiers
            // 
            this.linkLabelIdentifiers.AutoSize = true;
            this.linkLabelIdentifiers.Location = new System.Drawing.Point(332, 28);
            this.linkLabelIdentifiers.Name = "linkLabelIdentifiers";
            this.linkLabelIdentifiers.Size = new System.Drawing.Size(150, 13);
            this.linkLabelIdentifiers.TabIndex = 27;
            this.linkLabelIdentifiers.TabStop = true;
            this.linkLabelIdentifiers.Text = "List of advancement identifiers";
            this.linkLabelIdentifiers.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelIdentifiers_LinkClicked);
            // 
            // MinecraftAutosplitterSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 359);
            this.Controls.Add(this.grpBoxAdvancementEvents);
            this.Controls.Add(this.grpBoxCoreEvents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MinecraftAutosplitterSettings";
            this.Text = "Autosplitter Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MinecraftAutosplitterSettings_FormClosing);
            this.Load += new System.EventHandler(this.MinecraftAutosplitterSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAdvancements)).EndInit();
            this.grpBoxCoreEvents.ResumeLayout(false);
            this.grpBoxCoreEvents.PerformLayout();
            this.grpBoxAdvancementEvents.ResumeLayout(false);
            this.grpBoxAdvancementEvents.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAdvancements;
        private System.Windows.Forms.CheckBox checkBoxSplitOnCredits;
        private System.Windows.Forms.CheckBox checkBoxStartOnJoin;
        private System.Windows.Forms.CheckBox checkBoxResetOnCreation;
        private System.Windows.Forms.Button buttonAddAdvancement;
        private System.Windows.Forms.Button buttonRemoveAdvancements;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EnabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamespaceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentifierColumn;
        private System.Windows.Forms.Label labelAdvancements;
        private System.Windows.Forms.GroupBox grpBoxCoreEvents;
        private System.Windows.Forms.GroupBox grpBoxAdvancementEvents;
        private System.Windows.Forms.LinkLabel linkLabelIdentifiers;
    }
}