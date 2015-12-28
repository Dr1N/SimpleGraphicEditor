using System;
using System.Drawing;

/*
* В данном файле объявляются типы и классы для работы с событиями окна редактора
* и передачи параметров холсту (MyCanvas) и обратно форме
*/

namespace PFEditor
{
    //Делегаты и аргументы для событий окна редактора

    public delegate void ToolChanged(object sender, ToolChangeEventArgs e);
    public delegate void ColorChanged(object sender, ColorChangeEventArgs e);

    /// <summary>
    /// Аргумент события смены инструмента рисования
    /// </summary>
    public class ToolChangeEventArgs : EventArgs
    {
        public DrawingTools Tool { get; private set; }
        public ToolChangeEventArgs(DrawingTools tool)
        {
            this.Tool = tool;
        }
    }

    /// <summary>
    /// Аргумент события смены цветов рисования
    /// </summary>
    public class ColorChangeEventArgs : EventArgs
    {
        public Color Color { get; private set; }
        public ColorChangeEventArgs(Color foreColor)
        {
            this.Color = foreColor;
        }
    }

    /// <summary>
    /// Аргумент события прогресса инвертирования
    /// </summary>
    public class InverseProgressChangedEventArgs : EventArgs
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Progress { get; set; }
    }
}