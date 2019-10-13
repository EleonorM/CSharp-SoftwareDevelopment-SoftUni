using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    private Node head;
    private Node tail;

    public void AddFirst(T item)
    {
        var oldHead = this.head;

        this.head = new Node(item);
        this.head.Next = oldHead;

        if (this.Count == 0)
        {
            this.head = this.tail = new Node(item);
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        var oldTail = this.tail;
        this.tail = new Node(item);

        if (this.Count == 0)
        {
            this.head = this.tail;
        }
        else
        {
            oldTail.Next = this.tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var oldHead = this.head;
        this.head = this.head.Next;
        if (this.Count == 1)
        {
            this.tail = null;
        }

        this.Count--;

        return oldHead.Value;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var oldTail = this.tail;

        if (this.Count == 1)
        {
            this.tail = null;
            this.head = null;
        }
        else
        {
            var newTail = GetSecondToLastNode();
            newTail.Next = null;
            this.tail = newTail;
        }
        this.Count--;
        return oldTail.Value;
    }

    private Node GetSecondToLastNode()
    {
        var current = this.head;
        while (current.Next != this.tail)
        {
            current = current.Next;
        }

        return current;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = this.head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node
    {
        public Node(T item)
        {
            this.Value = item;
        }

        public T Value { get; private set; }

        public Node Next { get; set; }
    }
}
