﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing.ParseResults;

namespace Row13.RpnCalculator.TokenProcessing
{
    public class FinalizerTokenProcessor : TokenProcessor<FinalizerParseResult>
    {
        public override Action ProcessToken(IParseResult token, Stack<IParseResult> resultTokens, Stack<IParseResult> expressionTokens, IOutputProcessor outputProcessor)
        {
            ProcessedTokenCount++;

            IParseResult result = resultTokens.Pop();

            if (resultTokens.Any())
            {
                throw new PrematureFinalizationException( "Finalization was attempted before processing has completed" );
            }

            if( !( result is OperandParseResult ) )
            {
                throw new InvalidResultException( "Finalization attempted while the stack contains an operand tokentype" );
            }

            var parsedResult = ( OperandParseResult )result;
            var expression = expressionTokens.Pop();
            var expressionDisplay = expression.ToDisplay();

            return outputProcessor.Write(parsedResult.Result, expressionDisplay);
        }
    }
}