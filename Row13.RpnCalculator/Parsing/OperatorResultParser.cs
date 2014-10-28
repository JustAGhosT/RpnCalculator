using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Row13.RpnCalculator.Operators;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    public class OperatorResultParser : ResultParser<IParseResult>
    {
        [ImportingConstructor]
        public OperatorResultParser([ImportMany] IEnumerable<IOperator> operators)
            : base(2)
        {
            Operators = operators;
            ParsableTokens = from o in Operators
                select o.ProcessedToken;
        }

        private IEnumerable<IOperator> Operators { get; set; }
        public IEnumerable<string> ParsableTokens { get; private set; }

        private bool CanParse(string toParse)
        {
            return ParsableTokens.Contains(toParse);
        }

        public override bool TryParse(string toParse, out IParseResult result)
        {
            bool canParse = CanParse(toParse);

            result = canParse
                ? new OperatorParseResult(Operators.First(o => o.CanProcess(toParse)))
                : null;

            return canParse;
        }
    }
}