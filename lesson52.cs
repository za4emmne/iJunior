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
        public List<Cell> Cells { get; private set; }

        public Storehouse()
        {
            Cells = new List<Cell>();
            FillCells();
        }

        public void RemoveCell(Cell cell)
        {
            Cells.Remove(cell);
        }

        public void ShowSpareParts()
        {
            Console.Clear();
            Console.WriteLine("У нас на складе есть следующие комплектующие для автомобиля:\n");

            foreach (var cell in Cells)
            {
                cell.ShowInfo();
            }

            Console.WriteLine("\nНажмите любую клавишу длявыхода в меню..");
            Console.ReadKey();
            Console.Clear();
        }

        private void FillCells()
        {
            Cells.Add(new Cell(Part.GRM, "Ремень ГРМ", 5, new GRM()));
            Cells.Add(new Cell(Part.Wheel, "Колесо", 11, new Wheel()));
            Cells.Add(new Cell(Part.SparkPlug, "Свечи зажигания", 30, new SparkPlug()));
            Cells.Add(new Cell(Part.WindShield, "Лобовое стекло", 9, new WindShield()));
        }
    }

    class CarService
    {
        Storehouse storehouse = new Storehouse();
        private int _balance = 1000000;
        private int _priceWork = 3000;
        private int _fine = 5000;

        public CarService()
        {
            StartWork();
        }

        public void StartWork()
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
                        storehouse.ShowSpareParts();
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

            foreach (var cell in storehouse.Cells)
            {
                if (cell.Part == client.BrokenDetail)
                {
                    Console.WriteLine($"У вас сломан следующий узел: {cell.Name}");
                    Troubleshoot(cell, client);
                    break;
                }
            }

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
                    storehouse.RemoveCell(cell);
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
        public Part BrokenDetail { get; private set; }

        public Client()
        {
            int minMoney = 1000;
            int maxMoney = 20001;
            _money = _random.Next(minMoney, maxMoney);
            BrokenDetail = GetBrokenDetail();
        }

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
        private List<Detail> _details = new List<Detail>();
        public string Name { get; private set; }
        public int CountDetails { get; private set; }
        public int PriceDetail { get; private set; }
        public Part Part { get; private set; }

        public Cell(Part part, string name, int countDetails, Detail detail)
        {
            Name = name;
            CountDetails = _details.Count;
            Part = part;
            PriceDetail = detail.Price;

            for (int i = 0; i < countDetails; i++)
            {
                FillParts(detail);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {PriceDetail} руб, в наличии {_details.Count} штук");
        }

        public void RemoveDetail()
        {
            _details.RemoveAt(0);
        }

        private void FillParts(Detail detail)
        {
            _details.Add(detail);
        }
    }

    class WindShield : Detail
    {
        public WindShield()
        {
            Name = "Лобовое стекло";
            Price = 8000;
        }
    }

    class SparkPlug : Detail
    {
        public SparkPlug()
        {
            Name = "Свечи зажигания";
            Price = 500;
        }
    }

    class Wheel : Detail
    {
        public Wheel()
        {
            Name = "Руль";
            Price = 4000;
        }
    }

    class GRM : Detail
    {
        public GRM()
        {
            Name = "Ремень ГРМ";
            Price = 6000;
        }
    }

    class Detail
    {
        protected string Name;
        public int Price { get; protected set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Деталь: {Name}, цена: {Price} дереянных");
        }
    }

    enum Part
    {
        GRM,
        Wheel,
        SparkPlug,
        WindShield
    }
}
