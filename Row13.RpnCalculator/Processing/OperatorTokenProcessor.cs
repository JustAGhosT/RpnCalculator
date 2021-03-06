﻿using System;
using System.Collections.Generic;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Processing
{
    public class OperatorTokenProcessor : TokenProcessor<OperatorParseResult>
    {
        public override Action ProcessToken(IParseResult token, Stack<IParseResult> resultTokens, IOutputProcessor outputProcessor)
        {
            ProcessedTokenCount++;

            //process result
            var typedToken = ( OperatorParseResult )token;
            IParseResult operandRight = resultTokens.Pop();
            IParseResult operandLeft = resultTokens.Pop();

            if( operandLeft == null)
            {
                throw new InvalidTokenException(String.Format("Trying to perform {0} on invalid first operand",
                    token.GetType()));
            } 
            
            if( operandRight == null )
            {
                throw new InvalidTokenException( String.Format( "Trying to perform {0} on invalid second operand",
                    token.GetType() ) );
            }

            double leftResult = GetResult(operandLeft);
            double rightResult = GetResult( operandRight);

            double result = typedToken.Result.Eval( leftResult, rightResult );

            var expr = new ResultExpression
            {
                Expressions = Tuple.Create( operandLeft, operandRight ),
                Operator = typedToken,
                Result = result
            };
            resultTokens.Push( new ExpressionParseResult( expr ) );

            return null;
        }

        private static double GetResult(IParseResult parseResult)
        {
            var result = 0D;

            var operandResult = parseResult as OperandParseResult;
            if( operandResult != null )
            {
                result = operandResult.Result;
            }
            var expressionResult = parseResult as ExpressionParseResult;
            if( expressionResult != null )
            {
                result = expressionResult.Result.Result;
            }
            return result;
        }
    }
}