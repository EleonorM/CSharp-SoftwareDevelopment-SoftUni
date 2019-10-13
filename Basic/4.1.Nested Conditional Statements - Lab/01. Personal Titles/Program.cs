namespace _01.Personal_Titles
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double age = double.Parse(Console.ReadLine());
            var gender = Console.ReadLine().ToLower();

            if (age < 16)
            {
                if (gender == "m")
                {
                    Console.WriteLine("Master");
                }
                else if (gender == "f")
                {
                    Console.WriteLine("Miss");
                }
            }
            else
            {
                if (gender == "m")
                {
                    Console.WriteLine("Mr.");
                }
                else if (gender == "f")
                {
                    Console.WriteLine("Ms.");
                }
            }
        }
    }
}
