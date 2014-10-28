using System;
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
        public override Action ProcessToken(IParseResult token, Stack<IParseResult> currentTokens, IOutputProcessor outputProcessor)
        {
            IParseResult result = currentTokens.Pop();

            if( currentTokens.Any() )
            {
                throw new PrematureFinalizationException( "Finalization was attempted before processing has completed" );
            }

            if( !( result is OperandParseResult ) )
            {
                throw new InvalidResultException( "Finalization attempted while the stack contains an operand tokentype" );
            }

            var parsedResult = ( OperandParseResult )result;

            return outputProcessor.Write(parsedResult.Result);
        }
    }
}