namespace Row13.RpnCalculator.Operators
{
    using Row13.RpnCalculator.Parsing.ParseResults;

    public abstract class Operator : IOperator
    {
        public string ProcessedToken { get; private set; }

        public bool TakesPrecedence { get; private set; }

        public abstract double Eval( double operand1, double operand2 );

        protected Operator( string token, bool takesPrecedence )
        {
            ProcessedToken = token;
            TokenType = TokenType.Operator;
            TakesPrecedence = takesPrecedence;
        }

        public bool CanProcess( string token )
        {
            return token == ProcessedToken;
        }

        public TokenType TokenType { get; set; }
    }
}