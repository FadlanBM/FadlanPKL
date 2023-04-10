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
            var hasil = Perkalian(5,2);
            MessageBox.Show(hasil.ToString());
        }

        private int Perkalian(int x, int y)
        {
            var result = x * y;
            return result;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Start")
            {
                button5.Text = "Stop";
                timer1.Enabled = true;
            }
            else
            {
                button5.Text = "Start";
                timer1.Enabled = false;
                var hasil = ApakahBerhasil(progressBar1.Value);
                TampilkanHasil(hasil);
            }
        }
        private int counter = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == 20 || progressBar1.Value == 0)
                counter = -counter;
            progressBar1.Value += counter;
            label1.Text = progressBar1.Value.ToString();
        }

        private bool ApakahBerhasil(int score)
        {
            if(score == 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void TampilkanHasil(bool sukses)
        {
            if (sukses) 
            {
                label2.Text = "SUKSES!!!";
                label2.ForeColor = Color.Green;
            }
            else
            {
                label2.Text = "GAGAL!!";
                label2.ForeColor = Color.Red;
            }
        }
    }
}
