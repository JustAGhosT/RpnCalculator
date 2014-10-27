namespace Row13.RpnCalculator.Operators
{
    using System.ComponentModel.Composition;

    [InheritedExport( typeof( IOperator ) )]
    public interface IOperator
    {
        string ProcessedToken { get; }

        int Precedence { get; set; }
        double Eval( double operand1, double operand2 );
        bool CanProcess( string token );
    }
}