using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallGamesWindowsFormsApp
{
    public class Ball
    {
        private MainForm form;
        protected int x;
        protected int y;
        protected int vx = 1;
        protected int vy = 1;
        protected int size = 30;

        public Ball(MainForm form)
        {
            this.form = form;
        }

        public void Show()
        {
            var graphics = form.CreateGraphics();
            var brash = Brushes.Aqua;
            var rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brash, rectangle);
        }

        private void Go()
        {
            x += vx;
            y += vy;
        }
        private void Clear()
        {
            var graphics = form.CreateGraphics();
            var brash = Brushes.Silver;
            var rectangle = new Rectangle(x, y, size, size);
            graphics.FillEllipse(brash, rectangle);

        }

        public bool IsBallInForm()
        {
            if (form.Width >= x && x >= 0 && form.Height >= y && y >= 0)
            {
                return true;
            }
            return false;
        }

        public bool IsPointInCircle(Point point)
        {
            bool check = Math.Pow(x - point.X, 2) + Math.Pow(y - point.Y, 2) <= Math.Pow(size, 2);
            if (check) { return true; }
            return false;
        }
        public void Move()
        {
            Clear();
            Go(); 
            Show();
        }

        
    }
}
