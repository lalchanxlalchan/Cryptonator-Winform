using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptonator_WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region sidepanel button CLicks Handling
        private string activeFormID = string.Empty;
        private void resetSidePanelAddChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            switch (activeFormID)
            {
                case "Files":
                    buttonFiles.BackColor = Color.LightGray;
                    break;
                case "Devices":
                    buttonDevice.BackColor = Color.LightGray;
                    break;
                case "Manual":
                    buttonManual.BackColor = Color.LightGray;
                    break;
                default:
                    break;
            }
        }

        private void buttonDevice_Click(object sender, EventArgs e)
        {
            if(activeFormID != "Devices")
            {
                
                resetSidePanelAddChildForm(DeviceForm.Instance);
                activeFormID = "Devices";
                buttonDevice.BackColor = ColorTranslator.FromHtml("#CDDC39");
            }
        }

        private void buttonFiles_Click(object sender, EventArgs e)
        {
            if(activeFormID != "Files")
            {
                
                resetSidePanelAddChildForm(FilesForm.Instance);
                activeFormID = "Files";
                buttonFiles.BackColor = ColorTranslator.FromHtml("#CDDC39");
            }
        }

        private void buttonManual_Click(object sender, EventArgs e)
        {
            if(activeFormID != "Manual")
            {
                
                resetSidePanelAddChildForm(ManualForm.Instance);
                activeFormID = "Manual";
                buttonManual.BackColor = ColorTranslator.FromHtml("#CDDC39");
            }
        }
        #endregion

    }
}
