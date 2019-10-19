namespace _08._AnonymousThreat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            while (true)
            {
                var command = Console.ReadLine().Split();
                if (command[0] == "3:1")
                {
                    break;
                }

                var startIndex = int.Parse(command[1]);
                var endIndex = int.Parse(command[2]);
                if (startIndex < 0 || startIndex > input.Count)
                {
                    startIndex = 0;
                }

                if (endIndex < 0 || endIndex >= input.Count)
                {
                    endIndex = input.Count - 1;
                }

                if (command[0] == "merge")
                {
                    for (int i = startIndex; i < endIndex; i++)
                    {
                        input[startIndex] = input[startIndex] + input[startIndex + 1];
                        input.RemoveAt(startIndex + 1);
                    }
                }
                else if (command[0] == "divide")
                {
                    var index = int.Parse(command[1]);
                    var portions = int.Parse(command[2]);
                    var dividedPart = input[index].ToCharArray();


                    if (portions > 0 && dividedPart.Length % portions == 0)
                    {
                        string temp = "";
                        for (int i = dividedPart.Length - 1; i >= 0; i--)
                        {

                            temp += dividedPart[i];
                            if (i % (dividedPart.Length / portions) == 0)
                            {
                                char[] charArray = temp.ToCharArray();
                                Array.Reverse(charArray);
                                temp = new string(charArray);
                                input.Insert(index + 1, temp);
                                temp = "";
                            }
                        }

                        input.RemoveAt(index);
                    }
                    else
                    {
                        var list = new List<string>();
                        string temp = "";
                        if (portions > dividedPart.Length || portions < 1)
                        {
                            list.Add(input[index]);
                        }
                        else
                        {
                            for (int i = 0; i < dividedPart.Length; i++)
                            {
                                temp += dividedPart[i];
                                if (((i + 1) % (dividedPart.Length / portions) == 0 && list.Count < portions - 1) || i == dividedPart.Length - 1)
                                {
                                    list.Add(temp);
                                    temp = "";
                                }
                            }
                        }

                        list.Reverse();
                        input.RemoveAt(index);
                        for (int i = 0; i < list.Count; i++)
                        {
                            input.Insert(index, list[i]);
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
