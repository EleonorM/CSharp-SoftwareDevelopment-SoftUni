namespace _02._Excel_Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var headerRow = Console.ReadLine()
                .Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var table = new string[rows, headerRow.Length];

            AddHeader(headerRow, table);
            for (int i = 1; i <= rows - 1; i++)
            {
                var input = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < headerRow.Length; col++)
                {
                    table[i, col] = input[col];
                }
            }

            var action = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (action[0].ToLower() == "hide")
            {
                DeleteColumn(table, action[1]);
                table = RefactorTable(table);
            }
            else if (action[0].ToLower() == "sort")
            {
                table = SortRows(table, action[1]);
                AddHeader(headerRow, table);
            }
            else if (action[0].ToLower() == "filter")
            {
                table = Filter(table, action[1], action[2]);
                AddHeader(headerRow, table);
            }

            PrintTable(table);
        }

        private static string[,] Filter(string[,] table, string header, string value)
        {
            var column = 0;

            for (int i = 0; i < table.GetLength(1); i++)
            {
                if (table[0, i] == header)
                {
                    column = i;
                    break;
                }
            }

            var componentsCount = 0;
            for (int i = 1; i < table.GetLength(0); i++)
            {
                if (table[i, column] == value)
                {
                    componentsCount++;
                }
            }

            var newTable = new string[componentsCount + 1, table.GetLength(1)];
            var rowNewTable = 1;
            for (int row = 1; row < table.GetLength(0); row++)
            {
                if (table[row, column] == value)
                {
                    var colNewTable = 0;
                    for (int col = 0; col < table.GetLength(1); col++)
                    {
                        newTable[rowNewTable, colNewTable] = table[row, col];
                        colNewTable++;
                    }

                    rowNewTable++;
                }
            }

            return newTable;
        }

        private static string[,] SortRows(string[,] table, string header)
        {
            var components = new List<string>();
            var column = 0;
            var newTable = new string[table.GetLength(0), table.GetLength(1)];

            for (int i = 0; i < table.GetLength(1); i++)
            {
                if (table[0, i] == header)
                {
                    column = i;
                    break;
                }
            }

            for (int i = 1; i < table.GetLength(0); i++)
            {
                components.Add(table[i, column]);
            }

            components = components.OrderBy(x => x).ToList();
            var rowNewTable = 1;

            for (int i = 0; i < components.Count; i++)
            {
                for (int row = 1; row < table.GetLength(0); row++)
                {
                    if (table[row, column] == components[i])
                    {
                        var colNewTable = 0;
                        for (int col = 0; col < table.GetLength(1); col++)
                        {
                            newTable[rowNewTable, colNewTable] = table[row, col];
                            colNewTable++;

                        }

                        rowNewTable++;
                    }
                }
            }

            return newTable;
        }

        private static string[,] RefactorTable(string[,] table)
        {
            var newTable = new string[table.GetLength(0), table.GetLength(1) - 1];
            var isNull = false;
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (table[row, col] != null && isNull == false)
                    {
                        newTable[row, col] = table[row, col];
                    }
                    else if (table[row, col] == null)
                    {
                        isNull = true;
                    }
                    else
                    {
                        newTable[row, col - 1] = table[row, col];
                    }
                }

                isNull = false;
            }

            return newTable;
        }

        private static void AddHeader(string[] headerRow, string[,] table)
        {
            for (int i = 0; i < headerRow.Length; i++)
            {
                table[0, i] = headerRow[i];
            }
        }

        private static void DeleteColumn(string[,] table, string header)
        {
            var column = 0;
            for (int i = 0; i < table.GetLength(1); i++)
            {
                if (table[0, i] == header)
                {
                    column = i;
                    break;
                }
            }

            for (int col = 0; col < table.GetLength(0); col++)
            {
                table[col, column] = null;
            }
        }

        private static void PrintTable(string[,] table)
        {
            for (int row = 0; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (col == table.GetLength(1) - 1)
                    {
                        Console.Write(table[row, col]);
                    }
                    else
                        Console.Write(table[row, col] + " | ");
                }

                Console.WriteLine();
            }
        }
    }
}
