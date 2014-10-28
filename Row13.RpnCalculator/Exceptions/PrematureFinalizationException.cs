using System;

namespace Row13.RpnCalculator.Exceptions
{
    public class PrematureFinalizationException : RpnCalculatorException
    {
        public PrematureFinalizationException( string message )
            : base( message )
        {
        }
    }
}