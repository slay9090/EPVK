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
    public partial class About_filter : Form
    {
        public About_filter()
        {
            InitializeComponent();

            richTextBox1.ForeColor = Color.Black;


            int i2 = richTextBox1.SelectionStart;
            string rtbText = richTextBox1.Text;
            for (int i = 0; i < rtbText.Length; i++)
            {
                richTextBox1.ForeColor = Color.Black;
                if (rtbText[i] == '"')
                {
                    richTextBox1.Select(i, 1);
                    richTextBox1.SelectionColor = Color.Blue;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);

                }
                else
                {
                    richTextBox1.Select(i, 1);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
                }
                if (rtbText[i] == ';')
                {
                    richTextBox1.Select(i, 1);
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }
                if (rtbText[i] == '*')
                {
                    richTextBox1.Select(i, 1);
                    richTextBox1.SelectionColor = Color.Orange;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

              

                if (rtbText[i] == '(' || rtbText[i] == ')')
                {
                    richTextBox1.Select(i, 1);
                    richTextBox1.SelectionColor = Color.Green;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }


                if (rtbText[i] == 'л' && rtbText[i + 1] == 'ю' && rtbText[i + 2] == 'б' && rtbText[i + 3] == 'л' && rtbText[i + 4] == 'ю')
                {
                richTextBox1.Select(i, 5);
                richTextBox1.SelectionColor = Color.Orange;
                richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
            }

              


                }


            for (int i = 0; i < rtbText.Length; i++)
            {
                if (rtbText[i] == 'л' && rtbText[i + 1] == 'ю' && rtbText[i + 2] == 'б' && rtbText[i + 3] == 'л' && rtbText[i + 4] == 'ю')
                {
                    richTextBox1.Select(i, 5);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

                if (rtbText[i] == 'к' && rtbText[i + 1] == 'у' && rtbText[i + 2] == 'п' && rtbText[i + 3] == 'л' && rtbText[i + 4] == 'ю')
                {
                    richTextBox1.Select(i, 5);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }


                if (rtbText[i] == 'л' && rtbText[i + 1] == 'ю' && rtbText[i + 2] == 'б' && rtbText[i + 3] == 'и' && rtbText[i + 4] == 'л')
                {
                    richTextBox1.Select(i, 3);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

                if (rtbText[i] == 'к' && rtbText[i + 1] == 'у' && rtbText[i + 2] == 'п' && rtbText[i + 3] == 'и' && rtbText[i + 4] == 'л')
                {
                    richTextBox1.Select(i, 3);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

                if (rtbText[i] == 'л' && rtbText[i + 1] == 'ю' && rtbText[i + 2] == 'б' && rtbText[i + 3] == '*')
                {
                    richTextBox1.Select(i, 3);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

                if (rtbText[i] == 'к' && rtbText[i + 1] == 'у' && rtbText[i + 2] == 'п' && rtbText[i + 3] == '*')
                {
                    richTextBox1.Select(i, 3);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

                if (rtbText[i] == 'н' && rtbText[i + 1] == 'о' && rtbText[i + 2] == 'р' && rtbText[i + 3] == 'м')
                {
                    richTextBox1.Select(i, 11);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

                if (rtbText[i] == 'д' && rtbText[i + 1] == 'и' && rtbText[i + 2] == 'з' && rtbText[i + 3] == 'а' && rtbText[i + 4] == 'й' && rtbText[i + 5] == 'н')
                {
                    richTextBox1.Select(i, 6);
                    richTextBox1.SelectionColor = Color.Black;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

                if (rtbText[i] == 'С' && rtbText[i + 1] == 'а' && rtbText[i + 2] == 'м' && rtbText[i + 3] == 'а' && rtbText[i + 4] == 'р')
                {
                    richTextBox1.Select(i, 6);
                    richTextBox1.SelectionColor = Color.Gray;
                    richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                   // richTextBox1.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }


            }


            // Get the current caret position.
            //richTextBox1.SelectionStart = richTextBox1.Text.Length;



            richTextBox1.Select(i2, 0);


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
