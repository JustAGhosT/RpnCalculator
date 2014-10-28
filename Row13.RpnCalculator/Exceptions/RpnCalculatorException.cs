using System;

namespace Row13.RpnCalculator.Exceptions
{
    public class RpnCalculatorException : Exception
    {
        public RpnCalculatorException(string message)
            : base(message)
        {
        }
    }
}
