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
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDrawRectangle = new System.Windows.Forms.Button();
            this.buttonDrawLine = new System.Windows.Forms.Button();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonDrawEll = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.buttonChooseColor = new System.Windows.Forms.Button();
            this.buttonShowColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownPenWidth = new System.Windows.Forms.NumericUpDown();
            this.comboBoxDashStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPenWidth)).BeginInit();
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
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.pictureBoxMain.Location = new System.Drawing.Point(120, 98);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(656, 313);
            this.pictureBoxMain.TabIndex = 3;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseClick);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(182, 36);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAll.TabIndex = 4;
            this.buttonClearAll.Text = "Clear All";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(276, 36);
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
            // buttonChooseColor
            // 
            this.buttonChooseColor.Location = new System.Drawing.Point(182, 69);
            this.buttonChooseColor.Name = "buttonChooseColor";
            this.buttonChooseColor.Size = new System.Drawing.Size(82, 23);
            this.buttonChooseColor.TabIndex = 7;
            this.buttonChooseColor.Text = "Choose Color";
            this.buttonChooseColor.UseVisualStyleBackColor = true;
            this.buttonChooseColor.Click += new System.EventHandler(this.buttonChooseColor_Click);
            // 
            // buttonShowColor
            // 
            this.buttonShowColor.Enabled = false;
            this.buttonShowColor.Location = new System.Drawing.Point(276, 69);
            this.buttonShowColor.Name = "buttonShowColor";
            this.buttonShowColor.Size = new System.Drawing.Size(75, 23);
            this.buttonShowColor.TabIndex = 8;
            this.buttonShowColor.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Pen Width";
            // 
            // numericUpDownPenWidth
            // 
            this.numericUpDownPenWidth.Location = new System.Drawing.Point(429, 69);
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
            // 
            // comboBoxDashStyle
            // 
            this.comboBoxDashStyle.Enabled = false;
            this.comboBoxDashStyle.FormattingEnabled = true;
            this.comboBoxDashStyle.Location = new System.Drawing.Point(576, 66);
            this.comboBoxDashStyle.Name = "comboBoxDashStyle";
            this.comboBoxDashStyle.Size = new System.Drawing.Size(91, 21);
            this.comboBoxDashStyle.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dash Style";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 432);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDashStyle);
            this.Controls.Add(this.numericUpDownPenWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonShowColor);
            this.Controls.Add(this.buttonChooseColor);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonDrawRectangle;
        private System.Windows.Forms.Button buttonDrawLine;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonDrawEll;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button buttonChooseColor;
        private System.Windows.Forms.Button buttonShowColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPenWidth;
        private System.Windows.Forms.ComboBox comboBoxDashStyle;
        private System.Windows.Forms.Label label2;
    }
}

