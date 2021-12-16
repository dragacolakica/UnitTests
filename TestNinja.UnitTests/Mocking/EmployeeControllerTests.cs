using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private Mock<IEmployeeStorage> _employeeStorage;
        private EmployeeController _controller;

        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _controller = new EmployeeController(_employeeStorage.Object);
        }

        [Test]
        public void DeleteEmployee_DeleteFromDB()
        {
            _controller.DeleteEmployee(1);
            _employeeStorage.Verify(x => x.DeleteEmployee(1));
        }
    }
}
