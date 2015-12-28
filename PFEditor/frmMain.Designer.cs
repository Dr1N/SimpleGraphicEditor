namespace PFEditor
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnInverse = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.sbMain = new System.Windows.Forms.StatusStrip();
            this.tslblTool = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblMouseCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbpbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPen = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLine = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRectange = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEllipse = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnForeColor = new System.Windows.Forms.ToolStripButton();
            this.tsbtnBackColor = new System.Windows.Forms.ToolStripButton();
            this.pnBase = new System.Windows.Forms.Panel();
            this.msMain.SuspendLayout();
            this.sbMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(784, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnNew,
            this.mnOpen,
            this.mnSave,
            this.mnSaveAs,
            this.toolStripSeparator1,
            this.mnExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // mnNew
            // 
            this.mnNew.Name = "mnNew";
            this.mnNew.Size = new System.Drawing.Size(152, 22);
            this.mnNew.Text = "&New...";
            this.mnNew.Click += new System.EventHandler(this.createControl_Click);
            // 
            // mnOpen
            // 
            this.mnOpen.Name = "mnOpen";
            this.mnOpen.Size = new System.Drawing.Size(152, 22);
            this.mnOpen.Text = "&Open...";
            this.mnOpen.Click += new System.EventHandler(this.openControl_Click);
            // 
            // mnSave
            // 
            this.mnSave.Name = "mnSave";
            this.mnSave.Size = new System.Drawing.Size(152, 22);
            this.mnSave.Text = "&Save";
            this.mnSave.Click += new System.EventHandler(this.saveControl_Click);
            // 
            // mnSaveAs
            // 
            this.mnSaveAs.Name = "mnSaveAs";
            this.mnSaveAs.Size = new System.Drawing.Size(152, 22);
            this.mnSaveAs.Text = "Save &As...";
            this.mnSaveAs.Click += new System.EventHandler(this.saveControl_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(152, 22);
            this.mnExit.Text = "E&xit";
            this.mnExit.Click += new System.EventHandler(this.mnExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnInverse});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // mnInverse
            // 
            this.mnInverse.Name = "mnInverse";
            this.mnInverse.Size = new System.Drawing.Size(152, 22);
            this.mnInverse.Text = "&Inverse";
            this.mnInverse.Click += new System.EventHandler(this.mnInverse_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAbout});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // mnAbout
            // 
            this.mnAbout.Name = "mnAbout";
            this.mnAbout.Size = new System.Drawing.Size(152, 22);
            this.mnAbout.Text = "&About";
            this.mnAbout.Click += new System.EventHandler(this.mnAbout_Click);
            // 
            // sbMain
            // 
            this.sbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblTool,
            this.tslblMouseCoord,
            this.sbpbProgress});
            this.sbMain.Location = new System.Drawing.Point(0, 539);
            this.sbMain.Name = "sbMain";
            this.sbMain.Size = new System.Drawing.Size(784, 22);
            this.sbMain.TabIndex = 1;
            this.sbMain.Text = "statusStrip1";
            // 
            // tslblTool
            // 
            this.tslblTool.AutoSize = false;
            this.tslblTool.Name = "tslblTool";
            this.tslblTool.Size = new System.Drawing.Size(100, 17);
            // 
            // tslblMouseCoord
            // 
            this.tslblMouseCoord.AutoSize = false;
            this.tslblMouseCoord.Name = "tslblMouseCoord";
            this.tslblMouseCoord.Size = new System.Drawing.Size(150, 17);
            // 
            // sbpbProgress
            // 
            this.sbpbProgress.Margin = new System.Windows.Forms.Padding(10, 3, 1, 3);
            this.sbpbProgress.Name = "sbpbProgress";
            this.sbpbProgress.Size = new System.Drawing.Size(150, 16);
            this.sbpbProgress.Step = 1;
            this.sbpbProgress.Visible = false;
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnNew,
            this.tsbtnOpen,
            this.tsbtnSave,
            this.toolStripSeparator2,
            this.tsbtnPen,
            this.tsbtnLine,
            this.tsbtnRectange,
            this.tsbtnEllipse,
            this.toolStripSeparator3,
            this.tsbtnForeColor,
            this.tsbtnBackColor});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(784, 25);
            this.tsMain.TabIndex = 2;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbtnNew
            // 
            this.tsbtnNew.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnNew.Image = global::PFEditor.Properties.Resources.create;
            this.tsbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnNew.Name = "tsbtnNew";
            this.tsbtnNew.Size = new System.Drawing.Size(23, 22);
            this.tsbtnNew.Text = "New";
            this.tsbtnNew.ToolTipText = "New Drawing";
            this.tsbtnNew.Click += new System.EventHandler(this.createControl_Click);
            // 
            // tsbtnOpen
            // 
            this.tsbtnOpen.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpen.Image = global::PFEditor.Properties.Resources.open;
            this.tsbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpen.Name = "tsbtnOpen";
            this.tsbtnOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpen.Text = "Open";
            this.tsbtnOpen.ToolTipText = "Open Image";
            this.tsbtnOpen.Click += new System.EventHandler(this.openControl_Click);
            // 
            // tsbtnSave
            // 
            this.tsbtnSave.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSave.Image = global::PFEditor.Properties.Resources.save;
            this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSave.Name = "tsbtnSave";
            this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsbtnSave.Text = "Save";
            this.tsbtnSave.ToolTipText = "Save Image";
            this.tsbtnSave.Click += new System.EventHandler(this.saveControl_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnPen
            // 
            this.tsbtnPen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPen.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPen.Image")));
            this.tsbtnPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPen.Name = "tsbtnPen";
            this.tsbtnPen.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPen.Text = "Pen";
            this.tsbtnPen.ToolTipText = "Pen";
            this.tsbtnPen.CheckedChanged += new System.EventHandler(this.drawingTools_CheckedChanged);
            this.tsbtnPen.Click += new System.EventHandler(this.drawingTools_Click);
            // 
            // tsbtnLine
            // 
            this.tsbtnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnLine.Image = global::PFEditor.Properties.Resources.line;
            this.tsbtnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLine.Name = "tsbtnLine";
            this.tsbtnLine.Size = new System.Drawing.Size(23, 22);
            this.tsbtnLine.Text = "Line";
            this.tsbtnLine.ToolTipText = "Line";
            this.tsbtnLine.CheckedChanged += new System.EventHandler(this.drawingTools_CheckedChanged);
            this.tsbtnLine.Click += new System.EventHandler(this.drawingTools_Click);
            // 
            // tsbtnRectange
            // 
            this.tsbtnRectange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnRectange.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRectange.Image")));
            this.tsbtnRectange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRectange.Name = "tsbtnRectange";
            this.tsbtnRectange.Size = new System.Drawing.Size(23, 22);
            this.tsbtnRectange.Text = "Rectangle";
            this.tsbtnRectange.ToolTipText = "Rectangle";
            this.tsbtnRectange.CheckedChanged += new System.EventHandler(this.drawingTools_CheckedChanged);
            this.tsbtnRectange.Click += new System.EventHandler(this.drawingTools_Click);
            // 
            // tsbtnEllipse
            // 
            this.tsbtnEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnEllipse.Image = global::PFEditor.Properties.Resources.ellipse;
            this.tsbtnEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEllipse.Name = "tsbtnEllipse";
            this.tsbtnEllipse.Size = new System.Drawing.Size(23, 22);
            this.tsbtnEllipse.Text = "Ellipse";
            this.tsbtnEllipse.ToolTipText = "Ellipse";
            this.tsbtnEllipse.CheckedChanged += new System.EventHandler(this.drawingTools_CheckedChanged);
            this.tsbtnEllipse.Click += new System.EventHandler(this.drawingTools_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnForeColor
            // 
            this.tsbtnForeColor.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsbtnForeColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnForeColor.Image")));
            this.tsbtnForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnForeColor.Margin = new System.Windows.Forms.Padding(5);
            this.tsbtnForeColor.Name = "tsbtnForeColor";
            this.tsbtnForeColor.Padding = new System.Windows.Forms.Padding(5);
            this.tsbtnForeColor.Size = new System.Drawing.Size(23, 15);
            this.tsbtnForeColor.Text = "Foregroung color";
            this.tsbtnForeColor.Click += new System.EventHandler(this.tsbtnColorButtons_Click);
            // 
            // tsbtnBackColor
            // 
            this.tsbtnBackColor.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsbtnBackColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnBackColor.Image")));
            this.tsbtnBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnBackColor.Margin = new System.Windows.Forms.Padding(5);
            this.tsbtnBackColor.Name = "tsbtnBackColor";
            this.tsbtnBackColor.Padding = new System.Windows.Forms.Padding(5);
            this.tsbtnBackColor.Size = new System.Drawing.Size(23, 15);
            this.tsbtnBackColor.Text = "Backgroung color";
            this.tsbtnBackColor.Click += new System.EventHandler(this.tsbtnColorButtons_Click);
            // 
            // pnBase
            // 
            this.pnBase.AutoScroll = true;
            this.pnBase.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBase.Location = new System.Drawing.Point(0, 49);
            this.pnBase.Margin = new System.Windows.Forms.Padding(5);
            this.pnBase.Name = "pnBase";
            this.pnBase.Size = new System.Drawing.Size(784, 490);
            this.pnBase.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnBase);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.sbMain);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "frmMain";
            this.Text = "PFEditor";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.sbMain.ResumeLayout(false);
            this.sbMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnOpen;
        private System.Windows.Forms.ToolStripMenuItem mnSave;
        private System.Windows.Forms.ToolStripMenuItem mnSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnAbout;
        private System.Windows.Forms.StatusStrip sbMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbtnNew;
        private System.Windows.Forms.ToolStripButton tsbtnOpen;
        private System.Windows.Forms.ToolStripButton tsbtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnPen;
        private System.Windows.Forms.ToolStripButton tsbtnLine;
        private System.Windows.Forms.ToolStripButton tsbtnRectange;
        private System.Windows.Forms.ToolStripButton tsbtnEllipse;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnBackColor;
        private System.Windows.Forms.ToolStripButton tsbtnForeColor;
        private System.Windows.Forms.ToolStripMenuItem mnNew;
        private System.Windows.Forms.Panel pnBase;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnInverse;
        private System.Windows.Forms.ToolStripStatusLabel tslblTool;
        private System.Windows.Forms.ToolStripStatusLabel tslblMouseCoord;
        private System.Windows.Forms.ToolStripProgressBar sbpbProgress;
    }
}

