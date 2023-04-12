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
        private const int BOARD_SIZE = 25;
        private const int SQUARE_SIZE = 10;

        private Bitmap kanvas = null;
        private int actorX = 0;
        private int actorY = 0;

        private int lastX = 0;
        private int lastY = 0;

        private int[] bodyX = new int[300];
        private int[] bodyY = new int[300];

        private string arah = "kanan";

        private int foodX = 21;
        private int foodY = 15;

        private int score = 0;
        private int panjang = 0;

        public FormAnimasi()
        {
            InitializeComponent();
            DrawBoard();
            pictureBox1.Invalidate();
        }
        private void DrawBoard()
        {
            kanvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (var grafik = Graphics.FromImage(kanvas))
            {
                for (int x = 0; x < BOARD_SIZE; x++)
                    for (int y = 0; y < BOARD_SIZE; y++)
                    {
                        var brush = new SolidBrush(Color.LightCyan);
                        grafik.FillRectangle(brush, y * SQUARE_SIZE, x * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);

                        //var pen = new Pen(Color.PowderBlue);// (Color.PowderBlue);
                        //grafik.DrawRectangle(pen, y * SQUARE_SIZE, x * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
                    }
            }
        }

        private void DrawActor()
        {
            if (kanvas is null) return;
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var brushBody = new SolidBrush(Color.CornflowerBlue);

                bodyX[0] = lastX;
                bodyY[0] = lastY;
                for (var i = panjang; i>0; i--)
                {
                    if (i == 0) break;

                    bodyX[i] = bodyX[i-1];
                    bodyY[i] = bodyY[i - 1];
                    grafik.FillRectangle(brushBody, bodyX[i] * SQUARE_SIZE, bodyY[i] * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
                }
                //var brushHead = new SolidBrush(Color.DarkRed);
                //grafik.FillRectangle(brushHead, actorX * SQUARE_SIZE, actorY * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
                //var brushHead = new SolidBrush(Color.DarkRed);
                grafik.DrawImage(pictureBox2.Image, actorX * SQUARE_SIZE-15, actorY * SQUARE_SIZE-15, 40, 40);
            }
        }

        private void DrawFood()
        {
            if (kanvas is null) return;
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var brush = new SolidBrush(Color.MediumSeaGreen);
                grafik.FillRectangle(brush, foodX * SQUARE_SIZE, foodX * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (kanvas is null) return;
            e.Graphics.DrawImage(kanvas, 20, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lastX = actorX;
            lastY = actorY;

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

            label1.Text = $"{arah}: {actorX}, {actorY} | Score: {score}";

            DrawBoard();

            if (ApakahNabrakBody())
            {
                GameOver();
            }

            if (ApakahActorMakanFood())
            {
                RandomFood();
                score++;
                panjang++;
            }
            DrawActor();
            DrawFood();

            pictureBox1.Invalidate();
        }

        private bool ApakahNabrakBody()
        {
            for(var i = 0 ;i <= panjang; i++)
            {
                if (bodyX[i] != actorX) continue;
                if (bodyY[i] != actorY) continue;
                return true;
            }
            return false;
        }

        private void GameOver()
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            using (var grafik = Graphics.FromImage(kanvas))
            {
                var brush = new SolidBrush(Color.Red);
                grafik.DrawString("Game Over!", new Font("Arial", 16), brush, new Point(20,20));
            }

        }

        private bool ApakahActorMakanFood()
        {
            if (actorX == foodX && actorY == foodY)
                return true;
            return false;
        }

        private void FormAnimasi_KeyDown(object sender, KeyEventArgs e)
        {
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
        private void RandomFood()
        {
            Random randomX = new Random();
            foodX = randomX.Next(0, BOARD_SIZE);

            Random randomY = new Random();
            foodY = randomY.Next(0, BOARD_SIZE);
            timer2.Stop();
            timer2.Start();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            RandomFood();
            DrawBoard();
            DrawActor();
            DrawFood();
            pictureBox1.Invalidate();
        }
    }
}
