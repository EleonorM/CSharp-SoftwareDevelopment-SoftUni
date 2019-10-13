namespace _02.TronRacers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var board = new char[matrixSize, matrixSize];
            var firstPlayerPosition = new int[2];
            var secondPlayerPosition = new int[2];

            for (int row = 0; row < board.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                    if (input[col] == 'f')
                    {
                        firstPlayerPosition[0] = row;
                        firstPlayerPosition[1] = col;
                    }
                    else if (input[col] == 's')
                    {
                        secondPlayerPosition[0] = row;
                        secondPlayerPosition[1] = col;
                    }
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "up")
                {
                    var movedPosition = MoveUp(board, firstPlayerPosition);
                    if (board[movedPosition[0], movedPosition[1]] != '*')
                    {
                        board[movedPosition[0], movedPosition[1]] = 'x';
                        break;
                    }
                    board[movedPosition[0], movedPosition[1]] = 'f';
                    firstPlayerPosition = movedPosition;
                }
                else if (input[0] == "down")
                {
                    var movedPosition = MoveDown(board, firstPlayerPosition);
                    if (board[movedPosition[0], movedPosition[1]] != '*')
                    {
                        board[movedPosition[0], movedPosition[1]] = 'x';
                        break;
                    }

                    board[movedPosition[0], movedPosition[1]] = 'f';
                    firstPlayerPosition = movedPosition;
                }
                else if (input[0] == "left")
                {
                    var movedPosition = MoveLeft(board, firstPlayerPosition);
                    if (board[movedPosition[0], movedPosition[1]] != '*')
                    {
                        board[movedPosition[0], movedPosition[1]] = 'x';
                        break;
                    }

                    board[movedPosition[0], movedPosition[1]] = 'f';
                    firstPlayerPosition = movedPosition;
                }
                else if (input[0] == "right")
                {
                    var movedPosition = MoveRight(board, firstPlayerPosition);
                    if (board[movedPosition[0], movedPosition[1]] != '*')
                    {
                        board[movedPosition[0], movedPosition[1]] = 'x';
                        break;
                    }

                    board[movedPosition[0], movedPosition[1]] = 'f';
                    firstPlayerPosition = movedPosition;
                }


                if (input[1] == "up")
                {
                    var movedPosition = MoveUp(board, secondPlayerPosition);
                    if (board[movedPosition[0], movedPosition[1]] != '*')
                    {
                        board[movedPosition[0], movedPosition[1]] = 'x';
                        break;
                    }

                    board[movedPosition[0], movedPosition[1]] = 's';
                    secondPlayerPosition = movedPosition;
                }
                else if (input[1] == "down")
                {
                    var movedPosition = MoveDown(board, secondPlayerPosition);
                    if (board[movedPosition[0], movedPosition[1]] != '*')
                    {
                        board[movedPosition[0], movedPosition[1]] = 'x';
                        break;
                    }

                    board[movedPosition[0], movedPosition[1]] = 's';
                    secondPlayerPosition = movedPosition;
                }
                else if (input[1] == "left")
                {
                    var movedPosition = MoveLeft(board, secondPlayerPosition);
                    if (board[movedPosition[0], movedPosition[1]] != '*')
                    {
                        board[movedPosition[0], movedPosition[1]] = 'x';
                        break;
                    }

                    board[movedPosition[0], movedPosition[1]] = 's';
                    secondPlayerPosition = movedPosition;
                }
                else if (input[1] == "right")
                {
                    var movedPosition = MoveRight(board, secondPlayerPosition);
                    if (board[movedPosition[0], movedPosition[1]] != '*')
                    {
                        board[movedPosition[0], movedPosition[1]] = 'x';
                        break;
                    }

                    board[movedPosition[0], movedPosition[1]] = 's';
                    secondPlayerPosition = movedPosition;
                }
            }

            Print(board);
        }

        public static int[] MoveUp(char[,] matrix, int[] position)
        {
            var movedPosition = position;

            if (movedPosition[0] == 0)
            {
                movedPosition[0] = matrix.GetLength(0) - 1;
            }
            else
            {
                movedPosition[0]--;
            }

            return movedPosition;
        }

        public static int[] MoveDown(char[,] matrix, int[] position)
        {
            var movedPosition = position;

            if (movedPosition[0] == matrix.GetLength(0) - 1)
            {
                movedPosition[0] = 0;
            }
            else
            {
                movedPosition[0]++;
            }

            return movedPosition;
        }

        public static int[] MoveLeft(char[,] matrix, int[] position)
        {
            var movedPosition = position;

            if (movedPosition[1] == 0)
            {
                movedPosition[1] = matrix.GetLength(1) - 1;
            }
            else
            {
                movedPosition[1]--;
            }

            return movedPosition;
        }

        public static int[] MoveRight(char[,] matrix, int[] position)
        {
            var movedPosition = position;

            if (movedPosition[1] == matrix.GetLength(1) - 1)
            {
                movedPosition[1] = 0;
            }
            else
            {
                movedPosition[1]++;
            }

            return movedPosition;
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
