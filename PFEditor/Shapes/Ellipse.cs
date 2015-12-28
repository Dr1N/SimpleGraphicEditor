using System;
using System.Drawing;

namespace PFEditor
{
    //Pen, Brush - управляются холстом
    class PFEllipse : Shape, IDrawable
    {
        public Pen Pen { get; set; }

        public Brush Brush { get; set; }

        public PFEllipse(Point first, Point last) : base(first, last) { }

        public void Draw(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics", "PFEllipse can't draw. Graphics is null");
            }
            if (this.Pen == null || this.Brush == null)
            {
                throw new ShapeException("Can't draw PFEllipse. Pen or Brush is null");
            }

            Rectangle rect = new Rectangle(this.FirstPoint.X, this.FirstPoint.Y, this.LastPoint.X - this.FirstPoint.X, this.LastPoint.Y - this.FirstPoint.Y);
            graphics.FillEllipse(this.Brush, rect);
            graphics.DrawEllipse(this.Pen, rect);
        }
    }
}