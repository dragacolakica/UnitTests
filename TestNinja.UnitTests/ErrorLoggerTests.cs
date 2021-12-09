using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void LogWhenCalled_SetTheLastErrorPorperty()
        {

            var logger = new ErrorLogger();
            logger.Log("d");
            Assert.That(logger.LastError, Is.EqualTo("d"));

        }
    }
}
