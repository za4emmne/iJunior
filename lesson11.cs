using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 0;
            int lastNumber = 101;
            Random random = new Random();
            int number = random.Next(firstNumber, lastNumber);
            int sum = 0;
            int numberOne = 3;
            int numberTwo = 5;
            Console.WriteLine("Случайно число: " + number);

            for (int i = 0; i <= number; i += numberOne)
            {
                sum += i;
                Console.WriteLine(i);
            }

            for (int n = 0; n <= number; n += numberTwo)
            {

                if (n % numberOne == 0)
                {
                    continue;
                }
                sum += n;
                Console.WriteLine(n);
            }
            Console.WriteLine("Сумма всех чисел: " + sum);

        }
    }
}

