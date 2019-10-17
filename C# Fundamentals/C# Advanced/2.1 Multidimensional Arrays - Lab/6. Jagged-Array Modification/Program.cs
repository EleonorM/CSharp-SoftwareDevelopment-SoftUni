namespace _6._Jagged_Array_Modification
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            var jaggedMatrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jaggedMatrix[row] = new int[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    jaggedMatrix[row][col] = currentRow[col];
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split();

                var commandOperator = input[0];
                if (commandOperator.ToLower() == "end")
                {
                    break;
                }

                var commandRow = int.Parse(input[1]);
                var commandCol = int.Parse(input[2]);
                var value = int.Parse(input[3]);

                if (commandRow < 0 || commandRow >= jaggedMatrix.Length || commandCol < 0 || commandCol >= jaggedMatrix[commandRow].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else if (commandOperator.ToLower() == "add")
                {
                    jaggedMatrix[commandRow][commandCol] += value;
                }
                else if (commandOperator.ToLower() == "subtract")
                {
                    jaggedMatrix[commandRow][commandCol] -= value;
                }
            }

            foreach (var item in jaggedMatrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
}
