
namespace AngryBirdsWinFormApp
{
    public partial class BirdBall 
    {
        public class HitPigEventArgs
        {
            public bool YouHitThePig;
            public HitPigEventArgs(bool hitpig)
            {
                YouHitThePig = hitpig;
            }
        }
    }
}
