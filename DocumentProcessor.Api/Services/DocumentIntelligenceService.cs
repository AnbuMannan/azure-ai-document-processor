using Azure.AI.FormRecognizer.DocumentAnalysis;
using DocumentProcessor.Api.Infrastructure;

namespace DocumentProcessor.Api.Services
{
    public class DocumentIntelligenceService
    {
        private readonly DocumentAnalysisClient _client;

        public DocumentIntelligenceService(AzureClients clients)
        {
            _client = clients.DocumentClient;
        }

        public async Task<string> ExtractTextAsync(Stream document)
        {
            var operation = await _client.AnalyzeDocumentAsync(
                Azure.WaitUntil.Completed,
                "prebuilt-invoice",
                document);

            return operation.Value.Content;
        }
    }
}
