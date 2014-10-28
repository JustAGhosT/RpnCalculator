using System.Collections.Generic;
using Row13.RpnCalculator.Calculator;
using Row13.RpnCalculator.Operators;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing;
using Row13.RpnCalculator.Parsing.ParseResults;
using Row13.RpnCalculator.Processing;

namespace Row13.RpnCalculator.Tests
{
    public static class InitializationHelpers
    {
        public static IResultParser<IParseResult> InitializeOperatorTokenResultParser()
        {
            var operators = new List<IOperator>
            {
                new AdditionOperator(),
                new SubstractionOperator(),
                new MultiplicationOperator(),
                new DivisionOperator()
            };

            return new OperatorResultParser(operators);
        }

        public static ParsingProcessor InitializeTokenParser()
        {
            var tokenParsers = new List<IResultParser<IParseResult>>
            {
                InitializeOperatorTokenResultParser(),
                new OperandResultParser(),
                new FinalizerResultParser()
            };

            return new ParsingProcessor(tokenParsers);
        }

        public static ExpressionEvaluator InitializeExpressionEvaluator(IOutputProcessor outputProcessor)
        {
            return new ExpressionEvaluator(false, outputProcessor, InitializeTokenParser(), new List<ITokenProcessor<IParseResult>>
            {
                new OperatorTokenProcessor(),
                new OperandTokenProcessor(),
                new FinalizerTokenProcessor(new ExpressionBuilder())
            });
        }
    }
}
