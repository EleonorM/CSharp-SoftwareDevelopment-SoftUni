namespace _01.Permutations
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

            GeneratePermutations(array);
            Console.WriteLine($"Total permutations: {countOfPermutations}");
        }

        private static void GeneratePermutations(int[] array, int index = 0)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
                countOfPermutations++;
            }
            else
            {
                for (int i = index; i < array.Length; i++)
                {
                    Swap(array, i, index);
                    GeneratePermutations(array, index + 1);
                    Swap(array, i, index);
                }
            }
        }

        private static void Swap(int[] array, int i, int k)
        {
            var temp = array[i];
            array[i] = array[k];
            array[k] = temp;
        }
    }
}
