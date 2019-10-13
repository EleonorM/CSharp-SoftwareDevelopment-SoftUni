namespace _02.CalculateSequence
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var result = new List<int>();
            result = Print(number);

            Console.WriteLine(string.Join(", ", result));
        }

        private static List<int> Print(int number)
        {
            var result = new List<int>();
            result.Insert(0, number);
            Print(0, ref result);
            return result;
        }

        private static void Print(int counter, ref List<int> result)
        {
            result.Add(result[counter] + 1);
            if (result.Count >= 49)
            {
                return;
            }

            result.Add(2 * result[counter] + 1);
            result.Add(result[counter] + 2);
            Print(counter+1, ref result);
        }
    }
}
