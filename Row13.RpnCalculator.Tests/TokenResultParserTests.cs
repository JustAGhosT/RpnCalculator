using Microsoft.VisualStudio.TestTools.UnitTesting;
using Row13.RpnCalculator.Calculator;
using Row13.RpnCalculator.Exceptions;

namespace Row13.RpnCalculator.Tests
{
    using Row13.RpnCalculator.Parsing;

    [TestClass]
    public class TokenResultParserTests
    {
        private ParsingProcessor _tokenParser;

        [TestInitialize]
        public void Initialize()
        {
            _tokenParser = InitializationHelpers.InitializeTokenParser();
        }

        [TestMethod]
        [ExpectedException( typeof( InvalidTokenException ) )]
        public void InvalidOperatorExcpectsInvalidOperatorException()
        {
            //------------Arrange--------------------
            const string token = ";";

            //------------Act------------------------
            var op = _tokenParser.Parse( token );

            //------------Assert---------------------

            //Exception expected
        }
    }
}
