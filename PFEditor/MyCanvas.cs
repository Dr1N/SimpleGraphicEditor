using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Threading;

namespace PFEditor
{
    /// <summary>
    ///  Класс - холст.
    ///  Обработка рисования. Сохранение / обновление рисунка.
    ///  Изображение обрабатывается и хранится как растровое
    /// </summary>
    class MyCanvas : Panel
    {
        #region FIELDS

        private BufferedGraphics _drawingBufferedGraphics;  //Графический буфер (предотвращение мерцания при скользящем рисовании)
        private BufferedGraphics _imageBufferedGraphics;    //Графический буфер для хранения изображения
        private bool _isDrawing;                            //Признак рисования
        private Point _clickPoint;                          //Точка начала рисования (координаты клика по холсту)
        private Pen _currentPen;                            //Перо, которым происходит рисование (контур фигур)
        private Brush _currentBrush;                        //Кисть, которым происходит рисование (фон фигур)
        private IDrawable _currentShape;                    //Текущая рисуемая фигура
        private DrawingTools _currentTool;                  //Текущий инструмент рисования
        private List<Point> _movementPoints;                //Коллекция точек, через которое было перемещение курсора (для карандаша)

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Возвращает текущий рисунок в виде объекта Bitmap
        /// </summary>
        public Bitmap Drawing
        {
            get
            {
                try
                { 
                    Bitmap currentDrawing = null;
                    using (Graphics canvasGraphics = this.CreateGraphics())
                    {
                        currentDrawing = new Bitmap(this.Width, this.Height, canvasGraphics);
                    }
                    using (Graphics bitmapGraphics = Graphics.FromImage(currentDrawing))
                    {
                        this._imageBufferedGraphics.Render(bitmapGraphics);
                    }
                    return currentDrawing;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error creating Bitmap\n{0}", ex.Message);
                    throw new MyCanvasException("Can't create Bitmap");
                }
            }
        }

        /// <summary>
        /// Возвращает подготовленный графикс графического буфера для скользящего рисования
        /// </summary>
        private Graphics DrawingGraphics
        {
            get
            {
                Graphics graphicsFromBufferedGraphics = this._drawingBufferedGraphics.Graphics;
                graphicsFromBufferedGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphicsFromBufferedGraphics.Clear(Color.White);
                this._imageBufferedGraphics.Render(graphicsFromBufferedGraphics);
                return graphicsFromBufferedGraphics;
            }
        }

        #endregion

        #region EVENTS

        //Используем стандартные делегаты, учитывая ковариантность/контрвариатность

        public event EventHandler DrawingChanged;                       //Инициируется при изменении рисунка
        public event EventHandler MousePositionCoordChanged;            //Инициируется при изменении координат курсора на холсте
        public event EventHandler InverseProressChanged;                //Инициируется во время операции инвертирования
        public event EventHandler BeginInverse;                         //Инициируется в наачале операции инвертирования
        public event EventHandler EndInverse;                           //Инициируется в конце операции инвертирования

        #endregion

        #region CTORS

        private MyCanvas()
        {
            //Коллекции

            this._movementPoints = new List<Point>();

            //Параметры контрола

            this.DoubleBuffered = true;
            this.BackColor = Color.White;
            this.Location = new Point(5, 5);
            this.Cursor = Cursors.Cross;
        }

        public MyCanvas(int width, int height) : this()
        {
            if (Program.MIN_DRAWING_SIZE > width || width >= Program.MAX_DRAWING_SIZE 
                || Program.MIN_DRAWING_SIZE > height || height >= Program.MAX_DRAWING_SIZE)
            {
                string message = String.Format("Incorrect canvas size. Size range: {0} ... {1}",
                    Program.MIN_DRAWING_SIZE, Program.MAX_DRAWING_SIZE);
                throw new MyCanvasException(message);
            }
            this.Width = width;
            this.Height = height;

            this.InitBuffering();
        }

        public MyCanvas(Image image) : this(image.Width, image.Height)
        {
            if (image == null)
            {
                throw new MyCanvasException("Can't create canvas. Image is null");
            }

            //Кешируем изображение в BufferedGraphics

            this._imageBufferedGraphics.Graphics.DrawImage(image, new Point(0, 0));
        }

