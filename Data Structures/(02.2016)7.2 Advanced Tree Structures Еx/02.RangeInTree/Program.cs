namespace _02.RangeInTree
{
    using _01.AvlTree;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var tree = new AvlTree<int>();

            foreach (var num in nums)
            {
                tree.Add(num);
            }
            var range = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var numsInRange = tree.FindInRange(range[0], range[1]);
            Console.WriteLine(string.Join(" ", numsInRange));
        }
    }
}
