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
            const string CommandChooseAviary = "1";
            const string CommandExit = "0";
            bool isExit = false;
            Zoo zoo = new Zoo();

            while (isExit == false)
            {

                Console.WriteLine($"Добро пожаловать в зоопарк\nЗдесь вы увидите: ");
                zoo.ShowAviares();
                Console.Write("\nНажмите 1, чтобы выбрать вольер\nНажмите 0, чтобы выйти из программы\n\nВведите команду: ");
                string playerChoose = Console.ReadLine();

                switch (playerChoose)
                {
                    case CommandChooseAviary:
                        zoo.ChooseAviary();
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует...");
                        break;
                }

                Console.WriteLine("Выберите вольер к которому ходите подойти и введи его номер: ");
            }
        }
    }

    class Zoo
    {
        private List<IAviary> _aviaries;
        private Random _random = new Random();

        public Zoo()
        {
            _aviaries = new List<IAviary>();
            CreateAviares();
        }

        public void ShowAviares()
        {
            int numberAviary = 1;

            foreach (var aviary in _aviaries)
            {
                Console.Write(numberAviary + ". ");
                aviary.ShowInfo();
                numberAviary++;
            }
        }

        public void ChooseAviary()
        {
            Console.Write("Введите номмер вольера: ");
            string playerChoose = Console.ReadLine();
            Console.Clear();

            if(int.TryParse(playerChoose, out int numberAviary) && numberAviary>0 && numberAviary<=_aviaries.Count)
            {
                _aviaries[numberAviary].ShowInfo();
                Console.WriteLine();
                _aviaries[numberAviary].ShowAnimalInAviary();
            }
            else
            {
                Console.WriteLine("Такого вольера не существует..");
            }

            Console.Write("Чтобы выйти в меню, нажмите любую клавишу..");
            Console.ReadKey();
            Console.Clear();
        }

        private int RandomAnimalCount()
        {
            int minCountAnimals = 2;
            int maxCountAnimals = 10;
            int countAnimals = _random.Next(minCountAnimals, maxCountAnimals);
            return countAnimals;
        }

        private void CreateAviares()
        {
            _aviaries.Add(new Aviary<Horse>(animalCount: RandomAnimalCount(), name: "Вольер с лошадьми"));
            _aviaries.Add(new Aviary<Monkey>(animalCount: RandomAnimalCount(), name: "Вольер с медведями"));
            _aviaries.Add(new Aviary<Monkey>(animalCount: RandomAnimalCount(), name: "Вольер с медведями"));
            _aviaries.Add(new Aviary<Monkey>(animalCount: RandomAnimalCount(), name: "Вольер с медведями"));
        }
    }

    class Aviary<AnimalKind> : IAviary where AnimalKind : Animal, new()
    {
        private List<AnimalKind> _animals;
        private string Name;

        public Aviary(string name, int animalCount)
        {
            Name = name;
            _animals = new List<AnimalKind>();
            AddAnimal(animalCount);
        }

        public void AddAnimal(int animalCount)
        {
            for (int i = 0; i < animalCount; i++)
            {
                _animals.Add(new AnimalKind());
            }
        }

        public void ShowAnimalInAviary()
        {
            foreach (var animal in _animals)
            {
                animal.ShowInfo();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, его численность составляет {_animals.Count} животных");
        }
    }

    abstract class Animal
    {
        protected string name;
        protected const string MaleGender = "Самец";
        protected const string FemaleGender = "Самка";
        protected Gender gender;
        private Random _random = new Random();

        public Animal()
        {
            MakeGender();
        }

        public enum Gender
        {
            Male,
            Female
        }

        public abstract void ShowVoice();

        public virtual void ShowInfo()
        {
            Console.Write($"Это {name}, пол: {GetGender()}, издает звук - ");
            ShowVoice();
        }

        protected string GetGender()
        {
            switch (gender)
            {
                case Gender.Male:
                    return MaleGender;

                case Gender.Female:
                    return FemaleGender;

                default:
                    return string.Empty;
            }
        }

        private void MakeGender()
        {
            gender = (Gender)_random.Next((int)Gender.Male, (int)Gender.Female + 1);
        }
    }

    class Horse : Animal
    {
        public Horse()
        {
            name = "Лошадь";
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        public override void ShowVoice()
        {
            Console.WriteLine("Иго-го");
        }
    }

    class Bear : Animal
    {
        public Bear()
        {
            name = "Медведь";
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        public override void ShowVoice()
        {
            Console.WriteLine("ААААААААааааАААррррррррр");
        }
    }

    class Monkey : Animal
    {
        public Monkey()
        {
            name = "Обезьяна";
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        public override void ShowVoice()
        {
            Console.WriteLine("УаааУааааа-а-а");
        }
    }

    class Pig : Animal
    {
        public Pig()
        {
            name = "Свинья";
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
        }

        public override void ShowVoice()
        {
            Console.WriteLine("Хрю-Хрю");
        }
    }

    public interface IAviary
    {
        public void ShowAnimalInAviary();
        public void ShowInfo();
    }
}
