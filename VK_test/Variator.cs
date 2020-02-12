using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace VK_test
{
    public partial class Variator : Form
    {


        String url_test = WebBrows.url_iz_browser;
        public int stop;
        public int pb = 0;
        public int vsego_id = 0;
        String patch_file;
        int dcp = 0;

        public Variator()
        {
            InitializeComponent();
            Console.WriteLine(WebBrows.url_iz_browser);
            button1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread myThread = new Thread(get_id_sersh); //Создаем новый объект потока (Thread)
                                                        // Display the ProgressBar control.

            myThread.Start(); //запускаем поток

            progressBar1.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            progressBar1.Minimum = 1;
            // Set Maximum to the total number of files to copy.
           // progressBar1.Maximum = 6;
            // Set the initial value of the ProgressBar.
            progressBar1.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            progressBar1.Step = 1;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public void get_id_sersh()
        {


            String Query = Regex.Match(url_test, @"(?<=\[q\]\=)(.*?)(?=\&c)").ToString(); //- Строка поискового запроса. Например, Вася Бабич. строка
            String Offset = "0"; //- Смещение относительно первого найденного пользователя для выборки определенного подмножества. положительное число
            String Count = "1000"; //- Количество возвращаемых пользователей. Обратите внимание — даже при использовании параметра offset для получения информации доступны только первые 1000 результатов. /// положительное число, по умолчанию 20, максимальное значение 1000
            String City = Regex.Match(url_test, @"(?<=\[city\]\=)(.*?)(?=\&c)").ToString();  //- Идентификатор города.положительное число
            int City_of_int;
            if (City != "") { City_of_int = Convert.ToInt32(City); } else { City_of_int = 0; }
            String Country = Regex.Match(url_test, @"(?<=\[country\]\=)(.*?)(?=\&c)").ToString();  //- Идентификатор страны.положительное число
            int Country_of_int;
            if (Country != "") { Country_of_int = Convert.ToInt32(Country); } else { Country_of_int = 0; }
            String University = Regex.Match(url_test, @"(?<=\[university\]\=)(.*?)(?=\&c)").ToString();  //- Идентификатор ВУЗа.положительное число
            int University_of_int;
            if (University != "") { University_of_int = Convert.ToInt32(University); } else { University_of_int = 0; }
            String UniversityYear = Regex.Match(url_test, @"(?<=\[uni_year\]\=)(.*?)(?=\&c)").ToString();  //- Год окончания ВУЗа. положительное число
            int UniversityYear_of_int;
            if (UniversityYear != "") { UniversityYear_of_int = Convert.ToInt32(UniversityYear); } else { UniversityYear_of_int = 0; }
            uint UniversityYear_of_uint = Convert.ToUInt32(UniversityYear_of_int);
            String BirthDay = Regex.Match(url_test, @"(?<=\[bday\]\=)(.*?)(?=\&c)").ToString();  // - День рождения.положительное число
            int BirthDay_of_int;
            if (BirthDay != "") { BirthDay_of_int = Convert.ToInt32(BirthDay); } else { BirthDay_of_int = 0; }
            ushort BirthDay_of_ushort = (ushort)BirthDay_of_int;

            String BirthYear = Regex.Match(url_test, @"(?<=\[byear\]\=)(.*?)(?=\&c)").ToString();  //- Год рождения.положительное число
            int BirthYear_of_int;
            if (BirthYear != "") { BirthYear_of_int = Convert.ToInt32(BirthYear); } else { BirthYear_of_int = 0; }
            uint? BirthYear_of_uint = Convert.ToUInt32(BirthYear_of_int);
            String Online = Regex.Match(url_test, @"(?<=\[online\]\=)(.*?)(?=\&c)").ToString();  //- 1 — только в сети, 0 — все пользователи. флаг, может принимать значения 1 или 0
            int Online_of_int;
            if (Online != "") { Online_of_int = Convert.ToInt32(Online); } else { Online_of_int = 0; }
            bool Online_of_bool = Convert.ToBoolean(Online_of_int);
            String HasPhoto = Regex.Match(url_test, @"(?<=\[photo\]\=)(.*?)(?=\&c)").ToString();  //- 1 — только с фотографией, 0 — все пользователи. флаг, может принимать значения 1 или 0
            int HasPhoto_of_int;
            if (HasPhoto != "") { HasPhoto_of_int = Convert.ToInt32(HasPhoto); } else { HasPhoto_of_int = 0; }
            bool HasPhoto_of_bool = Convert.ToBoolean(HasPhoto_of_int);
            String School = Regex.Match(url_test, @"(?<=\[school\]\=)(.*?)(?=\&c)").ToString();  //- Идентификатор школы, которую закончили пользователи.положительное число
            int School_of_int;
            if (School != "") { School_of_int = Convert.ToInt32(School); } else { School_of_int = 0; }
            String SchoolYear = Regex.Match(url_test, @"(?<=\[school_year\]\=)(.*?)(?=\&c)").ToString();  //- Год окончания школы. положительное число
            int SchoolYear_of_int;
            if (SchoolYear != "") { SchoolYear_of_int = Convert.ToInt32(SchoolYear); } else { SchoolYear_of_int = 0; }
            uint SchoolYear_of_uint = Convert.ToUInt32(SchoolYear_of_int);
            String Religion = Regex.Match(url_test, @"(?<=\[religion\]\=)(.*?)(?=\&c)").ToString();  //- Религиозные взгляды.строка
            String Company = Regex.Match(url_test, @"(?<=\[company\]\=)(.*?)(?=\&c)").ToString();  //- Название компании, в которой работают пользователи. строка


            Console.WriteLine(
                "Query= " + Query + "\n" +
                  "Count= " + Count + "\n" +
                  "Offsett= " + Offset + "\n" +
                  "City= " + City + " City_of_int=" + City_of_int + "\n" +
                  "Country= " + Country + " of_int=" + Country_of_int + "\n" +
                  "University= " + University + " of_int=" + University_of_int + "\n" +
                  "UniversityYear= " + UniversityYear + " of_int=" + UniversityYear_of_uint + "\n" +
                  "BirthDay= " + BirthDay + " of_int=" + BirthDay_of_ushort + "\n" +
                  "BirthYear= " + BirthYear + " of_int=" + BirthYear_of_uint + "\n" +
                  "HasPhoto= " + HasPhoto + " of_int=" + HasPhoto_of_bool + "\n" +
                  "Online= " + Online + " of_int=" + Online_of_bool + "\n" +
                  "School= " + School + " of_int=" + School_of_int + "\n" +
                  "SchoolYear= " + SchoolYear + " of_int=" + SchoolYear_of_uint + "\n" +
                  "Religion= " + Religion + "\n" +
                  "Company= " + Company + "\n");




            String status = textBox1.Text; //получаю с формы
            String sex = textBox2.Text; //получаю с формы
            String interest = textBox3.Text; //получаю с формы
            String id_group_member = textBox4.Text; //получаю с формы
            int? id_group_member_of_int;
            ulong? id_group_member_of_ulong;
            if (id_group_member != "") {
                id_group_member_of_int = Convert.ToInt32(id_group_member);
                id_group_member_of_ulong = Convert.ToUInt64(id_group_member_of_int);
            } else {
                id_group_member_of_int = null;
                id_group_member_of_ulong = null;
            }
            
            String sort = "+0+1+"; // Не менять сортировка
            String birthMonth = "+1+2+3+4+5+6+7+8+9+10+11+12+"; // Не менять месяца 12

            String age_from = Regex.Match(url_test, @"(?<=\[age_from\]\=)(.*?)(?=\&c)").ToString(); //просто спарсить с ссылки
            int age_from1 = Convert.ToInt32(age_from);
            String age_to = Regex.Match(url_test, @"(?<=\[age_to\]\=)(.*?)(?=\&c)").ToString(); //просто спарсить с ссылки
            int age_to1 = Convert.ToInt32(age_to);
            String age_from_to = "+"; // Получaem строка Пр: +22+21+20+19+18+








            for (int i = age_from1; i <= age_to1; i++)
            {

                age_from_to = age_from_to.Insert(1, i + "+");
            }
            Console.WriteLine("age_from_to== " + age_from_to);


            int max_variant_status = -2;
            foreach (Match m in Regex.Matches(status, "\\+"))
                max_variant_status++;

            int max_variant_sex = -2;
            foreach (Match m in Regex.Matches(sex, "\\+"))
                max_variant_sex++;

            int max_variant_age = -2;
            foreach (Match m in Regex.Matches(age_from_to, "\\+"))
                max_variant_age++;





            // Console.WriteLine("kokichestvo vxogdeniiy== " + count);
            for (int i = 0; i <= max_variant_status; i++)                  //Первый цикл Статус
            {
                string happy = status.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries)[i];
                Console.WriteLine(happy);

                BeginInvoke(new MethodInvoker(delegate
                {
                    String t;
                    progressBar1.Maximum= (max_variant_status+3);
                    progressBar1.PerformStep(); //здесь твой код в основном потоке
                    t=label12.Text = Convert.ToString((pb * 100) / (max_variant_status+2) + " %");
                    Console.WriteLine("Znachenie %= " +t+ " pb= " + pb + " max_variant_status " + (max_variant_status+2));

                }));
                pb++;
                


                for (int j = 0; j <= max_variant_sex; j++)
                {     //Второй цикл Пол
                    string happy2 = sex.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries)[j];
                    for (int j1 = 0; j1 <= 1; j1++)            //Третий цикл Онлайн
                    {
                        string happy3 = sort.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries)[j1];

                        for (int j2 = 0; j2 <= max_variant_age; j2++) //Четвёртый цикл Возраст
                        {
                            string happy4 = age_from_to.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries)[j2];

                            if (checkBox1.Checked == true)
                            {
                                for (int j3 = 0; j3 <= 11; j3++) //Пятый цикл Месяца //Поиск = глубокий
                                {
                                    string happy5 = birthMonth.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries)[j3];
                                    Console.WriteLine("Cikl J: " + happy + " - " + happy2 + " - " + happy3 + " - " + happy4 + " - " + happy5);



                                    if (stop == 1)
                                    {
                                        i = max_variant_status;
                                        j = max_variant_sex;
                                        j2 = max_variant_age;
                                        j3 = 11;

                                    }

                                    if (i >= max_variant_status && j3 >= 11)
                                    {

                                        if (i == max_variant_status && j3 == 11)
                                        {
                                            if (dcp == 0)
                                            {
                                                dcp = 1; //флаг что бы 2 раза не срабатывала
                                                File.WriteAllLines(@patch_file, File.ReadAllText(@patch_file).Split().Distinct());
                                                int count_noduble = System.IO.File.ReadAllLines(patch_file).Length;

                                                MessageBox.Show("Файл: " + patch_file + "\nВсего ИД после удаления дублей: " + count_noduble, "Завершено! ");



                                                BeginInvoke(new MethodInvoker(delegate
                                                {
                                                    label12.Text = "Завершено!";
                                                    progressBar1.Value = (max_variant_status + 3);

                                                }));

                                            }
                                        }
                                        stop = 1;
                                        //i = max_variant_status + 2;
                                        //j3 = j3 + 2;
                                        Console.WriteLine("Uslovie esli i >= max_variant_status && j3 >= 11  " + i + " " + j3);

                                    }
                                    else
                                    {

                                        if (stop != 1)
                                        {
                                            Thread.Sleep(Convert.ToInt32(textBox5.Text) * 1000);

                                            var Status_of_int = VkNet.Enums.MaritalStatus.Engaged;
                                            if (Convert.ToInt32(happy) == 1) { Status_of_int = VkNet.Enums.MaritalStatus.Single; }
                                            if (Convert.ToInt32(happy) == 2) { Status_of_int = VkNet.Enums.MaritalStatus.Meets; }
                                            if (Convert.ToInt32(happy) == 3) { Status_of_int = VkNet.Enums.MaritalStatus.Engaged; }
                                            if (Convert.ToInt32(happy) == 4) { Status_of_int = VkNet.Enums.MaritalStatus.Married; }
                                            if (Convert.ToInt32(happy) == 5) { Status_of_int = VkNet.Enums.MaritalStatus.ItsComplicated; }
                                            if (Convert.ToInt32(happy) == 6) { Status_of_int = VkNet.Enums.MaritalStatus.TheActiveSearch; }
                                            if (Convert.ToInt32(happy) == 7) { Status_of_int = VkNet.Enums.MaritalStatus.InLove; }

                                            var sex_of_int = VkNet.Enums.Sex.Unknown;
                                            if (Convert.ToInt32(happy2) == 0) { sex_of_int = VkNet.Enums.Sex.Unknown; }
                                            if (Convert.ToInt32(happy2) == 1) { sex_of_int = VkNet.Enums.Sex.Female; }
                                            if (Convert.ToInt32(happy2) == 2) { sex_of_int = VkNet.Enums.Sex.Male; }

                                            var sort_of_int = VkNet.Enums.UserSort.ByPopularity;
                                            if (Convert.ToInt32(happy3) == 0) { sort_of_int = VkNet.Enums.UserSort.ByPopularity; }
                                            if (Convert.ToInt32(happy3) == 1) { sort_of_int = VkNet.Enums.UserSort.ByRegDate; }



                                            int age_from_to_of_int = Convert.ToInt32(happy4);

                                            ushort age_from_to_of_ushort = (ushort)age_from_to_of_int;
                                            int birthMonth_of_int = Convert.ToInt32(happy5);

                                            ushort birthMonth_of_ushort = (ushort)birthMonth_of_int;
                                            Console.WriteLine("Variacia 5 parametr ==\nStatus_of_int " + Status_of_int + " sex_of_int " + sex_of_int + " sort_of_int " + sort_of_int + " ge_from_to_of_ushort^ " + age_from_to_of_ushort + " birthMonth_of_ushort " + birthMonth_of_ushort);



                                            if (BirthYear_of_uint == 0) { BirthYear_of_uint = null; }
                                            if (Convert.ToInt32(happy) == 0)
                                            {
                                                var users = Avtorizacia.api.Users.Search(new UserSearchParams
                                                {
                                                    Query = Query,
                                                    City = City_of_int,
                                                    Offset = 0,
                                                    Count = 1000,
                                                    Country = Country_of_int,
                                                    University = University_of_int,
                                                    UniversityYear = UniversityYear_of_uint,
                                                    BirthDay = BirthDay_of_ushort,

                                                    BirthYear = BirthYear_of_uint,
                                                    Online = Online_of_bool,
                                                    HasPhoto = HasPhoto_of_bool,
                                                    School = School_of_int,

                                                    SchoolYear = SchoolYear_of_uint,
                                                    Religion = Religion,
                                                    Company = Company,
                                                    //вариативные параметры
                                                    // Status = Status_of_int, // Bez stutusa
                                                    Sex = sex_of_int,
                                                    Sort = sort_of_int,
                                                    AgeFrom = age_from_to_of_ushort,
                                                    AgeTo = age_from_to_of_ushort,
                                                    BirthMonth = birthMonth_of_ushort,
                                                    Interests = interest,
                                                    GroupId = id_group_member_of_ulong,


                                                    Fields = ProfileFields.City,



                                                }).ToList();

                                                foreach (var user in users)
                                                {
                                                    long s = user.Id;
                                                    vsego_id++;
                                                    BeginInvoke(new MethodInvoker(delegate
                                                    {


                                                        label13.Text = Convert.ToString("Всего найдено ИД: " + vsego_id);


                                                    }));

                                                    File.AppendAllText(patch_file, s.ToString() + Environment.NewLine);

                                                    Console.WriteLine(s + "  +++++++++++++++++++++++++++++++++++++++++++++  ");

                                                }
                                            }
                                            else {
                                                var users = Avtorizacia.api.Users.Search(new UserSearchParams
                                                {
                                                    Query = Query,
                                                    City = City_of_int,
                                                    Offset = 0,
                                                    Count = 1000,
                                                    Country = Country_of_int,
                                                    University = University_of_int,
                                                    UniversityYear = UniversityYear_of_uint,
                                                    BirthDay = BirthDay_of_ushort,

                                                    BirthYear = BirthYear_of_uint,
                                                    Online = Online_of_bool,
                                                    HasPhoto = HasPhoto_of_bool,
                                                    School = School_of_int,

                                                    SchoolYear = SchoolYear_of_uint,
                                                    Religion = Religion,
                                                    Company = Company,
                                                    //вариативные параметры
                                                    Status = Status_of_int, // C stutusom
                                                    Sex = sex_of_int,
                                                    Sort = sort_of_int,
                                                    AgeFrom = age_from_to_of_ushort,
                                                    AgeTo = age_from_to_of_ushort,
                                                    BirthMonth = birthMonth_of_ushort,
                                                    Interests = interest,
                                                    GroupId = id_group_member_of_ulong,


                                                    Fields = ProfileFields.City,



                                                }).ToList();

                                                foreach (var user in users)
                                                {
                                                    long s = user.Id;
                                                    vsego_id++;
                                                    BeginInvoke(new MethodInvoker(delegate
                                                    {


                                                        label13.Text = Convert.ToString("Всего найдено ИД: " + vsego_id);


                                                    }));

                                                    File.AppendAllText(patch_file, s.ToString() + Environment.NewLine);

                                                    Console.WriteLine(s + "  +++++++++++++++++++++++++++++++++++++++++++++  ");

                                                }
                                            }
                                        }
                                    }

                                }
                            }

                            else {  //Поиск = не глубокий


                               
                                Console.WriteLine("Cikl J no diver: " + happy + " - " + happy2 + " - " + happy3 + " - " + happy4 + " - ");



                                if (stop == 1)
                                {
                                    i = max_variant_status;
                                    j = max_variant_sex;
                                    j2 = max_variant_age;
                                  

                                }

                                if (i >= max_variant_status && j2>= max_variant_age)
                                {

                                    if (i == max_variant_status && j2 == max_variant_age)
                                    {
                                        if (dcp == 0)
                                        {
                                            dcp = 1; //флаг что бы 2 раза не срабатывала
                                            File.WriteAllLines(@patch_file, File.ReadAllText(@patch_file).Split().Distinct());
                                            int count_noduble = System.IO.File.ReadAllLines(patch_file).Length;

                                            MessageBox.Show("Файл: " + patch_file + "\nВсего ИД после удаления дублей: " + count_noduble, "Завершено! ");



                                            BeginInvoke(new MethodInvoker(delegate
                                            {
                                                label12.Text = "Завершено!";
                                                progressBar1.Value = (max_variant_status + 3);

                                            }));

                                        }
                                    }
                                    stop = 1;
                                    //i = max_variant_status + 2;
                                    //j3 = j3 + 2;
                                    Console.WriteLine("Uslovie esli i >= max_variant_status && j2 >= ?  " + i + " " + j2);

                                }
                                else
                                {

                                    if (stop != 1)
                                    {
                                        Thread.Sleep(Convert.ToInt32(textBox5.Text) * 1000);

                                        var Status_of_int = VkNet.Enums.MaritalStatus.Engaged;
                                        if (Convert.ToInt32(happy) == 1) { Status_of_int = VkNet.Enums.MaritalStatus.Single; }
                                        if (Convert.ToInt32(happy) == 2) { Status_of_int = VkNet.Enums.MaritalStatus.Meets; }
                                        if (Convert.ToInt32(happy) == 3) { Status_of_int = VkNet.Enums.MaritalStatus.Engaged; }
                                        if (Convert.ToInt32(happy) == 4) { Status_of_int = VkNet.Enums.MaritalStatus.Married; }
                                        if (Convert.ToInt32(happy) == 5) { Status_of_int = VkNet.Enums.MaritalStatus.ItsComplicated; }
                                        if (Convert.ToInt32(happy) == 6) { Status_of_int = VkNet.Enums.MaritalStatus.TheActiveSearch; }
                                        if (Convert.ToInt32(happy) == 7) { Status_of_int = VkNet.Enums.MaritalStatus.InLove; }
                                        

                                        var sex_of_int = VkNet.Enums.Sex.Unknown;
                                        if (Convert.ToInt32(happy2) == 0) { sex_of_int = VkNet.Enums.Sex.Unknown; }
                                        if (Convert.ToInt32(happy2) == 1) { sex_of_int = VkNet.Enums.Sex.Female; }
                                        if (Convert.ToInt32(happy2) == 2) { sex_of_int = VkNet.Enums.Sex.Male; }

                                        var sort_of_int = VkNet.Enums.UserSort.ByPopularity;
                                        if (Convert.ToInt32(happy3) == 0) { sort_of_int = VkNet.Enums.UserSort.ByPopularity; }
                                        if (Convert.ToInt32(happy3) == 1) { sort_of_int = VkNet.Enums.UserSort.ByRegDate; }



                                        int age_from_to_of_int = Convert.ToInt32(happy4);

                                        ushort age_from_to_of_ushort = (ushort)age_from_to_of_int;
                                        //int birthMonth_of_int = Convert.ToInt32(happy5);

                                        //ushort birthMonth_of_ushort = (ushort)birthMonth_of_int;
                                        Console.WriteLine("Variacia 5 parametr ==\nStatus_of_int " + Status_of_int + " sex_of_int " + sex_of_int + " sort_of_int " + sort_of_int + " ge_from_to_of_ushort^ " + age_from_to_of_ushort + " birthMonth_of_ushort " );



                                        if (BirthYear_of_uint == 0) { BirthYear_of_uint = null; }
                                        if (Convert.ToInt32(happy) == 0)
                                        {
                                            var users = Avtorizacia.api.Users.Search(new UserSearchParams
                                            {
                                                Query = Query,
                                                City = City_of_int,
                                                Offset = 0,
                                                Count = 1000,
                                                Country = Country_of_int,
                                                University = University_of_int,
                                                UniversityYear = UniversityYear_of_uint,
                                                BirthDay = BirthDay_of_ushort,

                                                BirthYear = BirthYear_of_uint,
                                                Online = Online_of_bool,
                                                HasPhoto = HasPhoto_of_bool,
                                                School = School_of_int,

                                                SchoolYear = SchoolYear_of_uint,
                                                Religion = Religion,
                                                Company = Company,
                                                //вариативные параметры
                                                //Status = Status_of_int,
                                                Sex = sex_of_int,
                                                Sort = sort_of_int,
                                                AgeFrom = age_from_to_of_ushort,
                                                AgeTo = age_from_to_of_ushort,
                                                // BirthMonth = birthMonth_of_ushort,   // убрал в не глубоком поиске
                                                Interests = interest,
                                                GroupId = id_group_member_of_ulong,


                                                Fields = ProfileFields.City,



                                            }).ToList();

                                            foreach (var user in users)
                                            {
                                                long s = user.Id;
                                                vsego_id++;
                                                BeginInvoke(new MethodInvoker(delegate
                                                {


                                                    label13.Text = Convert.ToString("Всего найдено ИД: " + vsego_id);


                                                }));

                                                File.AppendAllText(patch_file, s.ToString() + Environment.NewLine);

                                                Console.WriteLine(s + "  +++++++++++++status==0++++++++++++++++  ");

                                            }
                                        }
                                        else {

                                            var users = Avtorizacia.api.Users.Search(new UserSearchParams
                                            {
                                                Query = Query,
                                                City = City_of_int,
                                                Offset = 0,
                                                Count = 1000,
                                                Country = Country_of_int,
                                                University = University_of_int,
                                                UniversityYear = UniversityYear_of_uint,
                                                BirthDay = BirthDay_of_ushort,

                                                BirthYear = BirthYear_of_uint,
                                                Online = Online_of_bool,
                                                HasPhoto = HasPhoto_of_bool,
                                                School = School_of_int,

                                                SchoolYear = SchoolYear_of_uint,
                                                Religion = Religion,
                                                Company = Company,
                                                //вариативные параметры
                                                Status = Status_of_int,
                                                Sex = sex_of_int,
                                                Sort = sort_of_int,
                                                AgeFrom = age_from_to_of_ushort,
                                                AgeTo = age_from_to_of_ushort,
                                                // BirthMonth = birthMonth_of_ushort,   // убрал в не глубоком поиске
                                                Interests = interest,
                                                GroupId = id_group_member_of_ulong,


                                                Fields = ProfileFields.City,



                                            }).ToList();

                                            foreach (var user in users)
                                            {
                                                long s = user.Id;
                                                vsego_id++;
                                                BeginInvoke(new MethodInvoker(delegate
                                                {


                                                    label13.Text = Convert.ToString("Всего найдено ИД: " + vsego_id);


                                                }));

                                                File.AppendAllText(patch_file, s.ToString() + Environment.NewLine);

                                                Console.WriteLine(s + "  +++++++++++++++status!=0+++++++++++++  ");

                                            }


                                        }
                                    }
                                }



                            }


                        }

                    }

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stop = 1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory(); 
                        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
                       //saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 patch_file= saveFileDialog1.FileName;
                Console.WriteLine(patch_file);
                button1.Enabled = true;
                label12.Text = "Готово";
            }
           
        }
    }
}
