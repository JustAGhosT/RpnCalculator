using System;
using System.Collections.Generic;
using Row13.RpnCalculator.Exceptions;

namespace Row13.RpnCalculator.Operators
{
    public class OperatorTokenProcessor : TokenProcessor<OperatorParseResult>
    {
        public override Action ProcessToken( ITokenResult token, Stack<ITokenResult> currentTokens )
        {
            var typedToken = (OperatorParseResult) token;

            var operand2 = currentTokens.Pop();
            var operand1 = currentTokens.Pop();

            if( !( operand1 is OperandParseResult ) )
            {
                throw new InvalidTokenException( String.Format( "Trying to perform {0} on invalid first operand",
                    token.GetType() ) );
            }

            var typedOperand1 = ( OperandParseResult )operand1;
            var typedOperand2 = ( OperandParseResult )operand2;

            var result = typedToken.Result.Eval( typedOperand1.Result, typedOperand2.Result );

            var operandParseResult = new OperandParseResult( result );

            currentTokens.Push( operandParseResult );

            return null;
        }
    }
}