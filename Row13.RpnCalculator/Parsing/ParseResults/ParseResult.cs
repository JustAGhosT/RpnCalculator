namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public abstract class ParseResult<T> : IParseResult<T>
    {
        protected ParseResult(T result)
        {
            Result = result;
        }

        public TokenType TokenType { get; set; }

        public bool TakesPrecedence { get; protected set; }

        public T Result { get; set; }
    }
}