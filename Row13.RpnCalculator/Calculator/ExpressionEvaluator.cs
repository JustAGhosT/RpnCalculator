using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using log4net;
using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Calculator
{
    using System.ComponentModel.Composition.Hosting;

    using Row13.RpnCalculator.Exceptions;
    using Row13.RpnCalculator.Output;
    using Row13.RpnCalculator.Parsing;
    using Row13.RpnCalculator.Parsing.ParseResults;
    using Row13.RpnCalculator.TokenProcessing;

    public class ExpressionEvaluator
    {
        #region private members

        private static readonly ILog Log = LogManager.GetLogger( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType );
        private readonly Stack<IParseResult> _resultTokens; 
        private readonly Stack<IParseResult> _expressionTokens;
        private readonly IDictionary<Type, ITokenProcessor<IParseResult>> _tokenProcessorDictionary;

        private string[] _expression;
        private IEnumerable<ITokenProcessor<IParseResult>> _tokenProcessors;
        private CompositionContainer _container;

        #endregion private members

        #region public members

        [Import]
        public ParsingProcessor TokenParser { get; private set; }
        
        [ImportMany]
        public IEnumerable<ITokenProcessor<IParseResult>> TokenProcessors
        {
            get
            {
                return _tokenProcessors;
            }
            set
            {
                _tokenProcessors = value;
                _tokenProcessors.ToList().ForEach(p => _tokenProcessorDictionary[p.ProcessedType] = p);
            }
        }

        public IOutputProcessor OutputProcessor { get; private set; }

        #endregion public members

        #region constructor and init

        public ExpressionEvaluator(bool compose, IOutputProcessor outputProcessor, ParsingProcessor tokenParser = null, IEnumerable<ITokenProcessor<IParseResult>> tokenProcessors = null)
        {
            _resultTokens = new Stack<IParseResult>();
            _expressionTokens = new Stack<IParseResult>();
            _tokenProcessorDictionary = new Dictionary<Type, ITokenProcessor<IParseResult>>();
            OutputProcessor = outputProcessor;

            if (compose)
            {
                PerformComposition();
            }
            else
            {
                TokenParser = tokenParser;
                TokenProcessors = tokenProcessors;
            }
        }

        #endregion 

        #region public methods

        public double Eval( string expression )
        {
            TokenProcessors.ToList().ForEach(tp => tp.ResetState());
            _resultTokens.Clear();

            var operationStarted = DateTime.Now;
            Log.Debug(String.Format("Evaluating {0}", expression));

            var index = 0;
            try
            {
                _expression = expression.Split( ' ' );
                var totalExpressions = _expression.Count();

                while (index < totalExpressions)
                {
                    ProcessExpression(index);
                    index++;
                }

                if (_tokenProcessorDictionary[typeof(FinalizerParseResult)].ProcessedTokenCount == 0)
                {
                    throw new NoFinalizerFoundException("Consider including an equal(=) sign to evaluate expression");
                }
            }
            catch( Exception ex)
            {
                Log.Error(String.Format("Failed to evaluate {0}.", expression), ex);
                throw;
            }

            var timeSpan = DateTime.Now - operationStarted;
            Log.Debug(String.Format("Evaluated {0} in {1}.", expression, timeSpan));

            return OutputProcessor.Result;
        }

        #endregion

        #region private methods

        private void ProcessExpression(int index)
        {
            string toParse = this._expression[index];
            IParseResult tokenParseResult = this.TokenParser.Parse(toParse);
            Type resultType = tokenParseResult.GetType();
            ITokenProcessor<IParseResult> processor = this._tokenProcessorDictionary[resultType];
            Action result = processor.ProcessToken(tokenParseResult, this._resultTokens, this._expressionTokens, this.OutputProcessor);
            if (result != null)
            {
                result.Invoke();
            }
        }

        private void PerformComposition()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ExpressionEvaluator).Assembly));
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                Log.Error("Composition Exceptoin", ex);
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion
    }
}
