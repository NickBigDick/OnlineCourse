using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalutWINFormApp
{
    public class FireEventArgs
    {
        public int Y;
        public int X;
        public FireEventArgs(int x, int y)
        {
            Y = y;
            X = x;
        }   
    }
}
