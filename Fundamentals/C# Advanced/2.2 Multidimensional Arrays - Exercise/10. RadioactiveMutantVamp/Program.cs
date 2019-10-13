namespace _10._RadioactiveMutantVamp
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
            var matrix = new char[rowsAndCols[0], rowsAndCols[1]];
            var currentPlace = new int[] { 0, 0 };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'P')
                    {
                        currentPlace[0] = row;
                        currentPlace[1] = col;
                    }
                }
            }

            var actions = Console.ReadLine().ToCharArray();
            for (int i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                matrix[currentPlace[0], currentPlace[1]] = '.';
                matrix = BunniesMultiply(matrix);
                if (action == 'L' && currentPlace[1] - 1 >= 0)
                {
                    currentPlace[1] -= 1;
                }
                else if (action == 'R' && currentPlace[1] + 1 < matrix.GetLength(1))
                {
                    currentPlace[1] += 1;
                }
                else if (action == 'U' && currentPlace[0] - 1 >= 0)
                {
                    currentPlace[0] -= 1;
                }
                else if (action == 'D' && currentPlace[0] + 1 < matrix.GetLength(0))
                {
                    currentPlace[0] += 1;
                }
                else
                {
                    Print(matrix);
                    Console.WriteLine($"won: {currentPlace[0]} {currentPlace[1]}");
                    return;
                }

                if (matrix[currentPlace[0], currentPlace[1]] != 'B')
                {
                    matrix[currentPlace[0], currentPlace[1]] = 'P';
                }
                else
                {
                    Print(matrix);
                    Console.WriteLine($"dead: {currentPlace[0]} {currentPlace[1]}");
                    return;
                }
            }
        }

        private static char[,] BunniesMultiply(char[,] matrix)
        {
            var resutMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
            Array.Copy(matrix, resutMatrix, matrix.GetLength(0) * matrix.GetLength(1));
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (IsInside(matrix, row - 1, col))
                        {
                            resutMatrix[row - 1, col] = 'B';
                        }

                        if (IsInside(matrix, row + 1, col))
                        {
                            resutMatrix[row + 1, col] = 'B';
                        }

                        if (IsInside(matrix, row, col + 1))
                        {
                            resutMatrix[row, col + 1] = 'B';
                        }

                        if (IsInside(matrix, row, col - 1))
                        {
                            resutMatrix[row, col - 1] = 'B';
                        }
                    }
                }
            }

            return resutMatrix;
        }

        private static bool IsInside(char[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0
                && desiredCol < board.GetLongLength(1) && desiredCol >= 0;
        }

        public static void Print(char[,] matrix)
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
