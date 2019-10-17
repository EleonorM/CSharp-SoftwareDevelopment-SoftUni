namespace _01.TheGarden
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            var harvest = new Dictionary<char, int>();
            harvest.Add('L', 0);
            harvest.Add('P', 0);
            harvest.Add('C', 0);
            harvest.Add('H', 0);

            var jaggedMatrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                jaggedMatrix[row] = new char[currentRow.Length];
                for (int col = 0; col < currentRow.Length; col++)
                {
                    jaggedMatrix[row][col] = currentRow[col];
                }
            }

            while (true)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "End")
                {
                    break;
                }

                var row = int.Parse(input[1]);
                var col = int.Parse(input[2]);
                if (input[0] == "Harvest")
                {

                    try
                    {
                        if (jaggedMatrix[row][col] != ' ')
                        {
                            harvest[jaggedMatrix[row][col]]++;
                            jaggedMatrix[row][col] = ' ';
                        }
                    }
                    catch
                    {
                    }
                }
                else if (input[0] == "Mole")
                {
                    if (input[3] == "up")
                    {
                        try
                        {
                            for (int i = row; i >= 0; i -= 2)
                            {
                                if (jaggedMatrix[i][col] != ' ')
                                {
                                    harvest['H']++;
                                    jaggedMatrix[i][col] = ' ';
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    else if (input[3] == "down")
                    {
                        try
                        {
                            for (int i = row; i <= jaggedMatrix.Length; i += 2)
                            {
                                if (jaggedMatrix[i][col] != ' ')
                                {
                                    harvest['H']++;
                                    jaggedMatrix[i][col] = ' ';
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    else if (input[3] == "right")
                    {
                        try
                        {
                            for (int i = col; i <= jaggedMatrix[row].Length; i += 2)
                            {
                                if (jaggedMatrix[row][i] != ' ')
                                {
                                    harvest['H']++;
                                    jaggedMatrix[row][i] = ' ';
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    else if (input[3] == "left")
                    {
                        try
                        {
                            for (int i = col; i >= 0; i -= 2)
                            {
                                if (jaggedMatrix[row][i] != ' ')
                                {
                                    harvest['H']++;
                                    jaggedMatrix[row][i] = ' ';
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }

            foreach (var item in jaggedMatrix)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine($"Carrots: {harvest['C']}");
            Console.WriteLine($"Potatoes: {harvest['P']}");
            Console.WriteLine($"Lettuce: {harvest['L']}");
            Console.WriteLine($"Harmed vegetables: {harvest['H']}");
        }
    }
}
