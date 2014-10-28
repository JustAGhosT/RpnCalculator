using System;

namespace Row13.RpnCalculator.Output
{
    public interface IOutputProcessor
    {
        double Result { get; set; }
        string Expression { get; set; }
        Action Write(double result, string expression);
    }
}