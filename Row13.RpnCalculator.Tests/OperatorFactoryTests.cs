using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Row13.RpnCalculator.Tests
{
    using System.Collections.Generic;

    using Row13.RpnCalculator.Exceptions;
    using Row13.RpnCalculator.Operators;

    [TestClass]
    public class OperandFactoryTests
    {
        private OperatorFactory _operatorFactory;

        [TestInitialize]
        public void Initialize()
        {
            var operators = new List<IOperator>
                                {
                                    new AdditionOperator(),
                                    new SubstractionOperator(),
                                    new MultiplicationOperator(),
                                    new DivisionOperator()
                                };

            _operatorFactory = new OperatorFactory(operators);
        }

        [TestMethod]
        public void PlusSymbolReturnsPlusOperator()
        {
            //------------Arrange--------------------
            const char Token = '+';

            //------------Act------------------------
            var op = _operatorFactory.Create(Token);

            //------------Assert---------------------
            Assert.IsInstanceOfType(op, typeof(AdditionOperator));
        }

        [TestMethod]
        public void MinusSymbolReturnsSubstractionOperator()
        {
            //------------Arrange--------------------
            const char Token = '-';

            //------------Act------------------------
            var op = _operatorFactory.Create(Token);

            //------------Assert---------------------
            Assert.IsInstanceOfType(op, typeof(SubstractionOperator));
        }

        [TestMethod]
        public void MultiplySymbolReturnsMultiplicationOperator()
        {
            //------------Arrange--------------------
            const char Token = '*';

            //------------Act------------------------
            var op = _operatorFactory.Create(Token);

            //------------Assert---------------------
            Assert.IsInstanceOfType(op, typeof(MultiplicationOperator));
        }

        [TestMethod]
        public void DivideSymbolReturnsDivisionOperator()
        {
            //------------Arrange--------------------
            const char Token = '/';

            //------------Act------------------------
            var op = _operatorFactory.Create(Token);

            //------------Assert---------------------
            Assert.IsInstanceOfType(op, typeof(DivisionOperator));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperatorException))]
        public void InvalidOperatorExcpectsInvalidOperatorException()
        {
            //------------Arrange--------------------
            const char Token = ';';

            //------------Act------------------------
            var op = _operatorFactory.Create(Token);

            //------------Assert---------------------

            //Exception expected
        }
    }
}
