using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1612180_1612677
{
    public partial class FormMain : Form
    {
        private const int CLICK_SHAPE = -1;
        private const int LINE_SHAPE = 1;
        private const int NO_SHAPE = 0;
        private const int RECTANGLE_SHAPE = 2;

        // bitmap hien thi trong pictureBox
        private Bitmap bitmap;

        // bitmap luu tam
        private Bitmap bitmap_temp;

        // so thu tu cua hinh dang bi click
        // shapes[clickedShape] la hinh dang bi click
        private int clickedShape = -1;

        // trai qua su kien MouseDown chua
        private bool isMouseDown = false;

        // trai qua su kien MouseMove chua
        private bool isMouseMove = false;

        // p_end luu vi tri khi MouseUp
        private Point p_end;

        // p_start luu vi tri khi MouseDown
        private Point p_start;

        // luu danh sach cac hinh
        private List<MyShape> shapes = new List<MyShape>();

        private int typeShape = NO_SHAPE;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            // xoa het danh sach cac hinh
            shapes.Clear();

            // xoa trong pictureBox
            clearAll();
        }

        private void buttonClick_Click(object sender, EventArgs e)
        {
            typeShape = CLICK_SHAPE;
        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            typeShape = LINE_SHAPE;
        }

        private void buttonDrawRec_Click(object sender, EventArgs e)
        {
            typeShape = RECTANGLE_SHAPE;
        }

        // xoa het anh trong pictureBox
        private void clearAll()
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                pictureBoxMain.Invalidate();
            }
        }

        // wrap draw and pictureBox Invalidate
        private void drawWrap(MyShape myshape, Bitmap _bitmap)
        {
            myshape.draw(_bitmap);
            pictureBoxMain.Invalidate();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // tao bien bitmap gan cho pictureBox
            bitmap = new Bitmap(pictureBoxMain.Width,
                pictureBoxMain.Height,
                PixelFormat.Format24bppRgb);
            pictureBoxMain.Image = bitmap;
            clearAll();
        }

        private void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (typeShape == CLICK_SHAPE)
            {
                Point p = e.Location;
                int i;
                for (i = shapes.Count - 1; i >= 0; --i)
                {
                    if (shapes[i].isPointBelong(p))
                    {
                        clickedShape = i;
                        break;
                    }
                }
            }
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            switch (typeShape)
            {
                case NO_SHAPE:
                    break;

                case LINE_SHAPE:
                case RECTANGLE_SHAPE:
                    p_start = e.Location;
                    isMouseDown = true;
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            // kiem tra MouseDown chua
            if (!isMouseDown)
            {
                // MouseMove khong xay ra
                isMouseMove = false;
                return;
            }
            // xay ra MouseMove
            isMouseMove = true;

            // ve tren bitmap_temp
            switch (typeShape)
            {
                case NO_SHAPE:
                    break;

                case LINE_SHAPE:
                    bitmap_temp = (Bitmap)bitmap.Clone();
                    pictureBoxMain.Image = bitmap_temp;
                    p_end = e.Location;
                    MyShape myLine = new MyLine(
                        new PenAttr(Color.Red, DashStyle.Solid, 1),
                        p_start, p_end);
                    drawWrap(myLine, bitmap_temp);
                    break;

                case RECTANGLE_SHAPE:
                    bitmap_temp = (Bitmap)bitmap.Clone();
                    pictureBoxMain.Image = bitmap_temp;
                    p_end = e.Location;
                    MyShape myRectangle = new MyRectangle(
                        new PenAttr(Color.Red, DashStyle.Solid, 1),
                        p_start, p_end);
                    drawWrap(myRectangle, bitmap_temp);
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            // khong xay ra MouseMove thi khong lam gi ca
            if (!isMouseMove)
            {
                return;
            }
            isMouseMove = false;

            // ve tren bitmap
            switch (typeShape)
            {
                case NO_SHAPE:
                    break;

                case LINE_SHAPE:
                    pictureBoxMain.Image = bitmap;
                    p_end = e.Location;
                    MyShape myLine = new MyLine(
                        new PenAttr(Color.Red, DashStyle.Solid, 1),
                        p_start, p_end);
                    drawWrap(myLine, bitmap);
                    break;

                case RECTANGLE_SHAPE:
                    pictureBoxMain.Image = bitmap;
                    p_end = e.Location;
                    MyShape myRectangle = new MyRectangle(
                        new PenAttr(Color.Red, DashStyle.Solid, 1),
                        p_start, p_end);
                    drawWrap(myRectangle, bitmap);
                    break;

                default:
                    break;
            }
        }
    }
}