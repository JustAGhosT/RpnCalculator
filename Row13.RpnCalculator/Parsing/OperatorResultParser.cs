using Row13.RpnCalculator.Calculator;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Row13.RpnCalculator.Operators;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    public class OperatorResultParser : ResultParser<IParseResult>
    {
        private IEnumerable<IOperator> Operators { get; set; }
        public IEnumerable<string> ParsableTokens { get; private set; }

        [ImportingConstructor]
        public OperatorResultParser( [ImportMany]IEnumerable<IOperator> operators )
            : base( 2 )
        {
            this.Operators = operators;
            this.ParsableTokens = from o in this.Operators
                             select o.ProcessedToken;
        }

        private bool CanParse( string toParse )
        {
            return this.ParsableTokens.Contains( toParse );
        }

        public override bool TryParse(string toParse, out IParseResult result)
        {
            var canParse = CanParse( toParse );

            result = canParse ?
            new OperatorParseResult( this.Operators.First( o => o.CanProcess( toParse ) ) )
            : null;

            return canParse;
        }
    }
}