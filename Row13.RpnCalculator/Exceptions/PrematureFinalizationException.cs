using System;

namespace Row13.RpnCalculator.Exceptions
{
    public class PrematureFinalizationException : Exception
    {
        public PrematureFinalizationException( string message )
            : base( message )
        {
        }
    }
}