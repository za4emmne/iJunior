using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            int output = 0;
            bool resultParsing = false;

            Parsing(userInput, output, resultParsing);
        }

        static int Parsing(string input, int output, bool result)
        {
            Console.Write("Введите что хотите сконвертировать: ");
            input = Console.ReadLine();
            result = int.TryParse(input, out output);

            while (result == false)
            {                            
                Console.Write("Конвертация не удалась, попробуйте еще раз: ");
                input = Console.ReadLine();  
                result = int.TryParse(input, out output);         
            }
            Console.Write("Ввод отконвертирован");
            return output;
        }
    }
}
