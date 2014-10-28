using System;
using System.Collections.Generic;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.TokenProcessing
{
    using Row13.RpnCalculator.Output;

    public class OperandTokenProcessor : TokenProcessor<OperandParseResult>
    {
        public override Action ProcessToken(IParseResult token, Stack<IParseResult> resultTokens, Stack<IParseResult> expressionTokens, IOutputProcessor outputProcessor)
        {
            ProcessedTokenCount++;

            resultTokens.Push(token);
            expressionTokens.Push( token );

            return null;
        }
    }
}