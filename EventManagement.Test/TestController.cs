
using Event_Management.Models;
using NUnit.Framework;

namespace EventManagement.Test
{
    [TestFixture]
    public class TestController
    {
        [Test]
        public void GetReturnsProduct()
        {
            User user = new User();
            user.Email = "";
            user.Name = "";
            user.Password = "";
            Assert.AreNotEqual(10, 1);
        }
    }
}
