using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    public class MyEllipse : MyShape
    {
        private Point mostLeft;
        private int width;
        private int height;
        public BrushAttr brushAttr { get; set; }

        public MyEllipse(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
            mostLeft = new Point(Math.Min(points[0].X, points[1].X),
                Math.Min(points[0].Y, points[1].Y));
            width = Math.Abs(points[0].X - points[1].X);
            height = Math.Abs(points[0].Y - points[1].Y);
            // mac dinh la mau trang
            brushAttr = new BrushAttr(Color.White, "SolidBrush");
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
                Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawEllipse(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                switch (brushAttr.typeBrush)
                {
                    case "SolidBrush":
                        using (Brush brush = new SolidBrush(brushAttr.color))
                        {
                            Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                            graphics.FillEllipse(brush, rectangle);
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
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y + height));
            edgePoints.Add(new Point(mostLeft.X + width, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X + width, mostLeft.Y + height));
            return edgePoints;
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            bool flag = false;
            // hinh elip
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddEllipse(new Rectangle(mostLeft, new Size(width, height)));
                pen.DashStyle = penAttr.dashStyle;
                flag |= path.IsOutlineVisible(p, pen);
            }
            // hcn vien
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddRectangle(new Rectangle(mostLeft, new Size(width, height)));
                pen.DashStyle = penAttr.dashStyle;
                flag |= path.IsOutlineVisible(p, pen);
            }
            return flag;
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(mostLeft, new Size(width, height)));
                return path.IsVisible(p);
            }
        }

        public override void movePoints(int _moveWidth, int _moveHeight)
        {
            base.movePoints(_moveWidth, _moveHeight);
            // tinh lai
            mostLeft = new Point(Math.Min(points[0].X, points[1].X),
                Math.Min(points[0].Y, points[1].Y));
            width = Math.Abs(points[0].X - points[1].X);
            height = Math.Abs(points[0].Y - points[1].Y);

        }

        public override void scalePoints(Point p_before, Point p_after)
        {
            base.scalePoints(p_before, p_after);
            // tinh lai
            mostLeft = new Point(Math.Min(points[0].X, points[1].X),
                Math.Min(points[0].Y, points[1].Y));
            width = Math.Abs(points[0].X - points[1].X);
            height = Math.Abs(points[0].Y - points[1].Y);
        }
    }
}