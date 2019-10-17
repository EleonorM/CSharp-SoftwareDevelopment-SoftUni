namespace _05._Fashion_Boutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var capacity = int.Parse(Console.ReadLine());
            var clothes = new Stack<int>(input);
            var rack = 1;
            var sum = 0;
            while (true)
            {
                if (clothes.Count == 0)
                {
                    break;
                }
                else if (sum + clothes.Peek() <= capacity)
                {
                    sum += clothes.Pop();
                }
                else if (clothes.Count != 0)
                {
                    rack++;
                    sum = 0;
                }
            }

            Console.WriteLine(rack);
        }
    }
}
