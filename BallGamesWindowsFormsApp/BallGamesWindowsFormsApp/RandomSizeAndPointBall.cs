using System;

namespace BallGamesWindowsFormsApp
{
    public class RandomSizeAndPointBall: RandomPointBall
    {
        protected Random random = new Random();
        public RandomSizeAndPointBall(MainForm form):base(form)
        {
            size = random.Next(10, 70);
        }
    }
}
