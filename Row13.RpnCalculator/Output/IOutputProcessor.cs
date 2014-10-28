using System;

namespace Row13.RpnCalculator.Output
{
    public interface IOutputProcessor
    {
        Action Write( double result );
        double Result { get; set; }
    }
}