using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    internal class MyBezier : MyShape
    {
        public MyBezier(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 4;
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            if (points.Count != 4)
                return;
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(COLOR_PEN_DEFAULT))
            {
                pen.DashStyle = DASH_STYLE_TEMP;
                graphics.DrawBeziers(pen, points.ToArray());
                pictureBox.Invalidate();
            }
        }

        public override void drawTemporaryChange(Bitmap _bitmap, PictureBox pictureBox)
        {
            if (points.Count != 4)
                return;
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(Color.Black))
            {
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawBeziers(pen, points.ToArray());
                pictureBox.Invalidate();
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddBeziers(points.ToArray());
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(p, pen);
            }
        }

        // khong co diem ben trong
        public override void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
        }
    }
}