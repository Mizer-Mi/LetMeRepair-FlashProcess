namespace LetMeRepair___Flash_Process
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;


    public partial class FrmMFGEditorRlt : Form
    {
      
        
        public FrmMFGEditorRlt(bool brlt)
        {
            this.InitializeComponent();
            if (brlt)
            {
                this.BackColor = Color.Green;
                this.lblTestResult.Text = "Başarılı";
            }
            else
            {
                this.BackColor = Color.Red;
                this.lblTestResult.Text = "Başarısız";
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmMFGEditorRlt_Load(object sender, EventArgs e)
        {
            this.btn.Focus();
        }

        private void InitializeComponent()
        {
            this.lblTestResult = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTestResult
            // 
            this.lblTestResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTestResult.Font = new System.Drawing.Font("Arial Black", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestResult.ForeColor = System.Drawing.Color.Black;
            this.lblTestResult.Location = new System.Drawing.Point(12, 18);
            this.lblTestResult.Name = "lblTestResult";
            this.lblTestResult.Size = new System.Drawing.Size(511, 145);
            this.lblTestResult.TabIndex = 7;
            this.lblTestResult.Text = "Başarılı";
            this.lblTestResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn
            // 
            this.btn.BackColor = System.Drawing.SystemColors.Control;
            this.btn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.Location = new System.Drawing.Point(145, 185);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(224, 60);
            this.btn.TabIndex = 8;
            this.btn.Text = "Çıkış";
            this.btn.UseVisualStyleBackColor = false;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // FrmMFGEditorRlt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 266);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.lblTestResult);
            this.Name = "FrmMFGEditorRlt";
            this.Text = "Sonuç";
         
            this.ResumeLayout(false);

        }






    }
}
