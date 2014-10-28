using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public class FinalizerParseResult : ParseResult<bool>
    {
        public FinalizerParseResult(bool canFinalize)
            : base( canFinalize )
        {
            this.TokenType = TokenType.Finalizer;
        }
    }
}