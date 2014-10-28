using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public abstract class ParseResult<T> : IParseResult<T>
    {
        public TokenType TokenType { get; set; }

        public bool TakesPrecedence { get; protected set; }

        public T Result { get; set; }

        protected ParseResult(T result)
        {
            this.Result = result;
        }
    }
}