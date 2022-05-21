using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string message;
            string exit = "exit";
            bool isExit = false;
            int itteration = 1;
            Console.WriteLine("Запустился счетчик иттераций");

            while (isExit == false)
            { 
                Console.Write("Нажмините любую клавишу чтобы продолжить, либо введите "+ exit +", чтобы выйти: ");
                message = Console.ReadLine();
                Console.WriteLine(itteration++);
                if (message == exit)
                {
                    isExit = true;
                }
            }
        }
    }
}
