namespace _07._Concat_Names
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var firsName = Console.ReadLine();
            var secondName = Console.ReadLine();
            var delimeter = Console.ReadLine();

            Console.WriteLine($"{firsName}{delimeter}{secondName}");
        }
    }
}
