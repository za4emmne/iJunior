using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            FindOverdueProgram findOverdueProgram = new FindOverdueProgram();
            findOverdueProgram.Start();
        }
    }

    class FindOverdueProgram
    {
        private List<Soldier> _soldiers = new List<Soldier>();
        private Random _random = new Random();

        public FindOverdueProgram()
        {
            FillDataBase();
        }

        public void Start()
        {
            Console.WriteLine("Добро пожаловать в программу поиска солдат по вашим запросам\nЗапросы которые мы можем обработать:");

            Console.Write("Ваш ввод: ");
            var filteredWeaponSoldiers = _soldiers.Where(soldier => soldier.Name != null && soldier.Name != null).

            foreach (var soldier in filteredWeaponSoldiers)
            {
                Console.WriteLine(soldier);
            } 
        }



        private void FillDataBase()
        {
            _soldiers.Add(new Soldier("Олег", "Пистолет", "лейтенант", 65));
            _soldiers.Add(new Soldier("Дмитрий", "Автомат", "сержант", 33));
            _soldiers.Add(new Soldier("Александр", "Пистолет", "лейтенант", 65));
            _soldiers.Add(new Soldier("Илья", "Пистолет", "старший лейтенант", 73));
            _soldiers.Add(new Soldier("Михаил", "Автомат", "рядовой", 10));
            _soldiers.Add(new Soldier("Андрей", "Карабин", "ефрейтор", 29));
            _soldiers.Add(new Soldier("Максим", "Пистолет", "полковник", 150));
            _soldiers.Add(new Soldier("Семен", "Автомат", "сержант", 60));
        }

        private void ShowInfoAboutAllSoldiers(List<Soldier> soldiers)
        {
            Console.WriteLine("\nСписок всех военнослужащих: ");

            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int WorkTime { get; private set; }

        public Soldier(string name, string weapon, string rank, int workTime)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            WorkTime = workTime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {Name}  Оружие - {Weapon}  Звание - {Rank}  Срок службы - {WorkTime}");
        }

        public void ShowFiltered()
        {
            Console.WriteLine($"Имя - {Name}  Звание - {Rank}");
        }
    }
