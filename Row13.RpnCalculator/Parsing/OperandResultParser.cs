using System;
using Row13.RpnCalculator.Calculator;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    public class OperandResultParser : ResultParser<IParseResult>
    {
        public OperandResultParser()
            : base( 1 )
        {
        }

        public override bool TryParse( string toParse, out IParseResult result )
        {
            double parsedResult;
            result = null;

            if( !Double.TryParse( toParse, out parsedResult ) )
            {
                return false;
            }

            result = new OperandParseResult( parsedResult );
            return true;
        }

    }
}