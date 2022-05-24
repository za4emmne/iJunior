using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = 5;
            int[,] matrix = new int[sizeMatrix, sizeMatrix];
            Random random = new Random();
            int minRandom = 1;
            int maxRandom = 4;
            int sumRow = 0;
            int multiplicationColom = 1;
            int numberRow = 1;
            int numberColom = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(minRandom, maxRandom);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sumRow += matrix[numberRow, j];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                multiplicationColom *= matrix[i, numberColom];
            }
            Console.WriteLine("\nСумма элементов второй строки: " + sumRow);
            Console.WriteLine("\nПроизведение первого столбца: " + multiplicationColom);
        }
    }
}
