using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace MyPlayground.NHibernate
{
    public class SQLiteInMemorySessionFactory : INHibernationSessionFactory
    {
        private ISessionFactory _sessionFactory;
        private SQLiteConnection _dbConnection;

        public SQLiteInMemorySessionFactory()
        {
            Create();
        }

        private void BuildConnection()
        {
           
        }

        private void BuildSchema()
        {
            
        }

        public void Create()
        {
            if (_sessionFactory == null)
            {
                _dbConnection = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");
                _dbConnection.Open();

                var fluentConfiguration = Fluently.Configure();

                StringWriter writer = new StringWriter();

                _sessionFactory = fluentConfiguration
                    .Database(SQLiteConfiguration.Standard.InMemory)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DocumentDtoMap>())
                    .BuildSessionFactory();

                new SchemaExport(fluentConfiguration.BuildConfiguration())
                    .Execute(true, true, false, _dbConnection, writer);
            }
        }

        public ISession OpenSession()
        {
            return _sessionFactory.WithOptions().Connection(_dbConnection).OpenSession();
        }
    }
}
