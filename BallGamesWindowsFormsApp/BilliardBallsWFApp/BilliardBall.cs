using BallsCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilliardBallsWFApp
{
    public partial class BilliardBall : MoveBall
    {
        public event EventHandler<HitEventArgs> OnHitted;
        public BilliardBall(Form form, Brush brush) : base(form)
        {
            ballBrush = brush;
        }

        protected override void Go()
        {
            base.Go();
            if (centerX <= LeftSide())
            {
                vx = -vx;
                OnHitted.Invoke(this, new HitEventArgs(Side.Left));
            }
            if(centerX >= RightSide())
            {
                vx = -vx;
                OnHitted.Invoke(this, new HitEventArgs(Side.Right));
            }
            if (centerY <= TopSide() )
            {
                vy = -vy;
                OnHitted.Invoke(this, new HitEventArgs(Side.Top));

            }
            if (centerY >= DownSide())
            {
                vy = -vy;
                OnHitted.Invoke(this, new HitEventArgs(Side.Down));
            }
        }
    }
}
