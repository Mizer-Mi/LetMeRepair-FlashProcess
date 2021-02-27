
namespace LetMeRepair___Flash_Process
{
    using CommonClass;
    using CommonStructure;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;


    public partial class ct60_40_80 : Form
    {
        public const int ONLY_READ_DATA = 0;
        public const int CHECK_WRITE_DATA = 1;
        public const int CHECK_RESULT_DATA = -1;
   
        private ProgressBar pbrProgress;
        private GroupBox groupBox1;
  
        private int wait_ms = 100;
        private string output = "";
        public string g_msgString = "";
        private string sn = "";
        private string mn = "";
        private string pn = "";
        private string cn = "";
        private string ba = "";
        private string wma = "";
        private string imein = "";
        private string meidn = "";
        private string al = "";
        private mfgData m_mfgData;
        private mfgData m_OriginalData;

        public ct60_40_80()
        {
            this.InitializeComponent();
            this.m_OriginalData = new mfgData();
        }

        private void btnReadMFG_Click(object sender, EventArgs e)
        {
            this.btnReadMFG.Enabled = false;
            this.btnWriteMFG.Enabled = false;
            this.ClearText();
            this.WriteTestReportHeader();
            if (!CUtil.bCheckADBIsConnected())
            {
                this.DisplayMessage("Please check adb connected successfully!");
                this.WriteTestReportBooter();
                FrmMFGEditorRlt rlt = new FrmMFGEditorRlt(false);
                rlt.ShowDialog();
                rlt.Dispose();
            }
            else
            {
                this.ReadMFGData();
                this.copyMfgData(ref this.m_OriginalData);
                this.DisplayMessage("Read data finished!");
                this.WriteTestReportBooter();
                FrmMFGEditorRlt rlt2 = new FrmMFGEditorRlt(true);
                rlt2.ShowDialog();
                rlt2.Dispose();
                this.SetTextRead();
            }
            this.popUpReplaceDUTDlg();
        }

