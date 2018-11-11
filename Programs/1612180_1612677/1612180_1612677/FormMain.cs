using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace _1612180_1612677
{
    public partial class FormMain : Form
    {
        private const int BEZIER_STATE = 7;
        private const int CHARACTER_STATE = 4;
        private const int ELLIPSE_STATE = 3;
        private const int HINHBINHHANH_STATE = 6;
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

        // co dang moving shape hay khon
        private bool isMovingShape = false;

        //trai qua su kien saveFile hay chua
        private bool isSaveFile = false;

        // luu danh sach cac hinh
        private List<MyShape> myShapes = new List<MyShape>();

        // list Point cua shape truoc va sau move
        private List<Point> posMovingShape = new List<Point>();

        // thu tu cua shape dang duoc click
        private int selectedShape;

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
            posMovingShape.Clear();

            // reset state
            state = NO_STATE;
            isMouseDown = false;
            isMovingShape = false;
            selectedShape = -1;
            selectInsideShape = -1;
            selectOutlineShape = -1;
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

        private void buttonDrawBezier_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShape.Clear();
            // set state
            state = BEZIER_STATE;
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

        private void buttonDrawHBH_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShape.Clear();
            // set state
            state = HINHBINHHANH_STATE;
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
                if (selectedShape == -1)
                    return;

                // click ben trong, doi mau ben trong
                if (selectedShape != selectOutlineShape)
                {
                    if (myShapes[selectedShape] is MyCharater)
                    {
                        myShapes[selectedShape].penAttr = getPenAttr();
                    }
                    else
                    {
                        myShapes[selectedShape].brushAttr = getBrushAttr();
                    }
                }
                // click vien, doi mau vien
                else
                {
                    myShapes[selectOutlineShape].penAttr = getPenAttr();
                }

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapRedrawAllShapes(bitmap_primary);

                // highlight trong bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapRedrawAllShapes(bitmap_temp);
                wrapHightLightShape(selectedShape, bitmap_temp);
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
            ofd.Filter = "Binary files (*.bin)|*.bin";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                myShapes.Clear();
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                int length = (int)bf.Deserialize(fs);
                myShapes = new List<MyShape>(length);
                for (int i = 0; i < length; i++)
                {
                    myShapes.Add((MyShape)bf.Deserialize(fs));
                }
                wrapRedrawAllShapes(bitmap_primary);
                fs.Close();
            }
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == NO_STATE)
            {
                // khong nhan su kien mouse down
                // khi khong xay ra dieu gi ca
                isMouseDown = false;
                // khong moving gi ca
                isMovingShape = false;
                // set bitmap_primary
                pictureBoxMain.Image = bitmap_primary;
                return;
            }
            // xu ly truong hop select
            if (state == SELECT_STATE)
            {
                processSelect(e);
                return;
            }
            // khong select thi khong move
            isMovingShape = false;

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

                case HINHBINHHANH_STATE:
                    flag = MyHinhBinhHanh.isClickedPointsCanDrawShape(clickedPoints);
                    break;

                case BEZIER_STATE:
                    flag = MyBezier.isClickedPointsCanDrawShape(clickedPoints);
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

                    case HINHBINHHANH_STATE:
                        myShape = new MyHinhBinhHanh(getPenAttr(), clickedPoints);
                        break;

                    case BEZIER_STATE:
                        myShape = new MyBezier(getPenAttr(), clickedPoints);
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

                    case HINHBINHHANH_STATE:
                        myShape = new MyHinhBinhHanh(getPenAttr(), clickedPoints);
                        break;

                    case BEZIER_STATE:
                        myShape = new MyBezier(getPenAttr(), clickedPoints);
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
            if (state == SELECT_STATE && isMovingShape)
            {
                processMoving(e);
                return;
            }
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

                case HINHBINHHANH_STATE:
                    myShape = new MyHinhBinhHanh(getPenAttr(), clickedPoints);
                    break;

                case BEZIER_STATE:
                    myShape = new MyBezier(getPenAttr(), clickedPoints);
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

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (state == SELECT_STATE)
            {
                // neu khong select trung shape nao
                // thi khong lam gi ca
                if (selectedShape == -1)
                {
                    // reset list point vi tri cua shape truoc va sau
                    posMovingShape.Clear();

                    // khong cho phep moving khi tha ra
                    isMovingShape = false;
                    return;
                }

                // them diem hien tai khi mouse up
                posMovingShape.Add(new Point(e.Location.X, e.Location.Y));

                // vector di chuyen
                int moveWidth = posMovingShape[1].X - posMovingShape[0].X;
                int moveHeight = posMovingShape[1].Y - posMovingShape[0].Y;

                // di chuyen shape theo mouse move
                myShapes[selectedShape].movePoints(moveWidth, moveHeight);

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapRedrawAllShapes(bitmap_primary);

                // shape dang duoc click
                // lam noi bat len tren bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHightLightShape(selectedShape, bitmap_temp);
                if (selectedShape != selectOutlineShape)
                {
                    myShapes[selectedShape].drawInsidePoint(bitmap_temp, e.Location, pictureBoxMain);
                }

                // reset lai list moving shape
                posMovingShape.Clear();

                // khong cho phep moving khi tha ra
                isMovingShape = false;
            }
        }

        private void processMoving(MouseEventArgs e)
        {
            // khong click vao shape nao
            if (selectedShape == -1)
            {
                posMovingShape.Clear();
                return;
            }
            // them diem hien tai vao list vi tri cua shape moving
            posMovingShape.Add(new Point(e.Location.X, e.Location.Y));

            // vector di chuyen
            int moveWidth = posMovingShape[1].X - posMovingShape[0].X;
            int moveHeight = posMovingShape[1].Y - posMovingShape[0].Y;

            // di chuyen shape theo mouse move
            myShapes[selectedShape].movePoints(moveWidth, moveHeight);

            // xoa roi ve lai trong bitmap_primary
            clearBitmap();
            wrapRedrawAllShapes(bitmap_primary);

            // highlight select shape trong khi di chuyen
            wrapHightLightShape(selectedShape, bitmap_primary);
            if (selectedShape != selectOutlineShape)
            {
                myShapes[selectedShape].drawInsidePoint(bitmap_primary, e.Location, pictureBoxMain);
            }

            // xoa diem hien ra khoi list vi tri cua shape moving
            // vi chi la ve tam
            posMovingShape.RemoveAt(posMovingShape.Count - 1);
            // reset lai points cua shape vi chi la ve tam
            myShapes[selectedShape].movePoints(-moveWidth, -moveHeight);
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
            selectedShape = selectOutlineShape >= selectInsideShape ?
                selectOutlineShape : selectInsideShape;

            // select khong trung
            if (selectedShape == -1)
            {
                // Ve bang bitmap_primary
                pictureBoxMain.Image = bitmap_primary;

                // reset vi tri truoc va sau cua shape
                posMovingShape.Clear();

                // select khong trung thi khong cho moving
                isMovingShape = false;
                return;
            }
            // select trung thi them dia diem shape hien tai
            posMovingShape.Add(new Point(e.Location.X, e.Location.Y));

            // select trung thi ve tren bitmap_temp
            // hightlight shape dang select
            bitmap_temp = (Bitmap)bitmap_primary.Clone();
            pictureBoxMain.Image = bitmap_temp;
            wrapHightLightShape(selectedShape, bitmap_temp);
            if (selectedShape != selectOutlineShape)
            {
                myShapes[selectedShape].drawInsidePoint(bitmap_temp, e.Location, pictureBoxMain);
            }

            // them select vao list select shape
            if (selectShape.IndexOf(selectedShape) == -1)
            {
                // khong co thi them vao
                selectShape.Add(selectedShape);
            }

            // select trung thi cho phep moving
            isMovingShape = true;
        }

        private void reloadFontAttr(object sender, EventArgs e)
        {
            if (state != SELECT_STATE)
                return;

            // chua click shape nao ca
            if (selectedShape == -1)
                return;

            // kiem tra character
            if (myShapes[selectedShape] is MyCharater)
            {
                myShapes[selectedShape].penAttr = getPenAttr();
                MyCharater myCharacter = myShapes[selectedShape] as MyCharater;
                myCharacter.fontAttr = getFontAttr();

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapRedrawAllShapes(bitmap_primary);

                // highlight trong bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHightLightShape(selectedShape, bitmap_temp);
            }
        }

        private void reloadPenAttr(object sender, EventArgs e)
        {
            if (state != SELECT_STATE)
                return;

            // chua click shape nao ca
            if (selectedShape == -1)
                return;

            // click vien cua shape
            if (selectedShape == selectOutlineShape)
            {
                // thay doi vien
                myShapes[selectedShape].penAttr = getPenAttr();

                // xo roi ve lai trong bitmap_primary
                clearBitmap();
                wrapRedrawAllShapes(bitmap_primary);

                // hightlight trong bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHightLightShape(selectedShape, bitmap_temp);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\";
            sfd.RestoreDirectory = true;
            sfd.FileName = "Untitled";
            sfd.DefaultExt = "bin";
            sfd.Filter = "Binary files (*.bin)|*.bin";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filePath = sfd.FileName;
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, myShapes.Count);
                for (int i = 0; i < myShapes.Count; i++)
                {
                    bf.Serialize(fs, myShapes[i]);
                }
                fs.Close();
                isSaveFile = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isSaveFile)
            {
                FileStream fs = new FileStream(filePath, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, myShapes.Count);
                for (int i = 0; i < myShapes.Count; i++)
                {
                    bf.Serialize(fs, myShapes[i]);
                }
                fs.Close();
                isSaveFile = true;
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void wrapHightLightShape(int _hlShape, Bitmap _bitmap)
        {
            // dau tien fill, sau do draw vien, sau do draw edge
            myShapes[_hlShape].fill(_bitmap, pictureBoxMain);
            myShapes[_hlShape].draw(_bitmap, pictureBoxMain);
            myShapes[_hlShape].drawEdgePoints(_bitmap, pictureBoxMain);
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