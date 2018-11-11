using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1612180_1612677
{
    public class MyCharater : MyShape
    {
        private int height;
        private Point mostLeft;
        private int width;

        public MyCharater() : base()
        {
            mostLeft = Point.Empty;
        }

        public MyCharater(PenAttr _penAttr, List<Point> _points, FontAttr _fontAttr) :
            base(_penAttr)
        {
            mostLeft = new Point(_points[0].X, _points[0].Y);
            fontAttr = new FontAttr(_fontAttr);
        }

        public MyCharater(MyCharater myCharacter) :
            base(myCharacter)
        {
            mostLeft = new Point(myCharacter.mostLeft.X, myCharacter.mostLeft.Y);
            width = myCharacter.width;
            height = myCharacter.height;
            fontAttr = new FontAttr(myCharacter.fontAttr);
        }

        public FontAttr fontAttr { get; set; }

        private void getHeightAndWidthOfChar(Graphics graphics, Font font)
        {
            //get height and width of text
            width = (int)graphics.MeasureString(fontAttr.text, font).Width;
            height = (int)graphics.MeasureString(fontAttr.text, font).Height;
        }

        private int LengthOfFont(string font)
        {
            if (font.IndexOf(' ') >= 0)
            {
                String[] result = font.Split(' ');
                return result.Length;
            }
            return 0;
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            return _points.Count == 1;
        }

        public override MyShape Clone()
        {
            return new MyCharater(this);
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

        public override void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
        }

        public override List<Point> getEdgePoints()
        {
            List<Point> edgePoints = new List<Point>();
            edgePoints.Add(new Point(mostLeft.X, mostLeft.Y));
            return edgePoints;
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            // mac dinh khong chon vien
            return false;
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddRectangle(new Rectangle(mostLeft, new Size(width, height)));
                return path.IsVisible(p);
            }
        }

        public override void ReadData(string data)
        {
            // in ra string co dang "4 x y text size height  width color dashStyle width font"
            String[] result = data.Split(' ');
            mostLeft = new Point(Int32.Parse(result[1]), Int32.Parse(result[2]));

            fontAttr = new FontAttr(result[3], "", Int32.Parse(result[4]));
            height = Int32.Parse(result[5]);
            width = Int32.Parse(result[6]);

            // doc du lieu penAttr tu file
            Color colorShape = ConvertColorFromString(result[7]);
            DashStyle dashStyleFromFile = ConvertDashStypeFromString(result[8]);
            int widthFromFile = Int32.Parse(result[9]);

            if (Int32.Parse(result[10]) != 0)
            {
                for (int i = 0; i < Int32.Parse(result[10]); i++)
                {
                    fontAttr.fontFamily += result[11 + i] + " ";
                }
                fontAttr.fontFamily = fontAttr.fontFamily.Remove(fontAttr.fontFamily.Length - 1);
            }
            else
            {
                fontAttr.fontFamily += result[11];
            }

            penAttr = new PenAttr(colorShape, dashStyleFromFile, widthFromFile);
        }

        public override string WriteData()
        {
            // in ra string co dang "4 x y text size height  width color  dashStyle width font"
            String result = "4 ";
            result += mostLeft.X.ToString() + " ";
            result += mostLeft.Y.ToString() + " ";
            result += fontAttr.text + " ";
            result += fontAttr.size + " ";
            result += height.ToString() + " ";
            result += width.ToString() + " ";
            result += penAttr.color.ToArgb().ToString() + " " +
                    penAttr.dashStyle.ToString() + " " +
                    penAttr.width.ToString() + " ";
            result += LengthOfFont(fontAttr.fontFamily).ToString() + " ";
            result += fontAttr.fontFamily;
            return result;
        }
    }
}