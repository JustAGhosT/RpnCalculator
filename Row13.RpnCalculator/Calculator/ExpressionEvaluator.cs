using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using log4net;
using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Calculator
{
    using Row13.RpnCalculator.Output;
    using Row13.RpnCalculator.Parsing;
    using Row13.RpnCalculator.Parsing.ParseResults;
    using Row13.RpnCalculator.TokenProcessing;

    public class ExpressionEvaluator
    {
        private static readonly ILog Log = LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );

        private string[] _expression;
        private readonly Stack<IParseResult> _parsedTokens;
        public ParsingProcessor TokenParser { get; private set; }
        public IDictionary<Type, ITokenProcessor<IParseResult>> TokenProcessors { get; private set; }
        public IOutputProcessor OutputProcessor { get; private set; }
            
        [ImportingConstructor]
        public ExpressionEvaluator(ParsingProcessor tokenParser, IEnumerable<ITokenProcessor<IParseResult>> tokenProcessors, IOutputProcessor outputProcessor)
        {
            TokenParser = tokenParser;
            _parsedTokens = new Stack<IParseResult>();
            TokenProcessors = new Dictionary<Type, ITokenProcessor<IParseResult>>();
            tokenProcessors.ToList().ForEach(p => TokenProcessors[p.ProcessedType] = p);
            OutputProcessor = outputProcessor;
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
                    string token = _expression[index];
                    IParseResult tokenParseResult = TokenParser.Parse(token);
                    Type resultType = tokenParseResult.GetType();
                    ITokenProcessor<IParseResult> processor = TokenProcessors[resultType];
                    Action result = processor.ProcessToken( tokenParseResult, _parsedTokens, OutputProcessor );
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
