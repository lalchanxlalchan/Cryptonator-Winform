using System;
using System.Threading;
using System.Windows.Forms;

namespace Cryptonator_WinForm
{
    public partial class DeviceForm : Form
    {
        #region Singleton Constructor
        private DeviceForm()
        {
            InitializeComponent();
        }
        private static readonly object padlock = new object();
        private static DeviceForm instance = null;
        public static DeviceForm Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DeviceForm();
                    }
                    return instance;
                }
            }
        }
        #endregion

        private void buttonDeviceStartServer_Click(object sender, EventArgs e)
        {
            if(!Device.Instance.serverStarted)
                Device.Instance.startServer();
            Thread.Sleep(1500);
        }

        #region controllers

        internal void updateLabelDeviceStatus(string status)
        {
            DeviceForm.Instance.labelDeviceStatus.Invoke((MethodInvoker)(() =>
            {
                DeviceForm.Instance.labelDeviceStatus.Text = status;
            }));
        }

        internal void updateLabelDeviceIOStatus(string status)
        {
            DeviceForm.Instance.labelDeviceIOStatus.Invoke((MethodInvoker)(() =>
            {
                DeviceForm.Instance.labelDeviceIOStatus.Text = status;
            }));
        }

        internal void updateLabelDeviceName(string status)
        {
            DeviceForm.Instance.labelDeviceName.Invoke((MethodInvoker)(() =>
            {
                DeviceForm.Instance.labelDeviceName.Text = status;
            }));
        }

        internal void updateLabelDeviceID(string status)
        {
            DeviceForm.Instance.labelDeviceId.Invoke((MethodInvoker)(() =>
            {
                DeviceForm.Instance.labelDeviceId.Text = status;
            }));
        }


        #endregion

        private void buttonDeviceTest_Click(object sender, EventArgs e)
        {
            Device.Instance.sendData('T',textBoxDeviceTest.Text);
        }
    }
}
