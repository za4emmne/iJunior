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
            UnitedProgram unitedProgram = new UnitedProgram();
            unitedProgram.Start();
        }
    }

    class UnitedProgram
    {
        private List<Soldier> _soldiersBlueCrew = new List<Soldier>();
        private List<Soldier> _soldiersRedCrew = new List<Soldier>();

        public UnitedProgram()
        {
            FillBlueCrew();
            FillRedCrew();
        }

        public void Start()
        {
            char nameStartWithChar = 'Б';
            Console.WriteLine("Здрасти, здесь можно перевести из синего взвода в красный тех солдат, чьи фамилии начинаются на букву " + nameStartWithChar + "\n");
            Console.WriteLine("Солдаты синего взвода:");
            ShowInfoAboutAllSolsiers(_soldiersBlueCrew);
            Console.WriteLine();
            Console.WriteLine("Солдаты красного взвода:");
            ShowInfoAboutAllSolsiers(_soldiersRedCrew);

            MoveSoldiers(nameStartWithChar);

            Console.WriteLine("Солдаты красного взвода после перевода: ");
            ShowInfoAboutAllSolsiers(_soldiersRedCrew);
            Console.WriteLine();
            Console.WriteLine("Солдаты синего взвода после перевода: ");
            ShowInfoAboutAllSolsiers(_soldiersBlueCrew);
        }

        private void MoveSoldiers(char inputChar)
        {
            Console.WriteLine("\nНажмите любую кнопку, чтобы перевести солдат..");
            Console.ReadKey();
            var soldiersSurnameStartWithChar = _soldiersBlueCrew.Where(soldier => soldier.Surname.StartsWith(inputChar));
            _soldiersBlueCrew = _soldiersBlueCrew.Except(soldiersSurnameStartWithChar).ToList();
            _soldiersRedCrew = _soldiersRedCrew.Concat(soldiersSurnameStartWithChar.ToList()).ToList();
            Console.Clear();
        }

        private void FillBlueCrew()
        {
            _soldiersBlueCrew.Add(new Soldier("Киреев"));
            _soldiersBlueCrew.Add(new Soldier("Иванаев"));
            _soldiersBlueCrew.Add(new Soldier("Абрамцов"));
            _soldiersBlueCrew.Add(new Soldier("Бабий"));
            _soldiersBlueCrew.Add(new Soldier("Баглай"));
            _soldiersBlueCrew.Add(new Soldier("Вагнеров"));
            _soldiersBlueCrew.Add(new Soldier("Биткоинов"));
            _soldiersBlueCrew.Add(new Soldier("Нфтишкин"));
        }

        private void FillRedCrew()
        {
            _soldiersRedCrew.Add(new Soldier("Иванов"));
            _soldiersRedCrew.Add(new Soldier("Петров"));
            _soldiersRedCrew.Add(new Soldier("Сидоров"));
            _soldiersRedCrew.Add(new Soldier("Борисов"));
            _soldiersRedCrew.Add(new Soldier("Олигархов"));
            _soldiersRedCrew.Add(new Soldier("Предователеев"));
            _soldiersRedCrew.Add(new Soldier("Хитрюгин"));
            _soldiersRedCrew.Add(new Soldier("Бомберов"));
        }

        private void ShowInfoAboutAllSolsiers(List<Soldier> soldiers)
        {
            int number = 1;

            foreach (var soldier in soldiers)
            {
                Console.Write(number + ". ");
                soldier.ShowInfo();
                number++;
            }
        }
    }

    class Soldier
    {
        public string Surname { get; private set; }

        public Soldier(string name)
        {
            Surname = name;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Фамилия - {Surname}");
        }
    }
}
