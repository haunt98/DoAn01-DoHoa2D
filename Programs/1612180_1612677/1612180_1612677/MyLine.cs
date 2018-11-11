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
}