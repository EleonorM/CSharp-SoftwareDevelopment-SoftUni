namespace _8._Bombs
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndCols = int.Parse(Console.ReadLine());
            var field = new int[rowsAndCols, rowsAndCols];

            for (int row = 0; row < field.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                }
            }

            var coordinatesArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < coordinatesArray.Length; i++)
            {
                var coordinates = coordinatesArray[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var bombRow = coordinates[0];
                var bombCol = coordinates[1];
                if (field[bombRow, bombCol] > 0)
                {
                    field = BombExplosion(field, bombRow, bombCol);
                }
            }

            Console.WriteLine($"Alive cells: {FindAliveCells(field)}");
            Console.WriteLine($"Sum: {field.Cast<int>().Where(x => x > 0).Sum()}");
            Print(field);
        }

        private static int[,] BombExplosion(int[,] matrix, int bombRow, int bombCol)
        {
            var number = matrix[bombRow, bombCol];

            for (int row = bombRow - 1; row <= bombRow + 1; row++)
            {
                for (int col = bombCol - 1; col <= bombCol + 1; col++)
                {
                    if (IsInside(matrix, row, col) && matrix[row, col] > 0)
                    {
                        matrix[row, col] -= number;
                    }
                }
            }

            return matrix;
        }

        private static int FindAliveCells(int[,] matrix)
        {
            var aliveCells = matrix.GetLength(0) * matrix.GetLength(1);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] <= 0)
                    {
                        aliveCells--;
                    }
                }
            }

            return aliveCells;
        }

        private static bool IsInside(int[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0
                && desiredCol < board.GetLongLength(1) && desiredCol >= 0;
        }

        public static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
