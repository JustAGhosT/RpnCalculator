using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    [Export]
    public class ParsingProcessor
    {
        public IEnumerable<IResultParser<IParseResult>> TokenResultParsers { get; set; }

        [ImportingConstructor]
        public ParsingProcessor( [ImportMany]IEnumerable<IResultParser<IParseResult>> tokenResultParsers )
        {
            this.TokenResultParsers = tokenResultParsers.OrderBy( trp => trp.ParsePrecedence );
        }

        public IParseResult Parse( string toParse )
        {
            IParseResult result = null;

            foreach (var tokenResultParser in this.TokenResultParsers)
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
