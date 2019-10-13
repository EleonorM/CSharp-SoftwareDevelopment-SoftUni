namespace _06.Ticket_Combination
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var combinationWinnig = int.Parse(Console.ReadLine());
            var counter = 0;
            for (int x1 = 66; x1 <= 76; x1 += 2)
            {
                for (char x2 = 'f'; x2 >= 'a'; x2--)
                {
                    for (char x3 = 'A'; x3 <= 'C'; x3++)
                    {
                        for (int x4 = 1; x4 <= 10; x4++)
                        {
                            for (int x5 = 10; x5 >= 1; x5--)
                            {
                                var sum = x1 + (int)x2 + (int)x3 + x4 + x5;
                                counter++;
                                if (counter == combinationWinnig)
                                {
                                    Console.WriteLine($"Ticket combination: {(char)x1}{x2}{x3}{x4}{x5}");
                                    Console.WriteLine($"Prize: {sum} lv.");
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
