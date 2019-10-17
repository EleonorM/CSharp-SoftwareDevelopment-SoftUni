namespace _4._Matrix_shuffling
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
            var matrix = new string[rowsAndCols[0], rowsAndCols[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "END")
                {
                    break;
                }

                if (input.Length != 5 | input[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                }
                else if (input[0] == "swap")
                {
                    try
                    {
                        var xx = int.Parse(input[1]);
                        var xy = int.Parse(input[2]);
                        var yx = int.Parse(input[3]);
                        var yy = int.Parse(input[4]);

                        var currentString = matrix[xx, xy];
                        matrix[xx, xy] = matrix[yx, yy];
                        matrix[yx, yy] = currentString;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
            }
        }
    }
}
