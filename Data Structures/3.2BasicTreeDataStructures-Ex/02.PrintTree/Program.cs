using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

    public static void Main()
    {
        ReadTree();
        Console.WriteLine(GetRoodNode().Value);
        Print(GetRoodNode(), 0);
    }

    static Tree<int> GetTreeByValue(int value)
    {
        if (!nodeByValue.ContainsKey(value))
        {
            nodeByValue[value] = new Tree<int>(value);
        }

        return nodeByValue[value];
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
        return nodeByValue.Values.FirstOrDefault(x => x.Parent == null);
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
