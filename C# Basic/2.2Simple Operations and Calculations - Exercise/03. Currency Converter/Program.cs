namespace _03.Currency_Converter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var sum = double.Parse(Console.ReadLine());
            var cur1 = Console.ReadLine();
            var cur2 = Console.ReadLine();
            var sumaBGN = sum;
            if (cur1 == "USD")
                sumaBGN = sum * 1.79549;
            else if (cur1 == "EUR")
                sumaBGN = sum * 1.95583;
            else if (cur1 == "GBP")
                sumaBGN = sum * 2.53405;

            if (cur2 == "BGN")
                Console.WriteLine("{0} {1}", Math.Round(sumaBGN, 2), cur2);
            else if (cur2 == "USD")
                Console.WriteLine("{0} {1}", Math.Round(sumaBGN / 1.79549, 2), cur2);
            else if (cur2 == "EUR")
                Console.WriteLine("{0} {1}", Math.Round(sumaBGN / 1.95583, 2), cur2);
            else if (cur2 == "GBP")
                Console.WriteLine("{0} {1}", Math.Round(sumaBGN / 2.53405, 2), cur2);
        }
    }
}
