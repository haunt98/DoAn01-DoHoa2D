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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDrawRectangle = new System.Windows.Forms.Button();
            this.buttonDrawLine = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonDrawEll = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
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
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(788, 24);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // buttonDrawRectangle
            // 
            this.buttonDrawRectangle.Location = new System.Drawing.Point(12, 65);
            this.buttonDrawRectangle.Name = "buttonDrawRectangle";
            this.buttonDrawRectangle.Size = new System.Drawing.Size(96, 23);
            this.buttonDrawRectangle.TabIndex = 1;
            this.buttonDrawRectangle.Text = "Draw Rectangle";
            this.buttonDrawRectangle.UseVisualStyleBackColor = true;
            this.buttonDrawRectangle.Click += new System.EventHandler(this.buttonDrawRec_Click);
            // 
            // buttonDrawLine
            // 
            this.buttonDrawLine.Location = new System.Drawing.Point(12, 36);
            this.buttonDrawLine.Name = "buttonDrawLine";
            this.buttonDrawLine.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawLine.TabIndex = 2;
            this.buttonDrawLine.Text = "Draw Line";
            this.buttonDrawLine.UseVisualStyleBackColor = true;
            this.buttonDrawLine.Click += new System.EventHandler(this.buttonDrawLine_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(136, 129);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(640, 282);
            this.pictureBoxMain.TabIndex = 3;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(120, 36);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAll.TabIndex = 4;
            this.buttonClearAll.Text = "Clear All";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(214, 36);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonDrawEll
            // 
            this.buttonDrawEll.Location = new System.Drawing.Point(12, 98);
            this.buttonDrawEll.Name = "buttonDrawEll";
            this.buttonDrawEll.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawEll.TabIndex = 6;
            this.buttonDrawEll.Text = "Draw Ellipse";
            this.buttonDrawEll.UseVisualStyleBackColor = true;
            this.buttonDrawEll.Click += new System.EventHandler(this.buttonDrawEll_Click);
            // 
            // buttonShowColor
            // 
            this.buttonShowColor.Location = new System.Drawing.Point(493, 36);
            this.buttonShowColor.Name = "buttonShowColor";
            this.buttonShowColor.Size = new System.Drawing.Size(75, 23);
            this.buttonShowColor.TabIndex = 8;
            this.buttonShowColor.UseVisualStyleBackColor = true;
            this.buttonShowColor.Click += new System.EventHandler(this.buttonShowColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pen Width";
            // 
            // numericUpDownPenWidth
            // 
            this.numericUpDownPenWidth.Location = new System.Drawing.Point(232, 71);
            this.numericUpDownPenWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPenWidth.Name = "numericUpDownPenWidth";
            this.numericUpDownPenWidth.Size = new System.Drawing.Size(62, 20);
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
            this.comboBoxDashStyle.FormattingEnabled = true;
            this.comboBoxDashStyle.Location = new System.Drawing.Point(379, 72);
            this.comboBoxDashStyle.Name = "comboBoxDashStyle";
            this.comboBoxDashStyle.Size = new System.Drawing.Size(91, 21);
            this.comboBoxDashStyle.TabIndex = 11;
            this.comboBoxDashStyle.SelectedIndexChanged += new System.EventHandler(this.reloadPenAttr);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dash Style";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Brush Style";
            // 
            // comboBoxBrushStyle
            // 
            this.comboBoxBrushStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBrushStyle.FormattingEnabled = true;
            this.comboBoxBrushStyle.Location = new System.Drawing.Point(655, 38);
            this.comboBoxBrushStyle.Name = "comboBoxBrushStyle";
            this.comboBoxBrushStyle.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBrushStyle.TabIndex = 16;
            // 
            // buttonDrawChar
            // 
            this.buttonDrawChar.Location = new System.Drawing.Point(13, 139);
            this.buttonDrawChar.Name = "buttonDrawChar";
            this.buttonDrawChar.Size = new System.Drawing.Size(95, 23);
            this.buttonDrawChar.TabIndex = 17;
            this.buttonDrawChar.Text = "Draw Character";
            this.buttonDrawChar.UseVisualStyleBackColor = true;
            this.buttonDrawChar.Click += new System.EventHandler(this.buttonDrawChar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Text";
            // 
            // textBoxChar
            // 
            this.textBoxChar.Location = new System.Drawing.Point(214, 103);
            this.textBoxChar.Name = "textBoxChar";
            this.textBoxChar.Size = new System.Drawing.Size(100, 20);
            this.textBoxChar.TabIndex = 19;
            this.textBoxChar.TextChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Font";
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(394, 99);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFont.TabIndex = 21;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(533, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Font Size";
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Location = new System.Drawing.Point(602, 103);
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(46, 20);
            this.numericUpDownFontSize.TabIndex = 23;
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.reloadFontAttr);
            // 
            // buttonDrawPolygon
            // 
            this.buttonDrawPolygon.Location = new System.Drawing.Point(13, 169);
            this.buttonDrawPolygon.Name = "buttonDrawPolygon";
            this.buttonDrawPolygon.Size = new System.Drawing.Size(95, 23);
            this.buttonDrawPolygon.TabIndex = 24;
            this.buttonDrawPolygon.Text = "Draw Polygon";
            this.buttonDrawPolygon.UseVisualStyleBackColor = true;
            this.buttonDrawPolygon.Click += new System.EventHandler(this.buttonDrawPolygon_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(379, 36);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(92, 23);
            this.buttonDel.TabIndex = 25;
            this.buttonDel.Text = "Delete Selected";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUnselect
            // 
            this.buttonUnselect.Location = new System.Drawing.Point(295, 36);
            this.buttonUnselect.Name = "buttonUnselect";
            this.buttonUnselect.Size = new System.Drawing.Size(75, 23);
            this.buttonUnselect.TabIndex = 26;
            this.buttonUnselect.Text = "Unselect";
            this.buttonUnselect.UseVisualStyleBackColor = true;
            this.buttonUnselect.Click += new System.EventHandler(this.buttonUnselect_Click);
            // 
            // buttonDrawHbh
            // 
            this.buttonDrawHbh.Location = new System.Drawing.Point(13, 214);
            this.buttonDrawHbh.Name = "buttonDrawHbh";
            this.buttonDrawHbh.Size = new System.Drawing.Size(117, 23);
            this.buttonDrawHbh.TabIndex = 27;
            this.buttonDrawHbh.Text = "Draw Hinh binh hanh";
            this.buttonDrawHbh.UseVisualStyleBackColor = true;
            this.buttonDrawHbh.Click += new System.EventHandler(this.buttonDrawHBH_Click);
            // 
            // buttonDrawBezier
            // 
            this.buttonDrawBezier.Location = new System.Drawing.Point(13, 257);
            this.buttonDrawBezier.Name = "buttonDrawBezier";
            this.buttonDrawBezier.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawBezier.TabIndex = 28;
            this.buttonDrawBezier.Text = "Draw Bezier";
            this.buttonDrawBezier.UseVisualStyleBackColor = true;
            this.buttonDrawBezier.Click += new System.EventHandler(this.buttonDrawBezier_Click);
            // 
            // buttonDrawPara
            // 
            this.buttonDrawPara.Location = new System.Drawing.Point(13, 311);
            this.buttonDrawPara.Name = "buttonDrawPara";
            this.buttonDrawPara.Size = new System.Drawing.Size(75, 23);
            this.buttonDrawPara.TabIndex = 29;
            this.buttonDrawPara.Text = "Parabol";
            this.buttonDrawPara.UseVisualStyleBackColor = true;
            this.buttonDrawPara.Click += new System.EventHandler(this.buttonDrawPara_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 432);
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
            this.Controls.Add(this.buttonClearAll);
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
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonDrawEll;
        private System.Windows.Forms.ColorDialog colorDialog;
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
    }
}

