namespace _02.GeneratePermutationsIteratively
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int countOfPermutations = 0;

        public static void Main()
        {
            var nums = int.Parse(Console.ReadLine());
            var array = Enumerable.Range(1, nums).ToArray();
            var array2 = Enumerable.Range(0, nums + 1).ToArray();

            GeneratePermutations(array, array2);
            Console.WriteLine($"Total permutations: {countOfPermutations}");
        }

        private static void GeneratePermutations(int[] array, int[] array2, int index = 1)
        {
            int count = 0;
            PrintPermutation(array);
            count++;

            while (index < array.Length)
            {
                array2[index]--;
                int temp = 0;
                if (index % 2 != 0)
                {
                    temp = array2[index];
                }

                Swap(array, temp, index);
                index = 1;
                while (array2[index] == 0)
                {
                    array2[index] = index;
                    index++;
                }

                PrintPermutation(array);
                count++;
            }
        }

        private static void PrintPermutation(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        private static void Swap(int[] array, int i, int k)
        {
            var temp = array[i];
            array[i] = array[k];
            array[k] = temp;
        }
    }
}
