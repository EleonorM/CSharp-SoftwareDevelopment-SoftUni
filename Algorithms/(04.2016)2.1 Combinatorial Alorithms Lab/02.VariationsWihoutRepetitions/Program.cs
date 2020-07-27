namespace _02.VariationsWihoutRepetitions
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var array = new int[k];
            var used = new bool[n + 1];
            GenerateVariations(array, used, n);
        }

        private static void GenerateVariations(int[] arr, bool[] used, int sizeOfSet, int index = 0)
        {
            if (index >= arr.Length)
            {
                Print(arr);
            }
            else
            {
                for (int i = 1; i < sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariations(arr, used, sizeOfSet, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] arr)
        {
            Console.WriteLine($"({string.Join(',', arr)})");
        }
    }
}
