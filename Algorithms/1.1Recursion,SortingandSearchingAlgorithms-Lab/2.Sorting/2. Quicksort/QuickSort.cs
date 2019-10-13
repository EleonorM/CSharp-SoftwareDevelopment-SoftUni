namespace _2._Quicksort
{
    using System;

    public class QuickSort<T>
          where T : IComparable
    {

        public void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(T[] array, int lo, int hi)
        {
            if (lo >= hi)
            {
                return;
            }

            int p = Partition(array, lo, hi);
            Sort(array, lo, p - 1);
            Sort(array, p + 1, hi);
        }

        private static int Partition(T[] array, int lo, int hi)
        {
            if (lo >= hi)
            {
                return lo;
            }

            int i = lo;
            int j = hi + 1;
            while (true)
            {
                while (array[++i].CompareTo(array[lo]) < 0)
                {
                    if (i == hi)
                    {
                        break;
                    }
                }

                while (array[lo].CompareTo(array[--j]) < 0)
                {
                    if (j == lo)
                    {
                        break;
                    }
                }

                if (i >= j)
                {
                    break;
                }
                Swap(ref array, i, j);
            }

            Swap(ref array, lo, j);
            return i;
        }

        private static void Swap(ref T[] arr, int indexA, int indexB)
        {
            var temp = arr[indexA];
            arr[indexA] = arr[indexB];
            arr[indexB] = temp;
        }
    }
}
