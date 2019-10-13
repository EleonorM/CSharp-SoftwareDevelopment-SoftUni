namespace _06._8_Queens_Puzzle
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        private static char[,] field;
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();

        public static void PutQueens(int row)
        {
            if (row == field.GetLength(0))
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkAllPositions(int row, int col)
        {
            field[row, col] = '-';
            attackedRows.Remove(row);
            attackedCols.Remove(col);
        }

        private static void MarkAllPositions(int row, int col)
        {
            field[row, col] = '*';
            attackedRows.Add(row);
            attackedCols.Add(col);
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            if (attackedRows.Contains(row))
            {
                return false;
            }

            if (attackedCols.Contains(col))
            {
                return false;
            }

            //left-up diagonal
            for (int i = 1; i < field.GetLength(1); i++)
            {
                var currentRow = row - i;
                var currentCol = col - i;
                if (!IsInside(currentRow, currentCol))
                {
                    break;
                }

                if (field[currentRow, currentCol] == '*')
                {
                    return false;
                }
            }

            //right-up diagonal
            for (int i = 1; i < field.GetLength(1); i++)
            {
                var currentRow = row - i;
                var currentCol = col + i;
                if (!IsInside(currentRow, currentCol))
                {
                    break;
                }

                if (field[currentRow, currentCol] == '*')
                {
                    return false;
                }
            }

            //left-down diagonal
            for (int i = 1; i < field.GetLength(1); i++)
            {
                var currentRow = row + i;
                var currentCol = col - i;
                if (!IsInside(currentRow, currentCol))
                {
                    break;
                }

                if (field[currentRow, currentCol] == '*')
                {
                    return false;
                }
            }

            //right-down diagonal
            for (int i = 1; i < field.GetLength(1); i++)
            {
                var currentRow = row + i;
                var currentCol = col + i;
                if (!IsInside(currentRow, currentCol))
                {
                    break;
                }

                if (field[currentRow, currentCol] == '*')
                {
                    return false;
                }
            }

            return true;

        }

        private static bool IsInside(int desiredRow, int desiredCol)
        {
            return desiredRow < field.GetLength(0) && desiredRow >= 0
                && desiredCol < field.GetLength(1) && desiredCol >= 0;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ReadInput();
            PutQueens(0);
        }

        private static void ReadInput()
        {
            var rowsAndCols = 8;
            field = new char[rowsAndCols, rowsAndCols];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = '-';
                }
            }
        }
    }
}
