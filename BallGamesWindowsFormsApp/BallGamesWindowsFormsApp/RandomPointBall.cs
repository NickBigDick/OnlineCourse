using System;

namespace BallGamesWindowsFormsApp
{
    public class RandomPointBall: Ball
    {
        protected static Random random = new Random();
        public RandomPointBall(MainForm form) : base(form) 
        {
            x = random.Next(form.Width);
            y = random.Next(form.Height);
            vx = random.Next(-5, 5);
            vy = random.Next(-5, 5);



        }
    }
}
