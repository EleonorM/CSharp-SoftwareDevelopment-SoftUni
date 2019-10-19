namespace _03._Zig_ZagArrays
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            string[] firstElements = new string[lines];
            string[] secondElements = new string[lines];

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                if (i % 2 == 0)
                {
                    firstElements[i] = input[0];
                    secondElements[i] = input[1];
                }
                else
                {
                    firstElements[i] = input[1];
                    secondElements[i] = input[0];
                }
            }

            foreach (var item in firstElements)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            foreach (var item in secondElements)
            {
                Console.Write(item + " ");
            }
        }
    }
}
