namespace Row13.RpnCalculator.Tests
{
    using System.ComponentModel.Composition;

    [Export]
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