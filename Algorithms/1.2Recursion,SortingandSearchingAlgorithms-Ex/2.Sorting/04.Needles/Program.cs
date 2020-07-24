namespace _04.Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var numsToInsert = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var resutPositions = new List<int>();
            foreach (var num in numsToInsert)
            {
                var index = nums.Count - 1;
                while (index >= 0)
                {
                    if (nums[index] == 0)
                    {
                        index--;
                        continue;
                    }

                    if (nums[index] < num)
                    {
                        resutPositions.Add(index + 1);
                        break;
                    }
                    else
                    {
                        index--;
                    }
                }

                if (index == -1)
                {
                    resutPositions.Add(index + 1);
                }
            }

            Console.WriteLine(string.Join(" ", resutPositions));

        }
    }
}
