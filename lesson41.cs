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
            List<Player> players = database.Players;
            database.Menu();
        }
    }

    class Database
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public Database()
        {
            Players.Add(new Player("Nick", 1, "junior", true));
            Players.Add(new Player("Keck", 2, "middle", false));
        }

        public void Menu()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню:\n1. Вывести список всех игроков\n2. Добавить игрока\n3. Забанить игрока\n4. Разбанить игрока" +
                    "\n5. Удалить игрока\n6. Выход");
                Console.Write("\nВаш ввод: ");
                string choosePlayer = Console.ReadLine();

                switch (choosePlayer)
                {
                    case "1":
                        ShowDataBase();
                        break;
                    case "2":
                        AddPlayer();
                        break;
                    case "3":
                        BanPlayer();
                        break;
                    case "4":
                        UnBanPlayer();
                        break;
                    case "5":
                        DeletePlayer();
                        break;
                    case "6":
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
            bool baseFlag = true;
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
            Players.Add(new Player(inputPlayerName, inputPlayerId, baseLevel, baseFlag));
            Console.Clear();
        }

        public void BanPlayer()
        {
            bool banTrigger = true;
            Console.Write("\nВведите ID игрока, которого необходимо забанить: ");
            int inputPlayerId = Convert.ToInt32(Console.ReadLine());

            foreach (var player in Players)
            {
                if (player.Id == inputPlayerId && player.Flag)
                {
                    player.Flag = false;
                    banTrigger = false;
                    Console.WriteLine("Игрок забанен");
                }
            }

            if (banTrigger)
            {
                Console.WriteLine("Ошибка, проверьте вводимые данные");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void UnBanPlayer()
        {
            bool banTrigger = true;
            Console.WriteLine("\nСписок забаненых игроков: ");

            foreach (var player in Players)
            {
                if (player.Flag == false)
                {
                    player.ShowInfo();
                }
            }
            Console.Write("\nВведите Id игрока, которого необходимо разбанить: ");
            int inputPlayerId = Convert.ToInt32(Console.ReadLine());

            foreach (var player in Players)
            {
                if (player.Id == inputPlayerId && player.Flag == false)
                {
                    player.Flag = true;
                    banTrigger = false;
                    Console.WriteLine("Игрок разбанен");
                }
            }

            if (banTrigger)
            {
                Console.WriteLine("Ошибка, проверьте вводимые данные");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void DeletePlayer()
        {
            bool deleteTrigger = false;
            Console.Write("\nВведите Id игрока, которого необходимо удалить: ");
            int inputPlayerId = Convert.ToInt32(Console.ReadLine());

            foreach (var player in Players)
            {
                if (player.Id == inputPlayerId)
                {
                    deleteTrigger = true;
                }
            }

            if (deleteTrigger)
            {
                Players.RemoveAt(FindIndexPlayer(inputPlayerId));
                Console.WriteLine("Игрок удален");
            }
           else
            {
                Console.WriteLine("Ошибка, проверьте вводимые данные");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public int FindIndexPlayer(int inputId)
        {
            int findIndex = -1;

            foreach (var player in Players)
            {
                if (inputId == player.Id)
                {
                    findIndex = Players.IndexOf(player);
                }
            }
            return findIndex;
        }
        public void ShowDataBase()
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
        public string Name { get; set; }
        public int Id { get; set; }
        public string Level { get; set; }
        public bool Flag { get; set; }

        public Player(string name, int id, string level, bool flag)
        {
            Name = name;
            Id = id;
            Level = level;
            Flag = flag;
        }

        public void ShowInfo()
        {
            string flag;

            if (Flag)
            {
                flag = "активен";
            }
            else
            {
                flag = "забанен";
            }
            Console.WriteLine("ID: " + Id + ". Имя игрока: [" + Name + "] уровень: [" + Level + "] статус: " + flag);
        }
    }
}
