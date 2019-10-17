namespace _07.Name_Wars
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var biggestSum = 0;
            var biggestName = string.Empty;
            while (input != "STOP")
            {
                var sum = 0;
                foreach (char letter in input)
                {
                    sum += letter;
                }

                if (sum > biggestSum)
                {
                    biggestSum = sum;
                    biggestName = input;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Winner is {biggestName} - {biggestSum}!");
        }
    }
}
