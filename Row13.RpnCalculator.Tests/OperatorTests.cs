using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Row13.RpnCalculator.Tests
{
    [TestClass]
    public class OperatorTests
    {
        [TestMethod]
        public void AdditionOperatorAdds()
        {
            //------------Arrange--------------------
            var op = new AdditionOperator();

            //------------Act------------------------
            var result = op.Eval(2.0, 1.5);

            //------------Assert---------------------
            Assert.AreEqual(result, 3.5);
        }

        [TestMethod]
        public void SubstractionOperatorSubstracts()
        {          
            //------------Arrange--------------------
            var op = new SubstractionOperator();

            //------------Act------------------------
            var result = op.Eval(2.0, 1.5);

            //------------Assert---------------------
            Assert.AreEqual(result, 0.5);
        }

        [TestMethod]
        public void MultiplicationOperatorMultiplies()
        {
            //------------Arrange--------------------
            var op = new MultiplicationOperator();

            //------------Act------------------------
            var result = op.Eval(2.0, 1.5);

            //------------Assert---------------------
            Assert.AreEqual(result, 3.0);
        }

        [TestMethod]
        public void DivisionOperatorDivides()
        {
            //------------Arrange--------------------
            var op = new DivisionOperator();

            //------------Act------------------------
            var result = op.Eval(2.0, 1.5);

            //------------Assert---------------------
            Assert.AreEqual(result, 4/3);
        }
    }
}
