using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";

            GetParse(userInput);
        }

        static int GetParse(string input)
        {
            Console.Write("Введите что хотите сконвертировать: ");
            input = Console.ReadLine();
            bool result = int.TryParse(input, out int output);

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
