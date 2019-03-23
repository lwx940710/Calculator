using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator
{
    public partial class Form1 : Form
    {
        Double value = 0;
        String operation = "";
        bool operationPressed = false, operationEnd = false, percentagePressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (result.Text == "0" || operationPressed || operationEnd)
            {
                result.Text = b.Text;
                if (operationPressed)
                {
                    operationPressed = false;
                }
            } else
            {
                result.Text += b.Text;
            }
            operationEnd = false;
        }

        private void ce_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            operationEnd = true;
            percentagePressed = false;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            operation = b.Text;
            if (result.Text[result.Text.Length - 1] == '%')
            {
                value = Double.Parse(result.Text.Substring(0, result.Text.Length - 1)) / 100;
            } else
            {
                value = Double.Parse(result.Text);
            }
            operationPressed = true;
            history.Text = value.ToString() + " " + b.Text;
            percentagePressed = false;
        }

        private void c_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
            result.Text = "0";
            operation = "";
            operationPressed = false;
            operationEnd = false;
            percentagePressed = false;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (result.Text[result.Text.Length - 1] == '%')
            {
                value *= 100;
            }
            result.Text = result.Text.Substring(0, result.Text.Length - 1);
            if (result.Text.Length == 0)
            {
                result.Text = "0";
            }
        }

        private void plusOrMinus_Click(object sender, EventArgs e)
        {
            if (result.Text[0] == '-')
            {
                result.Text = result.Text.Substring(1, result.Text.Length - 1);
            }
            else if (result.Text == "0")
            {
                return;
            }
            else
            {
                result.Text = "-" + result.Text;
            }

        }

        private void dot_Click(object sender, EventArgs e)
        {
            result.Text = result.Text + ".";
        }

        private void leftThreeButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            value = Double.Parse(result.Text);
            switch (b.Name)
            {
                case "root":
                    value = Math.Sqrt(value);
                    break;
                case "squared":
                    value *= value;
                    break;
                case "cubic":
                    value = value * value * value;
                    break;
                case "oneOver":
                    if (value == 0) break;
                    value = 1 / value;
                    break;
            }
            result.Text = value.ToString();
        }
        
        private void percentage_Click(object sender, EventArgs e)
        {
            /*if (!percentagePressed)
            {
                value = double.Parse(result.Text) / 100;
                result.Text = result.Text + "%";
                percentagePressed = true;
            }
            else
            {
                result.Text = result.Text.Substring(0, result.Text.Length - 1);
                value = Double.Parse(result.Text);
                percentagePressed = false;
            }*/
            
        }

        private void equals_Click(object sender, EventArgs e)
        {
            history.Text = "";
            Double tmp = 0;
            if (result.Text[result.Text.Length - 1] == '%')
            {
                tmp = Double.Parse(result.Text.Substring(0, result.Text.Length - 1)) / 100;
            } else
            {
                tmp = Double.Parse(result.Text);
            }
            switch (operation)
            {
                case "+":
                    result.Text = (value + tmp).ToString();
                    break;
                case "-":
                    result.Text = (value - tmp).ToString();
                    break;
                case "x":
                    result.Text = (value * tmp).ToString();
                    break;
                case "/":
                    result.Text = (value / tmp).ToString();
                    break;
                default:
                    value = tmp;
                    if (value == 0) break;
                    result.Text = value.ToString();
                    break;
            }
            value = 0;
            operation = "";
            operationPressed = false;
            operationEnd = true;
            percentagePressed = false;
        }
    }
}
