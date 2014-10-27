using System.Collections.Generic;
using Row13.RpnCalculator.Calculator;
using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Tests
{
    public static class InitializationHelpers
    {
        public static ITokenResultParser<ITokenResult> InitializeOperatorTokenResultParser()
        {
            var operators = new List<IOperator>
            {
                new AdditionOperator(),
                new SubstractionOperator(),
                new MultiplicationOperator(),
                new DivisionOperator()
            };

            return new OperatorTokenResultParser( operators );
        }

        public static TokenParser InitializeTokenParser()
        {
            var tokenParsers = new List<ITokenResultParser<ITokenResult>>
            {
                InitializeOperatorTokenResultParser(),
                new OperandTokenResultParser(),
                new FinalizerTokenResultParser()
            };

            return new TokenParser( tokenParsers );
        }

        public static ExpressionEvaluator InitializeExpressionEvaluator( IOutputProcessor outputProcessor )
        {
            return new ExpressionEvaluator( InitializeTokenParser(), new List<ITokenProcessor<ITokenResult>>
            {
                new OperatorTokenProcessor(),
                new OperandTokenProcessor(),
                new FinalizerTokenProcessor(outputProcessor)
            } );
        }
    }
}
