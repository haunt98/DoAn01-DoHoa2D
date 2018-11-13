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

        private void calcMostLeftWidthHeight()
        {
            mostLeft = new Point(Math.Min(points[0].X, points[1].X),
                Math.Min(points[0].Y, points[1].Y));
            width = Math.Abs(points[0].X - points[1].X);
            height = Math.Abs(points[0].Y - points[1].Y);
        }

        public MyEllipse(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
            calcMostLeftWidthHeight();
            brushAttr = new BrushAttr(COLOR_BRUSH_DEFAULT, "SolidBrush");
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

        public override void drawTemporaryChange(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(COLOR_PEN_DEFAULT))
            using (Brush brush = new SolidBrush(COLOR_BRUSH_DEFAULT))
            {
                Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));
                graphics.FillEllipse(brush, rectangle);
                pen.DashStyle = DASH_STYLE_TEMP;
                graphics.DrawEllipse(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                Rectangle rectangle = new Rectangle(mostLeft, new Size(width, height));

                switch (brushAttr.typeBrush)
                {
                    case "SolidBrush":
                        using (Brush brush = new SolidBrush(brushAttr.color))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    case "HatchBrushVertical":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Vertical, brushAttr.color, Color.Blue))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    case "HatchBrushHorizontal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Horizontal, brushAttr.color, Color.Blue))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    case "HatchBrushCross":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Cross, brushAttr.color, Color.Blue))
                        {
                            graphics.FillEllipse(brush, rectangle);
                        }
                        break;

                    case "HatchBrushForwardDiagonal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.ForwardDiagonal, brushAttr.color, Color.Blue))
                        {
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

        public override void movePoints(Point p_before, Point p_after)
        {
            base.movePoints(p_before, p_after);
            // tinh lai
            calcMostLeftWidthHeight();
        }

        public override void scalePoints(Point p_before, Point p_after)
        {
            base.scalePoints(p_before, p_after);
            // tinh lai
            calcMostLeftWidthHeight();
        }

        public override void rotatePoints(Point p_before, Point p_after)
        {
            base.rotatePoints(p_before, p_after);
            // tinh lai
            calcMostLeftWidthHeight();
        }
    }
}