using System;

namespace Row13.RpnCalculator.Parsing.ParseResults
{
    using Row13.RpnCalculator.Operators;

    public class ExpressionParseResult : ParseResult<ResultExpression>
    {
        public ExpressionParseResult(ResultExpression result)
            : base(result)
        {
        }

        public override string ToDisplay()
        {  
            var result = Result.Expressions.Item1.ToDisplay() + Result.Operator.ToDisplay()
                         + Result.Expressions.Item2.ToDisplay();
            var precedence = ((OperatorParseResult)Result.Operator).Result.Precedence;
            if (precedence == 0)
            {
                return "(" + result + ")";
            }

            return result;
        }


    }

    public class ResultExpression
    {
        public Tuple<IParseResult, IParseResult> Expressions { get; set; } 
        public IParseResult Operator { get; set; }
    }
}
