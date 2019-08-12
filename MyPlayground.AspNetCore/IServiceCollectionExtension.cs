using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MyPlayground.AspNetCore
{

    public static class IServiceCollectionExtension
    {
        public static void AddDocumentService(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddTransient<IDocumentService, DocumentService>();
        }
    }
}
