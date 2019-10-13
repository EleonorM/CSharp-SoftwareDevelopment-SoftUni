namespace CustomTestingFramework.Exceptions
{
    using System;

    public class TestException : Exception
    {
        public TestException()
        {
        }

        public TestException(string message) : base(message)
        {
        }
    }
}
