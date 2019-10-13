namespace _03._Ferrari
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var car = new Ferrari(name);
            Console.WriteLine(car);
        }
    }
}
