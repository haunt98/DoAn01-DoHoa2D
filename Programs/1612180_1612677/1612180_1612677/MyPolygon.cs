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
            // da giac can it nhat 2 diem
            if (_points.Count >= 2)
            {
                // da giac hoan thanh khi diem dau va diem cuoi trung nhau
                if (isPointEqual(_points[_points.Count - 1], _points[0]))
                {
                    // delete diem trung
                    _points.RemoveAt(_points.Count - 1);
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
                graphics.DrawPolygon(pen, points.ToArray());
                pictureBox.Invalidate();
            }
        }

        public override void drawEdgePoints(Bitmap _bitmap, PictureBox pictureBox)
        {
            base.drawEdgePoints(_bitmap, pictureBox);
            base.drawFirstPoint(_bitmap, pictureBox);
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