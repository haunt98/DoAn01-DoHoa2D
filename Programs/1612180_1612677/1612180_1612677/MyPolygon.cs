using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    public class MyPolygon : MyShape
    {
        public MyPolygon(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            // it nhat 2 diem
            // da giac hoan thanh khi diem dau va diem cuoi trung nhau
            return _points.Count >= 2 && isPointEqual(_points[_points.Count - 1], _points[0]);
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
    }
}