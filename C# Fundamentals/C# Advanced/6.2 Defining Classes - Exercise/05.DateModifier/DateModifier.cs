namespace _05.DateModifier
{
    using System;
    using System.Linq;

    public class DateModifier
    {
        public DateTime FirstDate { get; set; }

        public DateTime SecondDate { get; set; }

        public double CalculateDifference(string firstDateAsString, string secondDateAsString)
        {
            FirstDate = Convert.ToDateTime(firstDateAsString);
            SecondDate = Convert.ToDateTime(secondDateAsString);
            return Math.Abs((SecondDate - FirstDate).TotalDays);
        }
    }
}
