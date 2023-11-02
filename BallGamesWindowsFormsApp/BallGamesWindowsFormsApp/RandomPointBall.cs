using System;

namespace BallGamesWindowsFormsApp
{
    public class RandomPointBall: Ball
    {
        protected static Random random = new Random();
        public RandomPointBall(MainForm form) : base(form) 
        {
            centerX = random.Next(LeftSide(), RightSide());
            centerY = random.Next(TopSide(), DownSide());
            vx = random.Next(-5, 5);
            vy = random.Next(-5, 5);



        }
    }
}
