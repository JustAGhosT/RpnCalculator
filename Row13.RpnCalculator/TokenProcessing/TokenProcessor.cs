using System;
using System.Collections.Generic;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.TokenProcessing
{
    public abstract class TokenProcessor<T> : ITokenProcessor<IParseResult>
    {
        protected TokenProcessor()
        {
            ProcessedType = typeof (T);
        }

        public abstract Action ProcessToken(IParseResult token, Stack<IParseResult> resultTokens,
            Stack<IParseResult> expressionTokens, IOutputProcessor outputProcessor);

        public Type ProcessedType { get; private set; }
        public int ProcessedTokenCount { get; protected set; }

        public virtual void ResetState()
        {
            ProcessedTokenCount = 0;
        }
    }
}