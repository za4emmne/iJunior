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
            const string CommandShowAllSoldiers = "1";
            const string CommandFilteredWeapon = "2";
            const string CommandFilteredWorkTime = "3";
            const string CommandSortWorkTime = "4";
            const string CommandSortName = "5";
            const string CommandExit = "0";

            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Добро пожаловать в программу поиска солдат по вашим запросам\nЗапросы которые мы можем обработать:");
                Console.WriteLine($"\nНАЖМИТЕ {CommandShowAllSoldiers} - показать всех военнослужащих\nНАЖМИТЕ {CommandFilteredWeapon} - " +
                    $"найти военнослужащих с этим оружием\nНАЖМИТЕ {CommandFilteredWorkTime} - найти военнослужащих с этим сроком службы" +
                    $"\nНАЖМИТЕ {CommandSortWorkTime} - отсортировать военнослужащих по сроку службы\nНАЖМИТЕ {CommandSortName} - сортировать военнослужащих" +
                    $"по имени\nНАЖМИТЕ {CommandExit} - выйти\n");
                Console.Write("Ваш ввод: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowAllSoldiers:
                        ShowInfoAboutAllSolsiers();
                        break;
                    case CommandFilteredWeapon:
                        FilteredWeaponSoldiers();
                        break;
                    case CommandFilteredWorkTime:
                        FilteredWorkTimeSoldiers();
                        break;
                    case CommandSortWorkTime:
                        SortWorkTimeSoldiers();
                        break;
                    case CommandSortName:
                        SortNameSoldiers();
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет..");
                        break;
                }
            }
        }

        private void SortNameSoldiers()
        {
            Console.Clear();
            Console.WriteLine("Военнослужащие отсортированные по имени: ");
            var sortNameSoldiers = _soldiers.OrderBy(soldier => soldier.Name);

            foreach (var soldier in sortNameSoldiers)
            {
                soldier.ShowFiltered();
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void SortWorkTimeSoldiers()
        {
            Console.Clear();
            Console.WriteLine("Военнослужащие отсортированные по сроку службы(от большего к меньшему): ");
            var sortWorkTimeSoldiers = _soldiers.OrderByDescending(soldier => soldier.WorkTime);

            foreach (var soldier in sortWorkTimeSoldiers)
            {
                soldier.ShowFiltered();
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void FilteredWorkTimeSoldiers()
        {
            Console.Clear();
            Console.Write("Введите срок службы, по которому хотите найти солдат: ");
            string userInputWorkTime = Console.ReadLine();
            bool isNumber = int.TryParse(userInputWorkTime, out int inputWorkTime);

            while (isNumber == false)
            {
                Console.Write("Введите число: ");
                isNumber = int.TryParse(userInputWorkTime = Console.ReadLine(), out inputWorkTime);
            }

            var filteredWorkTimeSoldiers = _soldiers.Where(soldier => soldier.WorkTime == inputWorkTime);

            if (filteredWorkTimeSoldiers.ToList().Count > 0)
            {
                Console.WriteLine("Список солдат со сроком службы - " + userInputWorkTime + ":");

                foreach (var soldier in filteredWorkTimeSoldiers)
                {
                    soldier.ShowFiltered();
                }
            }
            else
            {
                Console.WriteLine("Военнослужащих с таким сроком службы нет");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void FilteredWeaponSoldiers()
        {
            Console.Clear();
            Console.Write("Введите оружие, по которому хотите найти солдат: ");
            string userInputWeapon = Console.ReadLine();
            var filteredWeaponSoldiers = _soldiers.Where(soldier => soldier.Weapon.ToUpper() == userInputWeapon.ToUpper());

            if (filteredWeaponSoldiers.ToList().Count > 0)
            {
                Console.WriteLine("Список солдат с оружием - " + userInputWeapon.ToLower() + ":");

                foreach (var soldier in filteredWeaponSoldiers)
                {
                    soldier.ShowFiltered();
                }
            }
            else
            {
                Console.WriteLine("Военнослужащих с таким оружием нет");
            }

            Console.ReadKey();
            Console.Clear();
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

        private void ShowInfoAboutAllSolsiers()
        {
            Console.WriteLine("\nСписок всех военнослужащих: ");

            foreach (var soldier in _soldiers)
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
}
