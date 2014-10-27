using Row13.RpnCalculator.Calculator;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Row13.RpnCalculator.Operators
{
    public class OperatorTokenResultParser : TokenResultParser<ITokenResult>
    {
        private IEnumerable<IOperator> Operators { get; set; }
        public IEnumerable<string> ParsableTokens { get; private set; }

        [ImportingConstructor]
        public OperatorTokenResultParser( [ImportMany]IEnumerable<IOperator> operators )
            : base( 2 )
        {
            Operators = operators;
            ParsableTokens = from o in Operators
                             select o.ProcessedToken;
        }

        private bool CanParse( string toParse )
        {
            return ParsableTokens.Contains( toParse );
        }

        public override bool TryParse(string toParse, out ITokenResult result)
        {
            var canParse = CanParse( toParse );

            result = canParse ?
            new OperatorParseResult( Operators.First( o => o.CanProcess( toParse ) ) )
            : null;

            return canParse;
        }
    }
}