namespace _07._Water_Overflow
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int capacity = 0;
            for (int i = 0; i < number; i++)
            {
                int pour = int.Parse(Console.ReadLine());
                if (capacity + pour > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    capacity += pour;
                }
            }

            Console.WriteLine(capacity);
        }
    }
}
