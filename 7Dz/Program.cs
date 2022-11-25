using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace _7Dz
{
    public enum Tip
    {
        Tekushiy = 1,
        Sberegatelniy = 2
    }

    internal class Song
    {
        string name;
        string author;
        readonly Song prev;
        public void SetName()
        {
            Console.WriteLine("Enter name of song");
            name = Console.ReadLine();
        }
        public void SetAuthor()
        {
            Console.WriteLine("Enter song`s author");
            author = Console.ReadLine();
        }
        public void SetPrev(Song song)
        {
            prev.name = song.name;
            prev.author = song.author;
        }
        public static string Title(Song song)
        {
            return $"{song.name} {song.author}";
        }
        public override bool Equals(object obj)
        {
            Song s = obj as Song;
            if (s != null)
            {
                if ($"{this.name} {this.author}" == Song.Title(s))
                {
                    return true;
                }
            }
            return false;
        }
    }
    internal class Program
    {
        public static void Zad82()
        {
            Console.WriteLine("Введите строку");
            string a = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                sb.Append(a[i]);
            }
            Console.WriteLine(sb);
        }
        public static void Readfileto(string way, string way2)
        {
            int k = 0;
            StreamReader reader = new StreamReader(way);//cxbnsdfm, mtrcn
            FileInfo a = new FileInfo(way2);
            a.Create().Dispose();
            StreamWriter writer = new StreamWriter(way2);
            while (reader.ReadLine() != null)
            {
                k++;
            }
            reader.Close();
            StreamReader reader1 = new StreamReader(way);
            for (int i = 0; i < k; i++)
            {
                writer.WriteLine(reader1.ReadLine().Split('#')[1]);
            }
            reader1.Close();
            writer.Close();
        }
        public static string Readstr(string v)
        {
            v = v.Split('#')[1];
            return v;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 8.1");
            Schet schet1 = new Schet(777,666,Tip.Tekushiy);
            Schet schet2 = new Schet(234, 696, Tip.Sberegatelniy);
            Console.WriteLine("Какую сумму хотите перевести из первого банка во второй?");
            int monney = Convert.ToInt32(Console.ReadLine());
            schet1.moneytransfer(schet2, monney);
            schet1.Print();
            schet2.Print();

            //Console.WriteLine("Задание 8.2");
            //Zad82();

            Console.WriteLine("Задание 8.3");
            const string outputFileName = "ResultText.out";
            Console.WriteLine("Введите название входного файла: ");
            string inputFileName = Console.ReadLine();

            if (File.Exists(inputFileName))
            {
                File.WriteAllText(outputFileName, File.ReadAllText(inputFileName, Encoding.UTF8).ToUpper(), Encoding.UTF8);
                Console.WriteLine("Результат успешно записан в файл с именем \"{0}\"", outputFileName);
            }
            else
            {
                Console.WriteLine("Файл с именем \"{0}\" не найден!", inputFileName);
            }

            Console.WriteLine("Задание 8.4");
            double d = 123.12345678901234;
            string[] formats = { "C", "E", "e", "F", "G", "N", "P", "R" };
            for (int i = 0; i < formats.Length; i++)
                Console.WriteLine("{0:R} as {1}:  {2}", d, formats[i], d.ToString(formats[i], null));

            string[] intFormats = { "D", "x", "X" };
            int val = 255;
            for (int i = 0; i < intFormats.Length; i++)
                Console.WriteLine("{0} as {1}:  {2}", val, intFormats[i], val.ToString(intFormats[i], null));

            Console.WriteLine("Задание 8.11");
            Console.WriteLine("ДЗ упражнение 8.1");
            string way = @"..\..\TextFile1.txt";
            string way2 = @"..\..\TextFile2.txt";
            Readfileto(way, way2);
            StreamReader reader1 = new StreamReader(way);
            Console.WriteLine(Readstr(reader1.ReadLine()));
            Console.WriteLine();

            // task 8.2
            List<Song> songs = new List<Song>();
            for (int i = 0; i < 4; i++)
            {
                Song song = new Song();
                song.SetName();
                song.SetAuthor();
                songs.Add(song);
            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(Song.Title(songs[i]));
            }

            Console.WriteLine(songs[0].Equals(songs[1]));

            Console.ReadKey();
            
        }
    }
}
