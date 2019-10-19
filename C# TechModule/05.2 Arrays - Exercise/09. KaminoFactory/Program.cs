namespace _09._KaminoFactory
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var sequenceNum = int.Parse(Console.ReadLine());
            var longestSub = -1;
            var longestSubIndex = -1;
            var longestSubSum = -1;
            int indexOfSeq = 0;
            int indexOfLongest = 0;
            int[] sequence = new int[sequenceNum];
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Clone them!")
                {
                    break;
                }
                var sub = 0;
                var subIndex = -1;
                var subSum = 0;
                int count = 0;

                var DNA = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int i = 0; i < DNA.Length; i++)
                {
                    if (DNA[i] == 1)
                    {
                        count++;
                        subSum++;
                        if (count > sub)
                        {
                            sub = count;
                            subIndex = i - count;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }

                indexOfSeq++;


                if (sub > longestSub)
                {
                    longestSub = sub;
                    longestSubIndex = subIndex;
                    longestSubSum = subSum;
                    sequence = DNA;
                    indexOfLongest = indexOfSeq;
                }
                else if (sub == longestSub && longestSubIndex > subIndex)
                {
                    longestSub = sub;
                    longestSubIndex = subIndex;
                    longestSubSum = subSum;
                    indexOfLongest = indexOfSeq; sequence = DNA;
                }
                else if (sub == longestSub && longestSubIndex == subIndex && longestSubSum < subSum)
                {
                    longestSub = sub;
                    longestSubIndex = subIndex;
                    longestSubSum = subSum;
                    sequence = DNA;
                    indexOfLongest = indexOfSeq;
                }
            }

            Console.WriteLine($"Best DNA sample {indexOfLongest} with sum: {longestSubSum}.");
            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
