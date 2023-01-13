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
            carService.StartWork();
        }
    }

    class CarService
    {
        private int _balance = 1000000;
        private List<Cell> _cells = new List<Cell>();
        private int _priceWork = 3000;
        private int _fine = 5000;

        public CarService()
        {
            FillCells();
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
                        ShowSpareParts();
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

        private void RepairCar(Client client)
        {
            Console.Clear();
            Console.WriteLine("Посмотрим, что тут у вас..");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Смотрим..");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Смотрим..");
            System.Threading.Thread.Sleep(1000);

            foreach (var cell in _cells)
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

                switch (playerInput)
                {
                    case CommandFixCar:
                        ReplaceDetail(cell, totalPrice, client);
                        break;
                    default:
                        break;
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
            if (client.IsPayOff(totalPrice))
            {
                _balance += totalPrice;
                cell.RemoveDetail();

                if (cell.CountDetails == 0)
                {
                    _cells.Remove(cell);
                }

                Console.WriteLine("Машина починина, езжайте с Богом..");
            }
            else
            {
                Console.WriteLine("Клиент оказался не способен оплатить заказ, гоните его в щи");
            }
        }

        private void FillCells()
        {
            _cells.Add(new Cell(Part.GRM, "Ремень ГРМ", 5, new GRM()));
            _cells.Add(new Cell(Part.Wheel, "Колесо", 11, new Wheel()));
            _cells.Add(new Cell(Part.SparkPlug, "Свечи зажигания", 30, new SparkPlug()));
            _cells.Add(new Cell(Part.WindShield, "Лобовое стекло", 9, new WindShield()));
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

        public bool IsPayOff(int repairPrice)
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
            this.Name = name;
            this.CountDetails = countDetails;
            Part = part;
            PriceDetail = detail.GetPrice();

            for (int i = 0; i < countDetails; i++)
            {
                FillParts(detail);
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} - {PriceDetail} руб, в наличии {_details.Count} штук");
        }

        public int RemoveDetail()
        {
            int numberDetail = 1;
            _details.RemoveAt(numberDetail);
            return CountDetails--;
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
            name = "Лобовое стекло";
            price = 8000;
        }
    }

    class SparkPlug : Detail
    {
        public SparkPlug()
        {
            name = "Свечи зажигания";
            price = 500;
        }
    }

    class Wheel : Detail
    {
        public Wheel()
        {
            name = "Руль";
            price = 4000;
        }
    }

    class GRM : Detail
    {
        public GRM()
        {
            name = "Ремень ГРМ";
            price = 6000;
        }
    }

    class Detail
    {
        protected string name;
        protected int price;

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Деталь: {name}, цена: {price} дереянных");
        }

        public virtual int GetPrice()
        {
            return price;
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
