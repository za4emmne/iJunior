using System;

namespace ijunior
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество золота: ");
            int gold = Convert.ToInt32(Console.ReadLine());
            int priceCrystal = 10;
            Console.Write($"Кристалы стоят {priceCrystal} золотых.\nСколько кристаллов вы хотите купить? ");
            int buyCristal = Convert.ToInt32(Console.ReadLine());
            gold -= priceCrystal * buyCristal;
            Console.WriteLine($"У Вас осталось {gold} золота\nВы купили {buyCristal} кристалов");
        }
    }
}
