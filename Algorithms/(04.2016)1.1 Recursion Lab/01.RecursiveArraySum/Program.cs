namespace _01.RecursiveArraySum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Console.WriteLine(FindSum(input, 0));
        }

        private static int FindSum(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + FindSum(arr, index + 1);
        }
    }
}
