using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Dz
{
    public enum Tip
    {
        Tekushiy = 1,
        Sberegatelniy = 2
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

        static void Main(string[] args)
        {
            Schet schet1 = new Schet(777,666,Tip.Tekushiy);
            Schet schet2 = new Schet(234, 696, Tip.Sberegatelniy);

            Console.WriteLine("Какую сумму хотите перевести из первого банка во второй?");
            
            
            int monney = Convert.ToInt32(Console.ReadLine());
            schet1.moneytransfer(schet2, monney);
            schet1.Print();
            schet2.Print();

            //Console.WriteLine("Задание 8.2");
            //Zad82();


            Console.ReadKey();
            
        }
    }
}
