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
}