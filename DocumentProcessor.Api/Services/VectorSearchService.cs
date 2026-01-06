using Azure.Search.Documents;
using DocumentProcessor.Api.Infrastructure;

namespace DocumentProcessor.Api.Services
{
    public class VectorSearchService
    {
        private readonly SearchClient _searchClient;

        public VectorSearchService(AzureClients clients)
        {
            _searchClient = clients.SearchClient;
        }

        public async Task IndexAsync(string id, string content)
        {
            var doc = new
            {
                id,
                content
            };

            await _searchClient.UploadDocumentsAsync(new[] { doc });
        }
    }
}
