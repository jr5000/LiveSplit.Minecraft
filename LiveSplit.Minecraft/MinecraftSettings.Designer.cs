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
            this.txtBoxSavesPath = new System.Windows.Forms.TextBox();
            this.labelSavesPath = new System.Windows.Forms.Label();
            this.btnChangeSavesPath = new System.Windows.Forms.Button();
            this.btnResetSavesPath = new System.Windows.Forms.Button();
            this.labelVersion = new System.Windows.Forms.Label();
            this.linkInstructions = new System.Windows.Forms.LinkLabel();
            this.checkBoxAutosplitter = new System.Windows.Forms.CheckBox();
            this.splitsTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxSavesPath
            // 
            this.txtBoxSavesPath.Enabled = false;
            this.txtBoxSavesPath.Location = new System.Drawing.Point(13, 33);
            this.txtBoxSavesPath.Name = "txtBoxSavesPath";
            this.txtBoxSavesPath.Size = new System.Drawing.Size(364, 20);
            this.txtBoxSavesPath.TabIndex = 0;
            // 
            // labelSavesPath
            // 
            this.labelSavesPath.AutoSize = true;
            this.labelSavesPath.Location = new System.Drawing.Point(10, 17);
            this.labelSavesPath.Name = "labelSavesPath";
            this.labelSavesPath.Size = new System.Drawing.Size(80, 13);
            this.labelSavesPath.TabIndex = 1;
            this.labelSavesPath.Text = "Saves location:";
            // 
            // btnChangeSavesPath
            // 
            this.btnChangeSavesPath.Location = new System.Drawing.Point(13, 59);
            this.btnChangeSavesPath.Name = "btnChangeSavesPath";
            this.btnChangeSavesPath.Size = new System.Drawing.Size(124, 23);
            this.btnChangeSavesPath.TabIndex = 2;
            this.btnChangeSavesPath.Text = "Change saves location";
            this.btnChangeSavesPath.UseVisualStyleBackColor = true;
            this.btnChangeSavesPath.Click += new System.EventHandler(this.BtnChangeSavesPath_Click);
            // 
            // btnResetSavesPath
            // 
            this.btnResetSavesPath.Location = new System.Drawing.Point(142, 59);
            this.btnResetSavesPath.Name = "btnResetSavesPath";
            this.btnResetSavesPath.Size = new System.Drawing.Size(124, 23);
            this.btnResetSavesPath.TabIndex = 3;
            this.btnResetSavesPath.Text = "Reset saves location";
            this.btnResetSavesPath.UseVisualStyleBackColor = true;
            this.btnResetSavesPath.Click += new System.EventHandler(this.BtnResetSavesPath_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(10, 463);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(114, 13);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "Version ?.?.? by Kohru";
            // 
            // linkInstructions
            // 
            this.linkInstructions.AutoSize = true;
            this.linkInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.linkInstructions.Location = new System.Drawing.Point(13, 424);
            this.linkInstructions.Name = "linkInstructions";
            this.linkInstructions.Size = new System.Drawing.Size(396, 24);
            this.linkInstructions.TabIndex = 11;
            this.linkInstructions.TabStop = true;
            this.linkInstructions.Text = "INSTRUCTIONS AND FAQ, PLEASE WATCH";
            this.linkInstructions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkInstructions_LinkClicked);
            // 
            // checkBoxAutosplitter
            // 
            this.checkBoxAutosplitter.AutoSize = true;
            this.checkBoxAutosplitter.Location = new System.Drawing.Point(13, 109);
            this.checkBoxAutosplitter.Name = "checkBoxAutosplitter";
            this.checkBoxAutosplitter.Size = new System.Drawing.Size(149, 17);
            this.checkBoxAutosplitter.TabIndex = 12;
            this.checkBoxAutosplitter.Text = "Enable autosplitter (+1.12)";
            this.checkBoxAutosplitter.UseVisualStyleBackColor = true;
            this.checkBoxAutosplitter.CheckedChanged += new System.EventHandler(this.CheckBoxAutosplitter_CheckedChanged);
            // 
            // splitsTxt
            // 
            this.splitsTxt.Location = new System.Drawing.Point(113, 164);
            this.splitsTxt.Name = "splitsTxt";
            this.splitsTxt.Size = new System.Drawing.Size(356, 20);
            this.splitsTxt.TabIndex = 13;
            this.splitsTxt.TextChanged += new System.EventHandler(this.splitsTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Splits (Locations)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(459, 32);
            this.label2.TabIndex = 15;
            this.label2.Text = "Comma-separated list of splits. A split is either the exact name of a fast travel" + " location, precisely as it is spelled in the quest book, or \"Respawn\".";
            // 
            // MinecraftSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitsTxt);
            this.Controls.Add(this.checkBoxAutosplitter);
            this.Controls.Add(this.labelSavesPath);
            this.Controls.Add(this.txtBoxSavesPath);
            this.Controls.Add(this.btnResetSavesPath);
            this.Controls.Add(this.btnChangeSavesPath);
            this.Controls.Add(this.linkInstructions);
            this.Controls.Add(this.labelVersion);
            this.Name = "MinecraftSettings";
            this.Size = new System.Drawing.Size(475, 485);
            this.Load += new System.EventHandler(this.MinecraftSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox splitsTxt;

        private System.Windows.Forms.Button btnChangeSavesPath;
        private System.Windows.Forms.Button btnResetSavesPath;
        private System.Windows.Forms.CheckBox checkBoxAutosplitter;
        private System.Windows.Forms.Label labelSavesPath;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkInstructions;
        private System.Windows.Forms.TextBox txtBoxSavesPath;

        #endregion
    }
}
