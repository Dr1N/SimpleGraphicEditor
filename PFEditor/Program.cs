using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PFEditor
{
    static class Program
    {
        //Константы уровня приложения

        public static readonly string APP_NAME = "PFEditor";
        public static readonly int MAX_DRAWING_SIZE = 10000;
        public static readonly int MIN_DRAWING_SIZE = 100;
        public static readonly int DEFAULT_DRAWING_WIDTH = 600;
        public static readonly int DEFAULT_DRAWING_HEIGHT = 400;
        public static readonly float DEFAULT_PEN_WIDTH = 3.0f;
        public static readonly Color DEFAULT_FORE_COLOR = Color.Black;
        public static readonly Color DEFAULT_BACK_COLOR = Color.White;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        /// <summary>
        /// Обработчик неперехваченных исключений в потоках
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Debug.WriteLine("Critial Error\n{0}\n{1}", e.Exception.Message, e.Exception.StackTrace);
            MessageBox.Show("Criteal Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}