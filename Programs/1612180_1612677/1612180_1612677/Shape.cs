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

        public MyLine(PenAttr _penAttr, Point _p1, Point _p2) :
            base(_penAttr)
        {
            p1 = new Point(_p1.X, _p1.Y);
            p2 = new Point(_p2.X, _p2.Y);
        }

        public override void draw(Bitmap bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    graphics.DrawLine(pen, p1, p2);
                }
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            // su dung graphics path
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(p1, p2);
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }
    }

    public class MyRectangle : MyShape
    {
        private int height;
        private Point mostLeft;
        private Point p1;
        private Point p2;
        private int width;

        public MyRectangle(PenAttr _penAttr, Point _p1, Point _p2) :
            base(_penAttr)
        {
            p1 = new Point(_p1.X, _p1.Y);
            p2 = new Point(_p2.X, _p2.Y);

            // tim diem goc trai
            mostLeft = new Point(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            width = Math.Abs(p2.X - p1.X);
            height = Math.Abs(p2.Y - p1.Y);
        }

        public override void draw(Bitmap bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                // ve hcn
                Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    graphics.DrawRectangle(pen, rectangle);
                }
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(new Rectangle(mostLeft, new Size(width, height)));
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    pen.DashStyle = base.penAttr.dashStyle;
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }
    }

    public abstract class MyShape
    {
        public MyShape(PenAttr _penAttr)
        {
            penAttr = _penAttr;
        }

        public PenAttr penAttr { get; set; }

        public virtual void draw(Bitmap bitmap)
        {
        }

        // vi khi click tung pixel rat kho
        // nen xet them nhung diem lan can
        public bool isPointBelong(Point p)
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
                // chi can mot diem nam trong la nam trong
                flag |= isPointBelongPrecisely(temp_p);
            }

            return flag;
        }

        // kiem tra chinh xac mot diem
        public virtual bool isPointBelongPrecisely(Point p)
        {
            return false;
        }
    }

    // Luu nhung thuoc tinh cua class Pen
    public class PenAttr
    {
        public PenAttr(Color _color, DashStyle _dashStyle, int _width)
        {
            color = _color;
            dashStyle = _dashStyle;
            width = _width;
        }

        public Color color { get; set; }
        public DashStyle dashStyle { get; set; }
        public int width { get; set; }
    }
}