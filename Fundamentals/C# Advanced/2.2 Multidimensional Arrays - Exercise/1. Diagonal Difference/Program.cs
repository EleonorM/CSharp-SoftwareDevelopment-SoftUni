namespace _1._Diagonal_Difference
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndCols = int.Parse(Console.ReadLine());
            var matrix = new int[rowsAndCols, rowsAndCols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var sumDiagonal1 = 0;
            var sumDiagonal2 = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sumDiagonal1 += matrix[row, col];
                    }
                    if (row + col == matrix.GetLength(1) - 1)
                    {
                        sumDiagonal2 += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(sumDiagonal1 - sumDiagonal2));
        }
    }
}
