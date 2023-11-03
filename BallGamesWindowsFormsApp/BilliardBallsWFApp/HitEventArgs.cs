namespace BilliardBallsWFApp
{
    public partial class BilliardBall
    {
        public class HitEventArgs
        {
            public Side Side;
            public HitEventArgs(Side side)
            {
                Side = side;
            }
        }
    }
}
