using Microsoft.VisualStudio.TestTools.UnitTesting;
using Row13.RpnCalculator.Calculator;
using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Tests
{
    using Row13.RpnCalculator.Parsing;
    using Row13.RpnCalculator.Parsing.ParseResults;

    [TestClass]
    public class OperandFactoryTests
    {
        private IResultParser<IParseResult> _operatorTokenResultParser;

        [TestInitialize]
        public void Initialize()
        {
            _operatorTokenResultParser = InitializationHelpers.InitializeOperatorTokenResultParser();
        }

        [TestMethod]
        public void PlusSymbolReturnsPlusOperator()
        {
            //------------Arrange--------------------
            const string token = "+";

            //------------Act------------------------
            var @operator = ParseToken(token);

            //------------Assert---------------------
            Assert.IsInstanceOfType( @operator, typeof( AdditionOperator ) );
        }

        [TestMethod]
        public void MinusSymbolReturnsSubstractionOperator()
        {
            //------------Arrange--------------------
            const string token = "-";

            //------------Act------------------------
            var @operator = ParseToken( token );

            //------------Assert---------------------
            Assert.IsInstanceOfType( @operator, typeof( SubstractionOperator ) );
        }

        [TestMethod]
        public void MultiplySymbolReturnsMultiplicationOperator()
        {
            //------------Arrange--------------------
            const string token = "*";

            //------------Act------------------------
            var @operator = ParseToken( token );

            //------------Assert---------------------
            Assert.IsInstanceOfType( @operator, typeof( MultiplicationOperator ) );
        }

        [TestMethod]
        public void DivideSymbolReturnsDivisionOperator()
        {
            //------------Arrange--------------------
            const string token = "/";

            //------------Act------------------------
            var @operator = ParseToken( token );

            //------------Assert---------------------
            Assert.IsInstanceOfType( @operator, typeof( DivisionOperator ) );
        }

        private IOperator ParseToken( string token )
        {
            IParseResult tokenResult;
            _operatorTokenResultParser.TryParse( token, out tokenResult );
            var typedTokenResult = ( OperatorParseResult )tokenResult;
            var @operator = typedTokenResult.Result;
            return @operator;
        }
    }
}
