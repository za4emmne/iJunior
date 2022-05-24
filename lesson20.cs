using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            Random random = new Random();
            int maxValue = 0;
            int minValue = 0;
            int topMatrix = 100;
            int downMatrix = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(downMatrix, topMatrix);
                    Console.Write(matrix[i, j] + "  ");

                    if (matrix[i, j] > maxValue)
                    {
                        maxValue = matrix[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nМаксимальный элемент матрицы: " + maxValue + "\n");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    if (matrix[i, j] == maxValue)
                    {
                        matrix[i, j] = minValue;
                    }
                    Console.Write(matrix[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
