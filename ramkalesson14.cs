using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputWord;
            string inputSymbol;
            int addSymbol = 3;

            Console.Write("Введите слово: ");
            inputWord = Console.ReadLine();
            Console.Write("Введите символ: ");
            inputSymbol = Console.ReadLine();

            for(int i=0; i<= inputWord.Length+addSymbol; i++)
            {
                Console.Write(inputSymbol);
            }
            Console.WriteLine("\n" + inputSymbol + " " + inputWord + " " + inputSymbol);

            for (int i = 0; i <= inputWord.Length+addSymbol; i++)
            {
                Console.Write(inputSymbol);
            }
        }
    }
}
