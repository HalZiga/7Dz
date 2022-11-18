using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Dz
{
    public class Schet
    {
        private static uint nomer;
        private float balanse;
        private Tip tip;
        private static HashSet<uint> Last_Random = new HashSet<uint> { };
        public Schet(uint _nomer, float _balanse, Tip _trip)
        {
            nomer = _nomer;
            while (!Last_Random.Add(nomer))//закидываем в HashSet и проверяем был или нет
            {
                nomer += 1;
            }
            balanse = _balanse;
            tip = _trip;
            Print();
        }
        public Schet()
        {
            nomer++;
            while (!Last_Random.Add(nomer))//закидываем в HashSet и проверяем был или нет
            {
                nomer += 1;
            }
            balanse = Rand();
            tip = (Tip)1;

        }
        public uint Rand()
        {
            Random rnd = new Random();
            uint b = (uint)rnd.Next(0, 99999);//как сделать так чтобы метод в котором рандом при разных вызовах генерировал разные значения
            return b;
        }



        public bool Snat(float temp)
        {
            //Console.Write("Введите сумму для пополнения ");
            //float temp = float.Parse(Console.ReadLine());
            if (balanse - temp >= 0)
            {
                return true;
                //Console.WriteLine($"Балансе на данный момент: {balanse -= temp}");
            }
            else
            { 
                //Console.WriteLine("Вы не можете снять такую сумму");
                return false;
            }
        }
        public void Popoln()
        {
            Console.Write("Введите сумму для пополнения ");
            float temp = float.Parse(Console.ReadLine());
            Console.WriteLine($"Балансе на данный момент: {balanse += temp}");

        }
        public void Print()
        {
            Console.WriteLine("Номер: " + nomer);
            Console.WriteLine("Баланс: " + balanse);
            Console.WriteLine("Тип: " + tip);
        }
        public void moneytransfer(Schet Bank, int amount)
        {
            
            if (Snat(amount))
            {
                this.balanse -= amount;
                Bank.balanse += amount;
            }
            else
            {
                Console.WriteLine("Вы не можете снять такую сумму");
            }
            
        }
    }
}
