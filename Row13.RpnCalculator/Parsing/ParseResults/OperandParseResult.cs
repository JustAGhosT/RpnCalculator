using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Parsing.ParseResults
{
    using System.Globalization;

    public class OperandParseResult : ParseResult<double>
    {
        public OperandParseResult( double result )
            : base( result )
        {
            this.TokenType = TokenType.Operand;
        }
    }
}