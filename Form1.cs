using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA
{
    public partial class Form1 : Form
    {
        private RSAEncryption cipher; 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var inputText = textBox1.Text;

            var _e = (int)numericUpDown1.Value;
            var _d = (int)numericUpDown2.Value;
            var _n = (int)numericUpDown3.Value;

            cipher = new RSAEncryption(inputText, _e, _d, _n);
            cipher.Encrypt();

            textBox2.Text = cipher.GetCipherText();

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            cipher.SetCipherText(textBox2.Text);
            cipher.SetEDN(
                (int)numericUpDown1.Value,
                (int)numericUpDown2.Value,
                (int)numericUpDown3.Value);
            
            cipher.Decrypt();

            textBox3.Text = cipher.GetPlainText();
        }
    }
}
