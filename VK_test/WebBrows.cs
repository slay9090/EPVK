using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VK_test

    
{

    
public partial class WebBrows : Form
    {

        public static String url_iz_browser;
        public WebBrows()
            



        {
            InitializeComponent();
           
            webBrowser1.Navigate("https://vk.com/search?");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            url_iz_browser= webBrowser1.Url.ToString();

            try
            {
                //Console.WriteLine(url_iz_browser);
                String age_from = Regex.Match(url_iz_browser, @"(?<=\[age_from\]\=)(.*?)(?=\&c)").ToString(); //просто спарсить с ссылки

                String age_to = Regex.Match(url_iz_browser, @"(?<=\[age_to\]\=)(.*?)(?=\&c)").ToString(); //просто спарсить с ссылки

                Console.WriteLine(age_from+"_ALO_"+age_to);
                if (age_from=="" || age_to=="")
                {
                    MessageBox.Show("Параметры поиска: \"возраст от\" \"возраст до\" обязательны.");
                }
                else { 
                    Variator vr = new Variator();
                    vr.Show();
                    this.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ошибка в проверке обязательных параметров: возраст");
            }
            


           
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (textBox1.Text != e.Url.ToString())
            {
                textBox1.Text = e.Url.ToString();
            }
        }
    }
}
