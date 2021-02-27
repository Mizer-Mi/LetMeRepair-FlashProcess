using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LetMeRepair___Flash_Process
{
    public partial class mizer_acilir_Combo : Form
    {
        public mizer_acilir_Combo()
        {
            InitializeComponent();
        }
        public string cihaz_turu { get;set; }
        private void Mizer_acilir_Combo_Load(object sender, EventArgs e)
        {
           if (cihaz_turu=="CN51")
            {
                comboBox1.Items.Add("2.20");
                comboBox1.Items.Add("2.30");
                comboBox1.Items.Add("2.10");
              
            }
           else if (cihaz_turu == "CN51_WLAN")
            {
                comboBox1.Items.Add("2.20");
                comboBox1.Items.Add("2.30");
                comboBox1.Items.Add("2.11");
                comboBox1.Items.Add("2.10");

            }
           else if (cihaz_turu == "CK71")
            {
                comboBox1.Items.Add("1.62");
                comboBox1.Items.Add("1.61");
                comboBox1.Items.Add("1.50");
            }
            else if (cihaz_turu == "CK3")
            {
                comboBox1.Items.Add("1.62");
                comboBox1.Items.Add("1.61");
          
            }

            comboBox1.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
