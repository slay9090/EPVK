using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VK_test
{
    public partial class Kapcha : Form
    {
        public static String key_kapcha = "";
        public Kapcha()
        {
            TopMost = true;
            InitializeComponent();
        // String s = Osnova.e.Img;
       
            pictureBox1.ImageLocation=Osnova.uri_kapcha;
           // pictureBox1.Load("https://api.vk.com/captcha.php?sid=767194276378&s=1");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            key_kapcha = textBox1.Text;
            this.Dispose();
        }

        private void Kapcha_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                key_kapcha = textBox1.Text;
                this.Dispose();
            }
        }
    }
}
