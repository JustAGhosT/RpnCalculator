namespace Row13.RpnCalculator.Operators
{
    public class SubstractionOperator : Operator
    {
        public SubstractionOperator()
            : base("-", false)
        {
        }

        public override double Eval(double operand1, double operand2)
        {
            return operand1 - operand2;
        }
    }
}