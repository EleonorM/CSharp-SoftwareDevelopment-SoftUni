using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public class ListNode<T>
    {
        public T Value { get; private set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            var newNode = new ListNode<T>(element);
            head = newNode;
            tail = newNode;
        }
        else
        {
            var newNode = new ListNode<T>(element);
            newNode.NextNode = head;
            head.PrevNode = newNode;
            head = newNode;
        }

        Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            var newNode = new ListNode<T>(element);
            head = newNode;
            tail = newNode;
        }
        else
        {
            var newNode = new ListNode<T>(element);
            newNode.PrevNode = tail;
            tail.NextNode = newNode;
            tail = newNode;
        }

        Count++;
    }

    public T RemoveFirst()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Empty list.");
        }

        var oldHead = head;

        if (Count == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            var newHead = head.NextNode;
            newHead.PrevNode = null;
            head = newHead;
        }
        Count--;

        return oldHead.Value;
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Empty list.");
        }

        var oldTail = tail;

        if (Count == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            var newTail = tail.PrevNode;
            newTail.NextNode = null;
            tail = newTail;
        }

        Count--;

        return oldTail.Value;
    }

    public void ForEach(Action<T> action)
    {
        var node = this.head;
        while (node != null)
        {
            action(node.Value);
            node = node.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this.head;
        while (node != null)
        {
            yield return node.Value;
            node = node.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        var currentNode = this.head;
        var counter = 0;
        while (currentNode != null)
        {
            array[counter] = currentNode.Value;
            currentNode = currentNode.NextNode;
            counter++;
        }
        return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
