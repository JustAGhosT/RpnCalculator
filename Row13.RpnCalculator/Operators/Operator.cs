namespace Row13.RpnCalculator.Operators
{
    using Row13.RpnCalculator.Parsing.ParseResults;

    public abstract class Operator : IOperator
    {
        public string ProcessedToken { get; private set; }
        public int Precedence { get; private set; }

        public abstract double Eval( double operand1, double operand2 );

        protected Operator( string token, int precedence )
        {
            ProcessedToken = token;
            TokenType = TokenType.Operator;
            Precedence = precedence;
        }

        public bool CanProcess( string token )
        {
            return token == ProcessedToken;
        }

        public TokenType TokenType { get; set; }
    }
}