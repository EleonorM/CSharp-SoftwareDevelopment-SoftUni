namespace _06.MinimumEditDistance
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var costReplace = int.Parse(Console.ReadLine().Split(" ")[2]);
            var costInsert = int.Parse(Console.ReadLine().Split(" ")[2]);
            var costDelete = int.Parse(Console.ReadLine().Split(" ")[2]);

            var firstString = Console.ReadLine().Split("=")[1].Trim();
            var secondString = Console.ReadLine().Split("=")[1].Trim();

            var matrix = new int[firstString.Length + 1, secondString.Length + 1];

            for (int i = 1; i <= secondString.Length; i++)
            {
                matrix[0, i] = matrix[0, i - 1] + costInsert;
            }

            for (int i = 1; i <= firstString.Length; i++)
            {
                matrix[i, 0] = matrix[i - 1, 0] + costDelete;
            }

            for (int row = 1; row <= firstString.Length; row++)
            {
                for (int col = 1; col <= secondString.Length; col++)
                {
                    if (firstString[row - 1] == secondString[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        var costDeleting = matrix[row - 1, col] + costDelete;
                        var costInserting = matrix[row, col - 1] + costInsert;
                        var costReplacing = matrix[row - 1, col - 1] + costReplace;

                        matrix[row, col] = Math.Min(costDeleting, Math.Min(costReplacing, costInserting));
                    }
                }
            }

            Console.WriteLine(matrix[firstString.Length, secondString.Length]);
        }
    }
}
