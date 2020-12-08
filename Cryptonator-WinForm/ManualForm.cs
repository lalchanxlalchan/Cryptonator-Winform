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
    public partial class ManualForm : Form
    {
        private ManualForm()
        {
            InitializeComponent();
        }
        private static readonly object padlock = new object();
        private static ManualForm instance = null;
        public static ManualForm Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ManualForm();
                    }
                    return instance;
                }
            }
        }

        private void buttonManualKeyEncryption_Click(object sender, EventArgs e)
        {
            Device.Instance.DecryptFilesWithKey(textBoxManualKey.Text);
        }
    }
}
