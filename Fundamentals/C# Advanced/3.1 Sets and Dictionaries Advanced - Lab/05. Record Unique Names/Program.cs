namespace _05._Record_Unique_Names
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            HashSet<string> names = new HashSet<string>();

            int allNames = int.Parse(Console.ReadLine());
            for (int i = 0; i < allNames; i++)
            {
                var name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var nameKvp in names)
            {
                Console.WriteLine(nameKvp);
            }
        }
    }
}
