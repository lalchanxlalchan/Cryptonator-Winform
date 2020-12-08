using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptonator_WinForm
{
    public partial class FilesForm : Form
    {
        #region private properties
        private string filePath = "C:/";
        private string currentItem = string.Empty;
        private bool currentItemIsFile = false;
        private int selectedFileIndex;
        private List<string> selectedFiles = new List<string>();
        #endregion

        #region singleton Constructor

        private FilesForm()
        {
            InitializeComponent();
        }
        private static readonly object padlock = new object();
        private static FilesForm instance = null;
        public static FilesForm Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new FilesForm();
                    }
                    return instance;
                }
            }
        }

        #endregion

        #region on load

        private void FilesForm_Load(object sender, EventArgs e)
        {
            textBoxFileManagerPath.Text = filePath;
            loadFilesAndDirectories();
        }

        #endregion

        #region file manager

        private void loadFilesAndDirectories()
        {
            DirectoryInfo fileList;
            try
            {

                if (currentItemIsFile)
                {
                    if (!selectedFiles.Contains(getNewPath()))
                    {
                        ListViewItem selectedFile = new ListViewItem(currentItem);
                        selectedFile.SubItems.Add(getNewPath());
                        listViewSelectedFiles.Items.Add(selectedFile);

                        //add to device file
                        selectedFiles.Add(getNewPath());
                        labelSelectedFilePath.Text = selectedFiles.Count.ToString();
                    }
                }
                else
                {
                    fileList = new DirectoryInfo(filePath);
                    FileInfo[] files = fileList.GetFiles();
                    DirectoryInfo[] directories = fileList.GetDirectories();
                    listViewFileManager.Items.Clear();
                    foreach (FileInfo file in files)
                    {
                        listViewFileManager.Items.Add(file.Name, 0);
                    }
                    foreach (DirectoryInfo directory in directories)
                    {
                        listViewFileManager.Items.Add(directory.Name, 1);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        private void buttonFileManagerAdd_Click(object sender, EventArgs e)
        {
            loadAction();
        }
        private void listViewFileManager_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            loadAction();
        }
        private void buttonFileManagerUp_Click(object sender, EventArgs e)
        {
            if (textBoxFileManagerPath.Text == "C:/")
                return;
            goUpALevel();
            loadAction();
        }
        private void listViewFileManager_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            FileAttributes fileAttr;
            currentItem = e.Item.Text;
            fileAttr = File.GetAttributes(getNewPath());
            labelFileManagerSelectedItem.Text = currentItem;
            if ((fileAttr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                currentItemIsFile = false;
                textBoxFileManagerPath.Text = getNewPath();

            }
            else
            {
                currentItemIsFile = true;
            }
        }

        #region helper methods

        private void goUpALevel()
        {
            try
            {
                removeEndingSlash();
                string path = textBoxFileManagerPath.Text;
                path = path.Substring(0, path.LastIndexOf('/'));
                this.currentItemIsFile = false;
                textBoxFileManagerPath.Text = path;
                removeEndingSlash();
            }
            catch (Exception e)
            {

            }
        }

        private void removeEndingSlash()
        {
            string path = textBoxFileManagerPath.Text;
            if (path.LastIndexOf('/') == path.Length - 1)
            {
                textBoxFileManagerPath.Text = path.Substring(0, path.Length - 1);
            }
        }

        private void loadAction()
        {
            filePath = textBoxFileManagerPath.Text;
            if (filePath == "C:")
                filePath = "C:/";
            loadFilesAndDirectories();
            currentItemIsFile = false;
        }

        private string getNewPath()
        {
            if (filePath != "C:/")
            {
                return filePath + "/" + currentItem;
            }
            else
            {
                return filePath + currentItem;
            }
        }

        #endregion

        #endregion

        #region selected files


        private void listViewSelectedFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listViewSelectedFiles.Items.RemoveAt(selectedFileIndex);
            selectedFiles.RemoveAt(selectedFileIndex);
            labelSelectedFilePath.Text = selectedFiles.Count.ToString();
        }


        private void listViewSelectedFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selectedFileIndex = e.ItemIndex;
        }

        private void buttonFileManagementEncrypt_Click(object sender, EventArgs e)
        {
            Device.Instance.EncryptFiles(selectedFiles);
        }

        #endregion


    }
}
