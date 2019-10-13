namespace _6._Bomb_Basement
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = new int[dimentions[0], dimentions[1]];
            var bombDimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var bombRow = bombDimentions[0];
            var bombCol = bombDimentions[1];
            var bombRadius = bombDimentions[2];


            matrix[bombRow, bombCol] = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var scope = bombRadius - Math.Abs(bombRow - row);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    try
                    {
                        if (Math.Abs(col - bombCol) <= scope)
                        {
                            matrix[row, col] = 1;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                var counter = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    try
                    {
                        if (matrix[row, col] == 1)
                        {
                            matrix[row, col] = 0;
                            matrix[counter, col] = 1;
                            counter++;
                        }
                    }
                    catch
                    {
                    }
                }
            }

            Print(matrix);
        }

        public static void Print(int[,] matrix)
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
