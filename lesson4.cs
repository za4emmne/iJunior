using System;

namespace ijunior
{
    class Program
    {
        static void Main(string[] args)
        {
            int picture = 52; //общее число картинок
            int picInRow = 3; //число картинок в одном ряду
            int row = picture / picInRow; //вычисляем количество заполненных рядов
            int picWithot = picture - row * picInRow; //вычисляем количество оставшихся картинок
            Console.WriteLine($"Общее число картинок: {picture}\n Число картинок в одном ряду: {picInRow}\n" +
                $" Количество полностью заполенных рядов: {row}\n Картинки сверх меры: {picWithot}");
        }
    }
}
