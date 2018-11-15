namespace _1612180_1612677
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendBackwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bringForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDrawRectangle = new System.Windows.Forms.Button();
            this.buttonDrawLine = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonDrawEll = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonShowColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPenWidth = new System.Windows.Forms.NumericUpDown();
            this.comboBoxDashStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBrushStyle = new System.Windows.Forms.ComboBox();
            this.buttonDrawChar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxChar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.buttonDrawPolygon = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUnselect = new System.Windows.Forms.Button();
            this.buttonDrawHbh = new System.Windows.Forms.Button();
            this.buttonDrawBezier = new System.Windows.Forms.Button();
            this.buttonDrawPara = new System.Windows.Forms.Button();
            this.buttonFill = new System.Windows.Forms.Button();
            this.comboBoxSelectType = new System.Windows.Forms.ComboBox();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.buttonArcCircle = new System.Windows.Forms.Button();
            this.buttonColor2 = new System.Windows.Forms.Button();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(836, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToBackToolStripMenuItem,
            this.bringToFrontToolStripMenuItem,
            this.sendBackwardToolStripMenuItem,
            this.bringForwardToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sendToBackToolStripMenuItem.Text = "Send to back";
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.bringToFrontToolStripMenuItem.Text = "Bring to front";
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // sendBackwardToolStripMenuItem
            // 
            this.sendBackwardToolStripMenuItem.Name = "sendBackwardToolStripMenuItem";
            this.sendBackwardToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.sendBackwardToolStripMenuItem.Text = "Send backward";
            this.sendBackwardToolStripMenuItem.Click += new System.EventHandler(this.sendBackwardToolStripMenuItem_Click);
            // 
            // bringForwardToolStripMenuItem
            // 
            this.bringForwardToolStripMenuItem.Name = "bringForwardToolStripMenuItem";
            this.bringForwardToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.bringForwardToolStripMenuItem.Text = "Bring forward";
            this.bringForwardToolStripMenuItem.Click += new System.EventHandler(this.bringForwardToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.clearAllToolStripMenuItem.Text = "Clear all";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // buttonDrawRectangle
            // 
            this.buttonDrawRectangle.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawRectangle.Image")));
            this.buttonDrawRectangle.Location = new System.Drawing.Point(42, 35);
            this.buttonDrawRectangle.Name = "buttonDrawRectangle";
            this.buttonDrawRectangle.Size = new System.Drawing.Size(36, 33);
            this.buttonDrawRectangle.TabIndex = 1;
            this.buttonDrawRectangle.UseVisualStyleBackColor = true;
            this.buttonDrawRectangle.Click += new System.EventHandler(this.buttonDrawRec_Click);
            // 
            // buttonDrawLine
            // 
            this.buttonDrawLine.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawLine.Image")));
            this.buttonDrawLine.Location = new System.Drawing.Point(0, 36);
            this.buttonDrawLine.Name = "buttonDrawLine";
            this.buttonDrawLine.Size = new System.Drawing.Size(36, 33);
            this.buttonDrawLine.TabIndex = 2;
            this.buttonDrawLine.UseVisualStyleBackColor = true;
            this.buttonDrawLine.Click += new System.EventHandler(this.buttonDrawLine_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 152);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(836, 280);
            this.pictureBoxMain.TabIndex = 3;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelect.Image")));
            this.buttonSelect.Location = new System.Drawing.Point(168, 35);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(36, 33);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonDrawEll
            // 
            this.buttonDrawEll.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawEll.Image")));
            this.buttonDrawEll.Location = new System.Drawing.Point(126, 36);
            this.buttonDrawEll.Name = "buttonDrawEll";
            this.buttonDrawEll.Size = new System.Drawing.Size(36, 33);
            this.buttonDrawEll.TabIndex = 6;
            this.buttonDrawEll.UseVisualStyleBackColor = true;
            this.buttonDrawEll.Click += new System.EventHandler(this.buttonDrawEll_Click);
            // 
            // buttonShowColor
            // 
            this.buttonShowColor.Location = new System.Drawing.Point(533, 33);
            this.buttonShowColor.Name = "buttonShowColor";
            this.buttonShowColor.Size = new System.Drawing.Size(36, 33);
            this.buttonShowColor.TabIndex = 8;
            this.buttonShowColor.UseVisualStyleBackColor = true;
            this.buttonShowColor.Click += new System.EventHandler(this.buttonShowColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pen Width";
            // 
            // numericUpDownPenWidth
            // 
            this.numericUpDownPenWidth.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPenWidth.Location = new System.Drawing.Point(254, 78);
            this.numericUpDownPenWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPenWidth.Name = "numericUpDownPenWidth";
            this.numericUpDownPenWidth.Size = new System.Drawing.Size(39, 26);
            this.numericUpDownPenWidth.TabIndex = 10;
            this.numericUpDownPenWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPenWidth.ValueChanged += new System.EventHandler(this.reloadPenAttr);
            // 
            // comboBoxDashStyle
            // 
            this.comboBoxDashStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDashStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDashStyle.FormattingEnabled = true;
            this.comboBoxDashStyle.Location = new System.Drawing.Point(388, 77);
            this.comboBoxDashStyle.Name = "comboBoxDashStyle";
            this.comboBoxDashStyle.Size = new System.Drawing.Size(114, 26);
            this.comboBoxDashStyle.TabIndex = 11;
            this.comboBoxDashStyle.SelectedIndexChanged += new System.EventHandler(this.reloadPenAttr);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(299, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dash Style";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(508, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Brush Style";
            // 
            // comboBoxBrushStyle
            // 
            this.comboBoxBrushStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrushStyle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBrushStyle.FormattingEnabled = true;
            this.comboBoxBrushStyle.Location = new System.Drawing.Point(600, 77);
            this.comboBoxBrushStyle.Name = "comboBoxBrushStyle";
            this.comboBoxBrushStyle.Size = new System.Drawing.Size(224, 26);
            this.comboBoxBrushStyle.TabIndex = 16;
            // 
            // buttonDrawChar
            // 
            this.buttonDrawChar.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawChar.Image")));
            this.buttonDrawChar.Location = new System.Drawing.Point(42, 113);
            this.buttonDrawChar.Name = "buttonDrawChar";
            this.buttonDrawChar.Size = new System.Drawing.Size(36, 33);
            this.buttonDrawChar.TabIndex = 17;
            this.buttonDrawChar.UseVisualStyleBackColor = true;
            this.buttonDrawChar.Click += new System.EventHandler(this.buttonDrawChar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Text";
            // 
            // textBoxChar
            // 
            this.textBoxChar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChar.Location = new System.Drawing.Point(125, 114);
            this.textBoxChar.Name = "textBoxChar";
            this.textBoxChar.Size = new System.Drawing.Size(123, 26);
            this.textBoxChar.TabIndex = 19;
            this.textBoxChar.TextChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(254, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Font";
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFont.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(299, 116);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(133, 26);
            this.comboBoxFont.TabIndex = 21;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(438, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "Font Size";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFontSize.Location = new System.Drawing.Point(518, 115);
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(46, 26);
            this.numericUpDownFontSize.TabIndex = 23;
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // buttonDrawPolygon
            // 
            this.buttonDrawPolygon.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawPolygon.Image")));
            this.buttonDrawPolygon.Location = new System.Drawing.Point(84, 35);
            this.buttonDrawPolygon.Name = "buttonDrawPolygon";
            this.buttonDrawPolygon.Size = new System.Drawing.Size(36, 33);
            this.buttonDrawPolygon.TabIndex = 24;
            this.buttonDrawPolygon.UseVisualStyleBackColor = true;
            this.buttonDrawPolygon.Click += new System.EventHandler(this.buttonDrawPolygon_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Image = ((System.Drawing.Image)(resources.GetObject("buttonDel.Image")));
            this.buttonDel.Location = new System.Drawing.Point(342, 33);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(36, 33);
            this.buttonDel.TabIndex = 25;
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUnselect
            // 
            this.buttonUnselect.Image = ((System.Drawing.Image)(resources.GetObject("buttonUnselect.Image")));
            this.buttonUnselect.Location = new System.Drawing.Point(210, 35);
            this.buttonUnselect.Name = "buttonUnselect";
            this.buttonUnselect.Size = new System.Drawing.Size(36, 33);
            this.buttonUnselect.TabIndex = 26;
            this.buttonUnselect.UseVisualStyleBackColor = true;
            this.buttonUnselect.Click += new System.EventHandler(this.buttonUnselect_Click);
            // 
            // buttonDrawHbh
            // 
            this.buttonDrawHbh.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawHbh.Image")));
            this.buttonDrawHbh.Location = new System.Drawing.Point(0, 75);
            this.buttonDrawHbh.Name = "buttonDrawHbh";
            this.buttonDrawHbh.Size = new System.Drawing.Size(36, 33);
            this.buttonDrawHbh.TabIndex = 27;
            this.buttonDrawHbh.UseVisualStyleBackColor = true;
            this.buttonDrawHbh.Click += new System.EventHandler(this.buttonDrawHBH_Click);
            // 
            // buttonDrawBezier
            // 
            this.buttonDrawBezier.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawBezier.Image")));
            this.buttonDrawBezier.Location = new System.Drawing.Point(84, 75);
            this.buttonDrawBezier.Name = "buttonDrawBezier";
            this.buttonDrawBezier.Size = new System.Drawing.Size(36, 33);
            this.buttonDrawBezier.TabIndex = 28;
            this.buttonDrawBezier.UseVisualStyleBackColor = true;
            this.buttonDrawBezier.Click += new System.EventHandler(this.buttonDrawBezier_Click);
            // 
            // buttonDrawPara
            // 
            this.buttonDrawPara.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawPara.Image")));
            this.buttonDrawPara.Location = new System.Drawing.Point(126, 75);
            this.buttonDrawPara.Name = "buttonDrawPara";
            this.buttonDrawPara.Size = new System.Drawing.Size(36, 33);
            this.buttonDrawPara.TabIndex = 29;
            this.buttonDrawPara.UseVisualStyleBackColor = true;
            this.buttonDrawPara.Click += new System.EventHandler(this.buttonDrawPara_Click);
            // 
            // buttonFill
            // 
            this.buttonFill.Image = ((System.Drawing.Image)(resources.GetObject("buttonFill.Image")));
            this.buttonFill.Location = new System.Drawing.Point(683, 32);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(42, 33);
            this.buttonFill.TabIndex = 30;
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // comboBoxSelectType
            // 
            this.comboBoxSelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectType.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectType.FormattingEnabled = true;
            this.comboBoxSelectType.Location = new System.Drawing.Point(252, 36);
            this.comboBoxSelectType.Name = "comboBoxSelectType";
            this.comboBoxSelectType.Size = new System.Drawing.Size(84, 26);
            this.comboBoxSelectType.TabIndex = 31;
            this.comboBoxSelectType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectType_SelectedIndexChanged);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Image = ((System.Drawing.Image)(resources.GetObject("buttonUndo.Image")));
            this.buttonUndo.Location = new System.Drawing.Point(384, 35);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(36, 33);
            this.buttonUndo.TabIndex = 32;
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonRedo
            // 
            this.buttonRedo.Image = ((System.Drawing.Image)(resources.GetObject("buttonRedo.Image")));
            this.buttonRedo.Location = new System.Drawing.Point(426, 35);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(36, 33);
            this.buttonRedo.TabIndex = 33;
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // buttonArcCircle
            // 
            this.buttonArcCircle.Image = ((System.Drawing.Image)(resources.GetObject("buttonArcCircle.Image")));
            this.buttonArcCircle.Location = new System.Drawing.Point(42, 74);
            this.buttonArcCircle.Name = "buttonArcCircle";
            this.buttonArcCircle.Size = new System.Drawing.Size(36, 33);
            this.buttonArcCircle.TabIndex = 34;
            this.buttonArcCircle.UseVisualStyleBackColor = true;
            this.buttonArcCircle.Click += new System.EventHandler(this.buttonDrawArc);
            // 
            // buttonColor2
            // 
            this.buttonColor2.Location = new System.Drawing.Point(640, 31);
            this.buttonColor2.Name = "buttonColor2";
            this.buttonColor2.Size = new System.Drawing.Size(37, 35);
            this.buttonColor2.TabIndex = 35;
            this.buttonColor2.UseVisualStyleBackColor = true;
            this.buttonColor2.Click += new System.EventHandler(this.buttonColor2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(468, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 18);
            this.label7.TabIndex = 36;
            this.label7.Text = "Color 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(575, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 18);
            this.label8.TabIndex = 37;
            this.label8.Text = "Color 2";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 432);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonColor2);
            this.Controls.Add(this.buttonArcCircle);
            this.Controls.Add(this.buttonRedo);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.comboBoxSelectType);
            this.Controls.Add(this.buttonFill);
            this.Controls.Add(this.buttonDrawPara);
            this.Controls.Add(this.buttonDrawBezier);
            this.Controls.Add(this.buttonDrawHbh);
            this.Controls.Add(this.buttonUnselect);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonDrawPolygon);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxFont);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxChar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDrawChar);
            this.Controls.Add(this.comboBoxBrushStyle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDashStyle);
            this.Controls.Add(this.numericUpDownPenWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonShowColor);
            this.Controls.Add(this.buttonDrawEll);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.buttonDrawLine);
            this.Controls.Add(this.buttonDrawRectangle);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Paint2D";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.Button buttonDrawRectangle;
        private System.Windows.Forms.Button buttonDrawLine;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonDrawEll;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonShowColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPenWidth;
        private System.Windows.Forms.ComboBox comboBoxDashStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBrushStyle;
        private System.Windows.Forms.Button buttonDrawChar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxChar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Button buttonDrawPolygon;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUnselect;
        private System.Windows.Forms.Button buttonDrawHbh;
        private System.Windows.Forms.Button buttonDrawBezier;
        private System.Windows.Forms.Button buttonDrawPara;
        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendBackwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bringForwardToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxSelectType;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.Button buttonArcCircle;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.Button buttonColor2;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

