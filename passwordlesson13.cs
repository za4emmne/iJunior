using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "loop2";
            string userInput;
            int currentInput = 3;
            int currentAttempt;

            for (int i = 0; i<currentInput; i++)
            {
                Console.Write("Введите пароль: ");
                userInput = Console.ReadLine();

                if (userInput == password)
                {
                    Console.WriteLine("Вы открыли доступ к секретной информации: убийца - САДОВНИК");
                    break;
                }
                else 
                {
                    currentAttempt = currentInput - i - 1;
                    Console.WriteLine("Пароль неверный! Осталось " + currentAttempt + " попыток.");
                }
            }           
        }
    }
}
