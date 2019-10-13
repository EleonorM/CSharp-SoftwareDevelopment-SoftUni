namespace _07._Distance_in_Labyrinth
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new string[matrixSize, matrixSize];
            int startRow = 0;
            int startCol = 0;
            var counter = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                string[] currentRow = Console.ReadLine().Select(x => x.ToString()).ToArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    if (currentRow[col] == "*")
                    {
                        startRow = row;
                        startCol = col;
                    }
                    matrix[row, col] = currentRow[col];
                }
            }

            FillPositions(ref matrix, startRow, startCol, counter);
            counter++;

            while (true)
            {
                bool toContiniue = false;
                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        if (matrix[row, col] == counter.ToString())
                        {
                            FillPositions(ref matrix, row, col, counter);
                            toContiniue = true;
                        }
                    }
                }
                counter++;
                if (toContiniue == false)
                {
                    break;
                }
            }

            FillUnreachablePositions(matrix);
            Print(matrix);
        }

        private static void FillPositions(ref string[,] matrix, int startRow, int startCol, int counter)
        {
            counter++;
            if (IsInside(matrix, startRow, startCol - 1) && matrix[startRow, startCol - 1] == "0")
            {
                matrix[startRow, startCol - 1] = counter.ToString();
            }

            if (IsInside(matrix, startRow, startCol + 1) && matrix[startRow, startCol + 1] == "0")
            {
                matrix[startRow, startCol + 1] = counter.ToString();
            }

            if (IsInside(matrix, startRow - 1, startCol) && matrix[startRow - 1, startCol] == "0")
            {
                matrix[startRow - 1, startCol] = counter.ToString();
            }

            if (IsInside(matrix, startRow + 1, startCol) && matrix[startRow + 1, startCol] == "0")
            {
                matrix[startRow + 1, startCol] = counter.ToString();
            }
        }

        private static void FillUnreachablePositions(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == "0")
                    {
                        matrix[row, col] = "u";
                    }
                }
            }
        }

        private static bool IsInside(string[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0
                && desiredCol < board.GetLongLength(1) && desiredCol >= 0;
        }

        public static void Print(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
