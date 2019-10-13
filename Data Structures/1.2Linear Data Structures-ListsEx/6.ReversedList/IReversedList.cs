public interface IReversedList<T>
{
    void Add(T item);

    int Count { get; }

    int Capacity { get; }

    T this[int index] { get; }

    void RemoveAt(int index);
}
