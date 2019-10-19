namespace _02.Passed
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var grade = double.Parse(Console.ReadLine());

            if (grade >= 3)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
