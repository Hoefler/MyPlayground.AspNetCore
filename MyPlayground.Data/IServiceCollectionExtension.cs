using Microsoft.Extensions.DependencyInjection;

namespace MyPlayground.Data
{
    public static class IServiceCollectionExtension
    {
        public static void AddDocumentRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDocumentRepository, DocumentRepository>();
        }
    }
}