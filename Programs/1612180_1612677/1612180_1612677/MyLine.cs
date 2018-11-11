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
        private Point p_end;
        private Point p_start;

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

        public override void movePoints(int _moveWidth, int _moveHeight)
        {
            p_start.X += _moveWidth;
            p_start.Y += _moveHeight;
            p_end.X += _moveWidth;
            p_end.Y += _moveHeight;
        }
    }
}