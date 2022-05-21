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

           for (;repead>0;repead--)
            {
                Console.WriteLine(message);
            }
        }
    }
}
