using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptonator_WinForm
{
    class FileMetaData
    {
        #region public properties
        public string path { get; set; }

        public ushort length { get; set; }
        #endregion

        #region constructor

        public FileMetaData(string fileMetaDataString)
        {
            string[] fmdil = fileMetaDataString.Split('?');
            this.length = Convert.ToUInt16(fmdil[0]);
            this.path = fmdil[1];
        }

        public FileMetaData()
        {
        }
        #endregion

        #region Helpers


        public string GetMetaDataString()
        {
            return this.length.ToString() + "?" + this.path;
        }

        #endregion
    }
}
