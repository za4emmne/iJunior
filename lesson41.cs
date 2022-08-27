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
        private List<Player> _players = new List<Player>();

        public Database()
        {
            _players.Add(new Player("Nick", 1, "junior", true));
            _players.Add(new Player("Keck", 2, "middle", false));
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
                        ShowPlayers();
                        break;
                    case AddPlayers:
                        AddAndCheckPlayer();
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

        public void AddAndCheckPlayer()
        {
            string baseLevel = "Junior";
            bool isPlayerBanned = false;
            Console.Write("\nЧто бы добавить игрока введите его ID: ");
            bool isFindPlayerId = true;
            isFindPlayerId = TryGetPlayer(out _player);

            if (isFindPlayerId)
            {
                Console.WriteLine("Такой Id уже существувет, укажите другой!\n");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Write("\nВведите имя игрока: ");
                string inputPlayerName = Console.ReadLine();
                _players.Add(new Player(inputPlayerName, _player.Id, baseLevel, isPlayerBanned));
                Console.Clear();
            }
        }

        public void BanPlayer()
        {
            Console.Write("\nВведите ID игрока, которого необходимо забанить: ");
            bool banTrigger = TryGetPlayer(out _player);

            if (banTrigger && _player.IsBanned == false)
            {
                _player.Ban();
                Console.WriteLine("Игрок забанен");
            }
            else
            {
                Console.WriteLine("Ошибка, проверьте вводимые данные");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowBannedPlayers()
        {
            Console.WriteLine("\nСписок забаненых игроков: ");

            foreach (var player in _players)
            {
                if (player.IsBanned == true)
                {
                    player.ShowInfo();
                }
            }
        }

        public void UnBanPlayer()
        {
            ShowBannedPlayers();
            Console.Write("\nВведите Id игрока, которого необходимо разбанить: ");
            bool unbanTrigger = TryGetPlayer(out _player);

            if (unbanTrigger && _player.IsBanned)
            {
                _player.Unban();
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
            bool isCompleatBanned = TryGetPlayer(out _player);

            if (isCompleatBanned)
            {
                _players.Remove(_player);
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
            bool isNumber = true;
            bool isFindPlayer = true;
            gamer = null;
            string inputPlayerId = Console.ReadLine();
            int.TryParse(inputPlayerId, out int outputPlayerId);

            if (isNumber)
            {
                foreach (var player in _players)
                {
                    if (outputPlayerId == player.Id)
                    {
                        gamer = player;
                        return isFindPlayer;
                    }
                }
                return isFindPlayer = false;
            }
            else
            {
                return isFindPlayer = false;
            }
        }

        public void ShowPlayers()
        {
            Console.WriteLine("\nБаза данных игроков:");

            foreach (var player in _players)
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
        public bool IsBanned { get; private set; }

        public Player(string name, int id, string level, bool isBanned)
        {
            Name = name;
            Id = id;
            Level = level;
            IsBanned = isBanned;
        }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }

        public void ShowInfo()
        {
            string bannedFlag;
            if (IsBanned)
            {
                bannedFlag = "забанен";
            }
            else
            {
                bannedFlag = "активен";
            }
            Console.WriteLine("ID: " + Id + ". Имя игрока: [" + Name + "] уровень: [" + Level + "] статус: " + bannedFlag);
        }
    }
}
