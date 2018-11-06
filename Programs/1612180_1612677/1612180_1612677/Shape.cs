using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _1612180_1612677
{
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
            using (Graphics graphics = Graphics.FromImage(base.bitmap))
            {
                graphics.DrawLine(base.pen, p1, p2);
            }
        }

        // vi khi click tung pixel rat kho
        // nen xet them nhung diem lan can
        public override bool isPointBelong(Point p)
        {
            List<Point> ps = new List<Point>();
            // XXX
            // XXX
            // XXX
            ps.Add(new Point(p.X - 1, p.Y - 1));
            ps.Add(new Point(p.X - 1, p.Y));
            ps.Add(new Point(p.X - 1, p.Y + 1));
            ps.Add(new Point(p.X, p.Y - 1));
            ps.Add(new Point(p.X, p.Y));
            ps.Add(new Point(p.X, p.Y + 1));
            ps.Add(new Point(p.X + 1, p.Y - 1));
            ps.Add(new Point(p.X + 1, p.Y));
            ps.Add(new Point(p.X + 1, p.Y + 1));

            bool flag = false;
            foreach (Point temp_p in ps)
            {
                flag |= isPointBelongPrecisely(temp_p);
            }

            return flag;
        }

        // kiem tra chinh xac mot diem
        public override bool isPointBelongPrecisely(Point p)
        {
            // su dung graphics path
            GraphicsPath path = new GraphicsPath();
            path.AddLine(p1, p2);
            return path.IsOutlineVisible(p, base.pen);
        }
    }

    public class MyRectangle : MyShape
    {
        private Point p1;
        private Point p2;
        private Point mostLeft = new Point();
        private int width;
        private int height;

        public MyRectangle(Bitmap _bitmap, Pen _pen, Point _p1, Point _p2) : base(_bitmap, _pen)
        {
            p1 = new Point(_p1.X, _p1.Y);
            p2 = new Point(_p2.X, _p2.Y);

            // tim diem goc trai
            // p1  X
            // X   p2
            if (p1.X < p2.X && p1.Y < p2.Y)
            {
                mostLeft.X = p1.X;
                mostLeft.Y = p1.Y;
            }
            // p2  X
            // X   p1
            else if (p2.X < p1.X && p2.Y < p1.Y)
            {
                mostLeft.X = p2.X;
                mostLeft.Y = p2.Y;
            }
            // X   p2
            // p1  X
            else if (p1.Y < p2.Y)
            {
                mostLeft.X = p2.X;
                mostLeft.Y = p1.Y;
            }
            // X   p1
            // p2  X
            else
            {
                mostLeft.X = p1.X;
                mostLeft.Y = p2.Y;
            }
            width = Math.Abs(p2.X - p1.X);
            height = Math.Abs(p2.Y - p1.Y);
        }

        public override void draw()
        {
            using (Graphics graphics = Graphics.FromImage(base.bitmap))
            {
                // ve hcn
                Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                graphics.DrawRectangle(base.pen, rectangle);
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(new Rectangle(mostLeft, new Size(width, height)));
                return path.IsOutlineVisible(p, base.pen);
            }
        }
    }

    public abstract class MyShape
    {
        protected Bitmap bitmap;
        protected Pen pen;

        public MyShape(Bitmap _bitmap, Pen _pen)
        {
            bitmap = _bitmap;
            pen = _pen;
        }

        public void changePen(Pen _pen)
        {
            pen = _pen;
        }

        public virtual void draw()
        {
        }

        public virtual bool isPointBelongPrecisely(Point p)
        {
            return false;
        }

        public virtual bool isPointBelong(Point p)
        {
            return false;
        }
    }
}