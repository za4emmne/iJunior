using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            Console.Write("Введите предложение: ");
            userInput = Console.ReadLine();
            string[] words = userInput.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}
