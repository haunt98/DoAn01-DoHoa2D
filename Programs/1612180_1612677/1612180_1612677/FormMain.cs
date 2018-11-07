using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1612180_1612677
{
    public partial class FormMain : Form
    {
        private const int ELLIPSE_STATE = 3;
        private const int LINE_STATE = 1;
        private const int NO_STATE = 0;
        private const int RECTANGLE_STATE = 2;
        private const int SELECT_STATE = -1;

        // bitmap hien thi chinh trong pictureBox
        private Bitmap bitmap;

        // bitmap luu tam
        private Bitmap bitmap_temp;

        // so thu tu cua hinh dang bi click
        // shapes[clickedShape] la hinh dang bi click
        //private int clickedShape = -1;

        // hien thu tu shape dang nhan
        private int clickedShape = -1;

        // trai qua su kien MouseDown chua
        private bool isMouseDown = false;

        // trai qua su kien MouseMove chua
        private bool isMouseMove = false;

        // luu danh sach cac hinh
        private List<MyShape> myShapes = new List<MyShape>();

        // p_end luu vi tri khi MouseUp
        private Point p_end;

        // p_start luu vi tri khi MouseDown
        private Point p_start;

        private int state = NO_STATE;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonChooseColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            buttonShowColor.BackColor = colorDialog.Color;
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            // xoa het danh sach cac hinh
            myShapes.Clear();

            // xoa trong pictureBox
            clearAllResetBitmap();

            // reset state
            state = NO_STATE;
        }

        private void buttonDrawEll_Click(object sender, EventArgs e)
        {
            state = ELLIPSE_STATE;
        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            state = LINE_STATE;
        }

        private void buttonDrawRec_Click(object sender, EventArgs e)
        {
            state = RECTANGLE_STATE;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            state = SELECT_STATE;
        }

        // xoa het anh trong pictureBox
        private void clearAllResetBitmap()
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);
                if (bitmap_temp != null)
                {
                    using (Graphics graphics_temp = Graphics.FromImage(bitmap_temp))
                    {
                        graphics_temp.Clear(Color.White);
                    }
                }
                // reset to primary bitmap
                pictureBoxMain.Image = bitmap;
                pictureBoxMain.Invalidate();
            }
        }

        private void drawShapes(Bitmap _bitmap)
        {
            foreach (MyShape myShape in myShapes)
            {
                myShape.draw(_bitmap);
            }
            pictureBoxMain.Invalidate();
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
            clearAllResetBitmap();

            // load ComboBox
            loadComboBoxDashStyle();

            // default color dialog
            colorDialog.Color = Color.Black;
            buttonShowColor.BackColor = colorDialog.Color;
        }

        private PenAttr getPenAttr()
        {
            PenAttr penAttr = null;
            switch (comboBoxDashStyle.SelectedItem.ToString())
            {
                case "Dash":
                    penAttr = new PenAttr(colorDialog.Color, DashStyle.Dash,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                case "DashDot":
                    penAttr = new PenAttr(colorDialog.Color, DashStyle.DashDot,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                case "DashDotDot":
                    penAttr = new PenAttr(colorDialog.Color, DashStyle.DashDotDot,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                case "Dot":
                    penAttr = new PenAttr(colorDialog.Color, DashStyle.Dot,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                case "Solid":
                    penAttr = new PenAttr(colorDialog.Color, DashStyle.Solid,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                default:
                    break;
            }
            return penAttr;
        }

        private void loadComboBoxDashStyle()
        {
            comboBoxDashStyle.Items.Add("Dash");
            comboBoxDashStyle.Items.Add("DashDot");
            comboBoxDashStyle.Items.Add("DashDotDot");
            comboBoxDashStyle.Items.Add("Dot");
            comboBoxDashStyle.Items.Add("Solid");
            comboBoxDashStyle.SelectedIndex = comboBoxDashStyle.Items.IndexOf("Solid");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                myShapes.Clear();
                String filepath = ofd.FileName;
                String[] lines = System.IO.File.ReadAllLines(filepath);
                MyShape myshape = null;
                foreach (string line in lines)
                {
                    if (line[0] == '1')
                    {
                        myshape = new MyLine();
                        myshape.ReadData(line);
                    }
                    else if (line[0] == '2')
                    {
                        myshape = new MyRectangle();
                        myshape.ReadData(line);
                    }
                    else if (line[0] == '3')
                    {
                        myshape = new MyEllipse();
                        myshape.ReadData(line);
                    }
                    myShapes.Add(myshape);
                }
                drawShapes(bitmap);
            }
        }

        // MouseClick xay ra khi click va tha cung 1 object
        private void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (state == SELECT_STATE)
            {
                Point p = e.Location;

                clickedShape = -1;
                for (int i = myShapes.Count - 1; i >= 0; --i)
                {
                    if (myShapes[i].isPointBelong(p))
                    {
                        clickedShape = i;
                        break;
                    }
                }
                switch (clickedShape)
                {
                    // click khong trung
                    case -1:
                        pictureBoxMain.Image = bitmap;
                        break;
                    // click trung
                    default:
                        bitmap_temp = (Bitmap)bitmap.Clone();
                        pictureBoxMain.Image = bitmap_temp;
                        myShapes[clickedShape].drawEdgePoints(bitmap_temp);
                        pictureBoxMain.Invalidate();
                        break;
                }
            }
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            switch (state)
            {
                case NO_STATE:
                    break;

                case LINE_STATE:
                case RECTANGLE_STATE:
                case ELLIPSE_STATE:
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
            switch (state)
            {
                case NO_STATE:
                    break;

                case LINE_STATE:
                    bitmap_temp = (Bitmap)bitmap.Clone();
                    pictureBoxMain.Image = bitmap_temp;
                    p_end = e.Location;
                    MyShape myLine = new MyLine(
                        getPenAttr(),
                        p_start, p_end);
                    drawWrap(myLine, bitmap_temp);
                    break;

                case RECTANGLE_STATE:
                    bitmap_temp = (Bitmap)bitmap.Clone();
                    pictureBoxMain.Image = bitmap_temp;
                    p_end = e.Location;
                    MyShape myRectangle = new MyRectangle(
                        getPenAttr(),
                        p_start, p_end);
                    drawWrap(myRectangle, bitmap_temp);
                    break;

                case ELLIPSE_STATE:
                    bitmap_temp = (Bitmap)bitmap.Clone();
                    pictureBoxMain.Image = bitmap_temp;
                    p_end = e.Location;
                    MyShape myEllipse = new MyEllipse(
                        getPenAttr(),
                        p_start, p_end);
                    drawWrap(myEllipse, bitmap_temp);
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
            switch (state)
            {
                case NO_STATE:
                    break;

                case LINE_STATE:
                    pictureBoxMain.Image = bitmap;
                    p_end = e.Location;
                    MyShape myLine = new MyLine(
                        getPenAttr(),
                        p_start, p_end);
                    drawWrap(myLine, bitmap);
                    myShapes.Add(myLine);
                    break;

                case RECTANGLE_STATE:
                    pictureBoxMain.Image = bitmap;
                    p_end = e.Location;
                    MyShape myRectangle = new MyRectangle(
                        getPenAttr(),
                        p_start, p_end);
                    drawWrap(myRectangle, bitmap);
                    myShapes.Add(myRectangle);
                    break;

                case ELLIPSE_STATE:
                    pictureBoxMain.Image = bitmap;
                    p_end = e.Location;
                    MyShape myEllipse = new MyEllipse(
                        getPenAttr(),
                        p_start, p_end);
                    drawWrap(myEllipse, bitmap);
                    myShapes.Add(myEllipse);
                    break;

                default:
                    break;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.FileName = "Untitled.txt";
            sfd.DefaultExt = "txt";
            sfd.Filter = "Text files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = sfd.OpenFile();
                using (StreamWriter sWriter = new StreamWriter(fileStream, Encoding.ASCII))
                {
                    for (int i = 0; i < myShapes.Count; i++)
                    {
                        sWriter.WriteLine(myShapes[i].WriteData());
                    }
                    sWriter.Flush();
                }
                fileStream.Close();
            }
        }

        private void buttonReloadAfterChange_Click(object sender, EventArgs e)
        {
            if (state == SELECT_STATE)
            {
                if (clickedShape < 0 || clickedShape >= myShapes.Count)
                    return;
                myShapes[clickedShape].penAttr = getPenAttr();
                clearAllResetBitmap();
                drawShapes(bitmap);
            }
        }
    }
}