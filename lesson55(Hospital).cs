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
            Hospital hospitalProgram = new Hospital();
            hospitalProgram.Start();
        }
    }

    class Hospital
    {
        private List<Ill> _ills = new List<Ill>();

        public Hospital()
        {
            FillDataBase();
        }

        public void Start()
        {
            const string CommandSortName = "1";
            const string CommandSortAge = "2";
            const string CommandFilteredDesease = "3";
            const string CommandExit = "0";

            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Здравствуйте вы в программе управления данными больницы, в ней вы можете");
                Console.WriteLine($"НАЖАВ {CommandSortName} - Отсортировать всех больных по ФИО\nНАЖАВ {CommandSortAge} - Отсортировать всех больных по возрасту" +
                    $"\nНАЖАВ {CommandFilteredDesease} - Вывести больных с определенным заболеванием\nНАЖАВ {CommandExit} - Выйти");
                Console.SetCursorPosition(0, 10);
                Console.WriteLine($"Список всех больных:");
                ShowInfoAboutIlls(_ills);
                Console.SetCursorPosition(0, 4);
                Console.Write("Ваш ввод: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSortName:
                        SortName();
                        break;
                    case CommandSortAge:
                        SortAge();
                        break;
                    case CommandFilteredDesease:
                        FilteredDesease();
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

        private void FilteredDesease()
        {
            Console.Clear();
            Console.Write("Введите заболевание по которому хотите найти больных: ");
            string userInput = Console.ReadLine();
            var filteredDeseaseIlls = _ills.Where(ill => ill.Desease.ToUpper() == userInput.ToUpper());

            if (filteredDeseaseIlls.ToList().Count > 0)
            {
                ShowInfoAboutIlls(filteredDeseaseIlls.ToList());
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Больных с таким заболеванием нет..");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SortName()
        {
            var sortNameIlls = _ills.OrderBy(ill => ill.Name);
            Console.Clear();
            Console.WriteLine($"Список больных отсортированных по ФИО");
            ShowInfoAboutIlls(sortNameIlls.ToList());
            Console.ReadKey();
            Console.Clear();
        }

        private void SortAge()
        {
            var sortAgeIlls = _ills.OrderBy(ill => ill.Age);
            Console.Clear();
            Console.WriteLine($"Список больных отсортированных по возрасту");
            ShowInfoAboutIlls(sortAgeIlls.ToList());
            Console.ReadKey();
            Console.Clear();
        }

        private void FillDataBase()
        {
            _ills.Add(new Ill("Иванов Дмитрий Петровч", 64, "Бронхит"));
            _ills.Add(new Ill("Мельникова Ксения Витальевна", 55, "Грип"));
            _ills.Add(new Ill("Иванова София Ивановна", 43, "Ковид"));
            _ills.Add(new Ill("Буракшаева Юлия Сергеевна", 65, "Перхоть"));
            _ills.Add(new Ill("Фурсова Елизавета Владимировна", 23, "Отравление"));
            _ills.Add(new Ill("Сапсай Иван Алексеевич", 52, "Астма"));
            _ills.Add(new Ill("Богословский Артем Михайлович", 66, "Диарея"));
            _ills.Add(new Ill("Самбикина Юлия Владимировна", 45, "Ангина"));
            _ills.Add(new Ill("Шпак Ангелина Эдуардовна", 32, "Ковид"));
            _ills.Add(new Ill("Пименов Максим Евгеньевич", 98, "Бронхит"));
            _ills.Add(new Ill("Сигида Валерия Романовна", 34, "Бронхит"));
            _ills.Add(new Ill("Миронова Елизавета Валерьевна", 21, "Перхоть"));
        }

        private void ShowInfoAboutIlls(List<Ill> ills)
        {
            int number = 1;

            foreach (var ill in ills)
            {
                Console.Write(number + ". ");
                ill.ShowInfo();
                number++;
            }
        }
    }

    class Ill
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Desease { get; private set; }

        public Ill(string name, int age, string desease)
        {
            Name = name;
            Age = age;
            Desease = desease;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {Name}, возраст - {Age}, заболевание - {Desease} ");
        }
    }
}
