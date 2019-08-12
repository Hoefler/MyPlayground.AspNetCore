
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using MyPlayground.AspNetCore;
using MyPlayground.AspNetCore.Controllers;
using NUnit.Framework;

namespace Tests
{ 
    [TestFixture]
    public class ValuesControllerTests
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
            Mock<IDocumentService> documentServiceMock = new Mock<IDocumentService>();
            appSettingsMock.Setup(x => x.Value).Returns(new AppSettings());

            ValuesController controller = new ValuesController(loggerMock.Object, appSettingsMock.Object, documentServiceMock.Object);
            Assert.IsNotNull(controller);
        }
    }
}