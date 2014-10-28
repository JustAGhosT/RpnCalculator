using System;

namespace Row13.RpnCalculator.Output
{
    public interface IOutputProcessor
    {
        Action Write( double result, string expression );
        double Result { get; set; }
        string Expression { get; set; }
    }
}