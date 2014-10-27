using System;
using Row13.RpnCalculator.Calculator;

namespace Row13.RpnCalculator.Operators
{
    public class OperandTokenResultParser : TokenResultParser<ITokenResult>
    {
        public OperandTokenResultParser()
            : base( 1 )
        {
        }

        public override bool TryParse( string toParse, out ITokenResult result )
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