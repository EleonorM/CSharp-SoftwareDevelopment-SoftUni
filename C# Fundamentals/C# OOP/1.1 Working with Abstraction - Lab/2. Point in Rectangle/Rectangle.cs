namespace _2._Point_in_Rectangle
{
    public class Rectangle
    {
        public Rectangle()
        {
            this.TopRight = new Point();
            this.BottomLeft = new Point();
        }
        public Point BottomLeft { get; set; }
        public Point TopRight { get; set; }

        public bool Contains(Point point)
        {
            if (point.CoordinateX >= this.BottomLeft.CoordinateX && 
                point.CoordinateX <= this.TopRight.CoordinateX && 
                point.CoordinateY <= this.TopRight.CoordinateY && 
                point.CoordinateY >= this.BottomLeft.CoordinateY)
            {
                return true;
            }
            return false;
        }
    }
}
