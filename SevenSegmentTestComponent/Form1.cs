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
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "80x140")
            {

                sevenSegment1.SizeDisplay(80, 140);
            }
            else if (comboBox4.Text == "135x205")
            {
                sevenSegment1.SizeDisplay(135, 205);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Color Red")
            {
                sevenSegment1.Background = Color.Red;
            }
            else if (comboBox1.Text == "Color Yellow")
            {
                sevenSegment1.Background = Color.Yellow;
            }
            else if (comboBox1.Text == "Color Silver")
            {
                sevenSegment1.Background = Color.Silver;
            }
            else if (comboBox1.Text == "Color White")
            {
                sevenSegment1.Background = Color.White;
            }
            else if (comboBox1.Text == "Color Black")
            {
                sevenSegment1.Background = Color.Black;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Color Red")
            {
                sevenSegment1.SegmentON = Color.Red;
            }
            else if (comboBox2.Text == "Color Yellow")
            {
                sevenSegment1.SegmentON = Color.Yellow;
            }
            else if (comboBox2.Text == "Color Silver")
            {
                sevenSegment1.SegmentON = Color.Silver;
            }
            else if (comboBox2.Text == "Color White")
            {
                sevenSegment1.SegmentON = Color.White;
            }
            else if (comboBox2.Text == "Color Black")
            {
                sevenSegment1.SegmentON = Color.Black;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Color Red")
            {
                sevenSegment1.SegmentOFF = Color.Red;
            }
            else if (comboBox3.Text == "Color Yellow")
            {
                sevenSegment1.SegmentOFF = Color.Yellow;
            }
            else if (comboBox3.Text == "Color Silver")
            {
                sevenSegment1.SegmentOFF = Color.Silver;
            }
            else if (comboBox3.Text == "Color White")
            {
                sevenSegment1.SegmentOFF = Color.White;
            }
            else if (comboBox3.Text == "Color Black")
            {
                sevenSegment1.SegmentOFF = Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int valueDisplay = 0;
            if (int.TryParse(textBox1.Text, out valueDisplay))
            {
                sevenSegment1.Value = valueDisplay;
            }
            else
            {
                sevenSegment1.Value = -1;
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                sevenSegment1.ShowDot = true;

            }
            else if (checkBox1.Checked == false)
            {
                sevenSegment1.ShowDot = false;
            }
        }
    }
}
