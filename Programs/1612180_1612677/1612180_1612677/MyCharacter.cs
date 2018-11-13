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
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Vertical, brushAttr.color, COLOR_BRUSH_ALTERNATIVE))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
                        }
                        break;

                    case "HatchBrushHorizontal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Horizontal, brushAttr.color, COLOR_BRUSH_ALTERNATIVE))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
                        }
                        break;

                    case "HatchBrushCross":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.Cross, brushAttr.color, COLOR_BRUSH_ALTERNATIVE))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
                        }
                        break;

                    case "HatchBrushForwardDiagonal":
                        using (HatchBrush brush = new HatchBrush(HatchStyle.ForwardDiagonal, brushAttr.color, COLOR_BRUSH_ALTERNATIVE))
                        {
                            graphics.DrawString(fontAttr.text, font, brush, points[0]);
                        }
                        break;

                    default:
                        break;
                }
                pictureBox.Invalidate();
            }
        }

        public override void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(new Rectangle(points[0], size));
                return path.IsVisible(p);
            }
        }

        public override void movePoints(Point p_before, Point p_after)
        {
            base.movePoints(p_before, p_after);
        }

        public override void scalePoints(Point p_before, Point p_after)
        {
        }

        public override void rotatePoints(Point p_before, Point p_after)
        {
            base.rotatePoints(p_before, p_after);
        }
    }
}
