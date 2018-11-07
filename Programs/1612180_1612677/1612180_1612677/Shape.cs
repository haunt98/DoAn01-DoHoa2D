using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _1612180_1612677
{
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

        public override List<Point> getEdgePoints()
        {
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y + height));
            edgePoints.Add(new Point(mostLeft.X + width, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X + width, mostLeft.Y + height));
            return edgePoints;
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

        public override void ReadDataFromString(string data)
        {
        }

        public override string WriteData()
        {
            return "";
        }
    }

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

        public MyLine() :
            base()
        {
            p_start = Point.Empty;
            p_end = Point.Empty;
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

        public override List<Point> getEdgePoints()
        {
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(p_start.X, p_start.Y));
            edgePoints.Add(new Point(p_end.X, p_end.Y));
            return edgePoints;
        }

        public override void ReadDataFromString(string data)
        {
            //doc string co dang "1 xstart ystart xend yend"
            String[] result = data.Split(' ');
            p_start = new Point(Int32.Parse(result[1]), Int32.Parse(result[2]));
            p_end = new Point(Int32.Parse(result[3]), Int32.Parse(result[4]));
            //base.penAttr = new PenAttr(result[5], result[6], result[7]);
        }

        public override string WriteData()
        {
            //in ra string co dang 1 xstart ystart xend yend
            String result = "1 ";
            result += p_start.X.ToString() + " ";
            result += p_start.Y.ToString() + " ";
            result += p_end.X.ToString() + " ";
            result += p_end.Y.ToString() + " ";
            result += base.penAttr.color.ToString() + " " +
                base.penAttr.dashStyle.ToString() + " " +
                base.penAttr.width.ToString();
            return result;
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

        public MyRectangle() :
            base()
        {
            mostLeft = Point.Empty;
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

        public override List<Point> getEdgePoints()
        {
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y + height));
            edgePoints.Add(new Point(mostLeft.X + width, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X + width, mostLeft.Y + height));
            return edgePoints;
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

        public override void ReadDataFromString(string data)
        {
            // doc string co dang "2 xstart ystart xend yend"
            String[] result = data.Split(' ');
            mostLeft = new Point(Int32.Parse(result[1]), Int32.Parse(result[2]));
            height = Int32.Parse(result[3]);
            width = Int32.Parse(result[4]);
        }

        public override string WriteData()
        {
            // in ra string co dang "2 x y height width"
            String result = "2 ";
            result += mostLeft.X.ToString() + " ";
            result += mostLeft.Y.ToString() + " ";
            result += height.ToString() + " ";
            result += width.ToString();
            return result;
        }
    }

    public abstract class MyShape
    {
        public MyShape(PenAttr _penAttr)
        {
            penAttr = _penAttr;
        }

        public MyShape()
        {
            penAttr = null;
        }

        public MyShape(MyShape myShape)
        {
            penAttr = new PenAttr(myShape.penAttr);
        }

        public PenAttr penAttr { get; set; }

        public abstract MyShape Clone();

        public DashStyle ConvertDashStypeToInt(String dashStyle)
        {
            DashStyle result = DashStyle.Solid;
            switch (dashStyle)
            {
                case "Dash":
                    result = DashStyle.Dash;
                    break;

                case "DashDot":
                    result = DashStyle.DashDot;
                    break;

                case "DashDotDot":
                    result = DashStyle.DashDotDot;
                    break;

                case "Dot":
                    result = DashStyle.Dot;
                    break;

                case "Solid":
                    result = DashStyle.Solid;
                    break;
            }
            return result;
        }

        public abstract void draw(Bitmap _bitmap);

        // edge vi du nhu 4 dinh hcn, diem dau va diem cuoi cua doan thang
        public abstract List<Point> getEdgePoints();

        public void drawEdgePoints(Bitmap _bitmap)
        {
            List<Point> edgePoints = getEdgePoints();
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                foreach (Point p in edgePoints)
                {
                    Point p_mostLeft = new Point(p.X - 2, p.Y - 2);
                    Rectangle rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(pen, rectangle);
                }
            }
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
        public abstract bool isPointBelongPrecisely(Point p);

        // Doc data
        public abstract void ReadDataFromString(String data);

        // Viet data
        public abstract String WriteData();
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