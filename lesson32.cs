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
            int playerPositionX;
            int playerPositionY;
            int playerDirectionX = 0;
            int playerDirectionY = 0;
            int level = 200;
            int timer = 1000;
            char playerSkin = 'Ж';
            string mapName = "pacmanmap";
            char[,] map = ReadMap(ref mapName, out playerPositionX, out playerPositionY, playerSkin, ref allPoint);

            while (isExit == false)
            {
                Console.Clear();
                int userInputLevel = 0;
                int userInputMap = 0;
                Console.WriteLine("Добро пожаловать\n Выберите пункт меню:\n1. Играть\n2. Нарисовать карту\n3. Выбрать карту\n4. Выбрать скин игрока\n5. Выйти");
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Play(map, ref playerPositionX, ref playerPositionY, ref playerDirectionX, ref playerDirectionY, ref playerSkin, allPoint, ref casePoint, ref level, ref timer, ref userInputLevel);
                        break;
                    case 2:
                        PlayerDrawMap(mapName, map, out playerPositionX, out playerPositionY, playerSkin, allPoint, casePoint, playerDirectionX, playerDirectionY, level);
                        break;
                    case 3:
                        ChooseMap(userInputMap, mapName);
                        break;
                    case 4:
                        ChooseSkin(playerSkin);
                        break;
                    case 5:
                        isExit = true;
                        break;
                }
            }
        }

        static void ChooseSkin(char playerSkin)
        {
            Console.Write("Нажмите на символ, для выбора скина: ");
            playerSkin = Convert.ToChar(Console.ReadLine());
        }

        static void ChooseMap(int userInputMap, string mapName)
        {
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
        }

        static void Play(char[,] map, ref int positionX, ref int positionY, ref int directionX, ref int directionY, ref char skin, int allPoint, ref int casePoint, ref int speed, ref int timer, ref int userInput)
        {
            bool isPlaying = true;
            Console.Clear();
            Console.WriteLine($"Выберите уровень сложности\n1. Легкий\n2. Средний\n3. Сложный");
            userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    {
                        timer = 1000;
                        break;
                    }
                case 2:
                    {
                        timer = 500;
                        break;
                    }
                case 3:
                    {
                        timer = 250;
                        break;
                    }
            }
            Console.Clear();
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
                    ChangePosition(key, ref directionX, ref directionY);

                    if (key.Key == ConsoleKey.Escape)
                    {
                        isPlaying = false;
                    }
                }
                Move(map, ref positionX, ref positionY, directionX, directionY, ref skin, ref casePoint);
                System.Threading.Thread.Sleep(speed);

                if (casePoint == allPoint)
                {
                    Console.Clear();
                    Console.WriteLine("Вы победилиЙ");
                    isPlaying = false;
                }

                if (map[positionX, positionY] == '.')
                {
                    casePoint++;
                    map[positionX, positionY] = ' ';
                }
            }
            Console.Clear();
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("Вы проиграли\nНажмите любую кнопку");
            Console.ReadKey();
        }

        static void ChangePosition(ConsoleKeyInfo key, ref int directionX, ref int directionY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    directionY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    directionX = 1;
                    directionY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    directionX = 0;
                    directionY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    directionX = 0;
                    directionY = 1;
                    break;
            }
        }

        static void Move(char[,] map, ref int positionPlayerX, ref int positionPlayerY, int directionPlayerX, int directionPlayerY, ref char skin, ref int casePoint)
        {
            if (map[positionPlayerX + directionPlayerX, positionPlayerY + directionPlayerY] != '=' && map[positionPlayerX + directionPlayerX, positionPlayerY + directionPlayerY] != '#')
            {
                Console.SetCursorPosition(positionPlayerY, positionPlayerX);
                Console.Write(" ");
                positionPlayerX += directionPlayerX;
                positionPlayerY += directionPlayerY;
                Console.SetCursorPosition(positionPlayerY, positionPlayerX);
                Console.Write(skin);
            }
        }

        static char[,] ReadMap(ref string mapName, out int playerPositionX, out int playerPositionY, char skin, ref int allPoint)
        {
            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];
            playerPositionX = 0;
            playerPositionY = 0;

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
                        playerPositionX = i;
                        playerPositionY = j;
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

        static void PlayerDrawMap(string mapName, char[,] map, out int playerPositionX, out int playerPositionY, char playerSkin, int allPoint, int casePoint, int playerDirectionX, int playerDirectionY, int level)
        {
            Console.Clear();
            bool isDrawMap = true;
            mapName = "newmap";
            char wall = '#';
            map = ReadMap(ref mapName, out playerPositionX, out playerPositionY, playerSkin, ref allPoint);
            DrawMap(map, ref playerSkin, ref casePoint, allPoint);
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("\nНажмите Esk для выхода в меню\nЧтобы нарисовать стену нажмите - Enter\nЧтобы нарисовать точки нажмите - Tab");

            while (isDrawMap)
            {
                Console.CursorVisible = true;

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangePosition(key, ref playerDirectionX, ref playerDirectionY);

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
                            break;
                    }
                }

                if (map[playerPositionX + playerDirectionX, playerDirectionY + playerDirectionY] != '#')
                {
                    Console.SetCursorPosition(playerPositionY, playerPositionX);
                    Console.Write(wall);
                    playerPositionX += playerDirectionX;
                    playerPositionY += playerDirectionY;
                    Console.SetCursorPosition(playerPositionY, playerPositionX);
                    Console.Write(playerSkin);
                }
                System.Threading.Thread.Sleep(level);
            }
        }
    }
}
