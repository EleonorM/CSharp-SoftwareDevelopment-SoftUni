using System;
using System.Collections.Generic;

public class Tree<T>
{
    private List<Tree<T>> LeafNodes;

    private List<Tree<T>> MiddleNodes;

    private int LongestDistance = 0;

    private Tree<T> LastNodeInLongestDistance;

    private List<Tree<T>> subtreePreOrder;

    private static List<Tree<T>> NodesWithPathSum;

    private static List<Tree<T>> NodesWithSubtreeSum;


    public T Value { get; }

    public Tree<T> Parent { get; set; }

    public IList<Tree<T>> Children { get; }

    public Tree(T value, params Tree<T>[] children)
    {
        Value = value;
        Children = new List<Tree<T>>();
        foreach (var child in children)
        {
            child.Parent = this;
            Children.Add(child);
        }
    }

    public void Print(int indent = 0)
    {
        Console.WriteLine(new string(' ', 2 * indent) + Value);
        foreach (var child in Children)
        {
            child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(Value);
        foreach (var child in Children)
        {
            child.Each(action);
        }
    }

    public Tree<T> FindRootNode()
    {
        var currentNode = this;
        while (currentNode.Parent != null)
        {
            currentNode = currentNode.Parent;
        }

        return currentNode;
    }

    public IList<Tree<T>> FindLeafNodes()
    {
        LeafNodes = new List<Tree<T>>();
        var saveLeafNodesToList = new Action<Tree<T>>(x =>
        {
            if (x.Children.Count == 0)
            {
                LeafNodes.Add(x);
            }
        });

        DFS(this, saveLeafNodesToList);
        return LeafNodes;
    }

    public IList<Tree<T>> FindMiddleNodes()
    {
        MiddleNodes = new List<Tree<T>>();
        var saveMiddleNodesToList = new Action<Tree<T>>(x =>
        {
            if (x.Children.Count != 0 && x.Parent != null)
            {
                MiddleNodes.Add(x);
            }
        });

        DFS(this, saveMiddleNodesToList);
        return MiddleNodes;
    }

    public IList<Tree<T>> FindLongestRoadNodes()
    {
        DFSDistance(this, 0);

        var nodes = FindPathFromLastNode();
        return nodes;
    }

    public List<List<Tree<T>>> FindPathsOfSum(int pathsOfSum)
    {
        var listOfPaths = new List<List<Tree<T>>>();
        var sum = 0;

        NodesWithPathSum = new List<Tree<T>>();
        DFSPathSum(sum, pathsOfSum, this);

        foreach (var node in NodesWithPathSum)
        {
            var path = new List<Tree<T>>();
            var currentNode = node;
            while (currentNode != null)
            {
                path.Add(currentNode);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            listOfPaths.Add(path);
        }

        return listOfPaths;
    }

    public List<List<Tree<T>>> FindSubtreesOfSum(int subtreeSum)
    {
        var listOfSubtrees = new List<List<Tree<T>>>();
        subtreePreOrder = new List<Tree<T>>();
        var sum = 0;

        NodesWithSubtreeSum = new List<Tree<T>>();
        DFSSubtreeSum(subtreeSum, this);

        foreach (var node in NodesWithSubtreeSum)
        {
            FindPreOrder(node);
            listOfSubtrees.Add(subtreePreOrder);
        }

        return listOfSubtrees;
    }

    private void FindPreOrder(Tree<T> node)
    {
        subtreePreOrder.Add(node);
        foreach (var child in node.Children)
        {
            FindPreOrder(child);
        }
    }

    private void DFS(Tree<T> node, Action<Tree<T>> action)
    {
        action(node);
        foreach (var child in node.Children)
        {
            DFS(child, action);
        }
    }

    private void DFSDistance(Tree<T> node, int distance)
    {
        if (distance > LongestDistance)
        {
            LongestDistance = distance;
            LastNodeInLongestDistance = node;
        }

        foreach (var child in node.Children)
        {
            DFSDistance(child, distance + 1);
        }
    }

    private List<Tree<T>> FindPathFromLastNode()
    {
        var path = new List<Tree<T>>();
        var currentNode = LastNodeInLongestDistance;
        while (currentNode.Parent != null)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        path.Add(currentNode);
        path.Reverse();

        return path;
    }

    private static void DFSPathSum(int currentSum, int searchedSum, Tree<T> node)
    {
        currentSum += (int)(object)(node.Value);
        if (currentSum == searchedSum)
        {
            NodesWithPathSum.Add(node);
        }

        foreach (var child in node.Children)
        {
            DFSPathSum(currentSum, searchedSum, child);
        }
    }

    private int DFSSubtreeSum(int searchedSum, Tree<T> node)
    {
        var currentSum = (int)(object)node.Value;

        foreach (var child in node.Children)
        {
            currentSum += DFSSubtreeSum(searchedSum, child);
        }

        if (currentSum == searchedSum)
        {
            NodesWithSubtreeSum.Add(node);
        }

        return currentSum;
    }

}
