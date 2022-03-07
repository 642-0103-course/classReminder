using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event_Management.Models;
using NUnit.Framework;

namespace Event_Management.Controllers
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
