using MyPlayground.DataTransferObjects;
using MyPlayground.NHibernate;

namespace MyPlayground.Data
{
    public class DocumentRepository : RepositoryBase<DocumentDto>
    {
        public DocumentRepository(INHibernationSessionFactory factory)
            : base(factory)
        {
        }
    }
}
