namespace LetMeRepair___Flash_Process
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class ReadIniSettings
    {
        ~ReadIniSettings()
        {
        }

        private void Flush(string strFilename)
        {
            FlushPrivateProfileString(0, 0, 0, strFilename);
        }

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", SetLastError = true)]
        private static extern int FlushPrivateProfileString(int sectionName, int keyName, int defaultVal, string fileName);
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileIntA")]
        public static extern int GetPrivateProfileInt(string sectionName, string keyName, int defaultVal, string fileName);
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA", SetLastError = true)]
        private static extern int GetPrivateProfileStringKey(string sectionName, string keyName, string defaultVal, StringBuilder returnVal, int returnSize, string fileName);
        public int ReadPrivateProfileInt(string section, string key, string path)
        {
            int defaultVal = -1;
            return GetPrivateProfileInt(section, key, defaultVal, path);
        }

        public string ReadPrivateProfileStringKey(string section, string key, string path)
        {
            string defaultVal = "Error";
            StringBuilder returnVal = new StringBuilder(0x100);
            return ((GetPrivateProfileStringKey(section, key, defaultVal, returnVal, returnVal.Capacity, path) <= 0) ? defaultVal : returnVal.ToString());
        }

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringA", SetLastError = true)]
        private static extern int WritePrivateProfileString(string sectionName, string keyName, string defaultVal, string fileName);
        public void WriteString(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
            this.Flush(path);
        }
    }
}

