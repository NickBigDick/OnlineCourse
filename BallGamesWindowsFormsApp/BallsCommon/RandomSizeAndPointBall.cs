using System;
using System.Windows.Forms;

namespace BallsCommon
{
    public class RandomSizeAndPointBall: RandomPointBall
    {
        protected static Random newrandom = new Random();
        public RandomSizeAndPointBall(Form form):base(form)
        {
            radius = newrandom.Next(10, 70);
        }
    }
}
