namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public class FinalizerParseResult : ParseResult<bool>
    {
        public FinalizerParseResult(bool canFinalize)
            : base( canFinalize )
        {
            this.TokenType = TokenType.Finalizer;
        }

        public override string ToDisplay()
        {
            return string.Empty;
        }
    }
}