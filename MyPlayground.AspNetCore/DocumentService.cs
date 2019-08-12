using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MyPlayground.Data;

namespace MyPlayground.AspNetCore
{
    public interface IDocumentService
    {
        IList<string> GetDocuments();
    }

    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IDocumentRepository documentRepository, ILogger<DocumentService> logger)
        {
            _documentRepository = documentRepository;
            _logger = logger;
        }

        public IList<string> GetDocuments()
        {
            _logger.LogDebug("GetDocuments");
            return _documentRepository.GetDocuments();
        }
    }
}
