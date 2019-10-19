namespace _10._SoftUniCoursePlanning
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var lessons = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                var input = Console.ReadLine().Split(":");
                if (input[0] == "course start")
                {
                    break;
                }

                var command = input[0];
                if (command == "Add" && !lessons.Contains(input[1]))
                {
                    lessons.Add(input[1]);
                }
                else if (command == "Insert" && !lessons.Contains(input[1]))
                {
                    lessons.Insert(int.Parse(input[2]), input[1]);
                }
                else if (command == "Remove" && lessons.Contains(input[1]))
                {
                    lessons.Remove(input[1]);
                    if (lessons.Contains($"{input[1]}-Exercise"))
                    {
                        lessons.Remove($"{input[1]}-Exercise");
                    }
                }
                else if (command == "Swap" && lessons.Contains(input[1]) && lessons.Contains(input[2]))
                {
                    var firstLesson = input[1];
                    var secondLesson = input[2];
                    var firstIndex = lessons.IndexOf(input[1]);
                    var secondIndex = lessons.IndexOf(input[2]);
                    lessons[firstIndex] = secondLesson;
                    lessons[secondIndex] = firstLesson;
                    if (lessons.Contains($"{input[1]}-Exercise"))
                    {
                        lessons.Remove($"{input[1]}-Exercise");
                        lessons.Insert(secondIndex + 1, $"{input[1]}-Exercise");
                    }
                    if (lessons.Contains($"{input[2]}-Exercise"))
                    {
                        lessons.Remove($"{input[2]}-Exercise");
                        lessons.Insert(firstIndex + 1, $"{input[2]}-Exercise");
                    }
                }
                else if (command == "Exercise" && !lessons.Contains($"{input[1]}-Exercise"))
                {
                    if (lessons.Contains(input[1]))
                    {
                        var index = lessons.IndexOf(input[1]);
                        lessons.Insert(index + 1, $"{input[1]}-Exercise");
                    }
                    else
                    {
                        lessons.Add(input[1]);
                        lessons.Add($"{input[1]}-Exercise");
                    }
                }
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }
    }
}
