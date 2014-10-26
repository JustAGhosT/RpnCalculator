namespace Row13.RpnCalculator.Tests
{
    public class AdditionOperator : Operator
    {
        public AdditionOperator()
            : base('+')
        {
        }

        public override double Eval(double operand1, double operand2)
        {
            return operand1 + operand2;
        }
    }
}