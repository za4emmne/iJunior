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
            WorkProgram workProgram = new WorkProgram();
            workProgram.SellTicket(out int countPassengers);
        }
    }

    class WorkProgram
    {
        public void CreateWay()
        {
            Console.Write("Чтобы создать маршрут поезда введите станцию отправления: ");
            string startStation = Console.ReadLine();
            Console.Write("Теперь введите стандию прибытия: ");
            string finishStation = Console.ReadLine();
            Console.WriteLine("Маршрут от станции: " + startStation + " до станции " + finishStation + " сформирван.");
        }

        public void SellTicket(out int countPassengers)
        {
            int minCoutPassengers = 1;
            int maxCountPassengers = 1000;
            Random random = new Random();
            countPassengers = random.Next(minCoutPassengers, maxCountPassengers);
            Console.WriteLine("На данное направление купили " + countPassengers + " билетов.");
        }

        public void Create()
        {
            const string seatCarriage = "плацкарт";
            const string coupCarriage = "купе";
            const string svCarriage = "СВ";
            Console.Write("Выберите вагоны которые хотите добавить в состав поезда: ");
            string inputCarriage = Console.ReadLine();

            switch (inputCarriage)
            {
                case seatCarriage:
                    break;
            }
        }
    }

    class Train
    {
        private List<Carriage> _carriages = new List<Carriage>();
        
        public Train()
        {
            
        }
      
        public void AddCarriage(string carriage)
        {

        }

        public void ShowInfo()
        {
            Console.WriteLine("В состав поезда входит: " );
        }
    }

    class Carriage
    {
        protected int Passengers { get; private set; }

        public Carriage(int passengers)
        {
            Passengers = passengers;
        }
    }

    class SeatCarriage: Carriage
    {
        public SeatCarriage(out int countPassengers) : base(54)
        {
            countPassengers = 54;
        }
    }
}
