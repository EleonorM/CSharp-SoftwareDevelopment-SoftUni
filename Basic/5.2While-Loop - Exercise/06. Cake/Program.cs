namespace _06.Cake
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var width = int.Parse(Console.ReadLine());
            var lenght = int.Parse(Console.ReadLine());
            var countPieces = width * lenght;
            var word = Console.ReadLine();
            while (word != "STOP")
            {
                var piece = int.Parse(word);
                countPieces -= piece;
                if (countPieces < 0)
                    break;
                word = Console.ReadLine();
            }

            if (word == "STOP" && countPieces >= 0)
            {
                Console.WriteLine($"{countPieces} pieces are left.");
            }

            if (countPieces < 0)
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(countPieces)} pieces more.");
            }
        }
    }
}
