using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorAppLab4
{
    public partial class frmCalculator : Form
    {
        double result = 0;
        string operation = "";
        bool isPerformed = false;

        public frmCalculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            if ((txtInput.Text == "0") || isPerformed)
                txtInput.Clear();

            isPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!txtInput.Text.Contains("."))
                    txtInput.Text += button.Text;
            }
            else
            {
                txtInput.Text += button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!isPerformed)
            {
                if (operation != "")
                {
                    btnEqual.PerformClick();
                }
                else
                {
                    result = Double.Parse(txtInput.Text);
                }
            }

            operation = button.Text;
            isPerformed = true;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            double currentValue;
            if (!Double.TryParse(txtInput.Text, out currentValue))
                return;

            switch (operation)
            {
                case "+":
                    txtInput.Text = (result + currentValue).ToString();
                    break;
                case "-":
                    txtInput.Text = (result - currentValue).ToString();
                    break;
                case "*":
                    txtInput.Text = (result * currentValue).ToString();
                    break;
                case "/":
                    if (currentValue != 0)
                        txtInput.Text = (result / currentValue).ToString();
                    else
                        MessageBox.Show("Cannot divide by zero");
                    break;
                default:
                    return;
            }

            result = Double.Parse(txtInput.Text);
            operation = "";
            isPerformed = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "0";
            result = 0;
            operation = "";
            isPerformed = false;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length > 0)
                txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);

            if (txtInput.Text == "")
                txtInput.Text = "0";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
