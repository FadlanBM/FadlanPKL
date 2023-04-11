using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pkl_app_1_jude
{
    public partial class FormGraphic : Form
    {
        private Bitmap kanvas = null;

        public FormGraphic()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kanvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var pen = new Pen(Color.BlueViolet);
                grafik.DrawRectangle(pen, 10, 10, 100, 100);
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (kanvas == null)
                return;
            e.Graphics.DrawImage(kanvas, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kanvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var brush = new SolidBrush(Color.DarkGreen);
                grafik.FillRectangle(brush, 10, 10, 100, 100);
            }
            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kanvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var pen = new Pen(Color.DarkCyan);
                grafik.DrawEllipse(pen, 10, 10, 100, 100);
            }
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kanvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var brush = new HatchBrush(HatchStyle.Cross,Color.BurlyWood);
                grafik.FillEllipse(brush, 10, 10, 100, 100);
            }
            pictureBox1.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kanvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var brush = new LinearGradientBrush(new Point(0,0), new Point(450,450), Color.AliceBlue, Color.DarkRed);
                var polygon = new Point[] 
                { 
                    new Point(250,0), 
                    new Point(150,150),
                    new Point(0,150),
                    new Point(150,300),
                    new Point(50,450),
                    new Point(250,350),
                    new Point(450,450),
                    new Point(350,300),
                    new Point(350,300),
                    new Point(500,150),
                    new Point(350,150),
                };
                grafik.FillPolygon(brush, polygon);
            }
            pictureBox1.Invalidate();
        }
    }
}
