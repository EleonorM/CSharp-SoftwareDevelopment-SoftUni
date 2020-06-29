using System;
using System.Collections.Generic;
using System.Text;

namespace _06.ImplementTheDataStructure
{
    public interface IReversedList<T>
    {
        void Add(T item);

        int Count { get; }

        int Capacity { get; }

        T this[int index] { get; }

        void Remove(int index);
    }
}
