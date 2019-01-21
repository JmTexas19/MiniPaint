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
        bool draw = false;
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

        public Paint() {
            InitializeComponent();

            //Create Bitmap for drawing
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            //Set Drawing mode to true
            draw = true;

            //Record Mouse Position
            drawPosX = e.X;
            drawPosY = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            //Set Drawing mode to true
            draw = false;

            //Record Mouse Release Position
            releasePosX = e.X;
            releasePosY = e.Y;

            //Draw Shape
            drawShape();
        }

        //Draw Shape Selected
        private void drawShape() {

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
