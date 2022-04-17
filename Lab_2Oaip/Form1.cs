using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;


namespace Lab_2Oaip
{
    public partial class Form1 : Form
    {
        private int numPoints;
        private PointF[] pointFs;
        private Point point1;
        private Point point2;
        private Point point3;
        private bool flag;
        private Figur figure;
        private Pen pen;
        

        private Stack<Operator> operators = new
        Stack<Operator>();

        private Stack<Operand> operands = new
        Stack<Operand>();

        public Form1()
        {

            InitializeComponent();

            Bitmap bitmap = new
            Bitmap(pictureBox1.ClientSize.Width,
            pictureBox1.ClientSize.Height);
            this.pen = new Pen(Color.Black, 5);

            // Pen pan = new Pen(Color.White);
            Init.bitmap = bitmap;
            Init.pictureBox = pictureBox1;
            Init.pen = this.pen;

        }


        public void Clear()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    var elip = new Ellipse();
        //    ShapeContainer.AddFigure(elip);
        //    elip.Draw();
        //    comboBox1.Items.Clear();
        //    foreach (var item in ShapeContainer.figureList)
        //    {
        //        comboBox1.Items.Add(item.name);
        //    }
        //}
        private void textBoxInputString_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    for (int i = 0; i < textBoxInputString.Text.Length; i++)
                    {
                        if (IsNotOperation(textBoxInputString.Text[i]))
                        {
                            if (!(Char.IsDigit(textBoxInputString.Text[i])))
                            {
                                this.operands.Push(new Operand(textBoxInputString.Text[i]));
                                continue;
                            }
                            else if (Char.IsDigit(textBoxInputString.Text[i]))
                            {
                                if (Char.IsDigit(textBoxInputString.Text[i + 1]))
                                {
                                    if (flag)
                                    {
                                        this.operands.Push(new
                                        Operand(textBoxInputString.Text[i]));
                                    }
                                    this.operands.Push(new Operand(Convert.ToInt32(this.operands.Pop().value) * +Convert.ToInt32(textBoxInputString.Text[i + 1])));
                                    flag = false;
                                    continue;
                                }
                            }
                        }
                        else if ((textBoxInputString.Text[i + 1] == ','
                        || textBoxInputString.Text[i + 1] == ')')
                        && !(Char.IsDigit(textBoxInputString.Text[i - 1])))
                        {
                            this.operands.Push(new Operand(Convert.ToInt32(textBoxInputString.Text[i])));
                            continue;
                        }
                        else if (textBoxInputString.Text[i] == 'C')
                        {
                            if (this.operators.Count == 0)
                            {
                                this.operators.Push(OperatorContainer.FindOperator
                                (textBoxInputString.Text[i]));
                            }
                        }
                        else if (textBoxInputString.Text[i] == '(')
                        {
                            this.operators.Push(OperatorContainer.FindOperator
                            (textBoxInputString.Text[i]));
                        }
                        else if (textBoxInputString.Text[i] == ')')
                        {
                            do
                            {
                                if (operators.Peek().symbolOperator == '(')
                                {
                                    operators.Pop();
                                    break;
                                }
                                if (operators.Count == 0)
                                {
                                    break;
                                }
                            }
                            while (operators.Peek().symbolOperator != '('); // C(elip, 100,100,100,100)
                            if (operators.Peek() != null)
                            {
                                this.SelectingPerformingOperation(operators.Peek());
                            }
                            else
                            {
                                MessageBox.Show("Введенной операции не существует");
                            }
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    //добавляется информация о некорректной команде в историю команд
                    listBox1.Items.Add(ex.Message);
                }
                textBoxInputString.Text = "";
            }
            
        }
        private void SelectingPerformingOperation(Operator op)
        {
            if (op.symbolOperator == 'C')
            {
                var h = Convert.ToInt32(operands.Pop().value);
                var w = Convert.ToInt32(operands.Pop().value);
                var y = Convert.ToInt32(operands.Pop().value);
                var x = Convert.ToInt32(operands.Pop().value);
                var elip = new Ellipse(h, w, y, x);
                ShapeContainer.AddFigure(elip);
                elip.Draw();
                op = new Operator(elip.Draw, 'C');
                ShapeContainer.AddFigure(figure);
                listBox1.Items.Add(figure.name);
                op.operatorMethod();
            }
        }
        bool IsNotOperation(char item)
        {

            if (!(item == 'R' || item == 'M' || item == 'E' || item
            == 'C' || item == 'S' || item == ',' || item == '(' ||
            item == ')'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
