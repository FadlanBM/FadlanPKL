using pkl_app_1_jude.SpaceInvaders.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pkl_app_1_jude.SpaceInvaders
{
    public partial class SpaceInvadersForm : Form
    {
        private Bitmap _canvas = null;
        const int SPACE_BOARD_WIDTH = 80;
        const int SPACE_BOARD_HEIGHT = 40;
        const int SQUARE_SIZE = 10;
        const int JUMLAH_PELURU_ENEMY = 3;
        private List<EnemyModel> _listEnemy;
        private List<BentengModel> _listBenteng;
        private ActorModel _actor;
        private string _arahEnemy = "left";
        private string _arahActor = "";
        private PeluruModel _peluruActor;
        private List<PeluruModel> _listPeluruEnemy;

        const string ACTOR_NEMBAK_SOUND = "pkl_app_1_jude.actor-nembak.wav";
        const string ENEMY_KENA_SOUND = "pkl_app_1_jude.enemy-hit.wav";
        const string ENEMY_NEMBAK_SOUND = "pkl_app_1_jude.enemy-nembak.wav";
        const string BENTENG_HIT_SOUND = "pkl_app_1_jude.benteng-hit.wav";

        public SpaceInvadersForm()
        {
            InitializeComponent();
            _listEnemy = new List<EnemyModel>();
            _listBenteng = new List<BentengModel>();
            _actor = new ActorModel();
            _peluruActor = new PeluruModel(); 
            _listPeluruEnemy = new List<PeluruModel>();

            CreateEnemyObject();
            CreateBentengObject();
            CreateActorObject();
            CreatePeluruActorObject();
            CreatePeluruEnemyObject();

            DrawAll();

        }

        private void DrawAll()
        {
            DrawBoard();
            DrawEnemy();
            DrawBenteng();
            DrawActor();
            DrawPeluru();
            DrawPeluruEnemy();
            SpaceBoard.Invalidate();
        }

        private void DrawBoard()
        {
            _canvas = new Bitmap(SpaceBoard.Width, SpaceBoard.Height);
            using (var grafik = Graphics.FromImage(_canvas))
            {
                for (int x = 0; x < SPACE_BOARD_WIDTH; x++)
                    for (int y = 0; y < SPACE_BOARD_HEIGHT; y++)
                        grafik.DrawRectangle(new Pen(Color.DarkGreen), x * SQUARE_SIZE, y * SQUARE_SIZE, SQUARE_SIZE, SQUARE_SIZE);
            }
        }

        private void SpaceBoard_Paint(object sender, PaintEventArgs e)
        {
            if (_canvas is null) return;
            e.Graphics.DrawImage(_canvas, 0, 0);
        }

        private void DrawEnemy()
        {
            using (var grafik = Graphics.FromImage(_canvas))
            {
                foreach (var enemy in _listEnemy.Where(x => x.IsAlive != 2).ToList())
                {
                    if (enemy.IsAlive == 0)
                        grafik.DrawImage(enemy.Gambar, enemy.PosX * SQUARE_SIZE, enemy.PosY * SQUARE_SIZE, enemy.Width * SQUARE_SIZE, enemy.Height * SQUARE_SIZE);
                    else
                    {
                        grafik.DrawImage(ExplosionPic.Image, enemy.PosX * SQUARE_SIZE, enemy.PosY * SQUARE_SIZE, enemy.Width * SQUARE_SIZE, enemy.Height * SQUARE_SIZE);
                        enemy.IsAlive = 2;
                    }

                }
            }
        }
        private void DrawActor()
        {
            using (var grafik = Graphics.FromImage(_canvas))
            {
                grafik.DrawImage(_actor.Gambar, _actor.PosX * SQUARE_SIZE, _actor.PosY * SQUARE_SIZE, _actor.Width * SQUARE_SIZE, _actor.Height * SQUARE_SIZE);
            }
        }
        private void DrawPeluru()
        {
            using (var grafik = Graphics.FromImage(_canvas))
            {
                grafik.DrawImage(_peluruActor.Gambar, _peluruActor.PosX * SQUARE_SIZE, _peluruActor.PosY * SQUARE_SIZE, _peluruActor.Width * SQUARE_SIZE, _peluruActor.Height * SQUARE_SIZE);
            }
        }

        private void DrawPeluruEnemy()
        {
            using (var grafik = Graphics.FromImage(_canvas))
            {
                foreach(var item in _listPeluruEnemy.Where(x => x.IsAktif))
                    grafik.DrawImage(item.Gambar, item.PosX * SQUARE_SIZE, item.PosY * SQUARE_SIZE, item.Width * SQUARE_SIZE, item.Height * SQUARE_SIZE);
            }
        }

        private void PlaySound(string soundName)
        {
            Stream soundStream = typeof(Program).Assembly.GetManifestResourceStream(soundName);
            SoundPlayer soundPlayer = new SoundPlayer(soundStream);
            soundPlayer.Play();
        }

        private void MoveEnemy()
        {
            var modifierX = 0;
            var modifierY = 0;
            switch (_arahEnemy)
            {
                case "up":
                    modifierX = 0;
                    modifierY = -1;
                    break;
                case "down":
                    modifierX = 0;
                    modifierY = 1;
                    break;
                case "left":
                    modifierX = -1;
                    modifierY = 0;
                    break;
                case "right":
                    modifierX = 1;
                    modifierY = 0;
                    break;
            }
            foreach(var enemy in _listEnemy)
            {
                enemy.PosX += modifierX;
                enemy.PosY += modifierY;
            }
        }


        private void DrawBenteng()
        {
            using (var grafik = Graphics.FromImage(_canvas))
            {
                foreach (var benteng in _listBenteng)
                {
                    Brush brush = null;
                    switch(benteng.DefencePower)
                    {
                        case 5:  
                            brush = new SolidBrush(Color.Aquamarine);
                            break;
                        case 4:
                            brush = new SolidBrush(Color.Turquoise);
                            break;
                        case 3: 
                            brush = new SolidBrush(Color.LightSeaGreen);
                            break;
                        case 2:  
                            brush = new SolidBrush(Color.Teal);
                            break;
                        case 1:  
                            brush = new SolidBrush(Color.FromArgb(0,40,40));
                            break;
                        default:
                            brush = new SolidBrush(Color.DarkSlateGray);
                            break;
                    }; 
                    grafik.FillRectangle(brush, benteng.PosX * SQUARE_SIZE, benteng.PosY * SQUARE_SIZE, benteng.Width * SQUARE_SIZE, benteng.Height * SQUARE_SIZE);

                }
            }
        }
        private void DrawGameOver()
        {
            using (var grafik = Graphics.FromImage(_canvas))
            {
                var margin = 10;

                Font font = new Font("Arial", 34, FontStyle.Bold);
                string text = "GAME OVER!";
                SizeF size = grafik.MeasureString(text, font);
                size.Width += margin * 2;
                size.Height += margin * 2;

                var posXText = (SpaceBoard.Width/2) - (size.Width/2);
                var posYText = 50;


                Rectangle rect = new Rectangle((int)posXText, posYText, (int)size.Width, (int)size.Height);
                var fillBrush = new SolidBrush(Color.AntiqueWhite);

                grafik.FillRectangle(fillBrush, rect);
                var line = new Pen(Color.DarkRed);
                grafik.DrawRectangle(line, rect);

                Brush brush = Brushes.DarkRed;
                PointF position = new PointF(posXText + margin, posYText + margin);
                grafik.DrawString(text, font, brush, position);
            }
            SpaceBoard.Invalidate();
        }


        private void CreateEnemyObject()
        {
            const int WIDTH = 4;
            const int HEIGHT = 3;

            //  enemy level-3 (paling atas)
            for (var i = 1; i <= 9; i++)
            {
                var newEnemy = new EnemyModel
                {
                    Id = i,
                    Gambar = Enemy3Pic.Image,
                    IsAlive = 0,
                    Width = WIDTH,
                    Height = HEIGHT,
                    PosX = (i * WIDTH * 2) - WIDTH ,
                    PosY = 2
                };
                _listEnemy.Add(newEnemy);
            }

            //  enemy level-2 (tengah)
            for (var i = 10; i <= 18; i++)
            {
                var newEnemy = new EnemyModel
                {
                    Id = i,
                    Gambar = Enemy2Pic.Image,
                    IsAlive = 0,
                    Width = WIDTH,
                    Height = HEIGHT,
                    PosX = ((i-9) * WIDTH * 2) - WIDTH,
                    PosY = 7
                };
                _listEnemy.Add(newEnemy);
            }

            //  enemy level-1 (baris ke-2)
            for (var i = 19; i <= 27; i++)
            {
                var newEnemy = new EnemyModel
                {
                    Id = i,
                    Gambar = Enemy1Pic.Image,
                    IsAlive = 0,
                    Width = WIDTH,
                    Height = HEIGHT,
                    PosX = ((i - 18) * WIDTH * 2) - WIDTH,
                    PosY = 12
                };
                _listEnemy.Add(newEnemy);
            }

            //  enemy level-1 (baris ke-1)
            for (var i = 28; i <= 36; i++)
            {
                var newEnemy = new EnemyModel
                {
                    Id = i,
                    Gambar = Enemy1Pic.Image,
                    IsAlive = 0,
                    Width = WIDTH,
                    Height = HEIGHT,
                    PosX = ((i - 27) * WIDTH * 2) - WIDTH,
                    PosY = 17
                };
                _listEnemy.Add(newEnemy);
            }
        }

        private void CreateBentengObject()
        {
            const int WIDTH = 7;
            const int HEIGHT = 1;

            for (var i = 1; i <=8; i++)
            {
                var newBenteng = new BentengModel
                {
                    Id = i,
                    DefencePower = 5,
                    Height = HEIGHT,
                    Width = WIDTH,
                    PosX = (i * (WIDTH+4)) - WIDTH,
                    PosY = 30
                };
                _listBenteng.Add(newBenteng);
            }

        }
        private void CreateActorObject()
        {
            _actor = new ActorModel
            {
                Gambar = ActorPic.Image,
                Width = 5,
                Height = 3,
                PosX = 0,
                PosY = 36,
            };
        }

        private void CreatePeluruActorObject()
        {
            _peluruActor.IsAktif = false;
            _peluruActor.Width = 1;
            _peluruActor.Height = 3;
            _peluruActor.Gambar = PeluruPic.Image;
        }

        private void CreatePeluruEnemyObject()
        {
            for(var i = 1; i <=JUMLAH_PELURU_ENEMY; i++)
            {
                _listPeluruEnemy.Add(new PeluruModel
                {
                    Gambar = EnemyBulletPic.Image,
                    PosX = 0,
                    PosY = 0,
                    Height = 1,
                    Width = 1
                });
            }
        }

        private void EnemyMoveTimer_Tick(object sender, EventArgs e)
        {
            var palingLeft = _listEnemy.Where(x => x.IsAlive == 0).Min(x => x.PosX);
            var palingRight = _listEnemy.Where(x => x.IsAlive == 0).Max(x => x.PosX + x.Width);

            if ((_arahEnemy == "left") && (palingLeft <= 0))
                _arahEnemy = "right";
            if ((_arahEnemy == "right") && (palingRight >= SPACE_BOARD_WIDTH))
                _arahEnemy = "left";
            MoveEnemy();
            DrawAll();
        }

        private void SpaceInvadersForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void SpaceInvadersForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Left:
                    _arahActor = "left";
                    break;
                case Keys.Right:
                    _arahActor = "right";
                    break;
                case Keys.Space:
                    TembakMusuh();
                    break;
            }
        }

        private void ActorMoveTimer_Tick(object sender, EventArgs e)
        {
            if (_arahActor == "left")
                _actor.PosX--;
            if (_arahActor == "right")
                _actor.PosX++;

            if (_actor.PosX <= 0)
                _actor.PosX = 0;
            if (_actor.PosX > SPACE_BOARD_WIDTH - _actor.Width)
                _actor.PosX = SPACE_BOARD_WIDTH - _actor.Width;
            DrawAll();
        }

        private void SpaceInvadersForm_KeyUp(object sender, KeyEventArgs e)
        {
            _arahActor = string.Empty;
        }

        private void TembakMusuh()
        {
            if (_peluruActor.IsAktif)
                return;
            _peluruActor.PosX = _actor.PosX + (_actor.Width/2);
            _peluruActor.PosY = _actor.PosY;
            _peluruActor.IsAktif = true;
            PlaySound(ACTOR_NEMBAK_SOUND);
        }

        private void PeluruActorTimer_Tick(object sender, EventArgs e)
        {
            if (!_peluruActor.IsAktif)
                return;
            _peluruActor.PosY--;

            //  apakah peluru kena benteng?
            var bentengTertembak = GetBentengTertembak();
            if (bentengTertembak != null)
            {
                _peluruActor.IsAktif = false;
                _peluruActor.PosY = -10;
            }

            //  apakah peluru kena enemy?
            var enemyTertembak = GetEnemyTertembak();
            if (enemyTertembak != null)
            {
                enemyTertembak.IsAlive = 1;
                _peluruActor.IsAktif = false;
                _peluruActor.PosY = -10;
                PlaySound(ENEMY_KENA_SOUND);
            }

            //  apakah peluru kena udah lewat batas atas
            if (_peluruActor.PosY <= 0)
            {
                _peluruActor.IsAktif = false;
                _peluruActor.PosY = -10;
            }
        }

        private EnemyModel GetEnemyTertembak()
        {
            foreach(var enemy in _listEnemy.Where(x => x.IsAlive == 0).OrderByDescending(x => x.Id).ToList())
            {
                //  deteksi apakah kena bagian bawah enemy
                //      - tidak kena
                if (_peluruActor.PosY != enemy.PosY + 1 + enemy.Height)
                    continue;
                if (_peluruActor.PosX < enemy.PosX)
                    continue;
                if (_peluruActor.PosX > enemy.PosX + enemy.Width)
                    continue;
                //      - kena!!
                return enemy;
            }
            return null;
        }

        private BentengModel GetBentengTertembak()
        {
            foreach(var benteng in _listBenteng)
            {
                if (_peluruActor.PosY > benteng.PosY + benteng.Height -1)
                    continue;
                if (_peluruActor.PosX < benteng.PosX)
                    continue;
                if (_peluruActor.PosX > benteng.PosX + benteng.Width-1)
                    continue;
                if (benteng.DefencePower <= 0)
                    continue;
                return benteng;
            }
            return null;
        }

        private BentengModel GetBentengTertembakEnemy(PeluruModel peluru)
        {
            if (!peluru.IsAktif) return null;

            foreach (var benteng in _listBenteng)
            {
                if (benteng.DefencePower <= 0)
                    continue;

                if (peluru.PosY < benteng.PosY)
                    continue;
                if (peluru.PosY > benteng.PosY + benteng.Height - 1)
                    continue;
                if (peluru.PosX < benteng.PosX)
                    continue;
                if (peluru.PosX > benteng.PosX + benteng.Width - 1)
                    continue;
                return benteng;
            }
            return null;
        }
        private void PeluruEnemyTimer_Tick(object sender, EventArgs e)
        {
            foreach(var item in _listPeluruEnemy)
            {
                if (!item.IsAktif)
                    continue;
                item.PosY++;

                if (item.PosY > SPACE_BOARD_HEIGHT)
                {
                    item.IsAktif = false;
                    item.PosY = -10;
                }

                var benteng = GetBentengTertembakEnemy(item);
                if (benteng != null)
                {
                    benteng.DefencePower--;
                    item.IsAktif = false;
                    item.PosY = -10;
                    PlaySound(BENTENG_HIT_SOUND);

                }

                if (PeluruEnemyKenaActor(item))
                {
                    StopAllTimer();
                    DrawGameOver();
                }


            }
        }

        private bool PeluruEnemyKenaActor(PeluruModel peluru)
        {
            if (!peluru.IsAktif)
                return false;
            if (peluru.PosY < _actor.PosY)
                return false;
            if (peluru.PosY > _actor.PosY + _actor.Height - 1)
                return false;
            if (peluru.PosX < _actor.PosX)
                return false;
            if (peluru.PosX > _actor.PosX + _actor.Width - 1)
                return false;

            return true;
        }

        private void StopAllTimer()
        {
            EnemyMoveTimer.Stop();
            ActorMoveTimer.Stop();
            PeluruActorTimer.Stop();
            PeluruEnemyMoveTimer.Stop();
            PeluruEnemyTembakTimer.Stop();
        }

        private void PeluruEnemyTembakTimer_Tick(object sender, EventArgs e)
        {
            var enemyNembak = GetRandomEnemyBawah();
            var peluru = _listPeluruEnemy.FirstOrDefault(x => !x.IsAktif);
            if (peluru is null)
                return;

            peluru.IsAktif = true;
            peluru.PosX = enemyNembak.PosX;
            peluru.PosY = enemyNembak.PosY;
            PlaySound(ENEMY_NEMBAK_SOUND);
        }

        private List<EnemyModel> ListEnemyBawah()
        {
            var listPosX= _listEnemy
                .Where(x => x.IsAlive == 0)
                .Select(x => x.PosX)
                .Distinct().ToList();
            var listEnemyBawah = new List<EnemyModel>();
            foreach(var item in listPosX)
            {
                var enemyBawah = _listEnemy
                    .Where(x => x.IsAlive == 0)
                    .Where(x => x.PosX == item)
                    .OrderByDescending(x => x.PosY)
                    .First();
                listEnemyBawah.Add(enemyBawah);
            }
            return listEnemyBawah;
        }

        private EnemyModel GetRandomEnemyBawah()
        {
            var listEnemy = ListEnemyBawah();
            var randomX = new Random();
            var kolomRandom = randomX.Next(1, listEnemy.Count);
            var result = listEnemy.Take(kolomRandom).Last();
            return result;

        }
    }
}
