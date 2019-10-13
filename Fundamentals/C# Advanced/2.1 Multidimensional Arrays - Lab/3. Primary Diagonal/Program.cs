namespace _3._Primary_Diagonal
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int dimentions = int.Parse(Console.ReadLine());
            var matrix = new int[dimentions, dimentions];

            for (int row = 0; row < dimentions; row++)
            {
                var cuurentRow = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                for (int col = 0; col < dimentions; col++)
                {
                    matrix[row, col] = cuurentRow[col];
                }
            }

            var sum = 0;
            for (int i = 0; i < dimentions; i++)
            {
                sum += matrix[i, i];
            }

            Console.WriteLine(sum);
        }
    }
}
