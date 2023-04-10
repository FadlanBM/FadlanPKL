using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pkl_app_1_jude
{
    public partial class FormProsedureFunction : Form
    {
        public FormProsedureFunction()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selamat Pagi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var saya = "Yudis";
            UcapSelamatPagi(saya);
        }

        private void UcapSelamatPagi(string nama)
        {
            MessageBox.Show($"Selamat Pagi {nama}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var hasil = 5 * 2;
            MessageBox.Show(hasil.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var hasil = Perkalian();
            MessageBox.Show(hasil.ToString());
        }

        private int Perkalian()
        {
            var result = 5 * 2;
            return result;
        }
    }
}
