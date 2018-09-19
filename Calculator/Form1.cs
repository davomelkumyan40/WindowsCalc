using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double number1 = 0;
        private double number2 = 0;
        private double result = 0;
        private string operation = "";
        private bool isMinus = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (progrBar.Text.Length >= 18)
                label2.Text = "";

            if (progrBar.Text.Length < 18)
            {
                label2.Text = "Progress Bar";
            }
        }


        //numbers
        private void numbers_Click(object sender, EventArgs e)
        {
            if (progrBar.Text.Contains("="))
            {
                operationBar.Clear();
                progrBar.Clear();

            }

            if (operationBar.Text == "0")
            {
                operationBar.Clear();
            }

            Button bt = (Button)sender;
            operationBar.Text += bt.Text;
            progrBar.Text += operationBar.Text;
        }

        //ends numbers

        private void operators_Click(object sender, EventArgs e)
        {
            if (progrBar.Text.Contains("="))
            {
                operationBar.Clear();
                progrBar.Clear();

            }

            if (!string.IsNullOrEmpty(operationBar.Text))
            {
                if (isMinus)
                    number1 = Convert.ToDouble(operationBar.Text) * -1;
                else
                    number1 = Convert.ToDouble(operationBar.Text);
                isMinus = false;
                Button bt = (Button)sender;
                operation = bt.Text.ToString();
                progrBar.Text += operation;
                operationBar.Clear();
            }

        }


        private void clear_Click(object sender, EventArgs e)
        {
            number1 = 0;
            number2 = 0;
            result = 0;
            operationBar.Clear();
            progrBar.Clear();
        }

        private void dot_Click(object sender, EventArgs e)
        {
            if (!operationBar.Text.Contains(".") && operationBar.Text != "")
            {
                operationBar.Text += ".";
                progrBar.Text += ".";
            }

        }

        private void equals_Click(object sender, EventArgs e)
        {
            if (!operationBar.Text.Contains("=") && operationBar.Text != "")
            {
                if (isMinus)
                    number2 = Convert.ToDouble(operationBar.Text) * -1;
                else
                    number2 = Convert.ToDouble(operationBar.Text);
                switch (operation)
                {
                    case "+":
                        {
                            result = number1 + number2;
                            operationBar.Text = result.ToString();
                            if (isMinus)
                                progrBar.Text = $"{number1} + ({number2}) = {result}";
                            else
                                progrBar.Text = $"{number1} + {number2} = {result}";
                        }
                        break;
                    case "-":
                        {
                            result = number1 - number2;
                            operationBar.Text = result.ToString();
                            if (isMinus)
                                progrBar.Text = $"{number1} - ({number2}) = {result}";
                            else
                                progrBar.Text = $"{number1} - {number2} = {result}";
                        }
                        break;
                    case "*":
                        {
                            result = number1 * number2;
                            operationBar.Text = result.ToString();
                            if (isMinus)
                                progrBar.Text = $"{number1} * ({number2}) = {result}";
                            else
                                progrBar.Text = $"{number1} * {number2} = {result}";
                        }
                        break;
                    case "/":
                        {
                            result = number1 / number2;
                            operationBar.Text = result.ToString();
                            if (isMinus)
                                progrBar.Text = $"{number1} / ({number2}) = {result}";
                            else
                                progrBar.Text = $"{number1} / {number2} = {result}";
                        }
                        break;
                }
                isMinus = false;
            }
        }


        //movable
        private bool mouseDown;
        private Point lastLocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        //end movable


        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operationBar.Text) && !string.IsNullOrEmpty(operationBar.Text))
            {
                int startIndex = operationBar.Text.Length - 1;
                operationBar.Text = operationBar.Text.Remove(startIndex, 1);
            }
        }

        private void Minus_Plus_Click(object sender, EventArgs e)
        {
            isMinus = true;
        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.BackColor = Color.Red;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.BackColor = Color.Gray;
        }

        private void minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void minimized_MouseEnter(object sender, EventArgs e)
        {
            minimized.BackColor = Color.Red;
        }

        private void minimized_MouseLeave(object sender, EventArgs e)
        {
            minimized.BackColor = Color.Gray;
        }
    }
}