        private void btnWriteMFG_Click(object sender, EventArgs e)
        {
            this.btnReadMFG.Enabled = false;
            this.btnWriteMFG.Enabled = false;
            this.m_mfgData = new mfgData();
            this.WriteTestReportHeader();
            if (!this.CheckInput())
            {
                this.DisplayMessage("Input is wrong. Please check your input");
                MessageBox.Show("Input is wrong. Please check your input");
            }
            else if ((this.txtConfigNumber.Text.CompareTo(this.txtPartNumber.Text) == 0) || (MessageBox.Show("The input \"Part number\" and \"Configure number\" is not the same!\nDo you want to continue?\n", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.Cancel))
            {
                this.WriteMFGData();
                if (this.CheckMFGData())
                {
                    this.DisplayMessage("Check write data has finished!");
                    this.WriteTestReportBooter();
                    FrmMFGEditorRlt rlt = new FrmMFGEditorRlt(true);
                    rlt.ShowDialog();
                    rlt.Dispose();
                    this.popUpReplaceDUTDlg();
                }
                else
                {
                    this.DisplayMessage("Write data is not match read data.");
                    this.WriteTestReportBooter();
                    FrmMFGEditorRlt rlt2 = new FrmMFGEditorRlt(false);
                    rlt2.ShowDialog();
                    rlt2.Dispose();
                    this.popUpReplaceDUTDlg();
                }
            }
        }

        private bool CheckInput()
        {
            if (((this.txtSerialNumber.Text.Trim().Length != 10) || ((this.txtPartNumber.Text.Trim().Length > 0x12) || ((this.txtConfigNumber.Text.Trim().Length > 20) || ((this.txtSecBTAddress.Text.Trim().Length > 12) || ((this.txtBluetoothAddress.Text.Trim().Length > 12) || ((this.txtWlanMacAddress.Text.Trim().Length > 12) || ((this.txtIMEINumber.Text.Trim().Length > 0x10) || ((this.txtMEIDNumber.Text.Trim().Length > 14) || ((this.txtSecWifiAddress.Text.Trim().Length > 12) || (this.txtSerialNumber.Text.Trim() == "")))))))))) || !this.TextboxCheck())
            {
                return ((Program.g_str_Model == "CN80") && ((this.txtZigBeeAddress.Text.Trim().Length > 0x10) && false));
            }
            return true;
        }

        public bool CheckMFGData()
        {
            string command = "adb shell su 0 mfg-tool -g EX_CONFIGURATION_NUMBER";
            this.m_mfgData.cn = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.cn = this.removeEmpty(this.m_mfgData.cn);
            this.DisplayMessage("Command = " + command + ", value = " + this.m_mfgData.cn);
            command = "adb shell su 0 mfg-tool -g EX_SERIAL_NUMBER";
            this.m_mfgData.sn = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.sn = this.removeEmpty(this.m_mfgData.sn);
            this.DisplayMessage("Command = " + command + ", value = " + this.m_mfgData.sn);
            command = "adb shell su 0 mfg-tool -g EX_PART_NUMBER";
            this.m_mfgData.pn = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.pn = this.removeEmpty(this.m_mfgData.pn);
            this.DisplayMessage("Command = " + command + ", value = " + this.m_mfgData.pn);
            command = "adb shell su 0 mfg-tool -g WLAN_MAC_ADDRESS";
            this.m_mfgData.MAC = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.MAC = this.removeEmpty(this.m_mfgData.MAC);
            command = "adb shell su 0 mfg-tool -g WLAN_AUX_MAC_ADDRESS";
            this.m_mfgData.SecMAC = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.SecMAC = this.removeEmpty(this.m_mfgData.SecMAC);
            command = "adb shell su 0 mfg-tool -g BLUETOOTH_DEVICE_ADDRESS";
            this.m_mfgData.BDA = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.BDA = this.removeEmpty(this.m_mfgData.BDA);
            command = "adb shell su 0 mfg-tool -g SECOND_BLUETOOTH_DEVICE_ADDRESS";
            this.m_mfgData.SecBDA = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.SecBDA = this.removeEmpty(this.m_mfgData.SecBDA);
            command = "adb shell su 0 mfg-tool -g ZIGBEE_DEVICE_ADDRESS";
            this.m_mfgData.ZigBeeAddress = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.ZigBeeAddress = this.removeEmpty(this.m_mfgData.ZigBeeAddress);
            command = "adb shell su 0 mfg-tool -g MODEL_NUMBER";
            this.m_mfgData.modelNumber = this.Execute(command, this.wait_ms, true);
            this.m_mfgData.modelNumber = this.removeEmpty(this.m_mfgData.modelNumber);
            this.DisplayMessage("Command = " + command + ", value = " + this.m_mfgData.modelNumber);
            command = "adb shell getprop ro.hsm.imei.num";
            this.m_mfgData.IMEI = this.Execute(command, this.wait_ms, true);
            command = "adb shell getprop ro.hsm.meid.num";
            this.m_mfgData.MEID = this.Execute(command, this.wait_ms, true);
            if ((this.m_OriginalData.cn != this.removeEmpty(this.txtConfigNumber.Text)) && (this.removeEmpty(this.txtConfigNumber.Text) != this.m_mfgData.cn))
            {
                this.DisplayMessage("Error:CN not matching!");
                return false;
            }
            if ((this.m_OriginalData.sn != this.removeEmpty(this.txtSerialNumber.Text)) && (this.removeEmpty(this.txtSerialNumber.Text) != this.m_mfgData.sn))
            {
                this.DisplayMessage("Error:SN not matching!");
                return false;
            }
            if ((this.m_OriginalData.pn != this.removeEmpty(this.txtPartNumber.Text)) && (this.removeEmpty(this.txtPartNumber.Text) != this.m_mfgData.pn))
            {
                this.DisplayMessage("Error:PN not matching!");
                return false;
            }
            if ((this.m_OriginalData.MAC != this.removeEmpty(this.txtWlanMacAddress.Text)) && (this.removeEmpty(this.txtWlanMacAddress.Text) != this.m_mfgData.MAC))
            {
                this.DisplayMessage("Error:Wlan Mac Address not matching!");
                return false;
            }
            if ((this.m_OriginalData.SecMAC != this.removeEmpty(this.txtSecWifiAddress.Text)) && (this.removeEmpty(this.txtSecWifiAddress.Text) != this.m_mfgData.SecMAC))
            {
                this.DisplayMessage("Error:Second Wlan Mac Address not matching!");
                return false;
            }
            if ((this.m_OriginalData.BDA != this.removeEmpty(this.txtBluetoothAddress.Text)) && (this.removeEmpty(this.txtBluetoothAddress.Text) != this.m_mfgData.BDA))
            {
                this.DisplayMessage("Error:Bluetooth Address not matching!");
                return false;
            }
            if ((this.m_OriginalData.SecBDA != this.removeEmpty(this.txtSecBTAddress.Text)) && (this.removeEmpty(this.txtSecBTAddress.Text) != this.m_mfgData.SecBDA))
            {
                this.DisplayMessage("Error:Second Bluetooth Address not matching!");
                return false;
            }
            if (((Program.g_str_Model != "CN80") || (this.m_OriginalData.ZigBeeAddress == this.removeEmpty(this.txtZigBeeAddress.Text))) || (this.removeEmpty(this.txtZigBeeAddress.Text) == this.m_mfgData.ZigBeeAddress))
            {
                return true;
            }
            this.DisplayMessage("Error:ZigBee Address not matching!");
            return false;
        }

        private bool CheckRunCmd(string outStr, string cmdStr) =>
            ((outStr != "") ? ((outStr.Length <= 0) || (outStr.IndexOf(cmdStr) >= 0)) : false);

        public void ClearText()
        {
            this.txtSerialNumber.Clear();
            this.txtModelNumber.Clear();
            this.txtPartNumber.Clear();
            this.txtConfigNumber.Clear();
            this.txtSecBTAddress.Clear();
            this.txtBluetoothAddress.Clear();
            this.txtWlanMacAddress.Clear();
            this.txtIMEINumber.Clear();
            this.txtMEIDNumber.Clear();
            this.txtSecWifiAddress.Clear();
            this.txtSecBTAddress.Clear();
            if (Program.g_str_Model == "CN80")
            {
                this.txtZigBeeAddress.Clear();
            }
        }

        private void copyMfgData(ref mfgData data)
        {
            data.cn = this.removeEmpty(this.txtConfigNumber.Text);
            data.sn = this.removeEmpty(this.txtSerialNumber.Text);
            data.pn = this.removeEmpty(this.txtPartNumber.Text);
            data.MAC = this.removeEmpty(this.txtWlanMacAddress.Text);
            data.SecMAC = this.removeEmpty(this.txtSecWifiAddress.Text);
            data.BDA = this.removeEmpty(this.txtBluetoothAddress.Text);
            data.SecBDA = this.removeEmpty(this.txtSecBTAddress.Text);
            if (Program.g_str_Model == "CN80")
            {
                data.ZigBeeAddress = this.removeEmpty(this.txtZigBeeAddress.Text);
            }
        }

        private void DisplayMessage(string str_Message)
        {
            if (str_Message != "")
            {
                if (!this.rtb_TestResults.IsDisposed)
                {
                    this.rtb_TestResults.AppendText(str_Message + Convert.ToChar(13) + Convert.ToChar(10));
                    this.rtb_TestResults.ScrollToCaret();
                    this.rtb_TestResults.Refresh();
                }
                Application.DoEvents();
            }
        }

      
        public string Execute(string command, int seconds, bool runcmd)
        {
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
                    info.FileName = "install.bat";
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
                        this.output = process.StandardOutput.ReadToEnd();
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
            return this.output;
        }

        private void FrmMFGEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Execute("adb kill-server", 100, true);
        }

