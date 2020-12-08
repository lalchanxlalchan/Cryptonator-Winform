namespace Cryptonator_WinForm
{
    partial class Form1
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
            this.panelSide = new System.Windows.Forms.Panel();
            this.buttonManual = new System.Windows.Forms.Button();
            this.buttonDevice = new System.Windows.Forms.Button();
            this.buttonFiles = new System.Windows.Forms.Button();
            this.panelSideHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSide.SuspendLayout();
            this.panelSideHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.LightGray;
            this.panelSide.Controls.Add(this.buttonManual);
            this.panelSide.Controls.Add(this.buttonDevice);
            this.panelSide.Controls.Add(this.buttonFiles);
            this.panelSide.Controls.Add(this.panelSideHeader);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(250, 450);
            this.panelSide.TabIndex = 0;
            // 
            // buttonManual
            // 
            this.buttonManual.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonManual.FlatAppearance.BorderSize = 0;
            this.buttonManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManual.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManual.Location = new System.Drawing.Point(0, 190);
            this.buttonManual.Name = "buttonManual";
            this.buttonManual.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonManual.Size = new System.Drawing.Size(250, 45);
            this.buttonManual.TabIndex = 3;
            this.buttonManual.Text = "Use Manual Key";
            this.buttonManual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonManual.UseVisualStyleBackColor = true;
            this.buttonManual.Click += new System.EventHandler(this.buttonManual_Click);
            // 
            // buttonDevice
            // 
            this.buttonDevice.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDevice.FlatAppearance.BorderSize = 0;
            this.buttonDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDevice.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDevice.Location = new System.Drawing.Point(0, 145);
            this.buttonDevice.Name = "buttonDevice";
            this.buttonDevice.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonDevice.Size = new System.Drawing.Size(250, 45);
            this.buttonDevice.TabIndex = 2;
            this.buttonDevice.Text = "Devices";
            this.buttonDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDevice.UseVisualStyleBackColor = true;
            this.buttonDevice.Click += new System.EventHandler(this.buttonDevice_Click);
            // 
            // buttonFiles
            // 
            this.buttonFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFiles.FlatAppearance.BorderSize = 0;
            this.buttonFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiles.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiles.Location = new System.Drawing.Point(0, 100);
            this.buttonFiles.Name = "buttonFiles";
            this.buttonFiles.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.buttonFiles.Size = new System.Drawing.Size(250, 45);
            this.buttonFiles.TabIndex = 1;
            this.buttonFiles.Text = "Files";
            this.buttonFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFiles.UseVisualStyleBackColor = true;
            this.buttonFiles.Click += new System.EventHandler(this.buttonFiles_Click);
            // 
            // panelSideHeader
            // 
            this.panelSideHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.panelSideHeader.Controls.Add(this.label1);
            this.panelSideHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSideHeader.Location = new System.Drawing.Point(0, 0);
            this.panelSideHeader.Name = "panelSideHeader";
            this.panelSideHeader.Size = new System.Drawing.Size(250, 100);
            this.panelSideHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cryptonator";
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.Location = new System.Drawing.Point(250, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(550, 450);
            this.panelMain.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSide);
            this.Name = "Form1";
            this.Text = "Cryptonator";
            this.panelSide.ResumeLayout(false);
            this.panelSideHeader.ResumeLayout(false);
            this.panelSideHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelSideHeader;
        private System.Windows.Forms.Button buttonManual;
        private System.Windows.Forms.Button buttonDevice;
        private System.Windows.Forms.Button buttonFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
    }
}

