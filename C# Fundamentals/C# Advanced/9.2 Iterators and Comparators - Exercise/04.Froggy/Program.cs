namespace _04.Froggy
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var lake = new Lake(numbers);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
