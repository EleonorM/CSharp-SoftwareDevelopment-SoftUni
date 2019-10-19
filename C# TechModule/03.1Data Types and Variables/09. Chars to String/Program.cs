namespace _09._Chars_to_String
{
    using System;

    public class Program
    {
        public static void Main()
        {
            char input1 = char.Parse(Console.ReadLine());
            char input2 = char.Parse(Console.ReadLine());
            char input3 = char.Parse(Console.ReadLine());
            string result = input1.ToString() + input2 + input3;
            Console.WriteLine(result);
        }
    }
}
