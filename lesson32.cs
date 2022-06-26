using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isExit = false;
            int allPoint = 0;
            int casePoint = 0;
            int playerX;
            int playerY;
            int playerDX = 0;
            int playerDY = 0;
            int level = 200;
            int timer = 1000;
            char playerSkin = 'Ж';
            string mapName = "pacmanmap";
            char[,] map = ReadMap(ref mapName, out playerX, out playerY, playerSkin, ref allPoint);

            while (isExit == false)
            {
                Console.Clear();
                ChooseMenu(map, ref playerX, ref playerY, ref playerDX, ref playerDY, ref playerSkin, ref isExit, allPoint, ref casePoint,
                    ref level, ref timer, ref mapName);
            }
        }

        static void ChooseMenu(char[,] map, ref int x, ref int y, ref int dx, ref int dy, ref char playerSkin, ref bool exit, int allPoint,
            ref int casePoint, ref int level, ref int timer, ref string mapName)
        {
            int userInputLevel = 0;
            int userInputMap = 0;
            Console.WriteLine("Добро пожаловать\n Выберите пункт меню:\n1. Играть\n2. Нарисовать карту\n3. Настройки\n4. Выбрать скин игрока\n5. Выйти");
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine($"Выберите уровень сложности\n1. Легкий\n2. Средний\n3. Сложный:");
                    userInputLevel = Convert.ToInt32(Console.ReadLine());

                    switch (userInputLevel)
                    {
                        case 1:
                            {
                                timer = 1000;
                                level = 200;
                                break;
                            }
                        case 2:
                            {
                                timer = 500;
                                level = 150;
                                break;
                            }
                        case 3:
                            {
                                timer = 250;
                                level = 100;
                                break;
                            }
                    }
                    Console.Clear();
                    Playing(map, ref x, ref y, ref dx, ref dy, ref playerSkin, allPoint, ref casePoint, ref level, ref timer);
                    break;
                case 2:
                    Console.Clear();
                    bool isDrawMap = true;
                    mapName = "newmap";
                    char wall = '#';
                    map = ReadMap(ref mapName, out x, out y, playerSkin, ref allPoint);
                    DrawMap(map, ref playerSkin, ref casePoint, allPoint);
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("\nНажмите Esk для выхода в меню\nЧтобы нарисовать стену нажмите - Enter\nЧтобы нарисовать точки нажмите - Tab");

                    while (isDrawMap)
                    {
                        Console.CursorVisible = true;

                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo key = Console.ReadKey(true);
                            ChangePosition(key, ref dx, ref dy);

                            switch (key.Key)
                            {
                                case ConsoleKey.Enter:
                                    wall = '#';
                                    break;
                                case ConsoleKey.Tab:
                                     wall = '.';
                                    break;
                                case ConsoleKey.Escape:
                                    isDrawMap = false;
                                    break;                                                           }
                        }                      

                        if (map[x + dx, y + dy] != '#')
                        {
                            Console.SetCursorPosition(y, x);
                            Console.Write(wall);
                            x += dx;
                            y += dy;
                            Console.SetCursorPosition(y, x);
                            Console.Write(playerSkin);
                        }
                        System.Threading.Thread.Sleep(level);
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine($"Выберите карту\n1. Старндартная\n2. Моя\n");
                    userInputMap = Convert.ToInt32(Console.ReadLine());

                    switch (userInputMap)
                    {
                        case 1:
                            {
                                mapName = "pacmanmap";
                                break;
                            }
                        case 2:
                            {
                                mapName = "newmap";
                                break;
                            }                        
                    }
                    break;
                case 4:
                    Console.Write("Нажмите на символ, для выбора скина: ");
                    playerSkin = Convert.ToChar(Console.ReadLine());
                    break;
                case 5:
                    exit = true;
                    break;
            }
        }

        static void Playing(char[,] map, ref int x, ref int y, ref int dx, ref int dy, ref char skin, int allPoint, ref int casePoint, ref int speed, ref int timer)
        {
            bool isPlaying = true;
            DrawMap(map, ref skin, ref casePoint, allPoint);
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("\n\nНажмите Esk для выхода в меню");

            while (isPlaying && timer > 0)
            {
                Console.SetCursorPosition(0, 23);
                Console.WriteLine($"\nСобрано: {casePoint} / {allPoint}");
                timer--;
                Console.WriteLine($"Осталось времени: {timer}");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangePosition(key, ref dx, ref dy);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        isPlaying = false;
                    }
                }
                Move(map, ref x, ref y, dx, dy, ref skin, ref casePoint);
                System.Threading.Thread.Sleep(speed);

                if (casePoint == allPoint)
                {
                    Console.Clear();
                    Console.WriteLine("Вы победилиЙ");
                    isPlaying = false;
                }
            }
            Console.Clear();
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("Вы проиграли\nНажмите любую кнопку");
            Console.ReadKey();
        }

        static void ChangePosition(ConsoleKeyInfo key, ref int dX, ref int dY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    dX = -1; dY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    dX = 1; dY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    dX = 0; dY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    dX = 0; dY = 1;
                    break;
            }
        }

        static void Move(char[,] map, ref int x, ref int y, int dx, int dy, ref char skin, ref int casePoint)
        {
            if (map[x + dx, y + dy] != '=' && map[x + dx, y + dy] != '#')
            {
                Console.SetCursorPosition(y, x);
                Console.Write(" ");
                x += dx;
                y += dy;
                Console.SetCursorPosition(y, x);
                Console.Write(skin);

                if (map[x, y] == '.')
                {
                    casePoint++;
                    map[x, y] = ' ';
                }
            }
        }

        static char[,] ReadMap(ref string mapName, out int playerX, out int playerY, char skin, ref int allPoint)
        {
            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];
            playerX = 0;
            playerY = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] != ' ' && map[i, j] != '=' && map[i, j] != '#' && map[i, j] != '.')
                    {
                        map[i, j] = skin;
                    }

                    if (map[i, j] == skin)
                    {
                        playerX = i;
                        playerY = j;
                    }

                    else if (map[i, j] == ' ')
                    {
                        map[i, j] = '.';
                        allPoint++;
                    }
                }
            }
            return map;
        }

        static void DrawMap(char[,] map, ref char skin, ref int casePoint, int allPoint)
        {

            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
