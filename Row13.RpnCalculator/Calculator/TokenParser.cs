using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Calculator
{
    [Export]
    public class TokenParser
    {
        public IEnumerable<ITokenResultParser<ITokenResult>> TokenResultParsers { get; set; }

        [ImportingConstructor]
        public TokenParser( [ImportMany]IEnumerable<ITokenResultParser<ITokenResult>> tokenResultParsers )
        {
            TokenResultParsers = tokenResultParsers.OrderBy( trp => trp.ParsePrecedence );
        }

        public ITokenResult Parse( string toParse )
        {
            ITokenResult result = null;

            foreach (var tokenResultParser in TokenResultParsers)
            {
                tokenResultParser.TryParse(toParse, out result);
                if (result != null)
                {
                    return result;
                }
            }

            if( result == null )
            {
                throw new InvalidTokenException( String.Format( "{0} is an unregocnised token", toParse ) );
            }

            return null;
        }
    }
}
