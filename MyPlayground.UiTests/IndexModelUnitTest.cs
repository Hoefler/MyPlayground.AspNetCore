using MyPlayground.RazorPages.Pages;
using NUnit.Framework;

namespace MyPlayground.UiTests
{
    public class IndexModelUnitTest
    {
        [Test]
        public void IndexModelTests()
        {
            IndexModel indexModel = new IndexModel();
            indexModel.OnGet();

            Assert.AreEqual(2, indexModel.Messages.Count);
        }
    }
}
