namespace Row13.RpnCalculator.Exceptions
{
    using System;

    public class InvalidOperatorException : Exception
    {
        public InvalidOperatorException(string message) : base(message)
        {
        }
    }
}