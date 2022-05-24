using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputWord;
            char inputSymbol;
            string lineSymbol;
            string line = "";
            int addSymbol = 4;
            int lineLength;
            int lineWord;

            Console.Write("Введите слово: ");
            inputWord = Console.ReadLine();
            Console.Write("Введите символ: ");
            inputSymbol = Convert.ToChar(Console.ReadLine());
            lineSymbol = Convert.ToString(inputSymbol);
            lineWord = inputWord.Length;
            lineLength = lineWord + addSymbol;

            for (int i = 0; i < lineLength; i++)
            {
                line += lineSymbol;
            }
            Console.WriteLine("\n" + line);
            Console.WriteLine(inputSymbol + " " + inputWord + " " + inputSymbol);
            Console.WriteLine(line);
        }
    }
}
