using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _1612180_1612677
{
    public abstract class MyShape
    {
        protected Bitmap bitmap;
        protected Pen pen;

        public MyShape(Bitmap _bitmap, Pen _pen)
        {
            bitmap = _bitmap;
            pen = _pen;
        }

        public virtual void draw()
        {
        }

        public virtual bool isPointBelong(Point p)
        {
            return false;
        }

        public virtual void changePen(Pen _pen)
        {
            pen = _pen;
        }
    }

    public class MyLine : MyShape
    {
        private Point p1;
        private Point p2;

        public MyLine(Bitmap _bitmap, Pen _pen, Point _p1, Point _p2) : base(_bitmap, _pen)
        {
            p1 = new Point(_p1.X, _p1.Y);
            p2 = new Point(_p2.X, _p2.Y);
        }

        public override void draw()
        {
            Graphics graphics = Graphics.FromImage(base.bitmap);
            graphics.DrawLine(base.pen, p1, p2);
            graphics.Dispose();
        }

        // https://stackoverflow.com/questions/34171073/c-sharp-how-do-i-detect-if-a-line-painted-drawn-on-a-form-has-been-clicked-on
        public override bool isPointBelong(Point p)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(p1, p2);
            return path.IsOutlineVisible(p, base.pen);
        }

        public override void changePen(Pen _pen)
        {
            base.changePen(_pen);
        }
    }

    public class MyRectangle : MyShape
    {
        private Point p1;
        private Point p2;

        public MyRectangle(Bitmap _bitmap, Pen _pen, Point _p1, Point _p2) : base(_bitmap, _pen)
        {
            p1 = new Point(_p1.X, _p1.Y);
            p2 = new Point(_p2.X, _p2.Y);
        }

        public override void draw()
        {
        }
    }
}