using System;

namespace Row13.RpnCalculator.Exceptions
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException( string message )
            : base(message)
        {
        }
    }
}