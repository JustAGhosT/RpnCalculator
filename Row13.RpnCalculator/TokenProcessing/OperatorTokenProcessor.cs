using System;
using System.Collections.Generic;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.TokenProcessing
{
    using Row13.RpnCalculator.Output;

    public class OperatorTokenProcessor : TokenProcessor<OperatorParseResult>
    {
        public override Action ProcessToken(IParseResult token, Stack<IParseResult> resultTokens, Stack<IParseResult> expressionTokens, IOutputProcessor outputProcessor)
        {
            ProcessedTokenCount++;

            //process result
            var typedToken = (OperatorParseResult) token;
            IParseResult operand2 = resultTokens.Pop();
            IParseResult operand1 = resultTokens.Pop();

            if( !( operand1 is OperandParseResult ) )
            {
                throw new InvalidTokenException( String.Format( "Trying to perform {0} on invalid first operand",
                    token.GetType() ) );
            }

            var typedOperand1 = ( OperandParseResult )operand1;
            var typedOperand2 = ( OperandParseResult )operand2;

            double result = typedToken.Result.Eval( typedOperand1.Result, typedOperand2.Result );

            var operandParseResult = new OperandParseResult( result );

            resultTokens.Push(operandParseResult);

            //process expression
            IParseResult operandRight = expressionTokens.Pop();
            IParseResult operandLeft = expressionTokens.Pop();
            var expr = new ResultExpression
                           {
                               Expressions = Tuple.Create(operandLeft, operandRight),
                               Operator = typedToken
                           };
            expressionTokens.Push(new ExpressionParseResult(expr));

            return null;
        }
    }
}