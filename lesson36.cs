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
            int sum = 0;

            while (isExit == false)
            {
                Console.Write("Введите число или команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "sum":
                        Console.WriteLine($"Сумма чисел равна - {sum = numbers.Sum()}");
                        break;
                    case "exit":
                        isExit = true;
                        break;
                    default:
                        numbers.Add(Convert.ToInt32(userInput));
                        break;
                }
            }
        }
    }
}
