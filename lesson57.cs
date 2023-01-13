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
        private List<Steve> _steves = new List<Steve>();
        private Random _random = new Random();

        public FindOverdueProgram()
        {
            FillDataBase();
        }

        public void Start()
        {
            Console.WriteLine("Добро пожаловать в программу не отравись тушенкой\nВот весь имеющийся запас:");
            ShowInfoAboutAllSteve();
            Console.WriteLine("\nНАЖМИТЕ любую кнопку чтобы найти просроченную тушенку..");
            Console.ReadKey();
            Console.Clear();
            FindOverdueSteves();
        }

        private void FindOverdueSteves()
        {
            int currentYear = 2023;
            var overdueSteves = _steves.Where(steve => (steve.ProductionYear + steve.ShelfLife) < currentYear);
            Console.WriteLine("Список просроченной тушенки:");

            foreach (var steve in overdueSteves)
            {
                steve.ShowInfo();
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void FillDataBase()
        {
            int countSteve = 20;
            int minShelfLife = 1;
            int maxShelfLife = 6;
            int minProductionYear = 2015;
            int maxProductionYear = 2024;
            string[] nameSteve = new string[] { "Гос. резерв", "Орская", "Армейская", "Вкусная", "Халяль" };

            for (int i = 0; i < countSteve; i++)
            {
                int numberRandomName = _random.Next(0, nameSteve.Length);
                int randomShelfLife = _random.Next(minShelfLife, maxShelfLife);
                int randomProductionYear = _random.Next(minProductionYear, maxProductionYear);
                _steves.Add(new Steve(nameSteve[numberRandomName], randomShelfLife, randomProductionYear));
            }
        }

        private void ShowInfoAboutAllSteve()
        {
            foreach (var steve in _steves)
            {
                steve.ShowInfo();
            }
        }
    }

    class Steve
    {
        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ShelfLife { get; private set; }

        public Steve(string name, int productionYear, int shelfLife)
        {
            Name = name;
            ProductionYear = productionYear;
            ShelfLife = shelfLife;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название - {Name}  Год изготовления - {ProductionYear}  Срок годности - {ShelfLife}");
        }
    }
}
