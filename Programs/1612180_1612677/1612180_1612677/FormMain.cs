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
        private const int CHARACTER_STATE = 4;
        private const int ELLIPSE_STATE = 3;
        private const int LINE_STATE = 1;
        private const int NO_STATE = 0;
        private const int POLYGON_STATE = 5;
        private const int RECTANGLE_STATE = 2;
        private const int SELECT_STATE = -1;

        // bitmap hien thi chinh trong pictureBox
        private Bitmap bitmap_primary;

        // bitmap luu tam
        private Bitmap bitmap_temp;

        // hien thu tu shape dang nhan vao trong
        private int selectInsideShape;

        // hien thu tu shape dang nhan vao bien
        private int selectOutlineShape;

        // luu cac diem cho hinh da giac
        // nhu hinh binh hanh, ...
        private List<Point> clickedPoints = new List<Point>();

        // luu cac hinh duoc select
        private List<int> selectShape = new List<int>();

        //luu bien filePath
        private String filePath = "";

        // trai qua su kien MouseDown chua
        private bool isMouseDown = false;

        //trai qua su kien saveFile hay chua
        private bool isSaveFile = false;

        // luu danh sach cac hinh
        private List<MyShape> myShapes = new List<MyShape>();

        // state luu trang thai hien tai
        private int state = NO_STATE;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            clearBitmap();

            // reset list and state
            myShapes.Clear();
            clickedPoints.Clear();
            state = NO_STATE;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (state != SELECT_STATE)
                return;

            int clickedShape = selectInsideShape > selectOutlineShape
                ? selectInsideShape : selectOutlineShape;

            // chua click shape nao ca
            if (clickedShape == -1)
                return;

            // xoa shape ra khoi list
            myShapes.RemoveAt(clickedShape);
            // xoa roi ve lai
            clearBitmap();
            wrapRedrawAllShapes(bitmap_primary);
        }

        private void buttonDrawChar_Click(object sender, EventArgs e)
        {
            state = CHARACTER_STATE;
        }

        private void buttonDrawEll_Click(object sender, EventArgs e)
        {
            state = ELLIPSE_STATE;
        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            state = LINE_STATE;
        }

        private void buttonDrawPolygon_Click(object sender, EventArgs e)
        {
            state = POLYGON_STATE;
        }

        private void buttonDrawRec_Click(object sender, EventArgs e)
        {
            state = RECTANGLE_STATE;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            state = SELECT_STATE;
        }

        private void buttonShowColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            buttonShowColor.BackColor = colorDialog.Color;

            // reload lai mau sac cho vien cua shape
            if (state == SELECT_STATE)
            {
                int clickedShape = selectInsideShape > selectOutlineShape
                    ? selectInsideShape : selectOutlineShape;

                if (clickedShape == -1)
                    return;

                // click ben trong, doi mau ben trong
                if (clickedShape == selectInsideShape)
                {
                    if (myShapes[selectInsideShape] is MyCharater)
                    {
                        myShapes[selectInsideShape].penAttr = getPenAttr();
                        clearBitmap();
                        wrapRedrawAllShapes(bitmap_primary);
                    }
                    else
                    {
                        myShapes[selectInsideShape].brushAttr = getBrushAttr();
                        clearBitmap();
                        wrapRedrawAllShapes(bitmap_primary);
                    }
                }
                // click vien, doi mau vien
                else
                {
                    myShapes[selectOutlineShape].penAttr = getPenAttr();
                    clearBitmap();
                    wrapRedrawAllShapes(bitmap_primary);
                }
            }
        }

        // xoa het anh trong pictureBox
        private void clearBitmap()
        {
            using (Graphics graphics = Graphics.FromImage(bitmap_primary))
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
                pictureBoxMain.Image = bitmap_primary;
                pictureBoxMain.Invalidate();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // tao bien bitmap gan cho pictureBox
            bitmap_primary = new Bitmap(pictureBoxMain.Width,
                pictureBoxMain.Height,
                PixelFormat.Format24bppRgb);
            pictureBoxMain.Image = bitmap_primary;
            clearBitmap();

            // Dash Style combo box
            comboBoxDashStyle.Items.Add("Dash");
            comboBoxDashStyle.Items.Add("DashDot");
            comboBoxDashStyle.Items.Add("DashDotDot");
            comboBoxDashStyle.Items.Add("Dot");
            comboBoxDashStyle.Items.Add("Solid");
            comboBoxDashStyle.SelectedIndex = comboBoxDashStyle.Items.IndexOf("Solid");

            // Brush Style combo box
            comboBoxBrushStyle.Items.Add("SolidBrush");
            comboBoxBrushStyle.SelectedIndex = comboBoxBrushStyle.Items.IndexOf("SolidBrush");

            // Font Style combo box
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBoxFont.Items.Add(font.Name.ToString());
            }
            comboBoxFont.SelectedItem = FontFamily.Families[1].Name.ToString();

            //set value of font size
            numericUpDownFontSize.Value = 12;

            // default color dialog
            colorDialog.Color = Color.Black;
            buttonShowColor.BackColor = colorDialog.Color;
        }

        private BrushAttr getBrushAttr()
        {
            BrushAttr brushAttr = new BrushAttr(colorDialog.Color,
                comboBoxBrushStyle.SelectedItem.ToString());
            return brushAttr;
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
                    else if (line[0] == '4')
                    {
                        myshape = new MyCharater();
                        myshape.ReadData(line);
                    }
                    myShapes.Add(myshape);
                }
                wrapRedrawAllShapes(bitmap_primary);
            }
        }

        // MouseClick xay ra khi click va tha cung 1 object
        private void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            switch (state)
            {
                case SELECT_STATE:
                    Point p = e.Location;

                    // tim shape co diem nam tren
                    selectOutlineShape = -1;
                    for (int i = myShapes.Count - 1; i >= 0; --i)
                    {
                        if (myShapes[i].isPointBelong(p))
                        {
                            selectOutlineShape = i;
                            break;
                        }
                    }

                    // tim shape co diem nam trong
                    selectInsideShape = -1;
                    for (int i = myShapes.Count - 1; i >= 0; --i)
                    {
                        if (myShapes[i].isPointInsidePrecisly(p))
                        {
                            selectInsideShape = i;
                            break;
                        }
                    }

                    // chon shape nam ngoai cung
                    int clickedShape = selectOutlineShape > selectInsideShape ?
                        selectOutlineShape : selectInsideShape;
                    switch (clickedShape)
                    {
                        // click khong trung
                        case -1:
                            pictureBoxMain.Image = bitmap_primary;
                            break;
                        // click trung
                        default:
                            bitmap_temp = (Bitmap)bitmap_primary.Clone();
                            pictureBoxMain.Image = bitmap_temp;
                            // dau tien fill, sau do draw vien, sau do draw edge
                            MyShape myShape = myShapes[clickedShape].Clone();
                            myShape.fill(bitmap_temp, pictureBoxMain);
                            myShape.draw(bitmap_temp, pictureBoxMain);
                            myShape.drawEdgePoints(bitmap_temp, pictureBoxMain);
                            // neu click vao ben trong, danh dau tai diem click
                            if (clickedShape == selectInsideShape)
                            {
                                myShape.drawInsidePoint(bitmap_temp, e.Location, pictureBoxMain);
                            }
                            break;
                    }
                    break;

                case CHARACTER_STATE:
                    clickedPoints.Add(new Point(e.Location.X, e.Location.Y));
                    MyCharater myCharater = new MyCharater(getPenAttr(),
                        textBoxChar.Text,
                        clickedPoints,
                        comboBoxFont.Text.ToString(),
                        Convert.ToInt32(Math.Round(numericUpDownFontSize.Value, 0)));
                    // ve shape
                    myCharater.draw(bitmap_primary, pictureBoxMain);
                    myShapes.Add(myCharater);
                    clickedPoints.Clear();
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == NO_STATE || state == SELECT_STATE)
                return;
            // them diem hien tai vao click points
            clickedPoints.Add(new Point(e.Location.X, e.Location.Y));
            // ve tren bitmap primary
            pictureBoxMain.Image = bitmap_primary;
            // click point du dieu kien moi ve
            bool flag = false;
            switch (state)
            {
                case LINE_STATE:
                    flag = MyLine.isClickedPointsCanDrawShape(clickedPoints);
                    break;

                case RECTANGLE_STATE:
                    flag = MyRectangle.isClickedPointsCanDrawShape(clickedPoints);
                    break;

                case ELLIPSE_STATE:
                    flag = MyEllipse.isClickedPointsCanDrawShape(clickedPoints);
                    break;

                case POLYGON_STATE:
                    flag = MyPolygon.isClickedPointsCanDrawShape(clickedPoints);
                    break;

                default:
                    break;
            }

            if (flag)
            {
                MyShape myShape = null;
                switch (state)
                {
                    case LINE_STATE:
                        myShape = new MyLine(getPenAttr(), clickedPoints);
                        break;

                    case RECTANGLE_STATE:
                        myShape = new MyRectangle(getPenAttr(), clickedPoints);
                        break;

                    case ELLIPSE_STATE:
                        myShape = new MyEllipse(getPenAttr(), clickedPoints);
                        break;

                    case POLYGON_STATE:
                        // vi diem dau diem cuoi da giac trung nhau
                        clickedPoints.RemoveAt(clickedPoints.Count - 1);
                        myShape = new MyPolygon(getPenAttr(), clickedPoints);
                        break;

                    default:
                        break;
                }
                // ve shape
                myShape.draw(bitmap_primary, pictureBoxMain);
                // them vao list shape
                myShapes.Add(myShape);
                // reset list click point
                clickedPoints.Clear();
                // khong bat su kien mouse down nua vi ve xong
                isMouseDown = false;
            }
            // van con mouse down
            else
            {
                isMouseDown = true;
            }
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            // neu khong con mouse down thi khong ve nua
            if (!isMouseDown || state == NO_STATE || state == SELECT_STATE)
            {
                return;
            }
            // them diem hien tai vao click points
            clickedPoints.Add(new Point(e.Location.X, e.Location.Y));
            // ve tren bitmap_temp
            bitmap_temp = (Bitmap)bitmap_primary.Clone();
            pictureBoxMain.Image = bitmap_temp;

            // tao shape
            MyShape myShape = null;
            switch (state)
            {
                case LINE_STATE:
                    myShape = new MyLine(getPenAttr(), clickedPoints);
                    break;

                case RECTANGLE_STATE:
                    myShape = new MyRectangle(getPenAttr(), clickedPoints);
                    break;

                case ELLIPSE_STATE:
                    myShape = new MyEllipse(getPenAttr(), clickedPoints);
                    break;

                case POLYGON_STATE:
                    myShape = new MyPolygon(getPenAttr(), clickedPoints);
                    break;

                default:
                    break;
            }

            // ve shape
            myShape.draw(bitmap_temp, pictureBoxMain);
            myShape.drawEdgePoints(bitmap_temp, pictureBoxMain);

            // remove vi tri vua ve
            // vi day chi la mouse move tam thoi
            clickedPoints.RemoveAt(clickedPoints.Count - 1);
        }

        private void reloadFontAttr(object sender, EventArgs e)
        {
            if (state != SELECT_STATE)
                return;

            int clickedShape = selectInsideShape > selectOutlineShape
                ? selectInsideShape : selectOutlineShape;

            // chua click shape nao ca
            if (clickedShape == -1)
                return;
            else
            {
                clearBitmap();
                pictureBoxMain.Image = bitmap_temp;

                // ve trong bitmap temp

                // dau tien fill, sau do draw vien, sau do draw edge
                if (myShapes[clickedShape] is MyCharater)
                {
                    MyShape myShape = myShapes[clickedShape];
                    myShape.penAttr = getPenAttr();
                    MyCharater myCharacter = myShape as MyCharater;
                    myCharacter.SetValueOfChar(textBoxChar.Text,
                        comboBoxFont.Text.ToString(),
                        Int32.Parse(numericUpDownFontSize.Value.ToString()));
                    pictureBoxMain.Invalidate();
                }
                // ve trong bitmap real
                wrapRedrawAllShapes(bitmap_temp);
            }
        }

        private void reloadPenAttr(object sender, EventArgs e)
        {
            if (state != SELECT_STATE)
                return;

            int clickedShape = selectInsideShape > selectOutlineShape
                ? selectInsideShape : selectOutlineShape;

            // chua click shape nao ca
            if (clickedShape == -1)
                return;

            // click vien cua shape
            if (clickedShape == selectOutlineShape)
            {
                myShapes[clickedShape].penAttr = getPenAttr();

                // tao bitmap temp va reset bitmap
                Bitmap btemp = (Bitmap)bitmap_primary.Clone();
                clearBitmap();
                bitmap_temp = (Bitmap)btemp.Clone();
                pictureBoxMain.Image = bitmap_temp;

                // ve trong bitmap real
                wrapRedrawAllShapes(bitmap_primary);

                // ve trong bitmap temp
                // dau tien fill, sau do draw vien, sau do draw edge
                MyShape myShape = myShapes[clickedShape].Clone();
                myShape.fill(bitmap_temp, pictureBoxMain);
                myShape.draw(bitmap_temp, pictureBoxMain);
                myShape.drawEdgePoints(bitmap_temp, pictureBoxMain);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isSaveFile)
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
                    filePath = sfd.FileName;
                    using (StreamWriter sWriter = new StreamWriter(fileStream, Encoding.ASCII))
                    {
                        for (int i = 0; i < myShapes.Count; i++)
                        {
                            sWriter.WriteLine(myShapes[i].WriteData());
                        }
                        sWriter.Flush();
                    }
                    fileStream.Close();
                    isSaveFile = true;
                }
            }
            else
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
                {
                    foreach (MyShape shape in myShapes)
                    {
                        file.WriteLine(shape.WriteData());
                    }
                }
            }
        }

        private void wrapRedrawAllShapes(Bitmap _bitmap)
        {
            foreach (MyShape myShape in myShapes)
            {
                // fill truoc draw sau de ve vien
                myShape.fill(_bitmap, pictureBoxMain);
                myShape.draw(_bitmap, pictureBoxMain);
            }
        }

        private void buttonUnselect_Click(object sender, EventArgs e)
        {
            if (state == SELECT_STATE)
            {
                state = NO_STATE;
            }
        }
    }
}