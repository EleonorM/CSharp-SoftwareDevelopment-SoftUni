namespace _07._Paths_in_Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static char[,] field;
        private static int exitRow;
        private static int exitCol;
        private static int startRow = 0;
        private static int startCol = 0;
        private static List<char> path = new List<char>();


        private static void ReadInput()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            field = new char[rows, cols];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                    if (input[col] == 'e')
                    {
                        exitRow = row;
                        exitCol = col;
                    }
                }
            }
        }

        private static void FindPath(int row, int col, char direction)
        {
            if (!IsInside(row, col))
            {
                return;
            }
            path.Add(direction);
            if (IsExit(row, col))
            {
                PrintSolution();
            }
            else if (IsPassable(row, col))
            {
                field[row, col] = 'x';

                FindPath(row + 1, col, 'D');
                FindPath(row - 1, col, 'U');
                FindPath(row, col + 1, 'R');
                FindPath(row, col - 1, 'L');

                field[row, col] = '-';
            }

            path.RemoveAt(path.Count - 1);
        }

        private static bool IsPassable(int row, int col)
        {
            if (field[row, col] == 'x')
            {
                return false;
            }
            if (field[row, col] == '*')
            {
                return false;
            }

            return true;
        }

        private static void PrintSolution()
        {
            Console.WriteLine(string.Concat(path.Skip(1).ToArray()));
        }

        private static bool IsExit(int row, int col)
        {
            return field[row, col] == 'e';
        }

        private static bool IsInside(int desiredRow, int desiredCol)
        {
            return desiredRow < field.GetLength(0) && desiredRow >= 0
                && desiredCol < field.GetLength(1) && desiredCol >= 0;
        }

        public static void Main()
        {
            ReadInput();
            FindPath(startRow, startCol, 'S');
        }

    }
}
