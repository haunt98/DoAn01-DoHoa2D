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
        private float caculateDistantBetweenTwoPoint(Point p1, Point p2)
        {
            return (float)Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));

        }
        private float caculateAngle(Point center, Point start)
        {
            float angle = (float)Math.Atan2(start.Y - center.Y, start.X - center.X);
            return angle;
        }
        private void prepareToDraw()
        {
            if (points.Count == 3)
            {
                // p0 - p1
                r = caculateDistantBetweenTwoPoint(points[1], points[0]);
                bound = new RectangleF(Math.Abs(points[0].X - r), Math.Abs(points[0].Y - r), 2 * r, 2 * r);
                startAngle = caculateAngle(points[0], points[1]) * 180 / (float)Math.PI;
                endAngle = caculateAngle(points[0], points[2]) * 180 / (float)Math.PI;
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