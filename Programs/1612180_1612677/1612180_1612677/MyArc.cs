using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    internal class MyArcCircle : MyShape
    {
        private float r;
        RectangleF bound;
        float startAngle;
        float endAngle;
        float sweepAngle;

        public MyArcCircle(PenAttr _penAttr, List<Point> _points) :
                base(_penAttr, _points)
        {
        }

        private void prepareToDraw()
        {
            if (points.Count == 3)
            {
                // p0 - p1
                r = calcDistance(points[1], points[0]);
                bound = new RectangleF(Math.Abs(points[0].X - r), Math.Abs(points[0].Y - r), 2 * r, 2 * r);
                startAngle = calcAngle(points[0], points[1]);
                endAngle = calcAngle(points[0], points[2]);
                sweepAngle = endAngle - startAngle;


            }
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 3;
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            if (points.Count < 3)
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
                prepareToDraw();
                graphics.DrawArc(pen, bound, startAngle, sweepAngle);

                // reset bien hinh
                graphics.ResetTransform();

                pictureBox.Invalidate();
            }

        }

        public override void updatePenAttr(PenAttr _penAttr)
        {
            penAttr = _penAttr;
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                prepareToDraw();
                path.AddArc(bound, startAngle, sweepAngle);
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(pointBeforeScaleRotate(p), pen);
            }
        }
    }
}