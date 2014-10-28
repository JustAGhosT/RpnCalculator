namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public interface IParseResult<T> : IParseResult
    {
        T Result { get; set; }
    }

    public interface IParseResult
    {
        TokenType TokenType { get; set; }
        bool TakesPrecedence { get; }
    }
}