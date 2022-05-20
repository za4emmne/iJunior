using System;

namespace ijunior
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество старушек: ");
            int oldWomen = Convert.ToInt32(Console.ReadLine());
            int speedMove = 10;
            int waitingTimeHours = oldWomen * speedMove / 60;
            int waitingTimeMinutes = oldWomen * speedMove - waitingTimeHours*60;
            Console.WriteLine($"Вы должны ждать в очереди {waitingTimeHours} часов, {waitingTimeMinutes} минут. Удачи...");
        }
    }
}
