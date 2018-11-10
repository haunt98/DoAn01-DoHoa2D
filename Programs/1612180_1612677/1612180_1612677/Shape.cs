using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _1612180_1612677
{
    public class BrushAttr
    {
        public BrushAttr(Color _color, String _typeBrush)
        {
            color = _color;
            typeBrush = _typeBrush;
        }

        public BrushAttr(BrushAttr brushAttr)
        {
            if (brushAttr != null)
            {
                color = brushAttr.color;
                typeBrush = brushAttr.typeBrush;
            }
        }

        public Color color { get; set; }
        public String typeBrush { get; set; }
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

        public MyEllipse() :
            base()
        {
            mostLeft = Point.Empty;
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
                using (Pen pen = new Pen(penAttr.color, penAttr.width))
                {
                    pen.DashStyle = penAttr.dashStyle;
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
                using (Pen pen = new Pen(penAttr.color, penAttr.width))
                {
                    pen.DashStyle = penAttr.dashStyle;
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }

        public override void ReadData(string data)
        {
            // doc string co dang "3 x y  height  width color dashStype width"

            String[] result = data.Split(' ');
            mostLeft = new Point(Int32.Parse(result[1]), Int32.Parse(result[2]));
            height = Int32.Parse(result[3]);
            width = Int32.Parse(result[4]);

            //doc du lieu penAttr tu file
            Color colorFromFile = ConvertColorFromString(result[5]);
            DashStyle dashStyleFromFile = ConvertDashStypeFromString(result[6]);
            int widthFromFile = Int32.Parse(result[7]);

            penAttr = new PenAttr(colorFromFile, dashStyleFromFile, widthFromFile);
        }

        public override string WriteData()
        {
            // in ra string co dang "3 x y  height  width color dashStype width"
            String result = "3 ";
            result += mostLeft.X.ToString() + " ";
            result += mostLeft.Y.ToString() + " ";
            result += height.ToString() + " ";
            result += width.ToString() + " ";
            result += penAttr.color.ToArgb().ToString() + " " +
                penAttr.dashStyle.ToString() + " " +
                penAttr.width.ToString();
            return result;
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(mostLeft, new Size(width, height)));
                return path.IsVisible(p);
            }
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
                using (Pen pen = new Pen(penAttr.color, penAttr.width))
                {
                    pen.DashStyle = penAttr.dashStyle;
                    graphics.DrawLine(pen, p_start, p_end);
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

        public override bool isPointBelongPrecisely(Point p)
        {
            // su dung graphics path
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddLine(p_start, p_end);
                using (Pen pen = new Pen(penAttr.color, penAttr.width))
                {
                    pen.DashStyle = penAttr.dashStyle;
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }

        public override void ReadData(string data)
        {
            //doc string co dang "1 xstart ystart xend yend color dashStype width"
            String[] result = data.Split(' ');
            p_start = new Point(Int32.Parse(result[1]), Int32.Parse(result[2]));
            p_end = new Point(Int32.Parse(result[3]), Int32.Parse(result[4]));

            //doc du lieu penAtt tu file
            Color colorFromFile = ConvertColorFromString(result[5]);
            DashStyle dashStyleFromFile = ConvertDashStypeFromString(result[6]);
            int widthFromFile = Int32.Parse(result[7]);

            penAttr = new PenAttr(colorFromFile, dashStyleFromFile, widthFromFile);
        }

        public override string WriteData()
        {
            //in ra string co dang 1 xstart ystart xend yend
            String result = "1 ";
            result += p_start.X.ToString() + " ";
            result += p_start.Y.ToString() + " ";
            result += p_end.X.ToString() + " ";
            result += p_end.Y.ToString() + " ";
            result += penAttr.color.ToArgb().ToString() + " " +
                penAttr.dashStyle.ToString() + " " +
                penAttr.width.ToString();
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
            // mac dinh to mau trang
            brushAttr = new BrushAttr(Color.White, "SolidBrush");
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

        public override bool canFill()
        {
            return true;
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
                using (Pen pen = new Pen(penAttr.color, penAttr.width))
                {
                    pen.DashStyle = penAttr.dashStyle;
                    graphics.DrawRectangle(pen, rectangle);
                }
            }
        }

        public override void fill(Bitmap _bitmap)
        {
            if (brushAttr == null || !canFill())
                return;
            switch (brushAttr.typeBrush)
            {
                case "SolidBrush":
                    using (Graphics graphics = Graphics.FromImage(_bitmap))
                    using (Brush brush = new SolidBrush(brushAttr.color))
                    {
                        Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                        graphics.FillRectangle(brush, rectangle);
                    }
                    break;

                default:
                    break;
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
                using (Pen pen = new Pen(penAttr.color, penAttr.width))
                {
                    pen.DashStyle = penAttr.dashStyle;
                    return path.IsOutlineVisible(p, pen);
                }
            }
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(new Rectangle(mostLeft, new Size(width, height)));
                return path.IsVisible(p);
            }
        }

        public override void ReadData(string data)
        {
            // doc string co dang "2 x y  height  width color dashStype width"
            String[] result = data.Split(' ');
            mostLeft = new Point(Int32.Parse(result[1]), Int32.Parse(result[2]));
            height = Int32.Parse(result[3]);
            width = Int32.Parse(result[4]);

            //doc du lieu penAttr tu file
            Color colorFromFile = ConvertColorFromString(result[5]);
            DashStyle dashStyleFromFile = ConvertDashStypeFromString(result[6]);
            int widthFromFile = Int32.Parse(result[7]);

            penAttr = new PenAttr(colorFromFile, dashStyleFromFile, widthFromFile);
        }

        public override string WriteData()
        {
            // in ra string co dang "2 x y  height  width color dashStype width"
            String result = "2 ";
            result += mostLeft.X.ToString() + " ";
            result += mostLeft.Y.ToString() + " ";
            result += height.ToString() + " ";
            result += width.ToString() + " ";
            result += penAttr.color.ToArgb().ToString() + " " +
                penAttr.dashStyle.ToString() + " " +
                penAttr.width.ToString();
            return result;
        }
    }

    public abstract class MyShape
    {
        public MyShape(PenAttr _penAttr)
        {
            penAttr = new PenAttr(_penAttr);
            brushAttr = null;
        }

        public MyShape(PenAttr _penAttr, BrushAttr _brushAttr)
        {
            penAttr = new PenAttr(_penAttr);
            brushAttr = new BrushAttr(_brushAttr);
        }

        public MyShape()
        {
            penAttr = null;
            brushAttr = null;
        }

        public MyShape(MyShape myShape)
        {
            penAttr = new PenAttr(myShape.penAttr);
            brushAttr = new BrushAttr(myShape.brushAttr);
        }

        public BrushAttr brushAttr { get; set; }
        public PenAttr penAttr { get; set; }

        // co the to mau duoc
        public virtual bool canFill()
        {
            return false;
        }

        public abstract MyShape Clone();

        public Color ConvertColorFromString(String data)
        {
            Color result = Color.FromArgb(Int32.Parse(data));
            return result;
        }

        public DashStyle ConvertDashStypeFromString(String dashStyle)
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

        public void drawInsidePoint(Bitmap _bitmap, Point p)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                Point p_mostLeft = new Point(p.X - 2, p.Y - 2);
                Rectangle rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                graphics.FillRectangle(brush, rectangle);
                graphics.DrawRectangle(pen, rectangle);
            }
        }

        // to mau
        public virtual void fill(Bitmap _bitmap)
        {
        }

        // edge vi du nhu 4 dinh hcn, diem dau va diem cuoi cua doan thang
        public abstract List<Point> getEdgePoints();

        // vi khi click tung pixel rat kho
        // nen xet them nhung diem lan can
        public bool isPointBelong(Point p)
        {
            List<Point> ps = new List<Point>();
            // XXXXX
            // XXXXX
            // XXpXX
            // XXXXX
            // XXXXX
            ps.Add(new Point(p.X - 2, p.Y - 2));
            ps.Add(new Point(p.X - 2, p.Y - 1));
            ps.Add(new Point(p.X - 2, p.Y));
            ps.Add(new Point(p.X - 2, p.Y + 1));
            ps.Add(new Point(p.X - 2, p.Y + 2));
            ps.Add(new Point(p.X - 1, p.Y - 2));
            ps.Add(new Point(p.X - 1, p.Y - 1));
            ps.Add(new Point(p.X - 1, p.Y));
            ps.Add(new Point(p.X - 1, p.Y + 1));
            ps.Add(new Point(p.X - 1, p.Y + 2));
            ps.Add(new Point(p.X, p.Y - 2));
            ps.Add(new Point(p.X, p.Y - 1));
            ps.Add(new Point(p.X, p.Y));
            ps.Add(new Point(p.X, p.Y + 1));
            ps.Add(new Point(p.X, p.Y + 2));
            ps.Add(new Point(p.X + 1, p.Y - 2));
            ps.Add(new Point(p.X + 1, p.Y - 1));
            ps.Add(new Point(p.X + 1, p.Y));
            ps.Add(new Point(p.X + 1, p.Y + 1));
            ps.Add(new Point(p.X + 1, p.Y + 2));

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

        public virtual bool isPointInsidePrecisly(Point p)
        {
            return false;
        }

        // Doc data
        public abstract void ReadData(String data);

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

    public class MyCharater : MyShape
    {
        private String text;
        private Point mostLeft;
        private String font;
        private int size;

        public MyCharater() : base()
        {
            mostLeft = Point.Empty;
        }

        public MyCharater(PenAttr _penAttr, String _text, Point p_start, String _font, int _size) :
            base(_penAttr)
        {
            mostLeft = new Point(p_start.X, p_start.Y);
            text = _text;
            font = _font;
            size = _size;
        }

        public MyCharater(MyCharater myCharactor) :
            base(myCharactor)
        {
            mostLeft = new Point(myCharactor.mostLeft.X, myCharactor.mostLeft.Y);
            font = myCharactor.font;
            size = myCharactor.size;
        }

        public override MyShape Clone()
        {
            return new MyCharater(this);
        }

        public override void draw(Bitmap _bitmap)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                // ve charactor
                using (Pen pen = new Pen(base.penAttr.color, base.penAttr.width))
                {
                    pen.DashStyle = base.penAttr.dashStyle;
                    graphics.DrawString(text, new Font(font, size, FontStyle.Regular), new SolidBrush(Color.Red), mostLeft);
                }
            }
        }

        public override List<Point> getEdgePoints()
        {
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y + size));
            edgePoints.Add(new Point(mostLeft.X + size, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X + size, mostLeft.Y + size));
            return edgePoints;
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            return false;
        }

        public override void ReadData(string data)
        {
        }

        public override string WriteData()
        {
            return null;
        }
    }
}