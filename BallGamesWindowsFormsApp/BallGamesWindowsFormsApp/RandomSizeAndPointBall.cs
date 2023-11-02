using System;

namespace BallGamesWindowsFormsApp
{
    public class RandomSizeAndPointBall: RandomPointBall
    {
        protected static Random random = new Random();
        public RandomSizeAndPointBall(MainForm form):base(form)
        {
            radius = random.Next(10, 70);
        }
    }
}
