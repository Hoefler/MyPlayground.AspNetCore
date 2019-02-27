using MyPlayground.NHibernate;
using NHibernate;
using System.Collections.Generic;

namespace MyPlayground.Data
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly INHibernationSessionFactory _factory;

        internal RepositoryBase(INHibernationSessionFactory factory)
        {
            _factory = factory;
        }

        public IList<T> GetAll()
        {
            using (var session = _factory.OpenSession())
            {
                return session.QueryOver<T>().List();
            }
        }

        public void Save(T obj)
        {
            ITransaction transaction = null;
            try
            {
                using (var session = _factory.OpenSession())
                {
                    transaction = session.BeginTransaction();
                    session.SaveOrUpdate(obj);
                    transaction.Commit();
                }
            }
            catch (System.Exception exception)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                throw exception;
            }
            finally
            {
                if (transaction != null)
                {
                    transaction.Dispose();
                }
            }
        }
    }
}
