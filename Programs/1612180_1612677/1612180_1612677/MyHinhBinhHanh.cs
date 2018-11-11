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
    public class MyHinhBinhHanh : MyShape
    {
        private List<Point> points;

        public MyHinhBinhHanh(PenAttr _penAttr, List<Point> _points) :
            base(_penAttr)
        {
            points = new List<Point>(_points);
        }

        public MyHinhBinhHanh() :
            base()
        {
            points = new List<Point>();
        }

        public MyHinhBinhHanh(MyHinhBinhHanh myHinhBinhHanh) :
            base(myHinhBinhHanh)
        {
            points = new List<Point>(myHinhBinhHanh.points);
        }

        public static bool isClickedPointsCanDrawShape(List<Point> _points)
        {
            // hinh binh hanh ve bang 3 diem
            return _points.Count == 3;
        }

        public override MyShape Clone()
        {
            return new MyHinhBinhHanh(this);
        }

        public override void draw(Bitmap _bitmap, PictureBox pictureBox)
        {
            throw new NotImplementedException();
        }

        public override void drawEdgePoints(Bitmap _bitmap, PictureBox pictureBox)
        {
            base.drawEdgePoints(_bitmap, pictureBox);
        }

        public override void fill(Bitmap _bitmap, PictureBox pictureBox)
        {
            base.fill(_bitmap, pictureBox);
        }

        public override List<Point> getEdgePoints()
        {
            throw new NotImplementedException();
        }

        public override bool isPointBelongPrecisely(Point p)
        {
            throw new NotImplementedException();
        }

        public override bool isPointInsidePrecisly(Point p)
        {
            return base.isPointInsidePrecisly(p);
        }

        public override void ReadData(string data)
        {
            throw new NotImplementedException();
        }

        public override string WriteData()
        {
            throw new NotImplementedException();
        }
    }
}