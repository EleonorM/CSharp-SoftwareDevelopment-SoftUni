namespace _05._LongestIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        const int NO_PREVIOUS = -1;
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var len = new int[nums.Length];
            var prev = new int[nums.Length];

            int bestIndex = CalculateLongestIncreasingSubseq(nums, len, prev);
            PrintLongestIncreasingSub(nums, prev, bestIndex);
        }

        static int CalculateLongestIncreasingSubseq(int[] seq, int[] len, int[] prev)
        {
            int maxIndex = 0;
            int maxLenght = 0;
            for (int x = 0; x < seq.Length; x++)
            {
                len[x] = 1;
                prev[x] = -1;
                for (int i = 0; i < x; i++)
                {
                    if (seq[x] > seq[i] && len[i] + 1 > len[x])
                    {
                        len[x] = len[i] + 1;
                        prev[x] = i;
                    }
                }

                if (len[x] > maxLenght)
                {
                    maxLenght = len[x];
                    maxIndex = x;
                }
            }

            return maxIndex;
        }

        static void PrintLongestIncreasingSub(int[] seq, int[] prev, int index)
        {
            List<int> lis = new List<int>();
            while (index != NO_PREVIOUS)
            {
                lis.Add(seq[index]);
                index = prev[index];
            }

            lis.Reverse();
            Console.WriteLine(string.Join(" ", lis));
        }
    }
}
