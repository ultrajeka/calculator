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
        string outputString;
        int variable;
        int sum;
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

        }

        void btnClickHandler(object sender, EventArgs e)
        {
            outputString += ((Button)sender).Text;
            tbOutput.Text = outputString.ToString();
        }

        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputString))
            {
                outputString = outputString.Remove(outputString.Length - 1, 1);
                tbOutput.Text = outputString;
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(outputString))
            {
                outputString = outputString.Remove(outputString.Length-outputString.Length);
                tbOutput.Text = outputString;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            variable = Convert.ToInt32(outputString);
            sum = variable + Convert.ToInt32(outputString);
        }

        private void btnEqually_Click(object sender, EventArgs e)
        {
            tbOutput.Text = sum.ToString();
        }


    }
}
