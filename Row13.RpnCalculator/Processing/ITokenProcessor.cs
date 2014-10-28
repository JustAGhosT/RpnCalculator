using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.Processing
{
    [InheritedExport(typeof (ITokenProcessor<IParseResult>))]
    public interface ITokenProcessor<in T> where T : IParseResult
    {
        Type ProcessedType { get; }
        int ProcessedTokenCount { get; }

        Action ProcessToken(T token, Stack<IParseResult> resultTokens, IOutputProcessor outputProcessor);

        void ResetState();
    }
}