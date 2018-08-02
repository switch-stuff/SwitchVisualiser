using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace SwitchVisualiser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var Open = new SoundPlayer(@"assets\openmenu.wav");
            Open.Play();
            pictureBox1.ImageLocation = @"assets\title1.jpg";
            pictureBox2.ImageLocation = @"assets\title2.jpg";
            pictureBox3.ImageLocation = @"assets\title3.jpg";
            pictureBox4.ImageLocation = @"assets\title4.jpg";
            pictureBox5.ImageLocation = @"assets\title5.jpg";
            BackColor = Configs.Themes.BasicBlack.Background;
            MyPhoto();
        }

        PictureBox box;
        int IconPosition = 1;

        private float mBlend;
        private int mDir = 1;
        public int count = 0;
        public Bitmap[] pictures;

        public void MyPhoto()
        {
            pictures = new Bitmap[2];
            pictures[0] = new Bitmap(@"assets\outline1.png");
            pictures[1] = new Bitmap(@"assets\outline2.png");

            timer1.Interval = 1;
            timer1.Tick += BlendTick;
            try
            {
                blendPanel1.Image1 = pictures[count];
                blendPanel1.Image2 = pictures[++count];
            }
            catch
            {

            }
            timer1.Enabled = true;
        }
        private void BlendTick(object sender, EventArgs e)
        {
            mBlend += mDir * 1/32F;
            if (mBlend > 1)
            {
                mBlend = 0.0F;
                if ((count + 1) < pictures.Length)
                {
                    blendPanel1.Image1 = pictures[count];
                    blendPanel1.Image2 = pictures[++count];
                }
                else
                {
                    blendPanel1.Image1 = pictures[count];
                    blendPanel1.Image2 = pictures[0];
                    count = 0;
                }
            }
            blendPanel1.Blend = mBlend;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                System.Threading.Thread.Sleep(40);
                if (blendPanel1.Location.X >= 120)
                {
                    IconPosition--;
                    var Tick = new SoundPlayer(@"assets\tick.wav");
                    Tick.Play();
                    blendPanel1.Location = new Point(blendPanel1.Location.X - 270, blendPanel1.Location.Y);
                }
                else
                {
                    var Donk = new SoundPlayer(@"assets\donk.wav");
                    Donk.Play();
                    timer4.Start();
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                IconPosition++;
                System.Threading.Thread.Sleep(40);
                var Tick = new SoundPlayer(@"assets\tick.wav");
                Tick.Play();
                blendPanel1.Location = new Point(blendPanel1.Location.X + 270, blendPanel1.Location.Y);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (IconPosition == 1)
                {
                    box = pictureBox1;
                }
                else if (IconPosition == 2)
                {
                    box = pictureBox2;
                }
                else if (IconPosition == 3)
                {
                    box = pictureBox3;
                }
                else if (IconPosition == 4)
                {
                    box = pictureBox4;
                }
                else if (IconPosition == 5)
                {
                    box = pictureBox5;
                }
                System.Threading.Thread.Sleep(40);
                var Title = new SoundPlayer(@"assets\title.wav");
                Title.Play();              
                timer2.Start();
            }
        }

        int counterAnimShrink = 0;
        int counterAnimGrow = 0;
        int counterDonkLeft = 0;
        int counterDonkRight = 0;
        int counterDonkFinal = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            box.Size = new Size(box.Size.Width - 4, box.Size.Height - 4);
            blendPanel1.Size = new Size(blendPanel1.Size.Width - 4, blendPanel1.Size.Height - 4);
            box.Location = new Point(box.Location.X + 4, box.Location.Y + 4);
            blendPanel1.Location = new Point(blendPanel1.Location.X + 4, blendPanel1.Location.Y + 4);
            counterAnimShrink++;
            if (counterAnimShrink == 2)
            {
                timer2.Stop();
                timer3.Start();
                counterAnimShrink = 0;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            box.Size = new Size(box.Size.Width + 4, box.Size.Height + 4);
            blendPanel1.Size = new Size(blendPanel1.Size.Width + 4, blendPanel1.Size.Height + 4);
            box.Location = new Point(box.Location.X - 4, box.Location.Y - 4);
            blendPanel1.Location = new Point(blendPanel1.Location.X - 4, blendPanel1.Location.Y - 4);
            counterAnimGrow++;
            if (counterAnimGrow == 2)
            {
                timer3.Stop();
                counterAnimGrow = 0;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var Title = new SoundPlayer(@"assets\title.wav");
            Title.Play();
            timer2.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            blendPanel1.Location = new Point(blendPanel1.Location.X - 6, blendPanel1.Location.Y);
            counterDonkLeft++;
            if (counterDonkLeft == 3)
            {
                timer4.Stop();
                timer5.Start();
                counterDonkLeft = 0;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            blendPanel1.Location = new Point(blendPanel1.Location.X + 10, blendPanel1.Location.Y);
            counterDonkRight++;
            if (counterDonkRight == 3)
            {
                timer5.Stop();
                timer6.Start();
                counterDonkRight = 0;
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            blendPanel1.Location = new Point(blendPanel1.Location.X - 4, blendPanel1.Location.Y);
            counterDonkFinal++;
            if (counterDonkFinal == 3)
            {
                timer6.Stop();
                counterDonkFinal = 0;
            }
        }
    }
}
