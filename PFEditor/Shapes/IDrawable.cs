using System.Drawing;

namespace PFEditor
{
    /// <summary>
    /// Интерфейс для объектов, которые должны уметь себя выводить в Graphics
    /// </summary>
    interface IDrawable
    {
        void Draw(Graphics graphics);
    }
}