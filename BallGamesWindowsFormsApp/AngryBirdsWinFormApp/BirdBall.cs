using BallsCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AngryBirdsWinFormApp
{
    public partial class BirdBall : Ball
    {
        private Timer timer;
        public int checkpointX;
        public int checkpointY;
        Point point;
        bool achievedCheckPoint;
        private float g = 0.2f;
        public event EventHandler<HitPigEventArgs> HitPig;
        public PigBall pigBall;
        public BirdBall(Form form, PigBall pigball) : base(form)
        {
            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += Timer_Tick;
            centerY = DownSide() - radius;
            pigBall = pigball;
        }

        private void GetCheckedCoordinates()
        {
            vx = (checkpointX - centerX) * g;
            vy = (checkpointY - centerY) * g;
            point = new Point(checkpointX, checkpointY);
        }

        public void Fly()
        {
            if (IsPointInCircle(point))
            {
                achievedCheckPoint = true;
            }
            if (achievedCheckPoint)
            {
                vy += g;
                Move();
            }
            else
            {
                Move();
            }
            IfAchieveTheGround();
            if (IfHitThePig())
            {
                HitPig.Invoke(this, new HitPigEventArgs(true));
            }
        }

        public void IfAchieveTheGround()
        {
            Point groudPoint = new Point((int)centerX, (int)DownSide());
            bool ground = IsPointInCircle(groudPoint);
            if (ground)
            {
                if (vy - vy * 3 / 4 < 1)
                {
                    Stop();
                }
                else
                {
                    vy = -vy * 3 / 4;
                }
            }
        }

        public bool IfHitThePig()
        {
            Point point = pigBall.point;
            if (IsPointInCircle(point))
            {
                return true;
            }
            return false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Fly();
        }

        public void Start()
        {
            GetCheckedCoordinates();
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
