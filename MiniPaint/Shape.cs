using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPaint {
    abstract public class Shape {
        abstract public void draw(Graphics graphics, Color color, Point point1, Point point2);
    }

    class ShapeLine : Shape {
        public override void draw(Graphics graphics, Color color, Point point1, Point point2) {
            //Draw
            graphics.DrawLine(new Pen(color), point1, point2);
        }
    }

    class ShapeRectangle : Shape {
        public override void draw(Graphics graphics, Color color, Point point1, Point point2) {
            //Calculate Rectangle Size
            int width = point2.X - point1.X;
            int height = point2.Y - point1.Y;

            //Check if rectangle is drawn in opposite direction
            if (width < 0) {
                width = point1.X - point2.X;
            }
            if (height < 0) {
                height = point1.Y -point2.Y;
            }

            //Draw
            graphics.DrawRectangle(new Pen(color), new Rectangle(point1, new Size(width, height)));
        }
    }

    class ShapeEllipse : Shape {
        public override void draw(Graphics graphics, Color color, Point point1, Point point2) {
            //Calculate Ellipse Size
            int width = point2.X - point1.X;
            int height = point2.Y - point1.Y;

            //Check if rectangle is drawn in opposite direction
            if (width < 0) {
                width = point1.X - point2.X;
            }
            if (height < 0) {
                height = point1.Y - point2.Y;
            }

            //Draw
            graphics.DrawEllipse(new Pen(color), new RectangleF(point1, new Size(width, height)));
        }
    }
}
