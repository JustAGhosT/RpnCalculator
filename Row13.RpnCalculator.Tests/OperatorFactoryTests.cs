using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Row13.RpnCalculator.Tests
{
    [TestClass]
    public class OperandFactoryTests
    {
        //    + : add the preceding two numbers
        //- : subtract the first number from the second
        //* : multiply the preceding two numbers
        /// : divide the first number by the second
        //= : print the result of the preceding RPN expression to stdout

        [TestMethod]
        public void PlusSymbolReturnsPlusOperator()
        {
            //------------Arrange--------------------
            var factory = new OperatorFactory();
            const char Token = '+';

            //------------Act------------------------
            var op = factory.Create(Token);

            //------------Assert---------------------
            Assert.IsInstanceOfType(op, typeof(AdditionOperator));
        }

        [TestMethod]
        public void MinusSymbolReturnsSubstractionOperator()
        {
            //------------Arrange--------------------
            var factory = new OperatorFactory();
            const char Token = '-';

            //------------Act------------------------
            var op = factory.Create(Token);

            //------------Assert---------------------
            Assert.IsInstanceOfType(op, typeof(SubstractionOperator));
        }

        [TestMethod]
        public void MultiplySymbolReturnsMultiplicationOperator()
        {
            //------------Arrange--------------------
            var factory = new OperatorFactory();
            const char Token = '*';

            //------------Act------------------------
            var op = factory.Create(Token);

            //------------Assert---------------------
            Assert.IsInstanceOfType(op, typeof(MultiplicationOperator));
        }

        [TestMethod]
        public void DivideSymbolReturnsDivisionOperator()
        {
            //------------Arrange--------------------
            var factory = new OperatorFactory();
            const char Token = '/';

            //------------Act------------------------
            var op = factory.Create(Token);

            //------------Assert---------------------
            Assert.IsInstanceOfType(op, typeof(DivisionOperator));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperatorException))]
        public void InvalidOperatorExcpectsInvalidOperatorException()
        {
            //------------Arrange--------------------
            var factory = new OperatorFactory();
            const char Token = ';';

            //------------Act------------------------
            var op = factory.Create(Token);

            //------------Assert---------------------

            //Exception expected
        }
    }
}
