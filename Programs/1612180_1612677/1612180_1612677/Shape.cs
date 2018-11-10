using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    public class MyCharater : MyShape
    {
        private int height;
        private Point mostLeft;
        private int width;

        public MyCharater() : base()
        {
            mostLeft = Point.Empty;
        }

        public MyCharater(PenAttr _penAttr, List<Point> _points, FontAttr _fontAttr) :
            base(_penAttr)
        {
            mostLeft = new Point(_points[0].X, _points[0].Y);
            fontAttr = new FontAttr(_fontAttr);
        }

        public MyCharater(MyCharater myCharacter) :
            base(myCharacter)
        {
            mostLeft = new Point(myCharacter.mostLeft.X, myCharacter.mostLeft.Y);
            width = myCharacter.width;
            height = myCharacter.height;
            fontAttr = new FontAttr(myCharacter.fontAttr);
        }

        public FontAttr fontAttr { get; set; }

        private void getHeightAndWidthOfChar(Graphics graphics, Font font)
        {
            //get height and width of text
            width = (int)graphics.MeasureString(fontAttr.text, font).Width;
            height = (int)graphics.MeasureString(fontAttr.text, font).Height;
        }

        private int LengthOfFont(string font)
        {
            if (font.IndexOf(' ') >= 0)
            {
                String[] result = font.Split(' ');
                return result.Length;
            }
            return 0;
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 1;
        }

        public override MyShape Clone()
        {
            return new MyCharater(this);
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            using (Brush brush = new SolidBrush(penAttr.color))
            {
                pen.DashStyle = penAttr.dashStyle;
                Font font = new Font(fontAttr.fontFamily, fontAttr.size, FontStyle.Regular);
                getHeightAndWidthOfChar(graphics, font);
                //draw
                graphics.DrawString(fontAttr.text, font, brush, mostLeft);
                pictureBox.Invalidate();
            }
        }

        public override void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
        }

        public override List<Point> getEdgePoints()
        {
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y));
            return edgePoints;
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            // mac dinh khong chon vien
            return false;
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
            // in ra string co dang "4 x y text size height  width color dashStyle width font"
            String[] result = data.Split(' ');
            mostLeft = new Point(Int32.Parse(result[1]), Int32.Parse(result[2]));
            fontAttr.text = result[3];
            fontAttr.size = Int32.Parse(result[4]);
            height = Int32.Parse(result[5]);
            width = Int32.Parse(result[6]);

            // doc du lieu penAttr tu file
            Color colorShape = ConvertColorFromString(result[7]);
            DashStyle dashStyleFromFile = ConvertDashStypeFromString(result[8]);
            int widthFromFile = Int32.Parse(result[9]);

            if (Int32.Parse(result[10]) != 0)
            {
                for (int i = 0; i < Int32.Parse(result[10]); i++)
                {
                    fontAttr.fontFamily += result[11 + i] + " ";
                }
                fontAttr.fontFamily = fontAttr.fontFamily.Remove(fontAttr.fontFamily.Length - 1);
            }
            else
            {
                fontAttr.fontFamily += result[11];
            }

            penAttr = new PenAttr(colorShape, dashStyleFromFile, widthFromFile);
        }

        public override string WriteData()
        {
            // in ra string co dang "4 x y text size height  width color  dashStyle width font"
            String result = "4 ";
            result += mostLeft.X.ToString() + " ";
            result += mostLeft.Y.ToString() + " ";
            result += fontAttr.text + " ";
            result += fontAttr.size + " ";
            result += height.ToString() + " ";
            result += width.ToString() + " ";
            result += penAttr.color.ToArgb().ToString() + " " +
                    penAttr.dashStyle.ToString() + " " +
                    penAttr.width.ToString() + " ";
            result += LengthOfFont(fontAttr.fontFamily).ToString() + " ";
            result += fontAttr.fontFamily;
            return result;
        }
    }

    public class MyEllipse : MyShape
    {
        private int height;
        private Point mostLeft;
        private int width;

        public MyEllipse(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr)
        {
            mostLeft = new Point(Math.Min(_points[0].X, _points[1].X),
                Math.Min(_points[0].Y, _points[1].Y));
            width = Math.Abs(_points[0].X - _points[1].X);
            height = Math.Abs(_points[0].Y - _points[1].Y);
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

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 2;
        }

        public override MyShape Clone()
        {
            return new MyEllipse(this);
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawEllipse(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                switch (brushAttr.typeBrush)
                {
                    case "SolidBrush":
                        using (Brush brush = new SolidBrush(brushAttr.color))
                        {
                            Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    default:
                        break;
                }
                pictureBox.Invalidate();
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
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddEllipse(new Rectangle(mostLeft, new Size(width, height)));
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(p, pen);
            }
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(mostLeft, new Size(width, height)));
                return path.IsVisible(p);
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
            Color colorShape = ConvertColorFromString(result[5]);
            DashStyle dashStyleFromFile = ConvertDashStypeFromString(result[6]);
            int widthFromFile = Int32.Parse(result[7]);
            penAttr = new PenAttr(colorShape, dashStyleFromFile, widthFromFile);

            //doc Brush tu file
            Color colorFill = ConvertColorFromString(result[8]);
            brushAttr = new BrushAttr(colorFill, result[9]);
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
                penAttr.width.ToString() + " ";
            result += brushAttr.color.ToArgb().ToString() + " " +
                brushAttr.typeBrush.ToString();
            return result;
        }
    }

    public class MyHinhBinhHanh : MyShape
    {
        private List<Point> points;

        public MyHinhBinhHanh(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr)
        {
            points = new List<Point>(_points);
        }

        public MyHinhBinhHanh() :
            base()
        {
            points = new List<Point>();
        }

        public MyHinhBinhHanh(MyHinhBinhHanh myHinhBinhHanh) :
            base(myHinhBinhHanh)
        {
            points = new List<Point>(myHinhBinhHanh.points);
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            // hinh binh hanh ve bang 3 diem
            return _points.Count == 3;
        }

        public override MyShape Clone()
        {
            return new MyHinhBinhHanh(this);
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            throw new NotImplementedException();
        }

        public override void drawEdgePoints(Bitmap _bitmap, PictureBox pictureBox)
        {
            base.drawEdgePoints(_bitmap, pictureBox);
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            base.fill(_bitmap, pictureBox);
        }

        public override List<Point> getEdgePoints()
        {
            throw new NotImplementedException();
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            throw new NotImplementedException();
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            return base.isPointInsidePrecisly(p);
        }

        public override void ReadData(string data)
        {
            throw new NotImplementedException();
        }

        public override string WriteData()
        {
            throw new NotImplementedException();
        }
    }

    public class MyLine : MyShape
    {
        private Point p_end;
        private Point p_start;

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

        public MyLine(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr)
        {
            p_start = new Point(_points[0].X, _points[0].Y);
            p_end = new Point(_points[1].X, _points[1].Y);
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 2;
        }

        public override MyShape Clone()
        {
            return new MyLine(this);
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawLine(pen, p_start, p_end);
                pictureBox.Invalidate();
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
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddLine(p_start, p_end);
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(p, pen);
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

    public class MyPolygon : MyShape
    {
        private List<Point> points;

        public MyPolygon(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr)
        {
            points = new List<Point>(_points);
        }

        public MyPolygon() :
            base()
        {
            points = new List<Point>();
        }

        public MyPolygon(MyPolygon myPolygon) :
            base(myPolygon)
        {
            points = new List<Point>(myPolygon.points);
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            // it nhat 2 diem
            // da giac hoan thanh khi diem dau va diem cuoi trung nhau
            return _points.Count >= 2 && isPointEqual(_points[_points.Count - 1], _points[0]);
        }

        public override MyShape Clone()
        {
            return new MyPolygon(this);
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            // so diem phai >= 2
            if (points.Count < 2)
                return;
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawPolygon(pen, points.ToArray());
                pictureBox.Invalidate();
            }
        }

        public override void drawEdgePoints(Bitmap _bitmap, PictureBox pictureBox)
        {
            List<Point> edgePoints = getEdgePoints();
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush_white = new SolidBrush(Color.White))
            using (Brush brush_red = new SolidBrush(Color.Red))
            using (Pen pen_black = new Pen(Color.Black, 1))
            using (Pen pen_red = new Pen(Color.Red, 1))
            {
                Point p_mostLeft;
                Rectangle rectangle;
                foreach (Point p in edgePoints)
                {
                    p_mostLeft = new Point(p.X - 2, p.Y - 2);
                    rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                    graphics.FillRectangle(brush_white, rectangle);
                    graphics.DrawRectangle(pen_black, rectangle);
                }
                // diem dau tien ve mau do
                p_mostLeft = new Point(edgePoints[0].X - 2, edgePoints[0].Y - 2);
                rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                graphics.FillRectangle(brush_red, rectangle);
                graphics.DrawRectangle(pen_red, rectangle);
                pictureBox.Invalidate();
            }
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            if (points.Count < 2)
                return;
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                switch (brushAttr.typeBrush)
                {
                    case "SolidBrush":
                        using (Brush brush = new SolidBrush(brushAttr.color))
                        {
                            graphics.FillPolygon(brush, points.ToArray());
                        }
                        break;

                    default:
                        break;
                }
                pictureBox.Invalidate();
            }
        }

        public override List<Point> getEdgePoints()
        {
            return new List<Point>(points);
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddPolygon(points.ToArray());
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(p, pen);
            }
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(points.ToArray());
                return path.IsVisible(p);
            }
        }

        public override void ReadData(string data)
        {
            // doc string co dang "5 color dashStype width length x y "
            String[] result = data.Split(' ');

            Color colorShape = ConvertColorFromString(result[1]);
            DashStyle dashStyleFromFile = ConvertDashStypeFromString(result[2]);
            int widthFromFile = Int32.Parse(result[3]);
            penAttr = new PenAttr(colorShape, dashStyleFromFile, widthFromFile);
            // doc Brush tu file
            Color colorFill = ConvertColorFromString(result[4]);
            brushAttr = new BrushAttr(colorFill, result[5]);

            int length = Int32.Parse(result[6]);
            points = new List<Point>(length);
            int i = 0, k = 0;
            while (i < length) //5
            {
                Point temp = new Point(Int32.Parse(result[7 + k]), Int32.Parse(result[8 + k]));
                points.Add(temp);
                i = i + 1;
                k = k + 2;
            }
            //doc du lieu penAttr tu file

            // doc Brush tu file
        }

        public override string WriteData()
        {
            // in ra string co dang "5  color dashStype width  typeBrush length xi yi "
            String result = "5 ";
            result += penAttr.color.ToArgb().ToString() + " " +
               penAttr.dashStyle.ToString() + " " +
               penAttr.width.ToString() + " ";
            result += brushAttr.color.ToArgb().ToString() + " " +
                brushAttr.typeBrush.ToString() + " ";
            result += points.Count + " ";
            for (int i = 0; i < points.Count; i++)
            {
                result += points[i].X.ToString() + " " + points[i].Y.ToString() + " ";
            }

            return result;
        }
    }

    public class MyRectangle : MyShape
    {
        private int height;
        private Point mostLeft;
        private int width;

        public MyRectangle(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr)
        {
            // tim diem goc trai
            mostLeft = new Point(Math.Min(_points[0].X, _points[1].X),
                Math.Min(_points[0].Y, _points[1].Y));
            width = Math.Abs(_points[0].X - _points[1].X);
            height = Math.Abs(_points[0].Y - _points[1].Y);
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

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 2;
        }

        public override MyShape Clone()
        {
            return new MyRectangle(this);
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                // ve hcn
                Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawRectangle(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                switch (brushAttr.typeBrush)
                {
                    case "SolidBrush":
                        using (Brush brush = new SolidBrush(brushAttr.color))
                        {
                            Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                            graphics.FillRectangle(brush, rectangle);
                        }
                        break;

                    default:
                        break;
                }
                pictureBox.Invalidate();
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
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddRectangle(new Rectangle(mostLeft, new Size(width, height)));
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(p, pen);
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

            // doc du lieu penAttr tu file
            Color colorShape = ConvertColorFromString(result[5]);
            DashStyle dashStyleFromFile = ConvertDashStypeFromString(result[6]);
            int widthFromFile = Int32.Parse(result[7]);
            penAttr = new PenAttr(colorShape, dashStyleFromFile, widthFromFile);

            // doc Brush tu file
            Color colorFill = ConvertColorFromString(result[8]);
            brushAttr = new BrushAttr(colorFill, result[9]);
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
                penAttr.width.ToString() + " ";
            result += brushAttr.color.ToArgb().ToString() + " " +
                brushAttr.typeBrush.ToString();
            return result;
        }
    }

    public abstract class MyShape
    {
        private const int RANGE = 10;

        public MyShape(PenAttr _penAttr)
        {
            penAttr = new PenAttr(_penAttr);
            // mac dinh la mau trang
            brushAttr = new BrushAttr(Color.White, "SolidBrush");
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

        // 2 diem gan nhau la duoc
        // khong can chinh xac lam
        public static bool isPointEqual(Point p, Point q)
        {
            List<Point> ps = new List<Point>();
            int pointRange = RANGE;
            for (int i = -pointRange; i <= pointRange; ++i)
            {
                for (int j = -pointRange; j <= pointRange; ++j)
                {
                    ps.Add(new Point(p.X + i, p.Y + j));
                }
            }
            // chi can 1 diem trung la duoc
            foreach (Point p_temp in ps)
            {
                if (p_temp.Equals(q))
                    return true;
            }
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

        public abstract void draw(Bitmap _bitmap, PictureBox pictureBox);

        public virtual void drawEdgePoints(Bitmap _bitmap, PictureBox pictureBox)
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
                pictureBox.Invalidate();
            }
        }

        public virtual void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                Point p_mostLeft = new Point(p.X - 2, p.Y - 2);
                Rectangle rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                graphics.FillRectangle(brush, rectangle);
                graphics.DrawRectangle(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        // to mau
        public virtual void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
        }

        // edge vi du nhu 4 dinh hcn, diem dau va diem cuoi cua doan thang
        public abstract List<Point> getEdgePoints();

        // vi khi click tung pixel rat kho
        // nen xet them nhung diem lan can
        public bool isPointBelong(Point p)
        {
            List<Point> ps = new List<Point>();
            // lay nhung pixel xung quanh
            int clickRange = RANGE;
            for (int i = -clickRange; i <= clickRange; ++i)
            {
                for (int j = -clickRange; j <= clickRange; ++j)
                {
                    ps.Add(new Point(p.X + i, p.Y + j));
                }
            }

            foreach (Point temp_p in ps)
            {
                // chi can mot diem nam trong la nam trong
                if (isPointBelongPrecisely(p))
                    return true;
            }
            return false;
        }

        // kiem tra chinh xac mot diem nam o canh
        public abstract bool isPointBelongPrecisely(Point p);

        // kiem tra chinh xac mot diem nam be trong
        public virtual bool isPointInsidePrecisly(Point p)
        {
            return false;
        }

        // Doc data
        public abstract void ReadData(String data);

        // Viet data
        public abstract String WriteData();
    }
}