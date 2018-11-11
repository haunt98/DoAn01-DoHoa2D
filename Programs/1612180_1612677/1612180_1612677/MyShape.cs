using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    public abstract class MyShape
    {
        private const int RANGE = 10;

        public MyShape(PenAttr _penAttr)
        {
            penAttr = new PenAttr(_penAttr);
            // mac dinh la mau trang
            brushAttr = new BrushAttr(Color.White, "SolidBrush");
        }

        public MyShape()
        {
            penAttr = null;
            brushAttr = null;
        }

        public MyShape(MyShape myShape)
        {
            penAttr = new PenAttr(myShape.penAttr);
            brushAttr = new BrushAttr(myShape.brushAttr);
        }

        public BrushAttr brushAttr { get; set; }
        public PenAttr penAttr { get; set; }

        // 2 diem gan nhau la duoc
        // khong can chinh xac lam
        public static bool isPointEqual(Point p, Point q)
        {
            List<Point> ps = new List<Point>();
            int pointRange = RANGE;
            for (int i = -pointRange; i <= pointRange; ++i)
            {
                for (int j = -pointRange; j <= pointRange; ++j)
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

        public abstract MyShape Clone();

        public Color ConvertColorFromString(String data)
        {
            Color result = Color.FromArgb(Int32.Parse(data));
            return result;
        }

        public DashStyle ConvertDashStypeFromString(String dashStyle)
        {
            DashStyle result = DashStyle.Solid;
            switch (dashStyle)
            {
                case "Dash":
                    result = DashStyle.Dash;
                    break;

                case "DashDot":
                    result = DashStyle.DashDot;
                    break;

                case "DashDotDot":
                    result = DashStyle.DashDotDot;
                    break;

                case "Dot":
                    result = DashStyle.Dot;
                    break;

                case "Solid":
                    result = DashStyle.Solid;
                    break;
            }
            return result;
        }

        public abstract void draw(Bitmap _bitmap, PictureBox pictureBox);

        public virtual void drawEdgePoints(Bitmap _bitmap, PictureBox pictureBox)
        {
            List<Point> edgePoints = getEdgePoints();
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                foreach (Point p in edgePoints)
                {
                    Point p_mostLeft = new Point(p.X - 2, p.Y - 2);
                    Rectangle rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(pen, rectangle);
                }
                pictureBox.Invalidate();
            }
        }

        public virtual void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(Color.White))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                Point p_mostLeft = new Point(p.X - 2, p.Y - 2);
                Rectangle rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                graphics.FillRectangle(brush, rectangle);
                graphics.DrawRectangle(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        // to mau
        public virtual void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
        }

        // edge vi du nhu 4 dinh hcn, diem dau va diem cuoi cua doan thang
        public abstract List<Point> getEdgePoints();

        // vi khi click tung pixel rat kho
        // nen xet them nhung diem lan can
        public bool isPointBelong(Point p)
        {
            List<Point> ps = new List<Point>();
            // lay nhung pixel xung quanh
            int clickRange = RANGE;
            for (int i = -clickRange; i <= clickRange; ++i)
            {
                for (int j = -clickRange; j <= clickRange; ++j)
                {
                    ps.Add(new Point(p.X + i, p.Y + j));
                }
            }

            foreach (Point temp_p in ps)
            {
                // chi can mot diem nam trong la nam trong
                if (isPointBelongPrecisely(p))
                    return true;
            }
            return false;
        }

        // kiem tra chinh xac mot diem nam o canh
        public abstract bool isPointBelongPrecisely(Point p);

        // kiem tra chinh xac mot diem nam be trong
        public virtual bool isPointInsidePrecisly(Point p)
        {
            return false;
        }

        // Doc data
        public abstract void ReadData(String data);

        // Viet data
        public abstract String WriteData();
    }
}