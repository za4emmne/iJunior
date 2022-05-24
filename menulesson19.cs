using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int blackOut;
            bool isBlackOut = false;
            bool isExit = false;
            bool isEnter = false;
            bool isReadKey = false;
            string playerChoose;
            string inputName;
            string inputPassword;
            string name = null;
            string password = null;
            string inputColor;

            Console.WriteLine("Добро пожаловать");

            while (isExit == false && isBlackOut == false)
            {
                Console.WriteLine("\n 1 - Зарегистрироваться");
                Console.WriteLine(" 2 - Авторизоваться");
                Console.WriteLine(" 3 - Изменить имя пользователя");
                Console.WriteLine(" 4 - Изменить цвет текста");
                Console.WriteLine(" 5 - Изменить цвет консоли");
                Console.WriteLine(" 6 - Запустить BlackOut c0de");
                Console.WriteLine(" 7 - Выход\n");
                playerChoose = Console.ReadLine();

                switch (playerChoose)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("РЕГИСТРАЦИЯ");
                            Console.Write("\nВведите имя: ");
                            name = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            password = Console.ReadLine();
                            Console.Write("\nВы успешно зарегистрировались.\n");
                            break;
                        }
                    case "2":
                        {

                            if (name != null && password != null)
                            {
                                Console.Clear();
                                Console.WriteLine("АВТОРИЗАЦИЯ");
                                Console.Write("\nВведите имя: ");
                                inputName = Console.ReadLine();

                                if (inputName == name)
                                {
                                    Console.Write("Введите пароль: ");
                                    inputPassword = Console.ReadLine();

                                    if (inputPassword == password)
                                    {
                                        Console.WriteLine("\nВы авторизовались");
                                        isEnter = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nНеверный пароль");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nНеверный логин");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nЗарегистрируйтесь");
                            }
                                break;
                        }
                    case "3":
                        {

                            if (isEnter == true)
                            {
                                Console.Clear();
                                Console.WriteLine("\nВведите новое имя");
                                name = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("\nАвторизуйтесь");
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите цвет текста:");
                            Console.WriteLine(" 1 - Белый\n 2 - Желтый\n 3 - Красный\n 4 - Зеленый");
                            inputColor = Console.ReadLine();

                            switch (inputColor)
                            {
                                case "1":
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        break;
                                    }
                                case "2":
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        break;
                                    }
                                case "3":
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;
                                    }
                                case "4":
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    }
                            }
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            Console.WriteLine("Выберите цвет фона:");
                            Console.WriteLine(" 1 - Черный\n 2 - Серый\n 3 - Голубой\n 4 - Фиолетовый\n");
                            inputColor = Console.ReadLine();

                            switch (inputColor)
                            {
                                case "1":
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        break;
                                    }
                                case "2":
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkGray;
                                        break;
                                    }
                                case "3":
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                                        break;
                                    }
                                case "4":
                                    {
                                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                        break;
                                    }
                            }
                            Console.Clear();
                            break;
                        }
                    case "6":
                        {
                            Console.Clear();

                            if (isEnter == true)
                            {
                                Console.Write("Введите пароль: ");
                                inputPassword = Console.ReadLine();

                                if (inputPassword == password)
                                {
                                    isBlackOut = true;
                                    Console.Clear();

                                    while (isReadKey)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        blackOut = random.Next(0, 2);
                                        Console.Write(blackOut);     
                                    }
                                    Console.ReadKey();
                                    isReadKey = true;
                                }
                                else
                                {
                                    Console.WriteLine("\nНеверный пароль");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nАвторизуйтесь");
                            }                           
                            break;
                        }
                    case "7":
                        {
                            isExit = true;
                            break;
                        }
                }
            }
        }
    }
}
