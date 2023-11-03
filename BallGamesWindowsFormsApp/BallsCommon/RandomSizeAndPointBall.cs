using System;
using System.Windows.Forms;

namespace BallsCommon
{
    public class RandomSizeAndPointBall: RandomPointBall
    {
        protected static Random random = new Random();
        public RandomSizeAndPointBall(Form form):base(form)
        {
            radius = random.Next(10, 70);
        }
    }
}
