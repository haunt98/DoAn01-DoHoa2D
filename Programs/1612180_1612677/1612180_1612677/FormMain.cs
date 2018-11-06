using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private const int REC_SHAPE = 2;

        private int typeShape = NO_SHAPE;

        private Bitmap bitmap;
        private bool isMouseDown = false;

        private Point p1;
        private Point p2;

        // luu danh sach cac hinh
        private List<MyShape> shapes = new List<MyShape>();

        // so thu tu cua hinh dang bi click
        // shapes[clickedShape] la hinh dang bi click
        private int clickedShape = -1;

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
            typeShape = REC_SHAPE;
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

        private void drawShapes()
        {
            foreach (MyShape shape in shapes)
            {
                shape.draw();
            }
            pictureBoxMain.Invalidate();
        }

        // wrap draw and pictureBox Invalidate
        private void drawWrap(MyShape myshape)
        {
            myshape.draw();
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
                p1 = e.Location;
                int i;
                for (i = shapes.Count - 1; i >= 0; --i)
                {
                    if (shapes[i].isPointBelong(p1))
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
                case REC_SHAPE:
                    p1 = e.Location;
                    isMouseDown = true;
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            // kiem tra co dang di chuyen hay khong
            if (!isMouseDown)
            {
                return;
            }
            MyShape myshape;
            switch (typeShape)
            {
                case NO_SHAPE:
                    break;

                case LINE_SHAPE:
                    // xoa doan thang cu
                    myshape = new MyLine(bitmap, new Pen(Color.White), p1, p2);
                    drawWrap(myshape);

                    // ve lai toan bo
                    drawShapes();
                    p2 = e.Location;
                    myshape = new MyLine(bitmap, new Pen(Color.Red), p1, p2);
                    drawWrap(myshape);
                    break;

                case REC_SHAPE:
                    // xoa hcn cu
                    myshape = new MyRectangle(bitmap, new Pen(Color.White), p1, p2);
                    drawWrap(myshape);

                    // ve lai toan bo
                    drawShapes();
                    p2 = e.Location;
                    myshape = new MyRectangle(bitmap, new Pen(Color.Red), p1, p2);
                    drawWrap(myshape);
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            switch (typeShape)
            {
                case NO_SHAPE:
                    break;

                case LINE_SHAPE:
                    // tha chuot ra
                    isMouseDown = false;

                    // them vao danh sach hinh
                    MyShape myshape = new MyLine(bitmap, new Pen(Color.Red), p1, p2);
                    shapes.Add(myshape);
                    break;

                case REC_SHAPE:
                    // tha chuot ra
                    isMouseDown = false;

                    // them vao danh sach hinh
                    myshape = new MyRectangle(bitmap, new Pen(Color.Red), p1, p2);
                    shapes.Add(myshape);
                    break;
            }
        }
    }
}