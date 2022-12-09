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
            const string CommandAddFish = "1";
            const string CommandRemoveFish = "2";
            const string CommandExit = "q";
            bool isExit = false;
            int maxCountFish = 15;
            int oldSpeed = 1;
            Aquarium aquarium = new Aquarium(maxCountFish);

            while (isExit == false)
            {
                aquarium.ShowStats(oldSpeed);
                Console.WriteLine($"\nВы можете:\nДобавить рыбку в аквариум - НАЖАВ {CommandAddFish}\nДостать рыбку - НАЖАВ {CommandRemoveFish}\nВыйти - НАЖАВ {CommandExit}");
                Console.Write("ваш выбор: ");
                string playerChoose = Console.ReadLine();

                switch (playerChoose)
                {
                    case CommandAddFish:
                        aquarium.AddFish();
                        break;
                    case CommandRemoveFish:
                        aquarium.RemoveFish();
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                }

                aquarium.GetOldFishes(oldSpeed);
                aquarium.RemoveDeadFishes();
                Console.Clear();
            }
        }
    }

    class Aquarium
    {
        private Random _random = new Random();
        private List<Fish> _fishes = new List<Fish>();
        private int _maxCountFish;
        public Aquarium(int maxCountFish)
        {
            _maxCountFish = maxCountFish;
            CreateFishs();
        }

        public void RemoveDeadFishes()
        {
            for (int i = 0; i < _fishes.Count; i++)
            {
                if (_fishes[i].Life < 0)
                {
                    _fishes.RemoveAt(i);
                    i--;
                }
            }
        }

        public void RemoveFish()
        {
            if (_fishes.Count > 0)
            {
                Console.Write("Введите номер той рыбки, которую хотите достать: ");
                string playerChoose = Console.ReadLine();
                int.TryParse(playerChoose, out int fishNumber);

                if (fishNumber > 0 && fishNumber < _fishes.Count)
                {
                    _fishes.RemoveAt(fishNumber - 1);
                }
                else
                {
                    Console.WriteLine("Рыбы с таким номер нет");
                }
            }
        }

        public void AddFish()
        {
            if (_fishes.Count < _maxCountFish)
            {
                _fishes.Add(CreateFish());
            }
            else
            {
                Console.WriteLine("В аквариум больше нельзя добавить рыб, достаньте несколько или дождитесь пока кто умрет :(");
            }
        }

        public void ShowStats(int oldSpeed)
        {
            Console.WriteLine("Это аквариум, в нем сейчас живет - " + _fishes.Count + " рыб\nВ него помещается максимум " + _maxCountFish + " рыб\nПосле " +
                "каждого действия рыбка стареет на " + oldSpeed + " жизнь");
            int numberFish = 1;

            foreach (var fish in _fishes)
            {
                Console.Write("Рыба № " + numberFish + " - ");
                fish.ShowLife();
                Console.WriteLine();
                numberFish++;
            }
        }

        public void GetOldFishes(int oldSpeed)
        {
            foreach (var fish in _fishes)
            {
                fish.GetOld(oldSpeed);
            }
        }

        private void CreateFishs()
        {
            int minCountFish = 1;
            int maxCountFish = _maxCountFish + 1;
            int countFishs = _random.Next(minCountFish, maxCountFish);

            for (int i = 0; i < countFishs; i++)
            {
                _fishes.Add(CreateFish());
            }
        }

        private Fish CreateFish()
        {
            int minFishLife = 3;
            int maxFishLife = 11;
            int fishLife = _random.Next(minFishLife, maxFishLife);
            return new Fish(fishLife);
        }
    }

    class Fish
    {
        public int Life { get; private set; }

        public Fish(int life)
        {
            Life = life;
        }

        public void GetOld(int oldSpeed)
        {
            Life -= oldSpeed;
        }

        public void ShowLife()
        {
            Console.Write("осталось жизней - " + Life);

            if (Life == 1)
            {
                Console.Write(" !Рыбка умрет на следующем ходу!");
            }
            else if (Life == 0)
            {
                Console.Write(" Рыбка умерла :(");
            }
        }
    }
}
