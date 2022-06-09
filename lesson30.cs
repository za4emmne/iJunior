using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomMin = 0;
            int randomMax = 10;

            Console.Write("Введите размер массива: ");
            int arrayValue = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[arrayValue];
            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < arrayValue; i++)
            {
                array[i] = random.Next(randomMin, randomMax);
                Console.Write((i+1) + ". " + array[i] + "\n");
            }
            array = Shuffle(array, arrayValue);
            Console.WriteLine("Перемешанный массив: ");

            for (int i = 0; i < arrayValue; i++)
            {
                Console.Write((i + 1) + ". " + array[i] + "\n");
            }
        }

        static int[] Shuffle(int[] arrayShuffle, int arrayValue)
        {
            int index = 0;
            Random randomIndex = new Random();
            int randomIndexMin = 0;
            int randomIndexMax = arrayValue;

            for (int i = arrayValue-1; i > 0; i--)
            {
                int tempNumber = 0;
                index = randomIndex.Next(randomIndexMin, randomIndexMax);
                tempNumber = arrayShuffle[index];
                arrayShuffle[index] = arrayShuffle[i];
                arrayShuffle[i] = tempNumber;
            }
            return arrayShuffle;
        }
    }
}
