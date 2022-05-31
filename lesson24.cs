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
            int randomTop = 10;
            Random random = new Random();
            int number = 0;
            int repeat = 1;
            int repeatMount = 1;
            int numberMax = 0;

            for (int i = 0; i < arrayValue; i++)
            {
                array[i] = random.Next(randomDown, randomTop);
                Console.Write(array[i] + " ");
            }

            for (int i = 1; i < arrayValue; i++)
            {

                if (array[i - 1] == array[i])
                {
                    repeat++;
                    number = array[i];
                }
                else
                {

                    if (repeat > repeatMount)
                    {
                        repeatMount = repeat;
                        numberMax = number;
                    }
                    repeat = 1;
                }
            }
            Console.WriteLine("\nЧисло - " + numberMax + " повторяется " + repeatMount + " раз");
        }
    }
}
