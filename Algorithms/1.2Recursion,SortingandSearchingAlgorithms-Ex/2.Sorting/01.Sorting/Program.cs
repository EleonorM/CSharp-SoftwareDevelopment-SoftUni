namespace _01.Sorting
{
    using System;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var sorter = new Sorter();
            if (numbers.Length < 200)
            {
                sorter.MergeSort(numbers);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < numbers.Length; i++)
                {
                    builder.Append(numbers[i] + " ");
                }
                Console.WriteLine(builder.ToString());
            }
            else
            {
                sorter.ShellSort(numbers);
                Console.WriteLine(string.Join(" ", numbers));
            }
        }

        public class Sorter
        {
            private static int[] helperArray;
            public void MergeSort(int[] array)
            {
                helperArray = new int[array.Length];
                Sort(array, 0, array.Length - 1);
            }

            private static void Sort(int[] array, int startIndex, int endIndex)
            {
                if (startIndex >= endIndex)
                {
                    return;
                }

                var middleIndex = (startIndex + endIndex) / 2;
                Sort(array, startIndex, middleIndex);
                Sort(array, middleIndex + 1, endIndex);
                Merge(array, startIndex, middleIndex, endIndex);
            }

            private static void Merge(int[] array, int startIndex, int middleIndex, int endIndex)
            {
                if (middleIndex < 0
                    || middleIndex + 1 > array.Length
                    || array[middleIndex] < array[middleIndex + 1])
                {
                    return;
                }

                Array.Copy(array, helperArray, array.Length);

                var leftIndex = startIndex;
                var rightIndex = middleIndex + 1;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (leftIndex > middleIndex)
                    {
                        array[i] = helperArray[rightIndex++];
                    }
                    else if (rightIndex > endIndex)
                    {
                        array[i] = helperArray[leftIndex++];
                    }
                    else if (helperArray[leftIndex].CompareTo(helperArray[rightIndex]) > 0)
                    {
                        array[i] = helperArray[rightIndex++];
                    }
                    else
                    {
                        array[i] = helperArray[leftIndex++];
                    }
                }
            }

            public void ShellSort(int[] array)
            {
                int n = array.Length;
                int gap = n / 2;
                int temp;

                while (gap > 0)
                {
                    for (int i = 0; i + gap < n; i++)
                    {
                        int j = i + gap;
                        temp = array[j];

                        while (j - gap >= 0 && temp < array[j - gap])
                        {
                            array[j] = array[j - gap];
                            j = j - gap;
                        }

                        array[j] = temp;
                    }

                    gap = gap / 2;
                }
            }
        }
    }
}
