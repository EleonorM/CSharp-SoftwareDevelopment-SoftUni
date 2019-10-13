using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Implement_Binary_Search
{
    public class BinarySearch
    {
        public int IndexOf(int[] array, int key)
        {
            int lo = 0;
            int hi = array.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;

                if (key < array[mid])
                {
                    hi = mid - 1;
                }
                else if (key > array[mid])
                {
                    lo = mid - 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
