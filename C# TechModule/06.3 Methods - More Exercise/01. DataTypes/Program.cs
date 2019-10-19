namespace _01._DataTypes
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var type = Console.ReadLine();
            var input = Console.ReadLine();
            if (type == "int")
            {
                PrintInt(input);
            }
            else if (type == "real")
            {
                PrintReal(input);
            }
            else if (type == "string")
            {
                PrintString(input);
            }
        }

        private static void PrintReal(string input)
        {
            var num = double.Parse(input);
            Console.WriteLine($"{num * 1.5:f2}");
        }

        private static void PrintString(string input)
        {
            Console.WriteLine($"${input}$");
        }

        static void PrintInt(string input)
        {
            var num = int.Parse(input);
            Console.WriteLine(num * 2);
        }
    }
}
