namespace Row13.RpnCalculator.Operators
{
    public class FinalizerParseResult : TokenResult<bool>
    {
        public FinalizerParseResult(bool canFinalize)
            : base( canFinalize )
        {
            TokenType = TokenType.Finalizer;
        }
    }
}