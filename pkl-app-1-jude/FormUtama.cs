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
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        private void ganjilGenapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormString();
            form.MdiParent = this;
            form.Show();
        }

        private void numerikTambahKaliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormNumerik();
            form.MdiParent = this;
            form.Show();
        }
    }
}
