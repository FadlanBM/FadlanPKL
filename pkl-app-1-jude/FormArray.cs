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
    public partial class FormArray : Form
    {
        public FormArray()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] bilGenap = new int[10];
            var index = 0;
            for(var bil = numericUpDown1.Value; bil <= numericUpDown2.Value; bil++)
            {
                if (bil % 2 == 0)
                {
                    bilGenap[index] = (int)bil;
                    index++;
                    if (index >= 10)
                        break;
                }
            }
            textBox1.Text = string.Join(",",bilGenap);

        }
    }
}
