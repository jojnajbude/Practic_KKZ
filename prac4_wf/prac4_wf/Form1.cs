using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prac4_wf
{
    public partial class Form1 : Form
    {
        string operation = "(pick operation)";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    textBox4.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text));
                }
                else if (radioButton2.Checked == true)
                {
                    textBox4.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox2.Text));
                }
                else if (radioButton3.Checked == true)
                {
                    textBox4.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text));
                }
                else if (radioButton4.Checked == true)
                {
                    textBox4.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) / Convert.ToDouble(textBox2.Text));
                }
                else if (radioButton5.Checked == true)
                {
                    textBox4.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) % Convert.ToDouble(textBox2.Text));
                }
                else
                {
                    MessageBox.Show("Pick operation!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Text = textBox1.Text + " " + operation + " " + textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Text = textBox1.Text + " " + operation + " " + textBox2.Text;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            operation = "+";
            textBox3.Text = "";
            textBox3.Text = textBox1.Text + " " + operation + " " + textBox2.Text;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            operation = "-";
            textBox3.Text = "";
            textBox3.Text = textBox1.Text + " " + operation + " " + textBox2.Text;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            operation = "*";
            textBox3.Text = "";
            textBox3.Text = textBox1.Text + " " + operation + " " + textBox2.Text;
        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            operation = "/";
            textBox3.Text = "";
            textBox3.Text = textBox1.Text + " " + operation + " " + textBox2.Text;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            operation = "%";
            textBox3.Text = "";
            textBox3.Text = textBox1.Text + " " + operation + " " + textBox2.Text;
        }
    }
}
