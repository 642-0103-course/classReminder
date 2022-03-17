using Event_Management.Controllers;
using Event_Management.Models;
using Event_Management.MongodbContext;
using Event_Management.Services;
using NUnit.Framework;


namespace EventManagement.Test
{
    [TestFixture]
    public class TestController
    {
        public EventService ev;
        public string ConnectionString = "mongodb+srv://admin:admin@cluster0.6vdu6.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
        public string DatabaseName = "Events";
        IDatabaseSettings settings;
        EventsController eventsController;
        public string id = "";

        [SetUp]
        public void Setup()
        {
            settings = new DatabaseSettings();
            settings.ConnectionString = ConnectionString;
            settings.DatabaseName = DatabaseName;
            ev = new EventService(settings);
            eventsController = new EventsController(ev, null);
        }



        [Test]
        public void TestGet()
        {
            var result = ev.Get();
            if (result != null)
            {
                id = result[0].Id;
                Assert.AreNotEqual(null, result);
            }
            else
            {
                Assert.AreEqual(null, result);
            }
            

        }
        [Test]
        public void TestSearchList()
        {
            var x = ev.SearchList("giridhar196@gmail.com");
            if (x == null)
            {
                Assert.AreNotEqual(null, ev.SearchList(id));
            }
            else
            {
                Assert.AreNotEqual(null, x);
            }
        }
        [Test]
        public void TestEditController()
        {
            var y = eventsController.Edit(id);
            Assert.AreNotEqual(null, y);
        }

    }
}
