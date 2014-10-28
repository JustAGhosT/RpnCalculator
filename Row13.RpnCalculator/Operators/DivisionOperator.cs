namespace Row13.RpnCalculator.Operators
{
    public class DivisionOperator : Operator
    {
        public DivisionOperator()
            : base("/", 1)
        {
        }

        public override double Eval(double operand1, double operand2)
        {
            return operand1 / operand2;
        }
    }
}