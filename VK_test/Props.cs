using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace VK_test
{

    public class PropsFields
    {
      //  Console.WriteLine(Osnova.file_config);
        public String XMLFileName = Osnova.file_config;
        //Чтобы добавить настройку в программу просто добавьте туда строку вида -
        //public ТИП ИМЯ_ПЕРЕМЕННОЙ = значение_переменной_по_умолчанию;

        public String TextValueBox1;
        public String TextValueBox2;
        public String TextValueBox3;
        public String TextValueBox4;
        public String TextValueBox5;
        public String TextValueBox6;
        public String TextValueBox7;
        public String TextValueBox8;

        public Boolean BoolValueChebox1;
        public Boolean BoolValueChebox2;
        public Boolean BoolValueChebox3;
        public Boolean BoolValueChebox4;

        public int intValueCombox1;


    }

    class Props
    {
        public PropsFields Fields;

        public Props()
        {
            Fields = new PropsFields();
        }
        //Запись настроек в файл
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(PropsFields));

            TextWriter writer = new StreamWriter(Fields.XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        //Чтение насроек из файла
        public void ReadXml()
        {
            if (File.Exists(Fields.XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
                TextReader reader = new StreamReader(Fields.XMLFileName);
                Fields = ser.Deserialize(reader) as PropsFields;
                reader.Close();
            }
            else
            {
                //можно написать вывод сообщения если файла не существует
            }
        }
    }
}
