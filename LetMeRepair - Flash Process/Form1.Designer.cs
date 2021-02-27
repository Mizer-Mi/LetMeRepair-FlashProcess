namespace LetMeRepair___Flash_Process
{
	partial class Form1
	{
		/// <summary>
		///Gerekli tasarımcı değişkeni.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///Kullanılan tüm kaynakları temizleyin.
		/// </summary>
		///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer üretilen kod

		/// <summary>
		/// Tasarımcı desteği için gerekli metot - bu metodun 
		///içeriğini kod düzenleyici ile değiştirmeyin.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CK3_161 = new System.Windows.Forms.Button();
            this.bekleme_yazisi = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CN51_WWAN_161 = new System.Windows.Forms.Button();
            this.CN51_WLAN_161 = new System.Windows.Forms.Button();
            this.CK71_161 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.DOLP99_161 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.aktarim_label = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gösterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkındaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.EX25_FW_161 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.batarya = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.os_versiyonu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.iletisim_161 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CK3_161
            // 
            this.CK3_161.BackColor = System.Drawing.SystemColors.Control;
            this.CK3_161.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CK3_161.Location = new System.Drawing.Point(6, 18);
            this.CK3_161.Name = "CK3_161";
            this.CK3_161.Size = new System.Drawing.Size(229, 65);
            this.CK3_161.TabIndex = 0;
            this.CK3_161.Text = " CK3 - SU ";
            this.CK3_161.UseVisualStyleBackColor = false;
            this.CK3_161.Click += new System.EventHandler(this.Button1_Click);
            // 
            // bekleme_yazisi
            // 
            this.bekleme_yazisi.AutoSize = true;
            this.bekleme_yazisi.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bekleme_yazisi.Location = new System.Drawing.Point(319, 89);
            this.bekleme_yazisi.Name = "bekleme_yazisi";
            this.bekleme_yazisi.Size = new System.Drawing.Size(276, 42);
            this.bekleme_yazisi.TabIndex = 1;
            this.bekleme_yazisi.Text = "Lütfen Bekleyin..";
            this.bekleme_yazisi.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(946, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // CN51_WWAN_161
            // 
            this.CN51_WWAN_161.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CN51_WWAN_161.Location = new System.Drawing.Point(6, 231);
            this.CN51_WWAN_161.Name = "CN51_WWAN_161";
            this.CN51_WWAN_161.Size = new System.Drawing.Size(229, 65);
            this.CN51_WWAN_161.TabIndex = 3;
            this.CN51_WWAN_161.Text = "CN51 - WWAN - SU";
            this.CN51_WWAN_161.UseVisualStyleBackColor = true;
            this.CN51_WWAN_161.Click += new System.EventHandler(this.Button2_Click);
            // 
            // CN51_WLAN_161
            // 
            this.CN51_WLAN_161.BackColor = System.Drawing.SystemColors.Control;
            this.CN51_WLAN_161.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CN51_WLAN_161.Location = new System.Drawing.Point(6, 302);
            this.CN51_WLAN_161.Name = "CN51_WLAN_161";
            this.CN51_WLAN_161.Size = new System.Drawing.Size(229, 65);
            this.CN51_WLAN_161.TabIndex = 4;
            this.CN51_WLAN_161.Text = "CN51 - WLAN - SU";
            this.CN51_WLAN_161.UseVisualStyleBackColor = false;
            this.CN51_WLAN_161.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // CK71_161
            // 
            this.CK71_161.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CK71_161.Location = new System.Drawing.Point(6, 89);
            this.CK71_161.Name = "CK71_161";
            this.CK71_161.Size = new System.Drawing.Size(229, 65);
            this.CK71_161.TabIndex = 5;
            this.CK71_161.Text = "CK71 - SU";
            this.CK71_161.UseVisualStyleBackColor = true;
            this.CK71_161.Click += new System.EventHandler(this.Button3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(308, 147);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(287, 178);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // DOLP99_161
            // 
            this.DOLP99_161.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DOLP99_161.Location = new System.Drawing.Point(6, 160);
            this.DOLP99_161.Name = "DOLP99_161";
            this.DOLP99_161.Size = new System.Drawing.Size(229, 65);
            this.DOLP99_161.TabIndex = 7;
            this.DOLP99_161.Text = "Dolphin 99EX FW";
            this.DOLP99_161.UseVisualStyleBackColor = true;
            this.DOLP99_161.Click += new System.EventHandler(this.Button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(268, 331);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(375, 33);
            this.progressBar1.Step = 5;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // aktarim_label
            // 
            this.aktarim_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.aktarim_label.Location = new System.Drawing.Point(268, 353);
            this.aktarim_label.Name = "aktarim_label";
            this.aktarim_label.Size = new System.Drawing.Size(375, 37);
            this.aktarim_label.TabIndex = 9;
            this.aktarim_label.Text = "Aktarım Başlıyor.";
            this.aktarim_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aktarim_label.Visible = false;
            this.aktarim_label.Click += new System.EventHandler(this.Aktarim_label_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gösterToolStripMenuItem,
            this.ayarlarToolStripMenuItem,
            this.hakkındaToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // gösterToolStripMenuItem
            // 
            this.gösterToolStripMenuItem.Name = "gösterToolStripMenuItem";
            this.gösterToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gösterToolStripMenuItem.Text = "Göster";
            this.gösterToolStripMenuItem.Click += new System.EventHandler(this.GösterToolStripMenuItem_Click);
            // 
            // ayarlarToolStripMenuItem
            // 
            this.ayarlarToolStripMenuItem.Name = "ayarlarToolStripMenuItem";
            this.ayarlarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ayarlarToolStripMenuItem.Text = "Ayarlar";
            this.ayarlarToolStripMenuItem.Click += new System.EventHandler(this.AyarlarToolStripMenuItem_Click);
            // 
            // hakkındaToolStripMenuItem
            // 
            this.hakkındaToolStripMenuItem.Name = "hakkındaToolStripMenuItem";
            this.hakkındaToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hakkındaToolStripMenuItem.Text = "Hakkında";
            this.hakkındaToolStripMenuItem.Click += new System.EventHandler(this.HakkındaToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.ÇıkışToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Orange;
            this.button5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.DarkGreen;
            this.button5.Location = new System.Drawing.Point(16, 635);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(310, 35);
            this.button5.TabIndex = 11;
            this.button5.Text = "Fonksiyonlar = Açık";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Orange;
            this.button6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button6.ForeColor = System.Drawing.Color.DarkGreen;
            this.button6.Location = new System.Drawing.Point(620, 635);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(310, 35);
            this.button6.TabIndex = 12;
            this.button6.Text = "Program Ayarları";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // EX25_FW_161
            // 
            this.EX25_FW_161.BackColor = System.Drawing.SystemColors.Control;
            this.EX25_FW_161.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.EX25_FW_161.Location = new System.Drawing.Point(679, 18);
            this.EX25_FW_161.Name = "EX25_FW_161";
            this.EX25_FW_161.Size = new System.Drawing.Size(229, 65);
            this.EX25_FW_161.TabIndex = 13;
            this.EX25_FW_161.Text = "EX25 Firmware";
            this.EX25_FW_161.UseVisualStyleBackColor = false;
            this.EX25_FW_161.Click += new System.EventHandler(this.Button7_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.ImageList = this.ımageList1;
            this.tabControl1.Location = new System.Drawing.Point(12, 186);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(922, 443);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.batarya);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.os_versiyonu);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.iletisim_161);
            this.tabPage1.Controls.Add(this.CK3_161);
            this.tabPage1.Controls.Add(this.EX25_FW_161);
            this.tabPage1.Controls.Add(this.bekleme_yazisi);
            this.tabPage1.Controls.Add(this.CN51_WWAN_161);
            this.tabPage1.Controls.Add(this.CN51_WLAN_161);
            this.tabPage1.Controls.Add(this.aktarim_label);
            this.tabPage1.Controls.Add(this.CK71_161);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.pictureBox2);
            this.tabPage1.Controls.Add(this.DOLP99_161);
            this.tabPage1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabPage1.ImageKey = "windows_mobile_ik3_icon.ico";
            this.tabPage1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(914, 407);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Windows";
            // 
            // batarya
            // 
            this.batarya.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.batarya.Location = new System.Drawing.Point(375, 37);
            this.batarya.Name = "batarya";
            this.batarya.Size = new System.Drawing.Size(127, 19);
            this.batarya.TabIndex = 21;
            this.batarya.Text = "N/A";
            this.batarya.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(251, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pil Durumu:";
            // 
            // os_versiyonu
            // 
            this.os_versiyonu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.os_versiyonu.Location = new System.Drawing.Point(375, 10);
            this.os_versiyonu.Name = "os_versiyonu";
            this.os_versiyonu.Size = new System.Drawing.Size(127, 19);
            this.os_versiyonu.TabIndex = 19;
            this.os_versiyonu.Text = "N/A";
            this.os_versiyonu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(251, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sistem Mimarisi:";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.Control;
            this.button11.Enabled = false;
            this.button11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button11.Location = new System.Drawing.Point(679, 302);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(229, 65);
            this.button11.TabIndex = 17;
            this.button11.Text = "-";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.Control;
            this.button10.Enabled = false;
            this.button10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button10.Location = new System.Drawing.Point(679, 231);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(229, 65);
            this.button10.TabIndex = 16;
            this.button10.Text = "-";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.Control;
            this.button9.Enabled = false;
            this.button9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button9.Location = new System.Drawing.Point(679, 161);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(229, 65);
            this.button9.TabIndex = 15;
            this.button9.Text = "-";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // iletisim_161
            // 
            this.iletisim_161.BackColor = System.Drawing.SystemColors.Control;
            this.iletisim_161.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iletisim_161.Location = new System.Drawing.Point(679, 89);
            this.iletisim_161.Name = "iletisim_161";
            this.iletisim_161.Size = new System.Drawing.Size(229, 65);
            this.iletisim_161.TabIndex = 14;
            this.iletisim_161.Text = "LMR Uygulaması";
            this.iletisim_161.UseVisualStyleBackColor = false;
            this.iletisim_161.Click += new System.EventHandler(this.İletisim_161_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button16);
            this.tabPage2.Controls.Add(this.button17);
            this.tabPage2.Controls.Add(this.button18);
            this.tabPage2.Controls.Add(this.button19);
            this.tabPage2.ImageKey = "favicon.ico";
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(914, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Android";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button21);
            this.tabPage3.Controls.Add(this.button22);
            this.tabPage3.Controls.Add(this.button23);
            this.tabPage3.Controls.Add(this.button24);
            this.tabPage3.Controls.Add(this.button25);
            this.tabPage3.Controls.Add(this.button8);
            this.tabPage3.Controls.Add(this.button12);
            this.tabPage3.Controls.Add(this.button13);
            this.tabPage3.Controls.Add(this.button14);
            this.tabPage3.Controls.Add(this.button15);
            this.tabPage3.Controls.Add(this.button7);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.ImageIndex = 2;
            this.tabPage3.Location = new System.Drawing.Point(4, 32);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(914, 407);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ek araçlar";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.SystemColors.Control;
            this.button21.Enabled = false;
            this.button21.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button21.Location = new System.Drawing.Point(664, 321);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(229, 65);
            this.button21.TabIndex = 15;
            this.button21.Text = "---";
            this.button21.UseVisualStyleBackColor = false;
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.SystemColors.Control;
            this.button22.Enabled = false;
            this.button22.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button22.Location = new System.Drawing.Point(664, 246);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(229, 65);
            this.button22.TabIndex = 14;
            this.button22.Text = "---";
            this.button22.UseVisualStyleBackColor = false;
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.SystemColors.Control;
            this.button23.Enabled = false;
            this.button23.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button23.Location = new System.Drawing.Point(664, 171);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(229, 65);
            this.button23.TabIndex = 13;
            this.button23.Text = "---";
            this.button23.UseVisualStyleBackColor = false;
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.SystemColors.Control;
            this.button24.Enabled = false;
            this.button24.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button24.Location = new System.Drawing.Point(664, 93);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(229, 65);
            this.button24.TabIndex = 12;
            this.button24.Text = "---";
            this.button24.UseVisualStyleBackColor = false;
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.SystemColors.Control;
            this.button25.Enabled = false;
            this.button25.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button25.Location = new System.Drawing.Point(664, 16);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(229, 65);
            this.button25.TabIndex = 11;
            this.button25.Text = "---";
            this.button25.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.Control;
            this.button8.Enabled = false;
            this.button8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button8.Location = new System.Drawing.Point(344, 321);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(229, 65);
            this.button8.TabIndex = 10;
            this.button8.Text = "---";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.Control;
            this.button12.Enabled = false;
            this.button12.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button12.Location = new System.Drawing.Point(344, 246);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(229, 65);
            this.button12.TabIndex = 9;
            this.button12.Text = "---";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.SystemColors.Control;
            this.button13.Enabled = false;
            this.button13.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button13.Location = new System.Drawing.Point(344, 171);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(229, 65);
            this.button13.TabIndex = 8;
            this.button13.Text = "---";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.SystemColors.Control;
            this.button14.Enabled = false;
            this.button14.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button14.Location = new System.Drawing.Point(344, 93);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(229, 65);
            this.button14.TabIndex = 7;
            this.button14.Text = "---";
            this.button14.UseVisualStyleBackColor = false;
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.SystemColors.Control;
            this.button15.Enabled = false;
            this.button15.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button15.Location = new System.Drawing.Point(344, 16);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(229, 65);
            this.button15.TabIndex = 6;
            this.button15.Text = "---";
            this.button15.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.Control;
            this.button7.Enabled = false;
            this.button7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button7.Location = new System.Drawing.Point(12, 321);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(229, 65);
            this.button7.TabIndex = 5;
            this.button7.Text = "---";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Control;
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(12, 246);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(229, 65);
            this.button3.TabIndex = 4;
            this.button3.Text = "---";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Control;
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.Location = new System.Drawing.Point(12, 171);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(229, 65);
            this.button4.TabIndex = 3;
            this.button4.Text = "---";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(12, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(229, 65);
            this.button2.TabIndex = 2;
            this.button2.Text = "---";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(12, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(229, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "IMEI NO > HEX";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click_2);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "windows_mobile_ik3_icon.ico");
            this.ımageList1.Images.SetKeyName(1, "favicon.ico");
            this.ımageList1.Images.SetKeyName(2, "tools.ico");
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.SystemColors.Control;
            this.button16.Enabled = false;
            this.button16.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button16.Location = new System.Drawing.Point(670, 172);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(229, 65);
            this.button16.TabIndex = 8;
            this.button16.Text = "---";
            this.button16.UseVisualStyleBackColor = false;
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.SystemColors.Control;
            this.button17.Enabled = false;
            this.button17.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button17.Location = new System.Drawing.Point(670, 97);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(229, 65);
            this.button17.TabIndex = 7;
            this.button17.Text = "---";
            this.button17.UseVisualStyleBackColor = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.SystemColors.Control;
            this.button18.Enabled = false;
            this.button18.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button18.Location = new System.Drawing.Point(670, 19);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(229, 65);
            this.button18.TabIndex = 6;
            this.button18.Text = "---";
            this.button18.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.SystemColors.Control;
            this.button19.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button19.Location = new System.Drawing.Point(6, 19);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(229, 90);
            this.button19.TabIndex = 5;
            this.button19.Text = "CT40-CT60-CN80  Config değiştirme";
            this.button19.UseVisualStyleBackColor = false;
            this.button19.Click += new System.EventHandler(this.Button19_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(946, 673);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LetMeRepair - Flash Process";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Move += new System.EventHandler(this.Form1_Move);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CK3_161;
		public System.Windows.Forms.Label bekleme_yazisi;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button CN51_WWAN_161;
		private System.Windows.Forms.Button CN51_WLAN_161;
		private System.Windows.Forms.Button CK71_161;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button DOLP99_161;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label aktarim_label;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gösterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkındaToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem ayarlarToolStripMenuItem;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button EX25_FW_161;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button iletisim_161;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label os_versiyonu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label batarya;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
    }
}

