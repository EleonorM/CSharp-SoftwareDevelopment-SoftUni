namespace _7._Knight_Game
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var board = new char[matrixSize, matrixSize];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }

            int counter = 0;

            while (true)
            {
                var maxCount = 0;
                var knightRow = 0;
                var knightCol = 0;

                for (int row = 0; row < matrixSize; row++)
                {
                    for (int col = 0; col < matrixSize; col++)
                    {
                        int currentCount = 0;

                        if (board[row, col] == 'K')
                        {
                            if (IsInside(board, row - 2, col + 1) && board[row - 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row - 2, col - 1) && board[row - 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row + 2, col + 1) && board[row + 2, col + 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row + 2, col - 1) && board[row + 2, col - 1] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row - 1, col - 2) && board[row - 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row + 1, col - 2) && board[row + 1, col - 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row - 1, col + 2) && board[row - 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }

                            if (IsInside(board, row + 1, col + 2) && board[row + 1, col + 2] == 'K')
                            {
                                currentCount++;
                            }
                        }

                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxCount == 0)
                {
                    break;
                }

                board[knightRow, knightCol] = '0';
                counter++;
            }

            Console.WriteLine(counter);
        }

        private static bool IsInside(char[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0
                && desiredCol < board.GetLongLength(1) && desiredCol >= 0;
        }
    }
}
