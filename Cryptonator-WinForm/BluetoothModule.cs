using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptonator_WinForm
{
    class BluetoothModule
    {
        #region private properties

        private Guid mUUID = new Guid("85cdc8c0-9119-11ea-bb37-0242ac130002");
        private BluetoothListener blueListener;
        private NetworkStream mStream;
        private BluetoothClient conn { get; set; }
        #endregion

        #region public properties
        public bool serverStarted { get; set; }
        public bool socketEstablished { get; set; }
        public byte[] receivedMessage;
        public bool continueBluetoothConnection = false;
        #endregion

        #region constructor
        public BluetoothModule()
        {
            this.serverStarted = false;
            this.socketEstablished = false;
            this.receivedMessage = new byte[25];
            this.continueBluetoothConnection = false;
            try
            {
                this.blueListener = new BluetoothListener(mUUID);
            }
            catch (PlatformNotSupportedException)
            {
                MessageBox.Show("Please Turn On Bluetooth, Pair The Device and restart the Application");
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Failed");
            }
        }
        #endregion

        #region connection
        public void ServerConnectThread()
        {
            Thread bluetoothThread = new Thread(this.ConnectThread);
            bluetoothThread.Start();
        }

        private void ConnectThread()
        {
            this.blueListener.Start();
            serverStarted = true;
            DeviceForm.Instance.updateLabelDeviceStatus("Server Started");
            this.conn = this.blueListener.AcceptBluetoothClient();
            this.socketEstablished = true;
            DeviceForm.Instance.updateLabelDeviceStatus("Client Connected");
            this.mStream = this.conn.GetStream();
            
            this.continueBluetoothConnection = true;
            Thread t = new Thread(this.receive);
            t.Start();

        }
        #endregion

        #region IO
        public void sendData(char header, string body)
        {
            byte[] message = Encoding.UTF8.GetBytes(header + body);
            this.send(message);
        }
        private void send(byte[] message)
        {
            try
            {
                mStream.Write(message, 0, message.Length);
                DeviceForm.Instance.updateLabelDeviceIOStatus("Sending: " + Encoding.UTF8.GetString(message));
            }
            catch (IOException e)
            {
                MessageBox.Show("Exception at Sending!!");
            }
        }
        private void receive()
        {
            while (this.continueBluetoothConnection)
            {

                try
                {
                    this.mStream.Read(this.receivedMessage, 0, this.receivedMessage.Length);
                }
                catch (IOException e)
                {
                }

                if (BitConverter.ToString(this.receivedMessage.Take(1).ToArray()) == "00") //device has disconnected
                {
                    this.continueBluetoothConnection = false;
                    return;
                }

                byte[] header = this.receivedMessage.Take(1).ToArray();
                byte[] body = this.receivedMessage.Skip(1).ToArray();

                switch (Encoding.UTF8.GetString(header))
                {
                    case "M":
                        //device id
                        Device.Instance.foundDevice(this.conn.RemoteMachineName, Encoding.UTF8.GetString(body.Take(16).ToArray()));
                        DeviceForm.Instance.updateLabelDeviceName(this.conn.RemoteMachineName);
                        DeviceForm.Instance.updateLabelDeviceID(Encoding.UTF8.GetString(body.Take(16).ToArray()));
                        DeviceForm.Instance.updateLabelDeviceIOStatus("DeviceID: " + Encoding.UTF8.GetString(body.Take(16).ToArray()));
                        break;
                    case "K":
                        //key
                        Device.Instance.setEncryptionKey(body);
                        DeviceForm.Instance.updateLabelDeviceIOStatus("Length: " + Encoding.UTF8.GetString(body).Length.ToString());
                        break;
                    case "D":
                        //decrypt
                        Device.Instance.BluetoothDecryptAllFiles();
                        break;

                }
            }
        }
        #endregion


    }
}
