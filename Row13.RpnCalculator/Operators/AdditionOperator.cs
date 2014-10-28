using System.ComponentModel.Composition;

namespace Row13.RpnCalculator.Operators
{
    [Export]
    public class AdditionOperator : Operator
    {
        public AdditionOperator()
            : base("+", false)
        {
        }

        public override double Eval(double operand1, double operand2)
        {
            return operand1 + operand2;
        }
    }
}