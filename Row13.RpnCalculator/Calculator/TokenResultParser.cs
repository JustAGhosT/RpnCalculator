using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Calculator
{
    public abstract class TokenResultParser<T> : ITokenResultParser<T> where T : ITokenResult
    {
        public abstract bool TryParse( string toParse, out T result );

        public int ParsePrecedence { get; private set; }

        protected TokenResultParser( int parsePrecedence )
        {
            ParsePrecedence = parsePrecedence;
        }
    }
}