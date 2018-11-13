using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    public abstract class MyShape
    {
        protected const int RANGE = 10;
        protected Color COLOR_EDGE_POINTS = Color.White;
        protected Color COLOR_FIRST_POINT = Color.Red;
        protected Color COLOR_INSIDE_POINT = Color.White;
        protected Color COLOR_PEN_DEFAULT = Color.Black;
        protected Color COLOR_BRUSH_DEFAULT = Color.White;
        protected DashStyle DASH_STYLE_TEMP = DashStyle.Dot;

        public MyShape(PenAttr _penAttr, List<Point> _points)
        {
            penAttr = new PenAttr(_penAttr);
            points = new List<Point>(_points);
        }

        public PenAttr penAttr { get; set; }
        public List<Point> points { get; set; }

        // 2 diem gan nhau la duoc
        // khong can chinh xac lam
        public static bool isPointEqual(Point p, Point q)
        {
            List<Point> ps = new List<Point>();

            // pixel xung quanh p
            for (int i = -RANGE / 2; i <= RANGE / 2; ++i)
            {
                for (int j = -RANGE / 2; j <= RANGE / 2; ++j)
                {
                    ps.Add(new Point(p.X + i, p.Y + j));
                }
            }

            // chi can 1 diem trung la duoc
            foreach (Point p_temp in ps)
            {
                if (p_temp.Equals(q))
                    return true;
            }
            return false;
        }

        public abstract void draw(Bitmap _bitmap, PictureBox pictureBox);

        // ve net dut khi thay doi shape
        public abstract void drawTemporaryChange(Bitmap _bitmap, PictureBox pictureBox);

        // ve cac diem the hien khung cua shape
        public virtual void drawEdgePoints(Bitmap _bitmap, PictureBox pictureBox)
        {
            List<Point> edgePoints = getEdgePoints();
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(COLOR_EDGE_POINTS))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                foreach (Point p in edgePoints)
                {
                    Point p_mostLeft = new Point(p.X - RANGE / 2, p.Y - RANGE / 2);
                    Rectangle rectangle = new Rectangle(p_mostLeft, new Size(RANGE, RANGE));
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(pen, rectangle);
                }
                pictureBox.Invalidate();
            }
        }

        // ve diem dau tien cua shape
        public virtual void drawFirstPoint(Bitmap _bitmap, PictureBox pictureBox)
        {
            List<Point> edgePoints = getEdgePoints();
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(COLOR_FIRST_POINT))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                Point p_mostLeft = new Point(edgePoints[0].X - RANGE / 2, edgePoints[0].Y - RANGE / 2);
                Rectangle rectangle = new Rectangle(p_mostLeft, new Size(RANGE, RANGE));
                graphics.FillRectangle(brush, rectangle);
                graphics.DrawRectangle(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        // ve diem khi select ben trong shape
        public virtual void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(COLOR_INSIDE_POINT))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                Point p_mostLeft = new Point(p.X - RANGE / 2, p.Y - RANGE / 2);
                Rectangle rectangle = new Rectangle(p_mostLeft, new Size(RANGE, RANGE));
                graphics.FillRectangle(brush, rectangle);
                graphics.DrawRectangle(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        // to mau, cai dat cu the class con
        public virtual void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
        }

        // edge vi du nhu 4 dinh hcn, diem dau va diem cuoi cua doan thang
        public virtual List<Point> getEdgePoints()
        {
            return new List<Point>(points);
        }

        // 2 Point gan nhau coi nhu trung nhau
        public bool isPointBelong(Point p)
        {
            List<Point> ps = new List<Point>();

            // pixel xung quanh p
            for (int i = -RANGE / 2; i <= RANGE / 2; ++i)
            {
                for (int j = -RANGE / 2; j <= RANGE / 2; ++j)
                {
                    ps.Add(new Point(p.X + i, p.Y + j));
                }
            }

            // chi can mot diem nam trung
            foreach (Point temp_p in ps)
            {
                if (isPointBelongPrecisely(p))
                    return true;
            }
            return false;
        }

        // kiem tra chinh xac mot diem nam o canh
        public virtual bool isPointBelongPrecisely(Point p)
        {
            return false;
        }

        // kiem tra chinh xac mot diem nam be trong
        public virtual bool isPointInsidePrecisly(Point p)
        {
            return false;
        }

        // lay diem trong tam, la diem giu nguyen khi scale
        public virtual Point getCenterPoint()
        {
            Point center = new Point();
            int sum_X = 0;
            int sum_Y = 0;
            foreach (Point p in getEdgePoints())
            {
                sum_X += p.X;
                sum_Y += p.Y;
            }
            center.X = sum_X / getEdgePoints().Count;
            center.Y = sum_Y / getEdgePoints().Count;
            return center;
        }

        // scale shape, giu nguyen center
        public virtual void scalePoints(Point p_before, Point p_after)
        {
            // khong thay doi gi ca
            if (p_before.Equals(p_after))
            {
                return;
            }

            // khoang cach diem truoc va sau khi di chuyen den diem trung tam
            Point d_after = p_after - (Size)getCenterPoint();
            Point d_before = p_before - (Size)getCenterPoint();

            // tinh ty le scale
            float Sx = d_before.X == 0 ? 0.1f : (float)d_after.X / d_before.X;
            float Sy = d_before.Y == 0 ? 0.1f : (float)d_after.Y / d_before.Y;

            // gioi han co the scale
            if (Math.Abs(Sx) < 0.1f)
            {
                Sx = Sx > 0 ? 0.1f : -0.1f;
            }
            if (Math.Abs(Sy) < 0.1f)
            {
                Sy = Sy > 0 ? 0.1f : -0.1f;
            }

            // su dung matrix de scale
            Matrix matrix = new Matrix();
            // di chuyen goc toa do -> diem center
            matrix.Translate(getCenterPoint().X, getCenterPoint().Y);
            // scale theo ty le
            matrix.Scale(Sx, Sy);
            // di chuyen diem center -> goc toa do
            matrix.Translate(-getCenterPoint().X, -getCenterPoint().Y);

            // tinh scale points
            Point[] scalePoints = points.ToArray();
            matrix.TransformPoints(scalePoints);
            points = new List<Point>(scalePoints);
        }

        // rotate shape, giu nguyen center
        public virtual void rotatePoints(Point p_before, Point p_after)
        {

        }

        // di chuyen points
        public virtual void movePoints(Point p_before, Point p_after)
        {
            // tinh khoang cach di chuyen
            int moveWidth = p_after.X - p_before.X;
            int moveHeight = p_after.Y - p_before.Y;

            for (int i = 0; i < points.Count; ++i)
            {
                points[i] = new Point(points[i].X + moveWidth, points[i].Y + moveHeight);
            }
        }

        public virtual void updatePenAttr(PenAttr _penAttr)
        {
        }

        public virtual void updateBrushAttr(BrushAttr _brushAttr)
        {
        }

        public virtual void updateFontAttr(FontAttr _fontAttr)
        {
        }
    }
}
