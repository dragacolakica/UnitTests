using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        [Test]
        public void GetCutomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(0);
            Assert.That(result, Is.TypeOf<NotFound>()); //just NotFound object
            //Assert.That(result, Is.InstanceOf<NotFound>()); // and its derivatives
        }
        [Test]
        public void GetCutomer_IdNotZero_ReturnOk()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(1);
            Assert.That(result, Is.TypeOf<Ok>()); //just NotFound object
            //Assert.That(result, Is.InstanceOf<Ok>()); // and its derivatives
        }


    }
}
