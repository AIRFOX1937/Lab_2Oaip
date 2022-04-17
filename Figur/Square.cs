using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLib
{
    public class Square : Rectangle
    {
        public static int counter = 0;
        public Square()
        {
            this.name = "Square" + counter;
            counter++;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, 205, 28, 30, 30);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
