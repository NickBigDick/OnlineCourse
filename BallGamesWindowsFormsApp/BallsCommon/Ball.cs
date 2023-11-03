using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsCommon
{
    public class Ball
    {
        private Form form;
        protected int centerX;
        protected int centerY;
        protected int vx = 1;
        protected int vy = 1;
        protected int radius = 25;
        protected Brush ballBrush = Brushes.Aqua;

        public Ball(Form form)
        {
            this.form = form;
        }

        public void Show()
        {
            Draw(ballBrush);
        }

        protected virtual void Go()
        {
            centerX += vx;
            centerY += vy;
        }
        private void Clear()
        {
            Draw(Brushes.Gainsboro);
        }

        public bool IsBallInForm()
        {
            if (form.Width >= centerX && centerX >= 0 && form.Height >= centerY && centerY >= 0)
            {
                return true;
            }
            return false;
        }

        public bool IsPointInCircle(Point point)
        {
            bool check = Math.Pow(centerX - point.X, 2) + Math.Pow(centerY - point.Y, 2) <= Math.Pow(radius, 2);
            if (check) { return true; }
            return false;
        }
        public void Move()
        {
            Clear();
            Go();
            Show();
        }

        private void Draw(Brush brush)
        {
            var graphics = form.CreateGraphics();
            var rectangle = new Rectangle(centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            graphics.FillEllipse(brush, rectangle);
        }

        public int LeftSide()
        {
            return radius;
        }

        public int RightSide()
        {
            return form.Width - radius;
        }
        public int TopSide()
        {
            return radius;
        }
        public int DownSide()
        {
            return form.Height - radius;
        }
    }
}
