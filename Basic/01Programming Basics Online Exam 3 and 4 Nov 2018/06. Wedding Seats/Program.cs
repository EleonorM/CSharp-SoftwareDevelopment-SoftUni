namespace _06.Wedding_Seats
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var lastSector = char.Parse(Console.ReadLine());
            var rowFirstSector = int.Parse(Console.ReadLine());
            var seatsOddNumber = int.Parse(Console.ReadLine());
            var seatsEvenNumber = seatsOddNumber + 2;
            var counter = 0;
            for (char sector = 'A'; sector <= lastSector; sector++)
            {
                for (int row = 1; row <= rowFirstSector; row++)
                {
                    if (row % 2 != 0)
                    {
                        for (char seat = 'a'; seat < seatsOddNumber + 'a'; seat++)
                        {
                            Console.WriteLine($"{sector}{row}{seat}");
                            counter++;
                        }
                    }
                    else
                    {
                        for (char seat = 'a'; seat < seatsEvenNumber + 'a'; seat++)
                        {
                            Console.WriteLine($"{sector}{row}{seat}");
                            counter++;
                        }
                    }
                }

                rowFirstSector++;
            }

            Console.WriteLine(counter);
        }
    }
}
