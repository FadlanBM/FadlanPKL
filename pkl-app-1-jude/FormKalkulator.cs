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
    public partial class FormKalkulator : Form
    {
        private double angkaTampilan = 0;
        private double angkaMemory= 0;
        private string operasi = "";

        public FormKalkulator()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            SimpanTampilan();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            var angka = textBox1.Text;
            var angkaPotong = angka.Substring(0, angka.Length-1);
            textBox1.Text =angkaPotong;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
            SimpanTampilan();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
            SimpanTampilan();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
            SimpanTampilan();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
            SimpanTampilan();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
            SimpanTampilan();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
            SimpanTampilan();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
            SimpanTampilan();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
            SimpanTampilan();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
            SimpanTampilan();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
            SimpanTampilan();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            angkaMemory = angkaTampilan;
            angkaTampilan = 0;
            operasi = "tambah";
            textBox1.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            angkaMemory = angkaTampilan;
            angkaTampilan = 0;
            operasi = "kurang";
            textBox1.Text = "";
        }

        private void SimpanTampilan()
        {
            angkaTampilan = Convert.ToDouble(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (operasi == "tambah")
                angkaMemory = angkaTampilan + angkaMemory;

            if (operasi == "kurang")
                angkaMemory = angkaMemory - angkaTampilan;

            if (operasi == "kali")
                angkaMemory = angkaTampilan * angkaMemory;

            if (operasi == "bagi")
                angkaMemory = angkaTampilan / angkaMemory;

            textBox1.Text = angkaMemory.ToString("0.##");
            angkaTampilan = angkaMemory;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            angkaMemory = angkaTampilan;
            angkaTampilan = 0;
            operasi = "kali";
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            angkaMemory = angkaTampilan;
            angkaTampilan = 0;
            operasi = "bagi";
            textBox1.Text = "";
        }
    }
}
