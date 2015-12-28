using System;
using System.Collections.Generic;
using System.Drawing;

namespace PFEditor
{
    //Pen - управляются холстом
    class PFPen : IDrawable
    {
        public List<Point> Points { get; set; }

        public Pen Pen { get; set; }

        public PFPen(List<Point> pointsList)
        {
            if (pointsList == null)
            {
                throw new ArgumentNullException("pointsList", "Can't create PFPen. pointsList is null");
            }
            this.Points = pointsList;
        }

        public void Draw(Graphics graphics)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics", "PFPen can't draw. Graphics is null");
            }
            if (this.Pen == null)
            {
                throw new ShapeException("Can't draw PFPen. Pen is null");
            }
            if (this.Points == null)
            {
                throw new ShapeException("Can't draw PFPen. Points is null");
            }

            //Точки свободного рисования соединим прямыми

            for (int i = 0; i < this.Points.Count - 1; i++)
            {
                Point p1 = this.Points[i];
                Point p2 = this.Points[i + 1];
                graphics.DrawLine(this.Pen, p1, p2);
            }
        }
    }
}