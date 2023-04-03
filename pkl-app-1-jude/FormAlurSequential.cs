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
    public partial class FormAlurSequential : Form
    {
        public FormAlurSequential()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Budi membeli 7 buat Apel. Harga apel adalah 1500 rupiah per buah.
            //  Berapa yang harus dibayar Budi?

            var hargaApel = 1500;
            var qtyApel = 7;
            var bayar = hargaApel * qtyApel;

            textBox1.Text = $"Harga = {hargaApel}. Jumlah = {qtyApel}. Jumlah bayar = {bayar}";
        }
    }
}
