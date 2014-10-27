using System;

namespace Row13.RpnCalculator.Operators
{
    public interface IOutputProcessor
    {
        Action Write( double result );
    }
}