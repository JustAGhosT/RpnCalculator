using System;
using System.Collections.Generic;
using Row13.RpnCalculator.Exceptions;

namespace Row13.RpnCalculator.Operators
{
    public class OperatorParseResult : TokenResult<IOperator>
    {
        public OperatorParseResult( IOperator @operator )
            : base( @operator )
        {
            TokenType = TokenType.Operator;
        }
    }
}