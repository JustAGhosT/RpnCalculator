using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.TokenProcessing
{
    using System.Globalization;

    public class FinalizerTokenProcessor : TokenProcessor<FinalizerParseResult>
    {
        public override Action ProcessToken(IParseResult token, Stack<IParseResult> resultTokens, Stack<IParseResult> expressionTokens, IOutputProcessor outputProcessor)
        {
            ProcessedTokenCount++;

            IParseResult result = resultTokens.Pop();

            if (resultTokens.Any())
            {
                throw new PrematureFinalizationException( "Finalization was attempted before processing has completed" );
            }

            if( !( result is OperandParseResult ) )
            {
                throw new InvalidResultException( "Finalization attempted while the stack contains an operand tokentype" );
            }

            var parsedResult = ( OperandParseResult )result;
            var expression = (ExpressionParseResult)expressionTokens.Pop();
            var expressionDisplay = BuildDisplay(expression);

            return outputProcessor.Write(parsedResult.Result, expressionDisplay);
        }

        private string BuildDisplay(ExpressionParseResult expression)
        {
            return Build(expression, false);
        }

        private string Build(IParseResult result, bool previousPrecedence)
        {
            var parsedResult = result as OperandParseResult;
            if (parsedResult != null)
            {
                return parsedResult.Result.ToString(CultureInfo.InvariantCulture);
            }

            var expressionResult = result as ExpressionParseResult;
            if (expressionResult != null)
            {
                string toReturn = this.Build(expressionResult.Result.Expressions.Item1, expressionResult.TakesPrecedence)
                                  + ((OperatorParseResult)expressionResult.Result.Operator).Result.ProcessedToken
                                  + this.Build(expressionResult.Result.Expressions.Item2, expressionResult.TakesPrecedence);
                if (Convert.ToInt32(expressionResult.TakesPrecedence) < Convert.ToInt32(previousPrecedence))
                {
                    toReturn = '(' + toReturn + ')';
                }
                return toReturn;
            }

            return String.Empty;
        }
    }
}