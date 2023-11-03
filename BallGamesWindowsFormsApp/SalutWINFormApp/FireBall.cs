using BallsCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalutWINFormApp
{
    public class FireBall: MoveBall
    {
        public event EventHandler<FireEventArgs> Fire;
        private float g = 0.2f;
        public FireBall(MainForm form): base(form)
        {
            vy = - Math.Abs(vy);
            centerY = DownSide();

        }

        public bool Cut(int x, int y)
        {
            Point point = new Point(x, y);
            if (this.IsPointInCircle(point))
            {
                Fire.Invoke(this, new FireEventArgs(x, y));
                this.Stop();
                this.Clear();
                return true;
            }
            return false;
        }

        protected override void Go()
        {
            base.Go();
            vy += g;

        }
    }
}
