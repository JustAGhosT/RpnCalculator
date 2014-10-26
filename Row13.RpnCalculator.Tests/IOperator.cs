namespace Row13.RpnCalculator.Tests
{
    public interface IOperator
    {
        int Precedence { get; set; }

        double Eval(double operand1, double operand2);
        bool CanProcess(char token);
    }
}