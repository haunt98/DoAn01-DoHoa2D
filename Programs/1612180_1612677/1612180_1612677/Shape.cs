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
        private Point p_end;
        private Point p_start;

        public MyLine(PenAttr _penAttr, Point _p_start, Point _p_end) :
            base(_penAttr)
        {
            p_start = new Point(_p_start.X, _p_start.Y);
            p_end = new Point(_p_end.X, _p_end.Y);
        }

        public MyLine(MyLine myLine) :
            base(myLine)
        {
            p_start = new Point(myLine.p_start.X, myLine.p_start.Y);
            p_end = new Point(myLine.p_end.X, myLine.p_end.Y);
        }

        public override MyShape Clone()
        {
            return new MyLine(this);
        }

        public override void draw(Bitmap _bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    graphics.DrawLine(pen, p_start, p_end);
                }
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            // su dung graphics path
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(p_start, p_end);
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }
    }

    public class MyEllipse : MyShape
    {
        private int height;
        private Point mostLeft;
        private int width;

        public MyEllipse(PenAttr _penAttr, Point p_start, Point p_end) :
            base(_penAttr)
        {
            mostLeft = new Point(Math.Min(p_start.X, p_end.X), Math.Min(p_start.Y, p_end.Y));
            width = Math.Abs(p_start.X - p_end.X);
            height = Math.Abs(p_start.Y - p_end.Y);
        }

        public MyEllipse(MyEllipse myEllipse) :
            base(myEllipse)
        {
            mostLeft = new Point(myEllipse.mostLeft.X, myEllipse.mostLeft.Y);
            width = myEllipse.width;
            height = myEllipse.height;
        }

        public override MyShape Clone()
        {
            return new MyEllipse(this);
        }

        public override void draw(Bitmap _bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    graphics.DrawEllipse(pen, rectangle);
                }
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(mostLeft, new Size(width, height)));
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    pen.DashStyle = base.penAttr.dashStyle;
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }
    }

    public class MyRectangle : MyShape
    {
        private int height;
        private Point mostLeft;
        private int width;

        public MyRectangle(PenAttr _penAttr, Point p_start, Point p_end) :
            base(_penAttr)
        {
            // tim diem goc trai
            mostLeft = new Point(Math.Min(p_start.X, p_end.X), Math.Min(p_start.Y, p_end.Y));
            width = Math.Abs(p_start.X - p_end.X);
            height = Math.Abs(p_start.Y - p_end.Y);
        }

        public MyRectangle(MyRectangle myRectangle) :
            base(myRectangle)
        {
            mostLeft = new Point(myRectangle.mostLeft.X, myRectangle.mostLeft.Y);
            width = myRectangle.width;
            height = myRectangle.height;
        }

        public override MyShape Clone()
        {
            return new MyRectangle(this);
        }

        public override void draw(Bitmap _bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
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

        public MyShape(MyShape myShape)
        {
            penAttr = new PenAttr(myShape.penAttr);
        }

        public PenAttr penAttr { get; set; }

        public abstract MyShape Clone();

        public abstract void draw(Bitmap _bitmap);

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
        public abstract bool isPointBelongPrecisely(Point p);
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

        public PenAttr(PenAttr penAttr)
        {
            color = penAttr.color;
            dashStyle = penAttr.dashStyle;
            width = penAttr.width;
        }

        public Color color { get; set; }
        public DashStyle dashStyle { get; set; }
        public int width { get; set; }
    }
}