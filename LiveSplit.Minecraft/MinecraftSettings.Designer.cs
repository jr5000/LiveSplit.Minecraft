namespace LiveSplit.Minecraft
{
    partial class MinecraftSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinecraftSettings));
            this.txtBoxSavesPath = new System.Windows.Forms.TextBox();
            this.labelSavesPath = new System.Windows.Forms.Label();
            this.btnChangeSavesPath = new System.Windows.Forms.Button();
            this.btnResetSavesPath = new System.Windows.Forms.Button();
            this.grpBoxFAQ = new System.Windows.Forms.GroupBox();
            this.labelFAQ = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.grpBoxAutosplitterAndLiveIGT = new System.Windows.Forms.GroupBox();
            this.grpBoxAutsplitterSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxSplitOnCredits = new System.Windows.Forms.CheckBox();
            this.checkBoxStartOnJoin = new System.Windows.Forms.CheckBox();
            this.checkBoxResetOnCreation = new System.Windows.Forms.CheckBox();
            this.linkInstructions = new System.Windows.Forms.LinkLabel();
            this.linkMod = new System.Windows.Forms.LinkLabel();
            this.labelWarning = new System.Windows.Forms.Label();
            this.checkBoxAutosplitterEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxSplitOnFirstNetherEntrance = new System.Windows.Forms.CheckBox();
            this.grpBoxFAQ.SuspendLayout();
            this.grpBoxAutosplitterAndLiveIGT.SuspendLayout();
            this.grpBoxAutsplitterSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxSavesPath
            // 
            this.txtBoxSavesPath.Enabled = false;
            this.txtBoxSavesPath.Location = new System.Drawing.Point(10, 38);
            this.txtBoxSavesPath.Name = "txtBoxSavesPath";
            this.txtBoxSavesPath.Size = new System.Drawing.Size(336, 20);
            this.txtBoxSavesPath.TabIndex = 0;
            // 
            // labelSavesPath
            // 
            this.labelSavesPath.AutoSize = true;
            this.labelSavesPath.Location = new System.Drawing.Point(7, 22);
            this.labelSavesPath.Name = "labelSavesPath";
            this.labelSavesPath.Size = new System.Drawing.Size(80, 13);
            this.labelSavesPath.TabIndex = 1;
            this.labelSavesPath.Text = "Saves location:";
            // 
            // btnChangeSavesPath
            // 
            this.btnChangeSavesPath.Location = new System.Drawing.Point(10, 64);
            this.btnChangeSavesPath.Name = "btnChangeSavesPath";
            this.btnChangeSavesPath.Size = new System.Drawing.Size(124, 23);
            this.btnChangeSavesPath.TabIndex = 2;
            this.btnChangeSavesPath.Text = "Change saves location";
            this.btnChangeSavesPath.UseVisualStyleBackColor = true;
            this.btnChangeSavesPath.Click += new System.EventHandler(this.BtnChangeSavesPath_Click);
            // 
            // btnResetSavesPath
            // 
            this.btnResetSavesPath.Location = new System.Drawing.Point(139, 64);
            this.btnResetSavesPath.Name = "btnResetSavesPath";
            this.btnResetSavesPath.Size = new System.Drawing.Size(124, 23);
            this.btnResetSavesPath.TabIndex = 3;
            this.btnResetSavesPath.Text = "Reset saves location";
            this.btnResetSavesPath.UseVisualStyleBackColor = true;
            this.btnResetSavesPath.Click += new System.EventHandler(this.BtnResetSavesPath_Click);
            // 
            // grpBoxFAQ
            // 
            this.grpBoxFAQ.Controls.Add(this.labelFAQ);
            this.grpBoxFAQ.Location = new System.Drawing.Point(6, 279);
            this.grpBoxFAQ.Name = "grpBoxFAQ";
            this.grpBoxFAQ.Size = new System.Drawing.Size(423, 246);
            this.grpBoxFAQ.TabIndex = 5;
            this.grpBoxFAQ.TabStop = false;
            this.grpBoxFAQ.Text = "F.A.Q.";
            // 
            // labelFAQ
            // 
            this.labelFAQ.Location = new System.Drawing.Point(7, 20);
            this.labelFAQ.Name = "labelFAQ";
            this.labelFAQ.Size = new System.Drawing.Size(410, 223);
            this.labelFAQ.TabIndex = 0;
            this.labelFAQ.Text = resources.GetString("labelFAQ.Text");
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(345, 541);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(127, 13);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "Version ?.?.?.? by Jorkoh";
            // 
            // grpBoxAutosplitterAndLiveIGT
            // 
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.grpBoxAutsplitterSettings);
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.linkInstructions);
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.linkMod);
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.labelWarning);
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.checkBoxAutosplitterEnabled);
            this.grpBoxAutosplitterAndLiveIGT.Location = new System.Drawing.Point(6, 109);
            this.grpBoxAutosplitterAndLiveIGT.Name = "grpBoxAutosplitterAndLiveIGT";
            this.grpBoxAutosplitterAndLiveIGT.Size = new System.Drawing.Size(423, 164);
            this.grpBoxAutosplitterAndLiveIGT.TabIndex = 7;
            this.grpBoxAutosplitterAndLiveIGT.TabStop = false;
            this.grpBoxAutosplitterAndLiveIGT.Text = "Autosplitter and Live IGT (experimental)";
            // 
            // grpBoxAutsplitterSettings
            // 
            this.grpBoxAutsplitterSettings.Controls.Add(this.checkBoxSplitOnFirstNetherEntrance);
            this.grpBoxAutsplitterSettings.Controls.Add(this.checkBoxSplitOnCredits);
            this.grpBoxAutsplitterSettings.Controls.Add(this.checkBoxStartOnJoin);
            this.grpBoxAutsplitterSettings.Controls.Add(this.checkBoxResetOnCreation);
            this.grpBoxAutsplitterSettings.Location = new System.Drawing.Point(195, 45);
            this.grpBoxAutsplitterSettings.Name = "grpBoxAutsplitterSettings";
            this.grpBoxAutsplitterSettings.Size = new System.Drawing.Size(222, 113);
            this.grpBoxAutsplitterSettings.TabIndex = 12;
            this.grpBoxAutsplitterSettings.TabStop = false;
            this.grpBoxAutsplitterSettings.Text = "Autsplitter settings";
            // 
            // checkBoxSplitOnCredits
            // 
            this.checkBoxSplitOnCredits.AutoSize = true;
            this.checkBoxSplitOnCredits.Location = new System.Drawing.Point(11, 66);
            this.checkBoxSplitOnCredits.Name = "checkBoxSplitOnCredits";
            this.checkBoxSplitOnCredits.Size = new System.Drawing.Size(105, 17);
            this.checkBoxSplitOnCredits.TabIndex = 13;
            this.checkBoxSplitOnCredits.Text = "SPLIT on credits";
            this.checkBoxSplitOnCredits.UseVisualStyleBackColor = true;
            this.checkBoxSplitOnCredits.CheckedChanged += new System.EventHandler(this.CheckBoxSplitOnCredits_CheckedChanged);
            // 
            // checkBoxStartOnJoin
            // 
            this.checkBoxStartOnJoin.AutoSize = true;
            this.checkBoxStartOnJoin.Location = new System.Drawing.Point(11, 43);
            this.checkBoxStartOnJoin.Name = "checkBoxStartOnJoin";
            this.checkBoxStartOnJoin.Size = new System.Drawing.Size(124, 17);
            this.checkBoxStartOnJoin.TabIndex = 12;
            this.checkBoxStartOnJoin.Text = "START on world join";
            this.checkBoxStartOnJoin.UseVisualStyleBackColor = true;
            this.checkBoxStartOnJoin.CheckedChanged += new System.EventHandler(this.CheckBoxStartOnJoin_CheckedChanged);
            // 
            // checkBoxResetOnCreation
            // 
            this.checkBoxResetOnCreation.AutoSize = true;
            this.checkBoxResetOnCreation.Location = new System.Drawing.Point(11, 20);
            this.checkBoxResetOnCreation.Name = "checkBoxResetOnCreation";
            this.checkBoxResetOnCreation.Size = new System.Drawing.Size(146, 17);
            this.checkBoxResetOnCreation.TabIndex = 11;
            this.checkBoxResetOnCreation.Text = "RESET on world creation";
            this.checkBoxResetOnCreation.UseVisualStyleBackColor = true;
            this.checkBoxResetOnCreation.CheckedChanged += new System.EventHandler(this.CheckBoxResetOnCreation_CheckedChanged);
            // 
            // linkInstructions
            // 
            this.linkInstructions.AutoSize = true;
            this.linkInstructions.Location = new System.Drawing.Point(7, 112);
            this.linkInstructions.Name = "linkInstructions";
            this.linkInstructions.Size = new System.Drawing.Size(124, 13);
            this.linkInstructions.TabIndex = 10;
            this.linkInstructions.TabStop = true;
            this.linkInstructions.Text = "VIDEO INSTRUCTIONS";
            // 
            // linkMod
            // 
            this.linkMod.AutoSize = true;
            this.linkMod.Location = new System.Drawing.Point(7, 82);
            this.linkMod.Name = "linkMod";
            this.linkMod.Size = new System.Drawing.Size(77, 13);
            this.linkMod.TabIndex = 9;
            this.linkMod.TabStop = true;
            this.linkMod.Text = "LINK TO MOD";
            // 
            // labelWarning
            // 
            this.labelWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.Location = new System.Drawing.Point(7, 22);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(336, 13);
            this.labelWarning.TabIndex = 8;
            this.labelWarning.Text = "Requires mod to work! Only for Minecraft 1.14 and above!";
            // 
            // checkBoxAutosplitterEnabled
            // 
            this.checkBoxAutosplitterEnabled.AutoSize = true;
            this.checkBoxAutosplitterEnabled.Location = new System.Drawing.Point(10, 45);
            this.checkBoxAutosplitterEnabled.Name = "checkBoxAutosplitterEnabled";
            this.checkBoxAutosplitterEnabled.Size = new System.Drawing.Size(179, 17);
            this.checkBoxAutosplitterEnabled.TabIndex = 0;
            this.checkBoxAutosplitterEnabled.Text = "Enable Autosplitter and Live IGT";
            this.checkBoxAutosplitterEnabled.UseVisualStyleBackColor = true;
            this.checkBoxAutosplitterEnabled.CheckedChanged += new System.EventHandler(this.CheckBoxAutosplitterEnabled_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelSavesPath);
            this.groupBox1.Controls.Add(this.txtBoxSavesPath);
            this.groupBox1.Controls.Add(this.btnChangeSavesPath);
            this.groupBox1.Controls.Add(this.btnResetSavesPath);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Traditional IGT";
            // 
            // checkBoxSplitOnFirstNetherEntrance
            // 
            this.checkBoxSplitOnFirstNetherEntrance.AutoSize = true;
            this.checkBoxSplitOnFirstNetherEntrance.Location = new System.Drawing.Point(11, 89);
            this.checkBoxSplitOnFirstNetherEntrance.Name = "checkBoxSplitOnFirstNetherEntrance";
            this.checkBoxSplitOnFirstNetherEntrance.Size = new System.Drawing.Size(168, 17);
            this.checkBoxSplitOnFirstNetherEntrance.TabIndex = 14;
            this.checkBoxSplitOnFirstNetherEntrance.Text = "SPLIT on first nether entrance";
            this.checkBoxSplitOnFirstNetherEntrance.UseVisualStyleBackColor = true;
            this.checkBoxSplitOnFirstNetherEntrance.CheckedChanged += new System.EventHandler(this.CheckBoxSplitOnFirstNetherEntrance_CheckedChanged);
            // 
            // MinecraftSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxFAQ);
            this.Controls.Add(this.grpBoxAutosplitterAndLiveIGT);
            this.Controls.Add(this.labelVersion);
            this.Name = "MinecraftSettings";
            this.Size = new System.Drawing.Size(475, 560);
            this.Load += new System.EventHandler(this.MinecraftSettings_Load);
            this.grpBoxFAQ.ResumeLayout(false);
            this.grpBoxAutosplitterAndLiveIGT.ResumeLayout(false);
            this.grpBoxAutosplitterAndLiveIGT.PerformLayout();
            this.grpBoxAutsplitterSettings.ResumeLayout(false);
            this.grpBoxAutsplitterSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBoxSavesPath;
        private System.Windows.Forms.Label labelSavesPath;
        private System.Windows.Forms.Button btnChangeSavesPath;
        private System.Windows.Forms.Button btnResetSavesPath;
        private System.Windows.Forms.GroupBox grpBoxFAQ;
        private System.Windows.Forms.Label labelFAQ;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.GroupBox grpBoxAutosplitterAndLiveIGT;
        private System.Windows.Forms.CheckBox checkBoxAutosplitterEnabled;
        private System.Windows.Forms.GroupBox grpBoxAutsplitterSettings;
        private System.Windows.Forms.CheckBox checkBoxSplitOnCredits;
        private System.Windows.Forms.CheckBox checkBoxStartOnJoin;
        private System.Windows.Forms.CheckBox checkBoxResetOnCreation;
        private System.Windows.Forms.LinkLabel linkInstructions;
        private System.Windows.Forms.LinkLabel linkMod;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxSplitOnFirstNetherEntrance;
    }
}
