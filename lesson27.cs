using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            int tempArrayNumber;
            Random random = new Random();
            int minRandom = 5;
            int maxRandom = 10;
            int arrayValue = random.Next(minRandom, maxRandom);
            int[] array = new int[arrayValue];

            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < arrayValue; i++)
            {
                array[i] = i + 1;
                Console.Write(array[i] + " ");
            }
            Console.WriteLine("\nВведите на сколько сдвнуть массив");
            userInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < userInput; i++)
            {
                tempArrayNumber = array[0];

                for (int j = 0; j < arrayValue-1; j++)
                {
                    array[j] = array[j + 1];
                }
                array[arrayValue-1] = tempArrayNumber;
            }
            Console.WriteLine("Новый массив: ");

            for (int i = 0; i < arrayValue; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
