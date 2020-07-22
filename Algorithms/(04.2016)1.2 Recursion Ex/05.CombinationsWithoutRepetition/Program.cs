namespace _05.CombinationsWithoutRepetition
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var toNumber = int.Parse(Console.ReadLine());
            var numsCombination = int.Parse(Console.ReadLine());
            var arr = new int[numsCombination];
            GenerateCombinations(arr,1, toNumber, 0);
        }
        public static void GenerateCombinations(int[] arr,int startNum, int endNum, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr,i+1, endNum, index + 1);
                }
            }
        }
    }
}
