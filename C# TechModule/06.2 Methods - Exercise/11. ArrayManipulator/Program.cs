namespace _11._ArrayManipulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    Console.WriteLine($"[{string.Join(", ", array)}]");
                    return;
                }

                var token = input.Split();
                var command = token[0];
                if (command == "exchange")
                {
                    var newArray = Exchange(array, int.Parse(token[1]));
                    array = newArray;
                }
                else if (command == "max")
                {
                    MaxNumber(array, token[1]);
                }
                else if (command == "min")
                {
                    MinNumber(array, token[1]);
                }
                else if (command == "first")
                {
                    FirsElemets(array, long.Parse(token[1]), token[2]);
                }
                else if (command == "last")
                {
                    LastElemets(array, long.Parse(token[1]), token[2]);
                }
            }
        }

        static int[] Exchange(int[] array, int keyNum)
        {
            var reversedNums = new int[array.Length];
            if (keyNum >= array.Length || keyNum < 0)
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (keyNum + i + 1 < array.Length)
                {
                    reversedNums[i] = array[keyNum + i + 1];
                }
                else
                {
                    reversedNums[i] = array[-array.Length + 1 + keyNum + i];
                }
            }

            return reversedNums;
        }

        static void MaxNumber(int[] array, string type)
        {
            int maxPosition = -1;
            int maxNumber = int.MinValue;
            if (type == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] >= maxNumber)
                    {
                        maxNumber = array[i];
                        maxPosition = i;
                    }
                }
            }
            else if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] >= maxNumber)
                    {
                        maxPosition = i;
                        maxNumber = array[i];
                    }
                }
            }

            if (maxPosition != -1)
            {
                Console.WriteLine(maxPosition);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void MinNumber(int[] array, string type)
        {
            int minPosition = -1;
            int minNumber = int.MaxValue;
            if (type == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && array[i] <= minNumber)
                    {
                        minNumber = array[i];
                        minPosition = i;
                    }
                }
            }
            else if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && array[i] <= minNumber)
                    {
                        minPosition = i;
                        minNumber = array[i];
                    }
                }
            }

            if (minPosition != -1)
            {
                Console.WriteLine(minPosition);
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }

        static void FirsElemets(int[] array, long count, string type)
        {
            if (count > array.Length || count < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var counter = 0;
            var result = new List<int>();
            if (type == "odd")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 != 0 && counter < count)
                    {
                        result.Add(array[i]);
                        counter++;
                    }
                }
            }
            else if (type == "even")
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0 && counter < count)
                    {
                        result.Add(array[i]);
                        counter++;
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
        static void LastElemets(int[] array, long count, string type)
        {
            if (count > array.Length || count < 0)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var counter = 0;
            var result = new List<int>();
            if (type == "odd")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 != 0 && counter < count)
                    {
                        result.Add(array[i]);
                        counter++;
                    }
                }
            }
            else if (type == "even")
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == 0 && counter < count)
                    {
                        result.Add(array[i]);
                        counter++;
                    }
                }
            }

            result.Reverse();
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}
