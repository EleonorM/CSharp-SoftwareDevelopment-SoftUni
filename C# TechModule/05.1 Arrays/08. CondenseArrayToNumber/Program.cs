namespace _08._CondenseArrayToNumber
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] numsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            if (numsArray.Length == 1)
                Console.WriteLine($"{numsArray[0]}");
            else
            {
                while (numsArray.Length > 1)
                {
                    int[] condensered = new int[numsArray.Length - 1];
                    for (int i = 0; i < condensered.Length; i++)
                    {
                        condensered[i] = numsArray[i] + numsArray[i + 1];
                        numsArray[i] = condensered[i];
                    }

                    Array.Resize(ref numsArray, numsArray.Length - 1);

                }

                Console.WriteLine(numsArray[0]);
            }
        }
    }
}
