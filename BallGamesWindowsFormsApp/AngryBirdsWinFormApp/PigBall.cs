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
    public class PigBall : RandomPointBall
    {
        public Point point;
        public PigBall(Form form) : base(form)
        {
            point = new Point((int)centerX, (int)centerY);
        }
    }
}
