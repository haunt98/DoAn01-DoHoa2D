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

        // luu cac diem cho hinh da giac
        // nhu hinh binh hanh, ...
        private List<Point> clickedPoints = new List<Point>();

        //luu bien filePath
        private String filePath = "";

        // trai qua su kien MouseDown chua
        private bool isMouseDown = false;

        //trai qua su kien saveFile hay chua
        private bool isSaveFile = false;

        // luu danh sach cac hinh
        private List<MyShape> myShapes = new List<MyShape>();

        // hien thu tu shape dang nhan vao trong
        private int selectInsideShape;

        // hien thu tu shape dang nhan vao bien
        private int selectOutlineShape;

        // luu cac hinh duoc select
        private List<int> selectShape = new List<int>();

        // state luu trang thai hien tai
        private int state = NO_STATE;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            clearBitmap();

            // reset list
            myShapes.Clear();
            clickedPoints.Clear();
            selectShape.Clear();
            // reset state
            state = NO_STATE;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (state != SELECT_STATE || selectShape.Count == 0)
                return;

            // sap xep selectShape theo giam dan roi moi xoa
            foreach (int select_temp in selectShape.OrderByDescending(i => i))
            {
                myShapes.RemoveAt(select_temp);
            }

            state = NO_STATE;
            selectShape.Clear();
            // xoa roi ve lai
            clearBitmap();
            wrapRedrawAllShapes(bitmap_primary);
        }

        private void buttonDrawChar_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShape.Clear();
            // set state
            state = CHARACTER_STATE;
        }

        private void buttonDrawEll_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShape.Clear();
            // set state
            state = ELLIPSE_STATE;
        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShape.Clear();
            // set state
            state = LINE_STATE;
        }

        private void buttonDrawPolygon_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShape.Clear();
            // set state
            state = POLYGON_STATE;
        }

        private void buttonDrawRec_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShape.Clear();
            // set state
            state = RECTANGLE_STATE;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            // set state
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

        private void buttonUnselect_Click(object sender, EventArgs e)
        {
            if (state == SELECT_STATE)
            {
                state = NO_STATE;
                selectShape.Clear();
                // xoa roi ve lai
                clearBitmap();
                wrapRedrawAllShapes(bitmap_primary);
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

        private FontAttr getFontAttr()
        {
            FontAttr fontAttr = new FontAttr(textBoxChar.Text,
                comboBoxFont.SelectedItem.ToString(),
                Convert.ToInt32(Math.Round(numericUpDownFontSize.Value, 0)));
            return fontAttr;
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
                MyShape myShape = null;
                foreach (string line in lines)
                {
                    if (line[0] == '1')
                    {
                        myShape = new MyLine();
                        myShape.ReadData(line);
                    }
                    else if (line[0] == '2')
                    {
                        myShape = new MyRectangle();
                        myShape.ReadData(line);
                    }
                    else if (line[0] == '3')
                    {
                        myShape = new MyEllipse();
                        myShape.ReadData(line);
                    }
                    else if (line[0] == '4')
                    {
                        myShape = new MyCharater();
                        myShape.ReadData(line);
                    }
                    else if (line[0] == '5')
                    {
                        myShape = new MyPolygon();
                        myShape.ReadData(line);
                    }
                    myShapes.Add(myShape);
                }
                wrapRedrawAllShapes(bitmap_primary);
            }
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == NO_STATE)
            {
                // khong nhan su kien mouse down
                // khi khong xay ra dieu gi ca
                isMouseDown = false;
                return;
            }
            // xu ly truong hop select
            if (state == SELECT_STATE)
            {
                processSelect(e);
                // khong nhan su kien mouse down nua vi select xong
                isMouseDown = false;
                return;
            }

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

                case CHARACTER_STATE:
                    flag = MyCharater.isClickedPointsCanDrawShape(clickedPoints);
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

                    case CHARACTER_STATE:
                        myShape = new MyCharater(getPenAttr(), clickedPoints, getFontAttr());
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
                // nhung hinh ve nhieu diem
                // nhu da giac, hinh binh hanh
                // can ve them luc mouse down nhung chua hoan thanh da giac
                // ve tren bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;

                // tao shape
                MyShape myShape = null;
                switch (state)
                {
                    case POLYGON_STATE:
                        myShape = new MyPolygon(getPenAttr(), clickedPoints);
                        break;

                    default:
                        break;
                }
                if (myShape != null)
                {
                    myShape.draw(bitmap_temp, pictureBoxMain);
                    myShape.drawEdgePoints(bitmap_temp, pictureBoxMain);
                }
                isMouseDown = true;
            }
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            // neu khong con mouse down thi khong ve nua
            if (!isMouseDown)
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

        private void processSelect(MouseEventArgs e)
        {
            Point p = new Point(e.Location.X, e.Location.Y);

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
            int select_temp = selectOutlineShape > selectInsideShape ?
                selectOutlineShape : selectInsideShape;

            // select khong trung
            if (select_temp == -1)
                return;

            // select trung thi ve tren bitmap_temp
            bitmap_temp = (Bitmap)bitmap_primary.Clone();
            pictureBoxMain.Image = bitmap_temp;
            // dau tien fill, sau do draw vien, sau do draw edge
            MyShape myShape = myShapes[select_temp].Clone();
            myShape.fill(bitmap_temp, pictureBoxMain);
            myShape.draw(bitmap_temp, pictureBoxMain);
            myShape.drawEdgePoints(bitmap_temp, pictureBoxMain);
            // neu click vao ben trong, danh dau tai diem click
            if (select_temp == selectInsideShape)
            {
                myShape.drawInsidePoint(bitmap_temp, e.Location, pictureBoxMain);
            }

            // them select vao list select shape
            if (selectShape.IndexOf(select_temp) == -1)
            {
                // khong co thi them vao
                selectShape.Add(select_temp);
            }
            else
            {
                // xoa roi them lai cho dung thu tu
                selectShape.Remove(select_temp);
                selectShape.Add(select_temp);
            }
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
                    myCharacter.fontAttr = getFontAttr();
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
    }
}