namespace Row13.RpnCalculator.Tests
{
    public class SubstractionOperator : Operator
    {
        public SubstractionOperator()
            : base('-')
        {
        }

        public override double Eval(double operand1, double operand2)
        {
            return operand1 - operand2;
        }
    }
}