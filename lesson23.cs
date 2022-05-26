using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            string userInput = "";
            int[] array = new int[0];

            while (isExit == false)
            {
                Console.Write("Введите команду:\n sum - суммировать все введенные числа\n exit - выход\nИли введите число: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "exit":
                        {
                            isExit = true;
                            break;
                        }
                    case "sum":
                        {
                            int sum = 0;

                            for (int i = 0; i < array.Length; i++)
                            {
                                sum += array[i];
                            }
                            Console.WriteLine("Cумма элементов массива = " + sum + "\n");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            int number;
                            int[] tempArray = new int[array.Length + 1];

                            for (int i = 0; i < array.Length; i++)
                            {
                                tempArray[i] = array[i];
                            }
                            array = tempArray;
                            number = Convert.ToInt32(userInput);
                            array[array.Length-1] = number;
                            break;
                        }
                }
                Console.Clear();
            }
        }
    }
}
