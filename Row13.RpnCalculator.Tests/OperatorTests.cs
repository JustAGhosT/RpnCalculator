using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Row13.RpnCalculator.Tests
{
    using Row13.RpnCalculator.Operators;

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
            Assert.AreEqual(3.5, result);
        }

        [TestMethod]
        public void SubstractionOperatorSubstracts()
        {          
            //------------Arrange--------------------
            var op = new SubstractionOperator();

            //------------Act------------------------
            var result = op.Eval(2.0, 1.5);

            //------------Assert---------------------
            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void MultiplicationOperatorMultiplies()
        {
            //------------Arrange--------------------
            var op = new MultiplicationOperator();

            //------------Act------------------------
            var result = op.Eval(2.0, 1.5);

            //------------Assert---------------------
            Assert.AreEqual(3.0, result);
        }

        [TestMethod]
        public void DivisionOperatorDivides()
        {
            //------------Arrange--------------------
            var op = new DivisionOperator();

            //------------Act------------------------
            var result = op.Eval(2.0, 1.5);

            //------------Assert---------------------
            Assert.AreEqual(4.0/3.0, result );
        }
    }
}
