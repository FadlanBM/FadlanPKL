using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pkl_app_1_jude
{
    public partial class FormTanggal : Form
    {
        public FormTanggal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tglLahir = dateTimePicker1.Value;
            var tglSkrg = DateTime.Now;

            var umur = tglSkrg.Date - tglLahir.Date;
            var umurHari = umur.TotalDays;
            label2.Text = $"Umur anda adalah {umurHari:n0} hari";
        }
    }
}
