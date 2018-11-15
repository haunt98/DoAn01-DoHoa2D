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
        private Size size;
        public BrushAttr brushAttr { get; set; }

        private void calcMostLeftWidthHeight()
        {
            mostLeft = new Point(Math.Min(points[0].X, points[1].X),
                Math.Min(points[0].Y, points[1].Y));
            size = new Size(Math.Abs(points[0].X - points[1].X),
                Math.Abs(points[0].Y - points[1].Y));
        }

        public MyEllipse(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
            calcMostLeftWidthHeight();
            brushAttr = new BrushAttr(COLOR_BRUSH_DEFAULT, "SolidBrush");
        }

        public MyEllipse(MyEllipse _myEll)
            : base(_myEll)
        {
            mostLeft = _myEll.mostLeft;
            size = _myEll.size;
            brushAttr = new BrushAttr(_myEll.brushAttr);
        }

        public override MyShape clone()
        {
            return new MyEllipse(this);
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 2;
        }

        public override void updatePenAttr(PenAttr _penAttr)
        {
            penAttr = _penAttr;
        }

        public override void updateBrushAttr(BrushAttr _brushAttr)
        {
            brushAttr = _brushAttr;
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

                Rectangle rectangle = new Rectangle(mostLeft, size);
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawEllipse(pen, rectangle);

                // reset bien hinh
                graphics.ResetTransform();

                pictureBox.Invalidate();
            }
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                // bat smooth
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                // scale va rotate
                graphics.TranslateTransform(getCenterPoint().X, getCenterPoint().Y);
                graphics.ScaleTransform(tyleScale.Width, tyleScale.Height);
                graphics.RotateTransform(angleRotate);
                graphics.TranslateTransform(-getCenterPoint().X, -getCenterPoint().Y);

                Rectangle rectangle = new Rectangle(mostLeft, size);

                switch (brushAttr.typeBrush)
                {
                    case "SolidBrush":
                        using (Brush brush = new SolidBrush(brushAttr.color))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    case "HatchBrushVertical":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Vertical, brushAttr.color, COLOR_BRUSH_ALTERNATIVE))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    case "HatchBrushHorizontal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Horizontal, brushAttr.color, COLOR_BRUSH_ALTERNATIVE))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    case "HatchBrushCross":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Cross, brushAttr.color, COLOR_BRUSH_ALTERNATIVE))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    case "HatchBrushForwardDiagonal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.ForwardDiagonal, brushAttr.color, COLOR_BRUSH_ALTERNATIVE))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    default:
                        break;
                }

                // reset bien hinh
                graphics.ResetTransform();

                pictureBox.Invalidate();
            }
        }

        public override List<Point> getEdgePoints()
        {
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y + size.Height));
            edgePoints.Add(new Point(mostLeft.X + size.Width, mostLeft.Y));
            edgePoints.Add(new Point(mostLeft.X + size.Width, mostLeft.Y + size.Height));
            return edgePoints;
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            bool flag = false;
            // hinh elip
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddEllipse(new Rectangle(mostLeft, size));
                pen.DashStyle = penAttr.dashStyle;
                flag |= path.IsOutlineVisible(pointBeforeScaleRotate(p), pen);
            }
            // hcn vien
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddRectangle(new Rectangle(mostLeft, size));
                pen.DashStyle = penAttr.dashStyle;
                flag |= path.IsOutlineVisible(pointBeforeScaleRotate(p), pen);
            }
            return flag;
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(new Rectangle(mostLeft, size));
                return path.IsVisible(pointBeforeScaleRotate(p));
            }
        }

        public override void movePoints(Point p_before, Point p_after)
        {
            base.movePoints(p_before, p_after);
            // tinh lai
            calcMostLeftWidthHeight();
        }
    }
}
