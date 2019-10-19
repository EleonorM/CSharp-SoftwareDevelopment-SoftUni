namespace _11._Refactor_Volume_of_Pyramid
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double V = 0;
            Console.Write("Length: ");
            double lenght = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            double height = double.Parse(Console.ReadLine());
            V = (lenght * width * height) / 3.0;
            Console.WriteLine("Pyramid Volume: {0:F2}", V);
        }
    }
}
