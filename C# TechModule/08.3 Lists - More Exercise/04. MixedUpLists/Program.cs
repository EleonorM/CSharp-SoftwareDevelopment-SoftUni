namespace _04._MixedUpLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            var resultList = new List<int>();


            while (firstList.Count != 0 && secondList.Count != 0)
            {
                resultList.Add(firstList[0]);
                firstList.RemoveAt(0);

                resultList.Add(secondList[secondList.Count - 1]);
                secondList.RemoveAt(secondList.Count - 1);
            }

            var firsNumber = 0;
            var endNumber = 0;

            if (firstList.Count > 0)
            {
                firsNumber = Math.Min(firstList[0], firstList[1]);
                endNumber = Math.Max(firstList[0], firstList[1]);
            }
            else
            {
                firsNumber = Math.Min(secondList[0], secondList[1]);
                endNumber = Math.Max(secondList[0], secondList[1]);
            }

            resultList = resultList.Where(x => x > firsNumber && x < endNumber).ToList();

            resultList.Sort();

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
