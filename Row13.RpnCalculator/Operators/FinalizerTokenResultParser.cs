using System.Collections.Generic;
using System.Linq;
using Row13.RpnCalculator.Calculator;

namespace Row13.RpnCalculator.Operators
{
    public class FinalizerTokenResultParser : TokenResultParser<ITokenResult>
    {
        public IEnumerable<string> ParsableTokens { get; private set; }

        public FinalizerTokenResultParser() :
            base( 3 )
        {
            ParsableTokens = new List<string> { "=" };
        }

        private bool CanParse( string toParse )
        {
            return ParsableTokens.Contains( toParse );
        }

        public override bool TryParse( string toParse, out ITokenResult result )
        {
            var canParse = CanParse( toParse );

            result = canParse ?
            new FinalizerParseResult( true )
            : null;

            return canParse;
        }
    }
}