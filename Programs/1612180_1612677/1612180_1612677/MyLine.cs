using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    public class MyLine : MyShape
    {
        public MyLine(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
        }

        public MyLine(MyLine _myLine)
            : base(_myLine)
        {
        }

        public override MyShape clone()
        {
            return new MyLine(this);
        }

        public override void updatePenAttr(PenAttr _penAttr)
        {
            penAttr = _penAttr;
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 2;
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
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
                graphics.DrawLine(pen, points[0], points[1]);

                // reset bien hinh
                graphics.ResetTransform();

                pictureBox.Invalidate();
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            // su dung graphics path
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddLine(points[0], points[1]);
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(pointBeforeScaleRotate(p), pen);
            }
        }
    }
}
