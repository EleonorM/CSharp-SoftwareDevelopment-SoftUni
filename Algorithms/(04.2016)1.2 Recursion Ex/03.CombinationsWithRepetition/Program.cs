namespace _03.CombinationsWithRepetition
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var toNumber = int.Parse(Console.ReadLine());
            var numsCombination = int.Parse(Console.ReadLine());
            var arr = new int[numsCombination];
            GenerateCombinations(arr, toNumber, 0);
        }
        public static void GenerateCombinations(int[] arr, int endNum, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 1; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, endNum, index + 1);
                }
            }
        }
    }
}
