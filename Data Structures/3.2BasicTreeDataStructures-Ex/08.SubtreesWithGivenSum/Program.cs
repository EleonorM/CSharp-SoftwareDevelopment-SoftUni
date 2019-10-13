using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();

        var sum = int.Parse(Console.ReadLine());
        var leafs = tree.Values.Where(x => x.Children.Count == 0).ToList();
        Console.WriteLine($"Subtrees of sum {sum}:");
        foreach (var item in GetSubtreeWithSum(GetRoodNode(), sum))
        {
            PrintPreOrder(item);
            Console.WriteLine();
        }
    }

    private static void PrintPreOrder(Tree<int> item)
    {
        Console.Write(item.Value + " ");
        foreach (var node in item.Children)
        {
            PrintPreOrder(node);
        }
    }

    static List<Tree<int>> GetSubtreeWithSum(Tree<int> node, int sum)
    {
        var roots = new List<Tree<int>>();
        DFS(GetRoodNode(), sum, 0, roots);
        return roots;
    }

    static int DFS(Tree<int> node, int targetSum, int currentSum, List<Tree<int>> roots)
    {
        if (node == null)
        {
            return 0;
        }

        currentSum = node.Value;

        foreach (var child in node.Children)
        {
            currentSum += DFS(child, targetSum, currentSum, roots);
        }

        if (currentSum == targetSum)
        {
            roots.Add(node);
        }

        return currentSum;
    }

    static Tree<int> GetTreeByValue(int value)
    {
        if (!tree.ContainsKey(value))
        {
            tree[value] = new Tree<int>(value);
        }

        return tree[value];
    }

    static void AddEdge(int parent, int child)
    {
        Tree<int> parentNode = GetTreeByValue(parent);
        Tree<int> childNode = GetTreeByValue(child);

        parentNode.Children.Add(childNode);
        childNode.Parent = parentNode;
    }

    static void ReadTree()
    {
        int nodeCount = int.Parse(Console.ReadLine());
        for (int i = 1; i < nodeCount; i++)
        {
            var edge = Console.ReadLine().Split().Select(int.Parse).ToArray();
            AddEdge(edge[0], edge[1]);
        }
    }

    static Tree<int> GetRoodNode()
    {
        return tree.Values.FirstOrDefault(x => x.Parent == null);
    }

    static void Print(Tree<int> node, int tabulation)
    {
        foreach (var child in node.Children)
        {
            Console.Write(new string(' ', tabulation + 1));
            Console.WriteLine(child.Value);
            Print(child, tabulation + 1);
        }
    }
}
