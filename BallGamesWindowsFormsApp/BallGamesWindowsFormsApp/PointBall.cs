namespace BallGamesWindowsFormsApp
{
    public class PointBall: Ball
    {
        public PointBall(MainForm form, int x, int y): base(form)
        {
            this.centerY = y;
            this.centerX = x;
        }
    }
}
