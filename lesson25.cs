using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayValue = 10;
            int[] array = new int[arrayValue];
            int randomTop = 10;
            int randomDown = 0;
            int waitNumber = 0;
            Random random = new Random();

            Console.Write("Исходный массив - ");

            for (int i = 0; i < arrayValue; i++)
            {
                array[i] = random.Next(randomDown, randomTop);
                Console.Write(array[i] + " ");
            }

            for (int i = 0; i < arrayValue; i++)
            {

                for (int j = 0; j < arrayValue-1-i; j++)
                {

                    if (array[j] > array[j+1])
                    {
                        waitNumber = array[j];
                        array[j] = array[j+1];
                        array[j+1] = waitNumber;
                    }                   
                }
            }
            Console.Write("\nОтсортированный массив - ");

            for (int i = 0; i < arrayValue; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
    }
}
