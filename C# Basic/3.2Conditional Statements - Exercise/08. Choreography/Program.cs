namespace _08.Choreography
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var steps = int.Parse(Console.ReadLine());
            var dancers = double.Parse(Console.ReadLine());
            var days = double.Parse(Console.ReadLine());

            double stepsInDay = Math.Ceiling((steps / days) / steps * 100.0);
            double stepsPerDAncer = stepsInDay / dancers;
            if (stepsInDay <= 13)
            {
                Console.WriteLine("Yes, they will succeed in that goal! {0:0.00}%.", stepsPerDAncer);
            }
            else
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {stepsPerDAncer:f2}% steps to be learned per day.");
            }
        }
    }
}
