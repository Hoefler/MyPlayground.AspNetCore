using System;
using System.Collections.Generic;
using MyPlayground.DataTransferObjects;
using MyPlayground.NHibernate;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

[assembly: InternalsVisibleTo("MyPlayground.UnitTests")]
[assembly: InternalsVisibleTo("MyPlayground.Integrationstests")]
namespace MyPlayground.Data
{
    public interface IDocumentRepository
    {
        IList<string> GetDocuments();
    }

    internal class DocumentRepository : RepositoryBase<DocumentDto>, IDocumentRepository
    {
        private readonly ILogger<IDocumentRepository> _logger;

        public DocumentRepository(INHibernationSessionFactory factory, ILogger<IDocumentRepository> logger)
            : base(factory)
        {
            _logger = logger;
        }

        public IList<string> GetDocuments()
        {
            _logger.LogDebug("GetDocuments");

            throw new Exception("Db is not available");
            //return new string[] { "value1", "value2" };
        }

    }
}
