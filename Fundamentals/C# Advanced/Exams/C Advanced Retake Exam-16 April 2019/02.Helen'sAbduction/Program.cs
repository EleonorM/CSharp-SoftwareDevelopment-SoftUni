namespace _02.Helen_sAbduction
{
    using System;

    public class Program
    {
        static void Main()
        {
            var parisEnergy = int.Parse(Console.ReadLine());
            var parisPlace = new int[2];
            var matrixSize = int.Parse(Console.ReadLine());
            var board = new char[matrixSize][];

            for (int row = 0; row < matrixSize; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                board[row] = new char[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    if (currentRow[col] == 'P')
                    {
                        parisPlace[0] = row;
                        parisPlace[1] = col;
                    }

                    board[row][col] = currentRow[col];
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                board[int.Parse(input[1])][int.Parse(input[2])] = 'S';
                board[parisPlace[0]][parisPlace[1]] = '-';

                if (input[0] == "up" && IsInside(board, parisPlace[0] - 1, parisPlace[1]))
                {
                    if (board[parisPlace[0] - 1][parisPlace[1]] == 'S')
                    {
                        parisEnergy -= 2;
                    }

                    parisPlace[0]--;
                }
                else if (input[0] == "down" && IsInside(board, parisPlace[0] + 1, parisPlace[1]))
                {
                    if (board[parisPlace[0] + 1][parisPlace[1]] == 'S')
                    {
                        parisEnergy -= 2;
                    }

                    parisPlace[0]++;
                }
                else if (input[0] == "left" && IsInside(board, parisPlace[0], parisPlace[1] - 1))
                {
                    if (board[parisPlace[0]][parisPlace[1] - 1] == 'S')
                    {
                        parisEnergy -= 2;
                    }

                    parisPlace[1]--;
                }
                else if (input[0] == "right" && IsInside(board, parisPlace[0], parisPlace[1] + 1))
                {
                    if (board[parisPlace[0]][parisPlace[1] + 1] == 'S')
                    {
                        parisEnergy -= 2;
                    }

                    parisPlace[1]++;
                }

                parisEnergy--;


                if (board[parisPlace[0]][parisPlace[1]] == 'H')
                {
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
                    board[parisPlace[0]][parisPlace[1]] = '-';
                    Print(board);
                    return;
                }
                else
                    board[parisPlace[0]][parisPlace[1]] = 'P';

                if (parisEnergy <= 0)
                {
                    Console.WriteLine($"Paris died at {parisPlace[0]};{parisPlace[1]}.");
                    board[parisPlace[0]][parisPlace[1]] = 'X';
                    Print(board);
                    return;
                }
            }
        }

        private static bool IsInside(char[][] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0
                && desiredCol < board[desiredRow].Length && desiredCol >= 0;
        }

        public static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
