namespace Row13.RpnCalculator.Exceptions
{
    public class InvalidResultException : RpnCalculatorException
    {
        public InvalidResultException(string message)
            : base(message)
        {
        }
    }
}