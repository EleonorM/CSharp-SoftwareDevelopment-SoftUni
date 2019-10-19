namespace _03._MergingLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> firstList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> result = new List<int>();

            int minList = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < minList; i++)
            {
                result.Add(firstList[i]);
                result.Add(secondList[i]);
            }

            List<int> isBigger;
            if (firstList.Count > minList)
            {
                isBigger = firstList;
            }
            else
            {
                isBigger = secondList;
            }

            for (int i = minList; i < isBigger.Count; i++)
            {
                result.Add(isBigger[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
