namespace _03._ExtractFile
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split("\\");
            var file = input[input.Length - 1];
            var fileParts = file.Split(".");
            Console.WriteLine($"File name: {fileParts[0]}");
            Console.WriteLine($"File extension: {fileParts[1]}");
        }
    }
}
