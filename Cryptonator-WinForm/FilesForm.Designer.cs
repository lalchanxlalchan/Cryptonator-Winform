namespace Cryptonator_WinForm
{
    partial class FilesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilesForm));
            this.buttonFileManagerUp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonFileManagerAdd = new System.Windows.Forms.Button();
            this.textBoxFileManagerPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelFileManagerSelectedItem = new System.Windows.Forms.Label();
            this.buttonFileManagementEncrypt = new System.Windows.Forms.Button();
            this.listViewSelectedFiles = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewFileManager = new System.Windows.Forms.ListView();
            this.imageListFileManager = new System.Windows.Forms.ImageList(this.components);
            this.labelSelectedFilePath = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFileManagerUp
            // 
            this.buttonFileManagerUp.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonFileManagerUp.Location = new System.Drawing.Point(8, 0);
            this.buttonFileManagerUp.Name = "buttonFileManagerUp";
            this.buttonFileManagerUp.Size = new System.Drawing.Size(26, 25);
            this.buttonFileManagerUp.TabIndex = 0;
            this.buttonFileManagerUp.Text = "^";
            this.buttonFileManagerUp.UseVisualStyleBackColor = true;
            this.buttonFileManagerUp.Click += new System.EventHandler(this.buttonFileManagerUp_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonFileManagerAdd);
            this.panel1.Controls.Add(this.textBoxFileManagerPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonFileManagerUp);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.panel1.Size = new System.Drawing.Size(550, 25);
            this.panel1.TabIndex = 1;
            // 
            // buttonFileManagerAdd
            // 
            this.buttonFileManagerAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFileManagerAdd.Location = new System.Drawing.Point(487, 0);
            this.buttonFileManagerAdd.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.buttonFileManagerAdd.Name = "buttonFileManagerAdd";
            this.buttonFileManagerAdd.Size = new System.Drawing.Size(55, 25);
            this.buttonFileManagerAdd.TabIndex = 3;
            this.buttonFileManagerAdd.Text = "Add";
            this.buttonFileManagerAdd.UseVisualStyleBackColor = true;
            this.buttonFileManagerAdd.Click += new System.EventHandler(this.buttonFileManagerAdd_Click);
            // 
            // textBoxFileManagerPath
            // 
            this.textBoxFileManagerPath.Location = new System.Drawing.Point(76, 2);
            this.textBoxFileManagerPath.Name = "textBoxFileManagerPath";
            this.textBoxFileManagerPath.Size = new System.Drawing.Size(401, 20);
            this.textBoxFileManagerPath.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Dubai Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path: ";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.labelFileManagerSelectedItem);
            this.panel2.Controls.Add(this.buttonFileManagementEncrypt);
            this.panel2.Location = new System.Drawing.Point(12, 277);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.panel2.Size = new System.Drawing.Size(538, 24);
            this.panel2.TabIndex = 4;
            // 
            // labelFileManagerSelectedItem
            // 
            this.labelFileManagerSelectedItem.AutoSize = true;
            this.labelFileManagerSelectedItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFileManagerSelectedItem.Location = new System.Drawing.Point(0, 0);
            this.labelFileManagerSelectedItem.Margin = new System.Windows.Forms.Padding(0);
            this.labelFileManagerSelectedItem.Name = "labelFileManagerSelectedItem";
            this.labelFileManagerSelectedItem.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.labelFileManagerSelectedItem.Size = new System.Drawing.Size(13, 23);
            this.labelFileManagerSelectedItem.TabIndex = 1;
            this.labelFileManagerSelectedItem.Text = "--";
            // 
            // buttonFileManagementEncrypt
            // 
            this.buttonFileManagementEncrypt.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonFileManagementEncrypt.Location = new System.Drawing.Point(455, 0);
            this.buttonFileManagementEncrypt.Name = "buttonFileManagementEncrypt";
            this.buttonFileManagementEncrypt.Size = new System.Drawing.Size(75, 24);
            this.buttonFileManagementEncrypt.TabIndex = 0;
            this.buttonFileManagementEncrypt.Text = "Encrypt Files";
            this.buttonFileManagementEncrypt.UseVisualStyleBackColor = true;
            this.buttonFileManagementEncrypt.Click += new System.EventHandler(this.buttonFileManagementEncrypt_Click);
            // 
            // listViewSelectedFiles
            // 
            this.listViewSelectedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSelectedFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.path});
            this.listViewSelectedFiles.HideSelection = false;
            this.listViewSelectedFiles.Location = new System.Drawing.Point(12, 304);
            this.listViewSelectedFiles.Name = "listViewSelectedFiles";
            this.listViewSelectedFiles.Size = new System.Drawing.Size(530, 125);
            this.listViewSelectedFiles.TabIndex = 5;
            this.listViewSelectedFiles.UseCompatibleStateImageBehavior = false;
            this.listViewSelectedFiles.View = System.Windows.Forms.View.Details;
            this.listViewSelectedFiles.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewSelectedFiles_ItemSelectionChanged);
            this.listViewSelectedFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewSelectedFiles_MouseDoubleClick);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 100;
            // 
            // path
            // 
            this.path.Text = "Path";
            this.path.Width = 400;
            // 
            // listViewFileManager
            // 
            this.listViewFileManager.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFileManager.HideSelection = false;
            this.listViewFileManager.LargeImageList = this.imageListFileManager;
            this.listViewFileManager.Location = new System.Drawing.Point(12, 31);
            this.listViewFileManager.Name = "listViewFileManager";
            this.listViewFileManager.Size = new System.Drawing.Size(530, 243);
            this.listViewFileManager.TabIndex = 6;
            this.listViewFileManager.UseCompatibleStateImageBehavior = false;
            this.listViewFileManager.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewFileManager_ItemSelectionChanged);
            this.listViewFileManager.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewFileManager_MouseDoubleClick);
            // 
            // imageListFileManager
            // 
            this.imageListFileManager.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFileManager.ImageStream")));
            this.imageListFileManager.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFileManager.Images.SetKeyName(0, "fileIcon.png");
            this.imageListFileManager.Images.SetKeyName(1, "folderIcon.png");
            // 
            // labelSelectedFilePath
            // 
            this.labelSelectedFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSelectedFilePath.AutoSize = true;
            this.labelSelectedFilePath.Location = new System.Drawing.Point(12, 432);
            this.labelSelectedFilePath.Name = "labelSelectedFilePath";
            this.labelSelectedFilePath.Size = new System.Drawing.Size(13, 13);
            this.labelSelectedFilePath.TabIndex = 2;
            this.labelSelectedFilePath.Text = "--";
            // 
            // FilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.labelSelectedFilePath);
            this.Controls.Add(this.listViewFileManager);
            this.Controls.Add(this.listViewSelectedFiles);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FilesForm";
            this.Text = "FilesForm";
            this.Load += new System.EventHandler(this.FilesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFileManagerUp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonFileManagerAdd;
        private System.Windows.Forms.TextBox textBoxFileManagerPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonFileManagementEncrypt;
        private System.Windows.Forms.ListView listViewSelectedFiles;
        private System.Windows.Forms.ListView listViewFileManager;
        private System.Windows.Forms.ImageList imageListFileManager;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader path;
        private System.Windows.Forms.Label labelFileManagerSelectedItem;
        private System.Windows.Forms.Label labelSelectedFilePath;
    }
}