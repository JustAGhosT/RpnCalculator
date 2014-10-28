using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    public abstract class ResultParser<T> : IResultParser<T> where T : IParseResult
    {
        protected ResultParser(int parsePrecedence)
        {
            ParsePrecedence = parsePrecedence;
        }

        public abstract bool TryParse(string toParse, out T result);

        public int ParsePrecedence { get; private set; }
    }
}