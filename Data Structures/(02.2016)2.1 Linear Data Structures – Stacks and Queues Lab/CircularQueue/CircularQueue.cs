using System;

public class CircularQueue<T>
{
    private T[] elements;
    private int startIndex = 0;
    private int endIndex = 0;
    private const int InitialCapacity = 16;

    public int Count { get; private set; }

    public CircularQueue(int capacity = InitialCapacity)
    {
        elements = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (Count == elements.Length)
        {
            this.Grow();
        }

        elements[endIndex] = element;
        if (endIndex + 1 >= elements.Length)
        {
            endIndex = 0;
        }
        else
        {
            endIndex++;
        }

        Count++;
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }
        var returnedElement = elements[startIndex];
        elements[startIndex] = default;
        startIndex = startIndex != elements.Length - 1 ? startIndex + 1 : 0;
        Count--;
        return returnedElement;
    }

    public T[] ToArray()
    {
        var arr = new T[Count];
        CopyAllElementsTo(arr);
        return arr;
    }

    private void Grow()
    {
        var newArray = new T[Count * 2];
        CopyAllElementsTo(newArray);
        elements = newArray;
        startIndex = 0;
        endIndex = Count;
    }

    private void CopyAllElementsTo(T[] newArray)
    {
        var newArrCounter = 0;
        for (int i = startIndex; i < Count; i++)
        {
            newArray[newArrCounter] = elements[i];
            newArrCounter++;
        }
        if (startIndex > endIndex)
        {
            for (int i = 0; i <= endIndex; i++)
            {
                newArray[newArrCounter] = elements[i];
                newArrCounter++;
            }
        }
    }
}

class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