        private void FrmMFGEditor_Load(object sender, EventArgs e)
        {
            this.ClearText();
            this.txtSerialNumber.ForeColor = Color.Black;
            this.txtSerialNumber.Text = "Max 10 chars";
            this.txtModelNumber.ForeColor = Color.Gray;
            this.txtModelNumber.Text = "Max 4 chars";
            this.txtPartNumber.ForeColor = Color.Black;
            this.txtPartNumber.Text = "Max 18 chars";
            this.txtConfigNumber.ForeColor = Color.Black;
            this.txtConfigNumber.Text = "Max 20 chars";
            this.txtBluetoothAddress.ForeColor = Color.Gray;
            this.txtBluetoothAddress.Text = "Max 12 chars";
            this.txtSecBTAddress.ForeColor = Color.Gray;
            this.txtSecBTAddress.Text = "Max 12 chars";
            this.txtWlanMacAddress.ForeColor = Color.Gray;
            this.txtWlanMacAddress.Text = "Max 12 chars";
            this.txtSecWifiAddress.ForeColor = Color.Gray;
            this.txtSecWifiAddress.Text = "Max 12 chars";
            this.txtIMEINumber.ForeColor = Color.Gray;
            this.txtIMEINumber.Text = "Max 15 chars";
            this.txtMEIDNumber.ForeColor = Color.Gray;
            this.txtMEIDNumber.Text = "Max 14 chars";
            this.rtb_TestResults.Select();
            this.rtb_TestResults.Clear();
            if ((Program.g_str_Model == "CT60") || (Program.g_str_Model == "CT40"))
            {
                this.txtZigBeeAddress.Visible = false;
                this.lblZigBee.Visible = false;
            }
            else
            {
                this.txtZigBeeAddress.Visible = true;
                this.lblZigBee.Visible = true;
                this.txtZigBeeAddress.ForeColor = Color.Gray;
                this.txtZigBeeAddress.Text = "Max 16 chars";
            }
        }

