using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrix
{
    public class Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            if (x < 0 || y < 0) throw new Exception("Not allowed to have point below zero");
            this.x = x;
            this.y = y;
        }

        public Point add(Point p)
        {
            return new Point(x + p.y, y + p.x);
        }

        public Point sub(Point p)
        {
            return new Point(x - p.y, y - p.x);
        }
    }
}
