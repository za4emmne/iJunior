using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrayValue = 30;
            int[] array = new int[arrayValue];
            int randomDown = 0;
            int randomTop = 4;
            Random random = new Random();
            int number = 2;
            int repeat = 0;
            int repeatMount = 0;

            for (int i = 1; i < array.Length; i++)
            {
                array[i] = random.Next(randomDown, randomTop);
                Console.Write(array[i] + " ");

                if (array[i-1] == array[i])
                {
                    repeat++;
                    number = array[i];
                }
                else if (repeat > repeatMount)
                {
                    repeatMount = repeat;
                    repeat = 0;
                }
            }
            Console.WriteLine("\nЧисло - " + number + " повторяется " + repeatMount + " раз");
        }
    }
}
