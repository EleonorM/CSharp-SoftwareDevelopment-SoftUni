namespace _05.Bus
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var allPasangers = int.Parse(Console.ReadLine());
            var stops = int.Parse(Console.ReadLine());
            var passengers = allPasangers;
            for (int i = 1; i <= stops; i++)
            {
                var passengersLeft = int.Parse(Console.ReadLine());
                passengers -= passengersLeft;
                if (i % 2 != 0)
                {
                    passengers += 2;
                }
                else
                {
                    passengers -= 2;
                }

                var passengersCame = int.Parse(Console.ReadLine());
                passengers += passengersCame;
            }

            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
