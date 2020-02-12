using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace VK_test
{
    public partial class Konstruktor : Form
    {
        public Konstruktor()
        {
            InitializeComponent();

            TopMost = true;
            //  TransparencyKey = SystemColors.Control;

            panel1.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel1.Parent = this;
            panel6.BackColor = Color.FromArgb(0, 0, 0, 0);
            panel6.Parent = this;
            bitmap1 = new Bitmap(panel1.Width, panel1.Height);
            bitmap2 = new Bitmap(panel6.Width, panel6.Height);
        }

        Graphics G;
        Pen P;
        Bitmap bitmap1;
        Bitmap bitmap2;
        GraphicsState transState;
        public static String result = "";
        public static String find_result = "";
        int state_but1 = -1;
        int state_but2 = -1;
        int state_but3 = -1;
        int state_but5 = -1;
        int state_but4 = -1;
        int state_but6 = -1;

        int state_but7 = -1;
        int state_but8 = -1;
        int state_but9 = -1;

        int state_but10 = -1;
        int state_but11 = -1;
        int state_but12 = -1;

        int state_but13 = -1;
        int state_but14 = -1;
        int state_but15 = -1;


        bool a1 = false;
        bool a2 = false;
        bool a3 = false;
        bool b1 = false;
        bool b2 = false;
        bool b3 = false;
        bool c1 = false;
        bool c2 = false;
        bool c3 = false;


        bool d1 = false;
        bool d2 = false;
        bool d3 = false;
        bool e1 = false;
        bool e2 = false;
        bool e3 = false;
        bool f1 = false;
        bool f2 = false;
        bool f3 = false;

        bool g1 = false;
        bool g2 = false;
        bool g3 = false;
        bool h1 = false;
        bool h2 = false;
        bool h3 = false;
        bool i1 = false;
        bool i2 = false;
        bool i3 = false;

        bool o1 = false;
        bool o2 = false;
        bool o3 = false;
        bool p1 = false;
        bool p2 = false;
        bool p3 = false;
        bool r1 = false;
        bool r2 = false;
        bool r3 = false;



        int d1_use = 0;
        int d2_use = 0;
        int d3_use = 0;
        int e1_use = 0;
        int e2_use = 0;
        int e3_use = 0;
        int f1_use = 0;
        int f2_use = 0;
        int f3_use = 0;

        int g1_use = 0;
        int g2_use = 0;
        int g3_use = 0;
        int h1_use = 0;
        int h2_use = 0;
        int h3_use = 0;
        int i1_use = 0;
        int i2_use = 0;
        int i3_use = 0;

        int o1_use = 0;
        int o2_use = 0;
        int o3_use = 0;
        int p1_use = 0;
        int p2_use = 0;
        int p3_use = 0;
        int r1_use = 0;
        int r2_use = 0;
        int r3_use = 0;

        int a1_use = 0;
        int b1_use = 0;
        int c1_use = 0;
        int a2_use = 0;
        int b2_use = 0;
        int c2_use = 0;
        int a3_use = 0;
        int b3_use = 0;
        int c3_use = 0;


        int del_line = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            // base.OnPaint(e);
            //  e.Graphics.DrawEllipse(Pens.Red, 100, 100, 300, 300);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = SystemColors.Info;
            button1.Visible = true;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = SystemColors.Info;
            button2.Visible = true;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.BackColor = SystemColors.Info;
            button3.Visible = true;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.BackColor = SystemColors.Info;
            button4.Visible = true;
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.BackColor = SystemColors.Info;
            button5.Visible = true;
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.BackColor = SystemColors.Info;
            button6.Visible = true;
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.BackColor = SystemColors.Info;
            button7.Visible = true;
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            textBox8.BackColor = SystemColors.Info;
            button8.Visible = true;
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.BackColor = SystemColors.Info;
            button9.Visible = true;
        }

        private void textBox10_Click(object sender, EventArgs e)
        {
            textBox10.BackColor = SystemColors.Info;
            button10.Visible = true;
        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            textBox11.BackColor = SystemColors.Info;
            button11.Visible = true;
        }

        private void textBox12_Click(object sender, EventArgs e)
        {
            textBox12.BackColor = SystemColors.Info;
            button12.Visible = true;
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            textBox13.BackColor = SystemColors.Info;
            button13.Visible = true;
        }

        private void textBox14_Click(object sender, EventArgs e)
        {
            textBox14.BackColor = SystemColors.Info;
            button14.Visible = true;
        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            textBox15.BackColor = SystemColors.Info;
            button15.Visible = true;
        }

        private void textBox16_Click(object sender, EventArgs e)
        {
            textBox16.BackColor = SystemColors.Info;
            button16.Visible = true;
        }

        private void textBox17_Click(object sender, EventArgs e)
        {
            textBox17.BackColor = SystemColors.Info;
            button17.Visible = true;
        }

        private void textBox18_Click(object sender, EventArgs e)
        {
            textBox18.BackColor = SystemColors.Info;
            button18.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (state_but1 == 0 || state_but1 == -1)
            {


                state_but1 = 1;
                state_but2 = 0;
                state_but3 = 0;
                button1.BackColor = SystemColors.Info;
                button2.BackColor = SystemColors.AppWorkspace;
                button3.BackColor = SystemColors.AppWorkspace;
                //state_but4 = 0;
                //state_but5 = 0;
                //state_but6 = 0;



            }
            else
            {

                state_but1 = 0;

                button1.BackColor = SystemColors.AppWorkspace;


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.AppWorkspace;

            button5.BackColor = SystemColors.Info;
            button6.BackColor = SystemColors.AppWorkspace;





            if (a2 == true && state_but1 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                a2 = false;
            }

            if (b2 == true && state_but2 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                b2 = false;
            }

            if (c2 == true && state_but3 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                c2 = false;


            }


            if (a2 == false && state_but1 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Yellow, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                a2 = true;
                del_line = 0;
            }

            if (b2 == false && state_but2 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Yellow, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                b2 = true;
                del_line = 0;
            }
            if (c2 == false && state_but3 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Yellow, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                c2 = true;
                del_line = 0;
            }
            del_line = 0;
            paint_all_left();
            zapolnenie_result_tabl();

        }

        private void button5_Paint(object sender, PaintEventArgs e)
        {
            //  e.Graphics.DrawLine(Pens.Red, button1.Location.X, button1.Location.Y, button19.Location.X, button19.Location.Y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(bitmap1, 0, 0);



        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.AppWorkspace;

            button5.BackColor = SystemColors.AppWorkspace;
            button6.BackColor = SystemColors.Info;




            if (a3 == true && state_but1 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                a3 = false;
            }

            if (b3 == true && state_but2 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                b3 = false;
            }

            if (c3 == true && state_but3 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                c3 = false;


            }


            if (a3 == false && state_but1 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Red, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                a3 = true;
                del_line = 0;
            }

            if (b3 == false && state_but2 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Red, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                b3 = true;
                del_line = 0;
            }
            if (c3 == false && state_but3 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Red, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                c3 = true;
                del_line = 0;
            }
            del_line = 0;
            paint_all_left();
            zapolnenie_result_tabl();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (state_but4 == 0 || state_but4==-1)
            //{
            button4.BackColor = SystemColors.Info;

            button5.BackColor = SystemColors.AppWorkspace;
            button6.BackColor = SystemColors.AppWorkspace;






            if (a1 == true && state_but1 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                a1 = false;

            }

            if (b1 == true && state_but2 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                b1 = false;

            }

            if (c1 == true && state_but3 == 1)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                del_line = 1;
                c1 = false;

            }


            if (a1 == false && state_but1 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Blue, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                a1 = true;
                del_line = 0;




            }

            if (b1 == false && state_but2 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Blue, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                b1 = true;
                del_line = 0;

            }
            if (c1 == false && state_but3 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Blue, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
                c1 = true;
                del_line = 0;

            }
            del_line = 0;
            paint_all_left();
            zapolnenie_result_tabl();



        }

        public void paint_all_left() //перерисовываем всё полностью

        {



            if (a3 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Red, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }

            if (b3 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Red, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }

            if (c3 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Red, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }

            if (a2 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Yellow, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }

            if (b2 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Yellow, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }

            if (c2 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Yellow, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }


            if (a1 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Blue, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }

            if (b1 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Blue, 2);

                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }

            if (c1 == true)
            {
                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(Color.Blue, 2);

                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();
            }

            if (a1 == false && a2 == false && a3 == false && b1 == false && b2 == false && b3 == false && c1 == false && c2 == false && c3 == false)
            {
                Console.WriteLine("Clear color");


                G = Graphics.FromImage(bitmap1);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);
                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);
                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button4.Location.X + 11, button4.Location.Y + 11);
                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);
                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);
                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button5.Location.X + 11, button5.Location.Y + 11);
                G.DrawLine(P, button1.Location.X + 11, button1.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);
                G.DrawLine(P, button2.Location.X + 11, button2.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);
                G.DrawLine(P, button3.Location.X + 11, button3.Location.Y + 11, button6.Location.X + 11, button6.Location.Y + 11);


                panel1.Invalidate();


                panel1.Refresh();
                G.Dispose();




                panel1.Invalidate();
                panel1.Update();

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (state_but2 == 0 || state_but1 == -1)
            {


                state_but1 = 0;
                state_but2 = 1;
                state_but3 = 0;
                button1.BackColor = SystemColors.AppWorkspace;
                button2.BackColor = SystemColors.Info;
                button3.BackColor = SystemColors.AppWorkspace;
                state_but4 = 0;
                state_but5 = 0;
                state_but6 = 0;


            }
            else
            {

                state_but2 = 0;

                button2.BackColor = SystemColors.AppWorkspace;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (state_but3 == 0 || state_but1 == -1)
            {


                state_but1 = 0;
                state_but2 = 0;
                state_but3 = 1;
                button1.BackColor = SystemColors.AppWorkspace;
                button2.BackColor = SystemColors.AppWorkspace;
                button3.BackColor = SystemColors.Info;
                state_but4 = 0;
                state_but5 = 0;
                state_but6 = 0;


            }
            else
            {

                state_but3 = 0;

                button3.BackColor = SystemColors.AppWorkspace;


            }
        }

        public void zapolnenie_result_tabl()
        {

            int skolko_strok = 0;





            if (a1 == true)
            {
                skolko_strok++;

            }
            if (b1 == true)
            {
                skolko_strok++;

            }
            if (c1 == true)
            {
                skolko_strok++;

            }

            if (a2 == true)
            {
                skolko_strok++;
            }
            if (b2 == true)
            {
                skolko_strok++;
            }
            if (c2 == true)
            {
                skolko_strok++;
            }
            if (a3 == true)
            {
                skolko_strok++;
            }
            if (b3 == true)
            {
                skolko_strok++;
            }
            if (c3 == true)
            {
                skolko_strok++;
            }

            Console.WriteLine(skolko_strok);



            for (int i = 0; i <= 8; i++)
            {

                var textBoxes = new[] { textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15 };
                var buttoni = new[] { button7, button8, button9, button10, button11, button12, button13, button14, button15 };
                buttoni[i].Visible = false;
                textBoxes[i].Text = "";
                textBoxes[i].BackColor = Color.LightGray;


            }


            for (int i = 0; i <= skolko_strok - 1; i++)
            {

                var textBoxes = new[] { textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15 };
                var buttoni = new[] { button7, button8, button9, button10, button11, button12, button13, button14, button15 };


                if (a1 == true && a1_use == 0)
                {

                    a1_use = 1;
                    textBoxes[i].Text = "\"" + textBox1.Text + " " + textBox4.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;

                }
                if (b1 == true && b1_use == 0)
                {
                    b1_use = 1;
                    textBoxes[i].Text = "\"" + textBox2.Text + " " + textBox4.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;
                }
                if (c1 == true && c1_use == 0)
                {
                    c1_use = 1;
                    textBoxes[i].Text = "\"" + textBox3.Text + " " + textBox4.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;

                }

                if (a2 == true && a2_use == 0)
                {
                    a2_use = 1;
                    textBoxes[i].Text = "\"" + textBox1.Text + " " + textBox5.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;
                }
                if (b2 == true && b2_use == 0)
                {
                    b2_use = 1;
                    textBoxes[i].Text = "\"" + textBox2.Text + " " + textBox5.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;
                }
                if (c2 == true && c2_use == 0)
                {
                    c2_use = 1;
                    textBoxes[i].Text = "\"" + textBox3.Text + " " + textBox5.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;
                }
                if (a3 == true && a3_use == 0)
                {
                    a3_use = 1;
                    textBoxes[i].Text = "\"" + textBox1.Text + " " + textBox6.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;
                }
                if (b3 == true && b3_use == 0)
                {
                    b3_use = 1;
                    textBoxes[i].Text = "\"" + textBox2.Text + " " + textBox6.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;
                }
                if (c3 == true && c3_use == 0)
                {
                    c3_use = 1;
                    textBoxes[i].Text = "\"" + textBox3.Text + " " + textBox6.Text + "\"";
                    textBoxes[i].BackColor = SystemColors.Info;
                    buttoni[i].Visible = true;
                    continue;
                }




            }


            a1_use = 0;
            b1_use = 0;
            c1_use = 0;
            a2_use = 0;
            b2_use = 0;
            c2_use = 0;
            a3_use = 0;
            b3_use = 0;
            c3_use = 0;


        }

        private void button20_Click(object sender, EventArgs e)
        {
            a1 = false;
            a2 = false;
            a3 = false;
            b1 = false;
            b2 = false;
            b3 = false;
            c1 = false;
            c2 = false;
            c3 = false;
            paint_all_left();

            zapolnenie_result_tabl();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            state_but7 = 1;
            state_but8 = 0;
            state_but9 = 0;

            state_but10 = 0;
            state_but11 = 0;
            state_but12 = 0;

            state_but13 = 0;
            state_but14 = 0;
            state_but15 = 0;

            button7.BackColor = SystemColors.Info;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.AppWorkspace;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            state_but7 = 0;
            state_but8 = 1;
            state_but9 = 0;

            state_but10 = 0;
            state_but11 = 0;
            state_but12 = 0;

            state_but13 = 0;
            state_but14 = 0;
            state_but15 = 0;

            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.Info;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.AppWorkspace;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            state_but7 = 0;
            state_but8 = 0;
            state_but9 = 1;

            state_but10 = 0;
            state_but11 = 0;
            state_but12 = 0;

            state_but13 = 0;
            state_but14 = 0;
            state_but15 = 0;

            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.Info;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.AppWorkspace;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            state_but7 = 0;
            state_but8 = 0;
            state_but9 = 0;

            state_but10 = 1;
            state_but11 = 0;
            state_but12 = 0;

            state_but13 = 0;
            state_but14 = 0;
            state_but15 = 0;

            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.Info;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.AppWorkspace;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            state_but7 = 0;
            state_but8 = 0;
            state_but9 = 0;

            state_but10 = 0;
            state_but11 = 1;
            state_but12 = 0;

            state_but13 = 0;
            state_but14 = 0;
            state_but15 = 0;

            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.Info;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.AppWorkspace;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            state_but7 = 0;
            state_but8 = 0;
            state_but9 = 0;

            state_but10 = 0;
            state_but11 = 0;
            state_but12 = 1;

            state_but13 = 0;
            state_but14 = 0;
            state_but15 = 0;

            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.Info;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.AppWorkspace;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            state_but7 = 0;
            state_but8 = 0;
            state_but9 = 0;

            state_but10 = 0;
            state_but11 = 0;
            state_but12 = 0;

            state_but13 = 1;
            state_but14 = 0;
            state_but15 = 0;

            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.Info;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.AppWorkspace;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            state_but7 = 0;
            state_but8 = 0;
            state_but9 = 0;

            state_but10 = 0;
            state_but11 = 0;
            state_but12 = 0;

            state_but13 = 0;
            state_but14 = 1;
            state_but15 = 0;

            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.Info;
            button15.BackColor = SystemColors.AppWorkspace;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            state_but7 = 0;
            state_but8 = 0;
            state_but9 = 0;

            state_but10 = 0;
            state_but11 = 0;
            state_but12 = 0;

            state_but13 = 0;
            state_but14 = 0;
            state_but15 = 1;

            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.Info;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button16.BackColor = SystemColors.Info;

            button17.BackColor = SystemColors.AppWorkspace;
            button18.BackColor = SystemColors.AppWorkspace;


            if (d1 == true && state_but7 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                d1 = false;

            }

            if (e1 == true && state_but8 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                e1 = false;

            }

            if (f1 == true && state_but9 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                f1 = false;

            }

            if (g1 == true && state_but10 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                g1 = false;

            }
            if (h1 == true && state_but11 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                h1 = false;

            }
            if (i1 == true && state_but12 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                i1 = false;

            }
            if (o1 == true && state_but13 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                o1 = false;

            }
            if (p1 == true && state_but14 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                p1 = false;

            }
            if (r1 == true && state_but15 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                r1 = false;

            }





            // Дальше рисуем линии



            if (d1 == false && state_but7 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                d1 = true;
                del_line = 0;




            }

            if (e1 == false && state_but8 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                e1 = true;
                del_line = 0;




            }
            if (f1 == false && state_but9 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                f1 = true;
                del_line = 0;




            }
            if (g1 == false && state_but10 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                g1 = true;
                del_line = 0;




            }
            if (h1 == false && state_but11 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                h1 = true;
                del_line = 0;




            }
            if (i1 == false && state_but12 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                i1 = true;
                del_line = 0;




            }
            if (o1 == false && state_but13 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                o1 = true;
                del_line = 0;




            }
            if (p1 == false && state_but14 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                p1 = true;
                del_line = 0;




            }
            if (r1 == false && state_but15 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                r1 = true;
                del_line = 0;




            }
            del_line = 0;
            paint_all_right();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(bitmap2, 0, 0);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            button16.BackColor = SystemColors.AppWorkspace;

            button17.BackColor = SystemColors.Info;
            button18.BackColor = SystemColors.AppWorkspace;


            if (d2 == true && state_but7 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                d2 = false;

            }
            if (e2 == true && state_but8 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                e2 = false;

            }
            if (f2 == true && state_but9 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                f2 = false;

            }
            if (g2 == true && state_but10 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                g2 = false;

            }
            if (h2 == true && state_but11 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                h2 = false;

            }
            if (i2 == true && state_but12 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                i2 = false;

            }
            if (o2 == true && state_but13 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                o2 = false;

            }
            if (p2 == true && state_but14 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                p2 = false;

            }
            if (r2 == true && state_but15 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                r2 = false;

            }

            // Дальше рисуем линии
            if (d2 == false && state_but7 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                d2 = true;
                del_line = 0;




            }

            if (e2 == false && state_but8 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                e2 = true;
                del_line = 0;




            }
            if (f2 == false && state_but9 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                f2 = true;
                del_line = 0;




            }
            if (g2 == false && state_but10 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                g2 = true;
                del_line = 0;




            }
            if (h2 == false && state_but11 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                h2 = true;
                del_line = 0;




            }
            if (i2 == false && state_but12 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                i2 = true;
                del_line = 0;




            }
            if (o2 == false && state_but13 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                o2 = true;
                del_line = 0;




            }
            if (p2 == false && state_but14 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                p2 = true;
                del_line = 0;




            }
            if (r2 == false && state_but15 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                r2 = true;
                del_line = 0;




            }
            del_line = 0;
            paint_all_right();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            button16.BackColor = SystemColors.AppWorkspace;

            button17.BackColor = SystemColors.AppWorkspace;
            button18.BackColor = SystemColors.Info;


            if (d3 == true && state_but7 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                d3 = false;

            }
            if (e3 == true && state_but8 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                e3 = false;

            }
            if (f3 == true && state_but9 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                f3 = false;

            }
            if (g3 == true && state_but10 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                g3 = false;

            }
            if (h3 == true && state_but11 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                h3 = false;

            }
            if (i3 == true && state_but12 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                i3 = false;

            }
            if (o3 == true && state_but13 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                o3 = false;

            }
            if (p3 == true && state_but14 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                p3 = false;

            }
            if (r3 == true && state_but15 == 1)
            {
                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(SystemColors.AppWorkspace, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                del_line = 1;
                r3 = false;

            }

            // Дальше рисуем линии
            if (d3 == false && state_but7 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                d3 = true;
                del_line = 0;




            }
            if (e3 == false && state_but8 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                e3 = true;
                del_line = 0;




            }
            if (f3 == false && state_but9 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                f3 = true;
                del_line = 0;




            }
            if (g3 == false && state_but10 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                g3 = true;
                del_line = 0;




            }
            if (h3 == false && state_but11 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                h3 = true;
                del_line = 0;




            }
            if (i3 == false && state_but12 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                i3 = true;
                del_line = 0;




            }
            if (o3 == false && state_but13 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                o3 = true;
                del_line = 0;




            }
            if (p3 == false && state_but14 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                p3 = true;
                del_line = 0;




            }
            if (r3 == false && state_but15 == 1 && del_line != 1)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                r3 = true;
                del_line = 0;




            }
            del_line = 0;
            paint_all_right();
        }

        public void paint_all_right()
        {
            if (d1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                d1 = true;
                del_line = 0;




            }

            if (e1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                e1 = true;
                del_line = 0;




            }
            if (f1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                f1 = true;
                del_line = 0;




            }
            if (g1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                g1 = true;
                del_line = 0;




            }
            if (h1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                h1 = true;
                del_line = 0;




            }
            if (i1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                i1 = true;
                del_line = 0;




            }
            if (o1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                o1 = true;
                del_line = 0;




            }
            if (p1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                p1 = true;
                del_line = 0;




            }
            if (r1 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button16.Location.X + 11, button16.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                r1 = true;
                del_line = 0;




            }



            if (d2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                d2 = true;
                del_line = 0;




            }

            if (e2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                e2 = true;
                del_line = 0;




            }
            if (f2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                f2 = true;
                del_line = 0;




            }
            if (g2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                g2 = true;
                del_line = 0;




            }
            if (h2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                h2 = true;
                del_line = 0;




            }
            if (i2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                i2 = true;
                del_line = 0;




            }
            if (o2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                o2 = true;
                del_line = 0;




            }
            if (p2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                p2 = true;
                del_line = 0;




            }
            if (r2 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button17.Location.X + 11, button17.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                r2 = true;
                del_line = 0;




            }

            if (d3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button7.Location.X + 11, button7.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                d3 = true;
                del_line = 0;




            }
            if (e3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button8.Location.X + 11, button8.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                e3 = true;
                del_line = 0;




            }
            if (f3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button9.Location.X + 11, button9.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                f3 = true;
                del_line = 0;




            }
            if (g3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button10.Location.X + 11, button10.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                g3 = true;
                del_line = 0;




            }
            if (h3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button11.Location.X + 11, button11.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                h3 = true;
                del_line = 0;




            }
            if (i3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button12.Location.X + 11, button12.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                i3 = true;
                del_line = 0;




            }
            if (o3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button13.Location.X + 11, button13.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                o3 = true;
                del_line = 0;




            }
            if (p3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button14.Location.X + 11, button14.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                p3 = true;
                del_line = 0;




            }
            if (r3 == true)
            {

                G = Graphics.FromImage(bitmap2);
                this.transState = G.Save();
                P = new Pen(Color.Green, 2);

                G.DrawLine(P, button15.Location.X + 11, button15.Location.Y + 11, button18.Location.X + 11, button18.Location.Y + 11);


                panel6.Invalidate();


                panel6.Refresh();
                G.Dispose();
                r3 = true;
                del_line = 0;




            }


        }

        private void button19_Click(object sender, EventArgs e)
        {
            result = "";
            find_result = "";

            Osnova.one_raz_ne_pidoras1 = 0;
            Osnova.one_raz_ne_pidoras2 = 0;


            var textBoxes = new[] { textBox7, textBox8, textBox9, textBox10, textBox11, textBox12, textBox13, textBox14, textBox15 };

            var dr1 = new[] { d1, e1, f1, g1, h1, i1, o1, p1, r1 };
            var dr2 = new[] { d2, e2, f2, g2, h2, i2, o2, p2, r2 };
            var dr3 = new[] { d3, e3, f3, g3, h3, i3, o3, p3, r3 };
            var dr1_use = new[] { d1_use, e1_use, f1_use, g1_use, h1_use, i1_use, o1_use, p1_use, r1_use};
            var dr2_use = new[] { d2_use, e2_use, f2_use, g2_use, h2_use, i2_use, o2_use, p2_use, r2_use};
            var dr3_use = new[] { d3_use, e3_use, f3_use, g3_use, h3_use, i3_use, o3_use, p3_use, r3_use};
           // var textboxes_right = new[] { textBox16, textBox17, textBox18 };

            for (int i = 0; i <= 8; i++)
            {


                if (textBoxes[i].Text != "\" \"" && textBoxes[i].Text != "")
                {
                                 
                    if (dr1[i] == false &&  dr1_use[i] == 0)
                    {
                        // result += textBoxes[i].Text + "; " + " dr13[j]= " + dr13[i] + " dr13_use[j]= " + dr13_use[i] + " /";

                        if (dr1[i] == false && dr2[i] == false && dr3[i] == false)
                        {
                            result += textBoxes[i].Text + "; ";
                            dr1_use[i] = 1;
                            continue;
                        }
                    }

                    else
                    {
                        if (dr1_use[i] == 0)
                        {
                           // result += textBoxes[i].Text + " (" + textboxes_right[rtb].Text + "); " + " dr13[j]= " + dr13[i] + " dr13_use[j]= " + dr13_use[i] + " /"; //добавить 3 текстбокса справа самого
                            result += textBoxes[i].Text + " (" + textBox16.Text.Replace("*", "") + "); " ; 
                            dr1_use[i] = 1;
                            continue;
                        }
                      

                    }

                    // tut kod virezal 
                }


            }

            for (int i = 0; i <= 8; i++)
            {


                if (textBoxes[i].Text != "\" \"" && textBoxes[i].Text != "")
                {

                    if (dr2[i] == false && dr2_use[i] == 0)
                    {
                        // result += textBoxes[i].Text + "; " + " dr13[j]= " + dr13[i] + " dr13_use[j]= " + dr13_use[i] + " /";
                      //  result += textBoxes[i].Text + "; ";
                        dr2_use[i] = 1;
                        continue;
                    }

                    else
                    {
                        if (dr2_use[i] == 0)
                        {
                            // result += textBoxes[i].Text + " (" + textboxes_right[rtb].Text + "); " + " dr13[j]= " + dr13[i] + " dr13_use[j]= " + dr13_use[i] + " /"; //добавить 3 текстбокса справа самого
                            result += textBoxes[i].Text + " (" + textBox17.Text.Replace("*", "") + "); ";
                            dr2_use[i] = 1;
                            continue;
                        }


                    }

                    // tut kod virezal 
                }


            }

            for (int i = 0; i <= 8; i++)
            {


                if (textBoxes[i].Text != "\" \"" && textBoxes[i].Text != "")
                {

                    if (dr3[i] == false && dr3_use[i] == 0)
                    {
                        // result += textBoxes[i].Text + "; " + " dr13[j]= " + dr13[i] + " dr13_use[j]= " + dr13_use[i] + " /";
                       // result += textBoxes[i].Text + "; ";
                        dr3_use[i] = 1;
                        continue;
                    }

                    else
                    {
                        if (dr3_use[i] == 0)
                        {
                            // result += textBoxes[i].Text + " (" + textboxes_right[rtb].Text + "); " + " dr13[j]= " + dr13[i] + " dr13_use[j]= " + dr13_use[i] + " /"; //добавить 3 текстбокса справа самого
                            result += textBoxes[i].Text + " (" + textBox18.Text.Replace("*", "") + "); ";
                            dr3_use[i] = 1;
                            continue;
                        }


                    }

                    // tut kod virezal 
                }


            }


            Console.WriteLine(result);

            d1_use = 0;
            d2_use = 0;
            d3_use = 0;
            e1_use = 0;
            e2_use = 0;
            e3_use = 0;
            f1_use = 0;
            f2_use = 0;
            f3_use = 0;

            g1_use = 0;
            g2_use = 0;
            g3_use = 0;
            h1_use = 0;
            h2_use = 0;
            h3_use = 0;
            i1_use = 0;
            i2_use = 0;
            i3_use = 0;

            o1_use = 0;
            o2_use = 0;
            o3_use = 0;
            p1_use = 0;
            p2_use = 0;
            p3_use = 0;
            r1_use = 0;
            r2_use = 0;
            r3_use = 0;

            String find_zapr="";
            for (int i = 0; i <= 8; i++)
            {
                if (textBoxes[i].Text != "") {
                    find_zapr+= textBoxes[i].Text+"; ";

                }

            }

            // String RT1 = richTextBox2.Text;
            result = result.Trim();
          //  Console.WriteLine("RT=" + RT1 + "=RT");
            String tmp2 = result.Substring(result.Length - 1);
            if (tmp2 == ";")
            {
                result = result.Remove(result.Length - 1).Trim();
            }
            find_result = result.Replace("*", "").Replace("\"", "").Replace("(", "").Replace(")", "");
            Console.WriteLine("FIND^ "+find_result);

            Osnova ff = (Osnova)Application.OpenForms["Osnova"];



            // String RT1 = richTextBox2.Text;
           find_zapr = find_zapr.Trim();
            //  Console.WriteLine("RT=" + RT1 + "=RT");
            String tmp1 = find_zapr.Substring(find_zapr.Length - 1);
            if (tmp1 == ";")
            {
                find_zapr = find_zapr.Remove(find_zapr.Length - 1).Trim();
            }
            find_result = find_zapr.Replace("*", "").Replace("\"", "").Replace("(", "").Replace(")", "");




            ff.richTextBox3.Text = find_result;
            ff.richTextBox2.Text = result;

            this.Dispose();

        }

        private void button21_Click(object sender, EventArgs e)
        {
            d1_use = 0;
            d2_use = 0;
            d3_use = 0;
            e1_use = 0;
            e2_use = 0;
            e3_use = 0;
            f1_use = 0;
            f2_use = 0;
            f3_use = 0;

            g1_use = 0;
            g2_use = 0;
            g3_use = 0;
            h1_use = 0;
            h2_use = 0;
            h3_use = 0;
            i1_use = 0;
            i2_use = 0;
            i3_use = 0;

            o1_use = 0;
            o2_use = 0;
            o3_use = 0;
            p1_use = 0;
            p2_use = 0;
            p3_use = 0;
            r1_use = 0;
            r2_use = 0;
            r3_use = 0;


             d1 = false;
             d2 = false;
             d3 = false;
             e1 = false;
             e2 = false;
             e3 = false;
             f1 = false;
             f2 = false;
             f3 = false;

             g1 = false;
             g2 = false;
             g3 = false;
             h1 = false;
             h2 = false;
             h3 = false;
             i1 = false;
             i2 = false;
             i3 = false;

             o1 = false;
             o2 = false;
             o3 = false;
             p1 = false;
             p2 = false;
             p3 = false;
             r1 = false;
             r2 = false;
             r3 = false;


            button7.BackColor = SystemColors.AppWorkspace;
            button8.BackColor = SystemColors.AppWorkspace;
            button9.BackColor = SystemColors.AppWorkspace;

            button10.BackColor = SystemColors.AppWorkspace;
            button11.BackColor = SystemColors.AppWorkspace;
            button12.BackColor = SystemColors.AppWorkspace;

            button13.BackColor = SystemColors.AppWorkspace;
            button14.BackColor = SystemColors.AppWorkspace;
            button15.BackColor = SystemColors.AppWorkspace;

            button16.BackColor = SystemColors.AppWorkspace;

            button17.BackColor = SystemColors.AppWorkspace;
            button18.BackColor = SystemColors.AppWorkspace;



            var button_clear_levo = new[] { button7, button8, button9, button10, button11, button12, button13, button14, button15 };
            var button_clear_pravo = new[] { button16, button17, button18 };

            G = Graphics.FromImage(bitmap2);
            this.transState = G.Save();
            P = new Pen(SystemColors.AppWorkspace, 2);

            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    G.DrawLine(P, button_clear_levo[i].Location.X + 11, button_clear_levo[i].Location.Y + 11, button_clear_pravo[j].Location.X + 11, button_clear_pravo[j].Location.Y + 11);
                }

            }


            panel6.Invalidate();


            panel6.Refresh();
            G.Dispose();

            
        }
    }
}
