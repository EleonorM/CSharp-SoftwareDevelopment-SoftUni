namespace _1._Sum_Matrix_Elements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var dimentions = Console.ReadLine()
                .Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimentions[0];
            int cols = dimentions[1];

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var cuurentRow = Console.ReadLine()
                .Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = cuurentRow[col];
                }
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
