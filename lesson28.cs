using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int minHealth = 1;
            int maxHealth = 10;
            int userInput;
            Console.Write("Введите количество жизней от " + minHealth + " до " + maxHealth + ": ");
            userInput = Convert.ToInt32(Console.ReadLine());

            drawBar(userInput, maxHealth, ConsoleColor.Red);

            static void drawBar(int value, int maxValue, ConsoleColor color)
            {
                ConsoleColor defaultColor = Console.BackgroundColor;
                string bar = "";

                for (int i = 0; i < value; i++)
                {
                    bar += '#';
                }
                Console.SetCursorPosition(5, 3);
                Console.Write("[");
                Console.BackgroundColor = color;
                Console.Write(bar);
                Console.BackgroundColor = defaultColor;
                bar = "";

                for (int i = value; i < maxValue; i++)
                {
                    bar += '_';
                }
                Console.Write(bar + "]");
            }
        }
    }
}
