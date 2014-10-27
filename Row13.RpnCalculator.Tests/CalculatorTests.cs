using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Row13.RpnCalculator.Tests
{
    using Row13.RpnCalculator.Calculator;

    [TestClass]
    public class CalculatorTests
    {
        private ExpressionEvaluator _evaluator;

        [TestInitialize]
        public void Initialize()
        {
            _evaluator = new ExpressionEvaluator();
        }

        [TestMethod]
        public void SimpleAdditionAddsTest()
        {
            //------------Arrange--------------------
            var equation = "1 1 +";

            //------------Act------------------------
            var answer = _evaluator.Eval(equation);

            //------------Assert---------------------
            Assert.AreEqual<double>(2D, answer);
        }
    }
}
