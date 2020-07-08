namespace _03._RideTheHorse
{
    public class Position
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public int StepsToPosition { get; set; }

        public Position(int height, int width, int stepsToPosition = 1)
        {
            Height = height;
            Width = width;
            StepsToPosition = stepsToPosition;
        }
    }
}