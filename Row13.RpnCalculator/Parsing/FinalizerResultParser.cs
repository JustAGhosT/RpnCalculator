using System.Collections.Generic;
using System.Linq;
using Row13.RpnCalculator.Calculator;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    public class FinalizerResultParser : ResultParser<IParseResult>
    {
        public IEnumerable<string> ParsableTokens { get; private set; }

        public FinalizerResultParser() :
            base( 3 )
        {
            this.ParsableTokens = new List<string> { "=" };
        }

        private bool CanParse( string toParse )
        {
            return this.ParsableTokens.Contains( toParse );
        }

        public override bool TryParse( string toParse, out IParseResult result )
        {
            var canParse = this.CanParse( toParse );

            result = canParse ?
            new FinalizerParseResult( true )
            : null;

            return canParse;
        }
    }
}