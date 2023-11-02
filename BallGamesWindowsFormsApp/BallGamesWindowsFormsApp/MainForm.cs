using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallGamesWindowsFormsApp
{
    public partial class MainForm : Form
    {
        List<MoveBall> moveBalls;
        PointBall pointBall;
        public MainForm()
        {
            InitializeComponent();
        }

        //private void MainForm_MouseDown(object sender, MouseEventArgs e)
        //{
        //    pointBall = new PointBall(this, e.X, e.Y);
        //    pointBall.Show();
        //}

        private void manyBalls_Click(object sender, EventArgs e)
        {
            moveBalls = new List<MoveBall>();
            for (int i = 0; i < 10;  i++)
            {
                MoveBall moveBall = new MoveBall(this);
                moveBalls.Add(moveBall);
                moveBall.Show();
                this.manyBalls.Text = $"{i}";
                //moveBall.Start();
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            int counter = 0;
            foreach (MoveBall moveBall in moveBalls)
            {
                moveBall.Stop();
                counter += moveBall.IsBallInForm() == true ? 1: 0;
            }
            MessageBox.Show($"я поймал {counter} шариков");
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            moveBalls = new List<MoveBall>();
            for (int i = 0;i < 10; i++)
            {
                MoveBall moveBall = new MoveBall(this);
                moveBall.Start();
                moveBalls.Add(moveBall);
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            Point point = new Point(mouseX, mouseY);

            foreach (MoveBall moveBall in moveBalls)
            {
                bool check = moveBall.IsPointInCircle(point);
                if (check) { moveBall.Stop(); break; }
            }

        }
    }
}
