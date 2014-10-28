using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    public interface IResultParser<T> where T : IParseResult
    {
        int ParsePrecedence { get; }
        bool TryParse( string toParse, out T result );
    }
}