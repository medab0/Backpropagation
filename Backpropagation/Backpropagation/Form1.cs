using System;
using System.Windows.Forms;
using Backprop;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Backpropagation
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        public Form1()
        {
            InitializeComponent();
        }

        //  4 inputs, 4 hidden neurons, and 1 output
        private void button1_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(4, 4, 1); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[,] inputs = {
                { 0.0, 0.0, 0.0, 0.0 },
                { 0.0, 0.0, 0.0, 1.0 },
                { 0.0, 0.0, 1.0, 0.0 },
                { 0.0, 0.0, 1.0, 1.0 },
                { 0.0, 1.0, 0.0, 0.0 },
                { 0.0, 1.0, 0.0, 1.0 },
                { 0.0, 1.0, 1.0, 0.0 },
                { 0.0, 1.0, 1.0, 1.0 },
                { 1.0, 0.0, 0.0, 0.0 },
                { 1.0, 0.0, 0.0, 1.0 },
                { 1.0, 0.0, 1.0, 0.0 },
                { 1.0, 0.0, 1.0, 1.0 },
                { 1.0, 1.0, 0.0, 0.0 },
                { 1.0, 1.0, 0.0, 1.0 },
                { 1.0, 1.0, 1.0, 0.0 },
                { 1.0, 1.0, 1.0, 1.0 }
            };

            double[] outputs = {
                0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
                0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 1.0
            };

            for (int epoch = 0; epoch < 400; epoch++)
            {
                for (int i = 0; i < 16; i++)
                {
                    nn.setInputs(0, inputs[i, 0]);
                    nn.setInputs(1, inputs[i, 1]);
                    nn.setInputs(2, inputs[i, 2]);
                    nn.setInputs(3, inputs[i, 3]);
                    nn.setDesiredOutput(0, outputs[i]);
                    nn.learn();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.setInputs(2, Convert.ToDouble(textBox3.Text));
            nn.setInputs(3, Convert.ToDouble(textBox4.Text));
            nn.run();

            textBox5.Text = "" + nn.getOuputData(0);
        }
    }
}
