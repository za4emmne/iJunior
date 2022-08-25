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
            Database database = new Database();
            database.ShowMenu();
        }
    }

    class Database
    {
        private Player _player;
        private List<Player> Players = new List<Player>();

        public Database()
        {
            Players.Add(new Player("Nick", 1, "junior", true));
            Players.Add(new Player("Keck", 2, "middle", false));
        }

        public void ShowMenu()
        {
            const string CommandExit = "exit";
            const string ShowAllPlayers = "show";
            const string AddPlayers = "add";
            const string DeletePlayers = "del";
            const string BannedPlayers = "ban";
            const string UnBannedPlayers = "unban";
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню:\n1. Вывести список всех игроков - show\n2. Добавить игрока             - add\n3. Забанить игрока           " +
                "  - ban\n" + "4. Разбанить игрока            - unban" + "\n5. Удалить игрока              - del\n6. Выход                       - exit");
                Console.Write("\nВаш ввод: ");
                string choosePlayer = Console.ReadLine();

                switch (choosePlayer)
                {
                    case ShowAllPlayers:
                        ShowBase();
                        break;
                    case AddPlayers:
                        AddPlayer();
                        break;
                    case BannedPlayers:
                        BanPlayer();
                        break;
                    case UnBannedPlayers:
                        UnBanPlayer();
                        break;
                    case DeletePlayers:
                        DeletePlayer();
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Команда не найдена\n");
                        break;
                }
            }
        }

        public void AddPlayer()
        {
            string baseLevel = "Junior";
            bool isPlayerBanned = false;
            Console.Write("\nЧто бы добавить игрока введите его ID: ");
            int inputPlayerId = Convert.ToInt32(Console.ReadLine());

            foreach (var player in Players)
            {
                while (inputPlayerId == player.Id)
                {
                    Console.Write("Такой Id уже существувет, укажите другой: ");
                    inputPlayerId = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.Write("\nВведите имя игрока: ");
            string inputPlayerName = Console.ReadLine();
            Players.Add(new Player(inputPlayerName, inputPlayerId, baseLevel, isPlayerBanned));
            Console.Clear();
        }

        public void BanPlayer()
        {
            Console.Write("\nВведите ID игрока, которого необходимо забанить: ");
            bool banTrigger = TryGetPlayer(out _player);

            if (banTrigger && _player.IsBanned == false)
            {
                _player.IsBanned = true;
                Console.WriteLine("Игрок забанен");
            }
            else
            {
                Console.WriteLine("Ошибка, проверьте вводимые данные");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void UnBanPlayer()
        {
            Console.WriteLine("\nСписок забаненых игроков: ");

            foreach (var player in Players)
            {
                if (player.IsBanned == true)
                {
                    player.ShowInfo();
                }
            }
            Console.Write("\nВведите Id игрока, которого необходимо разбанить: ");
            bool unbanTrigger = TryGetPlayer(out _player);

            if (unbanTrigger && _player.IsBanned)
            {
                _player.IsBanned = false;
                Console.WriteLine("Игрок разбанен");
            }
            else
            {
                Console.WriteLine("Ошибка, проверьте вводимые данные");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void DeletePlayer()
        {
            Console.Write("\nВведите Id игрока, которого необходимо удалить: ");
            bool deleteTrigger = TryGetPlayer(out _player);

            if (deleteTrigger)
            {
                Players.Remove(_player);
                Console.WriteLine("Игрок удален");
            }
            else
            {
                Console.WriteLine("Ошибка, проверьте вводимые данные");
            }
            Console.ReadKey();
            Console.Clear();
        }

        private bool TryGetPlayer(out Player gamer)
        {
            bool isFindPlayer = true;
            gamer = null;
            int inputPlayerId = Convert.ToInt32(Console.ReadLine());

            foreach (var player in Players)
            {
                if (inputPlayerId == player.Id)
                {
                    gamer = player;
                    return isFindPlayer;
                }
            }
            return isFindPlayer = false;
        }

        public void ShowBase()
        {
            Console.WriteLine("\nБаза данных игроков:");

            foreach (var player in Players)
            {
                player.ShowInfo();
            }
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public string Level { get; private set; }
        public bool IsBanned { get; set; }

        public Player(string name, int id, string level, bool isBanned)
        {
            Name = name;
            Id = id;
            Level = level;
            IsBanned = isBanned;
        }

        public void ShowInfo()
        {
            string flag;

            if (IsBanned)
            {
                flag = "забанен";
            }
            else
            {
                flag = "активен";
            }
            Console.WriteLine("ID: " + Id + ". Имя игрока: [" + Name + "] уровень: [" + Level + "] статус: " + flag);
        }
    }
}
