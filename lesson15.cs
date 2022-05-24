using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int downNumberRandom = 1;
            int topNumberRandom = 28;
            int number = random.Next(downNumberRandom, topNumberRandom);
            int firstNumber = 100;
            int lastNumber = 1000;
            int secondNumber;
            int currentAimNumber = 0;

            Console.WriteLine("Число из рандома в диапазоне от " + downNumberRandom + " до " + topNumberRandom + " является " + number);

            for (int i = 0; i < lastNumber; i+=number)
            {
                secondNumber = i;

                if (secondNumber > 100)
                {
                    currentAimNumber++;
                }
            }
            Console.WriteLine("Оно кратно " + currentAimNumber + " трехзначным науральным числам.");
        }
    }
}
