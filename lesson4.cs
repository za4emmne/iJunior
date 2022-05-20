using System;

namespace ijunior
{
    class Program
    {
        static void Main(string[] args)
        {
            int picture = 52; 
            int pictureInRow = 3;
            int rowWithPicture = picture / pictureInRow; 
            int alonePicture = picture - rowWithPicture * pictureInRow; 
            Console.WriteLine($"Общее число картинок: {picture}\nЧисло картинок в одном ряду: {pictureInRow}\n" +
                $"Количество полностью заполенных рядов: {rowWithPicture}\nКартинки сверх меры: {alonePicture}");
        }
    }
}
