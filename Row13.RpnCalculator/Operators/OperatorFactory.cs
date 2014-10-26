namespace Row13.RpnCalculator.Operators
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    using Row13.RpnCalculator.Exceptions;

    public class OperatorFactory
    {
        private IEnumerable<IOperator> Operators { get; set; }

        [ImportingConstructor]
        public OperatorFactory([ImportMany]IEnumerable<IOperator> operators)
        {
            this.Operators = operators;
        }

        public IOperator Create(char token)
        {
            var @operator = this.Operators.FirstOrDefault(o => o.CanProcess(token));

            if (@operator != null)
            {
                return @operator;
            }

            throw new InvalidOperatorException(String.Format("{0} is not a valid operator", token));
        }
    }
}