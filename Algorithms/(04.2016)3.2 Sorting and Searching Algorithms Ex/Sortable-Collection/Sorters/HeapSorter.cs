namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private List<T> list;

        private readonly int RootIndex = 0;

        private int Count => list.Count;

        public void Sort(List<T> collection)
        {
            list = new List<T>(collection);
            for (int i = list.Count / 2; i >= 0; i--)
            {
                HeapifyDown(i);
            }

            SortProcedure(collection);
        }

        private void SortProcedure(List<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = this.ExtractMin();
            }
        }

        private T ExtractMin()
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

        private void HeapifyDown(int node)
        {
            if (Count == 0)
            {
                return;
            }
            var leftChildIndex = FindLeftChildIndex(node);
            var rightChildIndex = FindRightChildIndex(node);
            var smallestNodeIndex = node;
            if (leftChildIndex < Count && list[leftChildIndex].CompareTo(list[smallestNodeIndex]) < 0)
            {
                smallestNodeIndex = leftChildIndex;
            }
            if (rightChildIndex < Count && list[rightChildIndex].CompareTo(list[smallestNodeIndex]) < 0)
            {
                smallestNodeIndex = rightChildIndex;
            }
            if (smallestNodeIndex != node)
            {
                Swap(node, smallestNodeIndex);
                HeapifyDown(smallestNodeIndex);
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

            if (i > 0 && list[parentIndex].CompareTo(list[i]) > 0)
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
}
