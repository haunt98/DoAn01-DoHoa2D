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

        public override void updatePenAttr(PenAttr _penAttr)
        {
            penAttr = _penAttr;
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
                // bat smooth
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                // scale va rotate
                graphics.TranslateTransform(getCenterPoint().X, getCenterPoint().Y);
                graphics.ScaleTransform(tyleScale.Width, tyleScale.Height);
                graphics.RotateTransform(angleRotate);
                graphics.TranslateTransform(-getCenterPoint().X, -getCenterPoint().Y);

                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawCurve(pen, points.ToArray());

                // reset bien hinh
                graphics.ResetTransform();

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
                return path.IsOutlineVisible(pointBeforeScaleRotate(p), pen);
            }
        }
    }
}