        private void GetTextBoxData()
        {
        }

        
        private void MFGEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void popUpReplaceDUTDlg()
        {
            if (MessageBox.Show("Do you want to continue edit this unit?\n\n(Please change new DUT before 'click No')", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DisplayMessage("Run next unit");
                base.Close();
            }
            else
            {
                this.btnReadMFG.Enabled = true;
                this.btnWriteMFG.Enabled = true;
            }
        }

        public bool ReadMFGData()
        {
            string command = "adb shell su 0 mfg-tool -g EX_CONFIGURATION_NUMBER";
            this.Execute(command, this.wait_ms, true);
            command = "adb shell su 0 mfg-tool -g EX_CONFIGURATION_NUMBER";
            this.txtConfigNumber.Text = this.Execute(command, this.wait_ms, true);
            this.DisplayMessage("Command = " + command + ", value = " + this.txtConfigNumber.Text);
            command = "adb shell su 0 mfg-tool -g EX_SERIAL_NUMBER";
            this.txtSerialNumber.Text = this.Execute(command, this.wait_ms, true);
            this.DisplayMessage("Command = " + command + ", value = " + this.txtSerialNumber.Text);
            command = "adb shell su 0 mfg-tool -g EX_PART_NUMBER";
            this.txtPartNumber.Text = this.Execute(command, this.wait_ms, true);
            this.DisplayMessage("Command = " + command + ", value = " + this.txtPartNumber.Text);
            command = "adb shell su 0 mfg-tool -g WLAN_MAC_ADDRESS";
            this.txtWlanMacAddress.Text = this.Execute(command, this.wait_ms, true);
            command = "adb shell su 0 mfg-tool -g WLAN_AUX_MAC_ADDRESS";
            this.txtSecWifiAddress.Text = this.Execute(command, this.wait_ms, true);
            command = "adb shell su 0 mfg-tool -g BLUETOOTH_DEVICE_ADDRESS";
            this.txtBluetoothAddress.Text = this.Execute(command, this.wait_ms, true);
            command = "adb shell su 0 mfg-tool -g SECOND_BLUETOOTH_DEVICE_ADDRESS";
            this.txtSecBTAddress.Text = this.Execute(command, this.wait_ms, true);
            if (Program.g_str_Model == "CN80")
            {
                command = "adb shell su 0 mfg-tool -g ZIGBEE_DEVICE_ADDRESS";
                this.txtZigBeeAddress.Text = this.Execute(command, this.wait_ms, true);
            }
            command = "adb shell su 0 mfg-tool -g MODEL_NUMBER";
            this.txtModelNumber.Text = this.Execute(command, this.wait_ms, true);
            this.DisplayMessage("Command = " + command + ", value = " + this.txtModelNumber.Text);
            command = "adb shell getprop ro.hsm.imei.num";
            this.txtIMEINumber.Text = this.Execute(command, this.wait_ms, true);
            command = "adb shell getprop ro.hsm.meid.num";
            this.txtMEIDNumber.Text = this.Execute(command, this.wait_ms, true);
            return true;
        }

        private string removeEmpty(string input) =>
            (!input.Contains("\r\n") ? input : input.Substring(0, input.Length - 2));

       

        private void SetTextRead()
        {
            this.txtWlanMacAddress.ReadOnly = this.txtWlanMacAddress.Text.Trim() != "";
            this.txtSecWifiAddress.ReadOnly = this.txtSecWifiAddress.Text.Trim() != "";
            this.txtBluetoothAddress.ReadOnly = this.txtBluetoothAddress.Text.Trim() != "";
            this.txtSecBTAddress.ReadOnly = this.txtSecBTAddress.Text.Trim() != "";
            if (Program.g_str_Model == "CN80")
            {
                if (this.txtZigBeeAddress.Text.Trim() == "")
                {
                    this.txtZigBeeAddress.ReadOnly = false;
                }
                else
                {
                    this.txtZigBeeAddress.ReadOnly = true;
                }
            }
        }

        public bool TextboxCheck()
        {
            if (((this.txtSerialNumber.Text == "Max 10 chars") || ((this.txtPartNumber.Text == "Max 18 chars") || ((this.txtConfigNumber.Text == "Max 20 chars") || ((this.txtModelNumber.Text == "Max 4 chars") || ((this.txtBluetoothAddress.Text == "Max 12 chars") || ((this.txtSecBTAddress.Text == "Max 12 chars") || ((this.txtWlanMacAddress.Text == "Max 12 chars") || ((this.txtSecWifiAddress.Text == "Max 12 chars") || (this.txtMEIDNumber.Text == "Max 14 chars"))))))))) || (this.txtIMEINumber.Text == "Max 16 chars"))
            {
                return ((Program.g_str_Model == "CN80") && (this.txtZigBeeAddress.Text != "Max 16 chars"));
            }
            return true;
        }

        private void txtBluetoothAddress_Enter(object sender, EventArgs e)
        {
            bool flag1 = this.txtBluetoothAddress.Text == "Max 12 chars";
        }

        private void txtConfigNumber_Enter(object sender, EventArgs e)
        {
            this.txtConfigNumber.ForeColor = Color.Black;
            if (this.txtConfigNumber.Text == "Max 20 chars")
            {
                this.txtConfigNumber.Text = "";
            }
        }

        private void txtPartNumber_Enter(object sender, EventArgs e)
        {
            this.txtPartNumber.ForeColor = Color.Black;
            if (this.txtPartNumber.Text == "Max 18 chars")
            {
                this.txtPartNumber.Text = "";
            }
        }

        private void txtSerialNumber_Enter(object sender, EventArgs e)
        {
            this.txtSerialNumber.ForeColor = Color.Black;
            if (this.txtSerialNumber.Text == "Max 10 chars")
            {
                this.txtSerialNumber.Text = "";
            }
        }

        private void txtSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
        }

