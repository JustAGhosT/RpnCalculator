using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Row13.RpnCalculator.Exceptions;

namespace Row13.RpnCalculator.Operators
{
    public class FinalizerTokenProcessor : TokenProcessor<FinalizerParseResult>
    {
        public IOutputProcessor OutputProcessor { get; private set; }

        [ImportingConstructor]
        public FinalizerTokenProcessor( IOutputProcessor outputProcessor )
        {
            OutputProcessor = outputProcessor;
        }

        public override Action ProcessToken( ITokenResult token, Stack<ITokenResult> currentTokens )
        {
            var result = currentTokens.Pop();

            if( currentTokens.Any() )
            {
                throw new PrematureFinalizationException( "Finalization was attempted before processing has completed" );
            }

            if( !( result is OperandParseResult ) )
            {
                throw new InvalidResultException( "Finalization attempted while the stack contains an operand tokentype" );
            }

            var parsedResult = ( OperandParseResult )result;

            return OutputProcessor.Write( parsedResult.Result );
        }
    }
}