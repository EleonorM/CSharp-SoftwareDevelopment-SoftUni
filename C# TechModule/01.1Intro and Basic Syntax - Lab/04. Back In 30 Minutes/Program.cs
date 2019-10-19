namespace _04.Back_In_30_Minutes
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var hour = int.Parse(Console.ReadLine());
            var minutes = int.Parse(Console.ReadLine());

            var dateNow = new DateTime(1, 1, 1, hour, minutes, 00);
            dateNow = dateNow.AddMinutes(30);
            Console.WriteLine($"{dateNow.Hour}:{dateNow.Minute:d2}");
        }
    }
}