        private void txtWlanMacAddress_Enter(object sender, EventArgs e)
        {
            bool flag1 = this.txtWlanMacAddress.Text == "Max 12 chars";
        }

        public bool WriteMFGData()
        {
            string str = null;
            string command = null;
            if (this.m_OriginalData.cn != this.removeEmpty(this.txtConfigNumber.Text))
            {
                command = "adb shell su 0 mfg-tool -u EX_CONFIGURATION_NUMBER=" + this.txtConfigNumber.Text;
                str = this.Execute(command, this.wait_ms, true);
                this.DisplayMessage("Command = " + command + ", result = " + str);
            }
            if (this.m_OriginalData.sn != this.removeEmpty(this.txtSerialNumber.Text))
            {
                command = "adb shell su 0 mfg-tool -u EX_SERIAL_NUMBER=" + this.txtSerialNumber.Text;
                str = this.Execute(command, this.wait_ms, true);
                this.DisplayMessage("Command = " + command + ", result = " + str);
            }
            if (this.m_OriginalData.pn != this.removeEmpty(this.txtPartNumber.Text))
            {
                command = "adb shell su 0 mfg-tool -u EX_PART_NUMBER=" + this.txtPartNumber.Text;
                str = this.Execute(command, this.wait_ms, true);
                this.DisplayMessage("Command = " + command + ", result = " + str);
            }
            if (this.m_OriginalData.MAC != this.removeEmpty(this.txtWlanMacAddress.Text))
            {
                command = "adb shell su 0 mfg-tool -u WLAN_MAC_ADDRESS=" + this.txtWlanMacAddress.Text;
                str = this.Execute(command, this.wait_ms, true);
                this.DisplayMessage("Command = " + command + ", result = " + str);
            }
            if (this.m_OriginalData.SecMAC != this.removeEmpty(this.txtSecWifiAddress.Text))
            {
                command = "adb shell su 0 mfg-tool -u WLAN_AUX_MAC_ADDRESS=" + this.txtSecWifiAddress.Text;
                this.txtSecWifiAddress.Text = this.Execute(command, this.wait_ms, true);
                this.DisplayMessage("Command = " + command + ", result = " + str);
            }
            if (this.m_OriginalData.BDA != this.removeEmpty(this.txtBluetoothAddress.Text))
            {
                command = "adb shell su 0 mfg-tool -u BLUETOOTH_DEVICE_ADDRESS=" + this.txtBluetoothAddress.Text;
                str = this.Execute(command, this.wait_ms, true);
                this.DisplayMessage("Command = " + command + ", result = " + str);
            }
            if (this.m_OriginalData.SecBDA != this.removeEmpty(this.txtSecBTAddress.Text))
            {
                command = "adb shell su 0 mfg-tool -u SECOND_BLUETOOTH_DEVICE_ADDRESS=" + this.txtSecBTAddress.Text;
                str = this.Execute(command, this.wait_ms, true);
                this.DisplayMessage("Command = " + command + ", result = " + str);
            }
            if ((Program.g_str_Model == "CN80") && (this.m_OriginalData.ZigBeeAddress != this.removeEmpty(this.txtZigBeeAddress.Text)))
            {
                command = "adb shell su 0 mfg-tool -u ZIGBEE_DEVICE_ADDRESS=" + this.txtZigBeeAddress.Text;
                this.DisplayMessage("Command = " + command + ", result = " + this.Execute(command, this.wait_ms, true));
            }
            return true;
        }

        private bool WriteTestReportBooter()
        {
            this.DisplayMessage("EndTime : " + DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("HH:mm:ss"));
            this.DisplayMessage("****************************************  End  **************************************** ");
            return true;
        }

        private bool WriteTestReportHeader()
        {
            string str = DateTime.Now.ToString("yyyy-MM-dd");
            string str2 = DateTime.Now.ToString("HH:mm:ss");
            this.DisplayMessage("****************************************  Start **************************************** ");
            this.DisplayMessage("Timestamp: " + str + " " + str2);
            return true;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1)]
        public struct TD_LicData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x10)]
            public byte[] a_byUuid;
            public uint b_dwSeed;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] c_szSerial;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] d_byZeroFill;
            public uint e_dwCrc;
        }

        private void Ct60_40_80_Load(object sender, EventArgs e)
        {

        }
    }
}
