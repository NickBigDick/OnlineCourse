namespace BallGamesWindowsFormsApp
{
    public class PointBall: Ball
    {
        public PointBall(MainForm form, int x, int y): base(form)
        {
            this.y = y;
            this.x = x;
        }
    }
}
