namespace Row13.RpnCalculator.Operators
{
    public abstract class Operator : IOperator
    {
        public string ProcessedToken { get; private set; }

        public int Precedence { get; set; }
        public abstract double Eval( double operand1, double operand2 );

        protected Operator( string token )
        {
            ProcessedToken = token;
            TokenType = TokenType.Operator;
        }

        public bool CanProcess( string token )
        {
            return token == ProcessedToken;
        }

        public TokenType TokenType { get; set; }
    }
}