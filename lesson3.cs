using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Здравствуйте, как Вас зовут? ");
            string name = Console.ReadLine();
            Console.Write("Сколько Вам лет? ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("В каком городе вы родились? ");
            string city = Console.ReadLine();
            Console.Write("На какой машине вы ездиете? ");
            string car = Console.ReadLine();
            Console.WriteLine($"Вас зовут {name}, Ваш возраст {age} лет, Вы из города {city}, и издитете на машине {car}.\n Мы знаем о Вас все.\n Сдавайтесь...");
        }
    }
}
