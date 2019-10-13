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
        Console.WriteLine($"Paths of sum {sum}:");
        DFS(GetRoodNode(), sum);
    }

    static void DFS(Tree<int> node, int targetSum, int sum = 0)
    {
        sum += node.Value;
        if (sum == targetSum)
        {
            PrintPath(node);
            return;
        }

        foreach (var child in node.Children)
        {
            DFS(child, targetSum, sum);
        }
    }

    private static void PrintPath(Tree<int> node)
    {
        var path = new Stack<int>();
        var start = node;
        path.Push(start.Value);
        while (start.Parent != null)
        {
            start = start.Parent;
            path.Push(start.Value);
        }

        Console.WriteLine(string.Join(" ", path));
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
