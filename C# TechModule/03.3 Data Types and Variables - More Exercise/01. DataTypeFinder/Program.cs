namespace _01._DataTypeFinder
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var dataType = "";
            while (input != "END")
            {
                if (int.TryParse(input, out int value))
                {
                    dataType = "integer";
                }
                else if (double.TryParse(input, out double valueD))
                {
                    dataType = "floating point";
                }
                else if (char.TryParse(input, out char valueC))
                {
                    dataType = "character";
                }
                else if (bool.TryParse(input, out bool valueB))
                {
                    dataType = "boolean";
                }
                else
                {
                    dataType = "string";
                }

                Console.WriteLine($"{input} is {dataType} type");
                input = Console.ReadLine();
            }
        }
    }
}
