namespace _06._BalancedBrackets
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            bool isBalanced = true;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                if (input == "(" && counter == 0)
                {
                    counter = 1;
                }
                else if (input == "(" && counter == 1)
                {
                    isBalanced = false;
                }
                else if (input == ")" && counter == 0)
                {
                    isBalanced = false;
                }
                else if (input == ")" && counter == 1)
                {
                    counter = 0;
                }
            }

            if (isBalanced && counter == 0)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
