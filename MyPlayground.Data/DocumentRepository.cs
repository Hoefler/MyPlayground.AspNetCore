using MyPlayground.DataTransferObjects;
using MyPlayground.NHibernate;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MyPlayground.UnitTests")]
[assembly: InternalsVisibleTo("MyPlayground.Integrationstests")]
namespace MyPlayground.Data
{
    public interface IDocumentRepository
    {

    }

    internal class DocumentRepository : RepositoryBase<DocumentDto>, IDocumentRepository
    {
        public DocumentRepository(INHibernationSessionFactory factory)
            : base(factory)
        {
        }
    }
}
