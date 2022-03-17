using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LW_2_15
{
    internal class Ball
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Radius { get; private set; }
        public System.Drawing.Color Color { get; set; }

        private Random _rn;

        public Ball(int x, int y, Random rn)
        {
            X = x;
            Y = y;
            Radius = rn.Next(40, 70);
            Color = System.Drawing.Color.FromArgb(rn.Next(0, 255), rn.Next(0, 255), rn.Next(0, 255));

            _rn = rn;
        }

        public void Update()
        {
            while (true)
            {
                X += _rn.Next(-1, 2) * _rn.Next(1, 5);
                Y += _rn.Next(-1, 2) * _rn.Next(1, 5);
                Thread.Sleep(1);
                //Thread.Yield();
            }
        }
    }
}
