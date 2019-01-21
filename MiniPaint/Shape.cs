using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPaint {
    abstract public class Shape {
        abstract public void draw(Graphics graphics, Pen pen, int drawPosX, int drawPosY, int releasePosX, int releasePosY, PictureBox pictureBox1, Bitmap bmp);
    }

    class ShapeLine : Shape {
        public override void draw(Graphics graphics, Pen pen, int drawPosX, int drawPosY, int releasePosX, int releasePosY, PictureBox pictureBox1, Bitmap bmp) {
            //Draw
            graphics.DrawLine(pen, new Point(drawPosX, drawPosY), new Point(releasePosX, releasePosY));
            pictureBox1.Image = bmp;
        }
    }

    class ShapeRectangle : Shape {
        public override void draw(Graphics graphics, Pen pen, int drawPosX, int drawPosY, int releasePosX, int releasePosY, PictureBox pictureBox1, Bitmap bmp) {
            //Calculate Rectangle Size
            int width = releasePosX - drawPosX;
            int height = releasePosY - drawPosY;

            //Check if rectangle is drawn in opposite direction
            if (width < 0) {
                width = drawPosX - releasePosX;
            }
            if (height < 0) {
                height = drawPosY - releasePosY;
            }

            //Draw
            graphics.DrawRectangle(pen, new Rectangle(new Point(drawPosX, drawPosY), new Size(width, height)));
            pictureBox1.Image = bmp;
        }
    }

    class ShapeEllipse : Shape {
        public override void draw(Graphics graphics, Pen pen, int drawPosX, int drawPosY, int releasePosX, int releasePosY, PictureBox pictureBox1, Bitmap bmp) {
            //Calculate Rectangle Size
            int width = releasePosX - drawPosX;
            int height = releasePosY - drawPosY;

            //Check if rectangle is drawn in opposite direction
            if (width < 0) {
                width = drawPosX - releasePosX;
            }
            if (height < 0) {
                height = drawPosY - releasePosY;
            }

            //Draw
            graphics.DrawEllipse(pen, new RectangleF(new Point(drawPosX, drawPosY), new Size(width, height)));
            pictureBox1.Image = bmp;
        }
    }
}
