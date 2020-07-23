namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(List<T> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = array[start];
            var storeIndex = start + 1;
            for (int i = start + 1; i <= end; i++)
            {
                if (array[i].CompareTo(pivot) < 0)
                {
                    Swap(array, i, storeIndex);
                    storeIndex++;
                }
            }

            Swap(array, start, storeIndex - 1);
            Quicksort(array, start, storeIndex - 1);
            Quicksort(array, storeIndex, end);
        }

        private void Swap(List<T> array, int firtsIndex, int secondIndex)
        {
            var firstElemnt = array[firtsIndex];
            array[firtsIndex] = array[secondIndex];
            array[secondIndex] = firstElemnt;
        }
    }
}
