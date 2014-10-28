using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    using System.ComponentModel.Composition;

    [InheritedExport(typeof(IResultParser<IParseResult>))]
    public interface IResultParser<T> where T : IParseResult
    {
        int ParsePrecedence { get; }
        bool TryParse(string toParse, out T result);
    }
}