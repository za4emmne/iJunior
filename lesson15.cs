using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int number = rand.Next(1, 28);
            int firstNumber = 100;
            int lastNumber = 1000;
            int secondNumber;
            int currentAimNumber = 0;

            Console.WriteLine("Число из рандома в диапазоне от 1 до 27: " + number);

            for (int i = firstNumber; i < lastNumber; i++)
            {
                secondNumber = i;

                while(secondNumber>0)
                {
                    secondNumber -= number;
                }

                if(secondNumber==0)
                {
                    currentAimNumber++;
                }
            }
            Console.WriteLine("Оно кратно " + currentAimNumber + " трехзначным науральным числам.");
        }
    }
}
