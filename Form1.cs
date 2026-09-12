using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game_Projet
{
    public partial class Form1 : Form
    {
        Button Prev = null;

        int Counter = 0;
        long Seconds = 0;
        Image defaultImage = Properties.Resources.cherry_blossom_bro;
        void Star()
        {

            PictureBox[] stars = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5 };

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Image = (i < Counter) ? Properties.Resources.star : Properties.Resources.star__1_;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbSpeed.SelectedIndex = 0;
            cbTimer.SelectedIndex = 0;
            lblTimeResult.Text = "00:00";
            Star();
            Shufflearray();
        }
        void Speed()
        {
            if (cbSpeed.SelectedIndex == 0)
            {
                timer1.Interval = 1000;
            }
            else if (cbSpeed.SelectedIndex == 1)
            {
                timer1.Interval = 750;
            }
            else
            {
                timer1.Interval = 500;
            }
        }
        void Timer()
        {
            if (cbTimer.SelectedIndex == 0)
            {
                Seconds = 60;
            }
            else if (cbTimer.SelectedIndex == 1)
            {
                Seconds = 60 * 2;
            }
            else if (cbTimer.SelectedIndex == 2)
            {
                Seconds = 60 * 3;
            }
            else if (cbTimer.SelectedIndex == 3)
            {
                Seconds = 60 * 4;
            }
            else
            {
                Seconds = 60 * 5;
            }
            timer1.Enabled = true;
        }

        void Run()
        {
            Counter = 0;
            Timer();
            lblTimeResult.Text = "";
            Button[] arr = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Enabled = true;
            }
            Speed();

        }
        private void btnStar_Click(object sender, EventArgs e)
        {

            Run();
        }
        private void RestartGame()
        {
            timer1.Stop();
            Counter = 0;
            Prev = null;
            Star();
            Shufflearray();
            lblTimeResult.Text = "00:00";

        }
        void Shufflearray()
        {
            int[] arr = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
            Random random = new Random();
            arr = arr.OrderBy(x => random.Next()).ToArray();
            Button[] buttons = { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10 };

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Tag = arr[i];
                buttons[i].BackgroundImage = defaultImage;
            }

        }
        void RandomPicture(Button Now)
        {

            if (Now.Tag.ToString() == "1")
            {
                Now.BackgroundImage = Properties.Resources.trawl_fishing_pana;
            }
            else if (Now.Tag.ToString() == "2")
            {
                Now.BackgroundImage = Properties.Resources.trawl_fishing_rafiki;
            }
            else if (Now.Tag.ToString() == "3")
            {
                Now.BackgroundImage = Properties.Resources.trawl_fishing_amico;
            }
            else if (Now.Tag.ToString() == "4")
            {
                Now.BackgroundImage = Properties.Resources.trawl_fishing_bro;
            }
            else if (Now.Tag.ToString() == "5")
            {
                Now.BackgroundImage = Properties.Resources.trawl_fishing_cuate;
            }

        }
        private void btnResatart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
        void ChangeTime()
        {
            if (Seconds > 0)
            {
                Seconds--;
                TimeSpan Time = TimeSpan.FromSeconds(Seconds);
                lblTimeResult.Text = Time.ToString(@"mm\:ss");
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("انتهى الوقت!", "خسارة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void PlayButton(Button Now)
        {
            if (Now.BackgroundImage == defaultImage)
            {
                RandomPicture(Now);


                if (Prev == null)
                {
                    Prev = Now;

                }
                else
                {
                    Check(Now);

                    Prev = null;
                }



            }
            else
            {
                MessageBox.Show("error u chosed before");
            }

        }

     

        private void timerFlip_Tick(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeTime();
        }
        void Check(Button Now)
        {
            if (Now.Tag.ToString() == Prev.Tag.ToString())
            {
                Counter++;
                MessageBox.Show("جيد "+Counter);
                Star();
                if (Counter == 5)
                {
                    timer1.Stop();

                    MessageBox.Show("أحسنت! لقد فزت باللعبة 🎉", "الفوز");

                }
            }
            else
            {
                MessageBox.Show("ما يها ذاكرتك");
                Now.BackgroundImage = defaultImage;

                Prev.BackgroundImage = defaultImage;

            }
        }

      

        private void Clickbtn(object sender, EventArgs e)
        {
            PlayButton((Button)(sender));
        }
    }
}
