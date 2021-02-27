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
    public partial class mizer_model_combo : Form
    {
        public mizer_model_combo()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
        public string cihaz_turu { get; set; }
        private void Mizer_model_combo_Load(object sender, EventArgs e)
        {
            
                comboBox1.Items.Add("CT40");
                comboBox1.Items.Add("CT60");
                comboBox1.Items.Add("CN80");

            comboBox1.SelectedIndex = 0;
        }
    }
}
