using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.TokenProcessing
{
    using Row13.RpnCalculator.Output;

    [InheritedExport( typeof( ITokenProcessor<> ) )]
    public interface ITokenProcessor<in T> where T : IParseResult
    {
        Action ProcessToken(T token, Stack<IParseResult> currentTokens, IOutputProcessor outputProcessor);
        Type ProcessedType { get; }
    }
}