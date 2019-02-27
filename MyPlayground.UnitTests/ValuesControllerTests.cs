
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using MyPlayground.AspNetCore;
using MyPlayground.AspNetCore.Controllers;
using NUnit.Framework;

namespace Tests
{ 
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Tests()
        {
            Mock<ILogger<ValuesController>> loggerMock = new Mock<ILogger<ValuesController>>();
            Mock<IOptions<AppSettings>> appSettingsMock = new Mock<IOptions<AppSettings>>();
            appSettingsMock.Setup(x => x.Value).Returns(new AppSettings());

            ValuesController controller = new ValuesController(loggerMock.Object, appSettingsMock.Object);
            Assert.IsNotNull(controller);
        }
    }
}