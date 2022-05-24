using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            int deepInside = 0;
            int maxDeep = 1;
            char openBracket = '(';
            char closeBracket = ')';

            Console.Write("Введите строку из символов ( и ): ");
            userInput = Console.ReadLine();

            for (int i = 0; i < userInput.Length; i++)
            {

                if (userInput[i] == openBracket)
                {
                    deepInside++;

                    if (deepInside>maxDeep)
                    {
                        maxDeep = deepInside;
                    }
                }
                else if (userInput[i] == closeBracket)
                {
                    deepInside--;
                } 

                if(deepInside<0)
                {
                    Console.WriteLine("Выражение некорректно!");
                }
            }

            if (deepInside != 0)
            {
                Console.WriteLine("Выражение некорректно!");
            }
            Console.WriteLine("Выражение корректно\nГлубина выражения = " + maxDeep);           
        }
    }
}
