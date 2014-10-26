namespace Row13.RpnCalculator.Tests
{
    using System;

    public class InvalidOperatorException : Exception
    {
        public InvalidOperatorException(string message) : base(message)
        {
        }
    }
}