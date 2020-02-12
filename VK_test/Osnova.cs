using System;
using System.Collections.Generic;

using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.RequestParams;

// 03/05 добавил два трай кетча в два больших метода 
namespace VK_test
{
    public partial class Osnova : Form
    {
        String patch_file_open;
        int stop = 0;
        int postavili_comment = 0;
        int find_post_kolichestvo;
        String nugnie_posts; //сюда записываем посты после фильтра
        String text_posts = "";
        public static String file_config;
        Kapcha kp = new Kapcha();
        String bez_povtorov = "";
        String bez_povtorov_owner_id = "";
        public int filter_text_bad = 0;
        public static String uri_kapcha = "";
        // public static String sid_kapcha = "";
        public static int one_raz_ne_pidoras1 = 0;
        public static int one_raz_ne_pidoras2 = 0;
        String richbox4 = "";

        DateTime unixTime; //
       



        public Osnova()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 4;
            this.MaximizeBox = false;




            menuStrip1.BringToFront();

            //this.comboBox1.Items.AddRange(new object[] {"Без вложений",
            //            "Фото",
            //            "Видео",
            //            "Аудио",
            //            "Документ",
            //            "Граффити",
            //            "Ссылка",
            //            "Заметка",
            //            "Опрос",
            //            "Маркет"
            //});
            richTextBox1.DetectUrls = true;





            if (checkBox3.Checked == true)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }

