namespace SIS.HTTP.Exceptions
{
    using System;

    public class BadRequestException : Exception
    {
        private const string BadRequestExceptionDefaultMEssage = "The Request was malformed or contains unsupported elements.";

        public BadRequestException() : this(BadRequestExceptionDefaultMEssage)
        {

        }
        public BadRequestException(string name) : base(name)
        {

        }
    }
}
