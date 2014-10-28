using System;
using System.Globalization;
using Row13.RpnCalculator.Parsing.ParseResults;
using System.ComponentModel.Composition;

namespace Row13.RpnCalculator.Calculator
{
    public interface IExpressionBuilder
    {
        string Build(IParseResult result, bool previousPrecedence);
    }

    [Export(typeof(IExpressionBuilder))]
    public class ExpressionBuilder : IExpressionBuilder
    {
        public string Build(IParseResult result, bool previousPrecedence)
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
