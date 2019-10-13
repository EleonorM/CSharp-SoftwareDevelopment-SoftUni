namespace _3._Maximal_Sum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndCols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            var matrix = new int[rowsAndCols[0], rowsAndCols[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var maxSum = int.MinValue;
            var index = new int[2];
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        index[0] = row;
                        index[1] = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(matrix[index[0] + row, index[1] + col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
