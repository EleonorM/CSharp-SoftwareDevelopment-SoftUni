namespace _06.PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var matrix = new Matrix(rows, cols);
            var startPosition = new int[2];

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 's')
                    {
                        startPosition[0] = row;
                        startPosition[1] = col;
                    }
                }
            }

            var results = matrix.Move(startPosition[0], startPosition[1]);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }

        }

    }
}
