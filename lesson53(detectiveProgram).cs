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
            DetectiveProgram detectiveProgram = new DetectiveProgram();
            detectiveProgram.Start();
        }
    }

    class DetectiveProgram
    {
        private List<Criminal> _criminals = new List<Criminal>();

        public DetectiveProgram()
        {
            FillDataBase();
        }

        public void Start()
        {
            const string CommandStartFiltered = "1";
            const string CommandShowAllCriminals = "2";
            const string CommandExit = "0";

            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Добро пожаловать в программу ОКО\nОна позволяет найти преступников из базы данных по определенным параметрам\n");
                Console.Write($"НАЖМИТЕ {CommandStartFiltered} - Начать поиск\nНАЖМИТЕ {CommandShowAllCriminals} - " +
                    $"Показать всех преступников\nНАЖМИТЕ {CommandExit} - Выйти\n\nВаш ввод: ");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandStartFiltered:
                        FilteredCriminal();
                        break;
                    case CommandShowAllCriminals:
                        ShowInfoAboutAllCriminals();
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
        }

        private void FilteredCriminal()
        {
            Console.Write("Введите рост преступника: ");
            int inputGrowth = InputParameter();
            Console.Write("Введите вес преступника: ");
            int inputWeith = InputParameter();
            Console.Write("Введите национальность преступника: ");
            string inputNationality = Console.ReadLine();
            var filteredCriminals = _criminals.Where(criminal => criminal.Growth == inputGrowth && criminal.Weith == inputWeith &&
            criminal.Nationality == inputNationality && criminal.IsPrisoner == false);
            Console.Clear();
            Console.WriteLine($"Список преступников по вашему запросу:  Рост - {inputGrowth}, Вес - {inputWeith}," +
                $" Национальность - {inputNationality}");

            if (filteredCriminals.ToList().Count > 0)
            {
                foreach (var criminal in filteredCriminals)
                {
                    criminal.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("\nПреступников с такими данными нет");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private int InputParameter()
        {
            string inputParameter = Console.ReadLine();
            bool inputParamIsNumber = int.TryParse(inputParameter, out int parameter);

            while (inputParamIsNumber == false)
            {
                Console.Write("Введие число: ");
                inputParameter = Console.ReadLine();
                inputParamIsNumber = int.TryParse(inputParameter, out parameter);
            }

            return parameter;
        }

        private void FillDataBase()
        {
            _criminals.Add(new Criminal("Борис", 180, 90, false, "русский"));
            _criminals.Add(new Criminal("Никита", 183, 60, false, "русский"));
            _criminals.Add(new Criminal("Тиль", 195, 102, true, "немец"));
            _criminals.Add(new Criminal("Олег", 191, 89, false, "русский"));
            _criminals.Add(new Criminal("Куртамбек", 177, 83, false, "казах"));
            _criminals.Add(new Criminal("Альтаир", 174, 83, true, "осетин"));
        }

        private void ShowInfoAboutAllCriminals()
        {
            foreach (var criminal in _criminals)
            {
                criminal.ShowInfo();
            }

            Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public int Growth { get; private set; }
        public int Weith { get; private set; }
        public bool IsPrisoner { get; private set; }
        public string Nationality { get; private set; }

        public Criminal(string name, int growth, int weith, bool isPrisoner, string nationality)
        {
            Name = name;
            Growth = growth;
            Weith = weith;
            IsPrisoner = isPrisoner;
            Nationality = nationality;
        }

        public void ShowInfo()
        {
            Console.Write($"Имя - {Name}  Рост - {Growth} Вес - {Weith}  Национальность - {Nationality}:  ");

            if (IsPrisoner)
            {
                Console.WriteLine("Заключен под стражу");
            }
            else
            {
                Console.WriteLine("Не заключен под стражу");
            }
        }
    }
}
