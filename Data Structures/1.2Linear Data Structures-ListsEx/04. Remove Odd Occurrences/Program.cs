namespace _04._Remove_Odd_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var counter = 0;
            List<int> result = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (list[i] == list[j])
                    {
                        counter++;
                    }
                }

                if (counter % 2 == 0)
                {
                    result.Add(list[i]);
                }
                counter = 0;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
