namespace _04.Own_Bussiness
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var width = int.Parse(Console.ReadLine());
            var lenght = int.Parse(Console.ReadLine());
            var height = int.Parse(Console.ReadLine());
            string countComputer;

            var space = width * lenght * height;
            var allComputers = 0;
            do
            {
                countComputer = Console.ReadLine();
                if (countComputer == "Done")
                    break;
                int countComParse = int.Parse(countComputer);
                space -= countComParse;
                if (space < 0)
                    break;
            } while (true);

            if (space > 0 && countComputer == "Done")
            {
                Console.WriteLine($"{space} Cubic meters left.");
            }
            else if (space < 0)
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(space)} Cubic meters more.");
            }
        }
    }
}
