namespace Cryptonator_WinForm
{
    partial class ManualForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxManualKey = new System.Windows.Forms.TextBox();
            this.buttonManualKeyEncryption = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai Medium", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key: ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.textBoxManualKey);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 66);
            this.panel1.TabIndex = 1;
            // 
            // textBoxManualKey
            // 
            this.textBoxManualKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxManualKey.Location = new System.Drawing.Point(81, 12);
            this.textBoxManualKey.Name = "textBoxManualKey";
            this.textBoxManualKey.Size = new System.Drawing.Size(433, 38);
            this.textBoxManualKey.TabIndex = 1;
            // 
            // buttonManualKeyEncryption
            // 
            this.buttonManualKeyEncryption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonManualKeyEncryption.Location = new System.Drawing.Point(429, 350);
            this.buttonManualKeyEncryption.Name = "buttonManualKeyEncryption";
            this.buttonManualKeyEncryption.Size = new System.Drawing.Size(85, 47);
            this.buttonManualKeyEncryption.TabIndex = 2;
            this.buttonManualKeyEncryption.Text = "Use Key";
            this.buttonManualKeyEncryption.UseVisualStyleBackColor = true;
            this.buttonManualKeyEncryption.Click += new System.EventHandler(this.buttonManualKeyEncryption_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(418, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "The Key can be found in your mobile at the options panel of the Cryptonator Appli" +
    "cation";
            // 
            // ManualForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonManualKeyEncryption);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManualForm";
            this.Text = "ManualForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxManualKey;
        private System.Windows.Forms.Button buttonManualKeyEncryption;
        private System.Windows.Forms.Label label2;
    }
}