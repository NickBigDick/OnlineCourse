using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AngryBirdsWinFormApp.BirdBall;

namespace AngryBirdsWinFormApp
{
    public partial class Form1 : Form
    {
        BirdBall birdBall;
        public int score;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            PigBall pigBall = new PigBall(this);
            pigBall.Show();
            birdBall = new BirdBall(this, pigBall);
            birdBall.Show();
            birdBall.HitPig += StopTheGame;

        }
        
        public void StopTheGame(object sender, HitPigEventArgs e)
        {
            score += 1;
            scoreLabel.Text = score.ToString();
            birdBall.Stop();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            birdBall.checkpointX = e.X;
            birdBall.checkpointY = e.Y;
            birdBall.Start();
        }

        public bool HitThePig()
        {
            return true;
        }
    }
}
