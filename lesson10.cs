using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            int step = 7;
            int lastNumber = 96;

            for (number = 5; number<=lastNumber; number+=step)
            {
                Console.Write(number + " ");
            }
        }
    }
}
