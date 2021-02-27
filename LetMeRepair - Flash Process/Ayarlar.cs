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
    public partial class Ayarlar : Form
    {
        public Ayarlar()
        {
            InitializeComponent();
        }

        private void Ayarlar_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ustte==true)
            {
                ustte_olsunmu.Checked =true;
            }
            if (Properties.Settings.Default.sistem_icon_gecis==true)
            {
                checkBox1.Checked = true;
            }
        }

        private void Ustte_olsunmu_CheckedChanged(object sender, EventArgs e)
        {
            if (ustte_olsunmu.Checked==true)
            {
                Properties.Settings.Default.ustte = true;
            }
            else
            {
                Properties.Settings.Default.ustte = false;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.sistem_icon_gecis = true;
            }
            else
            {
                Properties.Settings.Default.sistem_icon_gecis = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           DialogResult= DialogResult.OK;
     
        }
    }
}
