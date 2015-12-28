using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFEditor
{
    /// <summary>
    /// Инкапсулирует работу с рисуками / файлами
    /// (создание, сохранение, открытие)
    /// </summary>
    class DrawingHelper
    {
        #region CONST

        //Словарь соотвествия расширений файлов форматам изображений

        private readonly Dictionary<string, ImageFormat> _extentionFormat = new Dictionary<string, ImageFormat>()
        {
            { ".bmp", ImageFormat.Bmp },
            { ".jpg", ImageFormat.Jpeg },
            { ".jpeg", ImageFormat.Jpeg },
            { ".png", ImageFormat.Png },
            { ".gif", ImageFormat.Gif }
        };

        private readonly string _openFilter = "All|*.*|Image *.bmp|*.bmp|Image *.jpg|*.jpg|Image *.png|*.png|Image *.gif|*.gif";
        private readonly string _saveFilter = "Image*.bmp|*.bmp|Image*.jpg|*.jpg|Image*.png|*.png|Image*.gif|*.gif";

        #endregion

        #region PROPERTIES

        public string FileName { get; set; }    //Имя файла с которым идёт работа

        #endregion

        #region METHODS

        public MyCanvas CreateDrawing()
        {
            MyCanvas result = null;
            frmNewDrawing newDrawingDiaog = new frmNewDrawing();
            if (newDrawingDiaog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }
            result = new MyCanvas(newDrawingDiaog.DrawingWidth, newDrawingDiaog.DrawingHeight);
            this.FileName = null;

            return result;
        }

        public MyCanvas OpenDrawing()
        {
            MyCanvas result;
            string tmpFileName;
            using (OpenFileDialog openDialog = new OpenFileDialog() { InitialDirectory = Application.StartupPath, Filter = this._openFilter })
            {
                if (openDialog.ShowDialog() != DialogResult.OK)
                {
                    return null;
                }
                tmpFileName = openDialog.FileName;
            }
            using (Image openedImage = Image.FromFile(tmpFileName))
            {
                result = new MyCanvas(openedImage);
            }
            this.FileName = tmpFileName;
            return result;
        }
        
        public bool SaveDrawing(MyCanvas canvas, bool isSaveAs)
        {
            if (isSaveAs == true || this.FileName == null)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog() { AddExtension = true, DefaultExt = ".bmp", InitialDirectory = Application.StartupPath, Filter = this._saveFilter })
                {
                    if (saveDialog.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                    this.FileName = saveDialog.FileName;
                }
            }
            using (Bitmap currentDrawing = canvas.Drawing)
            {
                string extention = Path.GetExtension(this.FileName);
                currentDrawing.Save(this.FileName, this._extentionFormat[extention]);
                return true;
            }
        }

        #endregion
    }
}