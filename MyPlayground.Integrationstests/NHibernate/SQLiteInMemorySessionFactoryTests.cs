using MyPlayground.NHibernate;
using NUnit.Framework;

namespace MyPlayground.Integrationstests.NHibernate
{
    [TestFixture]
    public class SQLiteInMemorySessionFactoryTests
    {
        [Test]
        public void Create_Test()
        {
            SQLiteInMemorySessionFactory factory = new SQLiteInMemorySessionFactory();
            Assert.IsNotNull(factory);
        }
    }
}
