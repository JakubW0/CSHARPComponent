using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenSegmentTestComponent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = sevenSegments1.Value.ToString();
            textBox2.Text = sevenSegments1.AlarmMinimum.ToString();
            textBox3.Text = sevenSegments1.AlarmMaximum.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                sevenSegments1.Value = 0;
            }
            if (textBox1.Text == "-")
            {
                sevenSegments1.Value = -0;
            }
            else
            {
                try
                {
                    sevenSegments1.Value = Double.Parse(textBox1.Text);

                }
                catch (Exception)
                {
                    Console.WriteLine("Value have to be number");
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                sevenSegments1.Value = 0;
            }
            if (textBox2.Text == "-")
            {
                sevenSegments1.Value = -0;
            }
            else
            {
                try
                {
                    sevenSegments1.AlarmMinimum = Double.Parse(textBox2.Text);

                }
                catch (Exception)
                {
                    Console.WriteLine("Value have to be number");
                }

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                sevenSegments1.Value = 0;
            }
            if (textBox3.Text == "-")
            {
                sevenSegments1.Value = -0;
            }
            else
            {
                try
                {
                    sevenSegments1.AlarmMaximum = Double.Parse(textBox3.Text);

                }
                catch (Exception)
                {
                    Console.WriteLine("Value have to be number");
                }
            }
        }
    }
}
