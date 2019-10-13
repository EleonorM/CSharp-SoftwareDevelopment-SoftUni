namespace _4._Hotel_Reservation
{
    class PriceCalculator
    {
        public PriceCalculator(double price, int days, Season season)
        {
            this.PricePerHoliday = price;
            this.Days = days;
            this.Season = season;
            this.DiscountType = Discount.None;

        }

        public PriceCalculator(double price, int days, Season season, Discount discount)
        {
            this.PricePerHoliday = price;
            this.Days = days;
            this.Season = season;
            this.DiscountType = discount;
        }
        public double PricePerHoliday { get; set; }

        public int Days { get; set; }

        public Season Season { get; set; }

        public Discount DiscountType { get; set; }

        public double Calculate()
        {
            return PricePerHoliday * Days * (int)this.Season * (1 - (int)this.DiscountType * 0.01);
        }
    }

    public enum Season
    {
        Autumn = 1, Spring, Winter, Summer
    }

    public enum Discount
    {
        VIP = 20, SecondVisit = 10, None = 0
    }
}
