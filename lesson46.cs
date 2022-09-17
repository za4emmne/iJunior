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
            Train train = new Train();
            WorkProgram workProgram = new WorkProgram(train);
        }
    }

    class WorkProgram
    {

        public WorkProgram(Train train)
        {
            bool isExit = false;

            while (isExit == false)
            {
                int countPassengers = 0;
                int countSeatCarriage = 0;
                int countCoupCarriage = 0;
                int countSvCarriage = 0;
                string startStation = "пусто";
                string finishStation = "пусто";
                Console.WriteLine("Добро пожаловать в менеджер ЖД путей\n");
                train.ShowInfo(countPassengers, startStation, finishStation, countSeatCarriage, countCoupCarriage, countSvCarriage);
                CreateWay(out startStation, out finishStation);
                SellTicket(out countPassengers);

                while (countPassengers > 0)
                {
                    train.ShowInfo(countPassengers, startStation, finishStation, countSeatCarriage, countCoupCarriage, countSvCarriage);
                    Create(train, ref countPassengers, ref countSeatCarriage, ref countCoupCarriage, ref countSvCarriage);
                }

                train.ShowInfo(countPassengers, startStation, finishStation, countSeatCarriage, countCoupCarriage, countSvCarriage);
                Console.WriteLine("Поезд готов к отправке, нажмите любую клавишу, чтобы составить новый маршрут или q, чтобы выйти..");

                if (Console.ReadLine() == "q")
                {
                    isExit = true;
                }

                Console.Clear();
            }
        }

        public void CreateWay(out string startStation, out string finishStation)
        {
            Console.Write("Чтобы создать маршрут поезда введите станцию отправления: ");
            startStation = Console.ReadLine();
            Console.Write("Теперь введите стандию прибытия: ");
            finishStation = Console.ReadLine();
            Console.Clear();
        }

        public void SellTicket(out int countPassengers)
        {
            int minCoutPassengers = 1;
            int maxCountPassengers = 400;
            Random random = new Random();
            countPassengers = random.Next(minCoutPassengers, maxCountPassengers);
        }

        public void Create(Train train, ref int countPassengers, ref int countSeatCarriage, ref int countCoupCarriage, ref int countSvCarriage)
        {
            const string commandSeatCarriage = "1";
            const string commandCoupCarriage = "2";
            const string commandSvCarriage = "3";
            const string seatCarriage = "плацкарт";
            const string coupCarriage = "купе";
            const string svCarriage = "СВ";
            const int countSeatPassengers = 54;
            const int countCoupPassengers = 36;
            const int countSvPassengers = 18;
            Console.WriteLine("Выберите вагоны которые хотите добавить в состав поезда: ");
            Console.Write("плацкарт(54 пассажира)  - нажмите 1\nкупе(36 пассажиров)     - нажмите 2\nСВ(18 пассажиров)       - нажмите 3\nВаш выбор: ");
            string inputCarriage = Console.ReadLine();

            switch (inputCarriage)
            {
                case commandSeatCarriage:
                    train.AddCarriage(seatCarriage, ref countPassengers, countSeatPassengers, ref countSeatCarriage);
                    break;
                case commandCoupCarriage:
                    train.AddCarriage(coupCarriage, ref countPassengers, countCoupPassengers, ref countCoupCarriage);
                    break;
                case commandSvCarriage:
                    train.AddCarriage(svCarriage, ref countPassengers, countSvPassengers, ref countSvCarriage);
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
        private List<Carriage> _carriages = new List<Carriage>();

        public Train()
        {
        }

        public void AddCarriage(string typeCarriage, ref int countTrainPassengers, int countCarriagePassengers, ref int countCarriage)
        {
            _carriages.Add(new Carriage(countCarriagePassengers, typeCarriage));
            countTrainPassengers -= countCarriagePassengers;
            countCarriage++;
        }

        public void ShowInfo(int countPassengers, string startStation, string finishStation, int countSeatCarriage, int countCoupCarriage,
            int countSvCarriage)
        {
            Console.WriteLine("Текущий маршрут: ");
            Console.WriteLine($"Станция отправления: [{startStation}] Станция прибытия: [{finishStation}]\n");
            Console.WriteLine("В состав поезда входит: ");
            Console.WriteLine("Вагоны плацкарт: " + countSeatCarriage);
            Console.WriteLine("Вагоны купе: " + countCoupCarriage);
            Console.WriteLine("Вагоны СВ: " + countSvCarriage);

            if (countPassengers > 0)
            {
                Console.WriteLine("\nВ поезд необходимо разместить: " + countPassengers + " пассажиров.\n");
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
        protected int Passengers;
        protected string Type;

        public Carriage(int passengers, string type)
        {
            Passengers = passengers;
            Type = type;
        }
    }
}
