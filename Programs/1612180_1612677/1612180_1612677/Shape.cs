using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _1612180_1612677
{
    public abstract class MyShape
    {
        protected Bitmap bitmap;

        public MyShape(Bitmap _bitmap)
        {
            bitmap = _bitmap;
        }

        public virtual void draw()
        {
        }
    }

    public class MyLine : MyShape
    {
        private Point p1;
        private Point p2;

        public MyLine(Bitmap _bitmap, Point _p1, Point _p2) : base(_bitmap)
        {
            p1 = new Point(_p1.X, _p1.Y);
            p2 = new Point(_p2.X, _p2.Y);
        }

        public override void draw()
        {
            Graphics graphics = Graphics.FromImage(base.bitmap);
            graphics.DrawLine(new Pen(Color.Red), p1, p2);
            graphics.Dispose();
        }
    }

    public class MyRectangle : MyShape
    {
        private Point p1;
        private Point p2;

        public MyRectangle(Bitmap _bitmap, Point _p1, Point _p2) : base(_bitmap)
        {
            p1 = new Point(_p1.X, _p1.Y);
            p2 = new Point(_p2.X, _p2.Y);
        }

        public override void draw()
        {
        }
    }
}