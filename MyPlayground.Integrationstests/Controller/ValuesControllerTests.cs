using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using MyPlayground.AspNetCore;
using MyPlayground.Data;
using NUnit.Framework;

namespace MyPlayground.Integrationstests.Controller
{
    [TestFixture]
    public class ValuesControllerTests
    {
        private HttpClient _client;

        [SetUpAttribute]
        public void Setup()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .ConfigureServices(ConfigureServices)
                .UseStartup<Startup>());

            _client = server.CreateClient();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.TryAddTransient<IDocumentRepository>((ctx) =>
            {
                Mock<IDocumentRepository> documentRepositoryMock = new Mock<IDocumentRepository>();
                documentRepositoryMock.Setup(x => x.GetDocuments()).Returns(new List<string>() { "Mock1", "Mock2" });
                return documentRepositoryMock.Object;
            });
        }

        [Test]
        public void Get_Test()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/values");
            var response = _client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.Result.StatusCode);
            Assert.AreEqual("[\"Mock1\",\"Mock2\"]", response.Result.Content.ReadAsStringAsync().Result);
        }
    }
}