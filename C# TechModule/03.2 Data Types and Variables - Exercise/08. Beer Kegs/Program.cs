namespace _08._Beer_Kegs
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            string nameOfTheBiggestKen = "";
            double biggestVolume = 0;
            for (int i = 0; i < num; i++)
            {
                string name = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double volume = Math.PI * radius * radius * height;
                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    nameOfTheBiggestKen = name;
                }
            }

            Console.WriteLine(nameOfTheBiggestKen);
        }
    }
}
