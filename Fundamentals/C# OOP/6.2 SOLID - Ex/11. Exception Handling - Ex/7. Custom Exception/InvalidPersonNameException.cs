using System;
using System.Runtime.Serialization;

namespace _7._Custom_Exception
{
    class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {
        }

        public InvalidPersonNameException(string message) : base(message)
        {
        }

        public InvalidPersonNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPersonNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
