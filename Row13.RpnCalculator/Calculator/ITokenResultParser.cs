using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Calculator
{
    public interface ITokenResultParser<T> where T : ITokenResult
    {
        int ParsePrecedence { get; }
        bool TryParse( string toParse, out T result );
    }
}