namespace _05._Count_of_Occurrences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            var counter = 1;
            List<int> num = new List<int>();
            List<int> timesRepeated = new List<int>();
            numbers.Sort();

            if (numbers.Count == 1)
            {
                num.Add(numbers[0]);
                timesRepeated.Add(1);
            }

            for (int i = 1; i < numbers.Count; i++)
            {

                if (numbers[i] != numbers[i - 1])
                {
                    timesRepeated.Add(counter);
                    num.Add(numbers[i - 1]);
                    counter = 0;
                }

                if (i == numbers.Count - 1)
                {
                    counter++;
                    timesRepeated.Add(counter);
                    num.Add(numbers[i]);
                }

                counter++;
            }

            for (int i = 0; i < num.Count; i++)
            {
                Console.WriteLine($"{num[i]} -> {timesRepeated[i]} times");
            }
        }
    }
}
