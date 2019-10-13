namespace _05.Wedding_Presents
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var guests = int.Parse(Console.ReadLine());
            var presentCount = double.Parse(Console.ReadLine());
            var aCount = 0;
            var bCount = 0;
            var vCount = 0;
            var gCount = 0;
            for (int i = 0; i < presentCount; i++)
            {
                var presentType = Console.ReadLine();
                if (presentType == "A")
                {
                    aCount++;
                }
                else if (presentType == "B")
                {
                    bCount++;
                }
                else if (presentType == "V")
                {
                    vCount++;
                }
                else if (presentType == "G")
                {
                    gCount++;
                }
            }

            Console.WriteLine($"{aCount / presentCount * 100:f2}%");
            Console.WriteLine($"{bCount / presentCount * 100:f2}%");
            Console.WriteLine($"{vCount / presentCount * 100:f2}%");
            Console.WriteLine($"{gCount / presentCount * 100:f2}%");
            Console.WriteLine($"{presentCount / guests * 100:f2}%");
        }
    }
}
