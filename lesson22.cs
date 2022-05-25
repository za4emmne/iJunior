using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayValue = 30;
            int[] array = new int[arrayValue];
            Random random = new Random();
            int number = 0;
            int minRandom = 0;
            int maxRandom = 10;

            for (int i = 1; i < array.Length-1; i++)
            {
                array[i] = random.Next(minRandom, maxRandom);
                Console.Write(array[i] + " "); 
            }

            for (int i = 1; i < array.Length - 1; i++)
            {

                if (array[i] > array[i + 1] && array[i] > array[i - 1])
                {
                    number = array[i];
                    Console.WriteLine("\nЛокальный максимум: " + number);
                }
            }
        }
    }
}
