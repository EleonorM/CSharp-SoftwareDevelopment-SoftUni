namespace _01.ClassBoxData
{
    using _01.ClassBoxData.Models;
    using System;

    public class Engine
    {
        public void Run()
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine(box);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
