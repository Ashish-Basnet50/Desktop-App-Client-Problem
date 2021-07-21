﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadway.DesktopApp
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }

        //Yesma Button Ko Kaam Gareko
        private void button11_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
                textBox_Result.Clear();
            isOperationPerformed = false;

            Button button = (Button)sender;
            if(button.Text==".")
            {
                if(!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else

            textBox_Result.Text = textBox_Result.Text + button.Text;
        }

        //Yesma opertor Used Gareko
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue!=0)
            {
                button19.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;


            }


        }
        //CS Oprator Used Gareko
        private void button16_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }
        //CE Used Gareko
        private void button17_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;

        }
        //= Ko Kaam Gareko
        private void button19_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (resultValue + double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "-":
                    textBox_Result.Text = (resultValue - double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "*":
                    textBox_Result.Text = (resultValue * double.Parse(textBox_Result.Text)).ToString();
                    break;

                case "/":
                    textBox_Result.Text = (resultValue / double.Parse(textBox_Result.Text)).ToString();
                    break;

                default:
                    break;
            }
            resultValue = Double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
        }
    } 
}