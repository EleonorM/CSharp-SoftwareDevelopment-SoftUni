namespace _04._FoldAndSum
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var unfolded = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] upperRow = new int[unfolded.Length / 2];
            int[] lowerRow = new int[unfolded.Length / 2];

            for (int i = 0; i < unfolded.Length / 4; i++)
            {
                upperRow[i] = unfolded[unfolded.Length / 4 - 1 - i];
                upperRow[upperRow.Length - i - 1] = unfolded[upperRow.Length + upperRow.Length / 2 + i];
            }

            for (int i = 0; i < lowerRow.Length; i++)
            {
                lowerRow[i] = unfolded[lowerRow.Length / 2 + i];
            }

            for (int i = 0; i < lowerRow.Length; i++)
            {
                Console.Write(upperRow[i] + lowerRow[i] + " ");
            }
        }
    }
}
