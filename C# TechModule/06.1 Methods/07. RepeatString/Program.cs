namespace _07._RepeatString
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var count = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatString(text, count));

        }

        static string RepeatString(string text, int count)
        {
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                result += text;
            }

            return result;
        }
    }
}
