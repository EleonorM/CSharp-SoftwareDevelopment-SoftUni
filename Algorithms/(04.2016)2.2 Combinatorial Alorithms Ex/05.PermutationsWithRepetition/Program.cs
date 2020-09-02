namespace _05.PermutationsWithRepetition
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            PermutationsRep(inputArray);
        }

        public static void PermutationsRep(int[] ps)
        {
            Array.Sort(ps);
            Permute(ps, 0, ps.Length);
        }

        private static void Permute(int[] ps, int start, int n)
        {
            PrintResult(ps);
            int tmp;

            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (ps[i] != ps[j])
                        {
                            // swap ps[i] <--> ps[j]
                            tmp = ps[i];
                            ps[i] = ps[j];
                            ps[j] = tmp;

                            Permute(ps, i + 1, n);
                        }
                    }

                    // Undo all modifications done by
                    // recursive calls and swapping
                    tmp = ps[i];
                    for (int k = i; k < n - 1;)
                        ps[k] = ps[++k];
                    ps[n - 1] = tmp;
                }
            }
        }

        private void PermuteRepIteretive(int[] ps)
        {
            PrintResult(ps);
            int n = ps.Length;
            int tmp = 0;

            // indexes[i] = i+1;
            int[] indexes = new int[n];
            for (int i = 0; i < n - 1;) indexes[i] = ++i;

            for (int i = n - 2; i >= 0;)
            {

                while (indexes[i] < n && ps[indexes[i]] == ps[i])
                {
                    indexes[i]++;
                }

                // swap ps[i] <--> ps[indexes[i]
                if (indexes[i] < n)
                {
                    tmp = ps[indexes[i]];
                    ps[indexes[i]] = ps[i];
                    ps[i] = tmp;

                    PrintResult(ps);
                }

                indexes[i]++;

                i = n - 2;

                while (i >= 0 && indexes[i] >= n)
                {
                    // Undo previous permutation from i+1
                    // Cyclical rotation to the left from i+1
                    // ps[k] = ps[k+1]
                    tmp = ps[i];
                    for (int k = i; k < n - 1;)
                        ps[k] = ps[++k];
                    ps[n - 1] = tmp;

                    // indexes[i]=i+1;
                    // i--;
                    indexes[i] = i-- + 1;
                }
            }
        }

        private static void PrintResult<T>(T[] ps)
        {
            Console.WriteLine(string.Join(", ", ps));
        }
    }
}
