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
    public partial class demo_versia_zakonchilas : Form
    {
        public demo_versia_zakonchilas()
        {
            InitializeComponent();
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {

            var url = "https://vk.com/epvk_project"; //адрес ссылки это значение свойства `Text`
            System.Diagnostics.Process.Start(url);

           
            //WebBrowser wb = new WebBrowser();
            //wb.Navigate("https://vk.com/matzuo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void demo_versia_zakonchilas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
