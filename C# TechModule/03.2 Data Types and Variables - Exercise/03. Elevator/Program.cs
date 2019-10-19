namespace _03._Elevator
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double course = Math.Ceiling(people / (double)capacity);
            Console.WriteLine(course);
        }
    }
}
