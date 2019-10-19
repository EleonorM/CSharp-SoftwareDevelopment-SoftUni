namespace _05._DrumSet
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var savings = double.Parse(Console.ReadLine());
            var startedDrumSet = Console.ReadLine().Split().Select(int.Parse).ToList();
            var drumSetArr = new int[startedDrumSet.Count];
            startedDrumSet.CopyTo(drumSetArr, 0);
            var drumSet = drumSetArr.ToList();
            var input = string.Empty;
            while ((input = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                var power = int.Parse(input);
                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= power;
                    if (drumSet[i] <= 0 && savings - startedDrumSet[i] * 3.0 >= 0)
                    {
                        drumSet[i] = startedDrumSet[i];
                        savings -= startedDrumSet[i] * 3.0;
                    }
                }
            }

            drumSet = drumSet.Where(x => x > 0).ToList();

            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
