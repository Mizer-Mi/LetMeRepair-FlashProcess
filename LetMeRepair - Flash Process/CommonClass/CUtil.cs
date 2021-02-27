namespace CommonClass
{
    using CommonStructure;
    using LetMeRepair___Flash_Process;
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class CUtil
    {
        public const byte SMT_CALIBRATION_PASS = 80;
        public const byte SMT_CALIBRATION_FAIL = 70;
        public const int SMT_ID_BT = 1;
        public const int SMT_ID_FT = 2;
        public const int SMT_ID_PABA_CIT = 3;
        public const string MODEL_EDA50_N = "EDA50_N";
        public const string MODEL_HUANG_N = "HUANG_N";
        public const string MODEL_EDA50K_N = "EDA50K_N";
        public const string MODEL_HENGS_N = "HENGS_N";
        public const string MODEL_HUAS_N = "HUSA_N";
        public const string MODEL_CN80 = "CN80";
        public const string MODEL_CT60 = "CT60";
        public const string MODEL_CT40 = "CT40";
        public const int IMG_TYPE_ANDROID_FASTBOOT = 1;
        public const int IMG_TYPE_ANDROID_OTA = 2;
        public const int IMG_TYPE_ANDROID_N_EMMCDL = 3;
        public const int SENSOR_K_TYPE_NULL = 0;
        public const int SENSOR_K_TYPE_PSENSOR = 1;
        public const int SENSOR_K_TYPE_GSENSOR_BIAS = 2;
        public const int SENSOR_K_TYPE_GYROSENSOR_BIAS = 3;
        public static ushort NV_SN_ID = 0x1acc;
        public static int NV_SN_LEN = 15;
        public static ushort NV_PN_ID = 0x1ac8;
        public static int NV_PN_LEN = 20;
        public static ushort NV_CN_ID = 0x1aca;
        public static int NV_CN_LEN = 20;
        public static ushort NV_SMT_ID = 0x9c3;
        public static int NV_SMT_LEN = 5;
        public static int LOCATION_NULL = -1;
        public static int LOCATION_FACTORY_SUZHOU = 0;
        public static int LOCATION_S_R = 1;
        public static int LOCATION_FACTORY_BRAZIL = 2;
        public static int CHECK_SMT = 1;
        public static int NOT_CHECK_SMT = 1;
        public static int FLASH_ENG = 0;
        public static int FLASH_RETAIL = 1;
        public static int CHECK_DEFAULT_IMAGE_ENG = 0;
        public static int CHECK_DEFAULT_IMAGE_RETAIL = 1;
        public static int CHECK_RF_ADB_ERR = -1;
        public static int CHECK_RF_FAILED = 0;
        public static int CHECK_RF_PASS = 1;
        public static string RUN_NVMANAGER_ON_WIN7_64BIT = @"C:\WINDOWS\Microsoft.NET\Framework64\v2.0.50727\Ldr64.exe Set64";
        public static string RUN_NVMANAGER_ON_WIN7_32BIT = @"C:\WINDOWS\Microsoft.NET\Framework64\v2.0.50727\Ldr64.exe setwow";

        public static bool bCheckADBIsConnected()
        {
            string str = execute("adb kill-server", 100);
            Thread.Sleep(500);
            str = execute("adb start-server", 100);
            Thread.Sleep(500);
            return execute("adb devices", 100).Contains("\tdevice");
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string str = "";
            if (bytes != null)
            {
                for (int i = bytes.Length; i > 0; i--)
                {
                    str = str + bytes[i - 1].ToString("X2");
                }
            }
            return str;
        }

        public bool CheckRunCmd(string outStr, string cmdStr) =>
            ((outStr != "") ? ((outStr.Length <= 0) || (outStr.IndexOf(cmdStr) >= 0)) : false);

    /*    public static bool checkSNAndRFResult(ref string strSN)
        {
            bool flag2;
            string sn = "";
            try
            {
                if (GetSerialNumber().Length != 10)
                {
                    Thread.Sleep(0x7d0);
                    sn = GetSerialNumber();
                    if (sn.Length != 10)
                    {
                        FrmFail fail = new FrmFail(sn);
                        fail.ShowDialog();
                        fail.Dispose();
                        return false;
                    }
                }
                int num = ReadLocation();
                if ((num != LOCATION_FACTORY_SUZHOU) && (num != LOCATION_FACTORY_BRAZIL))
                {
                    if (num != LOCATION_S_R)
                    {
                        return false;
                    }
                }
                else if (!ReadDebugModeSettings() && !TestVerifyRF(sn))
                {
                    FrmFail fail2 = new FrmFail(sn);
                    fail2.ShowDialog();
                    fail2.Dispose();
                    return false;
                }
                strSN = sn;
                return true;
            }
            catch (Exception exception1)
            {
                string message = exception1.Message;
                flag2 = false;
            }
            return flag2;
        }
        */
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo info = new DirectoryInfo(sourceDirName);
            if (!info.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);
            }
            DirectoryInfo[] directories = info.GetDirectories();
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            foreach (FileInfo info2 in info.GetFiles())
            {
                string destFileName = Path.Combine(destDirName, info2.Name);
                info2.CopyTo(destFileName, false);
            }
            if (copySubDirs)
            {
                foreach (DirectoryInfo info3 in directories)
                {
                    string str2 = Path.Combine(destDirName, info3.Name);
                    DirectoryCopy(info3.FullName, str2, copySubDirs);
                }
            }
        }

        public static void Dly(double WaitTimeSeconds)
        {
            long num = 0L;
            long ticks = 0L;
            num = Convert.ToInt64((double)(WaitTimeSeconds * 10000000.0));
            ticks = DateTime.Now.Ticks;
            while (true)
            {
                DateTime now = DateTime.Now;
                if ((now.Ticks - ticks) >= num)
                {
                    return;
                }
                Application.DoEvents();
            }
        }

        public static double ElapseTimeInSeconds(long StartTimeInTicks) =>
            ((double)((DateTime.Now.Ticks - StartTimeInTicks) / 0x989680L));

        public static bool ExcuteCmd(string str_cmd, ref string str_Result, ref string str_msg)
        {
            if (str_cmd == "")
            {
                str_msg = "Invaild paramter.";
                return false;
            }
            try
            {
                Process process = new Process
                {
                    StartInfo = {
                        FileName = @"C:\Windows\system32\cmd.exe",
                        Arguments = " /c " + str_cmd,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };
                process.Start();
                string str = "";
                str = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
                process.Dispose();
                str_Result = str;
            }
            catch (Exception exception1)
            {
                string message = exception1.Message;
                str_msg = "Exception:" + message;
                return false;
            }
            return true;
        }

        private static string execute(string command, int seconds)
        {
            string str = "";
            if ((command != null) && !command.Equals(""))
            {
                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C " + command,
                    UseShellExecute = false,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                process.StartInfo = info;
                try
                {
                    if (process.Start())
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();
                        }
                        else
                        {
                            process.WaitForExit(seconds);
                        }
                        str = process.StandardOutput.ReadToEnd();
                    }
                }
                finally
                {
                    if (process != null)
                    {
                        process.Close();
                    }
                }
            }
            return str;
        }

        public static string Execute(string command, int seconds)
        {
            string str = "";
            if ((command != null) && !command.Equals(""))
            {
                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C " + command,
                    UseShellExecute = false,
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                process.StartInfo = info;
                try
                {
                    if (process.Start())
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();
                        }
                        else
                        {
                            process.WaitForExit(seconds);
                        }
                        str = process.StandardOutput.ReadToEnd();
                    }
                }
                finally
                {
                    if (process != null)
                    {
                        process.Close();
                    }
                }
            }
            return str;
        }

        public string Execute(string command, int seconds, bool runcmd)
        {
            string str = "";
            if ((command != null) && !command.Equals(""))
            {
                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo();
                if (runcmd)
                {
                    info.FileName = "cmd.exe";
                    info.Arguments = "/C " + command;
                }
                else
                {
                    info.FileName = command;
                    info.Arguments = string.Format("10", new object[0]);
                }
                info.UseShellExecute = false;
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.CreateNoWindow = true;
                process.StartInfo = info;
                try
                {
                    if (process.Start())
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();
                        }
                        else
                        {
                            process.WaitForExit(seconds);
                        }
                        str = process.StandardOutput.ReadToEnd();
                    }
                }
                finally
                {
                    if (process != null)
                    {
                        process.Close();
                    }
                }
            }
            return str;
        }

        public static string executeGetSysProp(string command, int seconds, bool runcmd)
        {
            string str = "";
            StringBuilder builder1 = new StringBuilder();
            if ((command != null) && !command.Equals(""))
            {
                Process process = new Process();
                ProcessStartInfo info = new ProcessStartInfo();
                if (runcmd)
                {
                    info.FileName = "cmd.exe";
                    info.Arguments = "/C " + command;
                }
                else
                {
                    info.FileName = command;
                    info.Arguments = string.Format("10", new object[0]);
                }
                info.UseShellExecute = false;
                info.RedirectStandardInput = false;
                info.RedirectStandardOutput = true;
                info.CreateNoWindow = true;
                process.StartInfo = info;
                try
                {
                    if (process.Start())
                    {
                        str = process.StandardOutput.ReadLine();
                        if (seconds == 0)
                        {
                            process.WaitForExit();
                        }
                        else
                        {
                            process.WaitForExit(seconds);
                        }
                    }
                }
                finally
                {
                    if (process != null)
                    {
                        process.Close();
                    }
                }
            }
            return str;
        }

      /*  public static string GetLogPath(string fileName)
        {
            string path = "";
            string str2 = "";
            str2 = ReadLogPath(Program.g_str_Model);
            if (str2 == "")
            {
                MessageBox.Show("Can not find matching model");
                return null;
            }
            if (!Directory.Exists(str2))
            {
                Directory.CreateDirectory(str2);
            }
            path = (str2.Remove(0, str2.Length - 1) != @"\") ? (str2 + @"\" + fileName) : (str2 + fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        */
       /* public static bool GetMDCSFailCode(string deviceName, string sSN, ref string sValue, ref string sErrorMessage) =>
            new CSaveDataMDCS().GetMDCSVariables(deviceName, "failcode", sSN, ref sValue, ref sErrorMessage);
        */
        private static string GetSerialNumber() =>
            executeGetSysProp("adb shell su 0 mfg-tool -g EX_SERIAL_NUMBER", 100, true);

        public static bool Initialize(ref string sErrMsg)
        {
            IntPtr ptr = Marshal.AllocHGlobal(0x100);
            if (Initialize_QMSL(ptr))
            {
                Marshal.FreeHGlobal(ptr);
                return true;
            }
            sErrMsg = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);
            return false;
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("NVManager.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool Initialize_QMSL(IntPtr sErrMsg);
        public static bool IsConnected(ref string sErrMsg)
        {
            IntPtr ptr = Marshal.AllocHGlobal(0x100);
            if (IsConnected_QMSL(ptr))
            {
                Marshal.FreeHGlobal(ptr);
                return true;
            }
            sErrMsg = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);
            return false;
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("NVManager.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool IsConnected_QMSL(IntPtr sErrMsg);
        public static void KillQpst()
        {
            foreach (Process process in Process.GetProcessesByName("QPSTServer"))
            {
                try
                {
                    process.Kill();
                }
                catch (Exception)
                {
                }
            }
            foreach (Process process2 in Process.GetProcessesByName("AtmnServer"))
            {
                try
                {
                    process2.Kill();
                }
                catch (Exception)
                {
                }
            }
        }

        public static string LaunchExternalExecutable(string executablePath, string arguments)
        {
            string str = "";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = false,
                UseShellExecute = false,
                FileName = executablePath,
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = arguments,
                RedirectStandardOutput = true
            };
            try
            {
                using (Process process = Process.Start(startInfo))
                {
                    str = process.StandardOutput.ReadToEnd();
                }
            }
            catch (SystemException)
            {
            }
            return str.Trim().TrimEnd(Environment.NewLine.ToCharArray()).Replace('{', '[').Replace('}', ']');
        }

        public static bool nv_to_imei(byte[] imei, byte[] nv)
        {
            imei[0] = (byte)((nv[1] & 240) >> 4);
            imei[1] = (byte)(nv[2] & 15);
            imei[2] = (byte)((nv[2] & 240) >> 4);
            imei[3] = (byte)(nv[3] & 15);
            imei[4] = (byte)((nv[3] & 240) >> 4);
            imei[5] = (byte)(nv[4] & 15);
            imei[6] = (byte)((nv[4] & 240) >> 4);
            imei[7] = (byte)(nv[5] & 15);
            imei[8] = (byte)((nv[5] & 240) >> 4);
            imei[9] = (byte)(nv[6] & 15);
            imei[10] = (byte)((nv[6] & 240) >> 4);
            imei[11] = (byte)(nv[7] & 15);
            imei[12] = (byte)((nv[7] & 240) >> 4);
            imei[13] = (byte)(nv[8] & 15);
            imei[14] = (byte)((nv[8] & 240) >> 4);
            return true;
        }

        public static int PlateFormRunMode() =>
            ((Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0").GetValue("Identifier").ToString().IndexOf("64") <= 0) ? 0x20 : 0x40);

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("NVManager.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool QCNRestore(IntPtr fileName, IntPtr sErrMsg);
        public static int ReadCheckSMT()
        {
            string path = "";
            ReadIniSettings settings = new ReadIniSettings();
            path = Application.StartupPath + @"\Option.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Error: Can not locate " + path, "INI Error");
                return LOCATION_NULL;
            }
            string s = settings.ReadPrivateProfileStringKey("CheckSMT", "value", path);
            if (s != "Error")
            {
                return int.Parse(s);
            }
            MessageBox.Show("Error: Location setting", "INI Error");
            return LOCATION_NULL;
        }

        public static bool ReadDebugModeSettings()
        {
            ReadIniSettings settings = new ReadIniSettings();
            string path = Application.StartupPath + @"\Option.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Error: Can not locate " + path, "INI Error");
                return false;
            }
            string str2 = settings.ReadPrivateProfileStringKey("Debug", "enabled", path);
            if (str2 != "Error")
            {
                return (str2 == "1");
            }
            MessageBox.Show("Error: Debug setting", "INI Error");
            return false;
        }

        public static int ReadLocation()
        {
            string path = "";
            ReadIniSettings settings = new ReadIniSettings();
            path = Application.StartupPath + @"\Option.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Error: Can not locate " + path, "INI Error");
                return LOCATION_NULL;
            }
            string s = settings.ReadPrivateProfileStringKey("Location", "value", path);
            if (s != "Error")
            {
                return int.Parse(s);
            }
            MessageBox.Show("Error: Location setting", "INI Error");
            return LOCATION_NULL;
        }

       /* public static string ReadLogPath(string model)
        {
            string path = "";
            string str2 = "";
            ReadIniSettings settings = new ReadIniSettings();
            path = Application.StartupPath + @"\Option.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Error: Can not locate " + path, "INI Error");
                return "";
            }
            string key = model;
            if (key != null)
            {
                int num;
                if (< PrivateImplementationDetails >{ 8E12E5D5 - F4C1 - 4C01 - 879D - D481E47DBA75}.$$method0x6000070 - 1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(8);
                    dictionary1.Add("EDA50_N", 0);
                    dictionary1.Add("EDA50K_N", 1);
                    dictionary1.Add("HUANG_N", 2);
                    dictionary1.Add("HENGS_N", 3);
                    dictionary1.Add("HUSA_N", 4);
                    dictionary1.Add("CN80", 5);
                    dictionary1.Add("CT60", 6);
                    dictionary1.Add("CT40", 7);
                    < PrivateImplementationDetails >{ 8E12E5D5 - F4C1 - 4C01 - 879D - D481E47DBA75}.$$method0x6000070 - 1 = dictionary1;
                }
                if (< PrivateImplementationDetails >{ 8E12E5D5 - F4C1 - 4C01 - 879D - D481E47DBA75}.$$method0x6000070 - 1.TryGetValue(key, out num))
                {
                    switch (num)
                    {
                        case 0:
                            str2 = settings.ReadPrivateProfileStringKey("EDA50_N", "Log_Path", path);
                            goto TR_0004;

                        case 1:
                            str2 = settings.ReadPrivateProfileStringKey("EDA50K_N", "Log_Path", path);
                            goto TR_0004;

                        case 2:
                            str2 = settings.ReadPrivateProfileStringKey("Huang_N", "Log_Path", path);
                            goto TR_0004;

                        case 3:
                            str2 = settings.ReadPrivateProfileStringKey("HengS_N", "Log_Path", path);
                            goto TR_0004;

                        case 4:
                            str2 = settings.ReadPrivateProfileStringKey("HuaS_N", "Log_Path", path);
                            goto TR_0004;

                        case 5:
                            str2 = settings.ReadPrivateProfileStringKey("CN80", "Log_Path", path);
                            goto TR_0004;

                        case 6:
                            str2 = settings.ReadPrivateProfileStringKey("CT60", "Log_Path", path);
                            goto TR_0004;

                        case 7:
                            str2 = settings.ReadPrivateProfileStringKey("CT40", "Log_Path", path);
                            goto TR_0004;

                        default:
                            break;
                    }
                }
            }
            str2 = "";
        TR_0004:
            if ((str2 != "Error") && (str2 != ""))
            {
                return str2;
            }
            MessageBox.Show("Error: Translate setting", "INI Error");
            return "";
        } /*

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("NVManager.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool ReadNV_QMSL_Byte(ushort unIndex, byte[] data, int iSize, IntPtr sErrMsg);
        public static bool ReadNVByte(ushort unIndex, byte[] data, int iSize, ref string sErrMsg)
        {
            IntPtr ptr = Marshal.AllocHGlobal(0x100);
            if (ReadNV_QMSL_Byte(unIndex, data, iSize, ptr))
            {
                Marshal.FreeHGlobal(ptr);
                return true;
            }
            sErrMsg = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);
            return false;
        }

        public static bool ReadNVByteValue(ushort id, ref byte[] data, int iSize, ref string sErrMsg)
        {
            bool flag = false;
            IntPtr ptr = Marshal.AllocHGlobal(0x100);
            try
            {
                flag = ReadNV_QMSL_Byte(id, data, 5, ptr);
            }
            catch (Exception exception)
            {
                sErrMsg = "Exception:" + exception.Message;
                Marshal.FreeHGlobal(ptr);
                MessageBox.Show("Catch error = " + sErrMsg);
                return false;
            }
            if (flag)
            {
                Marshal.FreeHGlobal(ptr);
                return true;
            }
            sErrMsg = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);
            MessageBox.Show("ReadNV_QMSL_Byte failed, sErrMsg = " + sErrMsg);
            return false;
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("NVManager.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool ReadNVItem(ushort id, int iLength, IntPtr pData, IntPtr sErrMsg);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("NVManager.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool ReadNVItem_FixPort(string szComPort, ushort id, int iLength, IntPtr pData, IntPtr sErrMsg);
        public static bool ReadNVItemValue(ushort id, int iLength, ref string sValue, ref string sErrMsg)
        {
            sValue = "";
            bool flag = false;
            IntPtr ptr = Marshal.AllocHGlobal(0x100);
            IntPtr pData = Marshal.AllocHGlobal(iLength);
            try
            {
                flag = ReadNVItem(id, iLength, pData, ptr);
            }
            catch (Exception exception)
            {
                sErrMsg = "Exception:" + exception.Message;
                Marshal.FreeHGlobal(ptr);
                Marshal.FreeHGlobal(pData);
                MessageBox.Show("Catch error = " + sErrMsg);
                return false;
            }
            if (flag)
            {
                sValue = Marshal.PtrToStringAnsi(pData);
                Marshal.FreeHGlobal(ptr);
                Marshal.FreeHGlobal(pData);
                return true;
            }
            sErrMsg = Marshal.PtrToStringAnsi(ptr);
            Marshal.FreeHGlobal(ptr);
            Marshal.FreeHGlobal(pData);
            MessageBox.Show("ReadNV_QMSL_Byte failed, sErrMsg = " + sErrMsg);
            return false;
        }

        public static bool ReadNVItemValue_FixPort(string comPort, ushort id, int iLength, ref string sValue, ref string sErrMsg)
        {
            sValue = "";
            bool flag = false;
            IntPtr ptr = Marshal.AllocHGlobal(0x100);
            IntPtr pData = Marshal.AllocHGlobal(iLength);
            try
            {
                flag = ReadNVItem_FixPort(comPort, id, iLength, pData, ptr);
            }
            catch (Exception exception)
            {
                sErrMsg = "Exception:" + exception.Message;
                Marshal.FreeHGlobal(ptr);
                Marshal.FreeHGlobal(pData);
                return false;
            }
            if (!flag)
            {
                sErrMsg = Marshal.PtrToStringAnsi(ptr);
                Marshal.FreeHGlobal(ptr);
                Marshal.FreeHGlobal(pData);
                return false;
            }
            sValue = Marshal.PtrToStringAnsi(pData);
            Marshal.FreeHGlobal(ptr);
            Marshal.FreeHGlobal(pData);
            return true;
        }

        public static bool ReadOptionFile(ref CommonStructure.OptionData ini)
        {
            string str2;
            string strFileName = "";
            strFileName = Directory.GetCurrentDirectory() + @"\Option.ini";
            CIniFile file = new CIniFile(strFileName);
            string path = "";
            ReadIniSettings settings = new ReadIniSettings();
            if (!File.Exists(strFileName))
            {
                return false;
            }
            ini.MDCSEnable = file.ReadString("MDCS", "Enable");
            ini.MDCSURL = file.ReadString("MDCS", "URL");
            if ((ini.MDCSEnable != "0") && (ini.MDCSEnable != "1"))
            {
                return false;
            }
            if (ini.MDCSURL == "")
            {
                return false;
            }
            ini.FlashPath = file.ReadString("Flash", "Path");
            if (ini.FlashPath == "")
            {
                return false;
            }
            ini.Location = file.ReadString("Location", "Usage");
            if (ini.Location == "")
            {
                return false;
            }
            if (Program.g_str_SKU != "CT60")
            {
                if (Program.g_str_SKU != "CN80")
                {
                    ini.LogPath = "";
                    ini.QCNRestorePath = "";
                    ini.QCNBackupPath = "";
                    return false;
                }
                str2 = settings.ReadPrivateProfileStringKey("CN80", "Log_Path", path);
                if ((str2 == "Error") || (str2 == ""))
                {
                    MessageBox.Show("Error: Translate setting", "INI Error");
                    return false;
                }
                ini.LogPath = str2;
                str2 = settings.ReadPrivateProfileStringKey("CN80", "QCN_RemoteRestorePath", path);
                if ((str2 == "Error") || (str2 == ""))
                {
                    MessageBox.Show("Error: Translate setting", "INI Error");
                    return false;
                }
                ini.QCNRestorePath = str2;
                str2 = settings.ReadPrivateProfileStringKey("CN80", "QCN_BackupPath", path);
                if ((str2 == "Error") || (str2 == ""))
                {
                    MessageBox.Show("Error: Translate setting", "INI Error");
                    return false;
                }
                ini.QCNBackupPath = str2;
            }
            else
            {
                str2 = settings.ReadPrivateProfileStringKey("CT60", "Log_Path", path);
                if (str2 == "Error")
                {
                    goto TR_0005;
                }
                else if (str2 != "")
                {
                    ini.LogPath = str2;
                    str2 = settings.ReadPrivateProfileStringKey("CT60", "QCN_RemoteRestorePath", path);
                    if (str2 == "Error")
                    {
                        goto TR_0006;
                    }
                    else if (str2 != "")
                    {
                        ini.QCNRestorePath = str2;
                        str2 = settings.ReadPrivateProfileStringKey("CT60", "QCN_BackupPath", path);
                        if (str2 == "Error")
                        {
                            goto TR_0007;
                        }
                        else if (str2 != "")
                        {
                            ini.QCNBackupPath = str2;
                        }
                        else
                        {
                            goto TR_0007;
                        }
                    }
                    else
                    {
                        goto TR_0006;
                    }
                }
                else
                {
                    goto TR_0005;
                }
            }
            return true;
        TR_0005:
            MessageBox.Show("Error: Translate setting", "INI Error");
            return false;
        TR_0006:
            MessageBox.Show("Error: Translate setting", "INI Error");
            return false;
        TR_0007:
            MessageBox.Show("Error: Translate setting", "INI Error");
            return false;
        }

        public static string ReadQcnBackupPath(string model)
        {
            string path = "";
            string str2 = "";
            ReadIniSettings settings = new ReadIniSettings();
            path = Application.StartupPath + @"\Option.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Error: Can not locate " + path, "INI Error");
                return "";
            }
            string str3 = model;
            if (str3 != null)
            {
                if (str3 == "EDA50_N")
                {
                    str2 = settings.ReadPrivateProfileStringKey("EDA50_N", "QCN_BackupPath", path);
                    goto TR_0004;
                }
                else if (str3 == "EDA50K_N")
                {
                    str2 = settings.ReadPrivateProfileStringKey("EDA50K_N", "QCN_BackupPath", path);
                    goto TR_0004;
                }
                else if (str3 == "HUANG_N")
                {
                    str2 = settings.ReadPrivateProfileStringKey("Huang_N", "QCN_BackupPath", path);
                    goto TR_0004;
                }
                else if (str3 == "HENGS_N")
                {
                    str2 = settings.ReadPrivateProfileStringKey("HengS_N", "QCN_BackupPath", path);
                    goto TR_0004;
                }
                else if (str3 == "HUSA_N")
                {
                    str2 = settings.ReadPrivateProfileStringKey("HuaS_N", "QCN_BackupPath", path);
                    goto TR_0004;
                }
            }
            str2 = "";
        TR_0004:
            if ((str2 != "Error") && (str2 != ""))
            {
                return str2;
            }
            MessageBox.Show("Error: Translate setting", "INI Error");
            return "";
        }

        /*public static string ReadQcnRemoteRestorePath(string model)
        {
            string str2;
            string path = "";
            ReadIniSettings settings = new ReadIniSettings();
            path = Application.StartupPath + @"\Option.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Error: Can not locate " + path, "INI Error");
                return "";
            }
            string key = model;
            if (key != null)
            {
                int num;
                if (< PrivateImplementationDetails >{ 8E12E5D5 - F4C1 - 4C01 - 879D - D481E47DBA75}.$$method0x6000072 - 1 == null)
                {
                    Dictionary<string, int> dictionary1 = new Dictionary<string, int>(7);
                    dictionary1.Add("EDA50_N", 0);
                    dictionary1.Add("EDA50K_N", 1);
                    dictionary1.Add("HUANG_N", 2);
                    dictionary1.Add("HENGS_N", 3);
                    dictionary1.Add("HUSA_N", 4);
                    dictionary1.Add("CT60", 5);
                    dictionary1.Add("CN80", 6);
                    < PrivateImplementationDetails >{ 8E12E5D5 - F4C1 - 4C01 - 879D - D481E47DBA75}.$$method0x6000072 - 1 = dictionary1;
                }
                if (< PrivateImplementationDetails >{ 8E12E5D5 - F4C1 - 4C01 - 879D - D481E47DBA75}.$$method0x6000072 - 1.TryGetValue(key, out num))
                {
                    switch (num)
                    {
                        case 0:
                            str2 = settings.ReadPrivateProfileStringKey("EDA50_N", "QCN_RemoteRestorePath", path);
                            goto TR_0003;

                        case 1:
                            str2 = settings.ReadPrivateProfileStringKey("EDA50K_N", "QCN_RemoteRestorePath", path);
                            goto TR_0003;

                        case 2:
                            str2 = settings.ReadPrivateProfileStringKey("Huang_N", "QCN_RemoteRestorePath", path);
                            goto TR_0003;

                        case 3:
                            str2 = settings.ReadPrivateProfileStringKey("HengS_N", "QCN_RemoteRestorePath", path);
                            goto TR_0003;

                        case 4:
                            str2 = settings.ReadPrivateProfileStringKey("HuaS_N", "QCN_RemoteRestorePath", path);
                            goto TR_0003;

                        case 5:
                            str2 = settings.ReadPrivateProfileStringKey("CT60", "QCN_RemoteRestorePath", path);
                            goto TR_0003;

                        case 6:
                            str2 = settings.ReadPrivateProfileStringKey("CN80", "QCN_RemoteRestorePath", path);
                            goto TR_0003;

                        default:
                            break;
                    }
                }
            }
            str2 = "";
        TR_0003:
            if (str2 != "Error")
            {
                return str2;
            }
            MessageBox.Show("Error: Translate setting", "INI Error");
            return "";
        }
        */ 


        public static string ReadSwImgPath()
        {
            string path = "";
            ReadIniSettings settings = new ReadIniSettings();
            path = Application.StartupPath + @"\Option.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Error: Can not locate " + path, "INI Error");
                return "";
            }
            string str2 = settings.ReadPrivateProfileStringKey("Flash", "Path", path);
            if (str2 != "Error")
            {
                return str2;
            }
            MessageBox.Show("Error: Translate setting", "INI Error");
            return "";
        }

        public static bool ReadTranslationSettings()
        {
            ReadIniSettings settings = new ReadIniSettings();
            string path = Application.StartupPath + @"\Option.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Error: Can not locate " + path, "INI Error");
                return false;
            }
            string str2 = settings.ReadPrivateProfileStringKey("Translate", "enabled", path);
            if (str2 != "Error")
            {
                return (str2 == "1");
            }
            MessageBox.Show("Error: Translate setting", "INI Error");
            return false;
        }

        public static long StartTimeInTicks() =>
            DateTime.Now.Ticks;

       /* public static bool syncNV2MDB(ref string errMsg)
        {
            foreach (Process process in Process.GetProcessesByName("QPSTServer"))
            {
                try
                {
                    process.Kill();
                }
                catch (Exception)
                {
                }
            }
            Thread.Sleep(0xbb8);
            byte[] data = new byte[9];
            byte[] imei = new byte[15];
            byte[] buffer3 = new byte[7];
            string sErrMsg = "";
            int seconds = 100;
            bool flag = false;
            int num2 = 0;
            while (true)
            {
                if (num2 < 10)
                {
                    if ((!Initialize(ref sErrMsg) && (sErrMsg != "")) && sErrMsg.Contains("QLIB_IsPhoneConnected fail"))
                    {
                        num2++;
                        continue;
                    }
                    flag = true;
                }
                if (!flag)
                {
                    UnInitialize();
                    errMsg = "QLIB init failed";
                    return false;
                }
                if (!IsConnected(ref sErrMsg))
                {
                    int num3 = 0;
                    while (num3 < 10)
                    {
                        if (!Initialize(ref sErrMsg))
                        {
                            if (num3 != 10)
                            {
                                Thread.Sleep(0x3e8);
                                num3++;
                                continue;
                            }
                            if ((sErrMsg != "") && sErrMsg.Contains("QLIB_IsPhoneConnected fail"))
                            {
                                break;
                            }
                        }
                        flag = true;
                        break;
                    }
                }
                if (!ReadNVByte(0x797, buffer3, 7, ref sErrMsg))
                {
                    errMsg = sErrMsg;
                    return false;
                }
                Execute("adb shell su 0 mfg-tool -u MEID_NUMBER=" + byteToHexStr(buffer3), seconds);
                if (!ReadNVByte(550, data, 9, ref sErrMsg))
                {
                    errMsg = sErrMsg;
                    return false;
                }
                string str4 = "";
                if (!nv_to_imei(imei, data))
                {
                    return false;
                }
                for (int i = 0; i < 15; i++)
                {
                    str4 = str4 + imei[i].ToString();
                }
                Execute("adb shell su 0 mfg-tool -u IMEI_NUMBER=" + str4, seconds);
                UnInitialize();
                return true;
            }
        }
        */
      /*  private static bool TestVerifyRF(string sn)
        {
            string sValue = "";
            string sErrorMessage = "";
            ReadLocation();
            bool flag = false;
            if (Program.g_str_Model.CompareTo("EDA50_N") == 0)
            {
                flag = GetMDCSFailCode(CSaveDataMDCS.EDA50_N_RF_LINE_NAME, sn, ref sValue, ref sErrorMessage);
            }
            else if (Program.g_str_Model.CompareTo("EDA50K_N") == 0)
            {
                flag = GetMDCSFailCode(CSaveDataMDCS.EDA50K_N_RF_LINE_NAME, sn, ref sValue, ref sErrorMessage);
            }
            else if (Program.g_str_Model.CompareTo("HUANG_N") == 0)
            {
                flag = GetMDCSFailCode(CSaveDataMDCS.HUANG_N_RF_LINE_NAME, sn, ref sValue, ref sErrorMessage);
            }
            else if (Program.g_str_Model.CompareTo("HENGS_N") == 0)
            {
                flag = GetMDCSFailCode(CSaveDataMDCS.HENGS_N_RF_LINE_NAME, sn, ref sValue, ref sErrorMessage);
            }
            else if (Program.g_str_Model.CompareTo("HUSA_N") == 0)
            {
                flag = GetMDCSFailCode(CSaveDataMDCS.HUAS_N_RF_LINE_NAME, sn, ref sValue, ref sErrorMessage);
            }
            else
            {
                if (Program.g_str_Model.CompareTo("CT40") != 0)
                {
                    return false;
                }
                flag = GetMDCSFailCode(CSaveDataMDCS.CT40_N_RF_LINE_NAME, sn, ref sValue, ref sErrorMessage);
            }
            return (flag ? (sValue == "0") : false);
        } */

        public static void UnInitialize()
        {
            UnInitialize_QMSL();
        }

        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("NVManager.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool UnInitialize_QMSL();
        public static bool WriteHsmSN2IniFile(string hsmSN)
        {
            string strFileName = Directory.GetCurrentDirectory() + @"\TestSetting.ini";
            CIniFile file = new CIniFile(strFileName);
            if (!File.Exists(strFileName))
            {
                MessageBox.Show("File not found." + strFileName);
                return false;
            }
            file.Write("Setting", "HsmSN", hsmSN);
            return true;
        }
    }
}

