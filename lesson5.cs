using System;

namespace ijunior
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Don";
            string surname = "Yagon";
            Console.WriteLine($"Переменные до изменения: Имя - {name}, Фамилия - {surname}");
            string reservd = name;
            name = surname;
            surname = reservd;
            Console.Write($"Переменные после изменения: Имя - {name}, Фамилия - {surname}");
        }
    }
}
