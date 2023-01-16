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
            RatingProgram detectiveProgram = new RatingProgram();
            detectiveProgram.Start();
        }
    }

    class RatingProgram
    {
        private List<Player> _players = new List<Player>();
        private int _numberTop = 3;

        public RatingProgram()
        {
            FillDataBase();
        }

        public void Start()
        {
            const string CommandSortTopLevel = "1";
            const string CommandSortTopDamage = "2";
            const string CommandShowAllPlayers = "3";
            const string CommandExit = "0";

            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("Добро пожаловать в программу рейтинга ГеншинИмпакт\nЗдесь можно вывести топ игроков по разным параметрам\n");
                Console.Write($"НАЖМИТЕ {CommandSortTopLevel} - Вывести ТОП-3 по уровню\nНАЖМИТЕ {CommandSortTopDamage} - " +
                    $"Вывести ТОП-3 по силе\nНАЖМИТЕ {CommandShowAllPlayers} - Показать всех игроков\nНАЖМИТЕ {CommandExit} - Выйти\n\nВаш ввод: ");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case CommandSortTopLevel:
                        SortPlayerLevel();
                        break;
                    case CommandSortTopDamage:
                        SortPlayerDamage();
                        break;
                    case CommandShowAllPlayers:
                        ShowInfoAboutAllPlayers(_players);
                        break;
                    case CommandExit:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
        }

        private void SortPlayerDamage()
        {
            var topPlayersLevel = _players.OrderByDescending(player => player.Damage).Take(_numberTop);
            Console.WriteLine("Рейтинг ТОП-3 по силе:");
            ShowInfoAboutAllPlayers(topPlayersLevel.ToList());
        }

        private void SortPlayerLevel()
        {
            int numberTop = 3;
            var topPlayersLevel = _players.OrderByDescending(player => player.Level).Take(numberTop);
            Console.WriteLine("Рейтинг ТОП-3 по уровню:");
            ShowInfoAboutAllPlayers(topPlayersLevel.ToList());
        }

        private void FillDataBase()
        {
            _players.Add(new Player("Борис", 21, 9));
            _players.Add(new Player("Никита", 15, 60));
            _players.Add(new Player("Тиль", 2, 102));
            _players.Add(new Player("Олег", 43, 89));
            _players.Add(new Player("Куртамбек", 12, 83));
            _players.Add(new Player("Альтаир", 65, 83));
            _players.Add(new Player("Дракон", 11, 9));
            _players.Add(new Player("Влад", 5, 60));
            _players.Add(new Player("Тигр", 8, 102));
            _players.Add(new Player("Джигин", 32, 89));
            _players.Add(new Player("Нагибатор", 41, 83));
            _players.Add(new Player("Распремлятор", 22, 83));
        }

        private void ShowInfoAboutAllPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                player.ShowInfo();
            }

            Console.WriteLine("Нажмите любую кнопку чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Damage { get; private set; }

        public Player(string name, int level, int damage)
        {
            Name = name;
            Level = level;
            Damage = damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя - {Name}  Уровень - {Level}  Сила - {Damage}");
        }
    }
}
