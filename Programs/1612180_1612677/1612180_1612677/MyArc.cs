using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    internal class MyArc : MyShape
    {
        private RectangleF rect_bound;
        private float startAngle;
        private float sweepAngle;

        public MyArc(PenAttr _penAttr, List<Point> _points) :
                base(_penAttr, _points)
        {
            calcBound();
        }

        // tinh gioi han va goc quay
        public void calcBound()
        {
            if (points.Count != 3 || centerOfCircle(points) == PointF.Empty)
                return;
            float R = calcDistance(centerOfCircle(points), points[0]);
            rect_bound = new RectangleF(new PointF(centerOfCircle(points).X - R,
                centerOfCircle(points).Y - R),
                new SizeF(2 * R, 2 * R));
            startAngle = calcAngle(Point.Round(centerOfCircle(points)), points[0]);
            float endAngle = calcAngle(Point.Round(centerOfCircle(points)), points[2]);
            sweepAngle = endAngle - startAngle;
        }

        // http://paulbourke.net/geometry/circlesphere/
        public static PointF centerOfCircle(List<Point> _points)
        {
            if (_points.Count != 3)
                return PointF.Empty;

            float ma = (float)(_points[1].Y - _points[0].Y) / (_points[1].X - _points[0].X);
            float mb = (float)(_points[2].Y - _points[1].Y) / (_points[2].X - _points[1].X);
            float x = (ma * mb * (_points[0].Y - _points[2].Y)
                + mb * (_points[0].X + _points[1].X)
                - ma * (_points[1].X + _points[2].X))
                / (2 * mb - 2 * ma);
            float y = -1 * (x - (_points[0].X + _points[1].X) / 2) / ma
                + (_points[0].Y + _points[0].Y) / 2;
            return new PointF(x, y);
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 3;
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            if (points.Count != 3 || rect_bound.Width == 0 || rect_bound.Height == 0)
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
                graphics.DrawArc(pen, rect_bound, startAngle, sweepAngle);

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
            if (points.Count != 3 || rect_bound.Width == 0 || rect_bound.Height == 0)
                return false;

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                pen.DashStyle = penAttr.dashStyle;
                path.AddArc(rect_bound, startAngle, sweepAngle);
                return path.IsOutlineVisible(pointBeforeScaleRotate(p), pen);
            }
        }

        public override void movePoints(Point p_before, Point p_after)
        {
            base.movePoints(p_before, p_after);
            calcBound();
        }
    }
}