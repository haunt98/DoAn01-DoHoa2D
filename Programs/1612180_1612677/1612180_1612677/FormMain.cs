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
        private Bitmap bitmap;

        // Luu danh sach cac hinh
        private List<MyShape> shapes = new List<MyShape>();

        private Point p1 = new Point();
        private Point p2 = new Point();
        private bool moving = false;

        // 0 khong ve
        // 1 line
        // 2 rectangle
        private int typeShape = 0;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonDrawRec_Click(object sender, EventArgs e)
        {
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (typeShape == 0)
                return;
            if (typeShape == 1)
            {
                p1.X = e.X;
                p1.Y = e.Y;
                moving = true;
            }
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (typeShape == 0)
                return;
            moving = false;
            if (typeShape == 1)
            {
                MyShape myshape = new MyLine(bitmap, p1, p2);
                shapes.Add(myshape);
                myshape.draw();
                pictureBoxMain.Refresh();
            }
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (typeShape == 0)
                return;
            if (typeShape == 1 && moving)
            {
                p2.X = e.X;
                p2.Y = e.Y;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // tao bien bitmap gan cho pictureBox
            bitmap = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height, PixelFormat.Format24bppRgb);
            pictureBoxMain.Image = bitmap;
            clear();
        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            typeShape = 1;
        }

        // xoa het anh trong pictureBox
        private void clear()
        {
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.Dispose();
            pictureBoxMain.Refresh();
        }
    }
}