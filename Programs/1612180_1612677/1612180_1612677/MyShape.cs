﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _1612180_1612677
{
    [Serializable]
    public abstract class MyShape
    {
        private const int RANGE = 20;
        private Color COLOR_EDGE_POINTS = Color.White;
        private Color COLOR_FIRST_POINT = Color.Red;
        private Color COLOR_INSIDE_POINT = Color.Blue;

        public MyShape(PenAttr _penAttr, List<Point> _points)
        {
            penAttr = new PenAttr(_penAttr);

            // mac dinh la mau trang
            brushAttr = new BrushAttr(Color.White, "SolidBrush");

            points = new List<Point>(_points);
        }

        public BrushAttr brushAttr { get; set; }
        public PenAttr penAttr { get; set; }
        public List<Point> points { get; set; }

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

        public abstract void draw(Bitmap _bitmap, PictureBox pictureBox);

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
                    Point p_mostLeft = new Point(p.X - 2, p.Y - 2);
                    Rectangle rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(pen, rectangle);
                }
                pictureBox.Invalidate();
            }
        }

        // diem dau tien cua shape
        public virtual void drawFirstPoint(Bitmap _bitmap, PictureBox pictureBox)
        {
            List<Point> edgePoints = getEdgePoints();
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(COLOR_FIRST_POINT))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                Point p_mostLeft = new Point(edgePoints[0].X - 2, edgePoints[0].Y - 2);
                Rectangle rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
                graphics.FillRectangle(brush, rectangle);
                graphics.DrawRectangle(pen, rectangle);
                pictureBox.Invalidate();
            }
        }

        // diem khi select ben trong shape
        public virtual void drawInsidePoint(Bitmap _bitmap, Point p, PictureBox pictureBox)
        {
            using (Graphics graphics = Graphics.FromImage(_bitmap))
            using (Brush brush = new SolidBrush(COLOR_INSIDE_POINT))
            using (Pen pen = new Pen(Color.Black, 1))
            {
                Point p_mostLeft = new Point(p.X - 2, p.Y - 2);
                Rectangle rectangle = new Rectangle(p_mostLeft, new Size(4, 4));
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
        public virtual bool isPointBelongPrecisely(Point p)
        {
            return false;
        }

        // kiem tra chinh xac mot diem nam be trong
        public virtual bool isPointInsidePrecisly(Point p)
        {
            return false;
        }

        // di chuyen points
        public virtual void movePoints(int _moveWidth, int _moveHeight)
        {
            for (int i = 0; i < points.Count; ++i)
            {
                points[i] = new Point(points[i].X + _moveWidth, points[i].Y + _moveHeight);
            }
        }
    }
}