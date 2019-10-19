namespace _02._ChangeList
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                var inputString = input.Split();
                if (inputString[0] == "Delete")
                {
                    var num = int.Parse(inputString[1]);
                    list.RemoveAll(x => x == num);
                }
                else if (inputString[0] == "Insert")
                {
                    var element = int.Parse(inputString[1]);
                    var position = int.Parse(inputString[2]);
                    list.Insert(position, element);
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
