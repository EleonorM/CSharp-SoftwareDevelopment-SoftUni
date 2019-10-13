namespace _05.Generating_Combinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void GenCombinations(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenCombinations(set, vector, index + 1, i + 1);
                }
            }
        }

        public static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int border = int.Parse(Console.ReadLine());
            int[] vector = new int[border];
            GenCombinations(nums, vector, 0, 0);
        }
    }
}
