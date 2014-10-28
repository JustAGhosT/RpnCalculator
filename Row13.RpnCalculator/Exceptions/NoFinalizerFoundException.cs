namespace Row13.RpnCalculator.Exceptions
{
    public class NoFinalizerFoundException : RpnCalculatorException
    {
        public NoFinalizerFoundException(string message)
            : base(message)
        {
        }
    }
}
