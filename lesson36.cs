using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            List<int> numbers = new List<int>();
            bool isExit = false;

            while (isExit == false)
            {
                Console.Write("Введите число или команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "sum":
                        Sum(numbers);
                        break;
                    case "exit":
                        isExit = true;
                        break;
                    default:
                        Parser(userInput, numbers);
                        break;
                }
            }
        }

        static void Parser(string userInput, List<int> numbers)
        {
            int outputNumber;
            int.TryParse(userInput, out outputNumber);
            numbers.Add(outputNumber);
        }

        static void Sum(List<int> numbers)
        {
            int sum = 0;
            Console.WriteLine($"Сумма чисел равна - {sum = numbers.Sum()}");
            sum = 0;
        }
    }
}
