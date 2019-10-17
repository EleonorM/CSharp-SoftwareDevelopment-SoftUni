namespace _01._Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                var name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
