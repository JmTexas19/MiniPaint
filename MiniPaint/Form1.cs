using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPaint {
    public partial class Paint : Form {
        //Variables
        int drawPosX;
        int drawPosY;
        int releasePosX;
        int releasePosY;

        //Shapes
        enum MyShape {line, rectangle, ellipse};
        MyShape currentShape = MyShape.line;

        //Objects
        Bitmap bmp;
        Graphics graphics;
        Color drawColor;
        Pen pen;

        public Paint() {
            InitializeComponent();

            //Create Bitmap for drawing
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            pictureBox1.Image = bmp;
            drawColor = Color.Black;

            //Create Pen
            pen = new Pen(drawColor);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            //Record Mouse Position
            drawPosX = e.X;
            drawPosY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            //Record Mouse Release Position
            releasePosX = e.X;
            releasePosY = e.Y;

            //Draw Shape
            drawShape();
        }

        //Draw Shape Selected
        private void drawShape() {
            if (currentShape == MyShape.line) {
                drawLine();
            }

            if (currentShape == MyShape.rectangle) {
                drawRectangle();
            }

            if (currentShape == MyShape.ellipse) {
                drawEllipse();
            }
        }

        //Line
        public void drawLine() {
            //Draw
            graphics.DrawLine(pen, new Point(drawPosX, drawPosY), new Point(releasePosX, releasePosY));
            pictureBox1.Image = bmp;
        }

        //Rectangle
        public void drawRectangle() {
            //Calculate Rectangle Size
            int width = releasePosX - drawPosX;
            int height = releasePosY - drawPosY;

            //Check if rectangle is drawn in opposite direction
            if(width < 0) {
                width = drawPosX - releasePosX;
            }
            if(height < 0) {
                height = drawPosY - releasePosY;
            }

            //Draw
            graphics.DrawRectangle(pen, new Rectangle(new Point(drawPosX, drawPosY), new Size(width, height)));
            pictureBox1.Image = bmp;
        }

        //Ellipse
        public void drawEllipse() {
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

        private void button1_Click(object sender, EventArgs e) {
            currentShape = MyShape.line;
        }

        private void button2_Click(object sender, EventArgs e) {
            currentShape = MyShape.rectangle;
        }

        private void button3_Click(object sender, EventArgs e) {
            currentShape = MyShape.ellipse;
        }
    }
}
