using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenNETCF.MQTT;
using OpenNETCF.Desktop.Communication;
using System.Threading;
using System.Runtime.InteropServices;

namespace LetMeRepair___Flash_Process
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }











        public string versiyon_bilgisi = "";


        Boolean JETON = true;
        private void Button1_Click(object sender, EventArgs e)
        {
            using (mizer_acilir_Combo comboac = new mizer_acilir_Combo())
            {
                comboac.cihaz_turu = "CK3";
                comboac.ShowDialog();
                if (comboac.DialogResult == DialogResult.OK)
                {
                    versiyon_bilgisi = comboac.comboBox1.SelectedItem.ToString();
                    bekleme_yazisi.Visible = true;
                    pictureBox2.Visible = true;
                    Task task = new Task(delegate { kopyala("\\Flash File Store\\CABFILES\\LetMeRepair-CK3.CAB", "\\Flash File Store\\CABFILES\\CK3-NOWAN-W" + versiyon_bilgisi + ".CAB", "LetMeRepair/LetMeRepair-CK3.CAB", "Su/CK3-NOWAN-W" + versiyon_bilgisi + ".CAB"); });
                    task.Start();
                }
                else
                {
                    MessageBox.Show("Lütfen Versiyon seçiniz", "LetMeRepair");
                }

            }


        }

        private void ex99_fw()
        {
            progressBar1.Value = 0;
            timer1.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Yazılımı Yüklemek istediğine emin misin ?", "LetMeRepair", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (r.DevicePresent)
                    {
                        r.Connect();

                        progressBar1.Visible = true;
                        aktarim_label.Visible = true;
                        bekleme_yazisi.Visible = true;
                        pictureBox2.Visible = true;
                        CN51_WLAN_161.Enabled = false;
                        CK3_161.Enabled = false;
                        CN51_WWAN_161.Enabled = false;
                        CK71_161.Enabled = false;
                        DOLP99_161.Enabled = false;
                        EX25_FW_161.Enabled = false;

                        try { r.RemoveDeviceDirectory("\\IPSM\\Honeywell", true); } catch { }
                        try { r.DeleteDeviceFile("\\IPSM\\XBINKP_26.07_WWE.upg"); } catch { }
                        try { r.CreateDeviceDirectory("\\IPSM\\Honeywell"); } catch { }
                        try { r.CreateDeviceDirectory("\\IPSM\\Honeywell\\AutoInstall"); } catch { }
                        aktarim_label.Text = "Eski Dosyalar Siliniyor...";
                        progressBar1.PerformStep();
                        //// AUTO INSTAL TARAFI
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/CameraDemo_516.wm.armv4i.CAB";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/CameraDemo_516.wm.armv4i.CAB", "\\IPSM\\Honeywell\\AutoInstall\\CameraDemo_516.wm.armv4i.CAB", true);
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/DefaultSettings.reg";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/DefaultSettings.reg", "\\IPSM\\Honeywell\\AutoInstall\\DefaultSettings.reg", true);
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/Demos_516.wm.armv4i.CAB";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/Demos_516.wm.armv4i.CAB", "\\IPSM\\Honeywell\\AutoInstall\\Demos_516.wm.armv4i.CAB", true);
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/Ds172_35.wm.armv4i.CAB";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/Ds172_35.wm.armv4i.CAB", "\\IPSM\\Honeywell\\AutoInstall\\Ds172_35.wm.armv4i.CAB", true);
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/PowerTools_516.wm.armv4i.CAB";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/PowerTools_516.wm.armv4i.CAB", "\\IPSM\\Honeywell\\AutoInstall\\PowerTools_516.wm.armv4i.CAB", true);
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/REM_BootStrap_10.00.1.762.cab";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/REM_BootStrap_10.00.1.762.cab", "\\IPSM\\Honeywell\\AutoInstall\\REM_BootStrap_10.00.1.762.cab", true);
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/SDKNC_321.wm.armv4i.CAB";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/SDKNC_321.wm.armv4i.CAB", "\\IPSM\\Honeywell\\AutoInstall\\SDKNC_321.wm.armv4i.CAB", true);
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/SP_PowerTools_516.3.wm.armv4i.CAB";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/SP_PowerTools_516.3.wm.armv4i.CAB", "\\IPSM\\Honeywell\\AutoInstall\\SP_PowerTools_516.3.wm.armv4i.CAB", true);
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall/WLAN_D99EX_22.CAB";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall/WLAN_D99EX_22.CAB", "\\IPSM\\Honeywell\\AutoInstall\\WLAN_D99EX_22.CAB", true);

                        /// Honeywell TARAFI

                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall.exe";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall.exe", "\\IPSM\\Honeywell\\AutoInstall.exe", true);
                        ///
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/AutoInstall.exm";
                        r.CopyFileToDevice("99EX/Honeywell/AutoInstall.exm", "\\IPSM\\Honeywell\\AutoInstall.exm", true);
                        ///
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/Autorun.exe";
                        r.CopyFileToDevice("99EX/Honeywell/Autorun.exe", "\\IPSM\\Honeywell\\Autorun.exe", true);
                        ///
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/Autorun.exm";
                        r.CopyFileToDevice("99EX/Honeywell/Autorun.exm", "\\IPSM\\Honeywell\\Autorun.exm", true);
                        ////
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/DeviceConfig.exe";
                        r.CopyFileToDevice("99EX/Honeywell/DeviceConfig.exe", "\\IPSM\\Honeywell\\DeviceConfig.exe", true);
                        ///
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/DeviceConfig.exm";
                        r.CopyFileToDevice("99EX/Honeywell/DeviceConfig.exm", "\\IPSM\\Honeywell\\DeviceConfig.exm", true);
                        ///
                        progressBar1.PerformStep();
                        aktarim_label.Text = "99EX/Honeywell/EZConfigPPC.exe";
                        r.CopyFileToDevice("99EX/Honeywell/EZConfigPPC.exe", "\\IPSM\\Honeywell\\EZConfigPPC.exe", true);
                        ///
                        /// XBIN TARAFI
                        /// 
                        progressBar1.PerformStep();
                        aktarim_label.Text = "XBINKP_26.07_WWE.upg || yaklaşık 3 dk.. Bekleyiniz..";
                        r.CopyFileToDevice("99EX/XBINKP_26.07_WWE.upg", "\\IPSM\\XBINKP_26.07_WWE.upg", true);

                        progressBar1.Value = 100;


                        progressBar1.Visible = false;
                        aktarim_label.Visible = false;
                        bekleme_yazisi.Visible = false;
                        pictureBox2.Visible = false;
                        CN51_WLAN_161.Enabled = true;
                        CK3_161.Enabled = true;
                        CN51_WWAN_161.Enabled = true;
                        CK71_161.Enabled = true;
                        DOLP99_161.Enabled = true;
                        EX25_FW_161.Enabled = true;
                        r.CreateProcess("XBINKP_26.07_WWE.upg", null);
                        MessageBox.Show("99EX FW dosyalarının aktarımı Başarılı. Yazılım başlatılıyor...", "LetMeRepair Flash Process");
                        JETON = false;

                        try { r.Disconnect(); } catch { }
                        timer1.Enabled = true;
                        progressBar1.Value = 0;
                        muco_reset_atma();

                    }
                    else
                    {
                        timer1.Enabled = true;
                        progressBar1.Visible = false;
                        aktarim_label.Visible = false;
                        bekleme_yazisi.Visible = false;
                        pictureBox2.Visible = false;
                        CN51_WLAN_161.Enabled = true;
                        CK3_161.Enabled = true;
                        CN51_WWAN_161.Enabled = true;
                        CK71_161.Enabled = true;
                        DOLP99_161.Enabled = true;
                        EX25_FW_161.Enabled = true;
                        JETON = false;
                        MessageBox.Show("Cihaz bağlı değil! - LetMeRepair", "LetMeRepair Flash Process");

                    }
                }
                catch (Exception ex)
                {
                    progressBar1.Visible = false;
                    aktarim_label.Visible = false;
                    bekleme_yazisi.Visible = false;
                    pictureBox2.Visible = false;
                    CN51_WLAN_161.Enabled = true;
                    CK3_161.Enabled = true;
                    CN51_WWAN_161.Enabled = true;
                    CK71_161.Enabled = true;
                    DOLP99_161.Enabled = true;
                    EX25_FW_161.Enabled = true;
                    progressBar1.Value = 0;
                    timer1.Enabled = true;
                    JETON = false;
                    MessageBox.Show(ex.ToString());
                    try { r.Disconnect(); } catch { }

                }


            }
            else if (dialogResult == DialogResult.No)
            {
                timer1.Enabled = true;
            }
            timer1.Enabled = true;

        }

        private void kopyala(String LMR_path2device, String SU_path2device, String LMR_LocalPath, String SU_LocalPath)
        {
            timer1.Enabled = false;
            DialogResult dialogResult = MessageBox.Show("Su ve Cab Dosyalarını atmak istediğine emin misin?", "LetMeRepair", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (r.DevicePresent)
                    {
                        //Aktarım: Kaldıysa r.connectte kalmış demektir.
                        r.Connect();


                        yazilim_modu_giris_WEH_icin();
                        progressBar1.Step = 20;
                        /// Varsa eskileri siliniyor.
                        aktarim_label.Text = "Cihazdaki Dosyalar Doğrulanıyor..";
                        try { r.CreateDeviceDirectory("\\Flash File Store\\CABFILES"); } catch { }
                        try { r.DeleteDeviceFile(LMR_path2device); } catch { }
                        progressBar1.PerformStep();
                        try { r.DeleteDeviceFile(SU_path2device); } catch { }
                        progressBar1.PerformStep();
                        /// İletişim uygulaması
                        aktarim_label.Text = "LetMeRepair İletişim uygulaması atılıyor..";
                        progressBar1.PerformStep();
                        try { r.CopyFileToDevice(LMR_LocalPath, LMR_path2device, true); } catch { }
                        /// İletişim Read-Only
                        progressBar1.PerformStep();
                        aktarim_label.Text = "İşetişim Uygulaması Read-Only yapılıyor...";
                        try { r.SetDeviceFileAttributes(LMR_path2device, RAPI.RAPIFileAttributes.ReadOnly); } catch { }
                        /// Su dosyası atılıyor..
                        progressBar1.PerformStep();
                        aktarim_label.Text = "Su Dosyası Atılıyor...";
                        try { r.CopyFileToDevice(SU_LocalPath, SU_path2device, true); } catch { }


                        DialogResult reboot_sonuc_weh = MessageBox.Show("CAB dosyalarının aktarımı Başarılı. Cihaza REBOOT atılsın mı? ", "LetMeRepair Flash Process", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (reboot_sonuc_weh == DialogResult.OK)
                        {
                            r.CreateProcess("\\Windows\\cmd.exe", "reboot /c");
                        }
                        else
                        {

                        }
                        yazilim_modu_cikis_WEH_icin();

                        try { r.Disconnect(); } catch { }

                        muco_reset_atma();

                    }
                    else
                    {
                        yazilim_modu_cikis_WEH_icin();
                        try
                        {
                            r.Disconnect();
                        }
                        catch { }
                        MessageBox.Show("Cihaz bağlı değil! - LetMeRepair", "LetMeRepair Flash Process");
                        timer1.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    yazilim_modu_cikis_WEH_icin();

                    JETON = false;
                    MessageBox.Show(ex.ToString());
                    try { r.Disconnect(); } catch { }
                    timer1.Enabled = true;


                }
            }
            else if (dialogResult == DialogResult.No)
            {
                timer1.Enabled = true;
            }
            timer1.Enabled = true;


        }

        private void Form1_Load(object sender, EventArgs e)
        {


            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.TopLevel = false;
            this.TopLevel = true;
            this.Activate();

        }

        private void muco_reset_atma()
        {
            GC.Collect();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        }



        RAPI r = new RAPI();
        private void baglanti_trigger()
        {
            if (JETON == false)
            {
                yazilim_modu_cikis_WEH_icin();
                JETON = true;

            }

            if (button5.ForeColor == Color.DarkGreen)
            {
                if (r.DevicePresent)
                {
                    if (CN51_WWAN_161.BackColor == Color.DimGray)
                    {
                        this.Show();
                        this.WindowState = FormWindowState.Normal;
                        this.TopLevel = false;
                        this.TopLevel = true;
                        this.Activate();

                    }


                    CK3_161.BackColor = Color.Lime;
                    CK3_161.Enabled = true;
                    CN51_WLAN_161.BackColor = Color.Lime;
                    CN51_WLAN_161.Enabled = true;
                    CN51_WWAN_161.BackColor = Color.Lime;
                    CN51_WWAN_161.Enabled = true;
                    CK71_161.BackColor = Color.Lime;
                    CK71_161.Enabled = true;
                    DOLP99_161.BackColor = Color.Lime;
                    DOLP99_161.Enabled = true;
                    EX25_FW_161.BackColor = Color.Lime;
                    EX25_FW_161.Enabled = true;
                    iletisim_161.BackColor = Color.Lime;
                    iletisim_161.Enabled = true;
                    try
                    {

                        SYSTEM_POWER_STATUS_EX sps = new SYSTEM_POWER_STATUS_EX();
                        r.GetDeviceSystemPowerStatus(out sps);
                        batarya.Text = sps.BatteryLifePercent.ToString();


                    }
                    catch { };
                    try
                    {

                        SYSTEM_INFO osv = new SYSTEM_INFO();
                        r.GetDeviceSystemInfo(out osv);
                        os_versiyonu.Text = osv.wProcessorArchitecture.ToString();

                    }
                    catch { }
                    r.Disconnect();


                }
                else
                {
                    CK3_161.BackColor = Color.DimGray;
                    CK3_161.Enabled = false;
                    CN51_WLAN_161.BackColor = Color.DimGray;
                    CN51_WLAN_161.Enabled = false;
                    CN51_WWAN_161.BackColor = Color.DimGray;
                    CN51_WWAN_161.Enabled = false;
                    CK71_161.BackColor = Color.DimGray;
                    CK71_161.Enabled = false;
                    DOLP99_161.BackColor = Color.DimGray;
                    DOLP99_161.Enabled = false;
                    EX25_FW_161.BackColor = Color.DimGray;
                    EX25_FW_161.Enabled = false;
                    iletisim_161.BackColor = Color.DimGray;
                    iletisim_161.Enabled = false;


                }

            }



        }

        private void yazilim_modu_giris_WEH_icin()
        {
            progressBar1.Value = 0;
            aktarim_label.Text = "Aktarım Başlayacak.. ";
            progressBar1.Visible = true;
            aktarim_label.Visible = true;
            bekleme_yazisi.Visible = true;
            pictureBox2.Visible = true;
            CN51_WLAN_161.Enabled = false;
            CK3_161.Enabled = false;
            CN51_WWAN_161.Enabled = false;
            CK71_161.Enabled = false;
            DOLP99_161.Enabled = false;
            EX25_FW_161.Enabled = false;
            iletisim_161.Enabled = false;

        }
        private void yazilim_modu_cikis_WEH_icin()
        {
            progressBar1.Visible = false;
            aktarim_label.Visible = false;
            bekleme_yazisi.Visible = false;
            pictureBox2.Visible = false;
            CN51_WLAN_161.Enabled = true;
            CK3_161.Enabled = true;
            CN51_WWAN_161.Enabled = true;
            CK71_161.Enabled = true;
            DOLP99_161.Enabled = true;
            EX25_FW_161.Enabled = true;
            iletisim_161.Enabled = true;
            JETON = false;
            progressBar1.Value = 0;
            aktarim_label.Text = "Aktarım Başlayacak.. ";

        }




        private void Button2_Click(object sender, EventArgs e)
        {
            using (mizer_acilir_Combo comboac = new mizer_acilir_Combo())
            {
                comboac.cihaz_turu = "CN51";
                comboac.ShowDialog();
                if (comboac.DialogResult == DialogResult.OK)
                {
                    versiyon_bilgisi = comboac.comboBox1.SelectedItem.ToString();
                    bekleme_yazisi.Visible = true;
                    pictureBox2.Visible = true;
                    Task task = new Task(delegate { kopyala("\\Flash File Store\\CABFILES\\LetMeRepair-CK3.CAB", "\\Flash File Store\\CABFILES\\CN51-WWAN-W" + versiyon_bilgisi + ".CAB", "LetMeRepair/LetMeRepair-CK3.CAB", "Su/CN51-WWAN-W" + versiyon_bilgisi + ".CAB"); });
                    task.Start();
                }
                else
                {
                    MessageBox.Show("Lütfen Versiyon seçiniz", "LetMeRepair");
                }

            }

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            using (mizer_acilir_Combo comboac = new mizer_acilir_Combo())
            {
                comboac.cihaz_turu = "CN51_WLAN";
                comboac.ShowDialog();
                if (comboac.DialogResult == DialogResult.OK)
                {
                    versiyon_bilgisi = comboac.comboBox1.SelectedItem.ToString();
                    bekleme_yazisi.Visible = true;
                    pictureBox2.Visible = true;
                    Task task = new Task(delegate { kopyala("\\Flash File Store\\CABFILES\\LetMeRepair-CK3.CAB", "\\Flash File Store\\CABFILES\\CN51-NOWAN-W+" + versiyon_bilgisi + "+.CAB", "LetMeRepair/LetMeRepair-CK3.CAB", "Su/CN51-NOWAN-W" + versiyon_bilgisi + ".CAB"); });
                    task.Start();
                }
                else
                {
                    MessageBox.Show("Lütfen Versiyon seçiniz", "LetMeRepair");
                }

            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (mizer_acilir_Combo comboac = new mizer_acilir_Combo())
            {
                comboac.cihaz_turu = "CK71";
                comboac.ShowDialog();
                if (comboac.DialogResult == DialogResult.OK)
                {
                    versiyon_bilgisi = comboac.comboBox1.SelectedItem.ToString();
                    bekleme_yazisi.Visible = true;
                    pictureBox2.Visible = true;
                    Task task = new Task(delegate { kopyala("\\Flash File Store\\CABFILES\\LetMeRepair-CK3.CAB", "\\Flash File Store\\CABFILES\\CK71-NOWAN-W" + versiyon_bilgisi + ".CAB", "LetMeRepair/LetMeRepair-CK3.CAB", "Su/CK71-NOWAN-W" + versiyon_bilgisi + ".CAB"); });
                    task.Start();
                }
                else
                {
                    MessageBox.Show("Lütfen Versiyon seçiniz", "LetMeRepair");
                }

            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            baglanti_trigger();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            aktarim_label.Visible = true;
            bekleme_yazisi.Visible = true;
            pictureBox2.Visible = true;
            Task task = new Task(delegate { ex99_fw(); });
            task.Start();




        }

        private void Aktarim_label_Click(object sender, EventArgs e)
        {

        }

        private void HakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LetMeRepair Flash Process SU,FW ve LMR yazılımlarını kolay yoldan atmak için Kodlanmıştır.", "Mizer-LetMeRepair");

        }

        private void GösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.TopLevel = false;
            this.TopLevel = true;
        }

        private void ÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "LetMeRepair Flash Process", "LetMeRepair Flash Process Altta çalışmaya devam ediyor.", ToolTipIcon.Info);
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.TopLevel = false;
            this.TopLevel = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                button5.ForeColor = Color.Red;
                button5.Text = "Oto Fonksiyonlar = Kapalı";
                CK3_161.BackColor = Color.DarkRed;
                CK3_161.Enabled = true;
                CN51_WLAN_161.BackColor = Color.DarkRed;
                CN51_WLAN_161.Enabled = true;
                CN51_WWAN_161.BackColor = Color.DarkRed;
                CN51_WWAN_161.Enabled = true;
                CK71_161.BackColor = Color.DarkRed;
                CK71_161.Enabled = true;
                DOLP99_161.BackColor = Color.DarkRed;
                DOLP99_161.Enabled = true;
                EX25_FW_161.Enabled = true;
                EX25_FW_161.ForeColor = Color.DarkRed;
                iletisim_161.Enabled = true;
                iletisim_161.ForeColor = Color.DarkRed;
                timer1.Enabled = false;
            }
            else
            {
                button5.Text = "Oto Fonksiyonlar = Açık";
                button5.ForeColor = Color.DarkGreen;
                timer1.Enabled = true;
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void AyarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Ayarlar frm_ayr = new Ayarlar())
            {
                frm_ayr.ShowDialog();



            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            using (Ayarlar frm_ayr = new Ayarlar())
            {
                frm_ayr.ShowDialog();



            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.sistem_icon_gecis == true)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(1000, "LetMeRepair Flash Process", "LetMeRepair Flash Process Altta çalışmaya devam ediyor.", ToolTipIcon.Info);
                    this.Hide();
                    e.Cancel = true;
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            bekleme_yazisi.Visible = true;
            pictureBox2.Visible = true;
            Task task = new Task(delegate { kopyala("\\Flash File Store\\CABFILES\\LetMeRepair-CK3.CAB", "\\Flash File Store\\CABFILES\\EX25-FW-LetMeRepair.CAB", "LetMeRepair/LetMeRepair-CK3.CAB", "Su/EX25-FW-LetMeRepair.CAB"); });
            task.Start();
        }

        private void İletisim_161_Click(object sender, EventArgs e)
        {
            bekleme_yazisi.Visible = true;
            pictureBox2.Visible = true;
            Task task = new Task(delegate { kopyala("\\Flash File Store\\CABFILES\\LetMeRepair-CK3.CAB", "", "LetMeRepair/LetMeRepair-CK3.CAB", ""); });
            task.Start();
        }

        private void Button1_Click_2(object sender, EventArgs e)
        {
            using (imeidenhexe_mizer frm_hx = new imeidenhexe_mizer())
            {
                frm_hx.ShowDialog();
            }
        }

        private void Button19_Click(object sender, EventArgs e)
        {
            /*using (mizer_model_combo comboac = new mizer_model_combo())
            {
               
                comboac.ShowDialog();
                if (comboac.DialogResult == DialogResult.OK)
                {
                    Program.g_str_Model = comboac.comboBox1.SelectedItem.ToString();

                    using (ct60_40_80 frm_Ac2 = new ct60_40_80())
                    {
                        frm_Ac2.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen model seçiniz", "LetMeRepair");
                }



            }
            */
        }
    }
}


	




