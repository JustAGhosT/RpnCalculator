﻿namespace Row13.RpnCalculator.Parsing.ParseResults
{
    public class FinalizerParseResult : ParseResult<bool>
    {
        public FinalizerParseResult(bool canFinalize)
            : base(canFinalize)
        {
            TokenType = TokenType.Finalizer;
        }
    }
}