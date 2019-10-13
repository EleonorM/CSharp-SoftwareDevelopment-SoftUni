namespace _03._Longest_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> maxNumbers = new List<int>();
            List<int> temp = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                temp.Add(list[i]);
                if (temp.Count > maxNumbers.Count)
                {
                    List<int> maxN = new List<int>();
                    for (int j = 0; j < temp.Count; j++)
                    {
                        maxN.Add(temp[j]);
                        maxNumbers = maxN;
                    }
                }

                if (i < list.Count - 1)
                {
                    if (list[i] != list[i + 1])
                    {
                        temp.RemoveAll(item => item == list[i]);
                    }
                }
            }


            if (list.Count == 1)
            {
                Console.WriteLine(list[0]);
            }
            else
                Console.WriteLine(string.Join(" ", maxNumbers));
        }
    }
}
