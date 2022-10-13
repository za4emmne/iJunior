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
            Dispatcher dispatcher = new Dispatcher();
        }
    }

    class Dispatcher
    {
        private List<Train> _trains = new List<Train>();

        public Dispatcher()
        {
            bool isExit = false;

            while (isExit == false)
            {
                const string CommandExit = "q";
                int countCarriage = 0;
                int allCountPassengers = 0;
                string startStation = "пусто";
                string finishStation = "пусто";
                Console.WriteLine("Добро пожаловать в менеджер ЖД путей\n");
                int countPassengers = 0;
                Train train = new Train(countCarriage, countPassengers, allCountPassengers, startStation, finishStation);
                countPassengers = train.CountPassenger();
                ShowInfoTrains();
                train.CreateWay();
               
                while (train.CurrentCountPassengers > 0)
                {
                    ShowInfoTrains();
                    train.ShowInfo();
                    Create(train);
                }

                ShowInfoTrains();
                train.ShowInfo();
                Console.WriteLine("Поезд готов к отправке, нажмите любую клавишу, чтобы составить новый маршрут или " + CommandExit + ", чтобы выйти..");
                _trains.Add(train);

                if (Console.ReadLine() == CommandExit)
                {
                    isExit = true;
                }

                Console.Clear();
            }
        }

        public void ShowInfoTrains()
        {
            Console.WriteLine("История рейсов:");

            foreach (var train in _trains)
            {
                Console.WriteLine($"Станция отправления: [{train.StartStation}] Станция прибытия: [{train.FinishStation}], количество пассажиров в поезде: [{train.AllCountPassengers}]");
            }

            Console.WriteLine();
        }

        public void Create(Train train)
        {
            const string CommandSeatCarriage = "1";
            const string CommandCoupCarriage = "2";
            const string CommandSvCarriage = "3";
            const string SeatCarriageName = "плацкарт";
            const string CoupCarriageName = "купе";
            const string SvCarriageName = "СВ";
            const int CountSeatPassengers = 54;
            const int CountCoupPassengers = 36;
            const int CountSvPassengers = 18;
            Carriage SeatCarriage = new Carriage(CountSeatPassengers, SeatCarriageName);
            Carriage CoupCarriage = new Carriage(CountCoupPassengers, CoupCarriageName);
            Carriage SvCarriage = new Carriage(CountSvPassengers, SvCarriageName);
            Console.WriteLine("Выберите вагоны которые хотите добавить в состав поезда: ");
            Console.Write($"плацкарт({CountSeatPassengers} пассажира)  - нажмите 1\nкупе({CountCoupPassengers} пассажиров)     - нажмите 2\nСВ({CountSvPassengers} " +
                $"пассажиров)       - нажмите 3\nВаш выбор: ");
            string inputCarriage = Console.ReadLine();

            switch (inputCarriage)
            {
                case CommandSeatCarriage:
                    train.AddCarriage(SeatCarriage);
                    break;
                case CommandCoupCarriage:
                    train.AddCarriage(CoupCarriage);
                    break;
                case CommandSvCarriage:
                    train.AddCarriage(SvCarriage);
                    break;
                default:
                    Console.WriteLine("Такой команды нет");
                    break;
            }

            Console.Clear();
        }
    }

    class Train
    {
        protected int CountCarriage;
        private List<Carriage> _carriages = new List<Carriage>();
        public int CurrentCountPassengers { get; private set; }
        public int AllCountPassengers { get; private set; }
        public string StartStation { get; private set; }
        public string FinishStation { get; private set; }

        public Train(int countCarriage, int currentCountPassengers, int allCountPassengers, string startStation = "пусто", string finishStation = "пусто")
        {
            CurrentCountPassengers = currentCountPassengers;
            StartStation = startStation;
            FinishStation = finishStation;
            CountCarriage = countCarriage;
            AllCountPassengers = allCountPassengers;
        }

        public void CreateWay()
        {
            Console.Write("Чтобы создать маршрут поезда введите станцию отправления: ");
            StartStation = Console.ReadLine();
            Console.Write("Теперь введите стандию прибытия: ");
            FinishStation = Console.ReadLine();
            Console.Clear();
        }
        public int CountPassenger()
        {
            int minCountPassengers = 1;
            int maxCountPassengers = 400;
            Random random = new Random();
            CurrentCountPassengers = random.Next(minCountPassengers, maxCountPassengers);
            AllCountPassengers = CurrentCountPassengers;
            return CurrentCountPassengers;
        }

        public void AddCarriage(Carriage carriage)
        {
            _carriages.Add(carriage);
            CurrentCountPassengers -= carriage.Passengers;
            _carriages.Add(carriage);
            CountCarriage++;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Текущий маршрут: ");
            Console.WriteLine($"Станция отправления: [{StartStation}] Станция прибытия: [{FinishStation}]\n");
            Console.WriteLine($"В состав поезда входит: {CountCarriage} вагонов");

            if (CurrentCountPassengers > 0)
            {
                Console.WriteLine("\nВ поезд необходимо разместить: " + CurrentCountPassengers + " пассажиров.\n");
            }
            else
            {
                Console.WriteLine("Все пассажиры размещены.");
            }

            Console.WriteLine("====================================================================================\n");
        }
    }

    class Carriage
    {
        private string Type;
        public int Passengers { get; private set; }      

        public Carriage(int passengers, string type)
        {
            Passengers = passengers;
            Type = type;
        }
    }
}
