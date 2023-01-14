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
            Console.WriteLine("Здрасти, здесь можно перевести из синего взвода в красный тех солдат, чьи фамилии начинаются на букву Б\n");
            Console.WriteLine("Солдаты синего взвода:");
            ShowInfoAboutAllSolsiers(_soldiersBlueCrew);
            Console.WriteLine();
            Console.WriteLine("Солдаты красного взвода:");
            ShowInfoAboutAllSolsiers(_soldiersRedCrew);
            Console.WriteLine("\nНажмите любую кнопку, чтобы перевести солдат..");
            Console.ReadKey();
            var soldiersSurnameB = _soldiersBlueCrew.Where(soldier => soldier.Surname.StartsWith('Б'));
            var unitedSoldiers = _soldiersRedCrew.Union(soldiersSurnameB);
            _soldiersRedCrew = unitedSoldiers.ToList();
            Console.Clear();
            ShowInfoAboutAllSolsiers(_soldiersRedCrew);
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
            foreach (var soldier in soldiers)
            {
                soldier.ShowInfo();
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
