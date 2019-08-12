using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MyPlayground.AspNetCore;
using MyPlayground.Data;

namespace MyPlayground.Integrationstests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddTransient<IDocumentRepository>((ctx) =>
            {
                Mock<IDocumentRepository> documentRepositoryMock = new Mock<IDocumentRepository>();
                documentRepositoryMock.Setup(x => x.GetDocuments()).Returns(new List<string>() { "Mock1", "Mock2" });
                return documentRepositoryMock.Object;
            });
        }
    }
}