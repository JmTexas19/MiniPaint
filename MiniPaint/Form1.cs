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
        Bitmap bmpBG, bmpFG;
        Graphics graphics;
        Color drawColor;

        public Paint() {
            InitializeComponent();

            //Create Bitmap for drawing
            bmpBG = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmpFG = new Bitmap(pictureBox1.Width, pictureBox1.Height);
;           graphics = Graphics.FromImage(bmpFG);
            graphics.Clear(Color.White);
            graphics = Graphics.FromImage(bmpBG);
            graphics.Clear(Color.White);
            pictureBox1.Image = bmpBG;

            //Create Default Color
            drawColor = Color.Black;
        }

        //Mouse Move
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                releasePosX = e.X;
                releasePosY = e.Y;

                //Draw Foreground Shape
                graphics = Graphics.FromImage(bmpFG);
                graphics.DrawImage(bmpBG, 0, 0);
                drawChosenShape();
                pictureBox1.Image = bmpFG;
            }
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
            graphics = Graphics.FromImage(bmpBG);
            drawChosenShape();
            pictureBox1.Image = bmpBG;
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

        private void Paint_Resize(object sender, EventArgs e) {
            resizeCanvas();
        }

        //Resize Canvas
        private void resizeCanvas() {
            //Check if firstrun
            if (firstRun == false) {
                //Create new bitmapBG and draw old one on top
                Bitmap oldBmp = bmpBG;
                bmpBG = new Bitmap(bmpBG, pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(bmpBG);

                //Create new bitmapFG and draw old one on top
                bmpFG = new Bitmap(bmpBG, pictureBox1.Width, pictureBox1.Height);
                graphics = Graphics.FromImage(bmpFG);

                //Improve Graphics
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                //Draw
                graphics.DrawImage(oldBmp, 0, 0, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmpBG;
            } else {
                firstRun = false;
            }
        }
    }
}