        #endregion

        #region OVERRIDES METHOD (DRAWING, DISPOSING)

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }

            //Начало рисования

            this._isDrawing = true;
            this._clickPoint = e.Location;

            //Создание текущего рисуемого объекта
            //В классах объектов создаются копии инстументов, которыми они рисовались

            switch (this._currentTool)
            {
                case DrawingTools.PEN:
                    this._movementPoints.Add(e.Location);
                    this._currentShape = new PFPen(this._movementPoints) { Pen = this._currentPen };
                    break;
                case DrawingTools.LINE:
                    this._currentShape = new PFLine(Point.Empty, Point.Empty) { Pen = this._currentPen };
                    break;
                case DrawingTools.RECTANGLE:
                    this._currentShape = new PFRectangle(Point.Empty, Point.Empty) { Pen = this._currentPen, Brush = this._currentBrush };
                    break;
                case DrawingTools.ELLIPSE:
                    this._currentShape = new PFEllipse(Point.Empty, Point.Empty) { Pen = this._currentPen, Brush = this._currentBrush };
                    break;
                default:
                    throw new MyCanvasException("Unknown drawing tool");
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //Инициируем событие изменения положения курсора на холсте

            if (this.MousePositionCoordChanged != null)
            {
                this.MousePositionCoordChanged(this, e);
            }

            if (this._isDrawing == false)
            {
                return;
            }

            Graphics drawingGraphics = this.DrawingGraphics;
            
            //Текущая фигура (Скользящее рисование)

            switch (this._currentTool)
            {
                case DrawingTools.PEN:
                    this._movementPoints.Add(e.Location);
                    break;
                case DrawingTools.LINE:
                    ((Shape)this._currentShape).FirstPoint = this._clickPoint;
                    ((Shape)this._currentShape).LastPoint = e.Location;
                    break;
                case DrawingTools.RECTANGLE:
                case DrawingTools.ELLIPSE:

                    //Нормализация координат фигуры

                    Point startPoint = new Point(this._clickPoint.X < e.X ? this._clickPoint.X : e.X, this._clickPoint.Y < e.Y ? this._clickPoint.Y : e.Y);
                    Point endPoint = new Point(this._clickPoint.X >= e.X ? this._clickPoint.X : e.X, this._clickPoint.Y >= e.Y ? this._clickPoint.Y : e.Y);
                    ((Shape)this._currentShape).FirstPoint = startPoint;
                    ((Shape)this._currentShape).LastPoint = endPoint;
                    break;
                default:
                    throw new MyCanvasException("Unknown drawing tool");
            }
            this._currentShape.Draw(drawingGraphics);

            //Рендер буфера на холст

            using (Graphics panelGraphics = this.CreateGraphics())
            { 
                this._drawingBufferedGraphics.Render(panelGraphics);
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this._isDrawing == false)
            {
                return;
            }

            //Рендеринг фигуры в буфер

            this._currentShape.Draw(this._imageBufferedGraphics.Graphics);
            this._currentShape = null;
            this._isDrawing = false;

            if(this._currentTool == DrawingTools.PEN)
            { 
                this._movementPoints.Clear();
            }

            //Инициируем событие изменения рисунка

            if (this.DrawingChanged != null)
            {
                this.DrawingChanged(this, new EventArgs());
            }

            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Восстановление рисунка при перересовке холста

            this._imageBufferedGraphics.Render(e.Graphics);
            base.OnPaint(e);
        }

        protected override void Dispose(bool disposing)
        {
            //Освободим ресурсы (на всякий случай ;), поможем GC и OS)

            if (this._drawingBufferedGraphics != null)
            { 
                this._drawingBufferedGraphics.Dispose();
                this._drawingBufferedGraphics = null;
            }
            if (this._imageBufferedGraphics != null)
            {
                this._imageBufferedGraphics.Dispose();
                this._imageBufferedGraphics = null;
            }
            if (this._currentBrush != null)
            { 
                this._currentBrush.Dispose();
                this._currentBrush = null;
            }
            if (this._currentPen != null)
            { 
                this._currentPen.Dispose();
                this._currentPen = null;
            }
            this._currentShape = null;
            this._movementPoints.Clear();
            this._movementPoints = null;

            base.Dispose(disposing);
        }

