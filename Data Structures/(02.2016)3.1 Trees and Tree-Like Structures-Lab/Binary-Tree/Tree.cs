using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; }

    public IList<Tree<T>> Children { get; }

    public Tree(T value, params Tree<T>[] children)
    {
        Value = value;
        Children = new List<Tree<T>>();
        foreach (var child in children)
        {
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
}
