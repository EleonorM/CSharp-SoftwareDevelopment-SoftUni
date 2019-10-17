namespace _1.Logger.Exceptions
{
    using System;

    public class InvalidDateFormatException : Exception
    {
        private const string EXC_MESSAGE = "Invalid Datetime Format!";

        public InvalidDateFormatException() 
            : base(EXC_MESSAGE)
        {
        }

        public InvalidDateFormatException(string message) 
            : base(message)
        {
        }
    }
}
