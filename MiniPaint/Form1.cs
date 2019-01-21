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
        public Paint() {
            InitializeComponent();

            Bitmap bm = new Bitmap(1080, 720);
            Graphics g = Graphics.FromImage(bm);

            g.Clear(Color.White);

            this.pictureBox1.Image = bm;
        }

    }
}
