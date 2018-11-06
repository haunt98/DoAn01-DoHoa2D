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

        // kiem tra chinh xac mot diem
        public bool isPointBelongPrecisely(Point p)
        {
            // su dung graphics path
            GraphicsPath path = new GraphicsPath();
            path.AddLine(p1, p2);
            return path.IsOutlineVisible(p, base.pen);
        }

        // vi khi click tung pixel rat kho
        // nen xet them nhung diem lan can
        public override bool isPointBelong(Point p)
        {
            List<Point> ps = new List<Point>();
            //  X
            // XXX
            //  X
            ps.Add(new Point(p.X, p.Y));
            ps.Add(new Point(p.X - 1, p.Y));
            ps.Add(new Point(p.X, p.Y - 1));
            ps.Add(new Point(p.X, p.Y + 1));
            ps.Add(new Point(p.X + 1, p.Y));

            bool flag = false;
            foreach (Point temp_p in ps)
            {
                flag |= isPointBelongPrecisely(temp_p);
            }

            return flag;
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