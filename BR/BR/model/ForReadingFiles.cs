using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.IO;

namespace BR.model
{
    public class ForReadingFiles
    {
        public static void saveFileToIStore(string fileName, byte[] data)
        {
            var strBaseDir = string.Empty;
            const string delimStr = "/";
            var delimiter = delimStr.ToCharArray();
            var dirsPath = fileName.Split(delimiter);

            var isoStore = IsolatedStorageFile.GetUserStoreForApplication();

            for (var i = 0; i < dirsPath.Length - 1; i++)
            {
                strBaseDir = System.IO.Path.Combine(strBaseDir, dirsPath[i]);
                isoStore.CreateDirectory(strBaseDir);
            }



            using (var bw = new BinaryWriter(isoStore.CreateFile(fileName)))
            {
                bw.Write(data);
                bw.Close();
            }
        }

    }
}
