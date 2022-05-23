using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 0;
            int lastNumber = 1000000;
            Random random = new Random();
            int number = random.Next(firstNumber, lastNumber);
            int sqruare = 1;
            int findNumber = 2;
            int squareFindNumber = 2;

            for (int i = 1; number > squareFindNumber; i++)
            {
                squareFindNumber = squareFindNumber * findNumber;
                sqruare = i;
            }
            Console.WriteLine("Число из рандома: " + number + "\nМинимальная степень " + sqruare + ", а число в этой степени - " + squareFindNumber);
        }
    }
}
