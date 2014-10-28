namespace Row13.RpnCalculator.Exceptions
{
    public class InvalidTokenException : RpnCalculatorException
    {
        public InvalidTokenException( string message )
            : base(message)
        {
        }
    }
}