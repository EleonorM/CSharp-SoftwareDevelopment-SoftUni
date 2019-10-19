namespace _02._CommonElements
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            string[] firstElements = Console.ReadLine().Split().ToArray();
            string[] secondElements = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < secondElements.Length; i++)
            {
                for (int j = 0; j < firstElements.Length; j++)
                {
                    if (secondElements[i] == firstElements[j])
                    {
                        Console.Write(secondElements[i] + " ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
