namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            MergeSort(collection, new T[collection.Count], 0, collection.Count - 1);
        }

        private void MergeSort(List<T> collection, T[] tempArray, int start, int end)
        {
            if (start < end)
            {
                int middle = (end + start) / 2;
                MergeSort(collection, tempArray, start, middle);
                MergeSort(collection, tempArray, middle + 1, end);

                var leftMinIndex = start;
                var rightMinIndex = middle + 1;
                var tempArrayIndex = 0;

                while (leftMinIndex <= middle && rightMinIndex <= end)
                {
                    if (collection[leftMinIndex].CompareTo(collection[rightMinIndex]) < 0)
                    {
                        tempArray[tempArrayIndex] = collection[leftMinIndex];
                        leftMinIndex++;
                        tempArrayIndex++;
                    }
                    else
                    {
                        tempArray[tempArrayIndex] = collection[rightMinIndex];
                        rightMinIndex++;
                        tempArrayIndex++;
                    }
                }

                while (leftMinIndex <= middle)
                {
                    tempArray[tempArrayIndex] = collection[leftMinIndex];
                    leftMinIndex++;
                    tempArrayIndex++;
                }

                while (rightMinIndex <= end)
                {
                    tempArray[tempArrayIndex] = collection[rightMinIndex];
                    rightMinIndex++;
                    tempArrayIndex++;
                }

                var leftIndex = start;
                var tempIndex = 0;

                while (tempIndex < tempArray.Length && leftIndex <= end)
                {
                    collection[leftIndex] = tempArray[tempIndex];
                    leftIndex++;
                    tempIndex++;
                }
            }
        }
    }
}
