using System.Drawing;

namespace PFEditor
{
    /// <summary>
    /// Базовый класс для фигур, которые описываются двумя точками
    /// (Rectangle, Ellipse, Line ... )
    /// </summary>
    abstract class Shape
    {
        public Point FirstPoint { get; set; }

        public Point LastPoint { get; set; }

        public Shape(Point first, Point last)
        {
            this.FirstPoint = first;
            this.LastPoint = last;
        }
    }
}