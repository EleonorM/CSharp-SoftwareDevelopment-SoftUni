namespace _1._Merge_Sort
{
    using System;

    public class MergeSort<T>
          where T : IComparable
    {
        private static T[] helpArray;

        public void Sort(T[] array)
        {
            helpArray = new T[array.Length];
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(T[] array, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }
            var mid = (lo + hi) / 2;
            Sort(array, lo, mid);
            Sort(array, mid + 1, hi);
            Merge(array, lo, mid, hi);
        }

        private static void Merge(T[] array, int lo, int mid, int hi)
        {
            if (mid < 0
                || mid + 1 >= array.Length
                || array[mid].CompareTo(array[mid + 1]) < 0)
            {
                return;
            }

            for (int i = lo; i <= hi; i++)
            {
                helpArray[i] = array[i];
            }

            int leftIndex = lo;
            int rightIndex = mid + 1;
            for (int index = lo; index < hi + 1; index++)
            {
                if (leftIndex > mid)
                {
                    array[index] = helpArray[rightIndex++];
                }
                else if (rightIndex > hi)
                {
                    array[index] = helpArray[leftIndex++];
                }
                else if (helpArray[leftIndex].CompareTo(helpArray[rightIndex]) < 0)
                {
                    array[index] = helpArray[leftIndex++];
                }
                else
                {
                    array[index] = helpArray[rightIndex++];
                }
            }
        }
    }
}
