using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1612180_1612677
{
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
}