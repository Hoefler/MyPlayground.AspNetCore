using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using MyPlayground.RazorPages;
using NUnit.Framework;

namespace MyPlayground.UiTests
{
   public class RazorPagesTests
    {
        private readonly WebApplicationFactory<Startup> factory = new WebApplicationFactory<Startup>();

        [TestCase("/")]
        [TestCase("/Index")]
        [TestCase("/Privacy")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            var client = this.factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.AreEqual("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}