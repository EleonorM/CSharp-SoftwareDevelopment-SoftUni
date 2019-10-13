namespace _03.InversionCount
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var counter = new InvokeCounter(numbers);
            Console.WriteLine(counter.Count);
        }

        public class InvokeCounter
        {
            private static int[] helperArray;

            public InvokeCounter(int[] array)
            {
                helperArray = new int[array.Length];
                Count= Sort(array, 0, array.Length - 1);
            }

            public int Count { get; private set; }

            private static int Sort(int[] array, int startIndex, int endIndex)
            {
                var invCount = 0;
                if (startIndex < endIndex)
                {
                    var middleIndex = (startIndex + endIndex) / 2;
                    invCount += Sort(array, startIndex, middleIndex);
                    invCount += Sort(array, middleIndex + 1, endIndex);
                    invCount += Merge(array, startIndex, middleIndex, endIndex);
                }

                return invCount;
            }

            private static int Merge(int[] array, int startIndex, int middleIndex, int endIndex)
            {
                int leftIndex, rightIndex, counter;

                int invCount = 0;

                leftIndex = startIndex;
                rightIndex = middleIndex;
                counter = startIndex;

                while ((leftIndex <= middleIndex - 1) && (rightIndex <= endIndex))
                {
                    if (array[leftIndex] <= array[rightIndex])
                    {
                        helperArray[counter++] = array[leftIndex++];
                    }
                    else
                    {
                        helperArray[counter++] = array[rightIndex++];
                        invCount += middleIndex - leftIndex;
                    }
                }

                while (leftIndex <= middleIndex - 1)
                {
                    helperArray[counter++] = array[leftIndex++];
                }

                while (rightIndex <= endIndex)
                {
                    helperArray[counter++] = array[rightIndex++];
                }

                Array.Copy(array, helperArray, array.Length);
                return invCount;
            }
        }
    }
}
