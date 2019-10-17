namespace _07.Sum_Prime_Non_Prime
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            long sumPrime = 0;
            long sumNotPrime = 0;

            while (input != "stop")
            {
                long num = long.Parse(input);
                if (num < 0)
                {
                    while (num < 0)
                    {
                        Console.WriteLine("Number is negative.");
                        input = Console.ReadLine();
                        if (input == "stop")
                        {
                            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
                            Console.WriteLine($"Sum of all non prime numbers is: {sumNotPrime}");
                            return;
                        }
                        num = num = long.Parse(input);
                    }
                }

                if (IsPrime(num))
                {
                    sumPrime += num;
                }
                else
                {
                    sumNotPrime += num;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNotPrime}");
        }

        public static bool IsPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var limit = Math.Ceiling(Math.Sqrt(number)); //hoisting the loop limit

            for (long i = 2; i <= limit; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
