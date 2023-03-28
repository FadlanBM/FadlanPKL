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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var userId = textBox1.Text;
            var password = textBox2.Text;

            if ((userId == "jude") && (password == "asdfasdf"))
            {
                MessageBox.Show("Login berhasil!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Login gagal");
            }
        }
    }
}
