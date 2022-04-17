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
    public class Circle : Ellipse
    {
        public static int counter = 0;
        public Circle()
        {
            this.name = "Circl" + counter;
            counter++;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(Init.pen, x, y, w, w);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
