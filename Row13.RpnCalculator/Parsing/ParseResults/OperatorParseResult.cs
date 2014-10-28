using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public class OperatorParseResult : ParseResult<IOperator>
    {
        public OperatorParseResult(IOperator @operator)
            : base(@operator)
        {
            this.TokenType = TokenType.Operator;
        }
    }
}