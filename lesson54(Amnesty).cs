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
            AmnestyProgram amnestyProgram = new AmnestyProgram();
            amnestyProgram.Start();
        }
    }

    class AmnestyProgram
    {
        private List<Prisoner> _prisoners = new List<Prisoner>();

        public AmnestyProgram()
        {
            FillDataBase();
        }

        public void Start()
        {
            Console.WriteLine("Добрый день, сегодня вы сможете наблюдать величайшее событие в нашей стране\n" +
                    "Сегодня пройдет амнистия заключенных, осужденных за Антиправительственные преступления");
            Console.WriteLine($"Список всех заключенных:");
            ShowAllPrisoners();
            Console.WriteLine($"\nНАЖМИТЕ ЛЮУБУЮ КЛАВИШУ, ЧТОБЫ ПОРВЕСТИ АМНИСТИЮ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Амнистирование..");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Пощада..");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Делаем добрые дела..");
            System.Threading.Thread.Sleep(1000);
            DoAmnesty();
            }
       
        private void DoAmnesty()
        {
            const string PoliticCrime = "Антиправительственное";

            int number = 1;
            var notAmnestedPrisoners = _prisoners.Where(prisoner => prisoner.Crime != PoliticCrime);
            Console.Clear();
            Console.WriteLine($"Список преступников после амнистии:");

            foreach (var prisoner in notAmnestedPrisoners)
            {
                Console.Write(number + ". ");
                prisoner.ShowInfo();
                number++;
            }

            Console.ReadKey();
            Console.Clear();
        }

        private void FillDataBase()
        {
            _prisoners.Add(new Prisoner("Латыев Абубакир Гусманович", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Биспаев Культяк Турсунович", "Убийство"));
            _prisoners.Add(new Prisoner("Дирмеев Сазрым Хаметлюстеевич", "Дезертирство"));
            _prisoners.Add(new Prisoner("Кепин Расул Жорасавич", "Антиправительственное"));
            _prisoners.Add(new Prisoner("Бируев Кикбас Нусеевич", "Воровство"));
        }

        private void ShowAllPrisoners()
        {
            int number = 1;

            foreach (var prisoner in _prisoners)
            {
                Console.Write(number + ". ");
                prisoner.ShowInfo();
                number++;
            }
        }
    }

    class Prisoner
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public Prisoner(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {Name}, преступление - {Crime} ");
        }
    }
}
