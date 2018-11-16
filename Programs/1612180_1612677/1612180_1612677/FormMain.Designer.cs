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
            this.exportToImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.buttonColor1 = new System.Windows.Forms.Button();
            this.numericUpDownPenWidth = new System.Windows.Forms.NumericUpDown();
            this.comboBoxDashStyle = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxBrushStyle = new System.Windows.Forms.ComboBox();
            this.buttonDrawChar = new System.Windows.Forms.Button();
            this.textBoxChar = new System.Windows.Forms.TextBox();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.buttonDrawPolygon = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
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
            this.pictureBoxPenWidth = new System.Windows.Forms.PictureBox();
            this.pictureBoxDashStyle = new System.Windows.Forms.PictureBox();
            this.buttonFontBold = new System.Windows.Forms.Button();
            this.buttonFontItalic = new System.Windows.Forms.Button();
            this.buttonFontUnder = new System.Windows.Forms.Button();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDashStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(733, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exportToImageToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exportToImageToolStripMenuItem
            // 
            this.exportToImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportToImageToolStripMenuItem.Image")));
            this.exportToImageToolStripMenuItem.Name = "exportToImageToolStripMenuItem";
            this.exportToImageToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exportToImageToolStripMenuItem.Text = "Export to Image";
            this.exportToImageToolStripMenuItem.Click += new System.EventHandler(this.exportToImageToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeToolStripMenuItem.Image")));
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
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
            this.editToolStripMenuItem.Size = new System.Drawing.Size(42, 21);
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
            this.buttonDrawRectangle.Location = new System.Drawing.Point(32, 30);
            this.buttonDrawRectangle.Name = "buttonDrawRectangle";
            this.buttonDrawRectangle.Size = new System.Drawing.Size(32, 32);
            this.buttonDrawRectangle.TabIndex = 1;
            this.buttonDrawRectangle.UseVisualStyleBackColor = true;
            this.buttonDrawRectangle.Click += new System.EventHandler(this.buttonDrawRec_Click);
            // 
            // buttonDrawLine
            // 
            this.buttonDrawLine.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawLine.Image")));
            this.buttonDrawLine.Location = new System.Drawing.Point(0, 30);
            this.buttonDrawLine.Name = "buttonDrawLine";
            this.buttonDrawLine.Size = new System.Drawing.Size(32, 32);
            this.buttonDrawLine.TabIndex = 2;
            this.buttonDrawLine.UseVisualStyleBackColor = true;
            this.buttonDrawLine.Click += new System.EventHandler(this.buttonDrawLine_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(12, 149);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(709, 375);
            this.pictureBoxMain.TabIndex = 3;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Image = ((System.Drawing.Image)(resources.GetObject("buttonSelect.Image")));
            this.buttonSelect.Location = new System.Drawing.Point(240, 30);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(32, 32);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonDrawEll
            // 
            this.buttonDrawEll.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawEll.Image")));
            this.buttonDrawEll.Location = new System.Drawing.Point(96, 30);
            this.buttonDrawEll.Name = "buttonDrawEll";
            this.buttonDrawEll.Size = new System.Drawing.Size(32, 32);
            this.buttonDrawEll.TabIndex = 6;
            this.buttonDrawEll.UseVisualStyleBackColor = true;
            this.buttonDrawEll.Click += new System.EventHandler(this.buttonDrawEll_Click);
            // 
            // buttonColor1
            // 
            this.buttonColor1.Location = new System.Drawing.Point(490, 30);
            this.buttonColor1.Name = "buttonColor1";
            this.buttonColor1.Size = new System.Drawing.Size(32, 32);
            this.buttonColor1.TabIndex = 8;
            this.buttonColor1.UseVisualStyleBackColor = true;
            this.buttonColor1.Click += new System.EventHandler(this.buttonColor1_Click);
            // 
            // numericUpDownPenWidth
            // 
            this.numericUpDownPenWidth.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownPenWidth.Location = new System.Drawing.Point(178, 66);
            this.numericUpDownPenWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPenWidth.Name = "numericUpDownPenWidth";
            this.numericUpDownPenWidth.Size = new System.Drawing.Size(58, 25);
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
            this.comboBoxDashStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDashStyle.FormattingEnabled = true;
            this.comboBoxDashStyle.Location = new System.Drawing.Point(280, 66);
            this.comboBoxDashStyle.Name = "comboBoxDashStyle";
            this.comboBoxDashStyle.Size = new System.Drawing.Size(114, 25);
            this.comboBoxDashStyle.TabIndex = 11;
            this.comboBoxDashStyle.SelectedIndexChanged += new System.EventHandler(this.reloadPenAttr);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(400, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Brush Style";
            // 
            // comboBoxBrushStyle
            // 
            this.comboBoxBrushStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrushStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBrushStyle.FormattingEnabled = true;
            this.comboBoxBrushStyle.Location = new System.Drawing.Point(493, 66);
            this.comboBoxBrushStyle.Name = "comboBoxBrushStyle";
            this.comboBoxBrushStyle.Size = new System.Drawing.Size(224, 25);
            this.comboBoxBrushStyle.TabIndex = 16;
            // 
            // buttonDrawChar
            // 
            this.buttonDrawChar.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawChar.Image")));
            this.buttonDrawChar.Location = new System.Drawing.Point(64, 94);
            this.buttonDrawChar.Name = "buttonDrawChar";
            this.buttonDrawChar.Size = new System.Drawing.Size(32, 32);
            this.buttonDrawChar.TabIndex = 17;
            this.buttonDrawChar.UseVisualStyleBackColor = true;
            this.buttonDrawChar.Click += new System.EventHandler(this.buttonDrawChar_Click);
            // 
            // textBoxChar
            // 
            this.textBoxChar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxChar.Location = new System.Drawing.Point(96, 98);
            this.textBoxChar.Name = "textBoxChar";
            this.textBoxChar.Size = new System.Drawing.Size(140, 25);
            this.textBoxChar.TabIndex = 19;
            this.textBoxChar.TextChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFont.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(242, 98);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(152, 25);
            this.comboBoxFont.TabIndex = 21;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFontSize.Location = new System.Drawing.Point(400, 98);
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(58, 25);
            this.numericUpDownFontSize.TabIndex = 23;
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // buttonDrawPolygon
            // 
            this.buttonDrawPolygon.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawPolygon.Image")));
            this.buttonDrawPolygon.Location = new System.Drawing.Point(64, 30);
            this.buttonDrawPolygon.Name = "buttonDrawPolygon";
            this.buttonDrawPolygon.Size = new System.Drawing.Size(32, 32);
            this.buttonDrawPolygon.TabIndex = 24;
            this.buttonDrawPolygon.UseVisualStyleBackColor = true;
            this.buttonDrawPolygon.Click += new System.EventHandler(this.buttonDrawPolygon_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Image = ((System.Drawing.Image)(resources.GetObject("buttonDel.Image")));
            this.buttonDel.Location = new System.Drawing.Point(272, 30);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(32, 32);
            this.buttonDel.TabIndex = 25;
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonDrawHbh
            // 
            this.buttonDrawHbh.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawHbh.Image")));
            this.buttonDrawHbh.Location = new System.Drawing.Point(0, 62);
            this.buttonDrawHbh.Name = "buttonDrawHbh";
            this.buttonDrawHbh.Size = new System.Drawing.Size(32, 32);
            this.buttonDrawHbh.TabIndex = 27;
            this.buttonDrawHbh.UseVisualStyleBackColor = true;
            this.buttonDrawHbh.Click += new System.EventHandler(this.buttonDrawHBH_Click);
            // 
            // buttonDrawBezier
            // 
            this.buttonDrawBezier.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawBezier.Image")));
            this.buttonDrawBezier.Location = new System.Drawing.Point(64, 62);
            this.buttonDrawBezier.Name = "buttonDrawBezier";
            this.buttonDrawBezier.Size = new System.Drawing.Size(32, 32);
            this.buttonDrawBezier.TabIndex = 28;
            this.buttonDrawBezier.UseVisualStyleBackColor = true;
            this.buttonDrawBezier.Click += new System.EventHandler(this.buttonDrawBezier_Click);
            // 
            // buttonDrawPara
            // 
            this.buttonDrawPara.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawPara.Image")));
            this.buttonDrawPara.Location = new System.Drawing.Point(96, 62);
            this.buttonDrawPara.Name = "buttonDrawPara";
            this.buttonDrawPara.Size = new System.Drawing.Size(32, 32);
            this.buttonDrawPara.TabIndex = 29;
            this.buttonDrawPara.UseVisualStyleBackColor = true;
            this.buttonDrawPara.Click += new System.EventHandler(this.buttonDrawPara_Click);
            // 
            // buttonFill
            // 
            this.buttonFill.Image = ((System.Drawing.Image)(resources.GetObject("buttonFill.Image")));
            this.buttonFill.Location = new System.Drawing.Point(368, 30);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(32, 32);
            this.buttonFill.TabIndex = 30;
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // comboBoxSelectType
            // 
            this.comboBoxSelectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectType.FormattingEnabled = true;
            this.comboBoxSelectType.Location = new System.Drawing.Point(150, 32);
            this.comboBoxSelectType.Name = "comboBoxSelectType";
            this.comboBoxSelectType.Size = new System.Drawing.Size(70, 25);
            this.comboBoxSelectType.TabIndex = 31;
            this.comboBoxSelectType.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectType_SelectedIndexChanged);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Image = ((System.Drawing.Image)(resources.GetObject("buttonUndo.Image")));
            this.buttonUndo.Location = new System.Drawing.Point(304, 30);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(32, 32);
            this.buttonUndo.TabIndex = 32;
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndo_Click);
            // 
            // buttonRedo
            // 
            this.buttonRedo.Image = ((System.Drawing.Image)(resources.GetObject("buttonRedo.Image")));
            this.buttonRedo.Location = new System.Drawing.Point(336, 30);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(32, 32);
            this.buttonRedo.TabIndex = 33;
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedo_Click);
            // 
            // buttonArcCircle
            // 
            this.buttonArcCircle.Image = ((System.Drawing.Image)(resources.GetObject("buttonArcCircle.Image")));
            this.buttonArcCircle.Location = new System.Drawing.Point(32, 62);
            this.buttonArcCircle.Name = "buttonArcCircle";
            this.buttonArcCircle.Size = new System.Drawing.Size(32, 32);
            this.buttonArcCircle.TabIndex = 34;
            this.buttonArcCircle.UseVisualStyleBackColor = true;
            this.buttonArcCircle.Click += new System.EventHandler(this.buttonDrawArc);
            // 
            // buttonColor2
            // 
            this.buttonColor2.Location = new System.Drawing.Point(610, 30);
            this.buttonColor2.Name = "buttonColor2";
            this.buttonColor2.Size = new System.Drawing.Size(32, 32);
            this.buttonColor2.TabIndex = 35;
            this.buttonColor2.UseVisualStyleBackColor = true;
            this.buttonColor2.Click += new System.EventHandler(this.buttonColor2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(420, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 17);
            this.label7.TabIndex = 36;
            this.label7.Text = "Color 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(540, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Color 2";
            // 
            // pictureBoxPenWidth
            // 
            this.pictureBoxPenWidth.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPenWidth.Image")));
            this.pictureBoxPenWidth.Location = new System.Drawing.Point(140, 62);
            this.pictureBoxPenWidth.Name = "pictureBoxPenWidth";
            this.pictureBoxPenWidth.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxPenWidth.TabIndex = 40;
            this.pictureBoxPenWidth.TabStop = false;
            // 
            // pictureBoxDashStyle
            // 
            this.pictureBoxDashStyle.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDashStyle.Image")));
            this.pictureBoxDashStyle.Location = new System.Drawing.Point(242, 62);
            this.pictureBoxDashStyle.Name = "pictureBoxDashStyle";
            this.pictureBoxDashStyle.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxDashStyle.TabIndex = 41;
            this.pictureBoxDashStyle.TabStop = false;
            // 
            // buttonFontBold
            // 
            this.buttonFontBold.Image = ((System.Drawing.Image)(resources.GetObject("buttonFontBold.Image")));
            this.buttonFontBold.Location = new System.Drawing.Point(464, 94);
            this.buttonFontBold.Name = "buttonFontBold";
            this.buttonFontBold.Size = new System.Drawing.Size(32, 32);
            this.buttonFontBold.TabIndex = 42;
            this.buttonFontBold.UseVisualStyleBackColor = true;
            this.buttonFontBold.Click += new System.EventHandler(this.buttonFontBold_Click);
            // 
            // buttonFontItalic
            // 
            this.buttonFontItalic.Image = ((System.Drawing.Image)(resources.GetObject("buttonFontItalic.Image")));
            this.buttonFontItalic.Location = new System.Drawing.Point(496, 94);
            this.buttonFontItalic.Name = "buttonFontItalic";
            this.buttonFontItalic.Size = new System.Drawing.Size(32, 32);
            this.buttonFontItalic.TabIndex = 43;
            this.buttonFontItalic.UseVisualStyleBackColor = true;
            this.buttonFontItalic.Click += new System.EventHandler(this.buttonFontItalic_Click);
            // 
            // buttonFontUnder
            // 
            this.buttonFontUnder.Image = ((System.Drawing.Image)(resources.GetObject("buttonFontUnder.Image")));
            this.buttonFontUnder.Location = new System.Drawing.Point(528, 94);
            this.buttonFontUnder.Name = "buttonFontUnder";
            this.buttonFontUnder.Size = new System.Drawing.Size(32, 32);
            this.buttonFontUnder.TabIndex = 44;
            this.buttonFontUnder.UseVisualStyleBackColor = true;
            this.buttonFontUnder.Click += new System.EventHandler(this.buttonFontUnder_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 536);
            this.Controls.Add(this.buttonFontUnder);
            this.Controls.Add(this.buttonFontItalic);
            this.Controls.Add(this.buttonFontBold);
            this.Controls.Add(this.pictureBoxDashStyle);
            this.Controls.Add(this.pictureBoxPenWidth);
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
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonDrawPolygon);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.comboBoxFont);
            this.Controls.Add(this.textBoxChar);
            this.Controls.Add(this.buttonDrawChar);
            this.Controls.Add(this.comboBoxBrushStyle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxDashStyle);
            this.Controls.Add(this.numericUpDownPenWidth);
            this.Controls.Add(this.buttonColor1);
            this.Controls.Add(this.buttonDrawEll);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.buttonDrawLine);
            this.Controls.Add(this.buttonDrawRectangle);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Paint2D";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPenWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDashStyle)).EndInit();
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
        private System.Windows.Forms.Button buttonColor1;
        private System.Windows.Forms.NumericUpDown numericUpDownPenWidth;
        private System.Windows.Forms.ComboBox comboBoxDashStyle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxBrushStyle;
        private System.Windows.Forms.Button buttonDrawChar;
        private System.Windows.Forms.TextBox textBoxChar;
        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.Button buttonDrawPolygon;
        private System.Windows.Forms.Button buttonDel;
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
        private System.Windows.Forms.PictureBox pictureBoxPenWidth;
        private System.Windows.Forms.PictureBox pictureBoxDashStyle;
        private System.Windows.Forms.Button buttonFontBold;
        private System.Windows.Forms.Button buttonFontItalic;
        private System.Windows.Forms.Button buttonFontUnder;
        private System.Windows.Forms.ToolStripMenuItem exportToImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

