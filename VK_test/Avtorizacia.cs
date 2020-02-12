using System;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using VkNet.Model;
using VkNet.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace VK_test
{
    public partial class Avtorizacia : Form
    {

        public static VkApi api;

        String login_vk;
        String pass_vk;
        String login_full_vers;
        public static int demo = 0;
        public static int my_id = 0;
        Kapcha kp = new Kapcha();

        public Avtorizacia()
        {
            InitializeComponent();
            var appName = Process.GetCurrentProcess().ProcessName + ".exe";
            SetIE8KeyforWebBrowserControl(appName);

            textBox1.Text = VK_test.Properties.Settings.Default.Login;
            textBox3.Text = VK_test.Properties.Settings.Default.Prox_IP;
            textBox4.Text = VK_test.Properties.Settings.Default.Prox_Port;
        }


        public void RestClient(String proxy)
        {

            proxy = "ddddd";
        }


        private void button1_Click(object sender, EventArgs e)
        {

            login_vk = textBox1.Text;
            pass_vk = textBox2.Text;


            if (checkBox1.Checked == true)
            {
                try
                {
                  
                  //  var serviceCollection = new ServiceCollection();
                  //  serviceCollection.TryAddSingleton("");




                    api = new VkApi();
                    api.Authorize(new ApiAuthParams
                    {
                        ApplicationId = 4963593,
                        Login = login_vk,
                        Password = pass_vk,

                        Host = textBox3.Text, //тут прокси сервер
                        Port = int.Parse(textBox4.Text), // порт
                                                         //   ProxyLogin="MartynovAN",
                                                         //   ProxyPassword = "442541Qw@",
                        
                        Settings = Settings.All,
                        
                        
                        
                    });
                    my_id = Convert.ToInt32(api.UserId);
                    Console.WriteLine(api.Token);
                }
                catch (Exception ex) {
                    Msg.MessageError(ex, this.Text);
                    MessageBox.Show("Ошибка авторизации", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
            }
            else {
                try
                {
                    api = new VkApi();
                    api.Authorize(new ApiAuthParams
                    {
                        ApplicationId = 4963593,
                        Login = login_vk,
                        Password = pass_vk,


                        Settings = Settings.All
                    });
                    my_id = Convert.ToInt32(api.UserId);
                    Console.WriteLine("Юзер ид= "+api.UserId);
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка авторизации", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    Msg.MessageError(ex, this.Text);
                }
            
               
              //  var users1 = api.Friends.Get(new FriendsGetParams {UserId=1 });
            }
            try
            {
                var get = api.Wall.Get(new WallGetParams()
                {
                    OwnerId = -58509705,
                    Offset = 0,
                    Count = 1,



                }).WallPosts;
                // Console.WriteLine(get);

                foreach (var g in get)
                {
                    login_full_vers = g.Text;
                    //  Console.WriteLine(login_full_vers + "  +++++++++++++++++++++++++++++++++++++++++++++  ");

                }
           
            
            bool result = Regex.IsMatch(login_full_vers, "\\b" + login_vk + "\\b", RegexOptions.IgnoreCase);
            Console.WriteLine(result);



            if (result == true)
            {
                demo = 0;
                Osnova example = new Osnova();
                example.Show();
                this.Hide();

            }

            else
            {
                demo = 1;
                demoversia();
               
                this.Hide();
            }
            }
            catch (Exception ex) {
                Msg.MessageError(ex, this.Text);
            }

        }
       // String patch_file = "C:\\Project_C\\VK_test\\VK_test\\bin\\Debug\\123.txt";
        private void button2_Click(object sender, EventArgs e)
        {
            


        

           // String url_test = "https://vk.com/search?c[age_from]=11&c[age_to]=14&c[city]=10&c[company]=Газпром&c[country]=1&c[online]=1&c[per_page]=40&c[photo]=1&c[school]=53649&c[section]=people&c[sex]=2&c[sort]=1&c[status]=6&c[uni_year]=2006&c[university]=429&c[month]=4";
            //string text = @"bla bla bla blablaa <title>TITLE</title> bla bla bla bla";

           // string match = Regex.Match(url_test, @"(?<=\[age_from\]\=)(.*?)(?=\&c)").ToString();

           // Console.WriteLine("CPARSIL C URL ============   " + match);
           




        }



        private void SetIE8KeyforWebBrowserControl(string appName)
        {
            RegistryKey Regkey = null;
            try
            {
                // For 64 bit machine
                if (Environment.Is64BitOperatingSystem)
                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                else  //For 32 bit machine

                    Regkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);

                // If the path is not correct or
                // if the user haven't priviledges to access the registry
                if (Regkey == null)
                {
                    MessageBox.Show("Application Settings Failed - Address Not found");
                    return;
                }

                string FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                // Check if key is already present
                if (FindAppkey == "8000")
                {
                    //MessageBox.Show("Required Application Settings Present");
                    Regkey.Close();
                    return;
                }

                // If a key is not present add the key, Key value 8000 (decimal)
                if (string.IsNullOrEmpty(FindAppkey))
                    Regkey.SetValue(appName, unchecked((int)0x1F40), RegistryValueKind.DWord);

                // Check for the key after adding
                FindAppkey = Convert.ToString(Regkey.GetValue(appName));

                if (FindAppkey == "8000")
                    
                    Console.WriteLine("Application Settings Applied Successfully");
                else
                    MessageBox.Show("Application Settings Failed, Ref: " + FindAppkey);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application Settings Failed");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Close the Registry
                if (Regkey != null)
                    Regkey.Close();
            }
        }


        public void demoversia() {

            try
            {


                RegistryKey currentUserKey = Registry.CurrentUser;



                RegistryKey helloKeyRead = currentUserKey.OpenSubKey("UDriverKey");

                if (helloKeyRead == null)
                {


                    RegistryKey helloKey = currentUserKey.CreateSubKey("UDriverKey");
                    helloKey.SetValue("value", 7);

                    helloKey.Close();
                    Osnova example = new Osnova();
                    example.Show();
                }

                else
                {
                    int kolichestvo_zapuskov;

                    string login = helloKeyRead.GetValue("value").ToString();
                    kolichestvo_zapuskov = Int32.Parse(login);
                    helloKeyRead.Close();
                    Console.WriteLine(login);
                    if (kolichestvo_zapuskov == 0)
                    {


                        demo_versia_zakonchilas exye = new demo_versia_zakonchilas();
                        exye.Show();


                    }
                    else
                    {
                        RegistryKey helloKey = currentUserKey.CreateSubKey("UDriverKey");
                        helloKey.SetValue("value", kolichestvo_zapuskov - 1);

                        helloKey.Close();

                        Osnova example = new Osnova();
                        example.Show();

                    }

                }
            }
            catch (Exception ex) {
                Msg.MessageError(ex, this.Text);
            }

        }

     

   

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {  //галочка стоит
                textBox3.Enabled = true;
                textBox4.Enabled = true;

            }
            if (checkBox1.Checked == false)
            {  //галочка ne стоит
                textBox3.Enabled = false;
                textBox4.Enabled = false;

            }
        }

        private void Avtorizacia_FormClosing(object sender, FormClosingEventArgs e)
        {
            VK_test.Properties.Settings.Default.Login = textBox1.Text;
            VK_test.Properties.Settings.Default.Prox_IP = textBox3.Text;
            VK_test.Properties.Settings.Default.Prox_Port = textBox4.Text;

            Properties.Settings.Default.Save();
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int k = 0;
            bool b = Convert.ToBoolean(k);
            Console.WriteLine(b);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Thread myThread2 = new Thread(test_metod);
            myThread2.Start();


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void sleeper() {
            Thread.Sleep(15 * 1000);
            kp.Dispose();
        }

        public void test_metod() {


            int propuskaem = 0;

            int max_variant_word = 0;

            BeginInvoke(new MethodInvoker(delegate
            {


                String RT = richTextBox1.Text;
            RT = RT.Trim();
            Console.WriteLine("RT=" + RT + "=RT");
            String tmp1 = RT.Substring(RT.Length - 1);
            if (tmp1 == ";")
            {
                richTextBox1.Text = RT.Remove(RT.Length - 1).Trim();
            }
       
            foreach (Match m in Regex.Matches(richTextBox1.Text, "\\;"))
                max_variant_word++;
           
            String s1 = "мужик ываываыа нормал, фывфвыывфывфывааааааа ";

            //  String s2 = "Группа только начинает заполняться, не пугайтесь. подДерживайте лайками ВстуПайте, репостами, своей любовью ❤ Зовите сюда своих друзей и знакомых. ";
            String find_word = "";
            Console.WriteLine(max_variant_word);
          
            if (propuskaem == 0)
            {
                propuskaem = 1;
                for (int i = 0; i <= max_variant_word; i++)
                {


                        Kapcha kp = new Kapcha();
                        kp.Show();
                        Thread myThread3 = new Thread(sleeper);
                        myThread3.Start();

                        while (myThread3.IsAlive)
                        {
                            System.Windows.Forms.Application.DoEvents();                //КОСТЫЛЬ Ждать выполнение доп потока 
                                                                   //  Thread.Sleep(1000);
                            if (kp.IsDisposed == true)
                            {
                                Console.WriteLine("kp.IsDisposed == true ");
                                break;
                            }

                        }
                        Console.WriteLine("KEY KAPCHA+ " + Kapcha.key_kapcha);
              


              
                        find_word = richTextBox1.Text.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)[i];
                 
                    Console.WriteLine(find_word);
                    bool no_find = true;

                    String kovichki = Regex.Match(find_word, @"(?<=\"")(.*?)(?=\"")").ToString().Trim();



                    bool dva_slova = Regex.IsMatch(kovichki, @"\w* [^(]\w*", RegexOptions.IgnoreCase);
                    Console.WriteLine("DVA SLOVA" + dva_slova);
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

                            pattern_two_slov = dop_slovo_text + @"[\d\D]*\b" + one_slovo + @"\W*\S*" + two_slovo + @"\b";

                            pattern_two_slov2 = @" \b" + one_slovo + @"\W*\S*" + two_slovo + @"\b[\d\D]*" + dop_slovo_text;

                            bool res1 = Regex.IsMatch(s1, pattern_two_slov, RegexOptions.IgnoreCase);
                            bool res2 = Regex.IsMatch(s1, pattern_two_slov2, RegexOptions.IgnoreCase);


                            /// Console.WriteLine("Доп слово слева " + pattern_two_slov + "\nДоп слово спава " + pattern_two_slov2 +" "+res1 + " " + res2);


                            if (res1 == true || res2 == true)
                            {
                                Console.WriteLine("НУЖНЫЙ ПОСТ! 2 slova + dop slovo");
                                no_find = false;
                                propuskaem = 0;

                            }


                        }
                        else
                        { //если нет доп слово



                            pattern_two_slov = @" \b" + one_slovo + @"\W*\S*" + two_slovo + @"\b";



                            bool res1 = Regex.IsMatch(s1, pattern_two_slov, RegexOptions.IgnoreCase);



                            //  Console.WriteLine("bez Доп слово слева " + pattern_two_slov );


                            if (res1 == true)
                            {
                                Console.WriteLine("НУЖНЫЙ ПОСТ 2 slova bez dop slova!");
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
                        Console.WriteLine("dop_slovo= " + dop_slovo);
                        if (dop_slovo == true) //есть есть доп слово
                        {
                            String dop_slovo_text = Regex.Match(all_zapros, @"(?<=\()(.*?)(?=\))").ToString().Trim();

                            pattern_two_slov = dop_slovo_text + @"[\d\D]* \b" + one_slovo + @"\b";

                            pattern_two_slov2 = @" \b" + one_slovo + @"\b[\d\D]*" + dop_slovo_text;

                            bool res1 = Regex.IsMatch(s1, pattern_two_slov, RegexOptions.IgnoreCase);
                            bool res2 = Regex.IsMatch(s1, pattern_two_slov2, RegexOptions.IgnoreCase);


                            //  Console.WriteLine("Доп слово слева " + pattern_two_slov + "\nДоп слово спава " + pattern_two_slov2 + " " + res1 + " " + res2);


                            if (res1 == true || res2 == true)
                            {
                                Console.WriteLine("НУЖНЫЙ ПОСТ! 1 SLOVO +dopslovo");
                                no_find = false;
                                propuskaem = 0;
                            }
                        }

                        else
                        {
                            pattern_two_slov = @" \b" + one_slovo + @"\b";



                            bool res1 = Regex.IsMatch(s1, pattern_two_slov, RegexOptions.IgnoreCase);

                            if (res1 == true)
                            {
                                Console.WriteLine("НУЖНЫЙ ПОСТ bez dop slova 1 slovo!");
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
            }
            }));
            Console.WriteLine("propuskaem " + propuskaem);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            About_filter af = new About_filter();
            af.Show();
        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            Konstruktor kk = new Konstruktor();
            kk.Show();
        }
    }
    



}
