using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using log4net;
using Row13.RpnCalculator.Exceptions;
using Row13.RpnCalculator.Output;
using Row13.RpnCalculator.Parsing;
using Row13.RpnCalculator.Parsing.ParseResults;
using Row13.RpnCalculator.Processing;

namespace Row13.RpnCalculator.Calculator
{
    public class ExpressionEvaluator
    {
        #region private members

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Stack<IParseResult> _resultTokens;
        private readonly IDictionary<Type, ITokenProcessor<IParseResult>> _tokenProcessorDictionary;
        private CompositionContainer _container;
        private string[] _expression;
        private IEnumerable<ITokenProcessor<IParseResult>> _tokenProcessors;

        #endregion private members

        #region public members

        [Import]
        public ParsingProcessor TokenParser { get; private set; }

        [ImportMany]
        public IEnumerable<ITokenProcessor<IParseResult>> TokenProcessors
        {
            get { return _tokenProcessors; }
            set
            {
                _tokenProcessors = value;
                _tokenProcessors.ToList().ForEach(p => _tokenProcessorDictionary[p.ProcessedType] = p);
            }
        }

        public IOutputProcessor OutputProcessor { get; private set; }

        #endregion public members

        #region constructor and init

        public ExpressionEvaluator(bool compose, IOutputProcessor outputProcessor, ParsingProcessor tokenParser = null,
            IEnumerable<ITokenProcessor<IParseResult>> tokenProcessors = null)
        {
            _resultTokens = new Stack<IParseResult>();
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

        public double Eval(string expression)
        {
            TokenProcessors.ToList().ForEach(tp => tp.ResetState());
            _resultTokens.Clear();

            DateTime operationStarted = DateTime.Now;
            Log.Debug(String.Format("Evaluating {0}", expression));

            int index = 0;
            try
            {
                _expression = expression.Split(' ');
                int totalExpressions = _expression.Count();

                while (index < totalExpressions)
                {
                    ProcessExpression(index);
                    index++;
                }

                if (_tokenProcessorDictionary[typeof (FinalizerParseResult)].ProcessedTokenCount == 0)
                {
                    throw new NoFinalizerFoundException("Consider including an equal(=) sign to evaluate expression");
                }
            }
            catch (Exception ex)
            {
                Log.Error(String.Format("Failed to evaluate {0}.", expression), ex);
                throw;
            }

            TimeSpan timeSpan = DateTime.Now - operationStarted;
            Log.Debug(String.Format("Evaluated {0} in {1}.", expression, timeSpan));

            return OutputProcessor.Result;
        }

        #endregion

        #region private methods

        private void ProcessExpression(int index)
        {
            string toParse = _expression[index];
            IParseResult tokenParseResult = TokenParser.Parse(toParse);
            Type resultType = tokenParseResult.GetType();
            ITokenProcessor<IParseResult> processor = _tokenProcessorDictionary[resultType];
            Action result = processor.ProcessToken(tokenParseResult, _resultTokens, OutputProcessor);
            if (result != null)
            {
                result.Invoke();
            }
        }

        private void PerformComposition()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof (ExpressionEvaluator).Assembly));
            _container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                _container.ComposeParts(this);
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