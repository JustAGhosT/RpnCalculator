using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Row13.RpnCalculator.Calculator;
using Row13.RpnCalculator.Operators;

namespace Row13.RpnCalculator.Tests
{
    using Row13.RpnCalculator.Exceptions;
    using Row13.RpnCalculator.Output;

    [TestClass]
    public class CalculatorTests
    {
        private ExpressionEvaluator _evaluator;
        private Mock<IOutputProcessor> _mockProcessor;

        [TestInitialize]
        public void Initialize()
        {
            _mockProcessor = new Mock<IOutputProcessor>();
            _evaluator = InitializationHelpers.InitializeExpressionEvaluator(_mockProcessor.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NoFinalizerFoundException))]
        public void NoFinalizerCreatesNoOutput()
        {
            //------------Arrange--------------------
            const string equation = "1 2 +";
            double result = 0D;
            _mockProcessor.Setup(p => p.Write(It.IsAny<double>(), It.IsAny<string>())).Callback<double, string>((obj, expr) => result = obj);

            //------------Act------------------------
            var answer = _evaluator.Eval(equation);

            //------------Assert---------------------
            Assert.AreEqual(0D, result);
            _mockProcessor.Verify(p => p.Write(It.IsAny<double>(), It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void SimpleAdditionAddsTest()
        {
            //------------Arrange--------------------
            const string equation = "1 2 + =";
            double result = 0D;
            _mockProcessor.Setup(p => p.Write(It.IsAny<double>(), It.IsAny<string>())).Callback<double, string>((obj, expr) => result = obj);

            //------------Act------------------------
            var answer = _evaluator.Eval(equation);

            //------------Assert---------------------
            Assert.AreEqual(3D, result);
            _mockProcessor.Verify(p => p.Write(It.IsAny<double>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void SimpleSubstractionSubstractsTest()
        {
            //------------Arrange--------------------
            const string equation = "1 2 - =";
            double result = 0D;
            _mockProcessor.Setup(p => p.Write(It.IsAny<double>(), It.IsAny<string>())).Callback<double, string>((obj, expr) => result = obj);

            //------------Act------------------------
            var answer = _evaluator.Eval(equation);

            //------------Assert---------------------
            Assert.AreEqual(-1D, result);
            _mockProcessor.Verify(p => p.Write(It.IsAny<double>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void SimpleMultiplicationMultipliesTest()
        {
            //------------Arrange--------------------
            const string equation = "1 2 * =";
            double result = 0D;
            _mockProcessor.Setup(p => p.Write(It.IsAny<double>(), It.IsAny<string>())).Callback<double, string>((obj, expr) => result = obj);

            //------------Act------------------------
            var answer = _evaluator.Eval(equation);

            //------------Assert---------------------
            Assert.AreEqual(2D, result);
            _mockProcessor.Verify(p => p.Write(It.IsAny<double>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void SimpleDivisionDivides()
        {
            //------------Arrange--------------------
            const string equation = "1 2 / =";
            double result = 0D;
            _mockProcessor.Setup(p => p.Write(It.IsAny<double>(), It.IsAny<string>())).Callback<double, string>((obj, expr) => result = obj);

            //------------Act------------------------
            var answer = _evaluator.Eval(equation);

            //------------Assert---------------------
            Assert.AreEqual(0.5, result);
            _mockProcessor.Verify(p => p.Write(It.IsAny<double>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void FourOperatorsSuccees()
        {
            //------------Arrange--------------------
            const string equation = "5 1 2 + 4 * + 3 - =";
            double result = 0D;
            _mockProcessor.Setup(p => p.Write(It.IsAny<double>(), It.IsAny<string>())).Callback<double, string>((obj, expr) => result = obj);

            //------------Act------------------------
            var answer = _evaluator.Eval(equation);

            //------------Assert---------------------
            Assert.AreEqual(14D, result);
            _mockProcessor.Verify(p => p.Write(It.IsAny<double>(), It.IsAny<string>()), Times.Once);
        }
    }
}
