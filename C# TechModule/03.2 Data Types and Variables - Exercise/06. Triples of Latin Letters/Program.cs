namespace _06._Triples_of_Latin_Letters
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (char first = 'a'; first < 'a' + number; first++)
            {
                for (char second = 'a'; second < 'a' + number; second++)
                {
                    for (char third = 'a'; third < 'a' + number; third++)
                    {
                        Console.WriteLine($"{first}{second}{third}");
                    }
                }
            }
        }
    }
}
