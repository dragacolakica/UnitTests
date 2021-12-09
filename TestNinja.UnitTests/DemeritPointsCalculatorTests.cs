using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        public void CalculateDemeritPoints_SpeedIsOverLimit_ReturnPoints()
        {
            var calculator = new DemeritPointsCalculator();
            var result = calculator.CalculateDemeritPoints(165);
            Assert.AreEqual(20, result);
        }
        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        public void CalculateDemeritPoints_SpeedIsUnderLimit_ReturnZero(int a, int b)
        {
            var calculator = new DemeritPointsCalculator();
            var result = calculator.CalculateDemeritPoints(a);
            Assert.AreEqual(b, result);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsUnderZero_ThrowException(int a)
        {
            var calculator = new DemeritPointsCalculator();
            Assert.That(() => calculator.CalculateDemeritPoints(a),
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

    }
}
