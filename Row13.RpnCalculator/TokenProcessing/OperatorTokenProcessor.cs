using System;
using System.Collections.Generic;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.TokenProcessing
{
    using Row13.RpnCalculator.Output;

    public class OperatorTokenProcessor : TokenProcessor<OperatorParseResult>
    {
        public override Action ProcessToken(IParseResult token, Stack<IParseResult> currentTokens, IOutputProcessor outputProcessor)
        {
            var typedToken = (OperatorParseResult) token;

            IParseResult operand2 = currentTokens.Pop();
            IParseResult operand1 = currentTokens.Pop();

            if( !( operand1 is OperandParseResult ) )
            {
                throw new InvalidTokenException( String.Format( "Trying to perform {0} on invalid first operand",
                    token.GetType() ) );
            }

            var typedOperand1 = ( OperandParseResult )operand1;
            var typedOperand2 = ( OperandParseResult )operand2;

            double result = typedToken.Result.Eval( typedOperand1.Result, typedOperand2.Result );

            var operandParseResult = new OperandParseResult( result );

            currentTokens.Push( operandParseResult );

            return null;
        }
    }
}