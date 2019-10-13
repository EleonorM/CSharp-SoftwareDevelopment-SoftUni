namespace _02.Searching
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var searchedNumber = int.Parse(Console.ReadLine());
            var searcher = new Searcher(searchedNumber);
            Console.WriteLine(searcher.BinarySearcch(numbers, 0, numbers.Length - 1));
        }

        public class Searcher
        {
            private int searchedNumber;

            public Searcher(int searchhedNumber)
            {
                this.searchedNumber = searchhedNumber;
            }

            public int BinarySearcch(int[] array, int start, int end)
            {
                while (start <= end)
                {
                    var middle = (start + end) / 2;
                    if (array[middle] == searchedNumber)
                    {
                        return middle;
                    }
                    else if (array[middle] > searchedNumber)
                    {
                        end = middle - 1;
                    }
                    else
                    {
                        start = middle + 1;
                    }
                }

                return -1;
            }
        }
    }
}
