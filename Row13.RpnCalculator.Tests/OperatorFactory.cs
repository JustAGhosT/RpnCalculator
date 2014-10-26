namespace Row13.RpnCalculator.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    public class OperatorFactory
    {
        [ImportMany]
        public IEnumerable<IOperator> Operators { get; set; }

        public IOperator Create(char token)
        {
            var @operator = Operators.FirstOrDefault(o => o.CanProcess(token));

            if (@operator != null)
            {
                return @operator;
            }

            throw new InvalidOperatorException(String.Format("{0} is not a valid operator", token));
        }
    }
}