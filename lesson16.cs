using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int number = rand.Next(0, 1000000);
            int sqr = 1;
            int numberTwo = 2;
            int sqrTwo = 2;

            for (int i = 1; number>sqrTwo; i++)
            {
                sqrTwo = sqrTwo * numberTwo;
                sqr = i;
            }
            Console.WriteLine("Число из рандома: " + number + "\nМинимальная степень " + sqr + ", а число в этой степени - " + sqrTwo);
        }
    }
}
