using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.AreEqual("FizzBuzz", result);
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy3_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            Assert.AreEqual("Fizz", result);
        }
        [Test]
        public void GetOutput_InputIsDivisibleBy5_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
            Assert.AreEqual("Buzz", result);
        }
        [Test]
        public void GetOutput_InputNotDivisibleBy3And5_ReturnSameNumber()
        {
            var result = FizzBuzz.GetOutput(1);
            Assert.AreEqual("1", result);
        }
    }
}
