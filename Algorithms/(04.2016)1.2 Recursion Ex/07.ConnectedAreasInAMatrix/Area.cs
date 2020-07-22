namespace _07.ConnectedAreasInAMatrix
{
    using System;

    public class Area : IComparable<Area>
    {
        public int PositionRow { get; set; }

        public int PositionCol { get; set; }

        public int Size { get; set; }

        public int CompareTo(Area obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var area = obj;
            return Size.CompareTo(area.Size);
        }
    }
}
