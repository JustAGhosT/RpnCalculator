namespace Row13.RpnCalculator.Tests
{
    public abstract class Operator : IOperator
    {
        private readonly char _processedToken;

        public int Precedence { get; set; }
        public abstract double Eval(double operand1, double operand2);

        protected Operator(char token)
        {
            this._processedToken = token;
        }

        public bool CanProcess(char token)
        {
            return token == this._processedToken;
        }
    }
}