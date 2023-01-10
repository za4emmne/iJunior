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
            carService.Menu();
        }
    }

    class CarService
    {
        private int _balance = 1000000;
        private List<SpareParts> _spares = new List<SpareParts>();
        private int _priceWork = 3000;
        private int _fine = 5000;

        public CarService()
        {
            FillZip();
        }

        public void Menu()
        {
            bool isExit = false;

            while (isExit == false)
            {
                Client client = new Client();
                const string CommandShowPrices = "1";
                const string CommandFixCar = "2";
                const string CommandExit = "0";
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
                        DiagnoseCar(client);
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                }
            }
        }

        private void DiagnoseCar(Client client)
        {
            Console.Clear();
            Console.WriteLine("Посмотрим, что тут у вас..");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Смотрим..");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Смотрим..");
            System.Threading.Thread.Sleep(1000);

            foreach (var spare in _spares)
            {
                if (spare.Part == client.brokenDetail)
                {
                    Console.WriteLine($"У вас сломан следующий узел: {spare.Name}");
                    FixCar(spare, client);
                }
            }

            Console.Clear();
        }

        private void FixCar(SpareParts spare, Client client)
        {
            if (spare.CountDetails > 0)
            {
                const string CommandFixCar = "1";
                const string CommandExit = "0";
                int totalPrice = spare.PriceDetail + _priceWork;
                Console.WriteLine($"\nОтлично, комплектующие есть в наличии, цена услуги составит: {totalPrice} руб.");

                Console.Write($"Нажмите {CommandFixCar}, чтобы расплатиться и починить машину\nНажмите {CommandExit}, чтобы выйти\n\nВаш ввод: ");
                string playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case CommandFixCar:
                        ReplaceDetail(spare, totalPrice, client);
                        break;
                    case CommandExit:
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

        private void ReplaceDetail(SpareParts spare, int totalPrice, Client client)
        {
            if (client.isPayOff(totalPrice))
            {
                _balance += totalPrice;
                spare.RemoveDetail();

                if (spare.CountDetails == 0)
                {
                    _spares.Remove(spare);
                }

                Console.WriteLine("Машина починина, езжайте с Богом..");
            }
            else
            {
                Console.WriteLine("Клиент оказался не способен оплатить заказ, гоните его в щи");
            }
        }

        private void FillZip()
        {
            _spares.Add(new SpareParts(Part.GRM, "Ремень ГРМ", 5, new GRM()));
            _spares.Add(new SpareParts(Part.Wheel, "Колесо", 11, new Wheel()));
            _spares.Add(new SpareParts(Part.SparkPlug, "Свечи зажигания", 30, new SparkPlug()));
            _spares.Add(new SpareParts(Part.WindShield, "Лобовое стекло", 9, new WindShield()));
        }

        public void ShowSpareParts()
        {
            Console.Clear();
            Console.WriteLine("У нас на складе есть следующие комплектующие для автомобиля:\n");

            foreach (var spare in _spares)
            {
                spare.ShowInfo();
            }

            Console.WriteLine("\nНажмите любую клавишу длявыхода в меню..");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Client
    {
        public Part brokenDetail { get; private set; }
        private int _money;
        private Random _random = new Random();

        public Client()
        {
            int minMoney = 1000;
            int maxMoney = 20001;
            _money = _random.Next(minMoney, maxMoney);
            brokenDetail = GetBrokenDetail();
        }

        public bool isPayOff(int repairPrice)
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
            return brokenDetail = (Part)_random.Next(0, spareParts.Length + 1);
        }
    }

    class SpareParts
    {
        public string Name { get; private set; }
        public int CountDetails { get; private set; }
        public int PriceDetail { get; private set; }
        public Part Part { get; private set; }
        private List<Detail> _details = new List<Detail>();

        public SpareParts(Part part, string name, int countDetails, Detail detail)
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
            Console.WriteLine($"{Name} - {PriceDetail} руб, в наличии {CountDetails} штук");
        }

        public int RemoveDetail()
        {
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
