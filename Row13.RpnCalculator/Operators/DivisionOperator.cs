namespace Row13.RpnCalculator.Operators
{
    public class DivisionOperator : Operator
    {
        public DivisionOperator()
            : base("/", true)
        {
        }

        public override double Eval(double operand1, double operand2)
        {
            return operand1/operand2;
        }
    }
}