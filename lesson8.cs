using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            int repead;
            Console.Write("Введите сообщение: ");
            message = Console.ReadLine();
            Console.Write("Введите количество повторов: ");
            repead = Convert.ToInt32(Console.ReadLine());
            while (repead-- > 0)
            {
                Console.WriteLine(message);
            }
        }
    }
}
