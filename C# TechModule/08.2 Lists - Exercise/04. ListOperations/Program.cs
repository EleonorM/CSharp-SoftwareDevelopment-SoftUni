namespace _04._ListOperations
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Add")
                {
                    nums.Add(int.Parse(input[1]));
                }
                else if (input[0] == "Insert")
                {
                    var number = int.Parse(input[1]);
                    var index = int.Parse(input[2]);
                    if (index > nums.Count - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    nums.Insert(index, number);
                }
                else if (input[0] == "Remove")
                {
                    if (int.Parse(input[1]) > nums.Count - 1 || int.Parse(input[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    nums.RemoveAt(int.Parse(input[1]));
                }
                else if (input[0] == "Shift")
                {
                    if (input[1] == "left")
                    {
                        var count = int.Parse(input[2]);
                        if (count < 0)
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            var firstNum = nums[0];
                            nums.RemoveAt(0);
                            nums.Add(firstNum);
                        }
                    }
                    else if (input[1] == "right")
                    {
                        var count = int.Parse(input[2]);
                        if (count < 0)
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        for (int i = 0; i < count; i++)
                        {
                            var lastNum = nums[nums.Count - 1];
                            nums.RemoveAt(nums.Count - 1);
                            nums.Insert(0, lastNum);
                        }
                    }
                }

            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
