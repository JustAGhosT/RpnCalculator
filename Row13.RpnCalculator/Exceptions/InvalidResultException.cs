using System;

namespace Row13.RpnCalculator.Exceptions
{
    public class InvalidResultException : Exception
    {
        public InvalidResultException( string message )
            : base( message )
        {
        }
    }
}