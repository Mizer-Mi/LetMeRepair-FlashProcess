namespace CommonClass
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;

    public class CIniFile
    {
        public string _FileName;

        public CIniFile()
        {
        }

        public CIniFile(string strFileName)
        {
            this._FileName = strFileName;
        }

        public void AddKey(string Section, string Key)
        {
            this.Write(Section, Key, "");
        }

        public void AddSection(string Section)
        {
            WritePrivateProfileSectionA(Section, "", this._FileName);
        }

        private void CreateFile()
        {
            try
            {
                File.Create(this._FileName).Close();
            }
            catch (Exception exception1)
            {
                string message = exception1.Message;
            }
        }

        private void DeleteFile()
        {
            if (this.FileExists())
            {
                try
                {
                    File.Delete(this._FileName);
                }
                catch (Exception exception1)
                {
                    string message = exception1.Message;
                }
            }
        }

        public void DeleteKey(string Section, string Key)
        {
            this.Write(Section, Key, null);
        }

        public void DeleteSection(string Section)
        {
            WritePrivateProfileSectionA(Section, null, this._FileName);
        }

        private bool FileExists() =>
            File.Exists(this._FileName);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSectionA(string segName, StringBuilder buffer, int nSize, string fileName);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSectionNamesA(byte[] buffer, int iLen, string fileName);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileStringA(string segName, string keyName, string sDefault, StringBuilder buffer, int nSize, string fileName);
        public virtual bool ReadBool(string Section, string Key)
        {
            try
            {
                return bool.Parse(this.ReadString(Section, Key));
            }
            catch
            {
                return bool.Parse("0-0-0");
            }
        }

        public virtual byte ReadByte(string Section, string Key)
        {
            try
            {
                return byte.Parse(this.ReadString(Section, Key));
            }
            catch
            {
                return 0;
            }
        }

        public virtual DateTime ReadDateTime(string Section, string Key)
        {
            try
            {
                return DateTime.Parse(this.ReadString(Section, Key));
            }
            catch
            {
                return DateTime.Parse("0-0-0");
            }
        }

        public virtual double ReadDouble(string Section, string Key)
        {
            try
            {
                return double.Parse(this.ReadString(Section, Key));
            }
            catch
            {
                return -1.0;
            }
        }

        public virtual float ReadFloat(string Section, string Key)
        {
            try
            {
                return float.Parse(this.ReadString(Section, Key));
            }
            catch
            {
                return -1f;
            }
        }

        public virtual int ReadInt(string Section, string Key)
        {
            try
            {
                return int.Parse(this.ReadString(Section, Key));
            }
            catch
            {
                return -1;
            }
        }

        public virtual long ReadLong(string Section, string Key)
        {
            try
            {
                return long.Parse(this.ReadString(Section, Key));
            }
            catch
            {
                return -1L;
            }
        }

        public ArrayList ReadSections()
        {
            byte[] buffer = new byte[0xffff];
            int num = GetPrivateProfileSectionNamesA(buffer, buffer.GetUpperBound(0), this._FileName);
            ArrayList list = new ArrayList();
            if (num > 0)
            {
                int index = 0;
                int num3 = 0;
                for (index = 0; index < num; index++)
                {
                    if (buffer[index] == 0)
                    {
                        string str = Encoding.Default.GetString(buffer, num3, index).Trim();
                        num3 = index + 1;
                        if (str != "")
                        {
                            list.Add(str);
                        }
                    }
                }
            }
            return list;
        }

        public string ReadString(string Section, string Key)
        {
            StringBuilder buffer = new StringBuilder(0xffff);
            GetPrivateProfileStringA(Section, Key, "", buffer, buffer.Capacity, this._FileName);
            return buffer.ToString();
        }

        public string ReadValue(string Section, string Key, string FileName)
        {
            StringBuilder buffer = new StringBuilder(0xffff);
            GetPrivateProfileStringA(Section, Key, "", buffer, buffer.Capacity, FileName);
            return buffer.ToString();
        }

        public bool SectionExists(string Section)
        {
            StringBuilder buffer = new StringBuilder(0xffff);
            GetPrivateProfileSectionA(Section, buffer, buffer.Capacity, this._FileName);
            return (buffer.ToString().Trim() != "");
        }

        public bool ValueExits(string Section, string Key) =>
            (this.ReadString(Section, Key).Trim() != "");

        public void Write(string Section, string Key, object Value)
        {
            if (Value != null)
            {
                WritePrivateProfileStringA(Section, Key, Value.ToString(), this._FileName);
            }
            else
            {
                WritePrivateProfileStringA(Section, Key, null, this._FileName);
            }
        }

        public void WriteIniFile(string Section, string Key, string Value)
        {
            if (!this.FileExists())
            {
                this.CreateFile();
            }
            if (!this.SectionExists(Section))
            {
                this.AddSection(Section);
                this.AddKey(Section, Key);
                this.Write(Section, Key, Value);
            }
            else if (this.ValueExits(Section, Key))
            {
                this.Write(Section, Key, Value);
            }
            else
            {
                this.AddKey(Section, Key);
                this.Write(Section, Key, Value);
            }
        }

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileSectionA(string segName, string sValue, string fileName);
        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileStringA(string segName, string keyName, string sValue, string fileName);
        public void WriteValue(string Section, string Key, object Value, string FileName)
        {
            if (Value != null)
            {
                WritePrivateProfileStringA(Section, Key, Value.ToString(), FileName);
            }
            else
            {
                WritePrivateProfileStringA(Section, Key, null, FileName);
            }
        }
    }
}

