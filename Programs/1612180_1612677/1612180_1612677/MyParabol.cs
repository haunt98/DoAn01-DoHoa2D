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
    class MyParabol : MyShape
    {
        public MyParabol(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
        }

        private static Point findFinalPointOfParallel(List<Point> _points)
        {
            if (_points.Count == 2)
            {
                int dx = Math.Abs(_points[0].X - _points[1].X);
                int dy = Math.Abs(_points[0].Y - _points[1].Y);
                Point final;
                // doi xung qua X, X giu nguyen
                if (dx > dy)
                {
                    if (_points[0].Y > _points[1].Y)
                    {
                        final = new Point(_points[0].X, _points[0].Y - 2 * dy);
                    }
                    else
                    {
                        final = new Point(_points[0].X, _points[0].Y + 2 * dy);
                    }
                }
                // doi xung qua Y
                else
                {
                    if (_points[0].X > _points[1].X)
                    {
                        final = new Point(_points[0].X - 2 * dx, _points[0].Y);
                    }
                    else
                    {
                        final = new Point(_points[0].X + 2 * dx, _points[0].Y);
                    }
                }
                return final;
            }
            return Point.Empty;
        }
        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            if (_points.Count == 2)
            {
                Point final = findFinalPointOfParallel(_points);
                if (final != Point.Empty)
                {
                    _points.Add(final);
                    return true;
                }
            }
            return false;
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
                graphics.DrawCurve(pen, points.ToArray());
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

        public override bool isPointBelongPrecisely(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddCurve(points.ToArray());
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(p, pen);
            }
        }
    }
}
