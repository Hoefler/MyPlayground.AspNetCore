using Microsoft.Extensions.DependencyInjection;

namespace MyPlayground.NHibernate
{
    public static class IServiceCollectionExtension
    {
        public static void AddNHibernationSessionFactory(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<INHibernationSessionFactory, SQLiteInMemorySessionFactory>();
        }
    }
}