using System;
using System.Collections.Generic;

namespace Row13.RpnCalculator.Operators
{
    public class OperandTokenProcessor : TokenProcessor<OperandParseResult>
    {
        public override Action ProcessToken( ITokenResult token, Stack<ITokenResult> currentTokens )
        {
            currentTokens.Push( token );

            return null;
        }
    }
}