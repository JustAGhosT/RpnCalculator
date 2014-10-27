using System;
using System.Collections.Generic;

namespace Row13.RpnCalculator.Operators
{
    public abstract class TokenResult<T> : ITokenResult<T>
    {
        public TokenType TokenType { get; set; }
        public T Result { get; set; }

        protected TokenResult(T result)
        {
            Result = result;
        }
    }
}