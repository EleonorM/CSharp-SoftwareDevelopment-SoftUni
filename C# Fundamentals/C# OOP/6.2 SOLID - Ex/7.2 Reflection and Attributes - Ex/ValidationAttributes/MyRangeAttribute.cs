namespace ValidationAttributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            try
            {
                var number = Convert.ToInt32(obj);
                if (number > minValue && number < maxValue)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw new ArgumentException("The input is not an integer!");
            }
        }
    }
}
