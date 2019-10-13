namespace _4._Symbol_in_Matrix
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int dimentions = int.Parse(Console.ReadLine());
            var matrix = new char[dimentions, dimentions];

            for (int row = 0; row < dimentions; row++)
            {
                var cuurentRow = Console.ReadLine()
                .ToCharArray();
                for (int col = 0; col < dimentions; col++)
                {
                    matrix[row, col] = cuurentRow[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isTrue = false;
            for (int row = 0; row < dimentions; row++)
            {
                for (int col = 0; col < dimentions; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isTrue = true;
                        return;
                    }
                }
            }

            if (isTrue == false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }
        }
    }
}
