using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalutWINFormApp
{
    public partial class MainForm : Form
    {
        //до любой точки y поднимается снизу шарик
        //пользователь жмет на экран
        //если попал в шарик срабатывает евент
        //взрыавются шарики
        private List<FireBall> fireBalls;
        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fireBalls = new List<FireBall>();
            var random = new Random();
            var count = random.Next(0, 10);
            for (int i = 0; i < count; i++)
            {
                var fireBall = new FireBall(this);
                fireBalls.Add(fireBall);
                fireBall.Fire += Fire_Place_Taken;
                fireBall.Start();
            }
        }


        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (FireBall fireBall in fireBalls.ToArray())
            {
                if (fireBall.Cut(e.X, e.Y))
                {
                    fireBalls.Remove(fireBall);
                }

            }

        }

        private void Fire_Place_Taken(object sender, FireEventArgs e)
        {
            //фейрверк
            var random = new Random();
            var count = random.Next(0, 10);
            for (int i = 0; i < count; i++)
            {
                var salut = new SalutBall(this, e.X, e.Y);
                salut.Start();
            }
        }

    }
}
