namespace _07._ListManipulationAdvanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            bool toPrint = false;
            List<string> command = Console.ReadLine().Split(' ').ToList();
            while (command[0] != "end")
            {
                if (command[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(command[1])))
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                        Console.WriteLine("No such number");
                }
                else if (command[0] == "PrintEven")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 == 0)));
                }
                else if (command[0] == "PrintOdd")
                {
                    Console.WriteLine(string.Join(" ", numbers.Where(n => n % 2 != 0)));
                }
                else if (command[0] == "GetSum")
                {
                    Console.WriteLine(numbers.Sum());
                }
                else if (command[0] == "Filter")
                {
                    if (command[1] == ">")
                    {
                        Console.WriteLine(string.Join(" ", IsBigger(numbers, command)));
                    }
                    else if (command[1] == "<")
                    {
                        Console.WriteLine(string.Join(" ", IsLower(numbers, command)));
                    }
                    else if (command[1] == "<=")
                    {
                        Console.WriteLine(string.Join(" ", IsLowest(numbers, command)));
                    }
                    else if (command[1] == ">=")
                    {
                        Console.WriteLine(string.Join(" ", IsBiggest(numbers, command)));
                    }
                }
                else if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                    toPrint = true;
                }
                else if (command[0] == "Remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                    toPrint = true;
                }
                else if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                    toPrint = true;
                }
                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    toPrint = true;
                }

                command = Console.ReadLine().Split(' ').ToList();
            }

            if (toPrint)
                Console.WriteLine(string.Join(" ", numbers));
        }

        public static List<int> IsBigger(List<int> number, List<string> command)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] > int.Parse(command[2]))
                {
                    result.Add(number[i]);
                }
            }

            return result;
        }
        public static List<int> IsLowest(List<int> number, List<string> command)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] <= int.Parse(command[2]))
                {
                    result.Add(number[i]);
                }
            }

            return result;
        }
        public static List<int> IsBiggest(List<int> number, List<string> command)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] >= int.Parse(command[2]))
                {
                    result.Add(number[i]);
                }
            }

            return result;
        }
        public static List<int> IsLower(List<int> number, List<string> command)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] < int.Parse(command[2]))
                {
                    result.Add(number[i]);
                }
            }

            return result;
        }
    }
}
