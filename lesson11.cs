using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            int sum = 0;
            Console.WriteLine("Случайно число: " + number);

            for (int i = 0; i < number; i += 3)
            {
                sum += i;
                Console.WriteLine(i);
            }

            for (int n = 0; n < number; n += 5)
            {
                sum += n;
                Console.WriteLine(n);
            }
            Console.WriteLine("Сумма всех чисел: " + (sum + number));

        }
    }
}
