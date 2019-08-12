using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MyPlayground.Data
{
    public static class IServiceCollectionExtension
    {
        public static void AddDocumentRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddTransient<IDocumentRepository, DocumentRepository>();
        }
    }
}