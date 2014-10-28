using System.Collections.Generic;
using System.Linq;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    public class FinalizerResultParser : ResultParser<IParseResult>
    {
        public FinalizerResultParser() :
            base(3)
        {
            ParsableTokens = new List<string> {"="};
        }

        public IEnumerable<string> ParsableTokens { get; private set; }

        private bool CanParse(string toParse)
        {
            return ParsableTokens.Contains(toParse);
        }

        public override bool TryParse(string toParse, out IParseResult result)
        {
            bool canParse = CanParse(toParse);

            result = canParse
                ? new FinalizerParseResult(true)
                : null;

            return canParse;
        }
    }
}