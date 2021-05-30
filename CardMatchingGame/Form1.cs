using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

namespace CardMatchingGame
{
    public partial class Form1 : Form
    {
        static List<Label> labels = new List<Label>();
        static List<Button> buttons = new List<Button>();
        static List<int> buttonTag = new List<int>();
        static string path = "D:\\zahid\\bsm\\20-21-Bahar\\yazlab2\\CardMatchingGame\\CardMatchingGame\\CardMatchingGame\\images\\";
        static string pathc1 = path + "\\apple-icon.png";
        static string pathc2 = path + "\\grapes-icon.png";
        static string pathc3 = path + "\\lemon-icon.png";
        static string pathc4 = path + "\\pear-icon.png";
        static string pathc5 = path + "\\watermelon-icon.png";
        static int score = 0;
        static int second;

        static string soundpath = "D:\\zahid\\bsm\\20-21-Bahar\\yazlab2\\CardMatchingGame\\CardMatchingGame\\CardMatchingGame\\sound";
        static string correctsound = soundpath + "\\correctsound.wav";
        static string wrongsound = soundpath + "\\wrongsound.wav";

        SoundPlayer soundPlayer;

        static int a = 0;
        static int count = 0;


        public Form1()
        {
            InitializeComponent();

            second = 60;

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            buttons.Add(button10);

        }
        
        public void MakeVisible(int a)
        {
            if (a == 1)
            {
                button1.Visible = false;
                button2.Visible = false;
            }
            if (a == 2)
            {
                button3.Visible = false;
                button4.Visible = false;
            }
            if (a == 3)
            {
                button5.Visible = false;
                button6.Visible = false;
            }
            if (a == 4)
            {
                button7.Visible = false;
                button8.Visible = false;
            }
            if (a == 5)
            {
                button9.Visible = false;
                button10.Visible = false;
            }
        }

        public void Match( int tag)
        {
            timer1.Start();
            buttonTag.Add(tag);
            if (buttonTag.Count==2) //make a match
            {
                
                if (buttonTag.Contains(1) && buttonTag.Contains(2))
                {
                    a = 1;
                }
                if (buttonTag.Contains(3) && buttonTag.Contains(4))
                {
                    a = 2;
                }
                if (buttonTag.Contains(5) && buttonTag.Contains(6))
                {
                    a = 3;
                }
                if (buttonTag.Contains(7) && buttonTag.Contains(8))
                {
                    a = 4;
                }
                if (buttonTag.Contains(9) && buttonTag.Contains(10))
                {
                    a = 5;
                }

                if (buttonTag[0] == buttonTag[1])
                {
                    SetDefaultİmage();
                    score = score - 200;
                    scoreTxt.Text = "Score: " + score.ToString();
                }
                else if (a == 1 || a == 2 || a == 3 || a == 4 || a ==5)
                {
                    timer1.Stop(); // stop the time, until user click a card.
                    soundPlayer=  new SoundPlayer(correctsound);
                    soundPlayer.Play();
                    isCorrectLbl.Text = "Correct!";
                    MessageBox.Show("Correct!");
                    MakeVisible(a);
                    score = score + 100;
                    scoreTxt.Text = "Score: " + score.ToString();
                    //SetDefaultİmage(); //is necessary?
                    a = 0;
                    count++;
                }
                else
                {
                    soundPlayer = new SoundPlayer(wrongsound);
                    soundPlayer.Play();
                    isCorrectLbl.Text = "False";
                    MessageBox.Show("False!");
                    SetDefaultİmage();
                }
                buttonTag.Clear();
                isCorrectLbl.Text = " ";
            }
            
            

            if (count==5)
            {
                count = 0;
                timer1.Stop();
                MessageBox.Show("Finish!");
                EndGamePage endGamePage = new EndGamePage(score, second);
                endGamePage.Show();
                Hide();
            }
            
        }

        public void SetDefaultİmage()
        {
            //ImageList imageList = new ImageList();
            //imageList.Images.Add(Image.FromFile("D:\\zahid\\bsm\\20-21-Bahar\\yazlab2\\CardMatchingGame\\CardMatchingGame\\CardMatchingGame\\images\\orange-icon.png"));
            //Bitmap resim = new Bitmap(imageList.Images[0],new Size(128, 177));
            
            string pathdefault = "D:\\zahid\\bsm\\20-21-Bahar\\yazlab2\\CardMatchingGame\\CardMatchingGame\\CardMatchingGame\\images\\qm.png";
            button1.Image = Image.FromFile(pathdefault);
            button2.Image = Image.FromFile(pathdefault);
            button3.Image = Image.FromFile(pathdefault);
            button4.Image = Image.FromFile(pathdefault);
            button5.Image = Image.FromFile(pathdefault);
            button6.Image = Image.FromFile(pathdefault);
            button7.Image = Image.FromFile(pathdefault);
            button8.Image = Image.FromFile(pathdefault);
            button9.Image = Image.FromFile(pathdefault);
            button10.Image = Image.FromFile(pathdefault);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            score = 0;
            buttonTag.Clear(); // to clean start for new game
            //timer1.Start();
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                int random1 = rnd.Next(0, 10);
                int random2 = rnd.Next(0, 10);
                
                while ( random1 >= buttons.Count)
                {
                    random1 = rnd.Next(0, 10);

                }
                

                while ( random2 >= labels.Count)
                {
                    random2 = rnd.Next(0, 10);
                }

                //MessageBox.Show("tur:" + (i + 1) + ". " + random1.ToString() + "," + random2.ToString());
                buttons[random1].Location = labels[random2].Location;
                buttons.RemoveAt(random1);
                labels.RemoveAt(random2);
            }
            SetDefaultİmage();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Image = Image.FromFile(pathc1);
            Match(Convert.ToInt16(button1.Tag));
        }

        private void button2_Click(object sender, EventArgs e)
        {          
            button2.Image = Image.FromFile(pathc1);
            Match(Convert.ToInt16(button2.Tag));
        }

        private void button3_Click(object sender, EventArgs e)
        {           
            button3.Image = Image.FromFile(pathc2);
            Match(Convert.ToInt16(button3.Tag));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Image = Image.FromFile(pathc2);
            Match(Convert.ToInt16(button4.Tag));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            button5.Image = Image.FromFile(pathc3);
            Match(Convert.ToInt16(button5.Tag));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Image = Image.FromFile(pathc3);
            Match(Convert.ToInt16(button6.Tag));
        }

        private void button7_Click(object sender, EventArgs e)
        {          
            button7.Image = Image.FromFile(pathc4);
            Match(Convert.ToInt16(button7.Tag));
        }

        private void button8_Click(object sender, EventArgs e)
        {  
            button8.Image = Image.FromFile(pathc4);
            Match(Convert.ToInt16(button8.Tag));
        }

        private void button9_Click(object sender, EventArgs e)
        {           
            button9.Image = Image.FromFile(pathc5);
            Match(Convert.ToInt16(button9.Tag));
        }

        private void button10_Click(object sender, EventArgs e)
        {           
            button10.Image = Image.FromFile(pathc5);
            Match(Convert.ToInt16(button10.Tag));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            second = second - 1;
            timeLbl.Text = Convert.ToString(second) + " second";
            if (second==0)
            {
                timer1.Stop();
                string message = "Time is over! Tyr again?";
                string title = "Time is Over";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    buttonTag.Clear(); // to clean start for new game
                    Form1 form1 = new Form1();
                    form1.Show();
                    Hide();
                }
                else
                {
                    EndGamePage endGamePage = new EndGamePage(score, second);
                    endGamePage.Show();
                    Hide();
                }
                
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            Close();
        }
    }
}
