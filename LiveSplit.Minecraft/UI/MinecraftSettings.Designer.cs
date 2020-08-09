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
            this.btnConfigureAutosplitterSettings = new System.Windows.Forms.Button();
            this.linkInstructions = new System.Windows.Forms.LinkLabel();
            this.linkMod = new System.Windows.Forms.LinkLabel();
            this.labelWarning = new System.Windows.Forms.Label();
            this.checkBoxAutosplitterEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpBoxFAQ.SuspendLayout();
            this.grpBoxAutosplitterAndLiveIGT.SuspendLayout();
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
            this.grpBoxFAQ.Location = new System.Drawing.Point(6, 254);
            this.grpBoxFAQ.Name = "grpBoxFAQ";
            this.grpBoxFAQ.Size = new System.Drawing.Size(419, 246);
            this.grpBoxFAQ.TabIndex = 5;
            this.grpBoxFAQ.TabStop = false;
            this.grpBoxFAQ.Text = "F.A.Q.";
            // 
            // labelFAQ
            // 
            this.labelFAQ.Location = new System.Drawing.Point(7, 20);
            this.labelFAQ.Name = "labelFAQ";
            this.labelFAQ.Size = new System.Drawing.Size(406, 223);
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
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.btnConfigureAutosplitterSettings);
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.linkInstructions);
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.linkMod);
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.labelWarning);
            this.grpBoxAutosplitterAndLiveIGT.Controls.Add(this.checkBoxAutosplitterEnabled);
            this.grpBoxAutosplitterAndLiveIGT.Location = new System.Drawing.Point(6, 122);
            this.grpBoxAutosplitterAndLiveIGT.Name = "grpBoxAutosplitterAndLiveIGT";
            this.grpBoxAutosplitterAndLiveIGT.Size = new System.Drawing.Size(419, 113);
            this.grpBoxAutosplitterAndLiveIGT.TabIndex = 7;
            this.grpBoxAutosplitterAndLiveIGT.TabStop = false;
            this.grpBoxAutosplitterAndLiveIGT.Text = "Autosplitter and Live IGT (experimental)";
            // 
            // btnConfigureAutosplitterSettings
            // 
            this.btnConfigureAutosplitterSettings.Location = new System.Drawing.Point(10, 70);
            this.btnConfigureAutosplitterSettings.Name = "btnConfigureAutosplitterSettings";
            this.btnConfigureAutosplitterSettings.Size = new System.Drawing.Size(182, 23);
            this.btnConfigureAutosplitterSettings.TabIndex = 15;
            this.btnConfigureAutosplitterSettings.Text = "Configure Autosplitter Settings";
            this.btnConfigureAutosplitterSettings.UseVisualStyleBackColor = true;
            this.btnConfigureAutosplitterSettings.Click += new System.EventHandler(this.BtnConfigureAutosplitterSettings_Click);
            // 
            // linkInstructions
            // 
            this.linkInstructions.AutoSize = true;
            this.linkInstructions.Location = new System.Drawing.Point(248, 78);
            this.linkInstructions.Name = "linkInstructions";
            this.linkInstructions.Size = new System.Drawing.Size(124, 13);
            this.linkInstructions.TabIndex = 10;
            this.linkInstructions.TabStop = true;
            this.linkInstructions.Text = "VIDEO INSTRUCTIONS";
            // 
            // linkMod
            // 
            this.linkMod.AutoSize = true;
            this.linkMod.Location = new System.Drawing.Point(248, 49);
            this.linkMod.Name = "linkMod";
            this.linkMod.Size = new System.Drawing.Size(77, 13);
            this.linkMod.TabIndex = 9;
            this.linkMod.TabStop = true;
            this.linkMod.Text = "LINK TO MOD";
            this.linkMod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkMod_LinkClicked);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarning.Location = new System.Drawing.Point(6, 22);
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
            this.groupBox1.Size = new System.Drawing.Size(419, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Traditional IGT";
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
        private System.Windows.Forms.LinkLabel linkInstructions;
        private System.Windows.Forms.LinkLabel linkMod;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConfigureAutosplitterSettings;
    }
}
