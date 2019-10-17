namespace _05.DateModifier
{
    using System;

    public class StatUp
    {
        public static void Main()
        {
            var date = new DateModifier();
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();
            Console.WriteLine(date.CalculateDifference(firstDate, secondDate));
        }
    }
}
