using BallsCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BilliardBallsWFApp.BilliardBall;

namespace BilliardBallsWFApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Ball> ballList = new List<Ball>();
            for (int i=0; i<10; i++)
            {
                BilliardBall blueball = new BilliardBall(this, Brushes.Blue);
                blueball.OnHitted += Ball_OnHitted_Blue;
                ballList.Add(blueball);
                blueball.Start();
                BilliardBall redball = new BilliardBall(this, Brushes.Red);
                redball.OnHitted += Ball_OnHitted_Red;
                ballList.Add(redball);
                redball.Start();
            }

        }

        private void Ball_OnHitted_Blue(object sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left: 
                    leftBlueLabel.Text = (Convert.ToInt32(leftBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightBlueLabel.Text = (Convert.ToInt32(rightBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topBlueLabel.Text = (Convert.ToInt32(topBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Down:
                    downBlueLabel.Text = (Convert.ToInt32(downBlueLabel.Text) + 1).ToString();
                    break;
            }
        }
        private void Ball_OnHitted_Red(object sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftRedLabel.Text = (Convert.ToInt32(leftRedLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightRedLabel.Text = (Convert.ToInt32(rightRedLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topRedLabel.Text = (Convert.ToInt32(topRedLabel.Text) + 1).ToString();
                    break;
                case Side.Down:
                    downRedLabel.Text = (Convert.ToInt32(downRedLabel.Text) + 1).ToString();
                    break;
            }
        }

    }
}
