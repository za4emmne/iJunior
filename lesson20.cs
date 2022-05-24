using System;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] A = new int[10, 10];
            Random random = new Random();
            int maxValue = 0;
            int minValue = 0;
            int topMatrix = 100;
            int downMatrix = 0;

            for (int i = 0; i < A.GetLength(0); i++)
            {

                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = random.Next(downMatrix, topMatrix);
                    Console.Write(A[i, j] + "  ");

                    if (A[i, j] > maxValue)
                    {
                        maxValue = A[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nМаксимальный элемент матрицы: " + maxValue + "\n");

            for (int i = 0; i < A.GetLength(0); i++)
            {

                for (int j = 0; j < A.GetLength(1); j++)
                {

                    if (A[i, j] == maxValue)
                    {
                        A[i, j] = minValue;
                    }
                    Console.Write(A[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
