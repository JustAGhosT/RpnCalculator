using System;
using System.Collections.Generic;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Processing
{
    public class OperandTokenProcessor : TokenProcessor<OperandParseResult>
    {
        public override Action ProcessToken(IParseResult token, Stack<IParseResult> resultTokens,IOutputProcessor outputProcessor)
        {
            ProcessedTokenCount++;

            resultTokens.Push(token);

            return null;
        }
    }
}