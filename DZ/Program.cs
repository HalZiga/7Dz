using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ
{
    public class Person
    {
        public string name { get; set; }
        public Person boss { get; set; }
        public bool lv { get; set; }
        public Person(string name, Person boss)
        {
            this.name = name;
            this.boss = boss;
            lv = true;
        }
        public Person(string name, Person boss, bool lv)
        {
            this.name = name;
            this.boss = boss;
            this.lv = lv;
        }
    }
    internal class Program
    {
        static void Answer(string nameBoss, string nameEmployee, List<Person> list, string zadacha)
        {
            if (list.Find(i => i.name == nameEmployee && i.boss != null && i.boss.name == nameBoss && i.lv) != null)
            {
                Console.WriteLine($"От {nameBoss} дана задача: {zadacha} сотруднику {nameEmployee}. Ответ сотрудника: да берусь за задачу");
            }
            else if (list.Find(i => i.boss.name == nameBoss) == null)
            {
                Console.WriteLine("Нет босса с таким именем");
            }
            else if (list.Find(i => i.name == nameEmployee) == null)
            {
                Console.WriteLine("Нет сатрудника с таким именем");
            }
            else if ((list.Find(i => i.lv == false) == null))
            {
                Console.WriteLine("Этот сотрудник не может давать команды");
            }


            //Console.WriteLine($"От {nameBoss} дана задача: {zadacha} сотруднику {nameEmployee}. Ответ сотрудника: " +
            // $"{((list.Find(i => i.name == nameBoss && i.boss == null) != null && list.Find(i => i.name == nameEmployee && i.boss != null && i.boss.name == nameBoss || ) != null)? "Да" : "Нет")}");
        }
        static void Main(string[] args)
        {
            Person BorisBoss = new Person("Борис", null);
            Person Rashidboss = new Person("Рашид", BorisBoss);
            Person OIlhamboss = new Person("О Ильхам", BorisBoss);

            Person LukasEmp = new Person("Лукас", Rashidboss);

            Person OrcadiyBoss = new Person("Оркадий", OIlhamboss);
            Person VolodyaEmp = new Person("Володя", OrcadiyBoss);
            // системщики
            Person IlshatBoss = new Person("Ильшат", VolodyaEmp);
            Person IvanychEmp = new Person("Иваныч", IlshatBoss);
            Person IlyaEmp = new Person("Илья", IvanychEmp, false);
            Person VityaEmp = new Person("Витя", IvanychEmp, false);
            Person JhenyaEmp = new Person("Женя", IvanychEmp, false);
            //Разработка
            Person SergeyBoss = new Person("Сергей", VolodyaEmp);
            Person LyaisanEmp = new Person("Ляйсан", SergeyBoss);
            Person MaratEmp = new Person("Марат", LyaisanEmp, false);
            Person DinaEmp = new Person("Дина", LyaisanEmp, false);
            Person IldarEmp = new Person("Ильдар", LyaisanEmp, false);
            Person AntonEmp = new Person("Антон", LyaisanEmp, false);

            int i = 0;
            while (i < 5)
            {
                Console.WriteLine("Введите название задачи");
                string nameoftask = Console.ReadLine();
                Console.WriteLine("Укажите в какой отдел хотите адресовать задачу\nСистемщики или Разработчики или Начальство");
                string Direction = Console.ReadLine();
                Console.WriteLine("От кого задача");
                string nameBoss = Console.ReadLine();
                Console.WriteLine("Кому задача");
                string nameEmployee = Console.ReadLine();
                switch (Direction)
                {
                    case "Системщики":
                        List<Person> System = new List<Person>();
                        System.Add(OrcadiyBoss);
                        System.Add(VolodyaEmp);
                        System.Add(IlshatBoss);
                        System.Add(IvanychEmp);
                        System.Add(IlyaEmp);
                        System.Add(VityaEmp);
                        System.Add(JhenyaEmp);
                        Answer(nameBoss, nameEmployee, System, nameoftask);
                        break;
                    case "Разработчики":
                        List<Person> Development = new List<Person>();
                        Development.Add(OrcadiyBoss);
                        Development.Add(VolodyaEmp);
                        Development.Add(SergeyBoss);
                        Development.Add(LyaisanEmp);
                        Development.Add(MaratEmp);
                        Development.Add(DinaEmp);
                        Development.Add(IldarEmp);
                        Development.Add(AntonEmp);
                        Answer(nameBoss, nameEmployee, Development, nameoftask);

                        break;
                    case "Начальство":
                        List<Person> Bosses = new List<Person>();
                        Bosses.Add(BorisBoss);
                        Bosses.Add(Rashidboss);
                        Bosses.Add(OIlhamboss);
                        Bosses.Add(OrcadiyBoss);
                        Bosses.Add(VolodyaEmp);
                        Answer(nameBoss, nameEmployee, Bosses, nameoftask);
                        break;
                }
                i++;
            }

        }
    }
}
