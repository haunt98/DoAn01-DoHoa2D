using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    public class MyHinhBinhHanh : MyShape
    {
        public BrushAttr brushAttr { get; set; }

        public MyHinhBinhHanh(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr, _points)
        {
            // mac dinh la mau trang
            brushAttr = new BrushAttr(Color.White, "SolidBrush");
        }

        private static Point findFinalPointOfParallel(List<Point> _points)
        {
            if (_points.Count == 3)
            {
                int x = _points[0].X + _points[2].X;
                int y = _points[0].Y + _points[2].Y;
                return new Point(x - _points[1].X, y - _points[1].Y);
            }
            return Point.Empty;
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            // hinh binh hanh can 3 diem
            if (_points.Count == 3)
            {
                // them 1 diem con lai
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
                pen.DashStyle = penAttr.dashStyle;
                graphics.DrawPolygon(pen, points.ToArray());
                pictureBox.Invalidate();
            }
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            // so diem phai >= 2
            if (points.Count <= 2)
                return;
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            {
                switch (brushAttr.typeBrush)
                {
                    case "SolidBrush":
                        using (Brush brush = new SolidBrush(brushAttr.color))
                        {
                            graphics.FillPolygon(brush, points.ToArray());
                        }
                        break;
                    case "HatchBrushVertical":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Vertical, brushAttr.color, Color.Blue))
                        {
                            graphics.FillPolygon(brush, points.ToArray());
                        }
                        break;
                    case "HatchBrushHorizontal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Horizontal, brushAttr.color, Color.Blue))
                        {
                            graphics.FillPolygon(brush, points.ToArray());
                        }
                        break;
                    case "HatchBrushCross":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Cross, brushAttr.color, Color.Blue))
                        {
                            graphics.FillPolygon(brush, points.ToArray());
                        }
                        break;

                    case "HatchBrushForwardDiagonal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.ForwardDiagonal, brushAttr.color, Color.Blue))
                        {
                            graphics.FillPolygon(brush, points.ToArray());
                        }
                        break;

                    default:
                        break;
                }
                pictureBox.Invalidate();
            }
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            {
                path.AddPolygon(points.ToArray());
                pen.DashStyle = penAttr.dashStyle;
                return path.IsOutlineVisible(p, pen);
            }
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(points.ToArray());
                return path.IsVisible(p);
            }
        }
    }
}