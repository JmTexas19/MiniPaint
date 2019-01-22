using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        bool firstRun = true;

        //Shapes
        enum MyShape {line, rectangle, ellipse};
        MyShape currentShape = MyShape.line;

        //Objects
        Bitmap bmp;
        Graphics graphics;
        Color drawColor;

        public Paint() {
            InitializeComponent();

            //Create Bitmap for drawing
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp.SetResolution(1920, 1080)
;           graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            pictureBox1.Image = bmp;

            //Create Default Color
            drawColor = Color.Black;
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
            drawChosenShape();
        }

        //Draw Shape Selected
        private void drawChosenShape() {
            Shape shape = null;

            if (currentShape == MyShape.line) {
                shape = new ShapeLine();
            }

            if (currentShape == MyShape.rectangle) {
                shape = new ShapeRectangle();
            }

            if (currentShape == MyShape.ellipse) {
                shape = new ShapeEllipse();
            }

            //Call draw method
            drawColoredShape(drawColor, shape);
        }

        //Draw Shape
        public void drawColoredShape(Color color, Shape shape) {
            shape.draw(graphics, color, new Point(drawPosX, drawPosY), new Point(releasePosX, releasePosY));
            pictureBox1.Image = bmp;
        }

        //Buttons
        private void button1_Click(object sender, EventArgs e) {
            currentShape = MyShape.line;
        }

        private void button2_Click(object sender, EventArgs e) {
            currentShape = MyShape.rectangle;
        }

        private void button3_Click(object sender, EventArgs e) {
            currentShape = MyShape.ellipse;
        }

        //Trackbars
        private void trackBar1_Scroll(object sender, EventArgs e) {
            drawColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            new Pen(drawColor).Color = drawColor;
        }

        private void trackBar2_Scroll(object sender, EventArgs e) {
            drawColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            new Pen(drawColor).Color = drawColor;
        }

        private void trackBar3_Scroll(object sender, EventArgs e) {
            drawColor = Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            new Pen(drawColor).Color = drawColor;
        }

        //Resize Canvas
        private void Paint_Resize(object sender, EventArgs e) {
            //Check if firstrun
            if (firstRun == false) { 
                //Create new bitmap and draw old one on top
                Bitmap oldBmp = bmp;
                bmp = new Bitmap(bmp, pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(bmp);

                //Improve Graphics
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                //Draw
                graphics.DrawImage(oldBmp, 0, 0, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;  
            } else {
                firstRun = false;
            }
        }
    }
}
