namespace Row13.RpnCalculator.Tests
{
    public class DivisionOperator : Operator
    {
        public DivisionOperator()
            : base('/')
        {
        }

        public override double Eval(double operand1, double operand2)
        {
            return operand1 / operand2;
        }
    }
}