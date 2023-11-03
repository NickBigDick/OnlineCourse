using BallsCommon;
using System;
using System.Windows.Forms;

namespace BallsCommon
{
    public class RandomPointBall: Ball
    {
        protected static Random random = new Random();
        public RandomPointBall(Form form) : base(form) 
        {
            centerX = random.Next((int) LeftSide(), (int)RightSide());
            centerY = random.Next((int)TopSide(), (int)DownSide());
            vx = random.Next(-5, 5);
            vy = random.Next(-14, 15);



        }
    }
}
