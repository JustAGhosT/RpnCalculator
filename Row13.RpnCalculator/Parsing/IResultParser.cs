using System.ComponentModel.Composition;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Parsing
{
    [InheritedExport(typeof (IResultParser<IParseResult>))]
    public interface IResultParser<T> where T : IParseResult
    {
        int ParsePrecedence { get; }
        bool TryParse(string toParse, out T result);
    }
}