using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace Row13.RpnCalculator.Operators
{
    [InheritedExport( typeof( ITokenProcessor<> ) )]
    public interface ITokenProcessor<in T> where T : ITokenResult
    {
        Action ProcessToken(T token, Stack<ITokenResult> currentTokens );
        Type ProcessedType { get; }
    }

    public abstract class TokenProcessor<T> : ITokenProcessor<ITokenResult>
    {
        public abstract Action ProcessToken( ITokenResult token, Stack<ITokenResult> currentTokens );

        public Type ProcessedType { get; private set; }

        protected TokenProcessor(  )
        {
            ProcessedType = typeof( T );
        }
    }
}
