using System;

namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public class ExpressionParseResult : ParseResult<ResultExpression>
    {
        public ExpressionParseResult(ResultExpression result)
            : base(result)
        {
            TakesPrecedence = Result.Operator.TakesPrecedence;
        }
    }

    public class ResultExpression
    {
        public Tuple<IParseResult, IParseResult> Expressions { get; set; } 
        public IParseResult Operator { get; set; }
    }
}
