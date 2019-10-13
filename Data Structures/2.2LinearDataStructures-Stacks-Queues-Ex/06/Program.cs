namespace _06
{
using System;
using System.Collections.Generic;
using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var start = input[0];
            var end = input[1];
            if (start > end)
            {
                return;
            }

            if (end == start)
            {
                Console.WriteLine(start);
                return;
            }

            var removedElements = new List<int>();

            var queue = new Queue<Item>();
            Item startItem = new Item();
            startItem.Value = start;
            queue.Enqueue(startItem);

            var result = new List<int>();

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();

                int nextValue1 = element.Value + 1;
                int nextValue2 = element.Value + 2;
                int nextValue3 = element.Value * 2;

                if (nextValue1 == end
                   || nextValue2 == end
                   || nextValue3 == end)
                {
                    Print(element, end);
                    break;
                }

                if (nextValue1 < end)
                {
                    queue.Enqueue(new Item(nextValue1, element));
                }

                if (nextValue2 < end)
                {
                    queue.Enqueue(new Item(nextValue2, element));
                }

                if (nextValue3 < end)
                {
                    queue.Enqueue(new Item(nextValue3, element));
                }
            }

            result.Reverse();
            Console.WriteLine(string.Join(" -> ", result));
        }

        public static void Print(Item item, int end)
        {
            var stack = new Stack<int>();

            stack.Push(end);
            while (item.PrevItem != null)
            {
                stack.Push(item.Value);
                item = item.PrevItem;
            }

            stack.Push(item.Value);
            Console.WriteLine(string.Join(" -> ", stack.ToArray()));
        }
    }

    public class Item
    {
        public Item()
        {
        }

        public Item(int value, Item prevItem)
        {
            this.Value = value;
            this.PrevItem = prevItem;
        }

        public int Value { get; set; }

        public Item PrevItem { get; private set; }
    }
}

