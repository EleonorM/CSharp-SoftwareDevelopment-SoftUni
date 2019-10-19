namespace _06.Foreign_Languages
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var country = Console.ReadLine();
            switch (country)
            {
                case "England":
                case "USA":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                case "Argentina":
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;

                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
