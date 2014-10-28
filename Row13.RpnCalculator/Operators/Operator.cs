using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Operators
{
    public abstract class Operator : IOperator
    {
        protected Operator(string token, bool takesPrecedence)
        {
            ProcessedToken = token;
            TokenType = TokenType.Operator;
            TakesPrecedence = takesPrecedence;
        }

        public TokenType TokenType { get; set; }

        public string ProcessedToken { get; private set; }

        public bool TakesPrecedence { get; private set; }

        public abstract double Eval(double operand1, double operand2);

        public bool CanProcess(string token)
        {
            return token == ProcessedToken;
        }
    }
}