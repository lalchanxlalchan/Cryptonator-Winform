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
        public string DevicesInfoPath;
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
            this.DevicesInfoPath = this.path + "\\info.txt";
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

        #region key handling

        public void setEncryptionKey(byte[] newKey)
        {
            this.encryptionKey = newKey;
            //update in mongodb
        }
        #endregion

        #region bluetooth
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
            this.DevicesInfoPath = this.path + "\\info.txt";
            this.EncryptedFilePath = this.path + "\\files.aes";
            this.MetaFilePath = this.path + "\\meta.aes";
            this.StateFilePath = this.path + "\\state.txt";


            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
                File.Create(this.DevicesInfoPath);
                File.Create(this.EncryptedFilePath);
                File.Create(this.MetaFilePath);
                File.Create(this.StateFilePath);

            }
        }
        #endregion
        #region Testing
        public void sendData(string send)
        {
            this.deviceBlue.sendData('T', send);
        }
        #endregion


        public void BluetoothDecryptAllFiles()
        {
            this.DecryptAllFiles();
        }

        #endregion

        #region FileHandling

        #region write
        public void AddFile(string file)
        {


            using (FileStream fs = new FileStream(this.DevicesInfoPath, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Flush();
                sw.WriteLine(file);
            }
        }

        public void AddFiles(List<string> files)
        {
            foreach (string file in files)
            {
                this.AddFile(file);
            }
        }

        public void RemoveFile(string paramFile)
        {

            using (FileStream fs = new FileStream(this.DevicesInfoPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (FileStream tempFile = new FileStream(this.path + "//temp.cryp", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (StreamWriter sw = new StreamWriter(tempFile))
            using (StreamReader sr = new StreamReader(fs))
            {
                string file;
                while ((file = sr.ReadLine()) != null)
                {
                    sw.Flush();
                    if (file != paramFile)
                        sw.WriteLine(file);
                }
            }

            File.Delete(this.DevicesInfoPath);
            File.Move(this.path + "temp.cryp", this.DevicesInfoPath);
        }

        #endregion

        #region read
        public List<string> GetFileList()
        {
            List<string> files = new List<string>();

            using (FileStream fs = new FileStream(this.DevicesInfoPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                fs.Position = 0;
                string file;
                while ((file = sr.ReadLine()) != null)
                {
                    files.Add(file);
                }
            }

            return files;
        }
        public bool FileListContains(string paramFile)
        {

            using (FileStream fs = new FileStream(this.DevicesInfoPath, FileMode.Open, FileAccess.ReadWrite))
            using (StreamReader sr = new StreamReader(fs))
            {
                fs.Position = 0;
                string file;
                while ((file = sr.ReadLine()) != null)
                {
                    if (file == paramFile)
                        return true;
                }
            }
            return false;
        }
        #endregion

        #endregion

        #region Encryption & Decryption
        public void EncryptFiles(List<string> files)
        {
            TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();
            TripleDES.GenerateKey();
            MessageBox.Show("Key Length Should be " + TripleDES.Key.Length);
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
                string metadataString = string.Empty;
                foreach(FileMetaData fmd in metadatas)
                {
                    metadataString += fmd.GetMetaDataString()+ ":";
                }
                metadataString = metadataString.Remove(metadataString.Length - 1, 1);
                byte[] metadatabyte = Encoding.UTF8.GetBytes(metadataString);
                ushort length = Convert.ToUInt16(metadatabyte.Length);
                byte[] lengthbyte = BitConverter.GetBytes(length);
                cs.Write(lengthbyte, 0, 16);
                cs.Write(metadatabyte, 0, metadatabyte.Length);
                
            }
            #endregion
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
        public void DecryptFilesWithKey(string key)
        {
            Thread decryptThread = new Thread(() => Decrypt(Encoding.UTF8.GetBytes(key)));
            decryptThread.Start();
        }
        private void Decrypt(byte[] newEncryptionKey)
        {
            TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();
            TripleDES.Key = newEncryptionKey;
            TripleDES.Mode = CipherMode.CBC;
            TripleDES.Padding = PaddingMode.Zeros;
            int bufferSize = 1048576;
            string fileMetaDatasString = String.Empty;
            
            #region metadata

            using (FileStream fs = new FileStream(this.MetaFilePath, FileMode.Open, FileAccess.Read))
            using (CryptoStream cs = new CryptoStream(fs, TripleDES.CreateEncryptor(), CryptoStreamMode.Read))
            {

                byte[] lengthByte = new byte[16];
                cs.Read(lengthByte, 0, lengthByte.Length);
                ushort length = BitConverter.ToUInt16(lengthByte, 0);
                int lengthInt = Convert.ToInt32(length);

                byte[] fileMetaDataByte = new byte[lengthInt];
                cs.Read(fileMetaDataByte, 0, fileMetaDataByte.Length);
                fileMetaDatasString = Encoding.UTF8.GetString(fileMetaDataByte);
            }

            #region DataInfoConversion
            List<FileMetaData> metadatas = new List<FileMetaData>();
            string[] fileMetaDatasStringList = fileMetaDatasString.Split(':');
            foreach (string fileMetaDataString in fileMetaDatasStringList)
            {
                FileMetaData tempFMD = new FileMetaData(fileMetaDataString);
                metadatas.Add(tempFMD);
            }


            #endregion



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

        }

        #endregion
        

    }
}
