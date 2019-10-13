namespace _1.Logger.Factory
{
    using _1.Logger.Exceptions;
    using _1.Logger.Models.Contracts;
    using _1.Logger.Models.Enumerations;
    using _1.Logger.Models.Errors;
    using System;
    using System.Globalization;

    public class ErrorFactory
    {
        private const string DateFormat = "M/dd/yyyy h:mm:ss tt";

        public IError GetError(string dateString, string levelString, string message)
        {
            Level level;
            var hasPrsed = Enum.TryParse<Level>(levelString, out level);
            if (!hasPrsed)
            {
                throw new InvalidLevelTypeException();
            }

            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(dateString, DateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new InvalidDateFormatException();
            }

            return new Error(dateTime, message, level);
        }
    }
}
