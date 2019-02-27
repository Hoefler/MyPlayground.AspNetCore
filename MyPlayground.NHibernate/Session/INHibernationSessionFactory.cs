using NHibernate;

namespace MyPlayground.NHibernate
{
    public interface INHibernationSessionFactory
    {
        ISession OpenSession();
    }
}