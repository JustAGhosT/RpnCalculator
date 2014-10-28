using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Row13.RpnCalculator.Calculator;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Processing
{
    public class FinalizerTokenProcessor : TokenProcessor<FinalizerParseResult>
    {
        private readonly IExpressionBuilder _expressionBuilder;

        [ImportingConstructor]
        public FinalizerTokenProcessor(IExpressionBuilder expressionBuilder)
        {
            _expressionBuilder = expressionBuilder;
        }

        public override Action ProcessToken(IParseResult token, Stack<IParseResult> resultTokens, IOutputProcessor outputProcessor)
        {
            ProcessedTokenCount++;

            var result = ( ExpressionParseResult ) resultTokens.Pop();

            if (resultTokens.Any())
            {
                throw new FinalizationException("Finalization was attempted before processing has completed");
            }

            string expressionDisplay = _expressionBuilder.Build(result, false);

            return outputProcessor.Write( result.Result.Result, expressionDisplay );
        }
    }
}