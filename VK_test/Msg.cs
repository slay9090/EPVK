using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VK_test
{
    public static class Msg
    {
        public static void MessageInfo(string caption, string msg)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void MessageError(string caption, string msg)
        {
          //  MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void MessageError(Exception _ex, string caption)
        {
          //  MessageBox.Show(_ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            WriteLog(_ex.Message + "\n************************\n" + _ex.StackTrace + "\n******************\n\n");
        }

        public static void ShowError(Exception _ex, string caption)
        {
            MessageBox.Show(_ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(string txt, string caption)
        {
            MessageBox.Show(txt, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult MessageQuery(string caption, string msg)
        {
            return MessageBox.Show(msg, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static void WriteLog(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return;
            string path = Directory.GetCurrentDirectory() + "\\log.txt";
            using (var outfile = new StreamWriter(path, true, Encoding.UTF8))
            {
                outfile.WriteLine("***********************");
                outfile.WriteLine("дата: {0}", DateTime.Now);
                outfile.WriteLine();
                outfile.Write(msg);
            }
        }
    }
}
