namespace _03.Stack
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var collection = new MyStack<string>();
            while (true)
            {
                var input = Console.ReadLine().Split(new string[] { ", ", " " }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0] == "END")
                {
                    break;
                }

                if (input[0] == "Push")
                {
                    var items = input.Skip(1).ToArray();
                    foreach (var item in items)
                    {
                        collection.Push(item);
                    }
                }
                else if (input[0] == "Pop")
                {
                    collection.Pop();
                }
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
