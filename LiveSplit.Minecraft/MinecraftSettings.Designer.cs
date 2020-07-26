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
            this.grpBoxFAQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxSavesPath
            // 
            this.txtBoxSavesPath.Enabled = false;
            this.txtBoxSavesPath.Location = new System.Drawing.Point(6, 27);
            this.txtBoxSavesPath.Name = "txtBoxSavesPath";
            this.txtBoxSavesPath.Size = new System.Drawing.Size(364, 20);
            this.txtBoxSavesPath.TabIndex = 0;
            // 
            // labelSavesPath
            // 
            this.labelSavesPath.AutoSize = true;
            this.labelSavesPath.Location = new System.Drawing.Point(3, 11);
            this.labelSavesPath.Name = "labelSavesPath";
            this.labelSavesPath.Size = new System.Drawing.Size(80, 13);
            this.labelSavesPath.TabIndex = 1;
            this.labelSavesPath.Text = "Saves location:";
            // 
            // btnChangeSavesPath
            // 
            this.btnChangeSavesPath.Location = new System.Drawing.Point(6, 53);
            this.btnChangeSavesPath.Name = "btnChangeSavesPath";
            this.btnChangeSavesPath.Size = new System.Drawing.Size(124, 23);
            this.btnChangeSavesPath.TabIndex = 2;
            this.btnChangeSavesPath.Text = "Change saves location";
            this.btnChangeSavesPath.UseVisualStyleBackColor = true;
            this.btnChangeSavesPath.Click += new System.EventHandler(this.BtnChangeSavesPath_Click);
            // 
            // btnResetSavesPath
            // 
            this.btnResetSavesPath.Location = new System.Drawing.Point(135, 53);
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
            this.grpBoxFAQ.Location = new System.Drawing.Point(6, 95);
            this.grpBoxFAQ.Name = "grpBoxFAQ";
            this.grpBoxFAQ.Size = new System.Drawing.Size(364, 246);
            this.grpBoxFAQ.TabIndex = 5;
            this.grpBoxFAQ.TabStop = false;
            this.grpBoxFAQ.Text = "F.A.Q.";
            // 
            // labelFAQ
            // 
            this.labelFAQ.Location = new System.Drawing.Point(7, 20);
            this.labelFAQ.Name = "labelFAQ";
            this.labelFAQ.Size = new System.Drawing.Size(351, 223);
            this.labelFAQ.TabIndex = 0;
            this.labelFAQ.Text = resources.GetString("labelFAQ.Text");
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(329, 459);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(118, 13);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "Version ?.?.? by Jorkoh";
            // 
            // MinecraftSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.btnResetSavesPath);
            this.Controls.Add(this.btnChangeSavesPath);
            this.Controls.Add(this.labelSavesPath);
            this.Controls.Add(this.txtBoxSavesPath);
            this.Controls.Add(this.grpBoxFAQ);
            this.Name = "MinecraftSettings";
            this.Size = new System.Drawing.Size(475, 485);
            this.Load += new System.EventHandler(this.MinecraftSettings_Load);
            this.grpBoxFAQ.ResumeLayout(false);
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
    }
}
