namespace SIS.HTTP.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InternalServerErrorException : Exception
    {
        public const string InternalServerErrorDefaultMessage = "The Server has encountered an error.";
        public InternalServerErrorException() : this(InternalServerErrorDefaultMessage)
        {

        }

        public InternalServerErrorException(string name) : base(name)
        {

        }
    }
}
