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
        private int _balance;
        private List<SpareParts> _spares = new List<SpareParts>();
        private int _priceWork = 3000;

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
                Console.WriteLine("НАЖМИТЕ 1 - Цена и наличие комплектующих\nНАЖМИТЕ 2 - Провести диагностику и починить машину\nНАЖМИТЕ 0 - ВЫЙТИ");
                Console.Write("Ввод: ");
                string playerInput = Console.ReadLine();

                switch (playerInput)
                {
                    case CommandShowPrices:
                        ShowSpareParts();
                        break;
                    case CommandFixCar:
                        FixCar(client);
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                }
            }
        }

        private void FixCar(Client client)
        {
            Console.Clear();
            //Console.WriteLine("Посмотрим, что тут у вас..");
            //System.Threading.Thread.Sleep(1000);
            //Console.WriteLine("Смотрим..");
            //System.Threading.Thread.Sleep(1000);
            //Console.WriteLine("Смотрим..");
            //System.Threading.Thread.Sleep(1000);

            foreach (var spare in _spares)
            {
                Console.WriteLine(spare.Part);

                if (spare.Part == client.brokenDetail)
                {
                    Console.WriteLine($"У вас сломан {spare.name}");
                    ReplacePart(spare);
                }
            }

            Console.ReadKey();
        }

        private void ReplacePart(SpareParts spare)
        {
            if (spare.countDetails > 0)
            {
                int totalPrice = spare.priceDetail + _priceWork;
                Console.WriteLine($"Отлично, комплектующие есть в наличии, цена услуги составит: {totalPrice} руб.");
                spare.RemoveDetail();
            }
            else
            {
                Console.WriteLine("не понял");
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

        private Part GetBrokenDetail()
        {
            Part[] spareParts = (Part[])Enum.GetValues(typeof(Part));
            return brokenDetail = (Part)_random.Next(0, spareParts.Length + 1);
        }
    }

    class SpareParts
    {
        public string name { get; private set; }
        public int countDetails { get; private set; }
        public int priceDetail { get; private set; }
        public Part Part { get; private set; }
        private List<Detail> _details = new List<Detail>();

        public SpareParts(Part Part, string name, int countDetails, Detail detail)
        {
            this.name = name;
            this.countDetails = countDetails;
            priceDetail = detail.GetPrice();

            for (int i = 0; i < countDetails; i++)
            {
                FillParts(detail);
            }
        }

        private void FillParts(Detail detail)
        {
            _details.Add(detail);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{name} - {priceDetail} руб, в наличии {countDetails} штук");
        }

        public int RemoveDetail()
        {
            return countDetails--;
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
