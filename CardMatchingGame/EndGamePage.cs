using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardMatchingGame
{
    public partial class EndGamePage : Form
    {
        static string soundpath = "D:\\zahid\\bsm\\20-21-Bahar\\yazlab2\\CardMatchingGame\\CardMatchingGame\\CardMatchingGame\\sound";
        static string clap = soundpath + "\\clap.wav";
        static string timeover = soundpath + "\\timeover.wav";
        SoundPlayer soundPlayer;
        public EndGamePage(int score, int second)
        {
            InitializeComponent();
            if (second==0)
            {
                soundPlayer = new SoundPlayer(timeover);
                soundPlayer.Play();
                nameLbl.Text = "NAME: " + MainPage.name;
                scoreLbl.Text = "SCORE: " + score.ToString();
                timeLbl.Text = "TIME: " + second.ToString();
            }
            else if (second>0)
            {
                soundPlayer = new SoundPlayer(clap);
                soundPlayer.Play();
                nameLbl.Text = "NAME: " + MainPage.name;
                scoreLbl.Text = "SCORE: " + score.ToString();
                timeLbl.Text = "TIME: +" + second.ToString();
            }

            
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            
            MainPage mainPage = new MainPage();
            mainPage.Show();
            Hide();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
