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
            CarService carService = new CarService();
        }
    }

    class Storehouse
    {
        private List<Cell> _cells = new List<Cell>();

        public Storehouse()
        {
            FillStorehouse();
        }

        public void RemoveCell(Cell cell)
        {
            _cells.Remove(cell);
        }

        public void ShowSpareParts()
        {
            Console.Clear();
            Console.WriteLine("У нас на складе есть следующие комплектующие для автомобиля:\n");

            foreach (var cell in _cells)
            {
                cell.ShowInfo();
            }

            Console.WriteLine("\nНажмите любую клавишу длявыхода в меню..");
            Console.ReadKey();
            Console.Clear();
        }

        public Cell TryBrokenCell(Part part)
        {
            Cell findCell = null;

            foreach (var cell in _cells)
            {
                if (cell.Part == part)
                {
                    findCell = cell;
                }
            }

            return findCell;
        }

        private void FillStorehouse()
        {
            Detail grm = new Detail("Ремень ГРМ", 6000);
            Detail sparkPlug = new Detail("Свеча зажигания", 500);
            Detail windShield = new Detail("Лобовое стекло", 8000);
            Detail wheel = new Detail("Кодесо", 4000);
            _cells.Add(new Cell(Part.ГРМ, "Ремень ГРМ", 5, grm));
            _cells.Add(new Cell(Part.Колесо, "Колесо", 11, wheel));
            _cells.Add(new Cell(Part.Свеча, "Свеча зажигания", 30, sparkPlug));
            _cells.Add(new Cell(Part.Лобовуха, "Лобовое стекло", 9, windShield));
        }
    }

    class CarService
    {
        private Storehouse _storehouse = new Storehouse();
        private int _balance = 1000000;
        private int _priceWork = 3000;
        private int _fine = 5000;

        public CarService()
        {
            StartWork();
        }

        private void StartWork()
        {
            bool isExit = false;

            while (isExit == false)
            {
                const string CommandShowPrices = "1";
                const string CommandFixCar = "2";
                const string CommandExit = "0";
                Client client = new Client();
                Console.WriteLine("Добро пожаловать в автосервис КАЛИНА-МАЛИНА\nВыберите пункт меню:");
                Console.WriteLine($"НАЖМИТЕ {CommandShowPrices} - Цена и наличие комплектующих\nНАЖМИТЕ {CommandFixCar} - Провести диагностику " +
                    $"и починить машину\nНАЖМИТЕ {CommandExit} - ВЫЙТИ");
                Console.Write("Ввод: ");
                string playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case CommandShowPrices:
                        _storehouse.ShowSpareParts();
                        break;
                    case CommandFixCar:
                        RepairCar(client);
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                }
            }
        }

        private void RepairCar(Client client)
        {
            Console.Clear();
            Console.WriteLine("Посмотрим, что тут у вас..");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Смотрим..");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Смотрим..");
            System.Threading.Thread.Sleep(1000);
            Cell brokenCell = _storehouse.TryBrokenCell(client.BrokenDetail);

            if (brokenCell != null)
            {
                Console.WriteLine($"У вас сломан следующий узел: {brokenCell.Name}");
                Troubleshoot(brokenCell, client);
            }
            else
            {
                Console.WriteLine("Сломанный узел не найден..");
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void Troubleshoot(Cell cell, Client client)
        {
            if (cell.CountDetails > 0)
            {
                const string CommandFixCar = "1";
                int totalPrice = cell.PriceDetail + _priceWork;
                Console.WriteLine($"\nОтлично, комплектующие есть в наличии, цена услуги составит: {totalPrice} руб.");
                Console.Write($"Нажмите {CommandFixCar}, чтобы расплатиться и починить машину\nНажмите любую клавишу, чтобы выйти\n\nВаш ввод: ");
                string playerInput = Console.ReadLine();

                if (playerInput == CommandFixCar)
                {
                    ReplaceDetail(cell, totalPrice, client);

                }
            }
            else
            {
                Console.WriteLine($"Детали на складе закончились, просим прощения и готовы выплатить компенсацию(штраф) в размере: {_fine} руб.");

                if (_balance > _fine)
                {
                    _balance -= _fine;
                }
                else
                {
                    Console.WriteLine("Вы банкорот, закрывайтесь");
                }
            }
        }

        private void ReplaceDetail(Cell cell, int totalPrice, Client client)
        {
            if (client.TryPayOff(totalPrice))
            {
                _balance += totalPrice;
                cell.RemoveDetail();

                if (cell.CountDetails == 0)
                {
                    _storehouse.RemoveCell(cell);
                }

                Console.WriteLine("Машина починина, езжайте с Богом..");
            }
            else
            {
                Console.WriteLine("Клиент оказался не способен оплатить заказ, гоните его в щи");
            }
        }
    }

    class Client
    {
        private int _money;
        private Random _random = new Random();

        public Client()
        {
            int minMoney = 1000;
            int maxMoney = 20001;
            _money = _random.Next(minMoney, maxMoney);
            BrokenDetail = GetBrokenDetail();
        }

        public Part BrokenDetail { get; private set; }

        public bool TryPayOff(int repairPrice)
        {
            if (_money > repairPrice)
            {
                _money -= repairPrice;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Part GetBrokenDetail()
        {
            Part[] spareParts = (Part[])Enum.GetValues(typeof(Part));
            return BrokenDetail = (Part)_random.Next(0, spareParts.Length + 1);
        }
    }

    class Cell
    {
        public Cell(Part part, string name, int countDetails, Detail detail)
        {
            Name = name;
            CountDetails = countDetails;
            Part = part;
            PriceDetail = detail.GetPrice();

            for (int i = 0; i < countDetails; i++)
            {
                FillParts();
            }
        }

        public string Name { get; private set; }
        public int CountDetails { get; private set; }
        public int PriceDetail { get; private set; }
        public Part Part { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {PriceDetail} руб, в наличии {CountDetails} штук");
        }

        public void RemoveDetail()
        {
            CountDetails--;
        }

        private void FillParts()
        {
            CountDetails++;
        }
    }

    class Detail
    {
        private string _name;
        private int _price;

        public Detail(string name, int price)
        {
            _name = name;
            _price = price;
        }

        public int GetPrice()
        {
            return _price;
        }
    }

    enum Part
    {
        ГРМ,
        Колесо,
        Свеча,
        Лобовуха
    }
}
