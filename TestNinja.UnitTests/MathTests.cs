using NUnit.Framework;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private TestNinja.Fundamentals.Math _math;
        //SetUp
        //TearUp

        [SetUp]
        public void SetUp()
        {
            _math = new TestNinja.Fundamentals.Math();
        }

        [Test]
        //[Ignore("kasnije")]
        public void Add_WhenCallen_ReturnThSumOfArgumets()
        {
            var result = _math.Add(1, 2);
            Assert.AreEqual(result, 3);
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenFirstGreater_ReturnGreater(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.AreEqual(result, expectedResult);
        }
       
    }
}