            if (checkBox4.Checked == true)
            {
                textBox6.Enabled = true;
            }
            else
            {
                textBox6.Enabled = false;
            }


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "1234567")
            {
                textBox1.Text = "";
                textBox1.Font = new Font("Verdana", 10, FontStyle.Regular);
                textBox1.ForeColor = Color.Black;
            }
            ToolTip tt = new ToolTip();
            tt.IsBalloon = true;
            tt.InitialDelay = 2000;
            tt.ShowAlways = true;
            tt.SetToolTip(textBox1, "Введите ИД Вашей группы, только цифры");


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (richTextBox2.Text != "\"нормал* дизайнер\"(посоветуйте); \"нужн* помо*\"(дизайн);" && richTextBox4.Text != "Бла-бла-бла" && richTextBox3.Text != "ищу дизайнера; подскажите дизайнера; помогите с дизайном;")
            {


//                За всё время
//За 12 часов
//За день
//За 3 дня
//За неделю
//За месяц


                string selectedcomboBox2 = comboBox2.SelectedItem.ToString();
                if (selectedcomboBox2 == "За всё время") {
                   // unixTime = 0;
                    unixTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(0);
                }
                if (selectedcomboBox2 == "За 12 часов")
                {
                    int unixTime1 = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 43200;
                   unixTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(unixTime1);
                }
                if (selectedcomboBox2 == "За день")
                {
                    int unixTime1 = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 86400;
                    unixTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(unixTime1);
                }
                if (selectedcomboBox2 == "За 3 дня")
                {
                    int unixTime1 = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 259200;
                    unixTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(unixTime1);
                }
                if (selectedcomboBox2 == "За неделю")
                {
                    int unixTime1 = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 604800;
                    unixTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(unixTime1);
                }
                if (selectedcomboBox2 == "За месяц")
                {
                    int unixTime1 = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 2592000;
                    unixTime = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(unixTime1);
                }




              
              
                


                richbox4 = richTextBox4.Text;

                stop = 0;
                if (Avtorizacia.demo == 1)
                {
                    if (checkBox3.Checked == true)
                    {
                        var post = Avtorizacia.api.Wall.Post(new WallPostParams
                        {
                            OwnerId = Convert.ToInt64("-" + textBox1.Text),

                            FromGroup = false,
                            Message = "Вы используете демо версию!\n EPVK - Программное решение для продвижения любых, даже самых узкоспециализированных товаров/услуг/сообществ\n Подробнее в группе https://vk.com/epvk_project \n(приобретите полную версию программы, что бы это сообщение не появлялось)",
                        });
                    }
                    else
                    {
                        var post = Avtorizacia.api.Wall.Post(new WallPostParams
                        {
                            OwnerId = Avtorizacia.my_id,

                            FromGroup = false,
                            Message = "Вы используете демо версию!\n EPVK - Программное решение для продвижения любых, даже самых узкоспециализированных товаров/услуг/сообществ\n Подробнее в группе https://vk.com/epvk_project \n(приобретите полную версию программы, что бы это сообщение не появлялось)",
                        });
                    }


                }

                nugnie_posts = "";
                find_post_kolichestvo = 0;
                bez_povtorov = "";
                bez_povtorov_owner_id = "";





                progressBar1.Visible = true;

                progressBar1.Minimum = 0;

                progressBar1.Maximum = 800;
                progressBar1.Value = 1;

                progressBar1.Step = 1;
                Thread myThread = new Thread(Get_search_news);
                myThread.Start();

                while (myThread.IsAlive)
                {
                    Application.DoEvents();                //КОСТЫЛЬ Ждать выполнение доп потока 
                                                           //  Thread.Sleep(1000);

                }
                proverka_formirovania_text_filter();
                if (filter_text_bad == 0)
                {
                    Thread myThread2 = new Thread(create_comment);
                    myThread2.Start();
                }
                else {
                    label7.Text = "Ошибка формирования фильтров";
                }




                filter_text_bad = 0;





            }
            else { MessageBox.Show("Заполните все поля", "Заполнены не все поля!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification); }

        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            stop = 1;
        }

        private void Osnova_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Show();
            WindowState = FormWindowState.Normal;

        }

        private void Osnova_Resize_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                Hide();

            Console.WriteLine("Svernuli v trey");
            notifyIcon1.BalloonTipTitle = "EPVK";
            notifyIcon1.BalloonTipText = "Программа была спрятана в трей и продолжит свою работу.";
            // notifyIcon1.ShowBalloonTip(5000); // Параметром указываем количество миллисекунд, которое будет показываться подсказка

        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
            WebBrows wb = new WebBrows();
            wb.Show();
        }



        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //public void post_ocnova()
        //{                    // МЕТОД ДЛЯ УВЕДОМЛЯЛКИ НИЧЕГО НЕ ВЫШЛО, НЕ ИСПОЛЬЗУЮ. НО ПРИГОДИТСЯ.
        //    int max_list = System.IO.File.ReadAllLines(patch_file_open).Length;
        //    int vxod_id_v_peremen = 1;
        //    String five_id = "";
        //    String post_id_for_del = "";

        //    for (int i = 0; i < max_list; i++)
        //    {

        //        BeginInvoke(new MethodInvoker(delegate
        //        {



        //            label4.Text = max_list.ToString();
        //            label5.Text = i.ToString();
        //            label7.Text = Convert.ToString((i * 100) / (max_list + 1) + " %");
        //            progressBar1.Value = (i * 100) / (max_list + 1);




        //        }));










        //        if (stop == 1 || i == max_list - 1)
        //        {


        //            BeginInvoke(new MethodInvoker(delegate
        //            {
        //                progressBar1.Value = (100);
        //                label7.Text = "Завершено!";
        //                if (stop == 1)
        //                {
        //                    label5.Text = "Прервано";
        //                    i = max_list - 1;
        //                }
        //            }));

        //            var lines = File.ReadLines(patch_file_open).Skip(i);
        //            File.WriteAllLines(patch_file_open + "_temp.txt", lines);
        //            File.Delete(patch_file_open);





        //        }

        //        if (File.Exists(patch_file_open) == true)
        //        {
        //            string secondLine = File.ReadLines(patch_file_open).Skip(i).First();


        //            if (secondLine != "")
        //            {
        //                //Console.WriteLine("secondLine !=null "+ secondLine);

        //                if (vxod_id_v_peremen <= 4) //тут будем ловить 4 вхождений ид и записывать в переменную
        //                {
        //                    five_id = five_id + " @id" + secondLine;

        //                    // Console.WriteLine("vxod_id_v_peremen <= 5 " + secondLine);

        //                    if (vxod_id_v_peremen == 4)           //тут основные действия
        //                    {
        //                        Thread.Sleep(Convert.ToInt32(textBox4.Text) * 1000);
        //                        Console.WriteLine(five_id);

        //                        try
        //                        {
        //                            var post = Avtorizacia.api.Wall.Post(new WallPostParams
        //                            {
        //                                OwnerId = Convert.ToInt64("-" + textBox1.Text),

        //                                FromGroup = false,
        //                                Message = five_id + " " + richTextBox4.Text,
        //                            }).ToString();
        //                            foreach (var g in post)
        //                            {
        //                                String s = g.ToString();
        //                                post_id_for_del = post_id_for_del + s;

        //                            }
        //                            Console.WriteLine("post_id_for_del " + Convert.ToUInt32(post_id_for_del) + " id_group " + Convert.ToInt64("-" + textBox1.Text));

        //                            var delete = Avtorizacia.api.Wall.Delete(Convert.ToInt64("-" + textBox1.Text), Convert.ToUInt32(post_id_for_del));

        //                            post_id_for_del = "";



        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            MessageBox.Show(ex.Message, "Ошибка: ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);


        //                        }


        //                    }
        //                    vxod_id_v_peremen++;
        //                }
        //                else
        //                {

        //                    //  Console.WriteLine("vxod_id_v_peremen > 5 " + secondLine);
        //                    vxod_id_v_peremen = 1;
        //                    five_id = "";
        //                    i--;

        //                }

        //            }
        //            else
        //            {
        //                // Console.WriteLine("secondLine ======= null"); //пропускаем если пустая строка в списке
        //            }
        //        }
        //        else
        //        {
        //            var lines2 = File.ReadLines(patch_file_open + "_temp.txt").Skip(0);
        //            File.WriteAllLines(patch_file_open, lines2);
        //            File.Delete(patch_file_open + "_temp.txt");

        //        }
        //    }
        //} // МЕТОД ДЛЯ УВЕДОМЛЯЛКИ НИЧЕГО НЕ ВЫШЛО, НЕ ИСПОЛЬЗУЮ. НО ПРИГОДИТСЯ.

        private void button5_Click(object sender, EventArgs e)
        {
            var who = (dynamic)null;
            var getComments = Avtorizacia.api.Wall.GetComments(new WallGetCommentsParams
            {
                OwnerId = -75514519,
                PostId = 5206,
                Count = 100,
                Sort = VkNet.Enums.SortOrderBy.Desc,
            });
            foreach (var g in getComments)
            {
                who = g.FromId;
                Console.WriteLine(who);

                //тут условие
                if (Avtorizacia.my_id == who || Convert.ToInt32("-" + textBox1.Text) == who)
                {
                    Console.WriteLine("УЖЕ ЕСТЬ коммент");
                }

            };


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        public void Get_search_news()
        {                                                             //ищем посты по параметрам из формы
            try
            {
                String searh_word_temp = "";
                string searh_word = "";
                int max_variant_word = 0;




                Invoke(new MethodInvoker(delegate
                {

                    String RT1 = richTextBox2.Text;
                    RT1 = RT1.Trim();
                    Console.WriteLine("RT=" + RT1 + "=RT");
                    String tmp2 = RT1.Substring(RT1.Length - 1);
                    if (tmp2 == ";")
                    {
                        richTextBox2.Text = RT1.Remove(RT1.Length - 1).Trim();
                    }



                    String RT = richTextBox3.Text;
                    RT = RT.Trim();
                    Console.WriteLine("RT=" + RT + "=RT");
                    String tmp1 = RT.Substring(RT.Length - 1);
                    if (tmp1 == ";")
                    {
                        richTextBox3.Text = RT.Remove(RT.Length - 1).Trim();
                    }

                    foreach (Match m in Regex.Matches(richTextBox3.Text, "\\;"))
                        max_variant_word++;




                    for (int words = 0; words <= max_variant_word; words++)
                    {


                        searh_word_temp = richTextBox3.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[words];
                        // searh_word = Regex.Match(searh_word_temp, @"(?<=\"")(.*?)(?=\"")").ToString().Replace("*", "");
                        searh_word = searh_word_temp.Trim();
                        Console.WriteLine(searh_word + " ALO EBAT searh_word");





                        for (int five = 0; five <= 4; five++)
                        {


                            label7.Text = "Идет поиск записей..";
                            progressBar1.Value = (five + five) * 100;


                            Console.WriteLine("unixTime   "+ unixTime);

                            var search = Avtorizacia.api.NewsFeed.Search(new NewsFeedSearchParams
                            {
                                Query = searh_word,
                                Extended = true,
                                Count = 200,
                                Fields = VkNet.Enums.Filters.UsersFields.CanPost,
                                StartTime = unixTime,
                                StartFrom = (five + five) * 100

                            });




                            //var search2 = Avtorizacia.api.NewsFeed.Search(new NewsTypes);
                            String attach = "";
                            String attach_massiv = "";
                            String all_post = "";
                            String no_attach_str = "";
                            String all_post_massiv = "";


                            foreach (var g in search)
                            {
                                var type = g.PostType.ToString();
                                if (type == "post")
                                {

                                    Boolean can_post = g.Comments.CanPost;
                                    var can_post_group = g.Comments.GroupsCanPost;
                                    var count = g.Comments.Count;
                                    var post_type = g.PostType;
                                    var owner_id = g.OwnerId;
                                    var post_id = g.Id;
                                    var like_post = g.Likes.Count;
                                    var from_id = g.FromId;


                                    //Console.WriteLine("can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ^=  ");
                                    all_post = "Comm_id= 0 Type= " + post_type + " From_id= " + from_id + " Like= " + like_post + " can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ^=  ";
                                    // Console.WriteLine("Не выбрано " + all_post + " Не выбрано ");


                                    all_post_massiv += all_post + Environment.NewLine; //Все


                                    foreach (var p in g.Attachments)
                                    {
                                        var type_attachments = p.Type.Name;
                                        //  Console.WriteLine("Like= " + like_post + " can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ^=  " + type_attachments);
                                        attach = "Comm_id= 0 Type = " + post_type + " From_id= " + from_id + " Like= " + like_post + " can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ^=  ";
                                        String temp_attach = "Comm_id= 0 Type= " + post_type + " From_id= " + from_id + " Like= " + like_post + " can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ==  " + type_attachments;
                                        attach_massiv += temp_attach + Environment.NewLine; //
                                    }

                                    String[] substrings = all_post.Split('\n');
                                    foreach (var substring in substrings) { }
                                    String[] substrings2 = attach.Split('\n');
                                    foreach (var substring2 in substrings2) { }
                                    var no_attach = substrings.Except(substrings2).ToList();
                                    //   no_attach.ForEach(Console.WriteLine); // No attach


                                    StringBuilder sb = new StringBuilder();
                                    foreach (var ch in no_attach)
                                    {
                                        if (ch != "")
                                        {
                                            sb.Append(ch.ToString());
                                            no_attach_str += sb.ToString() + Environment.NewLine; //без вложений!!!
                                                                                                  //  no_attach_str = String.Join(" ", sb.ToString());




                                        }



                                        // Console.WriteLine(sb.ToString());
                                    }


                                }

                                else {

                                    Boolean can_post = g.Comments.CanPost;
                                    var can_post_group = g.Comments.GroupsCanPost;
                                    var count = g.Comments.Count;
                                    var post_type = g.PostType;
                                    var owner_id = g.OwnerId;
                                    var post_id = g.PostId;
                                    var like_post = g.Likes.Count;
                                    var from_id = g.FromId;
                                    var comment_id = g.Id;


                                    //Console.WriteLine("can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ^=  ");
                                    all_post = "Comm_id= " + comment_id + " Type= " + post_type + " From_id= " + from_id+ " Like= " + like_post + " can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ^=  ";
                                    // Console.WriteLine("Не выбрано " + all_post + " Не выбрано ");


                                    all_post_massiv += all_post + Environment.NewLine; //Все


                                    foreach (var p in g.Attachments)
                                    {
                                        var type_attachments = p.Type.Name;
                                        //  Console.WriteLine("Like= " + like_post + " can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ^=  " + type_attachments);
                                        attach = "Comm_id= " + comment_id + " Type= " + post_type + " From_id= " + from_id + " Like= " + like_post + " can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ^=  ";
                                        String temp_attach = "Comm_id= " + comment_id + " Type= " + post_type + " From_id= " + from_id + " Like= " + like_post + " can_post= " + can_post + " can_post_group= " + can_post_group + " count= " + count + "   |   https://vk.com/wall" + owner_id + "_" + post_id + "  АТАЧМЕНТ==  " + type_attachments;
                                        attach_massiv += temp_attach + Environment.NewLine; //
                                    }

                                    String[] substrings = all_post.Split('\n');
                                    foreach (var substring in substrings) { }
                                    String[] substrings2 = attach.Split('\n');
                                    foreach (var substring2 in substrings2) { }
                                    var no_attach = substrings.Except(substrings2).ToList();
                                    //   no_attach.ForEach(Console.WriteLine); // No attach


                                    StringBuilder sb = new StringBuilder();
                                    foreach (var ch in no_attach)
                                    {
                                        if (ch != "")
                                        {
                                            sb.Append(ch.ToString());
                                            no_attach_str += sb.ToString() + Environment.NewLine; //без вложений!!!
                                                                                                  //  no_attach_str = String.Join(" ", sb.ToString());




                                        }



                                        // Console.WriteLine(sb.ToString());
                                    }


                                }

                            }
                            Console.WriteLine("no_attach_str " + no_attach_str);



                            Console.WriteLine("ALLO EBATb mi v filtrax ");


                            string selectedcomboBox1 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox1 == "Не выбрано")
                            {
                                // Console.WriteLine("Не выбрано " + all_post_massiv + " Не выбрано ");
                                nugnie_posts += all_post_massiv;

                            }

                            string selectedcomboBox2 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox2 == "Без вложений")
                            {
                                // Console.WriteLine(no_attach_str);
                                nugnie_posts += no_attach_str;
                            }

                            string selectedcomboBox3 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox3 == "Фото")
                            {

                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bPhoto\\b");
                                    if (result == true)
                                    {
                                        //Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }




                            }





                            string selectedcomboBox4 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox4 == "Видео")
                            {
                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bVideo\\b");
                                    if (result == true)
                                    {
                                        //  Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }
                            }







                            //Опрос
                            //Маркет

                            string selectedcomboBox5 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox5 == "Аудио")
                            {
                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bAudio\\b");
                                    if (result == true)
                                    {
                                        // Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }
                            }

                            string selectedcomboBox6 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox6 == "Документ")
                            {
                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bDocument\\b");
                                    if (result == true)
                                    {
                                        // Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }
                            }

                            string selectedcomboBox7 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox7 == "Граффити")
                            {
                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bGraffiti\\b");
                                    if (result == true)
                                    {
                                        // Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }
                            }

                            string selectedcomboBox8 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox8 == "Ссылка")
                            {
                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bLink\\b");
                                    if (result == true)
                                    {
                                        // Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }
                            }

                            string selectedcomboBox9 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox9 == "Заметка")
                            {
                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bNote\\b");
                                    if (result == true)
                                    {
                                        // Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }
                            }

                            string selectedcomboBox10 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox10 == "Опрос")
                            {
                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bPoll\\b");
                                    if (result == true)
                                    {
                                        // Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }
                            }

                            string selectedcomboBox11 = comboBox1.SelectedItem.ToString(); //чекаем че выбрали в комбобоксе
                            if (selectedcomboBox11 == "Маркет")
                            {
                                int k = attach_massiv.Split('\n').Count();

                                for (int i = 1; i < k - 1; i++)
                                {
                                    string happy2 = attach_massiv.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");
                                    bool result = Regex.IsMatch(happy2, "\\bMarket\\b");
                                    if (result == true)
                                    {
                                        // Console.WriteLine(happy2);
                                        nugnie_posts += happy2 + Environment.NewLine;
                                    }


                                }
                            }

                            label7.Text = "Поиск завершен, подождите...";







                        }

                    }
                }));
            }
            catch (Exception e)
            {
                Msg.MessageError(e, this.Text);
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            //ToolTip tt = new ToolTip();
            //tt.IsBalloon = true;
            //tt.InitialDelay = 2000;
            //tt.ShowAlways = true;
            //tt.SetToolTip(richTextBox2, "Набор слов/фраз для поиска через точку-запятую ;");
        }

        public void create_comment()
        {
            try
            {

                Console.WriteLine("get sersh ===== " + nugnie_posts);

                //Удаляем повторы одинаковые посты
                List<string> lst = new List<string>();
                int max_variant_post_posle_filter = 0;
                foreach (Match m in Regex.Matches(nugnie_posts, "\n"))
                    max_variant_post_posle_filter++;

                int poschitaem_kol_postov_posle_vsex_filtrov = 0;

                for (int i = 0; i < max_variant_post_posle_filter; i++)
                {
                    string searh_word = nugnie_posts.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[i].Replace("\r", "");

                    String povtor_off = searh_word.Substring(0, searh_word.IndexOf('Ч') + 1); // 

                    lst.Add(povtor_off);
                    lst = lst.Distinct().ToList();
                }
                lst.ForEach(delegate (String ss)
                {



                    bez_povtorov += ss + Environment.NewLine;

                });

                Console.WriteLine("bez_povtorov==============" + bez_povtorov);

                var result = bez_povtorov.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries). // Удаляем овнер ид повторы спасибо форуму
                   GroupBy(x => Regex.Match(x, @"wall(.*?)_").Groups[1].ToString()).Select(x => x.FirstOrDefault()).ToList();
                foreach (var item in result)
                {
                    find_post_kolichestvo++;
                    bez_povtorov_owner_id += item + Environment.NewLine;
                    //Console.WriteLine(Regex.Match(item, @"(?<=wall)(.*?)(?=_)").ToString());
                }



                BeginInvoke(new MethodInvoker(delegate
                {
                    label4.Text = find_post_kolichestvo.ToString();
                }));




                // фильтр по осталным парам
                int max_variant_post_filter = 0;
                int obrab_variant_post_filter = 0;
                int from_my_group;
                if (checkBox3.Checked == true)
                {
                    from_my_group = Convert.ToInt32(textBox1.Text);
                }
                else { from_my_group = 0; }
                foreach (Match m in Regex.Matches(bez_povtorov_owner_id, "\n"))
                    max_variant_post_filter++;
                for (int f = 0; f < max_variant_post_filter; f++)
                {
                    string searh_word = bez_povtorov_owner_id.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[f].Replace("\r", "");

                    String Like = Regex.Match(searh_word, @"(?<=Like\= )(.*?)(?= can_post\=)").ToString();
                    //  Console.WriteLine("Like " + Like);
                    String can_post = Regex.Match(searh_word, @"(?<=can_post\= )(.*?)(?= can_post_group)").ToString();
                    //  Console.WriteLine("can_post " + can_post);
                    String can_post_group = Regex.Match(searh_word, @"(?<=can_post_group\= )(.*?)(?= count\=)").ToString();
                    //  Console.WriteLine("can_post_group " + can_post_group);
                    String count = Regex.Match(searh_word, @"(?<=count\= )(.*?)(?=   \|)").ToString();
                    //  Console.WriteLine("count " + count);
                    String owner_id = Regex.Match(searh_word, @"(?<=wall)(.*?)(?=_)").ToString();
                    //  Console.WriteLine("owner_id " + owner_id);
                    String post_id = Regex.Match(searh_word, @"(?<=" + owner_id + "_)(.*?)(?=  АТАЧ)").ToString();
                    //  Console.WriteLine("owner_id " + post_id);


                    // нахуярить условия тут
                    String eboy = owner_id.Substring(0, 1);
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        if (checkBox1.Checked == true && checkBox2.Checked == false)
                        {      //soobwestva
                            if (eboy == "-")
                            {


                                if (Convert.ToInt32(Like) >= Convert.ToInt32(textBox5.Text))
                                {

                                    if (Convert.ToInt32(count) >= Convert.ToInt32(textBox3.Text))
                                    {

                                        if (can_post == "True" && can_post_group == "True")
                                        {
                                            poschitaem_kol_postov_posle_vsex_filtrov++;
                                            Console.WriteLine("oschitaem_kol_postov_posle_vsex_filtrov= " + poschitaem_kol_postov_posle_vsex_filtrov);



                                            BeginInvoke(new MethodInvoker(delegate
                                        {
                                            label4.Text = poschitaem_kol_postov_posle_vsex_filtrov.ToString();
                                        }));

                                        }


                                    }

                                }

                            }
                        }  //просто считает кол-во постов после всех фильтров
                        if (checkBox1.Checked == false && checkBox2.Checked == true)
                        {
                            //profile
                            if (eboy != "-")
                            {
                                if (Convert.ToInt32(Like) >= Convert.ToInt32(textBox5.Text))
                                {

                                    if (Convert.ToInt32(count) >= Convert.ToInt32(textBox3.Text))
                                    {
                                        if (can_post == "True" && can_post_group == "True")
                                        {

                                            //   Console.WriteLine(searh_word);
                                            poschitaem_kol_postov_posle_vsex_filtrov++;


                                            label4.Text = poschitaem_kol_postov_posle_vsex_filtrov.ToString();

                                        }

                                    }

                                }
                            }
                        } //просто считает кол-во постов после всех фильтров
                        if (checkBox1.Checked == true && checkBox2.Checked == true)
                        {
                            //soobwestva + profile
                            if (Convert.ToInt32(Like) >= Convert.ToInt32(textBox5.Text))
                            {

                                if (Convert.ToInt32(count) >= Convert.ToInt32(textBox3.Text))
                                {
                                    if (can_post == "True" && can_post_group == "True")
                                    {
                                        //   Console.WriteLine(searh_word);
                                        poschitaem_kol_postov_posle_vsex_filtrov++;


                                        label4.Text = poschitaem_kol_postov_posle_vsex_filtrov.ToString();

                                    }

                                }

                            }

                        } //просто считает кол-во постов после всех фильтров
                    }));
                } //Костыль, считаем кол-во всех постов после всех фильтров

                BeginInvoke(new MethodInvoker(delegate
                {
                    progressBar1.Maximum = poschitaem_kol_postov_posle_vsex_filtrov;

                }));


                for (int f = 0; f < max_variant_post_filter; f++)
                {
                    try
                    {

                        string searh_word = bez_povtorov_owner_id.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)[f].Replace("\r", "");

                        String Comm_id = Regex.Match(searh_word, @"(?<=Comm_id\= )(.*?)(?= Type\=)").ToString();
                        String Type = Regex.Match(searh_word, @"(?<=Type\= )(.*?)(?= From_id\=)").ToString();
                        String From_id = Regex.Match(searh_word, @"(?<=From_id\= )(.*?)(?= Like\=)").ToString();
                        String Like = Regex.Match(searh_word, @"(?<=Like\= )(.*?)(?= can_post\=)").ToString();
                        //  Console.WriteLine("Like " + Like);
                        String can_post = Regex.Match(searh_word, @"(?<=can_post\= )(.*?)(?= can_post_group)").ToString();
                        //  Console.WriteLine("can_post " + can_post);
                        String can_post_group = Regex.Match(searh_word, @"(?<=can_post_group\= )(.*?)(?= count\=)").ToString();
                        //  Console.WriteLine("can_post_group " + can_post_group);
                        String count = Regex.Match(searh_word, @"(?<=count\= )(.*?)(?=   \|)").ToString();
                        //  Console.WriteLine("count " + count);
                        String owner_id = Regex.Match(searh_word, @"(?<=wall)(.*?)(?=_)").ToString();
                        //  Console.WriteLine("owner_id " + owner_id);
                        String post_id = Regex.Match(searh_word, @"(?<=" + owner_id + "_)(.*?)(?=  АТАЧ)").ToString();
                        //  Console.WriteLine("owner_id " + post_id);


                        // нахуярить условия тут
                        String eboy = owner_id.Substring(0, 1);






                        if (checkBox1.Checked == true && checkBox2.Checked == false)
                        {      //soobwestva
                            if (eboy == "-")
                            {


                                if (Convert.ToInt32(Like) >= Convert.ToInt32(textBox5.Text))
                                {

                                    if (Convert.ToInt32(count) >= Convert.ToInt32(textBox3.Text))
                                    {
                                        if (can_post == "True" && can_post_group == "True")
                                        {
                                            obrab_variant_post_filter++;
                                            Console.WriteLine(searh_word);

                                            var who = (dynamic)null;
                                            int propuskaem = 0;
                                            try
                                            {
                                                var getComments = Avtorizacia.api.Wall.GetComments(new WallGetCommentsParams
                                                {
                                                    OwnerId = Convert.ToInt32(owner_id),
                                                    PostId = Convert.ToInt32(post_id),
                                                    Count = 100,
                                                    Sort = VkNet.Enums.SortOrderBy.Desc,
                                                });
                                                foreach (var g in getComments)
                                                {
                                                    who = g.FromId;
                                                    //Console.WriteLine(who);

                                                    //тут условие
                                                    if (Avtorizacia.my_id == who || Convert.ToInt32("-" + textBox1.Text) == who)
                                                    {
                                                        propuskaem = 1;


                                                    }

                                                };
                                            }
                                            catch (Exception e)
                                            {
                                                propuskaem = 1;
                                            }


                                            if (Type == "reply")
                                            {
                                                var getComments = Avtorizacia.api.Wall.GetComments(new WallGetCommentsParams
                                                {
                                                    OwnerId = Convert.ToInt32(owner_id),
                                                    PostId = Convert.ToInt32(post_id),
                                                    StartCommentId = Convert.ToInt32(Comm_id),
                                                    Count = 1,
                                                    // Sort = VkNet.Enums.SortOrderBy.Desc,
                                                });

                                                foreach (var g in getComments)
                                                {
                                                    text_posts = g.Text;

                                                };

                                            }

                                            else
                                            {

                                                IEnumerable<String> m_oEnum = new string[] { owner_id + "_" + post_id };

                                                var getbyid = Avtorizacia.api.Wall.GetById(

                                                 posts: m_oEnum,
                                                 extended: false,
                                                 copyHistoryDepth: 0

                                                    ).WallPosts;

                                                foreach (var tex in getbyid)
                                                {


                                                    text_posts = tex.Text;

                                                }

                                            }

                                            // ТУТ анализ текста
                                            int max_variant_word = 0;

                                            Console.WriteLine("TEXT WALL/COMM== "+text_posts);

                                            //  String s1 = "123123 группа только ищу фото группа начинает г заполняться,  ищу не пугайтесь.    Балаково      ВстуПайТе,      поддерживайте! Балаково фото лайками, репостами, Помогите! своей любовью ❤ Зовите сюда своих друзей и знакомых.  раскрут, груп 123213  =)";
                                            //  String s2 = "Группа только начинает заполняться, не пугайтесь. подДерживайте лайками ВстуПайте, репостами, своей любовью ❤ Зовите сюда своих друзей и знакомых. ";
                                            String find_word = "";
                                            Console.WriteLine(max_variant_word);
                                            String RTB2 = "";
                                            Invoke(new MethodInvoker(delegate
                                            {
                                                RTB2 = richTextBox2.Text;
                                            }));
                                            if (propuskaem == 0)
                                            {

                                                propuskaem = 1;

                                                foreach (Match m in Regex.Matches(RTB2, "\\;"))
                                                    max_variant_word++;

                                                for (int i = 0; i <= max_variant_word; i++)
                                                {

                                                    find_word = RTB2.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[i];
                                                    Console.WriteLine(find_word + " ALO EBAT v delegate!");
                                                    Console.WriteLine(RTB2 + " richTextBox2.Text");



                                                    Console.WriteLine(find_word + "ALO EBAT!");
                                                    bool no_find = true;

                                                    String kovichki = Regex.Match(find_word, @"(?<=\"")(.*?)(?=\"")").ToString().Trim();
                                                    bool dva_slova = Regex.IsMatch(kovichki, "\\w* \\w*", RegexOptions.IgnoreCase);
                                                    if (dva_slova == true) //Если у нас два слова
                                                    {
                                                        String one_slovo = Regex.Match(kovichki, @"(?<=^)(.*?)(?= )").ToString();
                                                        String two_slovo = Regex.Match(kovichki, @"(?<= )(.*?)(?=$)").ToString();

                                                        if (one_slovo.IndexOf("*") > -1) //если есть звездочка в 1 слове добавляем регялрку
                                                        {
                                                            one_slovo = one_slovo.Replace("*", "\\w*");
                                                            //  Console.WriteLine("Вхождения найдены " + one_slovo); // 
                                                        }
                                                        if (two_slovo.IndexOf("*") > -1) ////если есть звездочка в 2 слове добавляем регялрку
                                                        {
                                                            two_slovo = two_slovo.Replace("*", "\\w*");
                                                            //    Console.WriteLine("Вхождения найдены " + two_slovo); // 

                                                        }

                                                        String pattern_two_slov = "";
                                                        String pattern_two_slov2 = "";
                                                        String all_zapros = Regex.Match(find_word, @"(?<=^)(.*?)(?=$)").ToString().Trim();

                                                        bool dop_slovo = Regex.IsMatch(all_zapros, "\\([\\d\\D]*\\)", RegexOptions.IgnoreCase);

                                                        if (dop_slovo == true) //есть есть доп слово
                                                        {
                                                            String dop_slovo_text = Regex.Match(all_zapros, @"(?<=\()(.*?)(?=\))").ToString().Trim();

                                                            pattern_two_slov = dop_slovo_text + @"[\d\D]* \b" + one_slovo + @"\W*\S*" + two_slovo + @"\b";

                                                            pattern_two_slov2 = @"\b" + one_slovo + @"\W*\S*" + two_slovo + @"\b[\d\D]*" + dop_slovo_text;

                                                            bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);
                                                            bool res2 = Regex.IsMatch(text_posts, pattern_two_slov2, RegexOptions.IgnoreCase);


                                                            /// Console.WriteLine("Доп слово слева " + pattern_two_slov + "\nДоп слово спава " + pattern_two_slov2 +" "+res1 + " " + res2);


                                                            if (res1 == true || res2 == true)
                                                            {
                                                                Console.WriteLine("НУЖНЫЙ ПОСТ! 2 slova + dop slovo " + one_slovo + " " + two_slovo + " " + dop_slovo_text);
                                                                no_find = false;
                                                                propuskaem = 0;

                                                            }


                                                        }
                                                        else
                                                        { //если нет доп слово



                                                            pattern_two_slov = @"\b" + one_slovo + @"\W*\S*" + two_slovo + @"\b";



                                                            bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);



                                                            //  Console.WriteLine("bez Доп слово слева " + pattern_two_slov );


                                                            if (res1 == true)
                                                            {
                                                                Console.WriteLine("НУЖНЫЙ ПОСТ 2 slova bez dop slova! " + one_slovo + " " + two_slovo);
                                                                no_find = false;
                                                                propuskaem = 0;
                                                            }

                                                        }


                                                        //Console.WriteLine("dop_slovo " + dop_slovo); // 



                                                    }
                                                    else
                                                    {  //Если Одно слово
                                                        String one_slovo = Regex.Match(kovichki, @"(?<=^)(.*?)(?=$)").ToString().Trim();
                                                        if (one_slovo.IndexOf("*") > -1)
                                                        {
                                                            one_slovo = one_slovo.Replace("*", "\\w*");
                                                            //   Console.WriteLine("Вхождения найдены " + one_slovo); // 
                                                        }


                                                        String all_zapros = Regex.Match(find_word, @"(?<=^)(.*?)(?=$)").ToString().Trim();

                                                        bool dop_slovo = Regex.IsMatch(all_zapros, "\\([\\d\\D]*\\)", RegexOptions.IgnoreCase);
                                                        String pattern_two_slov = "";
                                                        String pattern_two_slov2 = "";
                                                        if (dop_slovo == true) //есть есть доп слово
                                                        {
                                                            String dop_slovo_text = Regex.Match(all_zapros, @"(?<=\()(.*?)(?=\))").ToString().Trim();

                                                            pattern_two_slov = dop_slovo_text + @"[\d\D]* \b" + one_slovo + @"\b";

                                                            pattern_two_slov2 = @"\b" + one_slovo + @"\b[\d\D]*" + dop_slovo_text;

                                                            bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);
                                                            bool res2 = Regex.IsMatch(text_posts, pattern_two_slov2, RegexOptions.IgnoreCase);


                                                            //  Console.WriteLine("Доп слово слева " + pattern_two_slov + "\nДоп слово спава " + pattern_two_slov2 + " " + res1 + " " + res2);


                                                            if (res1 == true || res2 == true)
                                                            {
                                                                Console.WriteLine("НУЖНЫЙ ПОСТ! 1 SLOVO +dopslovo" + one_slovo + " " + dop_slovo_text);
                                                                no_find = false;
                                                                propuskaem = 0;
                                                            }
                                                        }

                                                        else
                                                        {
                                                            pattern_two_slov = @"\b" + one_slovo + @"\b";



                                                            bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);

                                                            if (res1 == true)
                                                            {
                                                                Console.WriteLine("НУЖНЫЙ ПОСТ bez dop slova 1 slovo!" + one_slovo + " ");
                                                                no_find = false;
                                                                propuskaem = 0;
                                                            }

                                                        }


                                                    }

                                                    if (no_find == true)
                                                    {
                                                        Console.WriteLine(" НЕ НАЙДЕНО СОВПАДЕНИЙ! ");
                                                    }







                                                }


                                                Console.WriteLine("propuskaem 1 да 0 нет================================== " + propuskaem);
                                                if (propuskaem != 1) //не равно 1 должно быть
                                                {

                                                    try
                                                    {

                                                        if (checkBox4.Checked == true)
                                                        {
                                                            var albumid = Convert.ToInt32(textBox6.Text);

                                                            var photos = Avtorizacia.api.Photo.Get(new PhotoGetParams
                                                            {
                                                                AlbumId = PhotoAlbumType.Id(albumid),
                                                                OwnerId = Avtorizacia.api.UserId.Value,

                                                            });


                                                            if (Type == "post")
                                                            {
                                                                var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                                {
                                                                    OwnerId = Convert.ToInt32(owner_id),
                                                                    PostId = Convert.ToInt32(post_id),
                                                                    FromGroup = from_my_group,
                                                                    Message = richbox4,
                                                                    // Guid = "1",
                                                                    Attachments = photos



                                                                }).ToString();

                                                                Console.WriteLine("asdasdasd " + addComment);
                                                                //String s=addComment.

                                                            }

                                                            else
                                                            {

                                                                String s = From_id.Substring(0, 1);
                                                                if (s == "-")
                                                                {
                                                                    From_id = From_id.Replace("-", "club");
                                                                }
                                                                else
                                                                {
                                                                    From_id = "id" + From_id;
                                                                }

                                                                var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                                {
                                                                    OwnerId = Convert.ToInt32(owner_id),
                                                                    PostId = Convert.ToInt32(post_id),
                                                                    FromGroup = from_my_group,
                                                                    Message = "[" + From_id + "|Hi!] " + richbox4,  // [id1 | Dur]

                                                                    // Guid = "1",
                                                                    Attachments = photos



                                                                }).ToString();

                                                                Console.WriteLine("asdasdasd MESSAGE " + addComment);
                                                                //String s=addComment.
                                                            }
                                                        }
                                                        else
                                                        {

                                                            if (Type == "post")
                                                            {

                                                                var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                                {
                                                                    OwnerId = Convert.ToInt32(owner_id),
                                                                    PostId = Convert.ToInt32(post_id),
                                                                    FromGroup = from_my_group,
                                                                    Message = richbox4,
                                                                    // Guid = "1",



                                                                }).ToString();

                                                                Console.WriteLine("asdasdasd " + addComment);

                                                            }

                                                            else
                                                            {
                                                                String s = From_id.Substring(0, 1);
                                                                if (s == "-")
                                                                {
                                                                    From_id = From_id.Replace("-", "club");
                                                                }
                                                                else
                                                                {
                                                                    From_id = "id" + From_id;
                                                                }
                                                                var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                                {
                                                                    OwnerId = Convert.ToInt32(owner_id),
                                                                    PostId = Convert.ToInt32(post_id),
                                                                    FromGroup = from_my_group,
                                                                    Message = "[" + From_id + "|Hi!] " + richbox4,  // [id1 | Dur]
                                                                    // Guid = "1",



                                                                }).ToString();

                                                                Console.WriteLine("asdasdasd " + addComment);

                                                            }

                                                        }


                                                    }
                                                    catch (VkNet.Exception.CaptchaNeededException e)
                                                    {
                                                        Console.WriteLine("CaptchaNeededException " + e.Sid + " " + e.Img);
                                                        // MessageBox.Show("CaptchaNeededException " + e.Sid + " " + e.Img + "\nПолучили капчу. Подождите минут 5-10 и запустите снова. \nВ Самом ближайшем фиксе будет реализован механизм ввода", "CaptchaNeededException");
                                                        // stop = 1;
                                                        uri_kapcha = e.Img.ToString();
                                                        // sid_kapcha = e.Sid.ToString();
                                                        //Thread.Sleep(300 * 1000);
                                                        Kapcha kp = new Kapcha();
                                                        kp.Show();

                                                        Thread myThread3 = new Thread(sleeper);
                                                        myThread3.Start();

                                                        while (myThread3.IsAlive)
                                                        {
                                                            Application.DoEvents();                //КОСТЫЛЬ Ждать выполнение доп потока 
                                                                                                   //  Thread.Sleep(1000);
                                                            if (kp.IsDisposed == true)
                                                            {
                                                                Console.WriteLine("kp.IsDisposed == true ");
                                                                break;
                                                            }

                                                        }

                                                        Console.WriteLine("Kapcha.key_kapcha " + Kapcha.key_kapcha);
                                                        try
                                                        {
                                                            var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                            {
                                                                OwnerId = Convert.ToInt32(owner_id),
                                                                PostId = Convert.ToInt32(post_id),
                                                                FromGroup = from_my_group,
                                                                Message = richbox4,
                                                                // Guid = "1",
                                                                CaptchaSid = e.Sid,
                                                                CaptchaKey = Kapcha.key_kapcha

                                                            }).ToString();
                                                        }
                                                        catch (VkNet.Exception.CaptchaNeededException t)
                                                        {

                                                        }



                                                    }
                                                    catch (VkNet.Exception.PublicServerErrorException ex)
                                                    {
                                                        Console.WriteLine("asdasdasd " + ex);
                                                        String s = ex.Message;
                                                        Console.WriteLine("s v IF popal " + s);

                                                        if (s == "Internal server error")
                                                        {
                                                            Console.WriteLine("s v IF popal " + s);
                                                            MessageBox.Show("Достигнуто ограничение вконтакте на кол-во комментариев, огрничение дейтсвует 12ч.", "Internal server error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            stop = 1;

                                                        }


                                                    }

                                                    catch (VkNet.Exception.ParameterMissingOrInvalidException ex)
                                                    {
                                                        MessageBox.Show("Ошибка доступа к альбому!\nНельзя использовать дефолтные альбомы. Создайте собственный", "album_id is invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                        stop = 1;
                                                    }

                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine("ОБЩАЯ ОШИБКА В МЕТОДЕ КРЕАТЕ КОМЕНТ");
                                                        Msg.MessageError(e, this.Text);
                                                    }


                                                }
                                                BeginInvoke(new MethodInvoker(delegate
                                                {
                                                    if (propuskaem != 1)
                                                    {
                                                        postavili_comment++;
                                                        richTextBox1.SelectionColor = Color.Green;
                                                        richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - комментарий добавлен\n");
                                                        label17.Text = postavili_comment.ToString();
                                                        if (postavili_comment == Convert.ToInt32(textBox2.Text)) { stop = 1; }




                                                    }
                                                    else
                                                    {
                                                        if (отображатьПропущенныеЗаписиToolStripMenuItem.Checked == true)
                                                        {
                                                            richTextBox1.SelectionColor = Color.Black;
                                                            richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - пропускаем, комментарий уже имеется или запись не соотвествует фильтрам\n");
                                                        }
                                                    }
                                                    label5.Text = obrab_variant_post_filter.ToString();
                                                    progressBar1.Value = obrab_variant_post_filter;
                                                    label7.Text = "Выполнено: " + (obrab_variant_post_filter * 100) / poschitaem_kol_postov_posle_vsex_filtrov + " %";


                                                }));

                                            }
                                            else
                                            {
                                                BeginInvoke(new MethodInvoker(delegate
                                                {
                                                    if (отображатьПропущенныеЗаписиToolStripMenuItem.Checked == true)
                                                    {
                                                        richTextBox1.SelectionColor = Color.Black;
                                                        richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - пропускаем, комментарий уже имеется или запись не соотвествует фильтрам\n");
                                                    }
                                                    label5.Text = obrab_variant_post_filter.ToString();
                                                    progressBar1.Value = obrab_variant_post_filter;
                                                    label7.Text = "Выполнено: " + (obrab_variant_post_filter * 100) / poschitaem_kol_postov_posle_vsex_filtrov + " %";
                                                }));
                                            }




                                            //конец анализа текста


                                            //Console.WriteLine("owner_id " + Convert.ToInt32(owner_id));
                                            //Console.WriteLine("post_id " + Convert.ToInt32(post_id));
                                            //Console.WriteLine("from_my_group " + from_my_group);
                                            //Console.WriteLine("textBox2.Text " + richTextBox4.Text);

                                            Thread.Sleep(Convert.ToInt32(textBox4.Text) * 1000);

                                        }



                                    }

                                }

                            }
                        }
                        if (checkBox1.Checked == false && checkBox2.Checked == true)
                        {
                            //profile
                            if (eboy != "-")
                            {


                                if (Convert.ToInt32(Like) >= Convert.ToInt32(textBox5.Text))
                                {

                                    if (Convert.ToInt32(count) >= Convert.ToInt32(textBox3.Text))
                                    {
                                        if (can_post == "True" && can_post_group == "True")
                                        {
                                            obrab_variant_post_filter++;
                                            Console.WriteLine(searh_word);

                                            var who = (dynamic)null;
                                            int propuskaem = 0;
                                            try
                                            {
                                                var getComments = Avtorizacia.api.Wall.GetComments(new WallGetCommentsParams
                                                {
                                                    OwnerId = Convert.ToInt32(owner_id),
                                                    PostId = Convert.ToInt32(post_id),
                                                    Count = 100,
                                                    Sort = VkNet.Enums.SortOrderBy.Desc,
                                                });
                                                foreach (var g in getComments)
                                                {
                                                    who = g.FromId;
                                                    //Console.WriteLine(who);

                                                    //тут условие
                                                    if (Avtorizacia.my_id == who || Convert.ToInt32("-" + textBox1.Text) == who)
                                                    {
                                                        propuskaem = 1;


                                                    }

                                                };
                                            }
                                            catch (Exception e)
                                            {
                                                propuskaem = 1;
                                            }


                                            if (Type == "reply")
                                            {
                                                var getComments = Avtorizacia.api.Wall.GetComments(new WallGetCommentsParams
                                                {
                                                    OwnerId = Convert.ToInt32(owner_id),
                                                    PostId = Convert.ToInt32(post_id),
                                                    StartCommentId = Convert.ToInt32(Comm_id),
                                                    Count = 1,
                                                    // Sort = VkNet.Enums.SortOrderBy.Desc,
                                                });

                                                foreach (var g in getComments)
                                                {
                                                    text_posts = g.Text;

                                                };

                                            }

                                            else
                                            {

                                                IEnumerable<String> m_oEnum = new string[] { owner_id + "_" + post_id };

                                                var getbyid = Avtorizacia.api.Wall.GetById(

                                                 posts: m_oEnum,
                                                 extended: false,
                                                 copyHistoryDepth: 0

                                                    ).WallPosts;

                                                foreach (var tex in getbyid)
                                                {


                                                    text_posts = tex.Text;

                                                }

                                            }

                                            // ТУТ анализ текста
                                            int max_variant_word = 0;

                                            Console.WriteLine("TEXT WALL/COMM== " + text_posts);

                                            //  String s1 = "123123 группа только ищу фото группа начинает г заполняться,  ищу не пугайтесь.    Балаково      ВстуПайТе,      поддерживайте! Балаково фото лайками, репостами, Помогите! своей любовью ❤ Зовите сюда своих друзей и знакомых.  раскрут, груп 123213  =)";
                                            //  String s2 = "Группа только начинает заполняться, не пугайтесь. подДерживайте лайками ВстуПайте, репостами, своей любовью ❤ Зовите сюда своих друзей и знакомых. ";
                                            String find_word = "";
                                            Console.WriteLine(max_variant_word);
                                            String RTB2 = "";
                                            Invoke(new MethodInvoker(delegate
                                            {
                                                RTB2 = richTextBox2.Text;
                                            }));
                                            if (propuskaem == 0)
                                            {

                                                propuskaem = 1;

                                                foreach (Match m in Regex.Matches(RTB2, "\\;"))
                                                    max_variant_word++;

                                                for (int i = 0; i <= max_variant_word; i++)
                                                {

                                                    find_word = RTB2.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[i];
                                                    Console.WriteLine(find_word + " ALO EBAT v delegate!");
                                                    Console.WriteLine(RTB2 + " richTextBox2.Text");



                                                    Console.WriteLine(find_word + "ALO EBAT!");
                                                    bool no_find = true;

                                                    String kovichki = Regex.Match(find_word, @"(?<=\"")(.*?)(?=\"")").ToString().Trim();
                                                    bool dva_slova = Regex.IsMatch(kovichki, "\\w* \\w*", RegexOptions.IgnoreCase);
                                                    if (dva_slova == true) //Если у нас два слова
                                                    {
                                                        String one_slovo = Regex.Match(kovichki, @"(?<=^)(.*?)(?= )").ToString();
                                                        String two_slovo = Regex.Match(kovichki, @"(?<= )(.*?)(?=$)").ToString();

                                                        if (one_slovo.IndexOf("*") > -1) //если есть звездочка в 1 слове добавляем регялрку
                                                        {
                                                            one_slovo = one_slovo.Replace("*", "\\w*");
                                                            //  Console.WriteLine("Вхождения найдены " + one_slovo); // 
                                                        }
                                                        if (two_slovo.IndexOf("*") > -1) ////если есть звездочка в 2 слове добавляем регялрку
                                                        {
                                                            two_slovo = two_slovo.Replace("*", "\\w*");
                                                            //    Console.WriteLine("Вхождения найдены " + two_slovo); // 

                                                        }

                                                        String pattern_two_slov = "";
                                                        String pattern_two_slov2 = "";
                                                        String all_zapros = Regex.Match(find_word, @"(?<=^)(.*?)(?=$)").ToString().Trim();

                                                        bool dop_slovo = Regex.IsMatch(all_zapros, "\\([\\d\\D]*\\)", RegexOptions.IgnoreCase);

                                                        if (dop_slovo == true) //есть есть доп слово
                                                        {
                                                            String dop_slovo_text = Regex.Match(all_zapros, @"(?<=\()(.*?)(?=\))").ToString().Trim();

                                                            pattern_two_slov = dop_slovo_text + @"[\d\D]* \b" + one_slovo + @"\W*\S*" + two_slovo + @"\b";

                                                            pattern_two_slov2 = @"\b" + one_slovo + @"\W*\S*" + two_slovo + @"\b[\d\D]*" + dop_slovo_text;

                                                            bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);
                                                            bool res2 = Regex.IsMatch(text_posts, pattern_two_slov2, RegexOptions.IgnoreCase);


                                                            /// Console.WriteLine("Доп слово слева " + pattern_two_slov + "\nДоп слово спава " + pattern_two_slov2 +" "+res1 + " " + res2);


                                                            if (res1 == true || res2 == true)
                                                            {
                                                                Console.WriteLine("НУЖНЫЙ ПОСТ! 2 slova + dop slovo " + one_slovo + " " + two_slovo + " " + dop_slovo_text);
                                                                no_find = false;
                                                                propuskaem = 0;

                                                            }


                                                        }
                                                        else
                                                        { //если нет доп слово



                                                            pattern_two_slov = @"\b" + one_slovo + @"\W*\S*" + two_slovo + @"\b";



                                                            bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);



                                                            //  Console.WriteLine("bez Доп слово слева " + pattern_two_slov );


                                                            if (res1 == true)
                                                            {
                                                                Console.WriteLine("НУЖНЫЙ ПОСТ 2 slova bez dop slova! " + one_slovo + " " + two_slovo);
                                                                no_find = false;
                                                                propuskaem = 0;
                                                            }

                                                        }


                                                        //Console.WriteLine("dop_slovo " + dop_slovo); // 



                                                    }
                                                    else
                                                    {  //Если Одно слово
                                                        String one_slovo = Regex.Match(kovichki, @"(?<=^)(.*?)(?=$)").ToString().Trim();
                                                        if (one_slovo.IndexOf("*") > -1)
                                                        {
                                                            one_slovo = one_slovo.Replace("*", "\\w*");
                                                            //   Console.WriteLine("Вхождения найдены " + one_slovo); // 
                                                        }


                                                        String all_zapros = Regex.Match(find_word, @"(?<=^)(.*?)(?=$)").ToString().Trim();

                                                        bool dop_slovo = Regex.IsMatch(all_zapros, "\\([\\d\\D]*\\)", RegexOptions.IgnoreCase);
                                                        String pattern_two_slov = "";
                                                        String pattern_two_slov2 = "";
                                                        if (dop_slovo == true) //есть есть доп слово
                                                        {
                                                            String dop_slovo_text = Regex.Match(all_zapros, @"(?<=\()(.*?)(?=\))").ToString().Trim();

                                                            pattern_two_slov = dop_slovo_text + @"[\d\D]* \b" + one_slovo + @"\b";

                                                            pattern_two_slov2 = @"\b" + one_slovo + @"\b[\d\D]*" + dop_slovo_text;

                                                            bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);
                                                            bool res2 = Regex.IsMatch(text_posts, pattern_two_slov2, RegexOptions.IgnoreCase);


                                                            //  Console.WriteLine("Доп слово слева " + pattern_two_slov + "\nДоп слово спава " + pattern_two_slov2 + " " + res1 + " " + res2);


                                                            if (res1 == true || res2 == true)
                                                            {
                                                                Console.WriteLine("НУЖНЫЙ ПОСТ! 1 SLOVO +dopslovo" + one_slovo + " " + dop_slovo_text);
                                                                no_find = false;
                                                                propuskaem = 0;
                                                            }
                                                        }

                                                        else
                                                        {
                                                            pattern_two_slov = @"\b" + one_slovo + @"\b";



                                                            bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);

                                                            if (res1 == true)
                                                            {
                                                                Console.WriteLine("НУЖНЫЙ ПОСТ bez dop slova 1 slovo!" + one_slovo + " ");
                                                                no_find = false;
                                                                propuskaem = 0;
                                                            }

                                                        }


                                                    }

                                                    if (no_find == true)
                                                    {
                                                        Console.WriteLine(" НЕ НАЙДЕНО СОВПАДЕНИЙ! ");
                                                    }







                                                }


                                                Console.WriteLine("propuskaem 1 да 0 нет================================== " + propuskaem);
                                                if (propuskaem != 1) //не равно 1 должно быть
                                                {

                                                    try
                                                    {

                                                        if (checkBox4.Checked == true)
                                                        {
                                                            var albumid = Convert.ToInt32(textBox6.Text);

                                                            var photos = Avtorizacia.api.Photo.Get(new PhotoGetParams
                                                            {
                                                                AlbumId = PhotoAlbumType.Id(albumid),
                                                                OwnerId = Avtorizacia.api.UserId.Value,

                                                            });


                                                            if (Type == "post")
                                                            {
                                                                var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                                {
                                                                    OwnerId = Convert.ToInt32(owner_id),
                                                                    PostId = Convert.ToInt32(post_id),
                                                                    FromGroup = from_my_group,
                                                                    Message = richbox4,
                                                                    // Guid = "1",
                                                                    Attachments = photos



                                                                }).ToString();

                                                                Console.WriteLine("asdasdasd " + addComment);
                                                                //String s=addComment.

                                                            }

                                                            else
                                                            {

                                                                String s = From_id.Substring(0, 1);
                                                                if (s == "-")
                                                                {
                                                                    From_id = From_id.Replace("-", "club");
                                                                }
                                                                else
                                                                {
                                                                    From_id = "id" + From_id;
                                                                }

                                                                var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                                {
                                                                    OwnerId = Convert.ToInt32(owner_id),
                                                                    PostId = Convert.ToInt32(post_id),
                                                                    FromGroup = from_my_group,
                                                                    Message = "[" + From_id + "|Hi!] " + richbox4,  // [id1 | Dur]

                                                                    // Guid = "1",
                                                                    Attachments = photos



                                                                }).ToString();

                                                                Console.WriteLine("asdasdasd MESSAGE " + addComment);
                                                                //String s=addComment.
                                                            }
                                                        }
                                                        else
                                                        {

                                                            if (Type == "post")
                                                            {

                                                                var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                                {
                                                                    OwnerId = Convert.ToInt32(owner_id),
                                                                    PostId = Convert.ToInt32(post_id),
                                                                    FromGroup = from_my_group,
                                                                    Message = richbox4,
                                                                    // Guid = "1",



                                                                }).ToString();

                                                                Console.WriteLine("asdasdasd " + addComment);

                                                            }

                                                            else
                                                            {
                                                                String s = From_id.Substring(0, 1);
                                                                if (s == "-")
                                                                {
                                                                    From_id = From_id.Replace("-", "club");
                                                                }
                                                                else
                                                                {
                                                                    From_id = "id" + From_id;
                                                                }
                                                                var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                                {
                                                                    OwnerId = Convert.ToInt32(owner_id),
                                                                    PostId = Convert.ToInt32(post_id),
                                                                    FromGroup = from_my_group,
                                                                    Message = "[" + From_id + "|Hi!] " + richbox4,  // [id1 | Dur]
                                                                    // Guid = "1",



                                                                }).ToString();

                                                                Console.WriteLine("asdasdasd " + addComment);

                                                            }

                                                        }


                                                    }
                                                    catch (VkNet.Exception.CaptchaNeededException e)
                                                    {
                                                        Console.WriteLine("CaptchaNeededException " + e.Sid + " " + e.Img);
                                                        // MessageBox.Show("CaptchaNeededException " + e.Sid + " " + e.Img + "\nПолучили капчу. Подождите минут 5-10 и запустите снова. \nВ Самом ближайшем фиксе будет реализован механизм ввода", "CaptchaNeededException");
                                                        // stop = 1;
                                                        uri_kapcha = e.Img.ToString();
                                                        // sid_kapcha = e.Sid.ToString();
                                                        //Thread.Sleep(300 * 1000);
                                                        Kapcha kp = new Kapcha();
                                                        kp.Show();

                                                        Thread myThread3 = new Thread(sleeper);
                                                        myThread3.Start();

                                                        while (myThread3.IsAlive)
                                                        {
                                                            Application.DoEvents();                //КОСТЫЛЬ Ждать выполнение доп потока 
                                                                                                   //  Thread.Sleep(1000);
                                                            if (kp.IsDisposed == true)
                                                            {
                                                                Console.WriteLine("kp.IsDisposed == true ");
                                                                break;
                                                            }

                                                        }

                                                        Console.WriteLine("Kapcha.key_kapcha " + Kapcha.key_kapcha);
                                                        try
                                                        {
                                                            var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                            {
                                                                OwnerId = Convert.ToInt32(owner_id),
                                                                PostId = Convert.ToInt32(post_id),
                                                                FromGroup = from_my_group,
                                                                Message = richbox4,
                                                                // Guid = "1",
                                                                CaptchaSid = e.Sid,
                                                                CaptchaKey = Kapcha.key_kapcha

                                                            }).ToString();
                                                        }
                                                        catch (VkNet.Exception.CaptchaNeededException t)
                                                        {

                                                        }



                                                    }
                                                    catch (VkNet.Exception.PublicServerErrorException ex)
                                                    {
                                                        Console.WriteLine("asdasdasd " + ex);
                                                        String s = ex.Message;
                                                        Console.WriteLine("s v IF popal " + s);

                                                        if (s == "Internal server error")
                                                        {
                                                            Console.WriteLine("s v IF popal " + s);
                                                            MessageBox.Show("Достигнуто ограничение вконтакте на кол-во комментариев, огрничение дейтсвует 12ч.", "Internal server error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                            stop = 1;

                                                        }


                                                    }

                                                    catch (VkNet.Exception.ParameterMissingOrInvalidException ex)
                                                    {
                                                        MessageBox.Show("Ошибка доступа к альбому!\nНельзя использовать дефолтные альбомы. Создайте собственный", "album_id is invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                        stop = 1;
                                                    }

                                                    catch (Exception e)
                                                    {
                                                        Console.WriteLine("ОБЩАЯ ОШИБКА В МЕТОДЕ КРЕАТЕ КОМЕНТ");
                                                        Msg.MessageError(e, this.Text);
                                                    }


                                                }
                                                BeginInvoke(new MethodInvoker(delegate
                                                {
                                                    if (propuskaem != 1)
                                                    {
                                                        postavili_comment++;
                                                        richTextBox1.SelectionColor = Color.Green;
                                                        richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - комментарий добавлен\n");
                                                        label17.Text = postavili_comment.ToString();
                                                        if (postavili_comment == Convert.ToInt32(textBox2.Text)) { stop = 1; }




                                                    }
                                                    else
                                                    {
                                                        if (отображатьПропущенныеЗаписиToolStripMenuItem.Checked == true)
                                                        {
                                                            richTextBox1.SelectionColor = Color.Black;
                                                            richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - пропускаем, комментарий уже имеется или запись не соотвествует фильтрам\n");
                                                        }
                                                    }
                                                    label5.Text = obrab_variant_post_filter.ToString();
                                                    progressBar1.Value = obrab_variant_post_filter;
                                                    label7.Text = "Выполнено: " + (obrab_variant_post_filter * 100) / poschitaem_kol_postov_posle_vsex_filtrov + " %";


                                                }));

                                            }
                                            else
                                            {
                                                BeginInvoke(new MethodInvoker(delegate
                                                {
                                                    if (отображатьПропущенныеЗаписиToolStripMenuItem.Checked == true)
                                                    {
                                                        richTextBox1.SelectionColor = Color.Black;
                                                        richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - пропускаем, комментарий уже имеется или запись не соотвествует фильтрам\n");
                                                    }
                                                    label5.Text = obrab_variant_post_filter.ToString();
                                                    progressBar1.Value = obrab_variant_post_filter;
                                                    label7.Text = "Выполнено: " + (obrab_variant_post_filter * 100) / poschitaem_kol_postov_posle_vsex_filtrov + " %";
                                                }));
                                            }




                                            //конец анализа текста


                                            //Console.WriteLine("owner_id " + Convert.ToInt32(owner_id));
                                            //Console.WriteLine("post_id " + Convert.ToInt32(post_id));
                                            //Console.WriteLine("from_my_group " + from_my_group);
                                            //Console.WriteLine("textBox2.Text " + richTextBox4.Text);

                                            Thread.Sleep(Convert.ToInt32(textBox4.Text) * 1000);
                                        }



                                    }

                                }
                            }
                        }
                        if (checkBox1.Checked == true && checkBox2.Checked == true)
                        {


                            if (Convert.ToInt32(Like) >= Convert.ToInt32(textBox5.Text))
                            {

                                if (Convert.ToInt32(count) >= Convert.ToInt32(textBox3.Text))
                                {
                                    if (can_post == "True" && can_post_group == "True")
                                    {
                                        obrab_variant_post_filter++;
                                        Console.WriteLine(searh_word);

                                        var who = (dynamic)null;
                                        int propuskaem = 0;
                                        try
                                        {
                                            var getComments = Avtorizacia.api.Wall.GetComments(new WallGetCommentsParams
                                            {
                                                OwnerId = Convert.ToInt32(owner_id),
                                                PostId = Convert.ToInt32(post_id),
                                                Count = 100,
                                                Sort = VkNet.Enums.SortOrderBy.Desc,
                                            });
                                            foreach (var g in getComments)
                                            {
                                                who = g.FromId;
                                                //Console.WriteLine(who);

                                                //тут условие
                                                if (Avtorizacia.my_id == who || Convert.ToInt32("-" + textBox1.Text) == who)
                                                {
                                                    propuskaem = 1;


                                                }

                                            };
                                        }
                                        catch (Exception e)
                                        {
                                            propuskaem = 1;
                                        }


                                        if (Type == "reply")
                                        {
                                            var getComments = Avtorizacia.api.Wall.GetComments(new WallGetCommentsParams
                                            {
                                                OwnerId = Convert.ToInt32(owner_id),
                                                PostId = Convert.ToInt32(post_id),
                                                StartCommentId = Convert.ToInt32(Comm_id),
                                                Count = 1,
                                                // Sort = VkNet.Enums.SortOrderBy.Desc,
                                            });

                                            foreach (var g in getComments)
                                            {
                                                text_posts = g.Text;

                                            };

                                        }

                                        else
                                        {

                                            IEnumerable<String> m_oEnum = new string[] { owner_id + "_" + post_id };

                                            var getbyid = Avtorizacia.api.Wall.GetById(

                                             posts: m_oEnum,
                                             extended: false,
                                             copyHistoryDepth: 0

                                                ).WallPosts;

                                            foreach (var tex in getbyid)
                                            {


                                                text_posts = tex.Text;

                                            }

                                        }

                                        // ТУТ анализ текста
                                        int max_variant_word = 0;

                                        Console.WriteLine("TEXT WALL/COMM== " + text_posts);

                                        //  String s1 = "123123 группа только ищу фото группа начинает г заполняться,  ищу не пугайтесь.    Балаково      ВстуПайТе,      поддерживайте! Балаково фото лайками, репостами, Помогите! своей любовью ❤ Зовите сюда своих друзей и знакомых.  раскрут, груп 123213  =)";
                                        //  String s2 = "Группа только начинает заполняться, не пугайтесь. подДерживайте лайками ВстуПайте, репостами, своей любовью ❤ Зовите сюда своих друзей и знакомых. ";
                                        String find_word = "";
                                        Console.WriteLine(max_variant_word);
                                        String RTB2 = "";
                                        Invoke(new MethodInvoker(delegate
                                        {
                                            RTB2 = richTextBox2.Text;
                                        }));
                                        if (propuskaem == 0)
                                        {

                                            propuskaem = 1;

                                            foreach (Match m in Regex.Matches(RTB2, "\\;"))
                                                max_variant_word++;

                                            for (int i = 0; i <= max_variant_word; i++)
                                            {

                                                find_word = RTB2.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[i];
                                                Console.WriteLine(find_word + " ALO EBAT v delegate!");
                                                Console.WriteLine(RTB2 + " richTextBox2.Text");



                                                Console.WriteLine(find_word + "ALO EBAT!");
                                                bool no_find = true;

                                                String kovichki = Regex.Match(find_word, @"(?<=\"")(.*?)(?=\"")").ToString().Trim();
                                                bool dva_slova = Regex.IsMatch(kovichki, "\\w* \\w*", RegexOptions.IgnoreCase);
                                                if (dva_slova == true) //Если у нас два слова
                                                {
                                                    String one_slovo = Regex.Match(kovichki, @"(?<=^)(.*?)(?= )").ToString();
                                                    String two_slovo = Regex.Match(kovichki, @"(?<= )(.*?)(?=$)").ToString();

                                                    if (one_slovo.IndexOf("*") > -1) //если есть звездочка в 1 слове добавляем регялрку
                                                    {
                                                        one_slovo = one_slovo.Replace("*", "\\w*");
                                                        //  Console.WriteLine("Вхождения найдены " + one_slovo); // 
                                                    }
                                                    if (two_slovo.IndexOf("*") > -1) ////если есть звездочка в 2 слове добавляем регялрку
                                                    {
                                                        two_slovo = two_slovo.Replace("*", "\\w*");
                                                        //    Console.WriteLine("Вхождения найдены " + two_slovo); // 

                                                    }

                                                    String pattern_two_slov = "";
                                                    String pattern_two_slov2 = "";
                                                    String all_zapros = Regex.Match(find_word, @"(?<=^)(.*?)(?=$)").ToString().Trim();

                                                    bool dop_slovo = Regex.IsMatch(all_zapros, "\\([\\d\\D]*\\)", RegexOptions.IgnoreCase);

                                                    if (dop_slovo == true) //есть есть доп слово
                                                    {
                                                        String dop_slovo_text = Regex.Match(all_zapros, @"(?<=\()(.*?)(?=\))").ToString().Trim();

                                                        pattern_two_slov = dop_slovo_text + @"[\d\D]* \b" + one_slovo + @"\W*\S*" + two_slovo + @"\b";

                                                        pattern_two_slov2 = @"\b" + one_slovo + @"\W*\S*" + two_slovo + @"\b[\d\D]*" + dop_slovo_text;

                                                        bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);
                                                        bool res2 = Regex.IsMatch(text_posts, pattern_two_slov2, RegexOptions.IgnoreCase);


                                                        /// Console.WriteLine("Доп слово слева " + pattern_two_slov + "\nДоп слово спава " + pattern_two_slov2 +" "+res1 + " " + res2);


                                                        if (res1 == true || res2 == true)
                                                        {
                                                            Console.WriteLine("НУЖНЫЙ ПОСТ! 2 slova + dop slovo " + one_slovo + " " + two_slovo + " " + dop_slovo_text);
                                                            no_find = false;
                                                            propuskaem = 0;

                                                        }


                                                    }
                                                    else
                                                    { //если нет доп слово



                                                        pattern_two_slov = @"\b" + one_slovo + @"\W*\S*" + two_slovo + @"\b";



                                                        bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);



                                                        //  Console.WriteLine("bez Доп слово слева " + pattern_two_slov );


                                                        if (res1 == true)
                                                        {
                                                            Console.WriteLine("НУЖНЫЙ ПОСТ 2 slova bez dop slova! " + one_slovo + " " + two_slovo);
                                                            no_find = false;
                                                            propuskaem = 0;
                                                        }

                                                    }


                                                    //Console.WriteLine("dop_slovo " + dop_slovo); // 



                                                }
                                                else
                                                {  //Если Одно слово
                                                    String one_slovo = Regex.Match(kovichki, @"(?<=^)(.*?)(?=$)").ToString().Trim();
                                                    if (one_slovo.IndexOf("*") > -1)
                                                    {
                                                        one_slovo = one_slovo.Replace("*", "\\w*");
                                                        //   Console.WriteLine("Вхождения найдены " + one_slovo); // 
                                                    }


                                                    String all_zapros = Regex.Match(find_word, @"(?<=^)(.*?)(?=$)").ToString().Trim();

                                                    bool dop_slovo = Regex.IsMatch(all_zapros, "\\([\\d\\D]*\\)", RegexOptions.IgnoreCase);
                                                    String pattern_two_slov = "";
                                                    String pattern_two_slov2 = "";
                                                    if (dop_slovo == true) //есть есть доп слово
                                                    {
                                                        String dop_slovo_text = Regex.Match(all_zapros, @"(?<=\()(.*?)(?=\))").ToString().Trim();

                                                        pattern_two_slov = dop_slovo_text + @"[\d\D]* \b" + one_slovo + @"\b";

                                                        pattern_two_slov2 = @"\b" + one_slovo + @"\b[\d\D]*" + dop_slovo_text;

                                                        bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);
                                                        bool res2 = Regex.IsMatch(text_posts, pattern_two_slov2, RegexOptions.IgnoreCase);


                                                        //  Console.WriteLine("Доп слово слева " + pattern_two_slov + "\nДоп слово спава " + pattern_two_slov2 + " " + res1 + " " + res2);


                                                        if (res1 == true || res2 == true)
                                                        {
                                                            Console.WriteLine("НУЖНЫЙ ПОСТ! 1 SLOVO +dopslovo" + one_slovo + " " + dop_slovo_text);
                                                            no_find = false;
                                                            propuskaem = 0;
                                                        }
                                                    }

                                                    else
                                                    {
                                                        pattern_two_slov = @"\b" + one_slovo + @"\b";



                                                        bool res1 = Regex.IsMatch(text_posts, pattern_two_slov, RegexOptions.IgnoreCase);

                                                        if (res1 == true)
                                                        {
                                                            Console.WriteLine("НУЖНЫЙ ПОСТ bez dop slova 1 slovo!" + one_slovo + " ");
                                                            no_find = false;
                                                            propuskaem = 0;
                                                        }

                                                    }


                                                }

                                                if (no_find == true)
                                                {
                                                    Console.WriteLine(" НЕ НАЙДЕНО СОВПАДЕНИЙ! ");
                                                }







                                            }


                                            Console.WriteLine("propuskaem 1 да 0 нет================================== " + propuskaem);
                                            if (propuskaem != 1) //не равно 1 должно быть
                                            {

                                                try
                                                {

                                                    if (checkBox4.Checked == true)
                                                    {
                                                        var albumid = Convert.ToInt32(textBox6.Text);

                                                        var photos = Avtorizacia.api.Photo.Get(new PhotoGetParams
                                                        {
                                                            AlbumId = PhotoAlbumType.Id(albumid),
                                                            OwnerId = Avtorizacia.api.UserId.Value,

                                                        });


                                                        if (Type == "post")
                                                        {
                                                            var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                            {
                                                                OwnerId = Convert.ToInt32(owner_id),
                                                                PostId = Convert.ToInt32(post_id),
                                                                FromGroup = from_my_group,
                                                                Message = richbox4,
                                                                // Guid = "1",
                                                                Attachments = photos



                                                            }).ToString();

                                                            Console.WriteLine("asdasdasd " + addComment);
                                                            //String s=addComment.

                                                        }

                                                        else
                                                        {

                                                            String s = From_id.Substring(0, 1);
                                                            if (s == "-")
                                                            {
                                                                From_id = From_id.Replace("-", "club");
                                                            }
                                                            else
                                                            {
                                                                From_id = "id" + From_id;
                                                            }

                                                            var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                            {
                                                                OwnerId = Convert.ToInt32(owner_id),
                                                                PostId = Convert.ToInt32(post_id),
                                                                FromGroup = from_my_group,
                                                                Message = "[" + From_id + "|Hi!] " + richbox4,  // [id1 | Dur]

                                                                // Guid = "1",
                                                                Attachments = photos



                                                            }).ToString();

                                                            Console.WriteLine("asdasdasd MESSAGE " + addComment);
                                                            //String s=addComment.
                                                        }
                                                    }
                                                    else
                                                    {

                                                        if (Type == "post")
                                                        {

                                                            var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                            {
                                                                OwnerId = Convert.ToInt32(owner_id),
                                                                PostId = Convert.ToInt32(post_id),
                                                                FromGroup = from_my_group,
                                                                Message = richbox4,
                                                                // Guid = "1",



                                                            }).ToString();

                                                            Console.WriteLine("asdasdasd " + addComment);

                                                        }

                                                        else
                                                        {
                                                            String s = From_id.Substring(0, 1);
                                                            if (s == "-")
                                                            {
                                                                From_id = From_id.Replace("-", "club");
                                                            }
                                                            else
                                                            {
                                                                From_id = "id" + From_id;
                                                            }
                                                            var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                            {
                                                                OwnerId = Convert.ToInt32(owner_id),
                                                                PostId = Convert.ToInt32(post_id),
                                                                FromGroup = from_my_group,
                                                                Message = "[" + From_id + "|Hi!] " + richbox4,  // [id1 | Dur]
                                                                                                                // Guid = "1",



                                                            }).ToString();

                                                            Console.WriteLine("asdasdasd " + addComment);

                                                        }

                                                    }


                                                }
                                                catch (VkNet.Exception.CaptchaNeededException e)
                                                {
                                                    Console.WriteLine("CaptchaNeededException " + e.Sid + " " + e.Img);
                                                    // MessageBox.Show("CaptchaNeededException " + e.Sid + " " + e.Img + "\nПолучили капчу. Подождите минут 5-10 и запустите снова. \nВ Самом ближайшем фиксе будет реализован механизм ввода", "CaptchaNeededException");
                                                    // stop = 1;
                                                    uri_kapcha = e.Img.ToString();
                                                    // sid_kapcha = e.Sid.ToString();
                                                    //Thread.Sleep(300 * 1000);
                                                    Kapcha kp = new Kapcha();
                                                    kp.Show();

                                                    Thread myThread3 = new Thread(sleeper);
                                                    myThread3.Start();

                                                    while (myThread3.IsAlive)
                                                    {
                                                        Application.DoEvents();                //КОСТЫЛЬ Ждать выполнение доп потока 
                                                                                               //  Thread.Sleep(1000);
                                                        if (kp.IsDisposed == true)
                                                        {
                                                            Console.WriteLine("kp.IsDisposed == true ");
                                                            break;
                                                        }

                                                    }

                                                    Console.WriteLine("Kapcha.key_kapcha " + Kapcha.key_kapcha);
                                                    try
                                                    {
                                                        var addComment = Avtorizacia.api.Wall.CreateComment(new WallCreateCommentParams
                                                        {
                                                            OwnerId = Convert.ToInt32(owner_id),
                                                            PostId = Convert.ToInt32(post_id),
                                                            FromGroup = from_my_group,
                                                            Message = richbox4,
                                                            // Guid = "1",
                                                            CaptchaSid = e.Sid,
                                                            CaptchaKey = Kapcha.key_kapcha

                                                        }).ToString();
                                                    }
                                                    catch (VkNet.Exception.CaptchaNeededException t)
                                                    {

                                                    }



                                                }
                                                catch (VkNet.Exception.PublicServerErrorException ex)
                                                {
                                                    Console.WriteLine("asdasdasd " + ex);
                                                    String s = ex.Message;
                                                    Console.WriteLine("s v IF popal " + s);

                                                    if (s == "Internal server error")
                                                    {
                                                        Console.WriteLine("s v IF popal " + s);
                                                        MessageBox.Show("Достигнуто ограничение вконтакте на кол-во комментариев, огрничение дейтсвует 12ч.", "Internal server error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                        stop = 1;

                                                    }


                                                }

                                                catch (VkNet.Exception.ParameterMissingOrInvalidException ex)
                                                {
                                                    MessageBox.Show("Ошибка доступа к альбому!\nНельзя использовать дефолтные альбомы. Создайте собственный", "album_id is invalid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                                                    stop = 1;
                                                }

                                                catch (Exception e)
                                                {
                                                    Console.WriteLine("ОБЩАЯ ОШИБКА В МЕТОДЕ КРЕАТЕ КОМЕНТ");
                                                    Msg.MessageError(e, this.Text);
                                                }


                                            }
                                            BeginInvoke(new MethodInvoker(delegate
                                            {
                                                if (propuskaem != 1)
                                                {
                                                    postavili_comment++;
                                                    richTextBox1.SelectionColor = Color.Green;
                                                    richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - комментарий добавлен\n");
                                                    label17.Text = postavili_comment.ToString();
                                                    if (postavili_comment == Convert.ToInt32(textBox2.Text)) { stop = 1; }




                                                }
                                                else
                                                {
                                                    if (отображатьПропущенныеЗаписиToolStripMenuItem.Checked == true)
                                                    {
                                                        richTextBox1.SelectionColor = Color.Black;
                                                        richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - пропускаем, комментарий уже имеется или запись не соотвествует фильтрам\n");
                                                    }
                                                }
                                                label5.Text = obrab_variant_post_filter.ToString();
                                                progressBar1.Value = obrab_variant_post_filter;
                                                label7.Text = "Выполнено: " + (obrab_variant_post_filter * 100) / poschitaem_kol_postov_posle_vsex_filtrov + " %";


                                            }));

                                        }
                                        else
                                        {
                                            BeginInvoke(new MethodInvoker(delegate
                                            {
                                                if (отображатьПропущенныеЗаписиToolStripMenuItem.Checked == true)
                                                {
                                                    richTextBox1.SelectionColor = Color.Black;
                                                    richTextBox1.AppendText("https://vk.com/wall" + owner_id + "_" + post_id + " - пропускаем, комментарий уже имеется или запись не соотвествует фильтрам\n");
                                                }
                                                label5.Text = obrab_variant_post_filter.ToString();
                                                progressBar1.Value = obrab_variant_post_filter;
                                                label7.Text = "Выполнено: " + (obrab_variant_post_filter * 100) / poschitaem_kol_postov_posle_vsex_filtrov + " %";
                                            }));
                                        }




                                        //конец анализа текста


                                        //Console.WriteLine("owner_id " + Convert.ToInt32(owner_id));
                                        //Console.WriteLine("post_id " + Convert.ToInt32(post_id));
                                        //Console.WriteLine("from_my_group " + from_my_group);
                                        //Console.WriteLine("textBox2.Text " + richTextBox4.Text);

                                        Thread.Sleep(Convert.ToInt32(textBox4.Text) * 1000);
                                    }



                                }

                            }

                        }
                        if (f == max_variant_post_filter - 2 || stop == 1)
                        {
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                progressBar1.Value = progressBar1.Maximum;
                                label7.Text = "Завершено!";
                            }));

                            if (stop == 1)
                            {
                                f = max_variant_post_filter - 1;
                            }
                        }

                    }
                    catch (Exception e)
                    {

                        Msg.MessageError(e, this.Text);
                    }
                }  // Рабочий цикл



            }
            catch (Exception e)
            {
                Msg.MessageError(e, this.Text);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void linkLabel1_MouseClick(object sender, MouseEventArgs e)
        {
            var url = "https://vk.com/epvk_project"; //адрес ссылки это значение свойства `Text`
            System.Diagnostics.Process.Start(url);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("CaptchaNeededException \n Получили капчу. Подождите минут 5-10 и запустите программу снова. \nВ Самом ближайшем фиксе будет реализован механизм ввода", "CaptchaNeededException");
        }

        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            //richTextBox2.SelectionFont = new Font("Tahoma", 10, FontStyle.Regular);

            richTextBox2.ForeColor = Color.Black;


            int i2 = richTextBox2.SelectionStart;
            string rtbText = richTextBox2.Text;
            for (int i = 0; i < rtbText.Length; i++)
            {
                richTextBox2.ForeColor = Color.Black;
                if (rtbText[i] == '"')
                {
                    richTextBox2.Select(i, 1);
                    richTextBox2.SelectionColor = Color.Blue;
                    richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);

                }
                else
                {
                    richTextBox2.Select(i, 1);
                    richTextBox2.SelectionColor = Color.Black;
                    richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
                }
                if (rtbText[i] == ';')
                {
                    richTextBox2.Select(i, 1);
                    richTextBox2.SelectionColor = Color.Red;
                    richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }
                if (rtbText[i] == '*')
                {
                    richTextBox2.Select(i, 1);
                    richTextBox2.SelectionColor = Color.Orange;
                    richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }
                if (rtbText[i] == '(' || rtbText[i] == ')')
                {
                    richTextBox2.Select(i, 1);
                    richTextBox2.SelectionColor = Color.Green;
                    richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                }

            }
            // Get the current caret position.
            //richTextBox2.SelectionStart = richTextBox2.Text.Length;



            richTextBox2.Select(i2, 0);

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

            if (one_raz_ne_pidoras1 == 0)
            {
                one_raz_ne_pidoras1 = 1;

                richTextBox2.ForeColor = Color.Black;


                int i2 = richTextBox2.SelectionStart;
                string rtbText = richTextBox2.Text;
                for (int i = 0; i < rtbText.Length; i++)
                {
                    richTextBox2.ForeColor = Color.Black;
                    if (rtbText[i] == '"')
                    {
                        richTextBox2.Select(i, 1);
                        richTextBox2.SelectionColor = Color.Blue;
                        richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);

                    }
                    else
                    {
                        richTextBox2.Select(i, 1);
                        richTextBox2.SelectionColor = Color.Black;
                        richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
                    }
                    if (rtbText[i] == ';')
                    {
                        richTextBox2.Select(i, 1);
                        richTextBox2.SelectionColor = Color.Red;
                        richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                    }
                    if (rtbText[i] == '*')
                    {
                        richTextBox2.Select(i, 1);
                        richTextBox2.SelectionColor = Color.Orange;
                        richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                    }
                    if (rtbText[i] == '(' || rtbText[i] == ')')
                    {
                        richTextBox2.Select(i, 1);
                        richTextBox2.SelectionColor = Color.Green;
                        richTextBox2.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                    }

                }
                // Get the current caret position.
                //richTextBox2.SelectionStart = richTextBox2.Text.Length;



                richTextBox2.Select(i2, 0);

            }
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void richTextBox4_Click(object sender, EventArgs e)
        {
         
        }

        private void richTextBox2_Click(object sender, EventArgs e)
        {


            if (richTextBox2.Text == "\"нормал* дизайнер\"(посоветуйте); \"нужн* помо*\"(дизайн);")
            {
                richTextBox2.Text = "";
                richTextBox2.Font = new Font("Verdana", 10, FontStyle.Regular);
                richTextBox2.ForeColor = Color.Black;
            }
        }

        private void label16_MouseClick(object sender, MouseEventArgs e)
        {
            About_filter wb = new About_filter();
            wb.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }
        public void sleeper()
        {
            Thread.Sleep(150 * 1000);
            kp.Dispose();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (one_raz_ne_pidoras2 == 0)
            {
                one_raz_ne_pidoras2 = 1;

                richTextBox3.ForeColor = Color.Black;


                int i2 = richTextBox3.SelectionStart;
                string rtbText = richTextBox3.Text;
                for (int i = 0; i < rtbText.Length; i++)
                {
                    richTextBox3.ForeColor = Color.Black;
                    if (rtbText[i] == '"')
                    {
                        richTextBox3.Select(i, 1);
                        richTextBox3.SelectionColor = Color.Blue;
                        richTextBox3.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);

                    }
                    else
                    {
                        richTextBox3.Select(i, 1);
                        richTextBox3.SelectionColor = Color.Black;
                        richTextBox3.SelectionFont = new Font("Verdana", 10, FontStyle.Regular);
                    }
                    if (rtbText[i] == ';')
                    {
                        richTextBox3.Select(i, 1);
                        richTextBox3.SelectionColor = Color.Red;
                        richTextBox3.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                    }
                    if (rtbText[i] == '*')
                    {
                        richTextBox3.Select(i, 1);
                        richTextBox3.SelectionColor = Color.Orange;
                        richTextBox3.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                    }
                    if (rtbText[i] == '(' || rtbText[i] == ')')
                    {
                        richTextBox3.Select(i, 1);
                        richTextBox3.SelectionColor = Color.Green;
                        richTextBox3.SelectionFont = new Font("Verdana", 10, FontStyle.Bold);
                    }

                }
                // Get the current caret position.
                //richTextBox3.SelectionStart = richTextBox3.Text.Length;



                richTextBox3.Select(i2, 0);

            }
        }

        private void richTextBox3_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "ищу дизайнера; подскажите дизайнера; помогите с дизайном;")
            {
                richTextBox3.Text = "";
                richTextBox3.Font = new Font("Verdana", 10, FontStyle.Regular);
                richTextBox3.ForeColor = Color.Black;
            }
        }

        private void button5_Click_3(object sender, EventArgs e)
        {



        }

        private void Osnova_Load(object sender, EventArgs e)
        {

        }

        private void спарситьБазуИДПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WebBrows wb = new WebBrows();
            wb.Show();
        }

        private void загрузитьБазуИДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            //saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                patch_file_open = saveFileDialog1.FileName;
                Console.WriteLine(patch_file_open);
                button1.Enabled = true;
                label7.Text = "Готово, можно приступать..";


            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox6.Enabled = true;
            }
            else
            {
                textBox6.Enabled = false;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void сохранитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {





            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            //saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_config = saveFileDialog1.FileName;
                Console.WriteLine(file_config);



            }

            #region Settings action
            Props props = new Props(); //экземпляр класса с настройками 
                                       //Запись настроек


            //Запись значения в ComboBox1

            //Запись значения в checkBox1


            props.Fields.TextValueBox1 = textBox1.Text;
            props.Fields.TextValueBox2 = richTextBox4.Text;
            props.Fields.TextValueBox3 = textBox3.Text;
            props.Fields.TextValueBox4 = textBox4.Text;
            props.Fields.TextValueBox5 = textBox5.Text;
            props.Fields.TextValueBox6 = textBox6.Text;
            props.Fields.TextValueBox7 = richTextBox2.Text;
            props.Fields.TextValueBox8 = richTextBox3.Text;

            props.Fields.BoolValueChebox1 = checkBox1.Checked;
            props.Fields.BoolValueChebox2 = checkBox2.Checked;
            props.Fields.BoolValueChebox3 = checkBox3.Checked;
            props.Fields.BoolValueChebox4 = checkBox4.Checked;

            props.Fields.intValueCombox1 = comboBox1.SelectedIndex;



            props.WriteXml();



            #endregion



        }

        private void загрузитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            one_raz_ne_pidoras1 = 0;
            one_raz_ne_pidoras2 = 0;
            OpenFileDialog saveFileDialog1 = new OpenFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            //saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_config = saveFileDialog1.FileName;
                Console.WriteLine(file_config);



            }



            textBox6.Font = new Font("Verdana", 10, FontStyle.Regular);
            textBox6.ForeColor = Color.Black;
            textBox1.Font = new Font("Verdana", 10, FontStyle.Regular);
            textBox1.ForeColor = Color.Black;
            richTextBox4.Font = new Font("Verdana", 10, FontStyle.Regular);
            richTextBox4.ForeColor = Color.Black;

            richTextBox2.Font = new Font("Verdana", 10, FontStyle.Regular);
            richTextBox2.ForeColor = Color.Black;
            richTextBox3.Font = new Font("Verdana", 10, FontStyle.Regular);
            richTextBox3.ForeColor = Color.Black;


            #region Settings action
            Props props = new Props(); //экземпляр класса с настройками 



            props.ReadXml();


            textBox1.Text = props.Fields.TextValueBox1;
            richTextBox4.Text = props.Fields.TextValueBox2;
            textBox3.Text = props.Fields.TextValueBox3;
            textBox4.Text = props.Fields.TextValueBox4;
            textBox5.Text = props.Fields.TextValueBox5;
            textBox6.Text = props.Fields.TextValueBox6;
            richTextBox2.Text = props.Fields.TextValueBox7;
            richTextBox3.Text = props.Fields.TextValueBox8;

            checkBox1.Checked = props.Fields.BoolValueChebox1;
            checkBox2.Checked = props.Fields.BoolValueChebox2;
            checkBox3.Checked = props.Fields.BoolValueChebox3;
            checkBox4.Checked = props.Fields.BoolValueChebox4;

            comboBox1.SelectedIndex = props.Fields.intValueCombox1;

            #endregion
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "12345678 (ИД альбома в профиле)")
            {
                textBox6.Text = "";
                textBox6.Font = new Font("Verdana", 10, FontStyle.Regular);
                textBox6.ForeColor = Color.Black;
            }
        }

        private void разработчикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v1.3\nEPVK project. Coded by A. Martynov 2018", "About");
        }

        private void лицензияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Avtorizacia.demo == 1)
            {
                MessageBox.Show("Триальная версия программы\nКоличество запусков ограничено, реклама включена", "Лицензия");
            }
            else
            {
                MessageBox.Show("Полная версия программы\nКоличество запусков не ограничено, реклама отключена", "Лицензия");
            }
        }

 

     

        public void proverka_formirovania_text_filter() {
            String find_word = "";
            String RTB2 = "";
            int max_variant_word = 0;

            Invoke(new MethodInvoker(delegate
            {
                RTB2 = richTextBox2.Text;
            }));
           

            foreach (Match m in Regex.Matches(RTB2, "\\;"))
                max_variant_word++;
            try
            {
                for (int i = 0; i <= max_variant_word; i++)
                {
                    find_word = RTB2.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[i];

                    String kovichki = Regex.Match(find_word, @"(?<=\"")(.*?)(?=\"")").ToString().Trim();
                    Console.WriteLine(kovichki);
                    if (kovichki == "")
                    {

                        MessageBox.Show("Ошибка формирования текстовых фильтров! \nОбязательный аргумент в ковычках отсутсвует ", "Ошибка форммирования текстовых фильтров!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                       

                        stop = 1;
                        filter_text_bad = 1;

                    }
                    
                }
            }
            catch (Exception e) {
                MessageBox.Show("Ошибка формирования текстовых фильтров! \nОбязательный аргумент в ковычках отсутсвует ", "Ошибка форммирования текстовых фильтров!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                stop = 1;
                filter_text_bad = 1;
            }

        }

        private void label22_Click(object sender, EventArgs e)
        {
            Konstruktor kon = new Konstruktor();
            kon.Show();
        }

        private void richTextBox4_Click_1(object sender, EventArgs e)
        {
            if (richTextBox4.Text == "Бла-бла-бла")
            {
                richTextBox4.Text = "";
                richTextBox4.Font = new Font("Verdana", 10, FontStyle.Regular);
                richTextBox4.ForeColor = Color.Black;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  int timestamp = 1527669152;
            int unixTime_12hour = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 43200 ; //
            int unixTime_1_sutki = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds- 86400 ; //sutki nazad 43200
            int unixTime_3_sutki = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 259200 ;
            int unixTime_1_nedelia = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 604800;
            int unixTime_1_mesiac = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - 2592000;
            int unixTime_all = 0;




            // DateTime date = new DateTime(1970, 1, 1).AddSeconds(timestamp);

            DateTime pDate1 = (new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(unixTime_12hour);
            DateTime pDate2 = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTime_1_sutki);
            DateTime pDate3 = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTime_3_sutki);
            DateTime pDate4 = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTime_1_nedelia);
            DateTime pDate5 = (new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds(unixTime_1_mesiac);
            

            Console.WriteLine(pDate1+"\n"+pDate2 + "\n"+pDate3 + "\n"+pDate4 + "\n"+pDate5 + "\n" );
        }
    }
}
