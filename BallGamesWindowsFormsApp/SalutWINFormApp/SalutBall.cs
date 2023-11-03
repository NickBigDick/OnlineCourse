using BallsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalutWINFormApp
{
    public class SalutBall: MoveBall
    {
        private float g = 0.2f;
        public SalutBall(MainForm form, int centerX, int centerY): base(form)
        {
            radius = 15;
            this.centerX = centerX;
            this.centerY = centerY;
            vy = -Math.Abs(vy);
        }

        protected override void Go()
        {
            base.Go();
            vy += g;
        }

    }

}
