using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptonator_WinForm
{
    public sealed class Device
    {

        #region private properties
        private byte[] encryptionKey;
        private BluetoothModule deviceBlue;
        #endregion

        #region public properties
        public string Name { get; set; }
        public string deviceID { get; set; }
        public List<string> Files { get; }
        public bool serverStarted;

        public string EncryptedFilePath;
        public string MetaFilePath;
        public string StateFilePath;
        public string path;
        public string state; // D= decrypted, E= encrypted, U = decrypting, L = encrypting

        #endregion

        #region singleton constructor
        private Device()
        {
            this.deviceBlue = new BluetoothModule();
            this.serverStarted = false;
            this.encryptionKey = new byte[24];
            this.Name = string.Empty;
            this.deviceID = string.Empty; ;
            this.path = "C:\\Cryptonator\\";
            this.EncryptedFilePath = this.path + "\\files.aes";
            this.MetaFilePath = this.path + "\\meta.aes";
            this.StateFilePath = this.path + "\\state.txt";
        }
        private static readonly object padlock = new object();
        private static Device instance = null;
        public static Device Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Device();
                    }
                    return instance;
                }
            }
        }

        #endregion

        #region Key Handling

        public void setEncryptionKey(byte[] newKey)
        {
            this.encryptionKey = newKey;
            //update in mongodb
        }

        #endregion

        #region State Handling
    
        private string getStateFromStateFile()
        {
            using (FileStream fs = new FileStream(this.StateFilePath, FileMode.Open, FileAccess.Read))
            using(StreamReader sr = new StreamReader(fs))
            {
                return sr.ReadLine();
            }
        }

        private void setStateToStateFile(string newState)
        {
            using (FileStream fs = new FileStream(this.StateFilePath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                File.WriteAllText(this.EncryptedFilePath, string.Empty);
                sw.WriteLine(newState);
            }
        }

        private void setState(string newState)
        {
            this.state = newState;
            this.setStateToStateFile(newState);
            Thread.Sleep(1000);
            this.sendData('S', newState);
        }
        #endregion

        #region Bluetooth

        #region ConnectionInitialization
        public void startServer()
        {
            this.serverStarted = true;
            this.deviceBlue.ServerConnectThread();
        }
        #endregion

        #region DeviceInitialization
        public void foundDevice(string remoteMachineName, string id)
        {
            this.Name = remoteMachineName;
            this.deviceID = id;
            this.path = "C:\\Cryptonator\\" + this.deviceID;
            this.EncryptedFilePath = this.path + "\\files.aes";
            this.MetaFilePath = this.path + "\\meta.aes";
            this.StateFilePath = this.path + "\\state.txt";


            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
                File.Create(this.EncryptedFilePath);
                File.Create(this.MetaFilePath);
                File.Create(this.StateFilePath);
                this.setState("D");
            }
            this.getStateFromStateFile()
        }
        #endregion

        #region Send Data
        public void sendData(char header, string send)
        {
            this.deviceBlue.sendData(header , send);
        }
        #endregion

        public void BluetoothDecryptAllFiles()
        {
            this.DecryptAllFiles();
        }

        #endregion
        
        #region Encryption & Decryption
        public void EncryptFiles(List<string> files)
        {
            this.setState("L");
            TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();
            TripleDES.GenerateKey();
            TripleDES.Key = this.encryptionKey;
            TripleDES.Mode = CipherMode.CBC;
            TripleDES.Padding = PaddingMode.Zeros;
            int bufferSize = 1048576;
            List<FileMetaData> metadatas = new List<FileMetaData>();
            #region files

            using (FileStream fs = new FileStream(this.EncryptedFilePath, FileMode.Open, FileAccess.Write))
            using (CryptoStream cs = new CryptoStream(fs, TripleDES.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int read;

                //individual files are read in the following code
                #region file
                foreach (string filepath in files)
                {
                    FileMetaData fmd = new FileMetaData();
                    fmd.path = filepath;
                    using (FileStream file = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    {
                        int length = 0;
                        while ((read = file.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            cs.Write(buffer, 0, read);
                            length += read;
                        }
                        fmd.length = Convert.ToUInt16(length);
                    }
                    metadatas.Add(fmd);
                    File.Delete(filepath);
                }
                #endregion

            }
            #endregion

            #region metadata

            File.WriteAllText(MetaFilePath, string.Empty);
            using (FileStream fs = new FileStream(this.MetaFilePath, FileMode.Open, FileAccess.Write))
            using(CryptoStream cs = new CryptoStream(fs, TripleDES.CreateDecryptor(), CryptoStreamMode.Write))
            {
                string completeMetadatastring = string.Empty;
                foreach(FileMetaData fmd in metadatas)
                {
                    var metadataString = fmd.GetMetaDataString();
                    completeMetadatastring = (metadataString.Length * 8).ToString() +"?"+ metadataString;
                }
                byte[] metadatabyte = Encoding.UTF8.GetBytes(completeMetadatastring);
                ushort length = Convert.ToUInt16(metadatabyte.Length);
                byte[] lengthbyte = BitConverter.GetBytes(length);
                cs.Write(lengthbyte, 0, 16);
                cs.Write(metadatabyte, 0, metadatabyte.Length);
                
            }
            #endregion

            this.setState("E");
        }
        public void EncryptAllFiles(List<string> files)
        {
            Thread decryptThread = new Thread(() => EncryptFiles(files));
            decryptThread.Start();
        }

        public void DecryptAllFiles()
        {
            Thread decryptThread = new Thread(() => Decrypt(this.encryptionKey));
            decryptThread.Start();
        }
        public void DecryptFilesWithKey(byte[] key)
        {
            Thread decryptThread = new Thread(() => Decrypt(key));
            decryptThread.Start();
        }
        private void Decrypt(byte[] newEncryptionKey)
        {
            this.setState("U");
            TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();
            TripleDES.Key = newEncryptionKey;
            TripleDES.Mode = CipherMode.CBC;
            TripleDES.Padding = PaddingMode.Zeros;
            int bufferSize = 1048576;
            List<FileMetaData> metadatas = new List<FileMetaData>();

            #region metadata

            using (FileStream fs = new FileStream(this.MetaFilePath, FileMode.Open, FileAccess.Read))
            using (CryptoStream cs = new CryptoStream(fs, TripleDES.CreateEncryptor(), CryptoStreamMode.Read))
            {

                byte[] lengthByte = new byte[16];
                cs.Read(lengthByte, 0, lengthByte.Length);
                ushort ulength = BitConverter.ToUInt16(lengthByte, 0);
                int length = Convert.ToInt32(ulength);
                int lengthRead = 0;
                while(lengthRead < length)
                {
                    cs.Read(lengthByte, 0, lengthByte.Length);
                    ulength = BitConverter.ToUInt16(lengthByte, 0);
                    length = Convert.ToInt32(ulength);
                    lengthRead += length + lengthByte.Length;
                    var fmdByte = new byte[length];
                    cs.Read(fmdByte, 0, fmdByte.Length);
                    var fmdstring = Encoding.UTF8.GetString(fmdByte);
                    var fmd = new FileMetaData(fmdstring);
                    metadatas.Add(fmd);

                }
                
            }
        
            #endregion

            #region files
            using (FileStream fs = new FileStream(this.EncryptedFilePath, FileMode.Open, FileAccess.Read))
            using (CryptoStream cs = new CryptoStream(fs, TripleDES.CreateDecryptor(), CryptoStreamMode.Read))
            {
                int read;
                byte[] buffer = new byte[bufferSize];

                #region file
                foreach (FileMetaData metadata in metadatas)
                {
                    int length = 0;
                    using (FileStream tempFile = new FileStream(metadata.path, FileMode.Create, FileAccess.Write))
                    {
                        while (metadata.length >= length + bufferSize)
                        {
                            read = cs.Read(buffer, 0, buffer.Length);
                            tempFile.Write(buffer, 0, read);
                            length += read;
                        }
                        int remainingBytes = metadata.length - length;
                        byte[] lastBuffer = new byte[remainingBytes];
                        read = cs.Read(lastBuffer, 0, remainingBytes);
                        tempFile.Write(lastBuffer, 0, read);
                    }
                }
                #endregion


            }
            #endregion

            #region .aes file management
            File.WriteAllText(this.EncryptedFilePath, string.Empty);
            #endregion
            this.setState("D");

        }

        #endregion

    }
}
