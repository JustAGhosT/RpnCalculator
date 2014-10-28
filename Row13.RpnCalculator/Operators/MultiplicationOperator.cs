namespace Row13.RpnCalculator.Operators
{
    public class MultiplicationOperator : Operator
    {
        public MultiplicationOperator()
            : base("*", 1)
        {
        }

        public override double Eval(double operand1, double operand2)
        {
            return operand1 * operand2;
        }
    }
}