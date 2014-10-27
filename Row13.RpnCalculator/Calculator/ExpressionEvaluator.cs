using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using log4net;
using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Calculator
{
    public class ExpressionEvaluator
    {
        private static readonly ILog Log = LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        private string[] _expression;
        private readonly Stack<ITokenResult> _parsedTokens;
        public TokenParser TokenParser { get; private set; }
        public IDictionary<Type, ITokenProcessor<ITokenResult>> TokenProcessors { get; private set; }
            
        [ImportingConstructor]
        public ExpressionEvaluator([Import] TokenParser tokenParser,
            [ImportMany] IEnumerable<ITokenProcessor<ITokenResult>> tokenProcessors )
        {
            TokenParser = tokenParser;
            _parsedTokens = new Stack<ITokenResult>();
            TokenProcessors = new Dictionary<Type, ITokenProcessor<ITokenResult>>();
            tokenProcessors.ToList().ForEach(p => TokenProcessors[p.ProcessedType] = p);
        }

        public double Eval( string expression )
        {
            var index = 0;
            try
            {
                _expression = expression.Split( ' ' );
                var totalExpressions = _expression.Count();

                while (index < totalExpressions)
                {
                    var token = _expression[index];
                    var tokenParseResult = TokenParser.Parse(token);
                    var resultType = tokenParseResult.GetType();
                    var processor = TokenProcessors[resultType];
                    var result = processor.ProcessToken( tokenParseResult, _parsedTokens );
                    if( result != null )
                    {
                        result.Invoke();
                    }
                    index++;
                }

            }
            catch( Exception ex)
            {
                Log.Error(String.Format("Failed to evaluate {0}", expression), ex);
                throw;
            }

            return 0D;
        }
    }
}
