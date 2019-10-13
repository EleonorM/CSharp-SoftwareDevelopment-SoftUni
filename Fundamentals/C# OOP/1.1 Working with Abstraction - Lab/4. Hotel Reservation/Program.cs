namespace _4._Hotel_Reservation
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            var price = double.Parse(input[0]);
            var days = int.Parse(input[1]);
            var seasonAsString = input[2];
            var season = new Season();

            if (seasonAsString == "Winter")
            {
                season = Season.Winter;
            }
            else if (seasonAsString == "Summer")
            {
                season = Season.Summer;
            }
            else if (seasonAsString == "Spring")
            {
                season = Season.Spring;
            }
            else if (seasonAsString == "Autumn")
            {
                season = Season.Autumn;
            }
            var calculator = new PriceCalculator(price, days, season);
            var totalPrice = calculator.Calculate();
            try
            {
                var discountAsString = input[3];
                var discount = new Discount();
                if (discountAsString == "VIP")
                {
                    discount = Discount.VIP;
                }
                else if (discountAsString == "SecondVisit")
                {
                    discount = Discount.SecondVisit;
                }
                else
                {
                    discount = Discount.None;
                }
                calculator.DiscountType = discount;

                totalPrice = calculator.Calculate();
            }
            catch
            {
            }
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
