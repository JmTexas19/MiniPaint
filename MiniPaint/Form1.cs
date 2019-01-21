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

        //Objects
        Bitmap bmp;
        Graphics graphics;
        Pen pen;

        public Paint() {
            InitializeComponent();

            //Create Bitmap for drawing
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            draw = true;
            drawPosX = e.X;
            drawPosY = e.Y;
            graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(new Point(drawPosX, drawPosY), new Size(new Point(10, 10))));
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            draw = false;
            drawPosX = e.X;
            drawPosY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            //If mouse is clicked, start drawing
            if (draw == true) {
                graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(new Point(drawPosX, drawPosY), new Size(new Point(1, 1))));
                pictureBox1.Image = bmp;
            }
        }
    }
}
