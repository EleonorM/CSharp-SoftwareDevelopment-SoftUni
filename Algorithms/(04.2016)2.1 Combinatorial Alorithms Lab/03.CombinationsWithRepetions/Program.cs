namespace _03.CombinationsWithRepetions
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            var array = new int[k];
            GenerateCombinations(array, n);
        }

        private static void GenerateCombinations(int[] arr, int sizeOfSet, int index = 0, int start = 1)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, sizeOfSet, index + 1, i);
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine($"({string.Join(',', arr)})");
        }
    }
}
