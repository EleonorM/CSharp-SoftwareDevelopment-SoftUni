namespace _2._Point_in_Rectangle
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToList();
            var rectangle = new Rectangle();
           
            rectangle.BottomLeft.CoordinateX = rectangleCoordinates[0];
            rectangle.BottomLeft.CoordinateY = rectangleCoordinates[1];
            rectangle.TopRight.CoordinateX = rectangleCoordinates[2];
            rectangle.TopRight.CoordinateY = rectangleCoordinates[3];

            var rows = int.Parse(Console.ReadLine());
            for (int i = 0; i < rows; i++)
            {
                var point = Console.ReadLine().Split().Select(int.Parse).ToList();
                var searchedPoint = new Point { CoordinateX = point[0], CoordinateY = point[1] };
                Console.WriteLine(rectangle.Contains(searchedPoint)); 
            }
        }
    }
}
