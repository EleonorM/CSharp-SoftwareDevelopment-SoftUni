namespace _02._A_Miner_Task
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var dic = new Dictionary<string, int>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "stop")
                {
                    break;
                }
                var value = int.Parse(Console.ReadLine());

                if (dic.ContainsKey(input))
                {
                    dic[input] += value;
                }
                else
                {
                    dic[input] = value;
                }
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
