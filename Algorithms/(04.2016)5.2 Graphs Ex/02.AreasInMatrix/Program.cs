namespace _02.AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static char[,] matrix;

        private static Dictionary<char, int> areas;

        private static bool[,] visitedMatrix;

        public static void Main()
        {
            ReadInput();
            MarkAllCellsAsUnvisited();
            areas = new Dictionary<char, int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!visitedMatrix[row, col])
                    {

                        var currentSymbol = matrix[row, col];

                        FindArea(row, col, currentSymbol);
                        if (!areas.ContainsKey(currentSymbol))
                        {
                            areas.Add(currentSymbol, 0);
                        }

                        areas[currentSymbol]++;
                    }
                }
            }

            PrintSolution();
        }

        private static void PrintSolution()
        {
            Console.WriteLine(areas.Values.Sum());
            foreach (var area in areas.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void FindArea(int row, int col, char currentSymbol)
        {
            if (!IsValidPosition(row, col) || visitedMatrix[row, col] || matrix[row, col] != currentSymbol)
            {
                return;
            }

            visitedMatrix[row, col] = true;

            FindArea(row - 1, col, currentSymbol);
            FindArea(row, col - 1, currentSymbol);
            FindArea(row + 1, col, currentSymbol);
            FindArea(row, col + 1, currentSymbol);
        }

        private static bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }

        private static void MarkAllCellsAsUnvisited()
        {
            visitedMatrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int row = 0; row < visitedMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < visitedMatrix.GetLength(1); col++)
                {
                    visitedMatrix[row, col] = false;
                }
            }
        }

        private static void ReadInput()
        {
            var rows = int.Parse(Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries)[1]);
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console.ReadLine().ToCharArray();
                if (row == 0)
                {
                    matrix = new char[rows, rowInput.Length];
                }

                for (int col = 0; col < rowInput.Length; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
        }
    }
}
