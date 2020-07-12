namespace _02._StringEditor
{
    using System;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            var rope = new BigList<char>();

            var input = Console.ReadLine();
            while (input != "END")
            {
                var inputParts = input.Split(" ");
                if (inputParts[0] == "INSERT")
                {
                    var partsToInsert = input.Remove(0, inputParts[0].Length + inputParts[1].Length + 2);
                    var position = int.Parse(inputParts[1]);
                    rope.InsertRange(position, partsToInsert.ToCharArray());
                }
                else if (inputParts[0] == "APPEND")
                {
                    var partsToInsert = input.Remove(0, inputParts[0].Length +1);
                    rope.InsertRange(rope.Count, partsToInsert.ToCharArray());
                }
                else if (inputParts[0] == "DELETE")
                {
                    try
                    {
                        rope.RemoveRange(int.Parse(inputParts[1]), int.Parse(inputParts[2]));
                    }
                    catch
                    {
                        Console.WriteLine("ERROR");
                    }
                }
                else if (inputParts[0] == "PRINT")
                {
                    Console.WriteLine(string.Join("", rope));
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
                Console.WriteLine("OK");
                input = Console.ReadLine();
            }
        }
    }
}
