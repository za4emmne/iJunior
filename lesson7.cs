using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество старушек: ");
            int oldWomen = Convert.ToInt32(Console.ReadLine());
            int speedMove = 10;
            int minuteInHour = 60;
            int waitTime = oldWomen * speedMove;
            int waitHours = waitTime / minuteInHour;
            int waitMinute = waitTime % 60;
            Console.WriteLine($"Вы должны стоять в очереди {waitHours} часа {waitMinute} минут.");

        }
    }
}
