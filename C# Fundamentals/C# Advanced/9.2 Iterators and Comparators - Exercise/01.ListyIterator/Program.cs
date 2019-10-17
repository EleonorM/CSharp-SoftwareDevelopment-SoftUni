namespace _01.ListyIterator
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            ListyIterator<string> list = null;
            while (true)
            {
                try
                {
                    var action = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (action[0] == "END")
                    {
                        break;
                    }

                    if (action[0] == "Create")
                    {
                        try
                        {
                            var numbers = action.Skip(1).ToList();
                            list = new ListyIterator<string>(numbers);
                        }
                        catch
                        {
                            list = new ListyIterator<string>();
                        }
                    }
                    else if (action[0] == "Move")
                    {
                        Console.WriteLine(list.Move());
                    }
                    else if (action[0] == "HasNext")
                    {
                        Console.WriteLine(list.HasNext());
                    }
                    else if (action[0] == "Print")
                    {
                        list.Print();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
