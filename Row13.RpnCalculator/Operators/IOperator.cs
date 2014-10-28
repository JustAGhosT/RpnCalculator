﻿using System.ComponentModel.Composition;

namespace Row13.RpnCalculator.Operators
{
    [InheritedExport( typeof( IOperator ) )]
    public interface IOperator
    {
        string ProcessedToken { get; }
        int Precedence { get; }

        double Eval( double operand1, double operand2 );
        bool CanProcess( string token );
    }
}