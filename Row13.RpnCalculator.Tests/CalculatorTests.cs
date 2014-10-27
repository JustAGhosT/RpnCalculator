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
            const string Equation = "1 2 +";

            //------------Act------------------------
            var answer = _evaluator.Eval(Equation);

            //------------Assert---------------------
            Assert.AreEqual(3D, answer);
        }

        [TestMethod]
        public void SimpleSubstractionSubstractsTest()
        {
            //------------Arrange--------------------
            const string Equation = "1 2 -";

            //------------Act------------------------
            var answer = _evaluator.Eval(Equation);

            //------------Assert---------------------
            Assert.AreEqual(-1D, answer);
        }

        [TestMethod]
        public void SimpleMultiplicationMultipliesTest()
        {
            //------------Arrange--------------------
            const string Equation = "1 2 *";

            //------------Act------------------------
            var answer = _evaluator.Eval(Equation);

            //------------Assert---------------------
            Assert.AreEqual(2D, answer);
        }

        [TestMethod]
        public void SimpleDivisionDivides()
        {
            //------------Arrange--------------------
            const string Equation = "1 2 /";

            //------------Act------------------------
            var answer = _evaluator.Eval(Equation);

            //------------Assert---------------------
            Assert.AreEqual(0.5, answer);
        }
    }
}
