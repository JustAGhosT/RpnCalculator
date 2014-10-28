using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Row13.RpnCalculator.Parsing.ParseResults;
using Row13.RpnCalculator.Output;

namespace Row13.RpnCalculator.TokenProcessing
{
    [InheritedExport( typeof( ITokenProcessor<IParseResult> ) )]
    public interface ITokenProcessor<in T> where T : IParseResult
    {
        Action ProcessToken(T token, Stack<IParseResult> resultTokens, Stack<IParseResult> expressionTokens, IOutputProcessor outputProcessor);
        Type ProcessedType { get; }
        int ProcessedTokenCount { get; }
        void ResetState();
    }
}