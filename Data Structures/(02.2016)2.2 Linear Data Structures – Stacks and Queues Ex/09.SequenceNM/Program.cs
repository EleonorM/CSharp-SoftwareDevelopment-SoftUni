namespace _09.SequenceNM
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int NumEnd;

        public static void Main()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException();
            }

            var nums = input.Split(" ").Select(int.Parse).ToArray();
            var numStart = nums[0];
            NumEnd = nums[1];
            var queue = new Queue<QueueNode<int>>();

            var startNode = new QueueNode<int>();
            startNode.Value = numStart;
            queue.Enqueue(startNode);
            Func<int, int> add1 = num => num + 1;
            Func<int, int> add2 = num => num + 2;
            Func<int, int> multiply2 = num => num * 2;
            var deleg = new List<Func<int, int>>
            {
                add1,
                add2,
                multiply2,
            };

            while (true)
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine("(no solution)");
                    return;
                }

                var currentNode = queue.Dequeue();
                for (int i = 0; i < deleg.Count; i++)
                {
                    if (FindSequence(queue, deleg[i], currentNode))
                    {
                        return;
                    }
                }
            }
        }

        private static bool FindSequence(Queue<QueueNode<int>> queue, Func<int, int> func, QueueNode<int> currentNode)
        {
            var node1 = new QueueNode<int>();
            node1.Value = func(currentNode.Value);
            node1.PrevNode = currentNode;

            if (node1.Value > NumEnd)
            {
                return false;
            }
            else if (node1.Value == NumEnd)
            {
                queue.Enqueue(node1);
                PrintNums(node1);
                return true;
            }
            queue.Enqueue(node1);
            return false;
        }

        private static void PrintNums(QueueNode<int> node)
        {
            var nums = new List<int>();
            while (node != null)
            {
                nums.Add(node.Value);
                node = node.PrevNode;
            }

            nums.Reverse();
            Console.WriteLine(string.Join(" -> ", nums));
            return;
        }
    }
}
