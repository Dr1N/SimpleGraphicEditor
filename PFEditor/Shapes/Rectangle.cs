using System;
using System.Drawing;

namespace PFEditor
{
    //Pen, Brush - управляются холстом
    class PFRectangle : Shape, IDrawable
    {
        public Pen Pen { get; set; }
        public Brush Brush { get; set; }

        public PFRectangle(Point first, Point last) : base(first, last) { }

        public void Draw(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics", "PFRectangle can't draw. Graphics is null");
            }
            if (this.Pen == null || this.Brush == null)
            {
                throw new ShapeException("Can't draw PFRectangle. Pen or Brush is null");
            }

            Rectangle rect = new Rectangle(this.FirstPoint.X, this.FirstPoint.Y, this.LastPoint.X - this.FirstPoint.X, this.LastPoint.Y - this.FirstPoint.Y);
            graphics.FillRectangle(this.Brush, rect);
            graphics.DrawRectangle(this.Pen, rect);
        }
    }
}