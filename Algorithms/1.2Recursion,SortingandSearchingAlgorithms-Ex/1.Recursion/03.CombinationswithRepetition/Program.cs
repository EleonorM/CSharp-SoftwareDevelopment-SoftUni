namespace _03.CombinationswithRepetition
{
    using System;
    public class Program
    {
        private static int numberOfIterations;
        public static void Main()
        {
            var numberOfLoops = int.Parse(Console.ReadLine());
            numberOfIterations = int.Parse(Console.ReadLine());
            var array = new int[numberOfIterations];
            Recursion(numberOfLoops, 0, 1, array);

        }

        private static void Recursion(int n, int position, int current, int[] array)
        {
            if (position == numberOfIterations)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = current; i <= n; i++)
            {
                array[position] = i ;
                Recursion(n, position + 1, current, array);
                current++;
            }
        }
    }
}
