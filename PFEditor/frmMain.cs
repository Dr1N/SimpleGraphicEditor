using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PFEditor
{
    public partial class frmMain : Form
    {
        #region FIELDS

        private List<Component> _drawingToolsButtons;       //Список кнопок выбора инструмента
        private MyCanvas _myCanvas;                         //Холст
        private Color _foreColor = Color.Black;             //Цвет контуров
        private Color _backColor = Color.White;             //Цвет фона
        private bool _isDitry;                              //Признак изменений в рисунке (to-do возможно перенести в класс холста)
        private DrawingHelper _drawingHelper;               //Работа с файлами
        
        #endregion

        #region EVENTS
        
        //События(делегаты) созданы свои (в отличие от холста) для разнообразия ;)

        private event ToolChanged DrawingToolChanged;         //Инициируется при смене инструмента рисования
        private event ColorChanged DrawingForeColorChanged;   //Иницииируется при смене цвета контура
        private event ColorChanged DrawingBackColorChanged;   //Инициируется при смена фона замкнутых фигур

        #endregion

        #region CTOR
        public frmMain()
        {
            InitializeComponent();

            //Добавление и инициализация холста

            this._myCanvas = new MyCanvas(Program.DEFAULT_DRAWING_WIDTH, Program.DEFAULT_DRAWING_HEIGHT);
            this.InitCanvas();

            this._drawingHelper = new DrawingHelper();

            //Список кнопок - инструменты рисования

            this._drawingToolsButtons = new List<Component>()
            {
                this.tsbtnPen,
                this.tsbtnLine,
                this.tsbtnRectange,
                this.tsbtnEllipse
            };

            //Свяжем кнопки с перечисленим инструментов (to-do альтернатива - словарь)

            this.tsbtnPen.Tag = DrawingTools.PEN;
            this.tsbtnLine.Tag = DrawingTools.LINE;
            this.tsbtnRectange.Tag = DrawingTools.RECTANGLE;
            this.tsbtnEllipse.Tag = DrawingTools.ELLIPSE;

            //Установим начальные цвета элементов управления выбора цвета

            this.tsbtnForeColor.BackColor = this._foreColor;
            this.tsbtnBackColor.BackColor = this._backColor;

            //Текущий инструмент по-умолчанию

            this.tsbtnPen.Checked = true;
        }

        #endregion

        #region OVERRIDED METHODS

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = this.AskUserOfLosingChanges();
            base.OnClosing(e);
        }

        #endregion

        #region EVENTS HANDLERS (CONTROLS)

        /// <summary>
        /// Устанавливает нажатое состояние инструмента рисования
        /// </summary>
        private void drawingTools_Click(object sender, EventArgs e)
        {
            ToolStripButton currentButton = sender as ToolStripButton;
            if (currentButton != null)
            {
                foreach (ToolStripButton button in this._drawingToolsButtons)
                {
                    button.Checked = (currentButton == button);
                }
            }
        }

        /// <summary>
        /// Смена инструмента рисования, инициализация события
        /// </summary>
        private void drawingTools_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton currentButton = sender as ToolStripButton;
            if (currentButton == null)
            {
                return;
            }
            if (currentButton.Checked == true)
            {
                //Инициирование события смены инструмента (получает холст)

                if (this.DrawingToolChanged != null)
                {
                    ToolChangeEventArgs te = new ToolChangeEventArgs((DrawingTools)currentButton.Tag);
                    this.DrawingToolChanged(currentButton, te);
                }
                
                //Установим в статусбаре название инструмента

                this.tslblTool.Text = String.Format("Tool: {0}", (DrawingTools)currentButton.Tag);
            }
        }

        /// <summary>
        /// Смена цветов рисования, инициализация событий смены
        /// </summary>
        private void tsbtnColorButtons_Click(object sender, EventArgs e)
        {
            ToolStripButton currentButton = sender as ToolStripButton;
            if (currentButton == null)
            {
                return;
            }

            //Установка цвета

            using (ColorDialog colorDialog = new ColorDialog())
            { 
                colorDialog.Color = (currentButton == this.tsbtnForeColor) ? this._foreColor : this._backColor;
                if (colorDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                currentButton.BackColor = colorDialog.Color;
                this._foreColor = (currentButton == this.tsbtnForeColor) ? colorDialog.Color : this._foreColor;
                this._backColor = (currentButton == this.tsbtnBackColor) ? colorDialog.Color : this._backColor;

                //Инициируем событие смены цвета

                ColorChangeEventArgs ce = new ColorChangeEventArgs(colorDialog.Color);

                if (currentButton == this.tsbtnForeColor && this.DrawingForeColorChanged != null)
                {
                    this.DrawingForeColorChanged(currentButton, ce);
                }
                if (currentButton == this.tsbtnBackColor && this.DrawingBackColorChanged != null)
                {
                    this.DrawingBackColorChanged(currentButton, ce);
                }
            }
        }

        private void createControl_Click(object sender, EventArgs e)
        {
            if (this.AskUserOfLosingChanges() == true)
            {
                return;
            }
            try
            { 
                MyCanvas canvas = this._drawingHelper.CreateDrawing();
                if (canvas == null)
                {
                    return;
                }
                this.ReplaceCanvas(canvas);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error creating drawing\n{0}", ex.Message);
                MessageBox.Show("Can't create drawing", Program.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveControl_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem currentMenuItem = sender as ToolStripMenuItem;
            try
            { 
                bool isSaved = this._drawingHelper.SaveDrawing(this._myCanvas, currentMenuItem != null && currentMenuItem == this.mnSaveAs);
                this._isDitry = !isSaved;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error saving file\n{0}", ex.Message);
                MessageBox.Show("Can't save drawing", Program.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void openControl_Click(object sender, EventArgs e)
        {
            if (this.AskUserOfLosingChanges() == true)
            {
                return;
            }
            try
            {
                MyCanvas canvas = this._drawingHelper.OpenDrawing();
                if (canvas == null)
                {
                    return;
                }
                this.ReplaceCanvas(canvas);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error opening file\n{0}", ex.Message);
                MessageBox.Show("Can't open file", Program.APP_NAME, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void mnInverse_Click(object sender, EventArgs e)
        {
            this._myCanvas.InverseDrawing();
        }
        
        private void mnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnAbout_Click(object sender, EventArgs e)
        {
            throw new Exception("TEST");
            new frmAbout().ShowDialog();
        }

        #endregion

        #region EVENTS HANDLERS (MYCANVAS)
        
        /// <summary>
        /// Устанавливает флаг изменения рисунка
        /// </summary>
        private void OnDrawingChanged(object sender, EventArgs e)
        {
            this._isDitry = true;
        }

        /// <summary>
        /// Отображает координаты мыши на холсте в статусбаре
        /// </summary>
        private void OnMousePositionChanged(object sender, EventArgs e)
        {
            if (e is MouseEventArgs)
            { 
                this.tslblMouseCoord.Text = String.Format("Position: {0}", ((MouseEventArgs)e).Location);
            }
        }

        /// <summary>
        /// Обновление прогрессбара при инвертировании изображения. 
        /// Выполняется в потоке инвертирования
        /// </summary>
        private void OnInverseProgressChanged(object sender, EventArgs e)
        {
            InverseProgressChangedEventArgs eArgs = e as InverseProgressChangedEventArgs;
            if (eArgs != null)
            { 
                this.Invoke(new Action(() => this.sbpbProgress.Value = 100 * eArgs.Progress / (eArgs.Max - eArgs.Min)));
            }
        }

        /// <summary>
        /// Отключаем элементы управления, работающие с холстом
        /// для предотвращения конкуретного доступа потоков к ресурсам.
        /// Выполняется в потоке инвертирования.
        /// </summary>
        private void OnBeginInverse(object sender, EventArgs e)
        {
            //Тоолбар

            this.Invoke(new Action(() =>  this.tsbtnNew.Enabled = false));
            this.Invoke(new Action(() => this.tsbtnOpen.Enabled = false));
            this.Invoke(new Action(() => this.tsbtnSave.Enabled = false));

            //Меню

            this.Invoke(new Action(() => this.mnNew.Enabled = false));
            this.Invoke(new Action(() => this.mnOpen.Enabled = false));
            this.Invoke(new Action(() => this.mnSave.Enabled = false));
            this.Invoke(new Action(() => this.mnSaveAs.Enabled = false));
            this.Invoke(new Action(() => this.mnInverse.Enabled = false));

            //Прогресс бар

            this.Invoke(new Action(() => this.sbpbProgress.Visible = true));
        }

        /// <summary>
        /// Включаем элементы управления после завершения инвертирования.
        /// Выполняется в потоке инвертирования изображения
        /// </summary>
        private void OnEndInverse(object sender, EventArgs e)
        {
            //Тоолбар

            this.Invoke(new Action(() => this.tsbtnNew.Enabled = true));
            this.Invoke(new Action(() => this.tsbtnOpen.Enabled = true));
            this.Invoke(new Action(() => this.tsbtnSave.Enabled = true));

            //Меню

            this.Invoke(new Action(() => this.mnNew.Enabled = true));
            this.Invoke(new Action(() => this.mnOpen.Enabled = true));
            this.Invoke(new Action(() => this.mnSave.Enabled = true));
            this.Invoke(new Action(() => this.mnSaveAs.Enabled = true));
            this.Invoke(new Action(() => this.mnInverse.Enabled = true));

            //Прогресс бар

            this.Invoke(new Action(() => this.sbpbProgress.Visible = false));
        }

        #endregion

        #region HELPERS

        /// <summary>
        /// Добавляет к форме и инициализирует объект холст
        /// Подписывается на события, устанавливает первоначальные значения
        /// </summary>
        private void InitCanvas()
        {
            //Подписываем его на события формы (изменения настроек рисования)

            this.DrawingToolChanged += this._myCanvas.OnToolChanged;
            this.DrawingForeColorChanged += this._myCanvas.OnForeColorChanged;
            this.DrawingBackColorChanged += this._myCanvas.OnBackColorChanged;

            //Подписываемся на события холста

            this._myCanvas.DrawingChanged += this.OnDrawingChanged;
            this._myCanvas.MousePositionCoordChanged += this.OnMousePositionChanged;
            this._myCanvas.InverseProressChanged += this.OnInverseProgressChanged;
            this._myCanvas.BeginInverse += this.OnBeginInverse;
            this._myCanvas.EndInverse += this.OnEndInverse;

            //Установим интрумент по умолчанию 
           
            this.DrawingToolChanged(this, new ToolChangeEventArgs(DrawingTools.PEN));
           
            //Установим цвет контура объектов

            this.DrawingForeColorChanged(this, new ColorChangeEventArgs(this._foreColor));

            //Установим цвет фона объектов
            
            this.DrawingBackColorChanged(this, new ColorChangeEventArgs(this._backColor));

            //Добавляем в холст в редактор

            this.pnBase.Controls.Add(this._myCanvas);
        }

        /// <summary>
        /// Удалить холст из формы редактора, отписавшись от событий
        /// </summary>
        private void RemoveCanvas()
        {
            //Отписываемся от событий

            this.DrawingToolChanged -= this._myCanvas.OnToolChanged;
            this.DrawingForeColorChanged -= this._myCanvas.OnForeColorChanged;
            this.DrawingBackColorChanged -= this._myCanvas.OnBackColorChanged;

            this._myCanvas.DrawingChanged -= this.OnDrawingChanged;
            this._myCanvas.MousePositionCoordChanged -= this.OnMousePositionChanged;
            this._myCanvas.InverseProressChanged -= this.OnInverseProgressChanged;
            this._myCanvas.BeginInverse -= this.OnBeginInverse;
            this._myCanvas.EndInverse -= this.OnEndInverse;

            this.pnBase.Controls.Clear();
            this._myCanvas = null;
        }

        /// <summary>
        /// Спросить пользователя сохранить ли рисунок пред закрытием (удалением)
        /// </summary>
        /// <returns>true - пользователь отказался сохранить изменения, false - дать возможность сохраниться</returns>
        private bool AskUserOfLosingChanges()
        {
            if (this._isDitry == true)
            {
                return MessageBox.Show("Unsaved changes are lost", Program.APP_NAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel;
            }
            return false;
        }

        /// <summary>
        /// Заменят текущий холст
        /// </summary>
        /// <param name="canvas">Холст на который надо заменить текущий</param>
        private void ReplaceCanvas(MyCanvas canvas)
        {
            this.RemoveCanvas();
            this._myCanvas = canvas;
            this.InitCanvas();
            this._isDitry = false;
        }

        #endregion
    }
}