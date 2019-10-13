using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public T Value { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode<T> Previous { get; set; }

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
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var newNode = new ListNode<T>(element);
            newNode.Next = this.head;
            this.head.Previous = newNode;
            this.head = newNode;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new ListNode<T>(element);
        }
        else
        {
            var newNode = new ListNode<T>(element);
            newNode.Previous = this.tail;
            this.tail.Next = newNode;
            this.tail = newNode;
        }
        Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List Empty");
        }

        var firstElement = this.head.Value;
        this.head = this.head.Next;
        if (this.head != null)
        {
            this.head.Previous = null;
        }
        else
        {
            this.tail = null;
        }
        this.Count--;
        return firstElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("List Empty");
        }

        var lastElement = this.tail.Value;
        this.tail = this.tail.Previous;
        if (this.tail != null)
        {
            this.tail.Next = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;
        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        var counter = 0;
        var currentNode = this.head;
        for (int i = 0; i < array.Length; i++)
        {
            array[counter] = currentNode.Value;
            currentNode = currentNode.Next;
            counter++;
        }

        return array;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;
        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}


public class Example
{
    public static void Main()
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
