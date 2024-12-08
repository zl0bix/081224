using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _081224
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
           Book book = new Book();

            book.WorkConsole();
            
            /*Заранее создать файл с 10 английскими словами,
            Програма считывает слова а пользователь вводит перевод и записывает в файл с переводом(отдельный файл)*/
        }
    }

    class Book
    {
        string path = @"C:/txt/test.txt";
        string rFile = "";

        public string OpenFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public List<string> WorkFile()
        {
            string strTmp = OpenFile(path);

            List<string> _list = strTmp.Split('\n').ToList();

           
            return _list;
        }

        public void WorkConsole()
        {
            List<string> listTmp = WorkFile();  
            
            List<string> listInterpreter = new List<string>();


            for (int i = 0; i < listTmp.Count; i++)
            {
                Console.WriteLine("Введите значение слова " + listTmp[i]);

                WriteTxt(Console.ReadLine());
            }

        }
        public void WriteTxt(string str)
        {
            string path = @"C:/txt/test1.txt";

            using (FileStream fs = new FileStream(path, FileMode.Append))
            {
                using(StreamWriter sr = new StreamWriter(fs))
                {
                    sr.WriteLine(str);
                }
            }
        }      
    }
}
