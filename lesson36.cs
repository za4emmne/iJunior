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
                        ShowSum(numbers);
                        break;
                    case "exit":
                        isExit = true;
                        break;
                    default:
                        AddNumber(userInput, numbers);
                        break;
                }
            }
        }

        static void AddNumber(string userInput, List<int> numbers)
        {
            int outputNumber;
            int.TryParse(userInput, out outputNumber);
            numbers.Add(outputNumber);
        }

        static void ShowSum(List<int> numbers)
        {
            Console.WriteLine($"Сумма чисел равна - {numbers.Sum()}");
        }
    }
}
