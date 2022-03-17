
using Event_Management.Controllers;
using Event_Management.Models;
using Event_Management.MongodbContext;
using Event_Management.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;

namespace EventManagement.Test
{
    [TestFixture]
    public class TestController
    {
        private EventsController eventsController;
        private readonly Mock<EventService> eventService;
        private readonly Mock<IWebHostEnvironment> webHostEnvironment;
        private readonly Mock<IDatabaseSettings> databaseSettings;
        private readonly Mock<IMongoClient> mockClient;
        private readonly Mock<IMongoDatabase> mockDb;

        public TestController()
        {
            //x.Verify();
            //this.eventService = new EventService(x);
            //webHostEnvironment = new IWebHostEnvironment();
            databaseSettings = new Mock<IDatabaseSettings>();
            databaseSettings.Setup(x => x.ConnectionString).Returns("mongodb+srv://admin:admin@cluster0.6vdu6.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            databaseSettings.Setup(x => x.DatabaseName).Returns("Event");
            eventService = new Mock<EventService>(databaseSettings.Object);
            webHostEnvironment = new Mock<IWebHostEnvironment>();
            eventsController = new EventsController(eventService.Object, webHostEnvironment.Object);
            mockClient = new Mock<IMongoClient>();
            mockDb = new Mock<IMongoDatabase>();

        }
        //[SetUp]
        //public void Setup()
        //{
        //    var hostingEnvironment = Mock.Of<IWebHostEnvironment>(e => e.ApplicationName == "Class Reminder");
           
        //    eventsController = new EventsController(eventService, hostingEnvironment);
        //}

        [Test]
        public void GetReturnsProduct()
        {
            eventsController.Create();
            //User user = new User();
            //user.Email = "";
            //user.Name = "";
            //user.Password = "";
            //Assert.AreNotEqual(10, 1);
        }
        [Test]
        public void test()
        {
            //var z = eventsController.Index();
            // Assert.AreNotEqual(null, z);
            EventModel eventModel = new EventModel()
            {
                Id = "1214",
                EventName = "sample"
            };
            //mockDb.Setup(c => c.GetCollection<EventModel>("Event", null)).Returns(eventModel);
            var c = eventsController.Edit("6192bbfe982af0dd0be02dca");
            Assert.AreNotEqual(null, c);

        }
    }
}
