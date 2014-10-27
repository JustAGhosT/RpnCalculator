namespace Row13.RpnCalculator.Operators
{
    public class OperandParseResult : TokenResult<double>
    {
        public OperandParseResult( double result )
            : base( result )
        {
            TokenType = TokenType.Operator;
        }
    }
}