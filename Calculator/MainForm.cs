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
    public partial class MainForm : Form
    {
        string inputString;
        string operation;

        double firstVariable;
        double secondVariable;
        double result;

        public MainForm()
        {
            InitializeComponent();
            btn0.Click += btnClickHandler;
            btn1.Click += btnClickHandler;
            btn2.Click += btnClickHandler;
            btn3.Click += btnClickHandler;
            btn4.Click += btnClickHandler;
            btn5.Click += btnClickHandler;
            btn6.Click += btnClickHandler;
            btn7.Click += btnClickHandler;
            btn8.Click += btnClickHandler;
            btn9.Click += btnClickHandler;

            btnPlus.Click += SetOperation;
            btnMinus.Click += SetOperation;
            btnMultiply.Click += SetOperation;
            btnDivide.Click += SetOperation;
            btnSqr.Click += SetOperation;

            firstVariable = secondVariable = result = 0.0;
        }

        void btnClickHandler(object sender, EventArgs e)
        {
            inputString += ((Button)sender).Text;
            tbInput.Text = inputString;
        }

        private void SetOperation(object sender, EventArgs e)
        {            
            firstVariable = double.Parse(tbInput.Text);
            tbFirstVar.Text = firstVariable.ToString();
            tbOutput.Text = "0";
            inputString = "";
            operation = ((Button)sender).Text;
            tbOperation.Text = operation;
            if (operation == "√")
            {
                tbOutput.Text = Math.Sqrt(firstVariable).ToString();
                tbInput.Text = "0";
            }
        }

        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputString))
            {
                inputString = inputString.Remove(inputString.Length - 1, 1);
                tbInput.Text = inputString;
            }
        }       
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {

            inputString = "";
            tbOutput.Text = "0";
            tbSecondVar.Text = "0";
            tbOperation.Text = "";
            tbFirstVar.Text = "0";
            tbInput.Text = "0";
            firstVariable = secondVariable = result = 0.0; ;  

        }

        private void btnEqually_Click(object sender, EventArgs e)
        {
            secondVariable = double.Parse(tbInput.Text);
            tbSecondVar.Text = secondVariable.ToString();
            Calculate(firstVariable, secondVariable, operation);
            tbInput.Text = "0";
        }

        private void Calculate(double firstVariable, double secondVariable, string operation)
        {
            switch (operation)
            {
                case "+":
                    result = firstVariable + secondVariable;
                    break;
                case "-":
                    result = firstVariable - secondVariable;
                    break;
                case "*":
                    result = firstVariable * secondVariable;
                    break;
                case "/":
                    if (secondVariable != 0)
                        result = firstVariable / secondVariable; 
                    else
                        MessageBox.Show("Нельзя делить на ноль. ХЗ почему. Так сказали в школе."); 
                    break;
            }

            tbOutput.Text = result.ToString();
        }
    }
}
