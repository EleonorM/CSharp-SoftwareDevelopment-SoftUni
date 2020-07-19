using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> list;
    private readonly int RootIndex = 0;

    public BinaryHeap()
    {
        list = new List<T>();
    }

    public BinaryHeap(T[] elements)
    {
        list = new List<T>(elements);
        for (int i = list.Count / 2; i >= 0; i--)
        {
            HeapifyDown(i);
        }
    }

    public int Count => list.Count;

    public T ExtractMax()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        var element = list[RootIndex];
        Swap(RootIndex, Count - 1);
        list.RemoveAt(Count - 1);
        HeapifyDown(RootIndex);
        return element;
    }

    public T PeekMax()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        return list[RootIndex];
    }

    public void Insert(T node)
    {
        list.Add(node);
        if (Count != 1)
        {
            HeapifyUp(Count - 1);
        }
    }

    private void HeapifyDown(int node)
    {
        if (Count == 0)
        {
            return;
        }
        var leftChildIndex = FindLeftChildIndex(node);
        var rightChildIndex = FindRightChildIndex(node);
        var largestNodeIndex = node;
        if (leftChildIndex < Count && list[leftChildIndex].CompareTo(list[largestNodeIndex]) > 0)
        {
            largestNodeIndex = leftChildIndex;
        }
        if (rightChildIndex < Count && list[rightChildIndex].CompareTo(list[largestNodeIndex]) > 0)
        {
            largestNodeIndex = rightChildIndex;
        }
        if (largestNodeIndex != node)
        {
            Swap(node, largestNodeIndex);
            HeapifyDown(largestNodeIndex);
        }
    }

    private int FindLeftChildIndex(int index)
    {
        var leftchildIndex = index * 2 + 1;
        return leftchildIndex;
    }

    private int FindRightChildIndex(int index)
    {
        var rightChildIndex = index * 2 + 2;
        return rightChildIndex;
    }

    private void HeapifyUp(int i)
    {
        var parentIndex = (i - 1) / 2;

        if (i > 0 && list[parentIndex].CompareTo(list[i]) < 0)
        {
            Swap(parentIndex, i);
            HeapifyUp(parentIndex);
        }
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        var temp = list[firstIndex];
        list[firstIndex] = list[secondIndex];
        list[secondIndex] = temp;
    }
}
