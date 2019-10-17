namespace _03._Space_Station_Establishment
{
    using System;

    public class StartUp
    {
        public static int[] spaseshipPosition = new int[2];

        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var board = new char[matrixSize, matrixSize];
            var starPower = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrixSize; col++)
                {
                    if (currentRow[col] == 'S')
                    {
                        spaseshipPosition[0] = row;
                        spaseshipPosition[1] = col;
                    }

                    board[row, col] = currentRow[col];
                }
            }

            while (starPower < 50)
            {
                var input = Console.ReadLine();
                board[spaseshipPosition[0], spaseshipPosition[1]] = '-';
                if (input == "left" && IsInside(board, spaseshipPosition[0], spaseshipPosition[1] - 1))
                {
                    if (board[spaseshipPosition[0], spaseshipPosition[1] - 1] == 'O')
                    {
                        spaseshipPosition = BlackHoleMovement(board, spaseshipPosition[0], spaseshipPosition[1] - 1);
                    }
                    else if (board[spaseshipPosition[0], spaseshipPosition[1] - 1] != '-')
                    {
                        starPower += (int)(board[spaseshipPosition[0], spaseshipPosition[1] - 1] - '0');
                        spaseshipPosition[1]--;
                    }
                    else
                        spaseshipPosition[1]--;

                    board[spaseshipPosition[0], spaseshipPosition[1]] = 'S';
                }
                else if (input == "right" && IsInside(board, spaseshipPosition[0], spaseshipPosition[1] + 1))
                {
                    if (board[spaseshipPosition[0], spaseshipPosition[1] + 1] == 'O')
                    {
                        spaseshipPosition = BlackHoleMovement(board, spaseshipPosition[0], spaseshipPosition[1] + 1);
                    }
                    else if (board[spaseshipPosition[0], spaseshipPosition[1] + 1] != '-')
                    {
                        starPower += (int)(board[spaseshipPosition[0], spaseshipPosition[1] + 1] - '0');
                        spaseshipPosition[1]++;
                    }
                    else
                        spaseshipPosition[1]++;

                    board[spaseshipPosition[0], spaseshipPosition[1]] = 'S';
                }
                else if (input == "down" && IsInside(board, spaseshipPosition[0] + 1, spaseshipPosition[1]))
                {
                    if (board[spaseshipPosition[0] + 1, spaseshipPosition[1]] == 'O')
                    {
                        spaseshipPosition = BlackHoleMovement(board, spaseshipPosition[0] + 1, spaseshipPosition[1]);
                    }
                    else if (board[spaseshipPosition[0] + 1, spaseshipPosition[1]] != '-')
                    {
                        starPower += (int)(board[spaseshipPosition[0] + 1, spaseshipPosition[1]] - '0');
                        spaseshipPosition[0]++;
                    }
                    else
                        spaseshipPosition[0]++;

                    board[spaseshipPosition[0], spaseshipPosition[1]] = 'S';
                }
                else if (input == "up" && IsInside(board, spaseshipPosition[0] - 1, spaseshipPosition[1]))
                {
                    if (board[spaseshipPosition[0] - 1, spaseshipPosition[1]] == 'O')
                    {
                        spaseshipPosition = BlackHoleMovement(board, spaseshipPosition[0] - 1, spaseshipPosition[1]);
                    }
                    else if (board[spaseshipPosition[0] - 1, spaseshipPosition[1]] != '-')
                    {
                        starPower += (int)(board[spaseshipPosition[0] - 1, spaseshipPosition[1]] - '0');
                        spaseshipPosition[0]--;
                    }
                    else
                        spaseshipPosition[0]--;

                    board[spaseshipPosition[0], spaseshipPosition[1]] = 'S';
                }
                else
                {
                    Console.WriteLine("Bad news, the spaceship went to the void.");
                    Console.WriteLine($"Star power collected: {starPower}");
                    Print(board);
                    return;
                }
            }

            Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
            Console.WriteLine($"Star power collected: {starPower}");
            Print(board);
        }

        private static int[] BlackHoleMovement(char[,] board, int v1, int v2)
        {
            var position = new int[2];
            board[v1, v2] = '-';
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 'O')
                    {
                        board[row, col] = 'S';
                        position[0] = row;
                        position[1] = col;
                        return position;
                    }
                }
            }

            return spaseshipPosition;
        }

        private static bool IsInside(char[,] board, int desiredRow, int desiredCol)
        {
            return desiredRow < board.GetLength(0) && desiredRow >= 0
                && desiredCol < board.GetLength(1) && desiredCol >= 0;
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
