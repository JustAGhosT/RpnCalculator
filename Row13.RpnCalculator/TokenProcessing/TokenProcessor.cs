using System;
using System.Collections.Generic;

using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.TokenProcessing
{
    using Row13.RpnCalculator.Output;

    public abstract class TokenProcessor<T> : ITokenProcessor<IParseResult>
    {
        public abstract Action ProcessToken(IParseResult token, Stack<IParseResult> currentTokens, IOutputProcessor outputProcessor);

        public Type ProcessedType { get; private set; }

        protected TokenProcessor(  )
        {
            this.ProcessedType = typeof( T );
        }
    }
}
