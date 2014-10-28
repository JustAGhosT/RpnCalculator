namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public class OperandParseResult : ParseResult<double>
    {
        public OperandParseResult(double result)
            : base(result)
        {
            TokenType = TokenType.Operand;
        }
    }
}