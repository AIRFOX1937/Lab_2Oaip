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
    public class Triangle : Figur
    {
        private PointF[] pointFs;
        public static int counter = 0;

        public Triangle(PointF[] pointFs)
        {
            this.pointFs = pointFs;
            this.name = "Triag" + counter;
            counter++;
        }



        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, pointFs);
            Init.pictureBox.Image = Init.bitmap;
        }
        private bool OutOfBoundsCheck(int x, int y)
        {
            return !((this.x + x < 0 && this.y + y < 0) || (this.y + y < 0) || (this.x + x > Init.pictureBox.Width && this.y + y < 0) || (this.x + this.w + x > Init.pictureBox.Width) || (this.x + x > Init.pictureBox.Width && this.y + y > Init.pictureBox.Height) || (this.y + this.h + y > Init.pictureBox.Height) || (this.x + x < 0 && this.y + y > Init.pictureBox.Height) || (this.x + x < 0));
        }
        public override void MoveTo(int x, int y)
        {
            if (OutOfBoundsCheck(x, y))
            {
                this.x += x;
                this.y += y;
                this.DeleteF(this, Init.pictureBox, false);
                this.Draw();
            }
        }
    }
}
