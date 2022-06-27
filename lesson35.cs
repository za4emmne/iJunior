using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int bank = 0;
            int randomMin = 100;
            int randomMax = 5000;
            Console.Write("Введите количество людей в очерееди: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            Queue<int> market = new Queue<int>(userInput);

            for (int i = 0; i < userInput; i++)
            {
                int buy = random.Next(randomMin, randomMax);
                market.Enqueue(buy);
            }
            Console.WriteLine("Денег в кассе - " + bank + " рублей\nНажмите любую клавишу чтобы начать обслуживать покупателей...");
            Console.ReadKey();

            foreach (var sumBuy in market)
            {
                Console.WriteLine("Сумма покупки - "+sumBuy+" рублей");
                bank += sumBuy;
                Console.WriteLine("Денег в кассе - "+bank+" рублей\nНажмите любую клавишу чтобы обслужить следующего покупателя...");
                Console.ReadKey();
                Console.Clear();
            }          
        }
    }
}
