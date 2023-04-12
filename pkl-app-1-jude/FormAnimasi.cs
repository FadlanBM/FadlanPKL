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
    public partial class FormAnimasi : Form
    {
        private const int BOARD_SIZE = 50;
        private const int SQUARE_SIZE = 10;

        private Bitmap kanvas = null;
        private int actorX = 0;
        private int actorY = 0;

        private string arah = "kanan";

        public FormAnimasi()
        {
            InitializeComponent();
            DrawPapanCatur();
            pictureBox1.Invalidate();
        }
        private void DrawPapanCatur()
        {
            kanvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var grafik = Graphics.FromImage(kanvas))
            {
                for (int x = 0; x < BOARD_SIZE; x++)
                    for (int y = 0; y < BOARD_SIZE; y++)
                    {
                        var brush = new SolidBrush(Color.LightCyan);
                        grafik.FillRectangle(brush, y * SQUARE_SIZE, x * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);

                        var pen = new Pen(Color.LightCyan);// (Color.PowderBlue);
                        grafik.DrawRectangle(pen, y * SQUARE_SIZE, x * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
                    }
            }
        }

        private void DrawActor()
        {
            if (kanvas is null) return;
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var brush = new SolidBrush(Color.DarkRed);
                grafik.FillRectangle(brush, actorX * SQUARE_SIZE, actorY * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (kanvas is null) return;
            e.Graphics.DrawImage(kanvas, 20, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (arah)
            {
                case "kiri": 
                    actorX--;
                    break;
                case "kanan":
                    actorX++;
                    break;
                case "atas":
                    actorY--;
                    break;
                case "bawah":
                    actorY++;
                    break;
            }

            if (actorX > BOARD_SIZE-1)
                actorX = 0;
            if (actorX < 0)
                actorX = BOARD_SIZE-1;

            if (actorY > BOARD_SIZE-1)
                actorY = 0;
            if (actorY < 0)
                actorY = BOARD_SIZE-1;

            label1.Text = $"{arah}: {actorX}, {actorY}";
            DrawPapanCatur();
            DrawActor();
            pictureBox1.Invalidate();
        }

        private void FormAnimasi_KeyDown(object sender, KeyEventArgs e)
        {
            var x = e.KeyCode;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    arah = "atas";
                    break;
                case Keys.Down:
                    arah = "bawah";
                    break;
                case Keys.Left:
                    arah = "kiri";
                    break;
                case Keys.Right:
                    arah = "kanan";
                    break;
            }
        }

        private void FormAnimasi_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
    }
}
