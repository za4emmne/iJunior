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
            bool isExit = false;
            int maxCountFish = 15;
            int oldSpeed = 1;
            const string commandAddFish = "1";
            const string commandRemoveFish = "2";
            const string commandExit = "q";
            Aquarium aquarium = new Aquarium(maxCountFish);

            while (isExit == false)
            {
                aquarium.ShowStats(oldSpeed);
                Console.WriteLine($"\nВы можете:\nДобавить рыбку в аквариум - НАЖАВ {commandAddFish}\nДостать рыбку - НАЖАВ {commandRemoveFish}\nВыйти - НАЖАВ {commandExit}");
                Console.Write("ваш выбор: ");
                string playerChoose = Console.ReadLine();

                switch (playerChoose)
                {
                    case commandAddFish:
                        aquarium.AddFish();
                        break;
                    case commandRemoveFish:
                        aquarium.RemoveFish();
                        break;
                    case commandExit:
                        isExit = true;
                        break;
                    default:
                        break;
                }

                aquarium.GetFishsOld(oldSpeed);
                aquarium.FishDead();
                Console.Clear();
            }
        }
    }

    class Aquarium
    {
        private Random _random = new Random();
        private List<Fish> _fishs = new List<Fish>();
        private int MaxCountFish;
        public Aquarium(int maxCountFish)
        {
            MaxCountFish = maxCountFish;
            CreateFishs();
        }

        public void FishDead()
        {
            for (int i = 0; i<_fishs.Count; i++)
            {
                if (_fishs.ElementAt(i).Life < 0)
                {
                    _fishs.RemoveAt(i);
                }
            }
        }

        public void RemoveFish()
        {
            if (_fishs.Count > 0)
            {
                Console.Write("Введите номер той рыбки, которую хотите достать: ");
                string playerChoose = Console.ReadLine();
                int.TryParse(playerChoose, out int fishNumber);
                _fishs.RemoveAt(fishNumber - 1);
            }
        }

        public void AddFish()
        {
            if (_fishs.Count < MaxCountFish)
            {
                _fishs.Add(CreateFish());
            }
            else
            {
                Console.WriteLine("В аквариум больше нельзя добавить рыб, достаньте несколько или дождитесь пока кто умрет :(");
            }
        }

        public void ShowStats(int oldSpeed)
        {
            Console.WriteLine("Это аквариум, в нем сейчас живет - " + _fishs.Count + " рыб\nВ него помещается максимум " + MaxCountFish + " рыб\nПосле " +
                "каждого действия рыбка стареет на " + oldSpeed + " жизнь");

            foreach (var fish in _fishs)
            {
                int numberFish = _fishs.IndexOf(fish) + 1;
                Console.Write("Рыба № " + numberFish + " - ");
                fish.ShowLife();
                Console.WriteLine();
            }
        }

        public void GetFishsOld(int oldSpeed)
        {
            foreach (var fish in _fishs)
            {
                fish.GetOld(oldSpeed);
            }
        }

        private void CreateFishs()
        {
            int minCountFish = 1;
            int maxCountFish = MaxCountFish + 1;
            int countFishs = _random.Next(minCountFish, maxCountFish);

            for (int i = 0; i < countFishs; i++)
            {
                _fishs.Add(CreateFish());
            }
        }

        private Fish CreateFish()
        {
            int minFishLife = 3;
            int maxFishLife = 11;
            int fishLife = _random.Next(minFishLife, maxFishLife);
            Fish fish = new Fish(fishLife);
            return fish;
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
            else if(Life == 0)
            {
                Console.Write(" Рыбка умерла :(");
            }
        }
    }
}
