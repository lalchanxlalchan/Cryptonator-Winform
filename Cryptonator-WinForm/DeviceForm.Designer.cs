namespace Cryptonator_WinForm
{
    partial class DeviceForm
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
            this.buttonDeviceStartServer = new System.Windows.Forms.Button();
            this.labelDeviceStatus = new System.Windows.Forms.Label();
            this.labelDeviceIOStatus = new System.Windows.Forms.Label();
            this.labelDeviceName = new System.Windows.Forms.Label();
            this.labelDeviceId = new System.Windows.Forms.Label();
            this.buttonDeviceTest = new System.Windows.Forms.Button();
            this.textBoxDeviceTest = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDeviceStartServer
            // 
            this.buttonDeviceStartServer.Location = new System.Drawing.Point(12, 89);
            this.buttonDeviceStartServer.Name = "buttonDeviceStartServer";
            this.buttonDeviceStartServer.Size = new System.Drawing.Size(75, 23);
            this.buttonDeviceStartServer.TabIndex = 1;
            this.buttonDeviceStartServer.Text = "Start Server";
            this.buttonDeviceStartServer.UseVisualStyleBackColor = true;
            this.buttonDeviceStartServer.Click += new System.EventHandler(this.buttonDeviceStartServer_Click);
            // 
            // labelDeviceStatus
            // 
            this.labelDeviceStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDeviceStatus.AutoSize = true;
            this.labelDeviceStatus.Location = new System.Drawing.Point(525, 428);
            this.labelDeviceStatus.Name = "labelDeviceStatus";
            this.labelDeviceStatus.Size = new System.Drawing.Size(13, 13);
            this.labelDeviceStatus.TabIndex = 2;
            this.labelDeviceStatus.Text = "--";
            this.labelDeviceStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // labelDeviceIOStatus
            // 
            this.labelDeviceIOStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDeviceIOStatus.AutoSize = true;
            this.labelDeviceIOStatus.Location = new System.Drawing.Point(9, 428);
            this.labelDeviceIOStatus.Name = "labelDeviceIOStatus";
            this.labelDeviceIOStatus.Size = new System.Drawing.Size(13, 13);
            this.labelDeviceIOStatus.TabIndex = 3;
            this.labelDeviceIOStatus.Text = "--";
            this.labelDeviceIOStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDeviceName
            // 
            this.labelDeviceName.AutoSize = true;
            this.labelDeviceName.Font = new System.Drawing.Font("Dubai", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeviceName.Location = new System.Drawing.Point(3, 9);
            this.labelDeviceName.Name = "labelDeviceName";
            this.labelDeviceName.Size = new System.Drawing.Size(193, 54);
            this.labelDeviceName.TabIndex = 4;
            this.labelDeviceName.Text = "Device Name";
            // 
            // labelDeviceId
            // 
            this.labelDeviceId.AutoSize = true;
            this.labelDeviceId.Location = new System.Drawing.Point(19, 63);
            this.labelDeviceId.Name = "labelDeviceId";
            this.labelDeviceId.Size = new System.Drawing.Size(55, 13);
            this.labelDeviceId.TabIndex = 5;
            this.labelDeviceId.Text = "Device ID";
            // 
            // buttonDeviceTest
            // 
            this.buttonDeviceTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeviceTest.Location = new System.Drawing.Point(352, 193);
            this.buttonDeviceTest.Name = "buttonDeviceTest";
            this.buttonDeviceTest.Size = new System.Drawing.Size(75, 23);
            this.buttonDeviceTest.TabIndex = 6;
            this.buttonDeviceTest.Text = "Send";
            this.buttonDeviceTest.UseVisualStyleBackColor = true;
            this.buttonDeviceTest.Click += new System.EventHandler(this.buttonDeviceTest_Click);
            // 
            // textBoxDeviceTest
            // 
            this.textBoxDeviceTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeviceTest.Location = new System.Drawing.Point(238, 167);
            this.textBoxDeviceTest.Name = "textBoxDeviceTest";
            this.textBoxDeviceTest.Size = new System.Drawing.Size(189, 20);
            this.textBoxDeviceTest.TabIndex = 7;
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.textBoxDeviceTest);
            this.Controls.Add(this.buttonDeviceTest);
            this.Controls.Add(this.labelDeviceId);
            this.Controls.Add(this.labelDeviceName);
            this.Controls.Add(this.labelDeviceIOStatus);
            this.Controls.Add(this.labelDeviceStatus);
            this.Controls.Add(this.buttonDeviceStartServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeviceForm";
            this.Text = "DeviceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeviceStartServer;
        internal System.Windows.Forms.Label labelDeviceStatus;
        internal System.Windows.Forms.Label labelDeviceIOStatus;
        private System.Windows.Forms.Label labelDeviceName;
        private System.Windows.Forms.Label labelDeviceId;
        private System.Windows.Forms.Button buttonDeviceTest;
        private System.Windows.Forms.TextBox textBoxDeviceTest;
    }
}