namespace _9._Miner
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var rowsAndCols = int.Parse(Console.ReadLine());
            var field = new char[rowsAndCols, rowsAndCols];
            var actions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var allCoals = 0;
            var currentPlace = new int[] { 0, 0 };
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = input[col];
                    if (input[col] == 's')
                    {
                        currentPlace[0] = row;
                        currentPlace[1] = col;
                    }
                    else if (input[col] == 'c')
                    {
                        allCoals++;
                    }
                }
            }

            var counterCoal = 0;
            for (int i = 0; i < actions.Length; i++)
            {
                var action = actions[i];

                if (action == "right" && currentPlace[1] + 1 < field.GetLength(1))
                {
                    currentPlace[1] += 1;
                }
                else if (action == "left" && currentPlace[1] - 1 >= 0)
                {
                    currentPlace[1] -= 1;
                }
                else if (action == "up" && currentPlace[0] - 1 >= 0)
                {
                    currentPlace[0] -= 1;
                }
                else if (action == "down" && currentPlace[0] + 1 < field.GetLength(0))
                {
                    currentPlace[0] += 1;
                }
                else
                {
                    continue;
                }

                if (field[currentPlace[0], currentPlace[1]] == 'c')
                {
                    counterCoal++;
                    field[currentPlace[0], currentPlace[1]] = '*';
                }
                else if (field[currentPlace[0], currentPlace[1]] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentPlace[0]}, {currentPlace[1]})");
                    return;
                }

                if (allCoals == counterCoal)
                {
                    Console.WriteLine($"You collected all coals! ({currentPlace[0]}, {currentPlace[1]})");
                    return;
                }
            }

            Console.WriteLine($"{allCoals - counterCoal} coals left. ({currentPlace[0]}, {currentPlace[1]})");
        }
    }
}
