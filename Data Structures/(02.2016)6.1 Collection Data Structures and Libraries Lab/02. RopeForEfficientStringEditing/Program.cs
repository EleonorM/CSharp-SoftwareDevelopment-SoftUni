namespace _02._RopeForEfficientStringEditing
{
    using System;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            var rope = new BigList<char>();

            var input = Console.ReadLine();
            while (input != "PRINT")
            {
                var inputParts = input.Split(" ");
                if (inputParts[0] == "INSERT")
                {
                    rope.InsertRange(0, inputParts[1].ToCharArray());
                }
                else if (inputParts[0] == "APPEND")
                {
                    rope.InsertRange(rope.Count, inputParts[1].ToCharArray());
                }
                else if (inputParts[0]== "DELETE")
                {
                    try
                    {
                        rope.RemoveRange(int.Parse(inputParts[1]), int.Parse(inputParts[2]));
                    }
                    catch
                    {
                        Console.WriteLine("ERROR");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
                Console.WriteLine("OK");
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("",rope));
        }
    }
}