        #endregion

        #region EVENT HANDLERS (MAINFORM)

        public void OnToolChanged(object sender, ToolChangeEventArgs e)
        {
            this._currentTool = e.Tool;
        }

        public void OnForeColorChanged(object sender, ColorChangeEventArgs e)
        {
            if (this._currentPen != null)
            { 
                this._currentPen.Dispose();
            }
            this._currentPen = new Pen(e.Color, Program.DEFAULT_PEN_WIDTH);
        }

        public void OnBackColorChanged(object sender, ColorChangeEventArgs e)
        {
            if (this._currentBrush != null)
            { 
               this._currentBrush.Dispose();
            }
            this._currentBrush = new SolidBrush(e.Color);
        }

        #endregion

        #region HELPERS

        /// <summary>
        /// Создаёт и запускает поток инвертирования изображения
        /// </summary>
        public void InverseDrawing()
        {
            new Thread(this.Inverse) { IsBackground = true }.Start();
        }

        /// <summary>
        /// Инвертирует текущее изображение
        /// Выполняется в рабочем потоке
        /// </summary>
        private void Inverse()
        {
            //Инициируем события начала операции инвертирования

            if (this.BeginInverse != null)
            {
                this.BeginInverse(this, new EventArgs());
            }

            try
            {
                //Отключим возможность рисования во время операции

                this.Invoke(new Action(() => this.Enabled = false));

                //Получаем и инвертируем текущее изображение в виде Bitmap
                //(неэфективный медленный метод, для продолжительности операции)

                using (Bitmap bitmap = this.Drawing)
                {
                    this.InverseBitmap(bitmap);

                    //Кешируем полученное изображение в буфере изображения

                    this._imageBufferedGraphics.Graphics.DrawImage(bitmap, new Point(0, 0));
                }

                //Перерисуем холст

                this.Invalidate();

                //Инициализация события изменения рисунка

                if (this.DrawingChanged != null)
                {
                    this.DrawingChanged(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during inversing image\n{0}", ex.Message);
            }
            finally
            {
                //Включаем возможность рисования

                this.Invoke(new Action(() => this.Enabled = true));

                // Инициируем события окончаниия операции инвертирования

                if (this.EndInverse != null)
                {
                    this.EndInverse(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Инвертирует битмам
        /// </summary>
        /// <param name="bitmap">Инвертируемый битмап</param>
        private void InverseBitmap(Bitmap bitmap)
        {
            for (int row = 0; row < bitmap.Height; row++)
            {
                for (int col = 0; col < bitmap.Width; col++)
                {
                    Color currentClr = bitmap.GetPixel(col, row);
                    Color inverseClr = Color.FromArgb(255, 255 - currentClr.R, 255 - currentClr.G, 255 - currentClr.B);
                    bitmap.SetPixel(col, row, inverseClr);

                    //Инициируем событие изменения прогресса инвертирования

                    if (this.InverseProressChanged != null)
                    {
                        InverseProgressChangedEventArgs e = new InverseProgressChangedEventArgs()
                        {
                            Min = 0,
                            Max = bitmap.Width * bitmap.Height,
                            Progress = row * bitmap.Width + col
                        };
                        this.InverseProressChanged(this, e);
                    }
                }
            }
        }

        /// <summary>
        /// Создаёт и инициализирует буферы для графики
        /// Буфер для изображения и буфер для скользящего рисования
        /// </summary>
        private void InitBuffering()
        {
            using (Graphics canvasGraphics = this.CreateGraphics())
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                this._drawingBufferedGraphics = BufferedGraphicsManager.Current.Allocate(canvasGraphics, rect);
                this._imageBufferedGraphics = BufferedGraphicsManager.Current.Allocate(canvasGraphics, rect);
                this._imageBufferedGraphics.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this._imageBufferedGraphics.Graphics.Clear(Color.White);
            }
        }
      
        #endregion
    }
}