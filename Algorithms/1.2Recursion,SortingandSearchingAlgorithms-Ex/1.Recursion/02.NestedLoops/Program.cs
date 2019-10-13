namespace _02.NestedLoops
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var numberOfLoops = int.Parse(Console.ReadLine());
            var array = new int[numberOfLoops];
            Recursion(numberOfLoops, 0, array);
        }

        private static void Recursion(int n, int position, int[] array)
        {
            if (position == n)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                array[position] = i;
                Recursion(n, position + 1, array);
            }
        }
    }
}
