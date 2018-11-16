using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    public class MyCharater : MyShape
    {

        private Size size;
        public BrushAttr brushAttr { get; set; }
        public FontAttr fontAttr { get; set; }

        public MyCharater(List<Point> _points, FontAttr _fontAttr) :
            base(_points)
        {
            fontAttr = new FontAttr(_fontAttr);
            brushAttr = new BrushAttr(COLOR_BRUSH_DARK, "SolidBrush");
        }

        public MyCharater(MyCharater _myChar)
            : base(_myChar)
        {
            fontAttr = new FontAttr(_myChar.fontAttr);
            brushAttr = new BrushAttr(_myChar.brushAttr);
        }

        public override MyShape clone()
        {
            return new MyCharater(this);
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 1;
        }

        public override void updateBrushAttr(BrushAttr _brushAttr)
        {
            brushAttr = _brushAttr;
        }

        public override void updateFontAttr(FontAttr _fontAttr)
        {
            fontAttr = _fontAttr;
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Font font = new Font(fontAttr.fontFamily, fontAttr.size, fontAttr.fontStyle))
            {
                // scale va rotate
                graphics.TranslateTransform(getCenterPoint().X, getCenterPoint().Y);
                graphics.ScaleTransform(tyleScale.Width, tyleScale.Height);
                graphics.RotateTransform(angleRotate);
                graphics.TranslateTransform(-getCenterPoint().X, -getCenterPoint().Y);

                // tinh lai size tuy theo text va font
                size = Size.Round(graphics.MeasureString(fontAttr.text, font));

                switch (brushAttr.typeBrush)
                {
                    case "SolidBrush":
                        using (Brush brush = new SolidBrush(brushAttr.color))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
                        }
                        break;

                    case "HatchBrushVertical":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Vertical, brushAttr.color, brushAttr.color2))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
                        }
                        break;

                    case "HatchBrushHorizontal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Horizontal, brushAttr.color, brushAttr.color2))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
                        }
                        break;

                    case "HatchBrushCross":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Cross, brushAttr.color, brushAttr.color2))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
                        }
                        break;

                    case "HatchBrushForwardDiagonal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.ForwardDiagonal, brushAttr.color, brushAttr.color2))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
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

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(new Rectangle(points[0], size));
                return path.IsVisible(pointBeforeScaleRotate(p));
            }
        }

        // khong cho character scale
        public override void scalePoints(Point _p_before, Point _p_after)
        {
        }
    }
}
