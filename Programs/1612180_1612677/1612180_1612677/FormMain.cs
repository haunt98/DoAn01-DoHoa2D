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
        private const int SELECT_STATE = -1;
        private const int NO_STATE = 0;
        private const int LINE_STATE = 1;
        private const int RECTANGLE_STATE = 2;
        private const int ELLIPSE_STATE = 3;
        private const int CHARACTER_STATE = 4;
        private const int POLYGON_STATE = 5;
        private const int PARALLELOGRAM_STATE = 6;
        private const int BEZIER_STATE = 7;
        private const int PARABOL_STATE = 8;
        private const int ARC_STATE = 9;

        // state luu trang thai hien tai
        private int state = NO_STATE;

        // bitmap hien thi chinh trong pictureBox
        private Bitmap bitmap_primary;

        // bitmap luu tam
        private Bitmap bitmap_temp;

        // luu cac diem cua shape
        private List<Point> clickedPoints = new List<Point>();

        // luu bien filePath
        private String filePath = "";

        // trai qua su kien MouseDown chua
        private bool isMouseDown = false;

        // co dang moving shape hay khong
        private bool isChangingShape = false;

        // trai qua su kien saveFile hay chua
        private bool isSaveFile = false;

        // luu danh sach cac hinh
        private List<MyShape> myShapes = new List<MyShape>();

        // list Point cua shape truoc va sau move
        private List<Point> posMovingShape = new List<Point>();

        // thu tu cua shape dang duoc select
        private int selectShape;

        // thu tu shape dang select vao trong
        private int selectInsideShape;

        // thu tu shape dang select vao bien
        private int selectOutlineShape;

        // luu cac hinh duoc select
        private List<int> selectShapes = new List<int>();

        // so lan toi da undo, redo
        private const int MAX_LIST_UNDO_REDO = 10;

        // index trong listMyShapes
        private int indexOfListMyShapes = -1;

        // luu cac gia tri myShapes trong qua trinh undo, redo
        private List<List<MyShape>> listMyShapes = new List<List<MyShape>>();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // tao bien bitmap gan cho pictureBox
            bitmap_primary = new Bitmap(pictureBoxMain.Width,
                pictureBoxMain.Height,
                PixelFormat.Format24bppRgb);
            pictureBoxMain.Image = bitmap_primary;
            clearBitmap();

            // them trang thai ban dau, khong co hinh nao vao undo redo
            listMyShapes.Add(cloneListMyShape(myShapes));
            ++indexOfListMyShapes;

            // Dash Style combo box
            comboBoxDashStyle.Items.Add("Dash");
            comboBoxDashStyle.Items.Add("DashDot");
            comboBoxDashStyle.Items.Add("DashDotDot");
            comboBoxDashStyle.Items.Add("Dot");
            comboBoxDashStyle.Items.Add("Solid");
            comboBoxDashStyle.SelectedIndex = comboBoxDashStyle.Items.IndexOf("Solid");

            // Brush Style combo box
            comboBoxBrushStyle.Items.Add("SolidBrush");
            comboBoxBrushStyle.Items.Add("HatchBrushVertical");
            comboBoxBrushStyle.Items.Add("HatchBrushHorizontal");
            comboBoxBrushStyle.Items.Add("HatchBrushForwardDiagonal");
            comboBoxBrushStyle.Items.Add("HatchBrushCross");
            comboBoxBrushStyle.SelectedIndex = comboBoxBrushStyle.Items.IndexOf("SolidBrush");

            // Font Style combo box
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBoxFont.Items.Add(font.Name.ToString());
            }
            // default font is Arial, otherwise fontback first font
            if (comboBoxFont.Items.IndexOf("Arial") != -1)
            {
                comboBoxFont.SelectedIndex = comboBoxFont.Items.IndexOf("Arial");
            }
            else
            {
                comboBoxFont.SelectedIndex = 0;
            }

            // default value of font size
            numericUpDownFontSize.Value = 16;

            // select style combo box
            comboBoxSelectType.Items.Add("Move");
            comboBoxSelectType.Items.Add("Scale");
            comboBoxSelectType.Items.Add("Rotate");
            comboBoxSelectType.SelectedIndex = comboBoxSelectType.Items.IndexOf("Move");

            // default color dialog
            colorDialog1.Color = Color.Black;
            buttonShowColor.BackColor = colorDialog1.Color;
            colorDialog2.Color = Color.Black;
            buttonColor2.BackColor = colorDialog2.Color;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (state != SELECT_STATE || selectShapes.Count == 0)
                return;

            deleteMultiObjFromMyShapes(selectShapes);

            state = NO_STATE;
            selectShapes.Clear();

            // redraw
            clearBitmap();
            wrapDrawAllShapes(bitmap_primary);
        }

        private void buttonDrawBezier_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = BEZIER_STATE;
        }

        private void buttonDrawChar_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = CHARACTER_STATE;
        }

        private void buttonDrawEll_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = ELLIPSE_STATE;
        }

        private void buttonDrawHBH_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = PARALLELOGRAM_STATE;
        }

        private void buttonDrawLine_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = LINE_STATE;
        }

        private void buttonDrawPara_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = PARABOL_STATE;
        }

        private void buttonDrawPolygon_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = POLYGON_STATE;
        }

        private void buttonDrawRec_Click(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = RECTANGLE_STATE;
        }

        private void buttonDrawArc(object sender, EventArgs e)
        {
            // reset list
            clickedPoints.Clear();
            selectShapes.Clear();
            // set state
            state = ARC_STATE;

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
            colorDialog1.ShowDialog();
            buttonShowColor.BackColor = colorDialog1.Color;
            // load lai mau vien
            reloadColorOutline(sender, e);
        }

        private void buttonUnselect_Click(object sender, EventArgs e)
        {
            if (state == SELECT_STATE)
            {
                state = NO_STATE;
                selectShapes.Clear();
                // xoa roi ve lai
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);
            }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            // load lai mau ben trong
            reloadColorInside(sender, e);
        }

        // xoa het anh trong pictureBox
        private void clearBitmap()
        {
            using (Graphics graphics = Graphics.FromImage(bitmap_primary))
            {
                graphics.ResetTransform();
                graphics.Clear(Color.White);
                if (bitmap_temp != null)
                {
                    using (Graphics graphics_temp = Graphics.FromImage(bitmap_temp))
                    {
                        graphics_temp.ResetTransform();
                        graphics_temp.Clear(Color.White);
                    }
                }

                // reset to primary bitmap
                pictureBoxMain.Image = bitmap_primary;
                pictureBoxMain.Invalidate();
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
                isChangingShape = false;
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
            // khong select thi khong change shape
            isChangingShape = false;

            // them diem hien tai vao click points
            clickedPoints.Add(e.Location);

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

                case PARALLELOGRAM_STATE:
                    flag = MyParallelogram.isClickedPointsCanDrawShape(clickedPoints);
                    break;

                case BEZIER_STATE:
                    flag = MyBezier.isClickedPointsCanDrawShape(clickedPoints);
                    break;

                case PARABOL_STATE:
                    flag = MyParabol.isClickedPointsCanDrawShape(clickedPoints);
                    break;

                case ARC_STATE:
                    flag = MyArc.isClickedPointsCanDrawShape(clickedPoints);
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
                        myShape = new MyPolygon(getPenAttr(), clickedPoints);
                        break;

                    case CHARACTER_STATE:
                        myShape = new MyCharater(clickedPoints, getFontAttr());
                        break;

                    case PARALLELOGRAM_STATE:
                        myShape = new MyParallelogram(getPenAttr(), clickedPoints);
                        break;

                    case BEZIER_STATE:
                        myShape = new MyBezier(getPenAttr(), clickedPoints);
                        break;

                    case PARABOL_STATE:
                        myShape = new MyParabol(getPenAttr(), clickedPoints);
                        break;

                    case ARC_STATE:
                        myShape = new MyArc(getPenAttr(), clickedPoints);
                        break;

                    default:
                        break;
                }
                if (myShape != null)
                {
                    // ve tren bitmap primary
                    pictureBoxMain.Image = bitmap_primary;

                    myShape.draw(bitmap_primary, pictureBoxMain);

                    // them vao list shape
                    addObjToMyShapes(myShape);
                }

                // reset list click point
                clickedPoints.Clear();
                // khong bat su kien mouse down nua vi ve xong
                isMouseDown = false;
            }
            // van con mouse down
            else
            {
                // tao shape
                MyShape myShape = null;
                switch (state)
                {
                    case POLYGON_STATE:
                        myShape = new MyPolygon(getPenAttr(), clickedPoints);
                        break;

                    case PARALLELOGRAM_STATE:
                        myShape = new MyParallelogram(getPenAttr(), clickedPoints);
                        break;

                    case BEZIER_STATE:
                        myShape = new MyBezier(getPenAttr(), clickedPoints);
                        break;

                    default:
                        break;
                }
                if (myShape != null)
                {
                    // ve tren bitmap_temp
                    bitmap_temp = (Bitmap)bitmap_primary.Clone();
                    pictureBoxMain.Image = bitmap_temp;

                    myShape.draw(bitmap_temp, pictureBoxMain);
                    myShape.drawEdgePoints(bitmap_temp, pictureBoxMain);
                }

                // ve chua xong nen tiep tuc bat su kien mouse down
                isMouseDown = true;
            }
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (state == SELECT_STATE)
            {
                if (isChangingShape)
                {
                    processChanging(e);
                }
                return;
            }
            // neu khong con mouse down thi khong ve nua
            if (!isMouseDown)
            {
                return;
            }

            // them diem hien tai vao click points
            clickedPoints.Add(e.Location);

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

                case PARALLELOGRAM_STATE:
                    myShape = new MyParallelogram(getPenAttr(), clickedPoints);
                    break;

                case BEZIER_STATE:
                    myShape = new MyBezier(getPenAttr(), clickedPoints);
                    break;

                case PARABOL_STATE:
                    myShape = new MyParabol(getPenAttr(), clickedPoints);
                    break;

                case ARC_STATE:
                    myShape = new MyArc(getPenAttr(), clickedPoints);
                    break;

                default:
                    break;
            }

            if (myShape != null)
            {
                // ve tren bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;

                myShape.draw(bitmap_temp, pictureBoxMain);
                myShape.drawEdgePoints(bitmap_temp, pictureBoxMain);
            }

            // remove vi tri vua ve
            // vi day chi la mouse move tam thoi
            clickedPoints.RemoveAt(clickedPoints.Count - 1);
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            // neu khong phai select state
            // khong changing shape
            // khong click trung
            if (state != SELECT_STATE || !isChangingShape)
            {
                resetSelect();
                return;
            }

            // khong reset bitmap_primary vi de vien de xac dinh
            if (selectShape == -1)
            {
                resetSelect();
                pictureBoxMain.Image = bitmap_primary;
                return;
            }

            // them diem hien tai khi mouse up
            posMovingShape.Add(e.Location);

            if (comboBoxSelectType.SelectedItem.ToString() == "Move")
            {
                // di chuyen shape theo mouse move
                changeMovePointsObjFromMyShapes(posMovingShape[0], posMovingShape[1], selectShape);

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // ve shape dang duoc click tren bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHighlightShape(bitmap_temp, selectShape);
            }
            else if (comboBoxSelectType.SelectedItem.ToString() == "Scale")
            {
                // scale shape theo mouse move
                changeScalePointsObjFromMyShapes(posMovingShape[0], posMovingShape[1], selectShape);

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // shape dang duoc click
                // lam noi bat len tren bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHighlightShape(bitmap_temp, selectShape);
            }
            else if (comboBoxSelectType.SelectedItem.ToString() == "Rotate")
            {
                // rotate shape theo mouse move
                changeRotatePointsObjFromMyShapes(posMovingShape[0], posMovingShape[1], selectShape);

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // shape dang duoc click
                // lam noi bat len tren bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHighlightShape(bitmap_temp, selectShape);
            }

            // reset lai list moving shape
            posMovingShape.Clear();

            // khong cho phep moving khi tha ra
            isChangingShape = false;
        }

        private void processChanging(MouseEventArgs e)
        {
            // khong click vao shape nao
            if (selectShape == -1)
            {
                resetSelect();
                pictureBoxMain.Image = bitmap_primary;
                return;
            }

            // them diem hien tai vao list vi tri cua shape moving
            posMovingShape.Add(e.Location);

            if (comboBoxSelectType.SelectedItem.ToString() == "Move")
            {
                // backup lai vi tri diem
                List<Point> backupPoints = new List<Point>(myShapes[selectShape].points);

                // di chuyen shape theo mouse move
                myShapes[selectShape].movePoints(posMovingShape[0], posMovingShape[1]);

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // highlight select shape trong khi di chuyen
                wrapHighlightShape(bitmap_primary, selectShape);

                // reset lai points cua shape vi chi la ve tam
                myShapes[selectShape].points = backupPoints;
            }
            else if (comboBoxSelectType.SelectedItem.ToString() == "Scale")
            {
                // backup lai ty le truoc khi scale
                SizeF backupTyleScale = myShapes[selectShape].tyleScale;

                // scale shape theo mouse move
                myShapes[selectShape].scalePoints(posMovingShape[0], posMovingShape[1]);

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // highlight select shape trong khi di chuyen
                wrapHighlightShape(bitmap_primary, selectShape);

                // reset lai ty le cua shape
                myShapes[selectShape].tyleScale = backupTyleScale;
            }
            else if (comboBoxSelectType.SelectedItem.ToString() == "Rotate")
            {
                // backup lai angle truoc khi rotate
                float backupAngleRotate = myShapes[selectShape].angleRotate;

                // rotate shape theo mouse move
                myShapes[selectShape].rotatePoints(posMovingShape[0], posMovingShape[1]);

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // highlight select shape trong khi di chuyen
                wrapHighlightShape(bitmap_primary, selectShape);

                // reset lai angle cua shape vi chi la ve tam
                myShapes[selectShape].angleRotate = backupAngleRotate;

            }

            // xoa diem hien ra khoi list vi tri cua shape moving
            // vi chi la ve tam
            posMovingShape.RemoveAt(posMovingShape.Count - 1);
        }

        private void processSelect(MouseEventArgs e)
        {
            // tim shape co diem nam tren
            selectOutlineShape = -1;
            for (int i = myShapes.Count - 1; i >= 0; --i)
            {
                if (myShapes[i].isPointBelong(e.Location))
                {
                    selectOutlineShape = i;
                    break;
                }
            }

            // tim shape co diem nam trong
            selectInsideShape = -1;
            for (int i = myShapes.Count - 1; i >= 0; --i)
            {
                if (myShapes[i].isPointInsidePrecisly(e.Location))
                {
                    selectInsideShape = i;
                    break;
                }
            }

            // uu tien shape nam ngoai cung
            selectShape = selectOutlineShape >= selectInsideShape ?
                selectOutlineShape : selectInsideShape;

            // select khong trung
            if (selectShape == -1)
            {
                resetSelect();
                pictureBoxMain.Image = bitmap_primary;
                return;
            }

            // select trung thi them dia diem shape hien tai
            posMovingShape.Add(e.Location);

            // mac dinh la khong cho change shape
            isChangingShape = false;

            // ve tren bitmap_temp
            bitmap_temp = (Bitmap)bitmap_primary.Clone();
            pictureBoxMain.Image = bitmap_temp;
            wrapHighlightShape(bitmap_temp, selectShape);

            if (comboBoxSelectType.SelectedItem.ToString() == "Move")
            {
                // neu khong co trong list select shape thi them vao
                if (selectShapes.IndexOf(selectShape) == -1)
                {
                    selectShapes.Add(selectShape);
                }

                // cho phep thuc hien thay doi shape
                isChangingShape = true;
            }
            else if (comboBoxSelectType.SelectedItem.ToString() == "Scale" ||
                comboBoxSelectType.SelectedItem.ToString() == "Rotate")
            {
                int index = myShapes[selectShape].IndexOfEdgePoints(e.Location);
                if (index != -1)
                {
                    // set chinh xac diem edge thay cho e.Location
                    posMovingShape[0] = myShapes[selectShape].getEdgePoints()[index];

                    // neu chua co trong list select shape thi them vao
                    if (selectShapes.IndexOf(selectShape) == -1)
                    {
                        selectShapes.Add(selectShape);
                    }

                    // cho phep thuc hien thay doi shape
                    isChangingShape = true;
                }
            }
        }

        private BrushAttr getBrushAttr()
        {
            BrushAttr brushAttr = new BrushAttr(colorDialog1.Color, colorDialog2.Color,
                comboBoxBrushStyle.SelectedItem.ToString());
            return brushAttr;
        }

        private FontAttr getFontAttr()
        {
            FontAttr fontAttr = new FontAttr(textBoxChar.Text,
                comboBoxFont.SelectedItem.ToString(),
                Convert.ToInt32(Math.Round(numericUpDownFontSize.Value, 0)),
                FontStyle.Regular);
            return fontAttr;
        }

        private PenAttr getPenAttr()
        {
            PenAttr penAttr = null;
            switch (comboBoxDashStyle.SelectedItem.ToString())
            {
                case "Dash":
                    penAttr = new PenAttr(colorDialog1.Color, DashStyle.Dash,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                case "DashDot":
                    penAttr = new PenAttr(colorDialog1.Color, DashStyle.DashDot,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                case "DashDotDot":
                    penAttr = new PenAttr(colorDialog1.Color, DashStyle.DashDotDot,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                case "Dot":
                    penAttr = new PenAttr(colorDialog1.Color, DashStyle.Dot,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                case "Solid":
                    penAttr = new PenAttr(colorDialog1.Color, DashStyle.Solid,
                        Convert.ToInt32(Math.Round(numericUpDownPenWidth.Value, 0)));
                    break;

                default:
                    break;
            }
            return penAttr;
        }

        private void reloadFontAttr(object sender, EventArgs e)
        {
            // chua click shape nao ca
            if (state != SELECT_STATE || selectShape == -1)
            {
                return;
            }

            if (selectShape != selectOutlineShape)
            {
                myShapes[selectShape].updateFontAttr(getFontAttr());

                // xoa roi ve lai trong bitmap_primary
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // hightlight trong bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHighlightShape(bitmap_temp, selectShape);
            }
        }

        private void reloadPenAttr(object sender, EventArgs e)
        {
            // chua click shape nao ca
            if (state != SELECT_STATE || selectShape == -1)
            {
                return;
            }

            // click vien cua shape
            if (selectShape == selectOutlineShape)
            {
                // thay doi vien
                myShapes[selectShape].updatePenAttr(getPenAttr());

                // xo roi ve lai trong bitmap_primary
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // hightlight trong bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHighlightShape(bitmap_temp, selectShape);
            }
        }

        private void reloadColorOutline(object sender, EventArgs e)
        {
            if (state != SELECT_STATE || selectShape == -1)
            {
                return;
            }

            // click outline, doi mau vien
            if (selectShape == selectOutlineShape)
            {
                myShapes[selectShape].updatePenAttr(getPenAttr());

                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // hightlight trong bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHighlightShape(bitmap_temp, selectShape);
            }
        }

        private void reloadColorInside(object sender, EventArgs e)
        {
            if (state != SELECT_STATE || selectShape == -1)
            {
                return;
            }

            // doi mau ben trong
            if (selectShape != selectOutlineShape)
            {
                myShapes[selectShape].updateBrushAttr(getBrushAttr());

                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);

                // hightlight trong bitmap_temp
                bitmap_temp = (Bitmap)bitmap_primary.Clone();
                pictureBoxMain.Image = bitmap_temp;
                wrapHighlightShape(bitmap_temp, selectShape);
            }
        }

        private void resetSelect()
        {
            // reset select points
            posMovingShape.Clear();

            // khong cho changing shape
            isChangingShape = false;
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
                    MyShape myShape = (MyShape)bf.Deserialize(fs);
                    addObjToMyShapes(myShape);
                }
                fs.Close();

                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);
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

        private void wrapDrawAllShapes(Bitmap _bitmap)
        {
            foreach (MyShape myShape in myShapes)
            {
                // fill truoc draw sau de ve vien
                myShape.fill(_bitmap, pictureBoxMain);
                myShape.draw(_bitmap, pictureBoxMain);
            }
        }

        private void wrapHighlightShape(Bitmap _bitmap, int _index)
        {
            if (_index < 0 || _index >= myShapes.Count)
                return;
            myShapes[_index].fill(_bitmap, pictureBoxMain);
            myShapes[_index].draw(_bitmap, pictureBoxMain);
            myShapes[_index].drawEdgePoints(_bitmap, pictureBoxMain);
        }

        // dua shape ve vi tri dau tien trong list
        // vi dau tien -> ve dau tien -> bi che khuat
        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state != SELECT_STATE || selectShape == -1)
                return;
            MyShape myShape = myShapes[selectShape];
            myShapes.RemoveAt(selectShape);
            myShapes.Insert(0, myShape);

            // reset lai picturebox
            clearBitmap();
            wrapDrawAllShapes(bitmap_primary);
        }

        // dua shape ve vi tri cuoi cung trong list
        // vi cuoi cung -> ve cuoi cung -> noi len tren
        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state != SELECT_STATE || selectShape == -1)
                return;
            MyShape myShape = myShapes[selectShape];
            myShapes.RemoveAt(selectShape);
            myShapes.Insert(myShapes.Count, myShape);

            // reset lai picturebox
            clearBitmap();
            wrapDrawAllShapes(bitmap_primary);
        }

        // lui lai 1 vi tri
        private void sendBackwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // vi tri 0 khong the lui
            if (state != SELECT_STATE || selectShape == -1 || selectShape == 0)
                return;

            MyShape myShape = myShapes[selectShape];
            myShapes.RemoveAt(selectShape);
            myShapes.Insert(selectShape - 1, myShape);

            // reset lai picturebox
            clearBitmap();
            wrapDrawAllShapes(bitmap_primary);
        }

        // tien toi mot vi tri
        private void bringForwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // vi tri count - 1 khong the tien
            if (state != SELECT_STATE || selectShape == -1 || selectShape == myShapes.Count - 1)
                return;

            MyShape myShape = myShapes[selectShape];
            myShapes.RemoveAt(selectShape);
            myShapes.Insert(selectShape + 1, myShape);

            // reset lai picturebox
            clearBitmap();
            wrapDrawAllShapes(bitmap_primary);
        }

        // khi thay doi combo box cua select type => reset select
        private void comboBoxSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetSelect();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            // khong co gi de undo
            if (indexOfListMyShapes == -1
                || indexOfListMyShapes == 0)
            {
                return;
            }
            else
            {
                indexOfListMyShapes -= 1;
                myShapes = cloneListMyShape(listMyShapes[indexOfListMyShapes]);

                // redraw
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);
            }
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            // khong co gi de redo
            if ((indexOfListMyShapes == MAX_LIST_UNDO_REDO)
                || indexOfListMyShapes == listMyShapes.Count - 1)
            {
                return;
            }
            else
            {
                indexOfListMyShapes += 1;
                myShapes = cloneListMyShape(listMyShapes[indexOfListMyShapes]);

                // redraw
                clearBitmap();
                wrapDrawAllShapes(bitmap_primary);
            }
        }

        // them shape vao myShapes
        // them myShapes vao list myShapes
        public void addObjToMyShapes(MyShape myShape)
        {
            // xoa het redo
            for (int i = listMyShapes.Count - 1; i >= indexOfListMyShapes + 1; i--)
            {
                listMyShapes.RemoveAt(i);
            }
            indexOfListMyShapes++;

            // them myShape vao myShapes
            myShapes.Add(myShape);

            // them myShapes clone vao listMyShapes
            listMyShapes.Add(cloneListMyShape(myShapes));
        }

        public void changeMovePointsObjFromMyShapes(Point p_before, Point p_after, int index)
        {
            // xoa het redo
            for (int i = listMyShapes.Count - 1; i >= indexOfListMyShapes + 1; i--)
            {
                listMyShapes.RemoveAt(i);
            }
            indexOfListMyShapes++;

            // thay doi myShapes[index]
            myShapes[index].movePoints(p_before, p_after);

            // them myShapes clone vao listMyShapes
            listMyShapes.Add(cloneListMyShape(myShapes));
        }

        public void changeScalePointsObjFromMyShapes(Point p_before, Point p_after, int index)
        {
            // xoa het redo
            for (int i = listMyShapes.Count - 1; i >= indexOfListMyShapes + 1; i--)
            {
                listMyShapes.RemoveAt(i);
            }
            indexOfListMyShapes++;

            // thay doi myShapes[index]
            myShapes[index].scalePoints(p_before, p_after);

            // them myShapes clone vao listMyShapes
            listMyShapes.Add(cloneListMyShape(myShapes));
        }

        public void changeRotatePointsObjFromMyShapes(Point p_before, Point p_after, int index)
        {
            // xoa het redo
            for (int i = listMyShapes.Count - 1; i >= indexOfListMyShapes + 1; i--)
            {
                listMyShapes.RemoveAt(i);
            }
            indexOfListMyShapes++;

            // thay doi myShapes[index]
            myShapes[index].rotatePoints(p_before, p_after);

            // them myShapes clone vao listMyShapes
            listMyShapes.Add(cloneListMyShape(myShapes));
        }

        public void deleteMultiObjFromMyShapes(List<int> multiIndex)
        {
            // xoa het redo
            for (int i = listMyShapes.Count - 1; i >= indexOfListMyShapes + 1; i--)
            {
                listMyShapes.RemoveAt(i);
            }
            indexOfListMyShapes++;

            // sap xep multiIndex theo giam dan roi moi xoa
            foreach (int index in multiIndex.OrderByDescending(i => i))
            {
                myShapes.RemoveAt(index);
            }

            // them myShapes clone vao listMyShapes
            listMyShapes.Add(cloneListMyShape(myShapes));
        }

        public void deleteAllObjFromMyShapes()
        {
            // xoa het redo
            for (int i = listMyShapes.Count - 1; i >= indexOfListMyShapes + 1; i--)
            {
                listMyShapes.RemoveAt(i);
            }
            indexOfListMyShapes++;

            // xoa het MyShape trong myShapes
            myShapes.Clear();

            // them myShapes clone vao listMyShapes
            listMyShapes.Add(cloneListMyShape(myShapes));
        }

        public List<MyShape> cloneListMyShape(List<MyShape> _myShapes)
        {
            List<MyShape> newList = new List<MyShape>();
            foreach (MyShape ms in _myShapes)
            {
                newList.Add(ms.clone());
            }
            return newList;
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // reset list
            deleteAllObjFromMyShapes();

            clickedPoints.Clear();
            selectShapes.Clear();
            posMovingShape.Clear();

            // reset state
            state = NO_STATE;
            isMouseDown = false;
            isChangingShape = false;
            selectShape = -1;
            selectInsideShape = -1;
            selectOutlineShape = -1;

            // redraw
            clearBitmap();
            wrapDrawAllShapes(bitmap_primary);
        }

        private void buttonColor2_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            buttonShowColor.BackColor = colorDialog2.Color;
        }
    }
}