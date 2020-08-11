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
            this.grpBoxAdvancedFeatures = new System.Windows.Forms.GroupBox();
            this.grpBoxTimingMethod = new System.Windows.Forms.GroupBox();
            this.radioBtnIGT = new System.Windows.Forms.RadioButton();
            this.radioBtnRTAWithoutLoads = new System.Windows.Forms.RadioButton();
            this.btnConfigureAutosplitterSettings = new System.Windows.Forms.Button();
            this.linkInstructions = new System.Windows.Forms.LinkLabel();
            this.linkMod = new System.Windows.Forms.LinkLabel();
            this.labelWarning = new System.Windows.Forms.Label();
            this.checkBoxAdvancedFeatures = new System.Windows.Forms.CheckBox();
            this.grpBoxTraditionalIGT = new System.Windows.Forms.GroupBox();
            this.grpBoxFAQ.SuspendLayout();
            this.grpBoxAdvancedFeatures.SuspendLayout();
            this.grpBoxTimingMethod.SuspendLayout();
            this.grpBoxTraditionalIGT.SuspendLayout();
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
            this.grpBoxFAQ.Location = new System.Drawing.Point(6, 271);
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
            // grpBoxAdvancedFeatures
            // 
            this.grpBoxAdvancedFeatures.Controls.Add(this.grpBoxTimingMethod);
            this.grpBoxAdvancedFeatures.Controls.Add(this.btnConfigureAutosplitterSettings);
            this.grpBoxAdvancedFeatures.Controls.Add(this.linkInstructions);
            this.grpBoxAdvancedFeatures.Controls.Add(this.linkMod);
            this.grpBoxAdvancedFeatures.Controls.Add(this.labelWarning);
            this.grpBoxAdvancedFeatures.Controls.Add(this.checkBoxAdvancedFeatures);
            this.grpBoxAdvancedFeatures.Location = new System.Drawing.Point(6, 116);
            this.grpBoxAdvancedFeatures.Name = "grpBoxAdvancedFeatures";
            this.grpBoxAdvancedFeatures.Size = new System.Drawing.Size(419, 145);
            this.grpBoxAdvancedFeatures.TabIndex = 7;
            this.grpBoxAdvancedFeatures.TabStop = false;
            this.grpBoxAdvancedFeatures.Text = "Advanced Features";
            // 
            // grpBoxTimingMethod
            // 
            this.grpBoxTimingMethod.Controls.Add(this.radioBtnIGT);
            this.grpBoxTimingMethod.Controls.Add(this.radioBtnRTAWithoutLoads);
            this.grpBoxTimingMethod.Location = new System.Drawing.Point(204, 74);
            this.grpBoxTimingMethod.Name = "grpBoxTimingMethod";
            this.grpBoxTimingMethod.Size = new System.Drawing.Size(209, 65);
            this.grpBoxTimingMethod.TabIndex = 19;
            this.grpBoxTimingMethod.TabStop = false;
            this.grpBoxTimingMethod.Text = "Timing Method";
            // 
            // radioBtnIGT
            // 
            this.radioBtnIGT.AutoSize = true;
            this.radioBtnIGT.Location = new System.Drawing.Point(18, 27);
            this.radioBtnIGT.Name = "radioBtnIGT";
            this.radioBtnIGT.Size = new System.Drawing.Size(43, 17);
            this.radioBtnIGT.TabIndex = 16;
            this.radioBtnIGT.TabStop = true;
            this.radioBtnIGT.Text = "IGT";
            this.radioBtnIGT.UseVisualStyleBackColor = true;
            this.radioBtnIGT.CheckedChanged += new System.EventHandler(this.RadioBtnIGT_CheckedChanged);
            // 
            // radioBtnRTAWithoutLoads
            // 
            this.radioBtnRTAWithoutLoads.AutoSize = true;
            this.radioBtnRTAWithoutLoads.Location = new System.Drawing.Point(88, 27);
            this.radioBtnRTAWithoutLoads.Name = "radioBtnRTAWithoutLoads";
            this.radioBtnRTAWithoutLoads.Size = new System.Drawing.Size(101, 17);
            this.radioBtnRTAWithoutLoads.TabIndex = 17;
            this.radioBtnRTAWithoutLoads.TabStop = true;
            this.radioBtnRTAWithoutLoads.Text = "RTA w/o Loads";
            this.radioBtnRTAWithoutLoads.UseVisualStyleBackColor = true;
            this.radioBtnRTAWithoutLoads.CheckedChanged += new System.EventHandler(this.RadioBtnRTAWithoutLoads_CheckedChanged);
            // 
            // btnConfigureAutosplitterSettings
            // 
            this.btnConfigureAutosplitterSettings.Location = new System.Drawing.Point(35, 86);
            this.btnConfigureAutosplitterSettings.Name = "btnConfigureAutosplitterSettings";
            this.btnConfigureAutosplitterSettings.Size = new System.Drawing.Size(99, 38);
            this.btnConfigureAutosplitterSettings.TabIndex = 15;
            this.btnConfigureAutosplitterSettings.Text = "Autosplitter Settings";
            this.btnConfigureAutosplitterSettings.UseVisualStyleBackColor = true;
            this.btnConfigureAutosplitterSettings.Click += new System.EventHandler(this.BtnConfigureAutosplitterSettings_Click);
            // 
            // linkInstructions
            // 
            this.linkInstructions.AutoSize = true;
            this.linkInstructions.Location = new System.Drawing.Point(213, 50);
            this.linkInstructions.Name = "linkInstructions";
            this.linkInstructions.Size = new System.Drawing.Size(88, 13);
            this.linkInstructions.TabIndex = 10;
            this.linkInstructions.TabStop = true;
            this.linkInstructions.Text = "INSTRUCTIONS";
            // 
            // linkMod
            // 
            this.linkMod.AutoSize = true;
            this.linkMod.Location = new System.Drawing.Point(307, 50);
            this.linkMod.Name = "linkMod";
            this.linkMod.Size = new System.Drawing.Size(99, 13);
            this.linkMod.TabIndex = 9;
            this.linkMod.TabStop = true;
            this.linkMod.Text = "DOWNLOAD MOD";
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
            // checkBoxAdvancedFeatures
            // 
            this.checkBoxAdvancedFeatures.AutoSize = true;
            this.checkBoxAdvancedFeatures.Location = new System.Drawing.Point(10, 49);
            this.checkBoxAdvancedFeatures.Name = "checkBoxAdvancedFeatures";
            this.checkBoxAdvancedFeatures.Size = new System.Drawing.Size(155, 17);
            this.checkBoxAdvancedFeatures.TabIndex = 0;
            this.checkBoxAdvancedFeatures.Text = "Enable Advanced Features";
            this.checkBoxAdvancedFeatures.UseVisualStyleBackColor = true;
            this.checkBoxAdvancedFeatures.CheckedChanged += new System.EventHandler(this.CheckBoxAutosplitterEnabled_CheckedChanged);
            // 
            // grpBoxTraditionalIGT
            // 
            this.grpBoxTraditionalIGT.Controls.Add(this.labelSavesPath);
            this.grpBoxTraditionalIGT.Controls.Add(this.txtBoxSavesPath);
            this.grpBoxTraditionalIGT.Controls.Add(this.btnChangeSavesPath);
            this.grpBoxTraditionalIGT.Controls.Add(this.btnResetSavesPath);
            this.grpBoxTraditionalIGT.Location = new System.Drawing.Point(6, 3);
            this.grpBoxTraditionalIGT.Name = "grpBoxTraditionalIGT";
            this.grpBoxTraditionalIGT.Size = new System.Drawing.Size(419, 100);
            this.grpBoxTraditionalIGT.TabIndex = 8;
            this.grpBoxTraditionalIGT.TabStop = false;
            this.grpBoxTraditionalIGT.Text = "Traditional IGT";
            // 
            // MinecraftSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBoxTraditionalIGT);
            this.Controls.Add(this.grpBoxFAQ);
            this.Controls.Add(this.grpBoxAdvancedFeatures);
            this.Controls.Add(this.labelVersion);
            this.Name = "MinecraftSettings";
            this.Size = new System.Drawing.Size(475, 560);
            this.Load += new System.EventHandler(this.MinecraftSettings_Load);
            this.grpBoxFAQ.ResumeLayout(false);
            this.grpBoxAdvancedFeatures.ResumeLayout(false);
            this.grpBoxAdvancedFeatures.PerformLayout();
            this.grpBoxTimingMethod.ResumeLayout(false);
            this.grpBoxTimingMethod.PerformLayout();
            this.grpBoxTraditionalIGT.ResumeLayout(false);
            this.grpBoxTraditionalIGT.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpBoxAdvancedFeatures;
        private System.Windows.Forms.CheckBox checkBoxAdvancedFeatures;
        private System.Windows.Forms.LinkLabel linkInstructions;
        private System.Windows.Forms.LinkLabel linkMod;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.GroupBox grpBoxTraditionalIGT;
        private System.Windows.Forms.Button btnConfigureAutosplitterSettings;
        private System.Windows.Forms.RadioButton radioBtnRTAWithoutLoads;
        private System.Windows.Forms.RadioButton radioBtnIGT;
        private System.Windows.Forms.GroupBox grpBoxTimingMethod;
    }
}
