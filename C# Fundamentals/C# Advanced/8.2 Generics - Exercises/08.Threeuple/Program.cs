namespace _08.Threeuple
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var town = input.Skip(3).ToArray();
            var tuple1 = new Tuple<string, string, string>(input[0] + " " + input[1], input[2], string.Join(" ", town));
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            var drunkIndicator = false;
            if (input[2] == "drunk")
            {
                drunkIndicator = true;
            }

            var tuple2 = new Tuple<string, int, bool>(input[0], int.Parse(input[1]), drunkIndicator);
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            var tuple3 = new Tuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
            Console.WriteLine(tuple3);
        }
    }
}
