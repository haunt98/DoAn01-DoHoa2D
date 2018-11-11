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
        private int height;
        private Point mostLeft;
        private int width;

        public MyCharater(PenAttr _penAttr, List<Point> _points, FontAttr _fontAttr) :
            base(_penAttr)
        {
            mostLeft = new Point(_points[0].X, _points[0].Y);
            fontAttr = new FontAttr(_fontAttr);
        }

        public FontAttr fontAttr { get; set; }

        private void getHeightAndWidthOfChar(Graphics graphics, Font font)
        {
            //get height and width of text
            width = (int)graphics.MeasureString(fontAttr.text, font).Width;
            height = (int)graphics.MeasureString(fontAttr.text, font).Height;
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 1;
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Pen pen = new Pen(penAttr.color, penAttr.width))
            using (Brush brush = new SolidBrush(penAttr.color))
            {
                pen.DashStyle = penAttr.dashStyle;
                Font font = new Font(fontAttr.fontFamily, fontAttr.size, FontStyle.Regular);
                getHeightAndWidthOfChar(graphics, font);
                //draw
                graphics.DrawString(fontAttr.text, font, brush, mostLeft);
                pictureBox.Invalidate();
            }
        }

        public override List<Point> getEdgePoints()
        {
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y));
            return edgePoints;
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(new Rectangle(mostLeft, new Size(width, height)));
                return path.IsVisible(p);
            }
        }
    }
}