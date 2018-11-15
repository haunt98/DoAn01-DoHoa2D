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
        protected Color COLOR_BRUSH_DARK = Color.Black;

        public MyShape(PenAttr _penAttr, List<Point> _points)
        {
            penAttr = _penAttr;
            points = new List<Point>(_points);
            angleRotate = 0;
            tyleScale = new SizeF(1, 1);
        }

        public MyShape(List<Point> _points)
        {
            penAttr = new PenAttr(COLOR_PEN_DEFAULT, DashStyle.Solid, 1);
            points = new List<Point>(_points);
            angleRotate = 0;
            tyleScale = new SizeF(1, 1);
        }

        public MyShape(MyShape _myShape)
        {
            penAttr = new PenAttr(_myShape.penAttr);
            points = new List<Point>(_myShape.points);
            angleRotate = _myShape.angleRotate;
            tyleScale = _myShape.tyleScale;
        }

        public abstract MyShape clone();

        public PenAttr penAttr { get; set; }

        public List<Point> points { get; set; }

        // goc quay
        public float angleRotate { get; set; }

        public SizeF tyleScale { get; set; }

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

        // tinh goc tao boi vecto
        // https://en.wikipedia.org/wiki/Atan2
        public static float calcAngle(Point p_start, Point p_end)
        {
            return (float)Math.Atan2(p_end.Y - p_start.Y,
                p_end.X - p_start.X)
                / (float)Math.PI * 180;
        }

        public static float calcDistance(PointF p_start, PointF p_end)
        {
            return (float)Math.Sqrt(Math.Pow(p_end.X - p_start.X, 2)
                + Math.Pow(p_end.Y - p_start.Y, 2));
        }

        // diem click trong man hinh la diem nao trong shape truoc khi scale va rotate
        public virtual Point pointBeforeScaleRotate(Point p)
        {
            using (Matrix matrix = new Matrix())
            {
                // scale va rotate nguoc lai
                matrix.Translate(getCenterPoint().X, getCenterPoint().Y);
                matrix.Rotate(-angleRotate);
                matrix.Scale(1 / tyleScale.Width, 1 / tyleScale.Height);
                matrix.Translate(-getCenterPoint().X, -getCenterPoint().Y);

                Point[] temp_points = new Point[1];
                temp_points[0] = p;
                matrix.TransformPoints(temp_points);
                return temp_points[0];
            }
        }

        // tra ve index cua p trong edge points, neu khong co tra ve -1
        public virtual int IndexOfEdgePoints(Point p)
        {
            int i;
            for (i = 0; i < getEdgePoints().Count; ++i)
            {
                if (isPointEqual(pointBeforeScaleRotate(p), getEdgePoints()[i]))
                {
                    break;
                }
            }
            // khong trung voi diem nao ca
            if (i == getEdgePoints().Count)
            {
                i = -1;
            }
            return i;
        }

        public abstract void draw(Bitmap _bitmap, PictureBox pictureBox);

        // ve cac diem the hien khung cua shape
        public virtual void drawEdgePoints(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(COLOR_EDGE_POINTS))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                // smoothing graphics
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                // scale va rotate
                graphics.TranslateTransform(getCenterPoint().X, getCenterPoint().Y);
                graphics.ScaleTransform(tyleScale.Width, tyleScale.Height);
                graphics.RotateTransform(angleRotate);
                graphics.TranslateTransform(-getCenterPoint().X, -getCenterPoint().Y);

                foreach (Point p in getEdgePoints())
                {
                    Point p_mostLeft = new Point(p.X - RANGE / 2, p.Y - RANGE / 2);
                    Rectangle rectangle = new Rectangle(p_mostLeft, new Size(RANGE, RANGE));
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(pen, rectangle);
                }

                // reset bien hinh
                graphics.ResetTransform();

                pictureBox.Invalidate();
            }
        }

        // ve diem dau tien cua shape
        public virtual void drawFirstPoint(Bitmap _bitmap, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(COLOR_FIRST_POINT))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                // smoothing graphics
                graphics.SmoothingMode = SmoothingMode.HighQuality;

                // scale va rotate
                graphics.TranslateTransform(getCenterPoint().X, getCenterPoint().Y);
                graphics.ScaleTransform(tyleScale.Width, tyleScale.Height);
                graphics.RotateTransform(angleRotate);
                graphics.TranslateTransform(-getCenterPoint().X, -getCenterPoint().Y);

                Point p_mostLeft = new Point(getEdgePoints()[0].X - RANGE / 2, getEdgePoints()[0].Y - RANGE / 2);
                Rectangle rectangle = new Rectangle(p_mostLeft, new Size(RANGE, RANGE));
                graphics.FillRectangle(brush, rectangle);
                graphics.DrawRectangle(pen, rectangle);

                // reset bien hinh
                graphics.ResetTransform();

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
            PointF center = new PointF();
            float sum_X = 0;
            float sum_Y = 0;
            foreach (Point p in getEdgePoints())
            {
                sum_X += p.X;
                sum_Y += p.Y;
            }
            center.X = sum_X / getEdgePoints().Count;
            center.Y = sum_Y / getEdgePoints().Count;
            return Point.Round(center);
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

        // scale shape, giu nguyen center
        public virtual void scalePoints(Point _p_before, Point _p_after)
        {
            // tinh lai vi hinh co scale va rotate
            Point p_before = pointBeforeScaleRotate(_p_before);
            Point p_after = pointBeforeScaleRotate(_p_after);

            // vector truoc va sau khi di chuyen den diem trung tam
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

            tyleScale = new SizeF(Sx, Sy);
        }

        // rotate shape, giu nguyen center
        public virtual void rotatePoints(Point _p_before, Point _p_after)
        {
            // tinh lai vi hinh co scale va rotate
            Point p_before = pointBeforeScaleRotate(_p_before);
            Point p_after = pointBeforeScaleRotate(_p_after);

            angleRotate = calcAngle(getCenterPoint(), p_after)
                - calcAngle(getCenterPoint(), p_before);
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
